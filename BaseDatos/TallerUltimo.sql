USE [master]
GO
/****** Object:  Database [TALLER_MECANICO]    Script Date: 25/06/2021 2:05:38 ******/
CREATE DATABASE [TALLER_MECANICO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TALLER_MECANICO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TALLER_MECANICO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TALLER_MECANICO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TALLER_MECANICO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TALLER_MECANICO] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TALLER_MECANICO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TALLER_MECANICO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET ARITHABORT OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TALLER_MECANICO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TALLER_MECANICO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TALLER_MECANICO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TALLER_MECANICO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET RECOVERY FULL 
GO
ALTER DATABASE [TALLER_MECANICO] SET  MULTI_USER 
GO
ALTER DATABASE [TALLER_MECANICO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TALLER_MECANICO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TALLER_MECANICO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TALLER_MECANICO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TALLER_MECANICO] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TALLER_MECANICO', N'ON'
GO
ALTER DATABASE [TALLER_MECANICO] SET QUERY_STORE = OFF
GO
USE [TALLER_MECANICO]
GO
/****** Object:  User [prueba]    Script Date: 25/06/2021 2:05:38 ******/
CREATE USER [prueba] FOR LOGIN [prueba] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[rutCliente] [varchar](10) NOT NULL,
	[nombreCliente] [varchar](35) NULL,
	[apellidoCliente] [varchar](35) NULL,
	[direccionCliente] [varchar](100) NULL,
	[telefonoCliente] [int] NULL,
	[correoCliente] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[rutCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_orden]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_orden](
	[folioDetalleOrden] [int] IDENTITY(1,1) NOT NULL,
	[fk_folioOrden] [int] NULL,
	[id] [int] NULL,
	[cantidad] [int] NULL,
	[Tipo] [char](1) NULL,
	[subTotal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[folioDetalleOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_presupuesto]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_presupuesto](
	[folioDetalle] [int] IDENTITY(1,1) NOT NULL,
	[fk_folioEncabezado] [int] NULL,
	[id] [int] NULL,
	[cantidad] [int] NULL,
	[Tipo] [char](1) NULL,
	[subTotal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[folioDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[encabezado_presupuesto]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[encabezado_presupuesto](
	[folioEncabezado] [int] IDENTITY(1,1) NOT NULL,
	[fk_rutCliente] [varchar](10) NULL,
	[fk_patente] [varchar](6) NULL,
	[fecha] [date] NULL,
	[observaciones] [varchar](200) NULL,
	[estado] [varchar](20) NULL,
	[neto] [int] NULL,
	[iva] [int] NULL,
	[total] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[folioEncabezado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orden_trabajo]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden_trabajo](
	[folioOrden] [int] IDENTITY(1,1) NOT NULL,
	[fk_idUsuario] [int] NULL,
	[fk_rutCliente] [varchar](10) NULL,
	[fk_patente] [varchar](6) NULL,
	[fecha] [date] NULL,
	[fechaEntrega] [date] NULL,
	[prioridad] [varchar](50) NULL,
	[observaciones] [varchar](200) NULL,
	[anulacion] [bit] NOT NULL,
	[neto] [int] NULL,
	[iva] [int] NULL,
	[total] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[folioOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[nombreProveedor] [varchar](50) NULL,
	[direccionProveedor] [varchar](200) NULL,
	[telefonoProveedor] [varchar](10) NULL,
	[correoProveedor] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[repuesto]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[repuesto](
	[idRepuesto] [int] IDENTITY(10000,1) NOT NULL,
	[nombreRepuesto] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idRepuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servicio]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicio](
	[idServicio] [int] IDENTITY(1,1) NOT NULL,
	[nombreServicio] [varchar](200) NULL,
	[valorServicio] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_usuario]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_usuario](
	[idTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[cargo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoVehiculo]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoVehiculo](
	[idTipoVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[fk_idTipoUsuario] [int] NULL,
	[nombreUsuario] [varchar](50) NULL,
	[passUsuario] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 25/06/2021 2:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[patente] [varchar](6) NOT NULL,
	[fk_rutCliente] [varchar](10) NULL,
	[fk_idTipoVehiculo] [int] NULL,
	[marca] [varchar](50) NULL,
	[color] [varchar](12) NULL,
	[modelo] [varchar](50) NULL,
	[ano] [int] NULL,
	[kilometraje] [int] NULL,
	[estado] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[cliente] ([rutCliente], [nombreCliente], [apellidoCliente], [direccionCliente], [telefonoCliente], [correoCliente]) VALUES (N'17248124-8', N'Felipe', N'Munoz', N'Avenida Nosellama 123', 994042289, N'felipemunoz@gmail.com')
INSERT [dbo].[cliente] ([rutCliente], [nombreCliente], [apellidoCliente], [direccionCliente], [telefonoCliente], [correoCliente]) VALUES (N'18117587-7', N'Nicolas', N'Espinoza', N'Buin,Cabernet 49', 36827051, N'9nico5@gmail.com')
SET IDENTITY_INSERT [dbo].[detalle_orden] ON 

INSERT [dbo].[detalle_orden] ([folioDetalleOrden], [fk_folioOrden], [id], [cantidad], [Tipo], [subTotal]) VALUES (1, 1, 3, 1, N'S', 45000)
INSERT [dbo].[detalle_orden] ([folioDetalleOrden], [fk_folioOrden], [id], [cantidad], [Tipo], [subTotal]) VALUES (2, 1, 3, 1, N'S', 45000)
INSERT [dbo].[detalle_orden] ([folioDetalleOrden], [fk_folioOrden], [id], [cantidad], [Tipo], [subTotal]) VALUES (3, 2, 11, 1, N'S', 12000)
SET IDENTITY_INSERT [dbo].[detalle_orden] OFF
SET IDENTITY_INSERT [dbo].[detalle_presupuesto] ON 

INSERT [dbo].[detalle_presupuesto] ([folioDetalle], [fk_folioEncabezado], [id], [cantidad], [Tipo], [subTotal]) VALUES (1, 1, 3, 1, N'S', 45000)
INSERT [dbo].[detalle_presupuesto] ([folioDetalle], [fk_folioEncabezado], [id], [cantidad], [Tipo], [subTotal]) VALUES (2, 1, 3, 1, N'S', 45000)
INSERT [dbo].[detalle_presupuesto] ([folioDetalle], [fk_folioEncabezado], [id], [cantidad], [Tipo], [subTotal]) VALUES (3, 2, 11, 1, N'S', 12000)
INSERT [dbo].[detalle_presupuesto] ([folioDetalle], [fk_folioEncabezado], [id], [cantidad], [Tipo], [subTotal]) VALUES (4, 3, 11, 1, N'S', 12000)
INSERT [dbo].[detalle_presupuesto] ([folioDetalle], [fk_folioEncabezado], [id], [cantidad], [Tipo], [subTotal]) VALUES (5, 5, 10, 1, N'S', 12000)
SET IDENTITY_INSERT [dbo].[detalle_presupuesto] OFF
SET IDENTITY_INSERT [dbo].[encabezado_presupuesto] ON 

INSERT [dbo].[encabezado_presupuesto] ([folioEncabezado], [fk_rutCliente], [fk_patente], [fecha], [observaciones], [estado], [neto], [iva], [total]) VALUES (1, N'18117587-7', N'zn7016', CAST(N'2021-06-25' AS Date), N' ', N'2', 90000, 17100, 107100)
INSERT [dbo].[encabezado_presupuesto] ([folioEncabezado], [fk_rutCliente], [fk_patente], [fecha], [observaciones], [estado], [neto], [iva], [total]) VALUES (2, N'18117587-7', N'zn7016', CAST(N'2021-06-25' AS Date), N' ', N'1', 12000, 2280, 14280)
INSERT [dbo].[encabezado_presupuesto] ([folioEncabezado], [fk_rutCliente], [fk_patente], [fecha], [observaciones], [estado], [neto], [iva], [total]) VALUES (3, N'18117587-7', N'zn7016', CAST(N'2021-06-25' AS Date), N' ', N'2', 12000, 2280, 14280)
INSERT [dbo].[encabezado_presupuesto] ([folioEncabezado], [fk_rutCliente], [fk_patente], [fecha], [observaciones], [estado], [neto], [iva], [total]) VALUES (4, N'18117587-7', N'zn7016', CAST(N'2021-06-25' AS Date), N' ', N'1', 0, 0, 0)
INSERT [dbo].[encabezado_presupuesto] ([folioEncabezado], [fk_rutCliente], [fk_patente], [fecha], [observaciones], [estado], [neto], [iva], [total]) VALUES (5, N'18117587-7', N'zn7016', CAST(N'2021-06-25' AS Date), N' ', N'1', 12000, 2280, 14280)
SET IDENTITY_INSERT [dbo].[encabezado_presupuesto] OFF
SET IDENTITY_INSERT [dbo].[orden_trabajo] ON 

INSERT [dbo].[orden_trabajo] ([folioOrden], [fk_idUsuario], [fk_rutCliente], [fk_patente], [fecha], [fechaEntrega], [prioridad], [observaciones], [anulacion], [neto], [iva], [total]) VALUES (1, 4, N'18117587-7', N'ZN7016', CAST(N'2021-06-25' AS Date), CAST(N'2021-06-25' AS Date), N'Baja', N' ', 0, 90000, 17100, 107100)
INSERT [dbo].[orden_trabajo] ([folioOrden], [fk_idUsuario], [fk_rutCliente], [fk_patente], [fecha], [fechaEntrega], [prioridad], [observaciones], [anulacion], [neto], [iva], [total]) VALUES (2, 4, N'18117587-7', N'ZN7016', CAST(N'2021-06-25' AS Date), CAST(N'2021-06-29' AS Date), N'Baja', N' ', 0, 12000, 2280, 14280)
SET IDENTITY_INSERT [dbo].[orden_trabajo] OFF
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([idProveedor], [nombreProveedor], [direccionProveedor], [telefonoProveedor], [correoProveedor]) VALUES (1, N'Chulito Repuestos', N'Av. Los Chulines 123', N'123468795', N'repuestoschulito@gmail.com')
INSERT [dbo].[proveedor] ([idProveedor], [nombreProveedor], [direccionProveedor], [telefonoProveedor], [correoProveedor]) VALUES (2, N'Nico Repuestos', N'Av. Los Nicolines 456', N'784236598', N'nicolinrepuestos@gmail.com')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
SET IDENTITY_INSERT [dbo].[repuesto] ON 

INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10016, N'Anillos de Motor')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10063, N'Balancin')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10069, N'Balatas Traseras')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10001, N'Batería')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10039, N'Biela de Motor')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10009, N'Bomba de Embrague')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10070, N'Bomba de Freno')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10040, N'Cadena Bomba Inyectora')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10041, N'Chaveta Cigueñal')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10036, N'Cigueñal')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10006, N'Cilindro de Embrague')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10003, N'Crucetas de Cardan')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10038, N'Culata')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10007, N'Disco de Embrague')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10073, N'Disco de Freno Delantero')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10072, N'Disco de Freno Trasero')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10042, N'Eje Balancín')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10037, N'Eje de Leva')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10019, N'Empaquetadora de Culata')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10020, N'Empaquetadura de Carter')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10022, N'Empaquetadura de Escape')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10021, N'Empaquetadura Multiple de Admisión')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10034, N'Empaquetadura Salida de Escape')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10018, N'Empaquetadura Tapa de Valvulas')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10017, N'Guia de Valvula')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10010, N'Horquilla de Embrague')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10052, N'Juego Bujes de Biela')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10053, N'Juego Camisa Motor')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10054, N'Juego de Metales Compensador')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10023, N'Juego Empaquetadura Motor')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10055, N'Juego Torre Eje de Leva')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10014, N'Kit de Embrague')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10002, N'Lubricante')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10025, N'Metales Axiales')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10032, N'Metales de Bancada')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10031, N'Metales de Biela')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10000, N'Neumático')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10056, N'Pasador Piston')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10068, N'Pastillas de Freno Delantero')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10067, N'Pastillas de Freno Trasero')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10057, N'Perno Biela')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10058, N'Perno Culata')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10064, N'Perno Polea Cigueñal')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10065, N'Piñon Bomba de Aceite')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10008, N'Piola de Embrague')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10015, N'Piola de Velocímetro')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10013, N'Piola Selector de Cambios')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10024, N'Pistones')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10059, N'Platillo Resorte de Valvulas')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10011, N'Punta de Homocinetica')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10060, N'Resorte de Valvula')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10028, N'Reten de Cigueñal')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10026, N'Reten Eje de Levas')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10029, N'Retenes de Valvula')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10012, N'Rodamiento Caja de Cambio')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10005, N'Rodamiento de Empuje')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10061, N'Seguro Valvula de Motor')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10004, N'Soporte Cardan')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10027, N'Soporte Motor')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10071, N'Tambores de Freno Trasero')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10066, N'Tapa Aceite')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10033, N'Taque')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10062, N'Tornillo Balancin')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10035, N'Turbo')
INSERT [dbo].[repuesto] ([idRepuesto], [nombreRepuesto]) VALUES (10030, N'Valculas de Motor')
SET IDENTITY_INSERT [dbo].[repuesto] OFF
SET IDENTITY_INSERT [dbo].[servicio] ON 

INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (1, N'Mantención por Kilometraje', 15000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (2, N'Ajuste de Motor', 60000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (3, N'Reparación Diferenciales', 45000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (4, N'Cambio de Aceite', 8000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (5, N'Electricidad', 15000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (6, N'Reparación Caja Mecánica', 35000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (7, N'Reparación Caja Automática', 70000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (8, N'Frenos - Cambio de Pastillas', 12000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (9, N'Frenos - Embalatado', 15000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (10, N'Frenos - Rectificado de Disco', 12000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (11, N'Scanner', 12000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (12, N'Pintura', 35000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (13, N'Tren Delantero', 35000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (14, N'Alineamiento', 10000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (15, N'Embrague - Cambio de Kit', 35000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (16, N'Embrague - Disco Prensa', 18000)
INSERT [dbo].[servicio] ([idServicio], [nombreServicio], [valorServicio]) VALUES (17, N'Embrague - Rodamientos', 10000)
SET IDENTITY_INSERT [dbo].[servicio] OFF
SET IDENTITY_INSERT [dbo].[tipo_usuario] ON 

INSERT [dbo].[tipo_usuario] ([idTipoUsuario], [cargo]) VALUES (1, N'ADMINISTRADOR')
INSERT [dbo].[tipo_usuario] ([idTipoUsuario], [cargo]) VALUES (2, N'MECANICO')
SET IDENTITY_INSERT [dbo].[tipo_usuario] OFF
SET IDENTITY_INSERT [dbo].[tipoVehiculo] ON 

INSERT [dbo].[tipoVehiculo] ([idTipoVehiculo], [nombre]) VALUES (1, N'auto')
INSERT [dbo].[tipoVehiculo] ([idTipoVehiculo], [nombre]) VALUES (2, N'camion')
INSERT [dbo].[tipoVehiculo] ([idTipoVehiculo], [nombre]) VALUES (3, N'grua orquilla')
INSERT [dbo].[tipoVehiculo] ([idTipoVehiculo], [nombre]) VALUES (4, N'tractor')
INSERT [dbo].[tipoVehiculo] ([idTipoVehiculo], [nombre]) VALUES (5, N'maquinaria agricola')
SET IDENTITY_INSERT [dbo].[tipoVehiculo] OFF
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [fk_idTipoUsuario], [nombreUsuario], [passUsuario]) VALUES (1, 1, N'FMUNOZ', N'81dc9bdb52d04dc20036dbd8313ed055')
INSERT [dbo].[usuario] ([idUsuario], [fk_idTipoUsuario], [nombreUsuario], [passUsuario]) VALUES (2, 1, N'ROBERTO', N'674f3c2c1a8a6f90461e8a66fb5550ba')
INSERT [dbo].[usuario] ([idUsuario], [fk_idTipoUsuario], [nombreUsuario], [passUsuario]) VALUES (3, 1, N'NICOLAS', N'789')
INSERT [dbo].[usuario] ([idUsuario], [fk_idTipoUsuario], [nombreUsuario], [passUsuario]) VALUES (4, 2, N'NESPINOZA', N'b59c67bf196a4758191e42f76670ceba')
INSERT [dbo].[usuario] ([idUsuario], [fk_idTipoUsuario], [nombreUsuario], [passUsuario]) VALUES (9, 2, N'Mecanico 2', N'123456')
SET IDENTITY_INSERT [dbo].[usuario] OFF
INSERT [dbo].[vehiculo] ([patente], [fk_rutCliente], [fk_idTipoVehiculo], [marca], [color], [modelo], [ano], [kilometraje], [estado]) VALUES (N'54WVC1', N'17248124-8', 5, N'Jhon Deere', N'Verde', N'5045-D', 2016, 50000, N'INGRESADO')
INSERT [dbo].[vehiculo] ([patente], [fk_rutCliente], [fk_idTipoVehiculo], [marca], [color], [modelo], [ano], [kilometraje], [estado]) VALUES (N'ZN7016', N'18117587-7', 1, N'Fiat', N'blanco', N'palio 1.2', 2006, 200000, N'INGRESADO')
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__repuesto__A39601EB656280F2]    Script Date: 25/06/2021 2:05:40 ******/
ALTER TABLE [dbo].[repuesto] ADD UNIQUE NONCLUSTERED 
(
	[nombreRepuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__servicio__29174983DBFAD68B]    Script Date: 25/06/2021 2:05:40 ******/
ALTER TABLE [dbo].[servicio] ADD UNIQUE NONCLUSTERED 
(
	[nombreServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__usuario__6BDEAE00437CD295]    Script Date: 25/06/2021 2:05:40 ******/
ALTER TABLE [dbo].[usuario] ADD UNIQUE NONCLUSTERED 
(
	[passUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__usuario__A0436BD71DE474FE]    Script Date: 25/06/2021 2:05:40 ******/
ALTER TABLE [dbo].[usuario] ADD UNIQUE NONCLUSTERED 
(
	[nombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[detalle_orden]  WITH CHECK ADD FOREIGN KEY([fk_folioOrden])
REFERENCES [dbo].[orden_trabajo] ([folioOrden])
GO
ALTER TABLE [dbo].[detalle_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_folioEncabezado])
REFERENCES [dbo].[encabezado_presupuesto] ([folioEncabezado])
GO
ALTER TABLE [dbo].[encabezado_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_patente])
REFERENCES [dbo].[vehiculo] ([patente])
GO
ALTER TABLE [dbo].[encabezado_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_rutCliente])
REFERENCES [dbo].[cliente] ([rutCliente])
GO
ALTER TABLE [dbo].[orden_trabajo]  WITH CHECK ADD FOREIGN KEY([fk_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[orden_trabajo]  WITH CHECK ADD FOREIGN KEY([fk_patente])
REFERENCES [dbo].[vehiculo] ([patente])
GO
ALTER TABLE [dbo].[orden_trabajo]  WITH CHECK ADD FOREIGN KEY([fk_rutCliente])
REFERENCES [dbo].[cliente] ([rutCliente])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD FOREIGN KEY([fk_idTipoUsuario])
REFERENCES [dbo].[tipo_usuario] ([idTipoUsuario])
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD FOREIGN KEY([fk_idTipoVehiculo])
REFERENCES [dbo].[tipoVehiculo] ([idTipoVehiculo])
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD FOREIGN KEY([fk_rutCliente])
REFERENCES [dbo].[cliente] ([rutCliente])
GO
/****** Object:  StoredProcedure [dbo].[MT_GET_BuscarCliente]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*------------------------------------------------------------------------------*/
/*-- Empresa			: TallerMecanico									    */
/*-- Tipo				: Procedimiento											*/
/*-- Nombre				: [dbo].[MT_GET_BuscarCliente]				                */
/*-- Detalle			:														*/
/*-- Autor				: NEspinoza												*/
/*-- Modificaciones		:														*/
/*------------------------------------------------------------------------------*/

create procedure [dbo].[MT_GET_BuscarCliente]
@rut varchar(10)
as
begin
select * 
from cliente
where rutCliente=''+@rut+''

end
GO
/****** Object:  StoredProcedure [dbo].[MT_GET_BuscarVehiculo]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 /*------------------------------------------------------------------------------*/
/*-- Empresa			: TallerMecanico									    */
/*-- Tipo				: Procedimiento											*/
/*-- Nombre				: [dbo].[MT_GET_BuscarVehiculo]				            */
/*-- Detalle			:														*/
/*-- Autor				: NEspinoza												*/
/*-- Modificaciones		:														*/
/*------------------------------------------------------------------------------*/

create procedure [dbo].[MT_GET_BuscarVehiculo]
@patente varchar(10)
as
begin
select * 
from vehiculo
where patente=''+@patente+''

end
GO
/****** Object:  StoredProcedure [dbo].[MT_GET_Clientes]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_GET_Clientes]

  as
  begin

  select	rutCliente,
			nombreCliente,
			apellidoCliente,
			direccionCliente,
			telefonoCliente,
			correoCliente
  from cliente 

  end
GO
/****** Object:  StoredProcedure [dbo].[MT_GET_Repuestos]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


  /*------------------------------------------------------------------------------*/
/*-- Empresa			: TallerMecanico									    */
/*-- Tipo				: Procedimiento											*/
/*-- Nombre				: [dbo].[MT_GET_Repuestos]				                */
/*-- Detalle			:														*/
/*-- Autor				: NEspinoza												*/
/*-- Modificaciones		:														*/
/*------------------------------------------------------------------------------*/
create procedure [dbo].[MT_GET_Repuestos]
as

begin 
select idRepuesto , upper(nombreRepuesto)as nombreRepuesto from repuesto

end
GO
/****** Object:  StoredProcedure [dbo].[MT_GET_Servicios]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



  /*------------------------------------------------------------------------------*/
/*-- Empresa			: TallerMecanico									    */
/*-- Tipo				: Procedimiento											*/
/*-- Nombre				: [dbo].[MT_GET_Servicios]				                */
/*-- Detalle			:														*/
/*-- Autor				: NEspinoza												*/
/*-- Modificaciones		:														*/
/*------------------------------------------------------------------------------*/

create procedure [dbo].[MT_GET_Servicios]

as
begin 

select idServicio, upper(nombreServicio) as nombreServicio,valorServicio
from servicio
end
GO
/****** Object:  StoredProcedure [dbo].[MT_GET_TipoVehiculo]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  /*------------------------------------------------------------------------------*/
/*-- Empresa			: TallerMecanico									    */
/*-- Tipo				: Procedimiento											*/
/*-- Nombre				: [dbo].[MT_GET_TipoVehiculo]								        */
/*-- Detalle			:														*/
/*-- Autor				: NEspinoza												*/
/*-- Modificaciones		:														*/
/*------------------------------------------------------------------------------*/
  CREATE procedure [dbo].[MT_GET_TipoVehiculo]

  as
  begin

  select idTipoVehiculo, UPPER(nombre) as nombre from tipoVehiculo 

  end

GO
/****** Object:  StoredProcedure [dbo].[MT_SP_DEL_DetallePresupuesto]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MT_SP_DEL_DetallePresupuesto]
@idEncabezado int,
@linea int
as
declare @mensaje varchar(max)

delete from detalle_presupuesto 
where folioDetalle=@linea and fk_folioEncabezado=@idEncabezado

select @mensaje='Registro insertado'
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_BuscarDetalle]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[MT_SP_GET_BuscarDetalle]
@IdEncabezado int,
@linea int 
as

  select
  d.folioDetalle,
  d.id as codigo,
  Tipo = case d.Tipo when 'R' then 'Repuesto' else 'Servicio' end,
  nombre= case d.Tipo when 'R' then (select nombreRepuesto from repuesto where idRepuesto=d.id) else (select nombreServicio from servicio where idServicio=d.id) end,
  d.fk_folioEncabezado,
  d.cantidad,
  Unidad=round((d.subTotal/d.cantidad),0),
  d.subTotal
  from detalle_presupuesto d
  where fk_folioEncabezado=@IdEncabezado and folioDetalle=@linea
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_DEtalleOrden]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_GET_DEtalleOrden]
@id_orden int
as
select 
o.folioOrden,
c.nombreCliente+' '+c.apellidoCliente as Nombre,
c.rutCliente,
c.telefonoCliente,
upper(v.patente) as patente,
v.marca,
v.modelo,
v.ano,
v.kilometraje,
convert(nvarchar(30),o.fecha,105) as fecha,
CONVERT(nvarchar(30),o.fechaEntrega,105) as Plazo,
Responsable=(select nombreUsuario from usuario where idUsuario=o.fk_idUsuario),
o.prioridad,
o.observaciones,
o.neto,
o.iva,
o.total,
v.estado,
Anulada=case when o.anulacion=0 then 'Activa' else 'Anulada' end 
from orden_trabajo o 
inner join  cliente c
on o.fk_rutCliente=c.rutCliente
inner join vehiculo v 
on c.rutCliente=v.fk_rutCliente
where o.folioOrden=@id_orden
order by o.fecha desc , o.folioOrden desc
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_DetalleOrdenModal]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create procedure [dbo].[MT_SP_GET_DetalleOrdenModal]
  @id_Orden int
  as 
  select
  d.folioDetalleOrden,
  d.id as codigo,
  nombre= case d.Tipo when 'R' then (select nombreRepuesto from repuesto where idRepuesto=d.id) else (select nombreServicio from servicio where idServicio=d.id) end,
  d.fk_folioOrden,
  d.cantidad,
  Unidad=round((d.subTotal/d.cantidad),0),
  d.subTotal
  from detalle_orden d
  where fk_folioOrden= @id_Orden
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_DetallePrespuesto]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[MT_SP_GET_DetallePrespuesto]
@id_Encabezado int
as
  select
  d.folioDetalle,
  d.id as codigo,
  nombre= case d.Tipo when 'R' then (select nombreRepuesto from repuesto where idRepuesto=d.id) else (select nombreServicio from servicio where idServicio=d.id) end,
  d.fk_folioEncabezado,
  d.cantidad,
  Unidad=round((d.subTotal/d.cantidad),0),
  d.subTotal
  from detalle_presupuesto d
  where fk_folioEncabezado=@id_Encabezado

GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_DetallePrespuestoExacto]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_GET_DetallePrespuestoExacto]
@id_Encabezado int
as
  select
  d.folioDetalle,
  d.fk_folioEncabezado,
  d.id,
  d.cantidad,
  tipo =d.Tipo,
  d.subTotal
  from detalle_presupuesto d
  where fk_folioEncabezado=@id_Encabezado


GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_EncabezadoDetalle]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_GET_EncabezadoDetalle]
@id_Encabezado int
as

select
p.folioEncabezado, 
c.nombreCliente+' '+c.apellidoCliente as Nombre,
c.rutCliente,
c.telefonoCliente,
upper(v.patente) as patente,
v.marca,
v.modelo,
v.ano,
v.kilometraje,
p.observaciones,
convert(nvarchar(30),p.fecha,105) as fecha,
p.neto,
p.iva,
p.total
from encabezado_presupuesto p
inner join cliente c
on p.fk_rutCliente=c.rutCliente
inner join vehiculo v 
on c.rutCliente=v.fk_rutCliente
where p.folioEncabezado =@id_Encabezado
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_Estado]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_GET_Estado]
@patente varchar(30)
as

select estado from vehiculo where patente=@patente
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_Mecanico]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MT_SP_GET_Mecanico]
@idUsuario int
as
select 
o.folioOrden,
c.nombreCliente+' '+c.apellidoCliente as Nombre,
c.rutCliente,
c.telefonoCliente,
upper(v.patente) as patente,
v.marca,
v.modelo,
v.ano,
v.kilometraje,
convert(nvarchar(30),o.fecha,105) as fecha,
CONVERT(nvarchar(30),o.fechaEntrega,105) as Plazo,
Responsable=(select nombreUsuario from usuario where idUsuario=o.fk_idUsuario),
o.prioridad,
o.observaciones,
o.neto,
o.iva,
o.total,
v.estado,
Anulada=case when o.anulacion=0 then 'Activa' else 'Anulada' end 
from orden_trabajo o 
inner join  cliente c
on o.fk_rutCliente=c.rutCliente
inner join vehiculo v 
on c.rutCliente=v.fk_rutCliente
where o.fk_idUsuario=4 and o.anulacion=0
order by o.fecha desc , o.folioOrden desc
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_obtenerMecanicos]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE procedure [dbo].[MT_SP_GET_obtenerMecanicos]
  as
  select 
 u.idUsuario,
 u.fk_idTipoUsuario,
 tu.cargo,
 u.nombreUsuario,
 u.passUsuario
  from usuario u
  inner join tipo_usuario tu
  on tu.idTipoUsuario =u.fk_idTipoUsuario
  where fk_idTipoUsuario=2
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_OrdenAnuladas]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MT_SP_GET_OrdenAnuladas]
as
select 
o.folioOrden,
c.nombreCliente+' '+c.apellidoCliente as Nombre,
c.rutCliente,
upper(v.patente) as patente,
v.marca,
v.modelo,
convert(nvarchar(30),o.fecha,105) as fecha,
CONVERT(nvarchar(30),o.fechaEntrega) as Plazo,
Responsable=(select nombreUsuario from usuario where idUsuario=o.fk_idUsuario),
o.prioridad,
o.neto,
o.iva,
o.total,
v.estado
from orden_trabajo o 
inner join  cliente c
on o.fk_rutCliente=c.rutCliente
inner join vehiculo v 
on c.rutCliente=v.fk_rutCliente
where o.anulacion=1
order by o.fecha desc , o.folioOrden desc
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_OrdenTrabajo]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[MT_SP_GET_OrdenTrabajo]
as
select 
o.folioOrden,
c.nombreCliente+' '+c.apellidoCliente as Nombre,
c.rutCliente,
upper(v.patente) as patente,
v.marca,
v.modelo,
convert(nvarchar(30),o.fecha,105) as fecha,
CONVERT(nvarchar(30),o.fechaEntrega) as Plazo,
Responsable=(select nombreUsuario from usuario where idUsuario=o.fk_idUsuario),
o.prioridad,
o.neto,
o.iva,
o.total,
v.estado
from orden_trabajo o 
inner join  cliente c
on o.fk_rutCliente=c.rutCliente
inner join vehiculo v 
on c.rutCliente=v.fk_rutCliente
where o.anulacion=0
order by o.fecha desc , o.folioOrden desc







GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_Presupuestos]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_GET_Presupuestos]
as
select
p.folioEncabezado, 
c.nombreCliente+' '+c.apellidoCliente as Nombre,
c.rutCliente,
upper(v.patente) as patente,
v.marca,
v.modelo,
convert(nvarchar(30),p.fecha,105) as fecha,
p.neto,
p.iva,
p.total,
case p.estado when '1' then 'pendiende' else 'aprobado' end as Estado 
from encabezado_presupuesto p
inner join cliente c
on p.fk_rutCliente=c.rutCliente
inner join vehiculo v 
on c.rutCliente=v.fk_rutCliente
where p.estado=1
order by p.fecha desc, p.folioEncabezado desc
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_GET_PresupuestosAprobador]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MT_SP_GET_PresupuestosAprobador]
as
select
p.folioEncabezado, 
c.nombreCliente+' '+c.apellidoCliente as Nombre,
c.rutCliente,
upper(v.patente) as patente,
v.marca,
v.modelo,
convert(nvarchar(30),p.fecha,105) as fecha,
p.neto,
p.iva,
p.total,
case p.estado when '1' then 'pendiende' else 'aprobado' end as Estado 
from encabezado_presupuesto p
inner join cliente c
on p.fk_rutCliente=c.rutCliente
inner join vehiculo v 
on c.rutCliente=v.fk_rutCliente
where p.estado=2
order by p.fecha desc, p.folioEncabezado desc
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_UP_ActualizarDetalle]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_UP_ActualizarDetalle]
@folioDetalle int,
@cantidad int,
@subtotal int
as
declare @mensaje varchar(max)
select @mensaje='Registro actualizado'

update  detalle_presupuesto set cantidad=@cantidad, subTotal=@subtotal where folioDetalle=@folioDetalle

select * from detalle_presupuesto
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_UP_ActualizarEstadoOR]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[MT_SP_UP_ActualizarEstadoOR]
@estado varchar(100),
@patente varchar(20)
as 

update vehiculo set estado=@estado where patente=@patente
 
select * from vehiculo
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_UP_ActualizarEstadoPresupuesto]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MT_SP_UP_ActualizarEstadoPresupuesto]
@idEncabezado int
as
update encabezado_presupuesto set estado=2 where folioEncabezado=@idEncabezado
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_UP_ActualizarObservacionOrden]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_UP_ActualizarObservacionOrden]
@id int,
@comentario varchar(100)
as

update orden_trabajo set observaciones=@comentario where folioOrden=@id

select * from orden_trabajo
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_UP_ActualizarObservacionPresu]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[MT_SP_UP_ActualizarObservacionPresu]
@idEncabezado int,
@observacion varchar(300)
as
declare @Mensaje varchar(max)
update encabezado_presupuesto set observaciones=@observacion where folioEncabezado=@idEncabezado

select @mensaje='Registro actualizado'

select * from encabezado_presupuesto
GO
/****** Object:  StoredProcedure [dbo].[MT_SP_UP_ActualizarPresupuesto]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MT_SP_UP_ActualizarPresupuesto]
@idEncabezado int,
@neto int,
@iva int,
@total int
as
declare @mensaje varchar(max)

update encabezado_presupuesto set neto=@neto ,iva=@iva,total=@total where folioEncabezado=@idEncabezado

select @mensaje='Registro actualizado'

select * from  encabezado_presupuesto
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_LOGIN]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*------------------------------------------------------------------------------*/
/*-- Empresa			: TallerMecanico									    */
/*-- Tipo				: Procedimiento											*/
/*-- Nombre				: [dbo].[GET_LOGIN]								        */
/*-- Detalle			:														*/
/*-- Autor				: NEspinoza												*/
/*-- Modificaciones		:														*/
/*------------------------------------------------------------------------------*/
create procedure [dbo].[SP_GET_LOGIN]  
	@Nombre varchar(15),       
	@Contrasena varchar(50)       
as 
begin
	set nocount on       
	
	select	u.idUsuario,
			u.fk_idTipoUsuario,
			u.nombreUsuario
	from	usuario u       
	where	u.nombreUsuario = @Nombre 
	and		u.passUsuario = @Contrasena 
	
	set nocount OFF       
end  
GO
/****** Object:  StoredProcedure [dbo].[SP_INS_AnularOrden]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_INS_AnularOrden]
@id int
as

update orden_trabajo set anulacion=1 where folioOrden=@id
select * from orden_trabajo
GO
/****** Object:  StoredProcedure [dbo].[SP_INS_DetalleOrden]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_INS_DetalleOrden]
@folioOrden int,
@id int,
@cantidad int,
@Tipo char,
@subTotal int
as
declare @Mensaje varchar(max)
insert into detalle_orden(fk_folioOrden,id,cantidad,Tipo,subTotal)values(@folioOrden,@id,@cantidad,@Tipo,@subTotal)

select @mensaje='Registro insertado'
select * from detalle_orden
GO
/****** Object:  StoredProcedure [dbo].[SP_INS_DetallePresupuesto]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[SP_INS_DetallePresupuesto]
@FolioEncabezado int,
@id int,
@cantidad int,
@Tipo char(1),
@subTotal int
as

declare @Mensaje varchar(max)


insert into detalle_presupuesto(fk_folioEncabezado,id,cantidad,Tipo,subTotal)
values(@FolioEncabezado,@id,@cantidad,@Tipo,@subTotal)

select @Mensaje='Registro insertado'
select * from  detalle_presupuesto
GO
/****** Object:  StoredProcedure [dbo].[SP_INS_EncabezadoOrden]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_INS_EncabezadoOrden]
@IdUsuario int,
@rutCliente varchar(12),
@patente varchar(8),
@fecha datetime,
@fechaEntrega datetime,
@prioridad varchar(12),
@observacion varchar(300),
@anulacion  Bit,
@neto  int,
@iva int,
@total int
as
insert into orden_trabajo (fk_idUsuario,fk_rutCliente,fk_patente,fecha,fechaEntrega,prioridad,observaciones,anulacion,neto,iva,total)
values(@IdUsuario,@rutCliente,@patente,@fecha,@fechaEntrega,@prioridad,@observacion,@anulacion,@neto,@iva,@total)

select @@IDENTITY as id_encabezado
GO
/****** Object:  StoredProcedure [dbo].[SP_INS_EncabezadoPresupuesto]    Script Date: 25/06/2021 2:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_INS_EncabezadoPresupuesto]
--- Cabecera---
@rutcliente varchar(10),
@patente varchar(8),
@fecha datetime,
@observaciones varchar(100),
@estado varchar(20),
@neto int,
@iva int,
@total int

as
declare @mensaje varchar(max)

insert into encabezado_presupuesto(fk_rutCliente,fk_patente,fecha,observaciones,estado,neto,iva,total)
values(@rutcliente,@patente,@fecha,@observaciones,@estado,@neto,@iva,@total)

select @@IDENTITY as id_encabezado


--select * from encabezado_presupuesto
--select * from detalle_presupuesto
--delete from encabezado_presupuesto
--DBCC CHECKIDENT (encabezado_presupuesto, RESEED, 0)
GO
USE [master]
GO
ALTER DATABASE [TALLER_MECANICO] SET  READ_WRITE 
GO
