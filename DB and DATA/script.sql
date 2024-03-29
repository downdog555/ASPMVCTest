USE [master]
GO
/****** Object:  Database [GameManagementSystem]    Script Date: 11/10/2019 17:19:20 ******/
CREATE DATABASE [GameManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GameManagementSystem', FILENAME = N'C:\Users\Reec\GameManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GameManagementSystem_log', FILENAME = N'C:\Users\Reec\GameManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GameManagementSystem] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GameManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GameManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GameManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GameManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GameManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GameManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [GameManagementSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GameManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GameManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GameManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GameManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GameManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GameManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GameManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GameManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GameManagementSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GameManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GameManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GameManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GameManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GameManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GameManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GameManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GameManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GameManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [GameManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GameManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GameManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GameManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GameManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GameManagementSystem] SET QUERY_STORE = OFF
GO
USE [GameManagementSystem]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [GameManagementSystem]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 11/10/2019 17:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[ReleaseDate] [datetime2](7) NOT NULL,
	[Genre] [varchar](255) NULL,
	[Price] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/10/2019 17:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([ID], [Title], [ReleaseDate], [Genre], [Price]) VALUES (2002, N'C&C3', CAST(N'2007-03-28T00:00:00.0000000' AS DateTime2), N'RTS', CAST(4.95 AS Decimal(18, 2)))
INSERT [dbo].[Game] ([ID], [Title], [ReleaseDate], [Genre], [Price]) VALUES (3002, N'C&C3 Kanes Wrath', CAST(N'2008-03-28T00:00:00.0000000' AS DateTime2), N'RTS', CAST(4.95 AS Decimal(18, 2)))
INSERT [dbo].[Game] ([ID], [Title], [ReleaseDate], [Genre], [Price]) VALUES (3003, N'C&C4 Tiberium Twilight', CAST(N'2010-03-16T00:00:00.0000000' AS DateTime2), N'RTS', CAST(15.95 AS Decimal(18, 2)))
INSERT [dbo].[Game] ([ID], [Title], [ReleaseDate], [Genre], [Price]) VALUES (3005, N'Cyberpunk 2077', CAST(N'2020-04-16T00:00:00.0000000' AS DateTime2), N'RPG', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Game] ([ID], [Title], [ReleaseDate], [Genre], [Price]) VALUES (3006, N'C&C3 Red alert 3', CAST(N'2008-10-28T00:00:00.0000000' AS DateTime2), N'RTS', CAST(4.95 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Game] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [Password]) VALUES (1, N'test1', N'test1')
INSERT [dbo].[Users] ([ID], [Username], [Password]) VALUES (2, N'test2', N'test2')
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [GameManagementSystem] SET  READ_WRITE 
GO
