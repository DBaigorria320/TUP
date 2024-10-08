USE [master]
GO
/****** Object:  Database [db_facturacion]    Script Date: 07/09/2024 17:25:31 ******/
CREATE DATABASE [db_facturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_facturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_facturacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_facturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_facturacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_facturacion] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_facturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_facturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_facturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_facturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_facturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_facturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_facturacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_facturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_facturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_facturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_facturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_facturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_facturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_facturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_facturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_facturacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_facturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_facturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_facturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_facturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_facturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_facturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_facturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_facturacion] SET RECOVERY FULL 
GO
ALTER DATABASE [db_facturacion] SET  MULTI_USER 
GO
ALTER DATABASE [db_facturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_facturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_facturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_facturacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_facturacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_facturacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_facturacion', N'ON'
GO
ALTER DATABASE [db_facturacion] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_facturacion] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_facturacion]
GO
/****** Object:  Table [dbo].[T_Articulos]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Articulos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_T_Articulos] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Detalles_Factura]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Detalles_Factura](
	[id_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[id_factura] [int] NULL,
 CONSTRAINT [PK_T_Detalles_Factura] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Facturas]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Facturas](
	[nro_factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[id_forma_pago] [int] NOT NULL,
	[cliente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Facturas] PRIMARY KEY CLUSTERED 
(
	[nro_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Formas_Pago]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Formas_Pago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[forma] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Formas_Pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Detalles_Factura]  WITH CHECK ADD  CONSTRAINT [fk_articulo] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[T_Articulos] ([id_articulo])
GO
ALTER TABLE [dbo].[T_Detalles_Factura] CHECK CONSTRAINT [fk_articulo]
GO
ALTER TABLE [dbo].[T_Detalles_Factura]  WITH CHECK ADD  CONSTRAINT [fk_factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[T_Facturas] ([nro_factura])
GO
ALTER TABLE [dbo].[T_Detalles_Factura] CHECK CONSTRAINT [fk_factura]
GO
ALTER TABLE [dbo].[T_Facturas]  WITH CHECK ADD  CONSTRAINT [fk_forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[T_Formas_Pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[T_Facturas] CHECK CONSTRAINT [fk_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Articulo]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_Articulo] 
	@id int
AS
BEGIN
	DELETE T_Articulos WHERE id_articulo = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Forma_Pago]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_Forma_Pago]
	@id int
AS
BEGIN
	DELETE T_Formas_Pago WHERE id_forma_pago = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Articulo]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Guardar_Articulo] 
	@nombre varchar(50),
	@precio float
AS
BEGIN
	INSERT INTO T_Articulos (nombre, precio) VALUES (@nombre, @precio);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Detalle]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertar_Detalle]
	@id_articulo int,
	@cantidad int,
	@id_factura int
AS
BEGIN
	INSERT INTO T_Detalles_Factura(id_articulo, cantidad, id_factura) VALUES (@id_articulo, @cantidad, @id_factura);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Forma_Pago]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertar_Forma_Pago]
	@nombre varchar(50)
AS
BEGIN
	INSERT INTO T_Formas_Pago (forma) VALUES (@nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Maestro]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertar_Maestro]
	@id_forma_pago int,
	@cliente varchar(50),
	@id int output
AS
BEGIN
	INSERT INTO T_Facturas (fecha, id_forma_pago, cliente) VALUES (GETDATE(), @id_forma_pago, @cliente);
	SET @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulo]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Articulo]
	@id int
AS
BEGIN
	SELECT * FROM T_Articulos WHERE id_articulo = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulos]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Articulos] 
AS
BEGIN
	SELECT * FROM T_Articulos;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalle_Factura]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Detalle_Factura]
	@id int
AS
BEGIN
	SELECT * FROM T_Detalles_Factura WHERE id_detalle = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalles_Factura]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Detalles_Factura]
AS
BEGIN
	SELECT * FROM T_Detalles_Factura;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Factura]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Factura]
	@id int
AS
BEGIN
	SELECT * FROM T_Facturas WHERE nro_factura = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Facturas]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Facturas]
AS
BEGIN
	SELECT * FROM T_Facturas;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Forma_Pago]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Forma_Pago]
	@id int
AS
BEGIN
	SELECT * FROM T_Formas_Pago WHERE id_forma_pago = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Formas_Pago]    Script Date: 07/09/2024 17:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Formas_Pago]
AS
BEGIN
	SELECT * FROM T_Formas_Pago;
END
GO
USE [master]
GO
ALTER DATABASE [db_facturacion] SET  READ_WRITE 
GO
