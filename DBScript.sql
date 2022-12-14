USE [master]
GO
/****** Object:  Database [CompanyBase]    Script Date: 20.12.2022 1:51:48 ******/
CREATE DATABASE [CompanyBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompanyBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CompanyBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompanyBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CompanyBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CompanyBase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompanyBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompanyBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompanyBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompanyBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompanyBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CompanyBase] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompanyBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompanyBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompanyBase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CompanyBase] SET QUERY_STORE = OFF
GO
USE [CompanyBase]
GO
/****** Object:  Table [dbo].[BrandCars]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandCars](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BrandCars] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumberСar] [nvarchar](12) NOT NULL,
	[RegionNumber] [int] NOT NULL,
	[ColorCarID] [int] NOT NULL,
	[ViewCarID] [int] NOT NULL,
	[BrandCarsID] [int] NOT NULL,
	[WeightLimitID] [int] NOT NULL,
	[DriverID] [int] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Patronymic] [nvarchar](100) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](320) NOT NULL,
	[GradeClientID] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorCar]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorCar](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ColorCar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrivingLicenseCategory]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrivingLicenseCategory](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_DrivingLicenseCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Patronymic] [nvarchar](100) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](320) NOT NULL,
	[GradeUserID] [int] NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDrivingCategories]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDrivingCategories](
	[DrivingLicenseCategoryID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeDrivingCategories] PRIMARY KEY CLUSTERED 
(
	[DrivingLicenseCategoryID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeClient]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeClient](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GradeClient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeUser]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeUser](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GradeUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[CarID] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[OrderStatusID] [int] NOT NULL,
	[TimeForExecution] [time](7) NOT NULL,
	[Cost] [money] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViewCar]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViewCar](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ViewCar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeightLimit]    Script Date: 20.12.2022 1:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeightLimit](
	[ID] [int] NOT NULL,
	[Weidht] [int] NOT NULL,
 CONSTRAINT [PK_WeightLimit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BrandCars] ([ID], [Title]) VALUES (0, N'Audi')
INSERT [dbo].[BrandCars] ([ID], [Title]) VALUES (1, N'BMW')
INSERT [dbo].[BrandCars] ([ID], [Title]) VALUES (2, N'Ford')
INSERT [dbo].[BrandCars] ([ID], [Title]) VALUES (3, N'Honda')
GO
SET IDENTITY_INSERT [dbo].[Car] ON 

INSERT [dbo].[Car] ([ID], [NumberСar], [RegionNumber], [ColorCarID], [ViewCarID], [BrandCarsID], [WeightLimitID], [DriverID]) VALUES (0, N'888', 116, 0, 0, 0, 0, NULL)
INSERT [dbo].[Car] ([ID], [NumberСar], [RegionNumber], [ColorCarID], [ViewCarID], [BrandCarsID], [WeightLimitID], [DriverID]) VALUES (1, N'716', 716, 1, 1, 1, 1, 2)
INSERT [dbo].[Car] ([ID], [NumberСar], [RegionNumber], [ColorCarID], [ViewCarID], [BrandCarsID], [WeightLimitID], [DriverID]) VALUES (2, N'123', 123, 2, 2, 3, 3, 1)
INSERT [dbo].[Car] ([ID], [NumberСar], [RegionNumber], [ColorCarID], [ViewCarID], [BrandCarsID], [WeightLimitID], [DriverID]) VALUES (3, N'234', 123, 0, 0, 2, 2, 2)
INSERT [dbo].[Car] ([ID], [NumberСar], [RegionNumber], [ColorCarID], [ViewCarID], [BrandCarsID], [WeightLimitID], [DriverID]) VALUES (4, N'123', 123, 0, 0, 2, 0, 1)
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ID], [Name], [Surname], [Patronymic], [Login], [Password], [PhoneNumber], [Email], [GradeClientID]) VALUES (0, N'Nam', N'Surname', N'PAt', N'qwe', N'qwe', N'89272413062', N'ndasfgdfhjgkjhf', 0)
INSERT [dbo].[Client] ([ID], [Name], [Surname], [Patronymic], [Login], [Password], [PhoneNumber], [Email], [GradeClientID]) VALUES (1, N'asd', N'asd', N'asd', N'asd', N'Asdasd!2', N'asd', N'asd', 0)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
INSERT [dbo].[ColorCar] ([ID], [Title]) VALUES (0, N'Серый')
INSERT [dbo].[ColorCar] ([ID], [Title]) VALUES (1, N'Белый')
INSERT [dbo].[ColorCar] ([ID], [Title]) VALUES (2, N'Черный')
GO
INSERT [dbo].[DrivingLicenseCategory] ([ID], [Title]) VALUES (0, N'B')
INSERT [dbo].[DrivingLicenseCategory] ([ID], [Title]) VALUES (1, N'BE')
INSERT [dbo].[DrivingLicenseCategory] ([ID], [Title]) VALUES (2, N'C')
INSERT [dbo].[DrivingLicenseCategory] ([ID], [Title]) VALUES (3, N'CE')
INSERT [dbo].[DrivingLicenseCategory] ([ID], [Title]) VALUES (4, N'D')
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [Name], [Surname], [Patronymic], [Login], [Password], [RoleID], [PhoneNumber], [Email], [GradeUserID], [Age]) VALUES (0, N'Кондрат ', N'Рыбаков ', N'Лукьянович', N'asd', N'asd', 0, N'+7 209 831 41 83', N'deussetoiyadde-8316@yopmail.com', NULL, 20)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [Patronymic], [Login], [Password], [RoleID], [PhoneNumber], [Email], [GradeUserID], [Age]) VALUES (1, N'Владислав ', N'Блинов', N'Германнович', N'sdf', N'sdf', 1, N'+7926 621 15 62', N'vawoiwikotu-9320@yopmail.com', 2, 30)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [Patronymic], [Login], [Password], [RoleID], [PhoneNumber], [Email], [GradeUserID], [Age]) VALUES (2, N'Мартын', N'Корнилов', N'Максович', N'zxc', N'zxc', 1, N'+77(78)536-75-37', N'becetemmewa-3789@yopmail.com', 4, 25)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [Patronymic], [Login], [Password], [RoleID], [PhoneNumber], [Email], [GradeUserID], [Age]) VALUES (3, N'qwer', N'qwe', N'qwe', N'wer', N'Werwer1!', 2, N'qwe', N'wer', NULL, 0)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [Patronymic], [Login], [Password], [RoleID], [PhoneNumber], [Email], [GradeUserID], [Age]) VALUES (4, N'asd', N'asd', N'asd', N'dfg', N'Dfgdfg1!', 0, N'asd', N'asd', NULL, 9)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[EmployeeDrivingCategories] ([DrivingLicenseCategoryID], [EmployeeID]) VALUES (0, 1)
INSERT [dbo].[EmployeeDrivingCategories] ([DrivingLicenseCategoryID], [EmployeeID]) VALUES (1, 1)
INSERT [dbo].[EmployeeDrivingCategories] ([DrivingLicenseCategoryID], [EmployeeID]) VALUES (1, 2)
INSERT [dbo].[EmployeeDrivingCategories] ([DrivingLicenseCategoryID], [EmployeeID]) VALUES (2, 1)
INSERT [dbo].[EmployeeDrivingCategories] ([DrivingLicenseCategoryID], [EmployeeID]) VALUES (2, 2)
INSERT [dbo].[EmployeeDrivingCategories] ([DrivingLicenseCategoryID], [EmployeeID]) VALUES (3, 2)
GO
INSERT [dbo].[GradeClient] ([ID], [Title]) VALUES (0, N'Pop')
GO
INSERT [dbo].[GradeUser] ([ID], [Title]) VALUES (0, N'Плохо')
INSERT [dbo].[GradeUser] ([ID], [Title]) VALUES (1, N'Ни хорошо')
INSERT [dbo].[GradeUser] ([ID], [Title]) VALUES (2, N'Нормально')
INSERT [dbo].[GradeUser] ([ID], [Title]) VALUES (3, N'Хорошо')
INSERT [dbo].[GradeUser] ([ID], [Title]) VALUES (4, N'Это человек?')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (0, 0, 0, CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'Бари Галеева 3', 0, CAST(N'20:20:00' AS Time), 500.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (1, 0, 2, CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'Победа 12', 1, CAST(N'12:12:00' AS Time), 1230.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (2, 0, 0, CAST(N'2022-12-15T21:33:04.040' AS DateTime), N'asd', 0, CAST(N'00:00:00' AS Time), 0.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (3, 0, 0, CAST(N'2022-12-15T21:39:41.393' AS DateTime), N'asd', 0, CAST(N'00:00:00' AS Time), 0.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (4, 0, 0, CAST(N'2022-12-15T21:42:55.243' AS DateTime), N'asd', 0, CAST(N'00:00:00' AS Time), 0.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (5, 0, 0, CAST(N'2022-12-15T21:45:27.930' AS DateTime), N'sdfg', 0, CAST(N'00:00:00' AS Time), 0.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (6, 0, 0, CAST(N'2022-12-15T21:47:45.657' AS DateTime), N'asd', 0, CAST(N'00:00:00' AS Time), 0.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (7, 0, 0, CAST(N'2022-12-15T21:48:28.777' AS DateTime), N'asd', 0, CAST(N'00:00:00' AS Time), 0.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (8, 0, 0, CAST(N'2022-12-15T21:48:46.177' AS DateTime), N'asd', 0, CAST(N'00:00:00' AS Time), 0.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (9, 0, 0, CAST(N'2022-12-16T09:40:56.000' AS DateTime), N'asd', 0, CAST(N'17:30:00' AS Time), 13700.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (10, 0, 1, CAST(N'2022-12-16T09:48:53.767' AS DateTime), N'ADASD', 0, CAST(N'16:00:00' AS Time), 3000.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (11, 0, 1, CAST(N'2022-12-16T20:18:06.747' AS DateTime), N'asdfghjkjhgfds', 0, CAST(N'15:00:00' AS Time), 14300.0000)
INSERT [dbo].[Order] ([ID], [ClientID], [CarID], [CreationDate], [Address], [OrderStatusID], [TimeForExecution], [Cost]) VALUES (1002, 0, 1, CAST(N'2022-12-19T22:56:08.593' AS DateTime), N'asdasdasdasd', 0, CAST(N'12:00:00' AS Time), 11300.0000)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderStatus] ([ID], [Title]) VALUES (0, N'Новый')
INSERT [dbo].[OrderStatus] ([ID], [Title]) VALUES (1, N'Выдан')
INSERT [dbo].[OrderStatus] ([ID], [Title]) VALUES (2, N'Принят')
INSERT [dbo].[OrderStatus] ([ID], [Title]) VALUES (3, N'Сделан')
GO
INSERT [dbo].[Role] ([ID], [Title]) VALUES (0, N'Администратор')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (1, N'Водитель')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (2, N'Поддержка')
GO
INSERT [dbo].[ViewCar] ([ID], [Title]) VALUES (0, N' Перевозка грузов без пассажиров')
INSERT [dbo].[ViewCar] ([ID], [Title]) VALUES (1, N' Перевозка людей без груза')
INSERT [dbo].[ViewCar] ([ID], [Title]) VALUES (2, N'Перевозка груза и пассажиров')
GO
INSERT [dbo].[WeightLimit] ([ID], [Weidht]) VALUES (0, 200)
INSERT [dbo].[WeightLimit] ([ID], [Weidht]) VALUES (1, 400)
INSERT [dbo].[WeightLimit] ([ID], [Weidht]) VALUES (2, 500)
INSERT [dbo].[WeightLimit] ([ID], [Weidht]) VALUES (3, 600)
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_BrandCars] FOREIGN KEY([BrandCarsID])
REFERENCES [dbo].[BrandCars] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_BrandCars]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_ColorCar] FOREIGN KEY([ColorCarID])
REFERENCES [dbo].[ColorCar] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_ColorCar]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Employee] FOREIGN KEY([DriverID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Employee]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_ViewCar] FOREIGN KEY([ViewCarID])
REFERENCES [dbo].[ViewCar] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_ViewCar]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_WeightLimit] FOREIGN KEY([WeightLimitID])
REFERENCES [dbo].[WeightLimit] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_WeightLimit]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_GradeClient] FOREIGN KEY([GradeClientID])
REFERENCES [dbo].[GradeClient] ([ID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_GradeClient]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_GradeUser] FOREIGN KEY([GradeUserID])
REFERENCES [dbo].[GradeUser] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_GradeUser]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[EmployeeDrivingCategories]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDrivingCategories_DrivingLicenseCategory] FOREIGN KEY([DrivingLicenseCategoryID])
REFERENCES [dbo].[DrivingLicenseCategory] ([ID])
GO
ALTER TABLE [dbo].[EmployeeDrivingCategories] CHECK CONSTRAINT [FK_EmployeeDrivingCategories_DrivingLicenseCategory]
GO
ALTER TABLE [dbo].[EmployeeDrivingCategories]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDrivingCategories_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[EmployeeDrivingCategories] CHECK CONSTRAINT [FK_EmployeeDrivingCategories_Employee]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Car] FOREIGN KEY([CarID])
REFERENCES [dbo].[Car] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Car]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatus] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_OrderStatus]
GO
USE [master]
GO
ALTER DATABASE [CompanyBase] SET  READ_WRITE 
GO
