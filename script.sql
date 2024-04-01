USE [master]
GO
/****** Object:  Database [SoftOneStudentRegistration]    Script Date: 4/2/2024 12:15:56 AM ******/
CREATE DATABASE [SoftOneStudentRegistration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoftOneStudentRegistration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL19\MSSQL\DATA\SoftOneStudentRegistration.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SoftOneStudentRegistration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL19\MSSQL\DATA\SoftOneStudentRegistration_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SoftOneStudentRegistration] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoftOneStudentRegistration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoftOneStudentRegistration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET RECOVERY FULL 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET  MULTI_USER 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoftOneStudentRegistration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SoftOneStudentRegistration] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SoftOneStudentRegistration', N'ON'
GO
ALTER DATABASE [SoftOneStudentRegistration] SET QUERY_STORE = OFF
GO
USE [SoftOneStudentRegistration]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/2/2024 12:15:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/2/2024 12:15:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Nic] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ImgPath] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SoftOneStudentRegistration] SET  READ_WRITE 
GO
