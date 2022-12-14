USE [master]
GO
/****** Object:  Database [gost]    Script Date: 28.04.2022 7:28:00 ******/
CREATE DATABASE [gost]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gost', FILENAME = N'D:\sql\SQL2017\MSSQL14.MSSQLSERVER2\MSSQL\DATA\gost.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gost_log', FILENAME = N'D:\sql\SQL2017\MSSQL14.MSSQLSERVER2\MSSQL\DATA\gost_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [gost] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gost].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gost] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gost] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gost] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gost] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gost] SET ARITHABORT OFF 
GO
ALTER DATABASE [gost] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gost] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gost] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gost] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gost] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gost] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gost] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gost] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gost] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gost] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gost] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gost] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gost] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gost] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gost] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gost] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gost] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gost] SET RECOVERY FULL 
GO
ALTER DATABASE [gost] SET  MULTI_USER 
GO
ALTER DATABASE [gost] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gost] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gost] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gost] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gost] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'gost', N'ON'
GO
ALTER DATABASE [gost] SET QUERY_STORE = OFF
GO
USE [gost]
GO
/****** Object:  Table [dbo].[bron]    Script Date: 28.04.2022 7:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bron](
	[id_n] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientt]    Script Date: 28.04.2022 7:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientt](
	[id] [int] NOT NULL,
	[surname] [varchar](max) NOT NULL,
	[name] [varchar](max) NOT NULL,
	[second_surname] [varchar](max) NOT NULL,
	[phone] [varchar](max) NOT NULL,
	[seria] [int] NOT NULL,
	[nomer] [int] NOT NULL,
	[login] [varchar](max) NOT NULL,
	[password] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Clientt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[otel]    Script Date: 28.04.2022 7:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[otel](
	[Nomer_hotel] [int] NOT NULL,
	[N] [varchar](max) NOT NULL,
	[Gorod] [varchar](max) NOT NULL,
	[Adress] [varchar](max) NOT NULL,
	[Nomer_tel] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Clientt] ([id], [surname], [name], [second_surname], [phone], [seria], [nomer], [login], [password]) VALUES (2, N'Иванов', N'Николай', N'Петрович', N'+75004003020', 5544, 456654, N'user2', N'ewq321')
INSERT [dbo].[Clientt] ([id], [surname], [name], [second_surname], [phone], [seria], [nomer], [login], [password]) VALUES (3, N'Попов', N'Андрей', N'Андреевич', N'+79881234567', 7771, 271771, N'qwerty', N'qq11')
INSERT [dbo].[Clientt] ([id], [surname], [name], [second_surname], [phone], [seria], [nomer], [login], [password]) VALUES (123, N'Пушной', N'Илья', N'Сергеевич', N'+72389471298', 1231, 421412, N'user123', N'qwe123')
GO
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (1, N'Волга', N'Саратов', N'Набережная, 6', N'+7999888')
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (2, N'Поволжье', N'Энгельс', N'Центральная, 1', N'+7111222')
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (3, N'ыфва', N'фыва', N'фыва', N'фыва')
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (4, N'фыва', N'фвы', N'ыфва', N'авыф')
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (5, N'фыва', N'фыва', N'фыва', N'фыва')
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (6, N'KSDKJ', N'SADFKAS', N'DSJKF', N'JHSDJKSDFKJ')
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (7, N'SDJF', N'KJD', N'BCBVBC', N'BCQHWB')
INSERT [dbo].[otel] ([Nomer_hotel], [N], [Gorod], [Adress], [Nomer_tel]) VALUES (8, N'SDJKFH', N'CXVM', N'OEIRQ', N'UIWE')
GO
USE [master]
GO
ALTER DATABASE [gost] SET  READ_WRITE 
GO
