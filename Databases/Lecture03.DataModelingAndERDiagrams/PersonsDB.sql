USE [master]
GO
/****** Object:  Database [PersonsDB]    Script Date: 21.8.2014 г. 21:29:04 ч. ******/
CREATE DATABASE [PersonsDB]
 CONTAINMENT = NONE
GO
ALTER DATABASE [PersonsDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonsDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonsDB] SET  MULTI_USER 
GO
ALTER DATABASE [PersonsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonsDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PersonsDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonsDB', N'ON'
GO
USE [PersonsDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 21.8.2014 г. 21:29:04 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 21.8.2014 г. 21:29:04 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinetId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CONTINENT_1] PRIMARY KEY CLUSTERED 
(
	[ContinetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 21.8.2014 г. 21:29:04 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_COUNTRY_1] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERSONS]    Script Date: 21.8.2014 г. 21:29:04 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONS](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_PERSON_1] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TOWNS]    Script Date: 21.8.2014 г. 21:29:04 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOWNS](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_TOWN] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (1, N'Tuflek Str                                                                                          ', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (2, N'Blah Shtrasse                                                                                       ', 2)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (3, N'Ping Pong str 1                                                                                     ', 3)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (4, N'McChicken Avenue                                                                                    ', 4)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (5, N'WTF street 7:1                                                                                      ', 6)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (6, N'Here be dragons str                                                                                 ', 7)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinetId], [Name]) VALUES (1, N'Europe              ')
INSERT [dbo].[Continents] ([ContinetId], [Name]) VALUES (2, N'Aisa                ')
INSERT [dbo].[Continents] ([ContinetId], [Name]) VALUES (3, N'North America       ')
INSERT [dbo].[Continents] ([ContinetId], [Name]) VALUES (4, N'South America       ')
INSERT [dbo].[Continents] ([ContinetId], [Name]) VALUES (5, N'Australia           ')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (2, N'Bulgaria                                          ', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (3, N'Germany                                           ', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (4, N'China                                             ', 2)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (5, N'USA                                               ', 3)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (6, N'Brasil                                            ', 4)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (7, N'Australia                                         ', 5)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[PERSONS] ON 

INSERT [dbo].[PERSONS] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (2, N'Pesho                         ', N'Petrov                        ', 1)
INSERT [dbo].[PERSONS] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (3, N'Gosho                         ', N'Petrov                        ', 1)
INSERT [dbo].[PERSONS] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (4, N'Zer                           ', N'Gut                           ', 2)
INSERT [dbo].[PERSONS] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (5, N'Lu                            ', N'Ping                          ', 3)
INSERT [dbo].[PERSONS] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (6, N'Fatty                         ', N'McFreedom                     ', 4)
SET IDENTITY_INSERT [dbo].[PERSONS] OFF
SET IDENTITY_INSERT [dbo].[TOWNS] ON 

INSERT [dbo].[TOWNS] ([TownId], [Name], [CountryId]) VALUES (1, N'Sofia                                             ', 2)
INSERT [dbo].[TOWNS] ([TownId], [Name], [CountryId]) VALUES (2, N'Berlin                                            ', 3)
INSERT [dbo].[TOWNS] ([TownId], [Name], [CountryId]) VALUES (3, N'Honkong                                           ', 4)
INSERT [dbo].[TOWNS] ([TownId], [Name], [CountryId]) VALUES (4, N'New York                                          ', 5)
INSERT [dbo].[TOWNS] ([TownId], [Name], [CountryId]) VALUES (6, N'Rio                                               ', 6)
INSERT [dbo].[TOWNS] ([TownId], [Name], [CountryId]) VALUES (7, N'Sidney                                            ', 7)
SET IDENTITY_INSERT [dbo].[TOWNS] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[TOWNS] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinetId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[PERSONS]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[PERSONS] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[TOWNS]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[TOWNS] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [PersonsDB] SET  READ_WRITE 
GO
