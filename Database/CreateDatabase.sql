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

--CREATE COUNTRY TABLE...
CREATE TABLE UC.Activities
(
	id_activity INT Identity(1,1) NOT NULL
   ,create_date DATE NOT NULL
   ,id_user VARCHAR(3) NOT NULL
   ,activity_description VARCHAR(150) NOT NULL
   ,CONSTRAINT PK_Activities_Id PRIMARY KEY(id_activity)
)
GO