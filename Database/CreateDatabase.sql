USE master
GO
--CREATE DATABASE...
CREATE DATABASE Loymark
GO

USE Loymark
GO

--CREATE SCHEMAS...

--UC SCHEMA MEANS "USER CONTROL": THIS SCHEMA CONTAINS THE 
CREATE SCHEMA UC
GO

--CM SCHEMA MEANS "COMMON": THIS SCHEMA CAN CONTAINS ALL TABLE AND DATABASE OBJECTS THAT CAN BE SHARED OR COMMON TO OTHERS SCHEMAS...
CREATE SCHEMA CM
GO

--CREATE COUNTRY TABLE...
CREATE TABLE CM.Countries
(
	 Id INT Identity(1,1) NOT NULL
   ,CountryName VARCHAR(100) NOT NULL
   ,Alpha3Code VARCHAR(3) NOT NULL
   ,CONSTRAINT PK_Countries_Id PRIMARY KEY(Id)
)
GO

--CREATE USERS TABLE...
CREATE TABLE UC.Users
(
	 Id INT Identity(1,1) NOT NULL
   ,Name VARCHAR(100) NOT NULL
   ,LastName VARCHAR(100) NOT NULL
   ,Email VARCHAR(150) NOT NULL
   ,Birthday DATE NOT NULL
   ,TelephoneNumber INT NULL
   ,SendNews BIT NOT NULL 
   ,CountryId INT NOT NULL
   ,CONSTRAINT PK_Users_Id PRIMARY KEY(Id)
)
GO

--ADD FOREIGK KEY RELATIONSHIP BETWEEN COUNTRIES AND USERS...
ALTER TABLE UC.Users ADD CONSTRAINT FK_Users_Countries_CountryId FOREIGN KEY(CountryId) REFERENCES CM.Countries(Id)
GO

--CREATE ACTIVITIES TABLE...
CREATE TABLE UC.Activities
(
    id_activity INT Identity(1,1) NOT NULL
   ,create_date DATETIME NOT NULL DEFAULT GETDATE()
   ,activity_type VARCHAR(3) NOT NULL
   ,activity_description VARCHAR(150) NOT NULL
   ,id_user INT NOT NULL
   ,data_user VARCHAR(MAX) NOT NULL
   ,CONSTRAINT PK_Activities_Id PRIMARY KEY(id_activity)
)
GO

-- =============================================
-- Author:		<BRAYAN GAZO>
-- Create date: <26-06-2022>
-- Description:	<USER DEFINE FUNCTION TO CHECK INTEGRITY BETWEEN TABLE USERS AND ACTIVITIES (USER_ID)>
-- =============================================
CREATE FUNCTION UC.CheckIfUserExists
(  
	@Id_User INT
   ,@Activity_Type VARCHAR(3)
)
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT = 1;

	---APPLY THIS RULE ONLY WHEN ACTION IS NOT A DELETE ELSE RETURN TRUE (KEEP HISTORIC OF DELETED USERS)...
	IF @Activity_Type <> 'd'
	BEGIN
		SET @Result = (SELECT CASE WHEN EXISTS(SELECT TOP 1 Id FROM UC.Users WHERE Id = @Id_User) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END);
	END

	RETURN @Result;
END
GO

--ADD CHECK CONTRAINT TO ACTIVITIES TABLE...
ALTER TABLE UC.Activities 
ADD CONSTRAINT CK_CheckIfUserExists
CHECK (UC.CheckIfUserExists(id_user, activity_type) = 1)
GO

-- =======================================================================================
-- Author:		<BRAYAN GAZO>
-- Create date: <26/06/2022>
-- Description:	<TRIGGER PARA AUDITAR CAMBIOS EN LA TABLA DE USUARIOS>
------------------------------------------------------------------------------------------
-- Event     |	INSERTED table holds |	DELETED table holds								 -
-- INSERT	 |  rows to be inserted	 |  empty										     -
-- UPDATE	 |  new rows modified by |  the update	existing rows modified by the update -
-- DELETE	 |  empty	             |  rows to be deleted							     -
------------------------------------------------------------------------------------------
-- =======================================================================================
CREATE TRIGGER [UC].[TrgUserAudit] ON [UC].[Users] AFTER INSERT, UPDATE, DELETE
AS
BEGIN

    SET NOCOUNT ON;

	DECLARE @DataUser VARCHAR(MAX); --HERE WE SAVE THE JSON DATA OF THE AFECTED ROW...

	--IF IT IS AN INSERT OR UPDATE...
	IF EXISTS (SELECT 0 FROM inserted)
	BEGIN
		--SET @DataUser = TRIM('[]' FROM (SELECT * FROM inserted FOR JSON PATH)); --INSERT OR DELETE, ROW AFFECTED IS GONNA BE IN INSERTED....
		SET @DataUser =  REPLACE(REPLACE((SELECT * FROM inserted FOR JSON PATH), '[', ''), ']', '');
		IF EXISTS (SELECT 0 FROM deleted) --IT IS AN UPDATE...
		BEGIN 
			INSERT INTO UC.Activities
			(
				create_date 
			   ,activity_description
			   ,activity_type
			   ,id_user
			   ,data_user
			)
			SELECT GETDATE()
				  ,'User Updated'
				  ,'u'
				  ,I.Id
				  ,@DataUser
			FROM inserted AS I
		END 
		ELSE --IT IS AN INSERT...
		BEGIN
			INSERT INTO UC.Activities
			(
				create_date 
			   ,activity_description
			   ,activity_type
			   ,id_user
			   ,data_user
			)
			SELECT GETDATE()
				  ,'User Created'
				  ,'i'
				  ,I.Id
				  ,@DataUser

			FROM inserted AS I
		END
	END 
	ELSE --ELSE IT IS A DELETE...
	BEGIN
	   --SET @DataUser = TRIM('[]' FROM (SELECT * FROM deleted FOR JSON PATH));
	   SET @DataUser =  REPLACE(REPLACE((SELECT * FROM inserted FOR JSON PATH), '[', ''), ']', '');
	   INSERT INTO UC.Activities
	   (
			create_date 
		   ,activity_description
		   ,activity_type
		   ,id_user
		   ,data_user
		)
		SELECT GETDATE()
			  ,'User Deleted'
			  ,'d'
			  ,D.Id
			  ,@DataUser

		FROM deleted AS D
	END 
END
