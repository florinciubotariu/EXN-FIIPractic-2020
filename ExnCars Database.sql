USE [master]
GO
/****** Object:  Database [ExnCars]    Script Date: 3/14/2020 12:20:11 PM ******/
CREATE DATABASE [ExnCars]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExnCarsTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExnCarsTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExnCarsTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExnCarsTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ExnCars] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExnCars].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExnCars] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExnCars] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExnCars] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExnCars] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExnCars] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExnCars] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExnCars] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExnCars] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExnCars] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExnCars] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExnCars] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExnCars] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExnCars] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExnCars] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExnCars] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExnCars] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExnCars] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExnCars] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExnCars] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExnCars] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExnCars] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExnCars] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExnCars] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExnCars] SET  MULTI_USER 
GO
ALTER DATABASE [ExnCars] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExnCars] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExnCars] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExnCars] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExnCars] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExnCars] SET QUERY_STORE = OFF
GO
USE [ExnCars]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 3/14/2020 12:20:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LogoUrl] [nvarchar](2048) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 3/14/2020 12:20:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ModelYear] [int] NULL,
	[EngineCode] [nvarchar](20) NULL,
	[EngineDisplacement] [int] NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/14/2020 12:20:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Avatar] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserVehicles]    Script Date: 3/14/2020 12:20:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVehicles](
	[VehicleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserVehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 3/14/2020 12:20:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleDetails](
	[VehicleId] [int] NOT NULL,
	[ExteriorColor] [nvarchar](20) NULL,
	[InteriorColor] [nvarchar](20) NULL,
	[LastMotDate] [date] NULL,
 CONSTRAINT [PK_VehicleDetails] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 3/14/2020 12:20:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VIN] [nvarchar](17) NOT NULL,
	[RegistrationDate] [date] NULL,
	[RegistrationNumber] [nvarchar](50) NULL,
	[ModelId] [int] NOT NULL,
 CONSTRAINT [PK_Vechiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name], [LogoUrl], [IsDeleted]) VALUES (1, N'Seat', N'https://www.vindecoderz.com/media/brands/SEAT.png', 0)
INSERT [dbo].[Brands] ([Id], [Name], [LogoUrl], [IsDeleted]) VALUES (2, N'BMW', N'https://www.vindecoderz.com/media/brands/BMW.png', 0)
INSERT [dbo].[Brands] ([Id], [Name], [LogoUrl], [IsDeleted]) VALUES (3, N'Volkswagen', N'https://www.vindecoderz.com/media/brands/VW.png', 0)
INSERT [dbo].[Brands] ([Id], [Name], [LogoUrl], [IsDeleted]) VALUES (4, N'Infinity', N'https://www.vindecoderz.com/media/brands/INFIN.png', 0)
INSERT [dbo].[Brands] ([Id], [Name], [LogoUrl], [IsDeleted]) VALUES (5, N'Ford', N'https://www.vindecoderz.com/media/brands/FORD.png', 0)
INSERT [dbo].[Brands] ([Id], [Name], [LogoUrl], [IsDeleted]) VALUES (6, N'Saab', N'https://www.vindecoderz.com/media/brands/FORD.png', 1)
SET IDENTITY_INSERT [dbo].[Brands] OFF
SET IDENTITY_INSERT [dbo].[Models] ON 

INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [EngineCode], [EngineDisplacement], [BrandId]) VALUES (1, N'FX37', 2014, N'VK50VE', 4494, 4)
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [EngineCode], [EngineDisplacement], [BrandId]) VALUES (2, N'Passat', 2008, N'CAYC', 1598, 3)
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [EngineCode], [EngineDisplacement], [BrandId]) VALUES (3, N'Focus', 2017, NULL, 1497, 5)
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [EngineCode], [EngineDisplacement], [BrandId]) VALUES (4, N'X5', 2013, N'N57N', 2993, 2)
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [EngineCode], [EngineDisplacement], [BrandId]) VALUES (5, N'Altea XL Reference', 2011, N'CAYC', 1600, 1)
SET IDENTITY_INSERT [dbo].[Models] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [Avatar]) VALUES (1, N'John', N'Smith', N'john.smith@mailinator.com', N'pass', NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [Avatar]) VALUES (2, N'Jane', N'Doe', N'jane.doe@mailinator.com', N'pass2', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[UserVehicles] ([VehicleId], [UserId]) VALUES (1, 1)
INSERT [dbo].[UserVehicles] ([VehicleId], [UserId]) VALUES (1, 2)
INSERT [dbo].[UserVehicles] ([VehicleId], [UserId]) VALUES (4, 2)
INSERT [dbo].[VehicleDetails] ([VehicleId], [ExteriorColor], [InteriorColor], [LastMotDate]) VALUES (1, N'GREY', N'GREY', CAST(N'2019-02-04' AS Date))
INSERT [dbo].[VehicleDetails] ([VehicleId], [ExteriorColor], [InteriorColor], [LastMotDate]) VALUES (2, N'BLUE', N'BLACK', CAST(N'2019-11-02' AS Date))
INSERT [dbo].[VehicleDetails] ([VehicleId], [ExteriorColor], [InteriorColor], [LastMotDate]) VALUES (3, N'SILVER', N'GREY', CAST(N'2018-12-01' AS Date))
INSERT [dbo].[VehicleDetails] ([VehicleId], [ExteriorColor], [InteriorColor], [LastMotDate]) VALUES (4, N'BLACK', N'BEIGE', CAST(N'2020-01-24' AS Date))
INSERT [dbo].[VehicleDetails] ([VehicleId], [ExteriorColor], [InteriorColor], [LastMotDate]) VALUES (5, N'RED', N'BEIGE', CAST(N'2017-04-19' AS Date))
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([Id], [VIN], [RegistrationDate], [RegistrationNumber], [ModelId]) VALUES (1, N'VSSZZZ5PZBR035968', CAST(N'2011-06-18' AS Date), N'IS59RPC', 5)
INSERT [dbo].[Vehicles] ([Id], [VIN], [RegistrationDate], [RegistrationNumber], [ModelId]) VALUES (2, N'WVWZZZ3CZ8P025751', CAST(N'2008-09-18' AS Date), N'B765SRC', 2)
INSERT [dbo].[Vehicles] ([Id], [VIN], [RegistrationDate], [RegistrationNumber], [ModelId]) VALUES (3, N'JN1TBNS51U0400382', CAST(N'2014-02-24' AS Date), N'NT83CLN', 1)
INSERT [dbo].[Vehicles] ([Id], [VIN], [RegistrationDate], [RegistrationNumber], [ModelId]) VALUES (4, N'1FADP3FE1HL275135', CAST(N'2017-11-06' AS Date), N'SV01SOR', 3)
INSERT [dbo].[Vehicles] ([Id], [VIN], [RegistrationDate], [RegistrationNumber], [ModelId]) VALUES (5, N'WBAKS410500C33610', NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
ALTER TABLE [dbo].[Brands] ADD  CONSTRAINT [DF_Brands_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Brands] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Brands]
GO
ALTER TABLE [dbo].[UserVehicles]  WITH CHECK ADD  CONSTRAINT [FK_UserVehicles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserVehicles] CHECK CONSTRAINT [FK_UserVehicles_Users]
GO
ALTER TABLE [dbo].[UserVehicles]  WITH CHECK ADD  CONSTRAINT [FK_UserVehicles_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[UserVehicles] CHECK CONSTRAINT [FK_UserVehicles_Vehicles]
GO
ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD  CONSTRAINT [FK_VehicleDetails_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[VehicleDetails] CHECK CONSTRAINT [FK_VehicleDetails_Vehicles]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Models]
GO
USE [master]
GO
ALTER DATABASE [ExnCars] SET  READ_WRITE 
GO
