USE [master]
GO
/****** Object:  Database [BolsaEmpleos]    Script Date: 6/21/2021 12:10:58 PM ******/
CREATE DATABASE [BolsaEmpleos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BolsaEmpleos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BolsaEmpleos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BolsaEmpleos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BolsaEmpleos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BolsaEmpleos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BolsaEmpleos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BolsaEmpleos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET ARITHABORT OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BolsaEmpleos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BolsaEmpleos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BolsaEmpleos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BolsaEmpleos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET RECOVERY FULL 
GO
ALTER DATABASE [BolsaEmpleos] SET  MULTI_USER 
GO
ALTER DATABASE [BolsaEmpleos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BolsaEmpleos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BolsaEmpleos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BolsaEmpleos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BolsaEmpleos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BolsaEmpleos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BolsaEmpleos', N'ON'
GO
ALTER DATABASE [BolsaEmpleos] SET QUERY_STORE = OFF
GO
USE [BolsaEmpleos]
GO
/****** Object:  Table [dbo].[administrador]    Script Date: 6/21/2021 12:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[administrador](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[usuario] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 6/21/2021 12:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[categoria_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[categoria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[poster]    Script Date: 6/21/2021 12:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[poster](
	[poster_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[usuario] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[telefono] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[poster_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[puesto]    Script Date: 6/21/2021 12:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[puesto](
	[puesto_id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](300) NULL,
	[nombre] [varchar](60) NULL,
	[email] [varchar](60) NULL,
	[como_aplicar] [varchar](100) NULL,
	[ubicacion] [varchar](100) NULL,
	[compania] [varchar](100) NULL,
	[logo] [varchar](100) NULL,
	[tipo] [varchar](100) NULL,
	[_url] [varchar](150) NULL,
	[categoria_id_pu] [int] NULL,
	[poster_id_pu] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[puesto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solicita]    Script Date: 6/21/2021 12:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solicita](
	[solicita_id] [int] IDENTITY(1,1) NOT NULL,
	[soli_id] [int] NULL,
	[puesto_id] [int] NULL,
	[fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[solicita_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solicitante]    Script Date: 6/21/2021 12:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solicitante](
	[soli_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[usuario] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[soli_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[administrador] ON 

INSERT [dbo].[administrador] ([admin_id], [nombre], [usuario], [password], [email]) VALUES (1, N'Andrius', N'Andri14', N'1234', N'andri@gmail.com')
SET IDENTITY_INSERT [dbo].[administrador] OFF
GO
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([categoria_id], [nombre]) VALUES (2, N'programador web')
INSERT [dbo].[categoria] ([categoria_id], [nombre]) VALUES (3, N'recepcionista')
SET IDENTITY_INSERT [dbo].[categoria] OFF
GO
ALTER TABLE [dbo].[solicita] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[puesto]  WITH CHECK ADD FOREIGN KEY([categoria_id_pu])
REFERENCES [dbo].[categoria] ([categoria_id])
GO
ALTER TABLE [dbo].[puesto]  WITH CHECK ADD FOREIGN KEY([poster_id_pu])
REFERENCES [dbo].[poster] ([poster_id])
GO
ALTER TABLE [dbo].[solicita]  WITH CHECK ADD FOREIGN KEY([puesto_id])
REFERENCES [dbo].[puesto] ([puesto_id])
GO
ALTER TABLE [dbo].[solicita]  WITH CHECK ADD FOREIGN KEY([soli_id])
REFERENCES [dbo].[solicitante] ([soli_id])
GO
USE [master]
GO
ALTER DATABASE [BolsaEmpleos] SET  READ_WRITE 
GO
