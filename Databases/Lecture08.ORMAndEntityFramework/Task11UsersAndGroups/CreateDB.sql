USE [master]
GO
CREATE DATABASE [UsersAndGroupsDB]
 CONTAINMENT = NONE
GO
ALTER DATABASE [UsersAndGroupsDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersAndGroupsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersAndGroupsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersAndGroupsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersAndGroupsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersAndGroupsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersAndGroupsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET RECOVERY FULL 
GO
ALTER DATABASE [UsersAndGroupsDB] SET  MULTI_USER 
GO
ALTER DATABASE [UsersAndGroupsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersAndGroupsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsersAndGroupsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsersAndGroupsDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UsersAndGroupsDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UsersAndGroupsDB', N'ON'
GO
USE [UsersAndGroupsDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
CONSTRAINT [IX_UserNames] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Groups]
GO
USE [master]
GO
ALTER DATABASE [UsersAndGroupsDB] SET  READ_WRITE 
GO
