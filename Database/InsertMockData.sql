USE [Loymark]
GO
SET IDENTITY_INSERT [CM].[Countries] ON 

INSERT [CM].[Countries] ([Id], [CountryName], [Alpha3Code]) VALUES (1, N'Costa Rica', N'CRI')
INSERT [CM].[Countries] ([Id], [CountryName], [Alpha3Code]) VALUES (2, N'Nicaragua', N'NIC')
INSERT [CM].[Countries] ([Id], [CountryName], [Alpha3Code]) VALUES (3, N'Mexico', N'MEX')
SET IDENTITY_INSERT [CM].[Countries] OFF
GO

DISABLE TRIGGER [UC].[TrgUserAudit] ON UC.[Users]
GO

SET IDENTITY_INSERT [UC].[Users] ON 

INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (2, N'John', N'Dere', N'derejohn@mail.com', CAST(N'1987-01-15' AS Date), 87878787, 1, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (4, N'Rick', N'Sanchez', N'rickrules@universe.com', CAST(N'1980-12-31' AS Date), 66666666, 1, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (5, N'Oliver', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (9, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (14, N'Rick', N'Sanchez', N'rickrules@universe.com', CAST(N'1980-12-31' AS Date), 66666666, 1, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (16, N'THIS A TEST ', N'I KNOW', N'email.mail@edu.com', CAST(N'1980-05-25' AS Date), 81818282, 0, 2)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (17, N'Carlos José', N'Albertardo Mata', N'test@delte.com', CAST(N'1898-08-16' AS Date), 56565454, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (18, N'HOLA ', N'MONA', N'mail@sfd.com', CAST(N'1992-01-06' AS Date), 84845858, 1, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (22, N'Hello', N'Kitty', N'audit@mail.com.ku', CAST(N'2020-06-08' AS Date), 65656464, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (23, N'his', N'a test', N'ma@maik.com', CAST(N'2020-01-21' AS Date), 25255454, 1, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (24, N'WELL', N'THIS IS ANOTHER', N'WELL@MAIL.COM', CAST(N'2020-03-30' AS Date), 6565566, 0, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (25, N'Bryan Javier', N'Gazo Mejía', N'gxzzin@outlook.com', CAST(N'1994-12-04' AS Date), 84179401, 1, 2)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (26, N'Jose', N'Perez', N'perezjose@mail.com', CAST(N'1991-06-15' AS Date), 87451287, 0, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (27, N'New User', N'Thi is is s', N'new@mail.com', CAST(N'2020-02-06' AS Date), 85458763, 0, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (28, N'This is a new User {EDITED}', N'new user', N'newiuser@mail.com', CAST(N'2020-06-06' AS Date), 54542132, 1, 2)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (29, N'José Mendéz', N'Añiratu Gazez', N'mail.com.mail', CAST(N'2028-01-06' AS Date), 87693665, 0, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (30, N'Oscar', N'Lopéz', N'oscarmail@mail.com', CAST(N'2022-06-01' AS Date), 87874526, 0, 2)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (31, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (32, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (33, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (34, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (35, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (36, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (37, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (38, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (39, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (40, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (41, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (42, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (43, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (44, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (45, N'Prueba x', N'Atom', N'atom@football.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (48, N'Prueba x', N'Atom', N'atom@footbalgl.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 3)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (51, N'Prueba x', N'Atom', N'atom@footbalgdfl.com', CAST(N'1990-05-18' AS Date), 66666666, 1, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (52, N'caracola', N'lola', N'mail@mail.com', CAST(N'2022-06-01' AS Date), 2147483647, 0, 1)
INSERT [UC].[Users] ([Id], [Name], [LastName], [Email], [Birthday], [TelephoneNumber], [SendNews], [CountryId]) VALUES (53, N'Javier Bryan', N'Mejía Gazo', N'gxzzin1@outlook.com', CAST(N'2022-06-01' AS Date), 878878787, 1, 2)
SET IDENTITY_INSERT [UC].[Users] OFF
GO

ENABLE TRIGGER [UC].[TrgUserAudit] ON UC.[Users]
GO

SET IDENTITY_INSERT [UC].[Activities] ON 

INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (1, CAST(N'2022-06-26T10:04:28.787' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier","LastName":"Gazo","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":88888888,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (2, CAST(N'2022-06-26T10:04:38.573' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":88888888,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (3, CAST(N'2022-06-26T10:05:02.960' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":false,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (4, CAST(N'2022-06-26T10:06:00.773' AS DateTime), N'd', N'User Deleted', 1, N'{"Id":1,"Name":"Bryan Javier","LastName":"Gazo Mejía","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":88888888,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (5, CAST(N'2022-06-26T10:08:01.390' AS DateTime), N'i', N'User Created', 26, N'{"Id":26,"Name":"Jose","LastName":"Perez","Email":"perezjose@mail.com","Birthday":"1991-06-15","TelephoneNumber":87451287,"SendNews":false,"CountryId":1}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (6, CAST(N'2022-06-26T10:16:26.070' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier [EDITADO]","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":false,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (7, CAST(N'2022-06-26T10:18:31.100' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier ","LastName":"Gazo Mejia [EDITADO]","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (8, CAST(N'2022-06-26T10:19:05.520' AS DateTime), N'u', N'User Updated', 18, N'{"Id":18,"Name":"HOLA ","LastName":"MONA","Email":"mail@sfd.com","Birthday":"1992-01-06","TelephoneNumber":84845858,"SendNews":true,"CountryId":1}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (9, CAST(N'2022-06-26T10:28:06.727' AS DateTime), N'i', N'User Created', 27, N'{"Id":27,"Name":"New User","LastName":"Thi is is s","Email":"new@mail.com","Birthday":"2020-02-06","TelephoneNumber":85458763,"SendNews":false,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (10, CAST(N'2022-06-26T10:29:12.623' AS DateTime), N'u', N'User Updated', 22, N'{"Id":22,"Name":"HELLO ","LastName":"AUDIT [EDITED]","Email":"audit@mail.com.ku","Birthday":"2020-06-08","TelephoneNumber":65656464,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (11, CAST(N'2022-06-26T10:32:18.750' AS DateTime), N'u', N'User Updated', 17, N'{"Id":17,"Name":"Carlos","LastName":"Albertardo","Email":"test@delte.com","Birthday":"1898-08-16","TelephoneNumber":56565454,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (12, CAST(N'2022-06-26T10:32:44.377' AS DateTime), N'u', N'User Updated', 22, N'{"Id":22,"Name":"Hello","LastName":"Kitty","Email":"audit@mail.com.ku","Birthday":"2020-06-08","TelephoneNumber":65656464,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (13, CAST(N'2022-06-26T10:32:58.130' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier ","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (15, CAST(N'2022-06-26T11:11:08.633' AS DateTime), N'i', N'User Created', 28, N'{"Id":28,"Name":"This is a new User","LastName":"new user","Email":"newiuser@mail.com","Birthday":"2020-06-06","TelephoneNumber":54542132,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (35, CAST(N'2022-06-26T11:12:25.217' AS DateTime), N'u', N'User Updated', 28, N'{"Id":28,"Name":"This is a new User {EDITED}","LastName":"new user","Email":"newiuser@mail.com","Birthday":"2020-06-06","TelephoneNumber":54542132,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (36, CAST(N'2022-06-26T12:02:38.140' AS DateTime), N'i', N'User Created', 29, N'{"Id":29,"Name":"José Mendéz","LastName":"Añiratu Gazez","Email":"mail.com.mail","Birthday":"2028-01-06","TelephoneNumber":87693665,"SendNews":false,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (37, CAST(N'2022-06-26T13:24:33.243' AS DateTime), N'i', N'User Created', 30, N'{"Id":30,"Name":"Oscar","LastName":"Lopéz","Email":"oscarmail@mail.com","Birthday":"2022-06-01","TelephoneNumber":87874526,"SendNews":false,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (38, CAST(N'2022-06-26T13:57:56.267' AS DateTime), N'i', N'User Created', 31, N'{"Id":31,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (39, CAST(N'2022-06-26T13:57:58.350' AS DateTime), N'i', N'User Created', 32, N'{"Id":32,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (40, CAST(N'2022-06-26T13:57:59.157' AS DateTime), N'i', N'User Created', 33, N'{"Id":33,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (41, CAST(N'2022-06-26T13:57:59.877' AS DateTime), N'i', N'User Created', 34, N'{"Id":34,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (42, CAST(N'2022-06-26T13:58:00.783' AS DateTime), N'i', N'User Created', 35, N'{"Id":35,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (43, CAST(N'2022-06-26T13:58:01.550' AS DateTime), N'i', N'User Created', 36, N'{"Id":36,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (44, CAST(N'2022-06-26T13:58:02.097' AS DateTime), N'i', N'User Created', 37, N'{"Id":37,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (45, CAST(N'2022-06-26T13:58:02.767' AS DateTime), N'i', N'User Created', 38, N'{"Id":38,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (46, CAST(N'2022-06-26T13:58:03.430' AS DateTime), N'i', N'User Created', 39, N'{"Id":39,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (47, CAST(N'2022-06-26T13:58:04.033' AS DateTime), N'i', N'User Created', 40, N'{"Id":40,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (48, CAST(N'2022-06-26T13:58:04.430' AS DateTime), N'i', N'User Created', 41, N'{"Id":41,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (49, CAST(N'2022-06-26T13:58:04.847' AS DateTime), N'i', N'User Created', 42, N'{"Id":42,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (50, CAST(N'2022-06-26T13:58:05.220' AS DateTime), N'i', N'User Created', 43, N'{"Id":43,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (51, CAST(N'2022-06-26T13:58:07.023' AS DateTime), N'i', N'User Created', 44, N'{"Id":44,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (52, CAST(N'2022-06-26T13:58:07.687' AS DateTime), N'i', N'User Created', 45, N'{"Id":45,"Name":"Prueba x","LastName":"Atom","Email":"atom@football.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (53, CAST(N'2022-06-26T14:18:58.967' AS DateTime), N'i', N'User Created', 48, N'{"Id":48,"Name":"Prueba x","LastName":"Atom","Email":"atom@footbalgl.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":3}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (54, CAST(N'2022-06-26T14:38:06.860' AS DateTime), N'i', N'User Created', 51, N'{"Id":51,"Name":"Prueba x","LastName":"Atom","Email":"atom@footbalgdfl.com","Birthday":"1990-05-18","TelephoneNumber":66666666,"SendNews":true,"CountryId":1}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (55, CAST(N'2022-06-26T14:42:57.333' AS DateTime), N'i', N'User Created', 52, N'{"Id":52,"Name":"caracola","LastName":"lola","Email":"mail@mail.com","Birthday":"2022-06-01","TelephoneNumber":2147483647,"SendNews":false,"CountryId":1}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (56, CAST(N'2022-06-26T14:43:12.913' AS DateTime), N'u', N'User Updated', 52, N'{"Id":52,"Name":"caracola","LastName":"lola","Email":"mail@mail.com","Birthday":"2022-06-01","TelephoneNumber":2147483647,"SendNews":false,"CountryId":1}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (57, CAST(N'2022-06-26T15:04:37.677' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier DEVELOPER","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (58, CAST(N'2022-06-26T15:05:33.980' AS DateTime), N'i', N'User Created', 53, N'{"Id":53,"Name":"Javier ","LastName":"Mejía","Email":"gxzzin1@outlook.com","Birthday":"2022-06-01","TelephoneNumber":878878787,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (59, CAST(N'2022-06-26T15:05:56.400' AS DateTime), N'u', N'User Updated', 53, N'{"Id":53,"Name":"Javier Bryan","LastName":"Mejía Gazo","Email":"gxzzin1@outlook.com","Birthday":"2022-06-01","TelephoneNumber":878878787,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (60, CAST(N'2022-06-26T15:06:08.693' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier DEVELOPER","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":false,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (61, CAST(N'2022-06-26T22:04:52.470' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":false,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (62, CAST(N'2022-06-26T22:44:14.873' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier","LastName":"Gazo Mejia","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (63, CAST(N'2022-06-26T22:44:29.327' AS DateTime), N'u', N'User Updated', 25, N'{"Id":25,"Name":"Bryan Javier","LastName":"Gazo Mejía","Email":"gxzzin@outlook.com","Birthday":"1994-12-04","TelephoneNumber":84179401,"SendNews":true,"CountryId":2}')
INSERT [UC].[Activities] ([id_activity], [create_date], [activity_type], [activity_description], [id_user], [data_user]) VALUES (64, CAST(N'2022-06-26T23:09:45.507' AS DateTime), N'u', N'User Updated', 17, N'{"Id":17,"Name":"Carlos José","LastName":"Albertardo Mata","Email":"test@delte.com","Birthday":"1898-08-16","TelephoneNumber":56565454,"SendNews":true,"CountryId":3}')
SET IDENTITY_INSERT [UC].[Activities] OFF
GO
