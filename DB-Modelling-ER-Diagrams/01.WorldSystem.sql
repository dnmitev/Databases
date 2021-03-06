USE [master]
GO
/****** Object:  Database [WorldSystem]    Script Date: 21.8.2014 г. 0:42:42 ******/
CREATE DATABASE [WorldSystem]
GO
ALTER DATABASE [WorldSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorldSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorldSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorldSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorldSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorldSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorldSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorldSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorldSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WorldSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorldSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorldSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorldSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorldSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorldSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorldSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorldSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorldSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorldSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorldSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorldSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorldSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorldSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorldSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorldSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorldSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [WorldSystem] SET  MULTI_USER 
GO
ALTER DATABASE [WorldSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorldSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorldSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorldSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorldSystem', N'ON'
GO
USE [WorldSystem]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 21.8.2014 г. 0:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 21.8.2014 г. 0:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 21.8.2014 г. 0:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 21.8.2014 г. 0:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 21.8.2014 г. 0:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([ID], [AddressText], [TownID]) VALUES (1, N'Narodno subranie Square', 2)
INSERT [dbo].[Addresses] ([ID], [AddressText], [TownID]) VALUES (2, N'Journalist Square', 2)
INSERT [dbo].[Addresses] ([ID], [AddressText], [TownID]) VALUES (3, N'Djumayata Square', 3)
INSERT [dbo].[Addresses] ([ID], [AddressText], [TownID]) VALUES (4, N'Trakia ', 3)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ID], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ID], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([ID], [Name]) VALUES (3, N'Africa')
INSERT [dbo].[Continents] ([ID], [Name]) VALUES (4, N'Australia')
INSERT [dbo].[Continents] ([ID], [Name]) VALUES (5, N'North America')
INSERT [dbo].[Continents] ([ID], [Name]) VALUES (6, N'South Amercia')
INSERT [dbo].[Continents] ([ID], [Name]) VALUES (7, N'Antarctica')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([ID], [Name], [ContinentID]) VALUES (2, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([ID], [Name], [ContinentID]) VALUES (3, N'China', 2)
INSERT [dbo].[Countries] ([ID], [Name], [ContinentID]) VALUES (4, N'Kongo', 3)
INSERT [dbo].[Countries] ([ID], [Name], [ContinentID]) VALUES (5, N'USA', 5)
INSERT [dbo].[Countries] ([ID], [Name], [ContinentID]) VALUES (6, N'Columbia', 6)
INSERT [dbo].[Countries] ([ID], [Name], [ContinentID]) VALUES (7, N'Laplandia', 7)
INSERT [dbo].[Countries] ([ID], [Name], [ContinentID]) VALUES (8, N'Germany', 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([ID], [FirstName], [LastName], [AddressID]) VALUES (1, N'Pesho', N'Peshev', 1)
INSERT [dbo].[People] ([ID], [FirstName], [LastName], [AddressID]) VALUES (2, N'Penka', N'Pesheva', 1)
INSERT [dbo].[People] ([ID], [FirstName], [LastName], [AddressID]) VALUES (3, N'Joro', N'Jorov', 2)
INSERT [dbo].[People] ([ID], [FirstName], [LastName], [AddressID]) VALUES (4, N'Ginka', N'Gencheva', 3)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([ID], [Name], [CountryID]) VALUES (2, N'Sofia', 2)
INSERT [dbo].[Towns] ([ID], [Name], [CountryID]) VALUES (3, N'Plovdiv', 2)
INSERT [dbo].[Towns] ([ID], [Name], [CountryID]) VALUES (4, N'Stara Zagora', 2)
INSERT [dbo].[Towns] ([ID], [Name], [CountryID]) VALUES (5, N'Munich', 8)
INSERT [dbo].[Towns] ([ID], [Name], [CountryID]) VALUES (6, N'Miami', 5)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownID])
REFERENCES [dbo].[Towns] ([ID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Addresses] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([ID])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [WorldSystem] SET  READ_WRITE 
GO
