USE [master]
GO
/****** Object:  Database [PersonsDB]    Script Date: 20.8.2014 г. 17:30:36 ******/
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
/****** Object:  Table [dbo].[ADDRESSES]    Script Date: 20.8.2014 г. 17:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDRESSES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nchar](100) NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONTINENTS]    Script Date: 20.8.2014 г. 17:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTINENTS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_CONTINENT_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COUNTRYES]    Script Date: 20.8.2014 г. 17:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRYES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_COUNTRY_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERSONS]    Script Date: 20.8.2014 г. 17:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nchar](30) NOT NULL,
	[last_name] [nchar](30) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_PERSON_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TOWNS]    Script Date: 20.8.2014 г. 17:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOWNS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_TOWN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ADDRESSES] ON 

INSERT [dbo].[ADDRESSES] ([id], [address_text], [town_id]) VALUES (1, N'Tuflek Str                                                                                          ', 1)
INSERT [dbo].[ADDRESSES] ([id], [address_text], [town_id]) VALUES (2, N'Blah Shtrasse                                                                                       ', 2)
INSERT [dbo].[ADDRESSES] ([id], [address_text], [town_id]) VALUES (3, N'Ping Pong str 1                                                                                     ', 3)
INSERT [dbo].[ADDRESSES] ([id], [address_text], [town_id]) VALUES (4, N'McChicken Avenue                                                                                    ', 4)
INSERT [dbo].[ADDRESSES] ([id], [address_text], [town_id]) VALUES (5, N'WTF street 7:1                                                                                      ', 6)
INSERT [dbo].[ADDRESSES] ([id], [address_text], [town_id]) VALUES (6, N'Here be dragons str                                                                                 ', 7)
SET IDENTITY_INSERT [dbo].[ADDRESSES] OFF
SET IDENTITY_INSERT [dbo].[CONTINENTS] ON 

INSERT [dbo].[CONTINENTS] ([id], [name]) VALUES (1, N'Europe              ')
INSERT [dbo].[CONTINENTS] ([id], [name]) VALUES (2, N'Aisa                ')
INSERT [dbo].[CONTINENTS] ([id], [name]) VALUES (3, N'North America       ')
INSERT [dbo].[CONTINENTS] ([id], [name]) VALUES (4, N'South America       ')
INSERT [dbo].[CONTINENTS] ([id], [name]) VALUES (5, N'Australia           ')
SET IDENTITY_INSERT [dbo].[CONTINENTS] OFF
SET IDENTITY_INSERT [dbo].[COUNTRYES] ON 

INSERT [dbo].[COUNTRYES] ([id], [name], [continent_id]) VALUES (2, N'Bulgaria                                          ', 1)
INSERT [dbo].[COUNTRYES] ([id], [name], [continent_id]) VALUES (3, N'Germany                                           ', 1)
INSERT [dbo].[COUNTRYES] ([id], [name], [continent_id]) VALUES (4, N'China                                             ', 2)
INSERT [dbo].[COUNTRYES] ([id], [name], [continent_id]) VALUES (5, N'USA                                               ', 3)
INSERT [dbo].[COUNTRYES] ([id], [name], [continent_id]) VALUES (6, N'Brasil                                            ', 4)
INSERT [dbo].[COUNTRYES] ([id], [name], [continent_id]) VALUES (7, N'Australia                                         ', 5)
SET IDENTITY_INSERT [dbo].[COUNTRYES] OFF
SET IDENTITY_INSERT [dbo].[PERSONS] ON 

INSERT [dbo].[PERSONS] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Pesho                         ', N'Petrov                        ', 1)
INSERT [dbo].[PERSONS] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Gosho                         ', N'Petrov                        ', 1)
INSERT [dbo].[PERSONS] ([id], [first_name], [last_name], [address_id]) VALUES (4, N'Zer                           ', N'Gut                           ', 2)
INSERT [dbo].[PERSONS] ([id], [first_name], [last_name], [address_id]) VALUES (5, N'Lu                            ', N'Ping                          ', 3)
INSERT [dbo].[PERSONS] ([id], [first_name], [last_name], [address_id]) VALUES (6, N'Fatty                         ', N'McFreedom                     ', 4)
SET IDENTITY_INSERT [dbo].[PERSONS] OFF
SET IDENTITY_INSERT [dbo].[TOWNS] ON 

INSERT [dbo].[TOWNS] ([id], [name], [country_id]) VALUES (1, N'Sofia                                             ', 2)
INSERT [dbo].[TOWNS] ([id], [name], [country_id]) VALUES (2, N'Berlin                                            ', 3)
INSERT [dbo].[TOWNS] ([id], [name], [country_id]) VALUES (3, N'Honkong                                           ', 4)
INSERT [dbo].[TOWNS] ([id], [name], [country_id]) VALUES (4, N'New York                                          ', 5)
INSERT [dbo].[TOWNS] ([id], [name], [country_id]) VALUES (6, N'Rio                                               ', 6)
INSERT [dbo].[TOWNS] ([id], [name], [country_id]) VALUES (7, N'Sidney                                            ', 7)
SET IDENTITY_INSERT [dbo].[TOWNS] OFF
ALTER TABLE [dbo].[ADDRESSES]  WITH CHECK ADD  CONSTRAINT [FK_ADDRESS_TOWN] FOREIGN KEY([town_id])
REFERENCES [dbo].[TOWNS] ([id])
GO
ALTER TABLE [dbo].[ADDRESSES] CHECK CONSTRAINT [FK_ADDRESS_TOWN]
GO
ALTER TABLE [dbo].[COUNTRYES]  WITH CHECK ADD  CONSTRAINT [FK_COUNTRY_CONTINENT] FOREIGN KEY([continent_id])
REFERENCES [dbo].[CONTINENTS] ([id])
GO
ALTER TABLE [dbo].[COUNTRYES] CHECK CONSTRAINT [FK_COUNTRY_CONTINENT]
GO
ALTER TABLE [dbo].[PERSONS]  WITH CHECK ADD  CONSTRAINT [FK_PERSON_ADDRESS] FOREIGN KEY([address_id])
REFERENCES [dbo].[ADDRESSES] ([id])
GO
ALTER TABLE [dbo].[PERSONS] CHECK CONSTRAINT [FK_PERSON_ADDRESS]
GO
ALTER TABLE [dbo].[TOWNS]  WITH CHECK ADD  CONSTRAINT [FK_TOWN_COUNTRY] FOREIGN KEY([country_id])
REFERENCES [dbo].[COUNTRYES] ([id])
GO
ALTER TABLE [dbo].[TOWNS] CHECK CONSTRAINT [FK_TOWN_COUNTRY]
GO
USE [master]
GO
ALTER DATABASE [PersonsDB] SET  READ_WRITE 
GO
