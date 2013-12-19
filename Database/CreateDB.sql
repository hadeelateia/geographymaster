USE [master]
GO
/****** Object:  Database [GeographyMaster]    Script Date: 12/20/2013 00:42:01 ******/
CREATE DATABASE [GeographyMaster] ON  PRIMARY 
( NAME = N'GeographyMaster', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GeographyMaster.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GeographyMaster_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GeographyMaster_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GeographyMaster] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GeographyMaster].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GeographyMaster] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [GeographyMaster] SET ANSI_NULLS OFF
GO
ALTER DATABASE [GeographyMaster] SET ANSI_PADDING OFF
GO
ALTER DATABASE [GeographyMaster] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [GeographyMaster] SET ARITHABORT OFF
GO
ALTER DATABASE [GeographyMaster] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [GeographyMaster] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [GeographyMaster] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [GeographyMaster] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [GeographyMaster] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [GeographyMaster] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [GeographyMaster] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [GeographyMaster] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [GeographyMaster] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [GeographyMaster] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [GeographyMaster] SET  DISABLE_BROKER
GO
ALTER DATABASE [GeographyMaster] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [GeographyMaster] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [GeographyMaster] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [GeographyMaster] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [GeographyMaster] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [GeographyMaster] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [GeographyMaster] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [GeographyMaster] SET  READ_WRITE
GO
ALTER DATABASE [GeographyMaster] SET RECOVERY FULL
GO
ALTER DATABASE [GeographyMaster] SET  MULTI_USER
GO
ALTER DATABASE [GeographyMaster] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [GeographyMaster] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'GeographyMaster', N'ON'
GO
USE [GeographyMaster]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 12/20/2013 00:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 12/20/2013 00:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 12/20/2013 00:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/20/2013 00:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subcategory]    Script Date: 12/20/2013 00:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcategory](
	[IdSubcategory] [bigint] IDENTITY(1,1) NOT NULL,
	[Subcategory] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Subcategory] PRIMARY KEY CLUSTERED 
(
	[IdSubcategory] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/20/2013 00:42:05 ******/
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
/****** Object:  Table [dbo].[Badge]    Script Date: 12/20/2013 00:42:05 ******/
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
/****** Object:  Table [dbo].[Question]    Script Date: 12/20/2013 00:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[IdQuestion] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCategory] [bigint] NOT NULL,
	[IdSubcategory] [bigint] NOT NULL,
	[Question] [nvarchar](max) NOT NULL,
	[NoStars] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[IdQuestion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoBox]    Script Date: 12/20/2013 00:42:05 ******/
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
/****** Object:  Table [dbo].[Score]    Script Date: 12/20/2013 00:42:05 ******/
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
/****** Object:  Table [dbo].[Hint]    Script Date: 12/20/2013 00:42:05 ******/
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
/****** Object:  Table [dbo].[Answer]    Script Date: 12/20/2013 00:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[IdAnswer] [bigint] IDENTITY(1,1) NOT NULL,
	[AnswerDescription] [nvarchar](max) NOT NULL,
	[IdQuestion] [bigint] NOT NULL,
	[IsTrue] [bit] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[IdAnswer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__webpages___IsCon__276EDEB3]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__286302EC]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  ForeignKey [FK_Badge_Category]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[Badge]  WITH CHECK ADD  CONSTRAINT [FK_Badge_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[Badge] CHECK CONSTRAINT [FK_Badge_Category]
GO
/****** Object:  ForeignKey [FK_Question_Category]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Category]
GO
/****** Object:  ForeignKey [FK_Question_Subcategory]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Subcategory] FOREIGN KEY([IdSubcategory])
REFERENCES [dbo].[Subcategory] ([IdSubcategory])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Subcategory]
GO
/****** Object:  ForeignKey [FK_InfoBox_Category]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[InfoBox]  WITH CHECK ADD  CONSTRAINT [FK_InfoBox_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[InfoBox] CHECK CONSTRAINT [FK_InfoBox_Category]
GO
/****** Object:  ForeignKey [FK_Score_Badge]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK_Score_Badge] FOREIGN KEY([IdBadge])
REFERENCES [dbo].[Badge] ([IdBadge])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK_Score_Badge]
GO
/****** Object:  ForeignKey [FK_Hint_Question]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[Hint]  WITH CHECK ADD  CONSTRAINT [FK_Hint_Question] FOREIGN KEY([IdQuestion])
REFERENCES [dbo].[Question] ([IdQuestion])
GO
ALTER TABLE [dbo].[Hint] CHECK CONSTRAINT [FK_Hint_Question]
GO
/****** Object:  ForeignKey [FK_Answer_Question]    Script Date: 12/20/2013 00:42:05 ******/
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([IdQuestion])
REFERENCES [dbo].[Question] ([IdQuestion])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
