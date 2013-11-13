USE [GeographyMaster]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [bigint] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IdCategory] [bigint] IDENTITY(1,1) NOT NULL,
	[Continent] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[IdCategory] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Badge]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Badge](
	[IdBadge] [bigint] IDENTITY(1,1) NOT NULL,
	[Badge] [nvarchar](150) NOT NULL,
	[NoStars] [int] NOT NULL,
	[IdCategory] [bigint] NOT NULL,
 CONSTRAINT [PK_Badge] PRIMARY KEY CLUSTERED 
(
	[IdBadge] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[IdQuestion] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCategory] [bigint] NOT NULL,
	[Question] [nvarchar](max) NOT NULL,
	[NoStars] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[IdQuestion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoBox]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoBox](
	[IdInfoBox] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCategory] [bigint] NOT NULL,
	[InfoBox] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_InfoBox] PRIMARY KEY CLUSTERED 
(
	[IdInfoBox] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subcategory]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcategory](
	[IdSubcategory] [bigint] IDENTITY(1,1) NOT NULL,
	[Subcategory] [nvarchar](max) NOT NULL,
	[IdCategory] [bigint] NOT NULL,
 CONSTRAINT [PK_Subcategory] PRIMARY KEY CLUSTERED 
(
	[IdSubcategory] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Score]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Score](
	[IdScore] [bigint] IDENTITY(1,1) NOT NULL,
	[PlayerName] [nvarchar](100) NOT NULL,
	[Score] [int] NOT NULL,
	[IdBadge] [bigint] NOT NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[IdScore] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hint]    Script Date: 11/13/2013 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hint](
	[IdHint] [bigint] IDENTITY(1,1) NOT NULL,
	[IdQuestion] [bigint] NOT NULL,
	[Hint] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Hint] PRIMARY KEY CLUSTERED 
(
	[IdHint] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Badge_Category]    Script Date: 11/13/2013 10:18:41 ******/
ALTER TABLE [dbo].[Badge]  WITH CHECK ADD  CONSTRAINT [FK_Badge_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[Badge] CHECK CONSTRAINT [FK_Badge_Category]
GO
/****** Object:  ForeignKey [FK_Hint_Question]    Script Date: 11/13/2013 10:18:41 ******/
ALTER TABLE [dbo].[Hint]  WITH CHECK ADD  CONSTRAINT [FK_Hint_Question] FOREIGN KEY([IdQuestion])
REFERENCES [dbo].[Question] ([IdQuestion])
GO
ALTER TABLE [dbo].[Hint] CHECK CONSTRAINT [FK_Hint_Question]
GO
/****** Object:  ForeignKey [FK_InfoBox_Category]    Script Date: 11/13/2013 10:18:41 ******/
ALTER TABLE [dbo].[InfoBox]  WITH CHECK ADD  CONSTRAINT [FK_InfoBox_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[InfoBox] CHECK CONSTRAINT [FK_InfoBox_Category]
GO
/****** Object:  ForeignKey [FK_Question_Category]    Script Date: 11/13/2013 10:18:41 ******/
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Category]
GO
/****** Object:  ForeignKey [FK_Score_Badge]    Script Date: 11/13/2013 10:18:41 ******/
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK_Score_Badge] FOREIGN KEY([IdBadge])
REFERENCES [dbo].[Badge] ([IdBadge])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK_Score_Badge]
GO
/****** Object:  ForeignKey [FK_Subcategory_Category]    Script Date: 11/13/2013 10:18:41 ******/
ALTER TABLE [dbo].[Subcategory]  WITH CHECK ADD  CONSTRAINT [FK_Subcategory_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[Subcategory] CHECK CONSTRAINT [FK_Subcategory_Category]
GO
