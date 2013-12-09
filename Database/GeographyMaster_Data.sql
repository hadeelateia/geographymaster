USE [GeographyMaster]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 12/09/2013 22:30:16 ******/
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 12/09/2013 22:30:16 ******/
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 12/09/2013 22:30:16 ******/
/****** Object:  Table [dbo].[User]    Script Date: 12/09/2013 22:30:16 ******/
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([IdUser], [Username], [Password]) VALUES (2, N'admin', N'admin1!2@')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Category]    Script Date: 12/09/2013 22:30:16 ******/
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (1, N'Europe')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (2, N'Asia')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (3, N'Australia and Oceania')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (4, N'South America')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (5, N'North America')
INSERT [dbo].[Category] ([IdCategory], [Continent]) VALUES (6, N'Africa')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Badge]    Script Date: 12/09/2013 22:30:16 ******/
/****** Object:  Table [dbo].[Question]    Script Date: 12/09/2013 22:30:16 ******/
SET IDENTITY_INSERT [dbo].[Question] ON
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [Question], [NoStars]) VALUES (3, 5, N'In which English County would you find Stonehenge?', 5)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [Question], [NoStars]) VALUES (5, 2, N'To visit the ruins of Persepolis, an ancient ceremonial capital of Persia, you would have to travel to what present-day country?', 10)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [Question], [NoStars]) VALUES (6, 1, N'What is Benelux?', 2)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [Question], [NoStars]) VALUES (7, 3, N' In which Australian State would you find Lake Eyre?', 3)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [Question], [NoStars]) VALUES (9, 6, N'Zanzibar and Pemba Islands are part of which country?', 5)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [Question], [NoStars]) VALUES (10, 1, N'Which state has a climate suitable for growing citrus fruits—California or Maine?', 5)
INSERT [dbo].[Question] ([IdQuestion], [IdCategory], [Question], [NoStars]) VALUES (11, 2, N'Test question test edit', 5)
SET IDENTITY_INSERT [dbo].[Question] OFF
/****** Object:  Table [dbo].[InfoBox]    Script Date: 12/09/2013 22:30:16 ******/
/****** Object:  Table [dbo].[Subcategory]    Script Date: 12/09/2013 22:30:16 ******/
/****** Object:  Table [dbo].[Score]    Script Date: 12/09/2013 22:30:16 ******/
/****** Object:  Table [dbo].[Hint]    Script Date: 12/09/2013 22:30:16 ******/
