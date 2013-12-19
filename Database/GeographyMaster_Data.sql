USE [GeographyMaster]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 12/20/2013 00:43:48 ******/
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 12/20/2013 00:43:48 ******/
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 12/20/2013 00:43:48 ******/
/****** Object:  Table [dbo].[User]    Script Date: 12/20/2013 00:43:48 ******/
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([IdUser], [Username], [Password]) VALUES (2, N'admin', N'admin1!2@')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Subcategory]    Script Date: 12/20/2013 00:43:48 ******/
SET IDENTITY_INSERT [dbo].[Subcategory] ON
INSERT [dbo].[Subcategory] ([IdSubcategory], [Subcategory]) VALUES (1, N'Flags')
INSERT [dbo].[Subcategory] ([IdSubcategory], [Subcategory]) VALUES (2, N'Capital cities')
INSERT [dbo].[Subcategory] ([IdSubcategory], [Subcategory]) VALUES (3, N'Countries')
SET IDENTITY_INSERT [dbo].[Subcategory] OFF
/****** Object:  Table [dbo].[Category]    Script Date: 12/20/2013 00:43:48 ******/
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (1, N'Europe')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (2, N'Asia')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (3, N'Australia and Oceania')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (4, N'South America')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (5, N'North America')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (6, N'Africa')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Badge]    Script Date: 12/20/2013 00:43:48 ******/
/****** Object:  Table [dbo].[Question]    Script Date: 12/20/2013 00:43:48 ******/
SET IDENTITY_INSERT [dbo].[Question] ON
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (3, 1, 2, N'What is the capital of Slovenia?', 9)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (5, 1, 2, N'What is the capital of France?', 6)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (6, 1, 2, N'What is the capital of  Italy?', 2)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (7, 3, 1, N' In which Australian State would you find Lake Eyre?', 3)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (9, 6, 1, N'Zanzibar and Pemba Islands are part of which country?', 5)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (10, 1, 2, N'What is the capital of Serbia?', 5)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (12, 1, 2, N'What is the capital of Macedonia?', 3)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [IdSubcategory], [Question], [NoStars]) VALUES (13, 1, 2, N'Test question', 2)
SET IDENTITY_INSERT [dbo].[Question] OFF
/****** Object:  Table [dbo].[InfoBox]    Script Date: 12/20/2013 00:43:48 ******/
SET IDENTITY_INSERT [dbo].[InfoBox] ON
INSERT [dbo].[InfoBox] ([IdInfoBox], [IdCategory], [InfoBox]) VALUES (1, 3, N'Nesto pravilno 1')
SET IDENTITY_INSERT [dbo].[InfoBox] OFF
/****** Object:  Table [dbo].[Score]    Script Date: 12/20/2013 00:43:48 ******/
/****** Object:  Table [dbo].[Hint]    Script Date: 12/20/2013 00:43:48 ******/
SET IDENTITY_INSERT [dbo].[Hint] ON
INSERT [dbo].[Hint] ([IdHint], [IdQuestion], [Hint]) VALUES (2, 3, N'The beautiful Ljubljanica river goes through the center of this city.')
INSERT [dbo].[Hint] ([IdHint], [IdQuestion], [Hint]) VALUES (3, 3, N'The Triple Bridge (Slovene: Tromostovje, in older sources also Tromostje) is a group of three bridges across the Ljubljanica river and it is part of the city that you are looking for.')
INSERT [dbo].[Hint] ([IdHint], [IdQuestion], [Hint]) VALUES (4, 5, N'The city where the Eiffel Tour is.')
INSERT [dbo].[Hint] ([IdHint], [IdQuestion], [Hint]) VALUES (5, 6, N'Colosseum. ')
INSERT [dbo].[Hint] ([IdHint], [IdQuestion], [Hint]) VALUES (6, 12, N'The city of bizarre monuments.')
SET IDENTITY_INSERT [dbo].[Hint] OFF
/****** Object:  Table [dbo].[Answer]    Script Date: 12/20/2013 00:43:48 ******/
SET IDENTITY_INSERT [dbo].[Answer] ON
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (2, N'Skopje', 12, 1)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (11, N'Celje', 3, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (12, N'Paris', 5, 1)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (13, N'Lyon', 5, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (14, N'Strasbourg', 5, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (15, N'Rome', 6, 1)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (16, N'Venice', 6, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (17, N'Florence', 6, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (18, N'Ljubljana', 3, 1)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (19, N'Maribor', 3, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (20, N'Bitola', 12, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (21, N'Ohrid', 12, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (22, N'Niš', 10, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (23, N'Novi Sad', 10, 0)
INSERT [dbo].[Answer] ([IdAnswer], [AnswerDescription], [IdQuestion], [IsTrue]) VALUES (24, N'Belgrade', 10, 1)
SET IDENTITY_INSERT [dbo].[Answer] OFF
