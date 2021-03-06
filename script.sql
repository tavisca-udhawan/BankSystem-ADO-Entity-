USE [master]
GO
/****** Object:  Database [DBBankingSystem]    Script Date: 7/30/2018 8:35:59 PM ******/
CREATE DATABASE [DBBankingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBBankingSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBBankingSystem.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBBankingSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBBankingSystem_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBBankingSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBBankingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBBankingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBBankingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBBankingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBBankingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBBankingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBBankingSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBBankingSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBBankingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBBankingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBBankingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBBankingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBBankingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBBankingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBBankingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBBankingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBBankingSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBBankingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBBankingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBBankingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBBankingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBBankingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBBankingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBBankingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBBankingSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBBankingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [DBBankingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBBankingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBBankingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBBankingSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBBankingSystem]
GO
/****** Object:  StoredProcedure [dbo].[AddCustomers]    Script Date: 7/30/2018 8:35:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddCustomers]
(
@Name varchar(50),
@AccountType varchar(50),
@Balance int,
@Password varchar(50)
)
as
insert into CustomerDetails(Name,AccountType,Balance,Password) values(@Name,@AccountType,@Balance,@Password);

GO
/****** Object:  StoredProcedure [dbo].[Login_Check]    Script Date: 7/30/2018 8:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Login_Check]
(
@Name varchar(50),
@Password varchar(50)
)
as
select Name,Password,AccountID,Balance,AccountType from CustomerDetails where Name=@Name and Password=@Password;

GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 7/30/2018 8:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[AccountID] [int] IDENTITY(1000,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[AccountType] [varchar](50) NOT NULL,
	[Balance] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [DBBankingSystem] SET  READ_WRITE 
GO
