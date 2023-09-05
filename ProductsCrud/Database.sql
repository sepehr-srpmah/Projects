USE [master]
GO
/****** Object:  Database [Accounting_DB]    Script Date: 09/03/2023 14:00:41 ******/
CREATE DATABASE [Accounting_DB] ON  PRIMARY 
( NAME = N'Accounting_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\Accounting_DB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Accounting_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\Accounting_DB_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Accounting_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Accounting_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Accounting_DB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Accounting_DB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Accounting_DB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Accounting_DB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Accounting_DB] SET ARITHABORT OFF
GO
ALTER DATABASE [Accounting_DB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Accounting_DB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Accounting_DB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Accounting_DB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Accounting_DB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Accounting_DB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Accounting_DB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Accounting_DB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Accounting_DB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Accounting_DB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Accounting_DB] SET  ENABLE_BROKER
GO
ALTER DATABASE [Accounting_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Accounting_DB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Accounting_DB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Accounting_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Accounting_DB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Accounting_DB] SET READ_COMMITTED_SNAPSHOT ON
GO
ALTER DATABASE [Accounting_DB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Accounting_DB] SET  READ_WRITE
GO
ALTER DATABASE [Accounting_DB] SET RECOVERY FULL
GO
ALTER DATABASE [Accounting_DB] SET  MULTI_USER
GO
ALTER DATABASE [Accounting_DB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Accounting_DB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Accounting_DB', N'ON'
GO
USE [Accounting_DB]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/03/2023 14:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionType]    Script Date: 09/03/2023 14:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[ID] [int] NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TransactionType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 09/03/2023 14:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Mobile] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](50) NULL,
	[UserName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 09/03/2023 14:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionType] [int] NOT NULL,
	[Amount] [bigint] NOT NULL,
	[DateCreated] [date] NOT NULL,
	[Description] [nvarchar](800) NULL,
	[Customer_ID] [int] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Customer_User]    Script Date: 09/03/2023 14:00:43 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([UserName])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
/****** Object:  ForeignKey [FK_Transaction_Customer]    Script Date: 09/03/2023 14:00:43 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customer]
GO
/****** Object:  ForeignKey [FK_Transaction_Transaction]    Script Date: 09/03/2023 14:00:43 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Transaction] FOREIGN KEY([ID])
REFERENCES [dbo].[Transaction] ([ID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Transaction]
GO
/****** Object:  ForeignKey [FK_Transaction_TransactionType]    Script Date: 09/03/2023 14:00:43 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_TransactionType] FOREIGN KEY([TransactionType])
REFERENCES [dbo].[TransactionType] ([ID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_TransactionType]
GO
