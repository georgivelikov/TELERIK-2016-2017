USE [master]
GO
/****** Object:  Database [ComputersDb]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
CREATE DATABASE [ComputersDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComputersDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\ComputersDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComputersDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\ComputersDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComputersDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComputersDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComputersDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComputersDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComputersDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComputersDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComputersDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComputersDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComputersDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComputersDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComputersDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComputersDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComputersDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComputersDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComputersDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComputersDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComputersDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComputersDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComputersDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComputersDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComputersDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComputersDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComputersDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComputersDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComputersDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComputersDb] SET  MULTI_USER 
GO
ALTER DATABASE [ComputersDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComputersDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComputersDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComputersDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ComputersDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ComputersDb]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NOT NULL,
	[CpuId] [int] NOT NULL,
	[ComputerTypeId] [int] NOT NULL,
	[Memory] [int] NOT NULL,
 CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputersGpus]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputersGpus](
	[ComputerId] [int] NOT NULL,
	[GpuId] [int] NOT NULL,
 CONSTRAINT [PK_ComputersGpus] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[GpuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputersStorageDevices]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputersStorageDevices](
	[ComputerId] [int] NOT NULL,
	[StorageDeviceId] [int] NOT NULL,
 CONSTRAINT [PK_ComputersStorageDevices] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[StorageDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputerTypes]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputerTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ComputerTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cpus]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cpus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NOT NULL,
	[NumberOfCores] [int] NOT NULL,
	[ClockCycles] [float] NOT NULL,
 CONSTRAINT [PK_Cpus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gpus]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gpus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NOT NULL,
	[GpuTypeId] [int] NOT NULL,
	[Memory] [int] NOT NULL,
 CONSTRAINT [PK_Gpus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GpuTypes]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GpuTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GpuTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Models]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[VendorId] [int] NOT NULL,
	[ModelTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModelTypes]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ModelTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageDevices]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageDevices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NOT NULL,
	[StorageDeviceTypeId] [int] NOT NULL,
	[Size] [int] NOT NULL,
 CONSTRAINT [PK_StorageDevices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageDeviceTypes]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageDeviceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StorageDeviceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 8.11.2016 г. 15:57:50 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_ComputerTypes] FOREIGN KEY([ComputerTypeId])
REFERENCES [dbo].[ComputerTypes] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_ComputerTypes]
GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_Cpus] FOREIGN KEY([CpuId])
REFERENCES [dbo].[Cpus] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_Cpus]
GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_Models]
GO
ALTER TABLE [dbo].[ComputersGpus]  WITH CHECK ADD  CONSTRAINT [FK_ComputersGpus_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComputersGpus] CHECK CONSTRAINT [FK_ComputersGpus_Computers]
GO
ALTER TABLE [dbo].[ComputersGpus]  WITH CHECK ADD  CONSTRAINT [FK_ComputersGpus_Gpus] FOREIGN KEY([GpuId])
REFERENCES [dbo].[Gpus] ([Id])
GO
ALTER TABLE [dbo].[ComputersGpus] CHECK CONSTRAINT [FK_ComputersGpus_Gpus]
GO
ALTER TABLE [dbo].[ComputersStorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_ComputersStorageDevices_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComputersStorageDevices] CHECK CONSTRAINT [FK_ComputersStorageDevices_Computers]
GO
ALTER TABLE [dbo].[ComputersStorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_ComputersStorageDevices_StorageDevices] FOREIGN KEY([StorageDeviceId])
REFERENCES [dbo].[StorageDevices] ([Id])
GO
ALTER TABLE [dbo].[ComputersStorageDevices] CHECK CONSTRAINT [FK_ComputersStorageDevices_StorageDevices]
GO
ALTER TABLE [dbo].[Cpus]  WITH CHECK ADD  CONSTRAINT [FK_Cpus_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[Cpus] CHECK CONSTRAINT [FK_Cpus_Models]
GO
ALTER TABLE [dbo].[Gpus]  WITH CHECK ADD  CONSTRAINT [FK_Gpus_GpuTypes] FOREIGN KEY([GpuTypeId])
REFERENCES [dbo].[GpuTypes] ([Id])
GO
ALTER TABLE [dbo].[Gpus] CHECK CONSTRAINT [FK_Gpus_GpuTypes]
GO
ALTER TABLE [dbo].[Gpus]  WITH CHECK ADD  CONSTRAINT [FK_Gpus_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[Gpus] CHECK CONSTRAINT [FK_Gpus_Models]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_ModelTypes] FOREIGN KEY([ModelTypeId])
REFERENCES [dbo].[ModelTypes] ([Id])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_ModelTypes]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Vendors]
GO
ALTER TABLE [dbo].[StorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_StorageDevices_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[StorageDevices] CHECK CONSTRAINT [FK_StorageDevices_Models]
GO
ALTER TABLE [dbo].[StorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_StorageDevices_StorageDeviceTypes] FOREIGN KEY([StorageDeviceTypeId])
REFERENCES [dbo].[StorageDeviceTypes] ([Id])
GO
ALTER TABLE [dbo].[StorageDevices] CHECK CONSTRAINT [FK_StorageDevices_StorageDeviceTypes]
GO
USE [master]
GO
ALTER DATABASE [ComputersDb] SET  READ_WRITE 
GO
