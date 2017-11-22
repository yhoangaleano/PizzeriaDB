CREATE DATABASE [pizzeriaDB]
GO
USE [pizzeriaDB]
GO
CREATE TABLE [dbo].[tblIngrediente](
	[idIngrediente] [int] IDENTITY(1,1) NOT NULL,
	[nombreIngrediente] [varchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_tblIngrediente] PRIMARY KEY CLUSTERED 
(
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblIngredientePizza]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIngredientePizza](
	[idIngredientePizza] [int] IDENTITY(1,1) NOT NULL,
	[idIngrediente] [int] NOT NULL,
	[idPizza] [int] NOT NULL,
 CONSTRAINT [PK_tblIngredientePizza] PRIMARY KEY CLUSTERED 
(
	[idIngredientePizza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPizza]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPizza](
	[idPizza] [int] IDENTITY(1,1) NOT NULL,
	[nombrePizza] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL CONSTRAINT [DF_tblPizza_estado]  DEFAULT ((1)),
 CONSTRAINT [PK_tblPizza] PRIMARY KEY CLUSTERED 
(
	[idPizza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblIngredientePizza]  WITH CHECK ADD  CONSTRAINT [FK_tblIngredientePizza_tblIngrediente] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[tblIngrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[tblIngredientePizza] CHECK CONSTRAINT [FK_tblIngredientePizza_tblIngrediente]
GO
ALTER TABLE [dbo].[tblIngredientePizza]  WITH CHECK ADD  CONSTRAINT [FK_tblIngredientePizza_tblPizza] FOREIGN KEY([idPizza])
REFERENCES [dbo].[tblPizza] ([idPizza])
GO
ALTER TABLE [dbo].[tblIngredientePizza] CHECK CONSTRAINT [FK_tblIngredientePizza_tblPizza]
GO
/****** Object:  StoredProcedure [dbo].[ACTIVE_PIZZA]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTIVE_PIZZA] 
	@idPizza int
AS
BEGIN
	
	UPDATE tblPizza
	SET estado = 1 
	WHERE idPizza = @idPizza;

END

GO
/****** Object:  StoredProcedure [dbo].[DELETE_PIZZA]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETE_PIZZA] 
	@idPizza int
AS
BEGIN
	
	DELETE tblPizza 
	WHERE idPizza = @idPizza;

END

GO
/****** Object:  StoredProcedure [dbo].[INACTIVE_PIZZA]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INACTIVE_PIZZA] 
	@idPizza int
AS
BEGIN
	
	UPDATE tblPizza
	SET estado = 0 
	WHERE idPizza = @idPizza;

END

GO
/****** Object:  StoredProcedure [dbo].[INSERT_PIZZA]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_PIZZA] 
	@nombrePizza varchar(50)
AS
BEGIN
	
	INSERT INTO tblPizza (nombrePizza)
	VALUES (@nombrePizza);

END

GO
/****** Object:  StoredProcedure [dbo].[LIST_PIZZA]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LIST_PIZZA] 
AS
BEGIN
	
	SELECT idPizza, nombrePizza, estado
	FROM tblPizza;

END

GO
/****** Object:  StoredProcedure [dbo].[SEARCH_PIZZA]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SEARCH_PIZZA]
	@idPizza int,
	@nombrePizza varchar(50),
	@estado bit,
	@opcion tinyint 
AS
BEGIN
	
	--Buscar por el nombre
	IF(@opcion = 1)
	BEGIN
		SELECT idPizza, nombrePizza, estado
		FROM tblPizza
		WHERE nombrePizza LIKE @nombrePizza;
	END
	-- Buscar por el id
	ELSE IF(@opcion = 2)
    BEGIN
		SELECT idPizza, nombrePizza, estado
		FROM tblPizza
		WHERE idPizza = @idPizza;
    END
	-- Buscar por el estado
	ELSE IF(@opcion = 3)
    BEGIN
		SELECT idPizza, nombrePizza, estado
		FROM tblPizza
		WHERE estado = @estado;
    END

END

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_PIZZA]    Script Date: 22/11/2017 12:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_PIZZA] 
	@idPizza int,
	@nombrePizza varchar(50),
	@estado bit
AS
BEGIN
	
	UPDATE tblPizza 
	SET nombrePizza = @nombrePizza, estado = @estado
	WHERE idPizza = @idPizza;

END

GO
