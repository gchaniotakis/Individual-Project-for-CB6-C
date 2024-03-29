USE [master]
GO
/****** Object:  Database [Messaging_App]    Script Date: 18/1/2019 19:34:15 ******/
CREATE DATABASE [Messaging_App]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Messaging_App', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Messaging_App.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Messaging_App_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Messaging_App_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Messaging_App] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Messaging_App].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Messaging_App] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Messaging_App] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Messaging_App] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Messaging_App] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Messaging_App] SET ARITHABORT OFF 
GO
ALTER DATABASE [Messaging_App] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Messaging_App] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Messaging_App] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Messaging_App] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Messaging_App] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Messaging_App] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Messaging_App] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Messaging_App] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Messaging_App] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Messaging_App] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Messaging_App] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Messaging_App] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Messaging_App] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Messaging_App] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Messaging_App] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Messaging_App] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Messaging_App] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Messaging_App] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Messaging_App] SET  MULTI_USER 
GO
ALTER DATABASE [Messaging_App] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Messaging_App] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Messaging_App] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Messaging_App] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Messaging_App] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Messaging_App] SET QUERY_STORE = OFF
GO
USE [Messaging_App]
GO
/****** Object:  User [messaging_app_superadmin]    Script Date: 18/1/2019 19:34:16 ******/
CREATE USER [messaging_app_superadmin] FOR LOGIN [messaging_app_superadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [messaging_app_superadmin]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 18/1/2019 19:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[messageid] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[sender] [nvarchar](20) NOT NULL,
	[receiver] [nvarchar](20) NOT NULL,
	[content] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[messageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/1/2019 19:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[rank] [nvarchar](14) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([messageid], [date], [sender], [receiver], [content]) VALUES (1, CAST(N'2019-01-18T16:24:22.327' AS DateTime), N'admin', N'sub', N'Hello darkness, my old friend.')
INSERT [dbo].[Messages] ([messageid], [date], [sender], [receiver], [content]) VALUES (2, CAST(N'2019-01-18T16:33:09.990' AS DateTime), N'hehe', N'admin', N'Hello man')
INSERT [dbo].[Messages] ([messageid], [date], [sender], [receiver], [content]) VALUES (3, CAST(N'2019-01-18T17:00:47.970' AS DateTime), N'hehe', N'admin', N'Do me a favor.')
INSERT [dbo].[Messages] ([messageid], [date], [sender], [receiver], [content]) VALUES (4, CAST(N'2019-01-18T17:01:58.933' AS DateTime), N'hehe', N'admin', N'please')
INSERT [dbo].[Messages] ([messageid], [date], [sender], [receiver], [content]) VALUES (5, CAST(N'2019-01-18T17:03:11.043' AS DateTime), N'admin', N'hehe', N'What do you want?')
INSERT [dbo].[Messages] ([messageid], [date], [sender], [receiver], [content]) VALUES (6, CAST(N'2019-01-18T17:04:02.677' AS DateTime), N'admin', N'hehe', N'Exactly?')
INSERT [dbo].[Messages] ([messageid], [date], [sender], [receiver], [content]) VALUES (7, CAST(N'2019-01-18T17:18:06.850' AS DateTime), N'edit', N'admin', N'hel')
SET IDENTITY_INSERT [dbo].[Messages] OFF
INSERT [dbo].[Users] ([username], [password], [rank]) VALUES (N'admin', N'admin', N'SuperAdmin')
INSERT [dbo].[Users] ([username], [password], [rank]) VALUES (N'edit', N'edit', N'DataEditor')
INSERT [dbo].[Users] ([username], [password], [rank]) VALUES (N'hehe', N'hehe', N'DataViewer')
INSERT [dbo].[Users] ([username], [password], [rank]) VALUES (N'helper', N'help', N'SuperUser')
INSERT [dbo].[Users] ([username], [password], [rank]) VALUES (N'sub', N'sub', N'SuperAdmin')
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([rank]='SuperAdmin' OR [rank]='SuperUser' OR [rank]='DataEditor' OR [rank]='DataViewer'))
GO
USE [master]
GO
ALTER DATABASE [Messaging_App] SET  READ_WRITE 
GO
