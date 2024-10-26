USE master

CREATE DATABASE DBPedidos;
GO

USE [DBPedidos]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](80) NOT NULL,
	[Zona] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Opcion]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Opcion](
	[IdOpcion] [int] IDENTITY(1,1) NOT NULL,
	[NombreOpcion] [varchar](50) NULL,
	[UrlOpcion] [varchar](50) NULL,
	[RutaImagen] [varchar](50) NULL,
	[NroOrden] [int] NULL,
	[IdOpcionRef] [int] NULL,
 CONSTRAINT [PK_Opcion] PRIMARY KEY CLUSTERED 
(
	[IdOpcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[CodUsuario] [varchar](50) NOT NULL,
	[Clave] [binary](50) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Pedidos]    Script Date: 20/11/2020 06:28:46 p. m. no corrido ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[CodPedido] [varchar](50) NOT NULL,
	[CodCliente] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
-- Clave foránea que hace referencia a la tabla Clientes
 CONSTRAINT [FK_Pedido_Clientes] FOREIGN KEY([CodCliente])
 REFERENCES [dbo].[Clientes] ([Codigo])
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Codigo], [NombreCompleto], [Zona]) VALUES (1, N'Armando David Espinoza Robles', N'San Borja')
INSERT [dbo].[Clientes] ([Codigo], [NombreCompleto], [Zona]) VALUES (3, N'Gladys Rebeca Gutierrez Blanco', N'Ate Vitarte')
INSERT [dbo].[Clientes] ([Codigo], [NombreCompleto], [Zona]) VALUES (6, N'Miguel Mizardo Maurtua', N'San Juan')
INSERT [dbo].[Clientes] ([Codigo], [NombreCompleto], [Zona]) VALUES (8, N'Veronica Narvaez Bossio', N'San Borja')
INSERT [dbo].[Clientes] ([Codigo], [NombreCompleto], [Zona]) VALUES (10, N'Silvia Adios ', N'San Juan de Lurigancho')
INSERT [dbo].[Clientes] ([Codigo], [NombreCompleto], [Zona]) VALUES (11, N'Edith Rojas', N'Huancayo')
INSERT [dbo].[Clientes] ([Codigo], [NombreCompleto], [Zona]) VALUES (12, N'Ana Arias', N'el Agustino')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Opcion] ON 

INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (1, N'Mantenimiento', N'#', N'fa fa-envelope-o', 1, 0)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (2, N'Clientes', N'Clientes/Index', N'fa fa-envelope-o', 1, 1)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (3, N'Vendedor', N'Vendedor/Index', N'fa fa-envelope-o', 2, 1)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (4, N'Maestrías', N'#', N'fa fa-envelope-o', 3, 1)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (5, N'TipoDocumento', N'TipoDocumento/Index', N'fa fa-envelope-o', 1, 4)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (6, N'Tipo de Vias', N'TipoVia/Index', N'fa fa-envelope-o', 2, 4)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (7, N'Ubigeo', N'Ubigeo/Index', N'fa fa-envelope-o', 3, 4)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (8, N'Seguridad', N'#', N'fa fa-database', 2, 0)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (9, N'Usuario', N'Usuario/Index', N'fa fa-envelope-o', 1, 8)
INSERT [dbo].[Opcion] ([IdOpcion], [NombreOpcion], [UrlOpcion], [RutaImagen], [NroOrden], [IdOpcionRef]) VALUES (10, N'Pedidos', N'Pedido/Index', N'fa fa-fighter-jet', 3, 0)
SET IDENTITY_INSERT [dbo].[Opcion] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [CodUsuario], [Clave], [Nombres]) VALUES (1, N'despinoza', 0x7A59847CAC0B59A20037BF4DA8CEF4C300000000000000000000000000000000000000000000000000000000000000000000, N'Espinoza Robles Armando')
INSERT [dbo].[Usuario] ([IdUsuario], [CodUsuario], [Clave], [Nombres]) VALUES (3, N'ggutierrez', 0x7A59847CAC0B59A20037BF4DA8CEF4C300000000000000000000000000000000000000000000000000000000000000000000, N'gladys gutierrez')
INSERT [dbo].[Usuario] ([IdUsuario], [CodUsuario], [Clave], [Nombres]) VALUES (7, N'gsalinas', 0xAA00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, N'Salinas Asaña Gilberto')
INSERT [dbo].[Usuario] ([IdUsuario], [CodUsuario], [Clave], [Nombres]) VALUES (8, N'jchavez', 0x7A00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, N'Chavez saume Julio')
SET IDENTITY_INSERT [dbo].[Usuario] OFF

SET IDENTITY_INSERT [dbo].[Pedido] ON
INSERT INTO [dbo].[Pedido] (CodPedido, CodCliente, Fecha, Estado)
VALUES 
('PED001', 3, '18-10-2024', 'Pendiente'),
('PED002', 6, '18-10-2024', 'Completado'),
('PED003', 8, '18-10-2024', 'Cancelado');
DBCC USEROPTIONS;


SET IDENTITY_INSERT [dbo].[Pedido] OFF
/****** Object:  StoredProcedure [dbo].[ActualizaClave]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizaClave]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
declare @bClave binary(50)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 SELECT  @bClave= clave FROM  [DB_Repositorio_Procesos].[dbo].[Usuario]
	 where IdUsuario =1
	 UPDATE [DBPedidos].[dbo].[Usuario] 
		SET
		
		clave = @bClave
		where IdUsuario = 1
END


GO
/****** Object:  StoredProcedure [dbo].[paBuscarCliente]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create OR ALTER PROCEDURE [dbo].[paBuscarCliente]
	-- Add the parameters for the stored procedure here
	
	@Codigo int
AS
BEGIN
	
	--SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT Codigo, NombreCompleto, Zona From Clientes
	Where Codigo = @Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[paInsertarClientes]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create OR ALTER PROCEDURE [dbo].[paInsertarClientes] 
	-- Add the parameters for the stored procedure here
	
	@NombreCompleto varchar(80), 
	@Zona varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Clientes (NombreCompleto, Zona)
	Values (@NombreCompleto,@Zona )
END


GO
/****** Object:  StoredProcedure [dbo].[paListarClientes]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create OR ALTER PROCEDURE [dbo].[paListarClientes] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Codigo, NombreCompleto, Zona from Clientes
END

GO
/****** Object:  StoredProcedure [dbo].[paModificarCliente]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create OR ALTER PROCEDURE [dbo].[paModificarCliente]
	-- Add the parameters for the stored procedure here
 @Codigo int,
 @NombreCompleto Varchar(80),
 @Zona Varchar(50)
AS
BEGIN
	
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	 UPDATE Clientes 
		SET		
		NombreCompleto = @NombreCompleto,
		Zona =  @Zona
		where Codigo = @Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[paOpcionLista]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[paOpcionLista] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdOpcion],[NombreOpcion] , [UrlOpcion], [RutaImagen],[NroOrden],[IdOpcionRef] from Opcion
END


GO
/****** Object:  StoredProcedure [dbo].[paUsuario_BuscaCodUserClave]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[paUsuario_BuscaCodUserClave]
	-- Add the parameters for the stored procedure here
	@Clave binary,
	@CodUsuario varchar(50)
AS
BEGIN
	
	--SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT IdUsuario,CodUsuario,Nombres From Usuario
	Where CodUsuario = @CodUsuario and Clave = @Clave
END


GO
/****** Object:  StoredProcedure [dbo].[paUsuario_insertar]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[paUsuario_insertar] 
	-- Add the parameters for the stored procedure here
	@Clave binary,
	@CodUsuario varchar(50), 
	@Nombres varchar(50)
AS
BEGIN
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Usuario (CodUsuario, Clave,Nombres)
	Values (@CodUsuario, @Clave, @Nombres )
END


GO
/****** Object:  StoredProcedure [dbo].[paUsuarioLista]    Script Date: 20/11/2020 06:28:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[paUsuarioLista] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT IdUsuario, CodUsuario, Clave, Nombres from Usuario
END


GO

SELECT * FROM Clientes

/****Procedimientos almacenados de Pedido*****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[paBuscarPedido]
    -- Parámetro para buscar el pedido
    @CodPedido varchar(50)
AS
BEGIN
    -- Buscar el pedido por su ID
    SELECT CodPedido, CodCliente, Estado 
    FROM Pedido
    WHERE CodPedido = @CodPedido
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[paInsertarPedido]
    -- Parámetros para insertar un nuevo pedido
    @CodPedido varchar(50),
    @CodCliente int,
    @Estado varchar(50)
AS
BEGIN
    -- Insertar un nuevo pedido
    INSERT INTO Pedido (CodPedido, CodCliente, Estado)
    VALUES (@CodPedido, @CodCliente, @Estado)
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[paListarPedidos]
AS
BEGIN
    -- Listar todos los pedidos junto con el nombre completo del cliente
    SELECT 
        p.IdPedido, 
        p.CodPedido, 
        c.NombreCompleto,
		p.Fecha,
        p.Estado 
    FROM Pedido p
    INNER JOIN Clientes c ON p.CodCliente = c.Codigo
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[paModificarPedido]
    -- Parámetros para modificar un pedido
    
    @CodPedido varchar(50),
    @CodCliente int,
    @Estado varchar(50)
AS
BEGIN
    -- Actualizar un pedido existente
    UPDATE Pedido
    SET 
        CodPedido = @CodPedido,
        CodCliente = @CodCliente,
        Estado = @Estado
    WHERE CodPedido = @CodPedido
END
GO

CREATE OR ALTER PROCEDURE [dbo].[paBorrarPedido]
    @CodPedido varchar(50)
AS
BEGIN
    --SET NOCOUNT ON;
    DELETE FROM Pedido WHERE CodCliente = @CodPedido;
END;
GO