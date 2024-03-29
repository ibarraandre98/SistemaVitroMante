USE [master]
GO
/****** Object:  Database [ProyectoVitromanteEjemplo1]    Script Date: 08/26/2018 23:19:15 ******/
CREATE DATABASE [ProyectoVitromanteEjemplo1] ON  PRIMARY 
( NAME = N'ProyectoVitromanteEjemplo1', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ProyectoVitromanteEjemplo1.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProyectoVitromanteEjemplo1_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ProyectoVitromanteEjemplo1_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoVitromanteEjemplo1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET ARITHABORT OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET  DISABLE_BROKER
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET  READ_WRITE
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET  MULTI_USER
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ProyectoVitromanteEjemplo1] SET DB_CHAINING OFF
GO
USE [ProyectoVitromanteEjemplo1]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 08/26/2018 23:19:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ID] [bigint] NOT NULL,
	[Producto] [nchar](10) NULL,
	[CostoUnitario] [float] NULL,
	[Precio] [float] NULL,
	[Utilidad] [int] NULL,
	[Cantidad] [int] NULL,
	[Descripcion] [nchar](100) NOT NULL,
	[UnidadDeMedida] [nchar](10) NULL,
 CONSTRAINT [ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos-Clientes]    Script Date: 08/26/2018 23:19:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos-Clientes](
	[ID] [bigint] NULL,
	[Nombre] [nchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 08/26/2018 23:19:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[ID] [bigint] NOT NULL,
	[Cliente] [nchar](100) NULL,
	[Domicilio] [nchar](100) NULL,
	[Telefono] [bigint] NULL,
	[FechaRealizado] [date] NULL,
	[FechaEntregar] [date] NULL,
	[Producto] [nchar](50) NULL,
	[Descripcion] [nchar](100) NULL,
	[CostoProducto] [float] NULL,
	[IDProducto] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConClientes]    Script Date: 08/26/2018 23:19:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConClientes](
	[Nombre] [nchar](100) NOT NULL,
	[ID] [bigint] NULL,
 CONSTRAINT [PK_ConClientes] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 08/26/2018 23:19:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ID] [bigint] NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Apellido Paterno] [nchar](50) NOT NULL,
	[Apellido Materno] [nchar](50) NULL,
	[Calle] [nchar](30) NULL,
	[NumCasa] [int] NULL,
	[Colonia] [nchar](50) NULL,
	[CodigoPostal] [int] NULL,
	[Ciudad] [nchar](30) NULL,
	[Estado] [nchar](30) NULL,
	[Telefono] [bigint] NULL,
	[Email] [nchar](60) NULL,
 CONSTRAINT [PK_Clientes_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido Paterno], [Apellido Materno], [Calle], [NumCasa], [Colonia], [CodigoPostal], [Ciudad], [Estado], [Telefono], [Email]) VALUES (0, N'Andre                                             ', N'Ibarra                                            ', N'Perez                                             ', N'Hidalgo                       ', 1410, N'Independencia                                     ', 89888, N'Mante                         ', N'Tamaulipas                    ', 2340631, N'sk8muski@gmail.com                                          ')
