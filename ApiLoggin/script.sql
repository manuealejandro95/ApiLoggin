USE [APIPRUEBAS]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 31/01/2023 10:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CorreoElectronico] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CRUDUSUARIO]    Script Date: 31/01/2023 10:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<MANUEL PACHECO>
-- Create date: <31/01/2023>
-- Description:	<CRUD TABLE Usuarios>
-- =============================================
CREATE PROCEDURE [dbo].[CRUDUSUARIO]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@EMAIL VARCHAR(100),
	@PASSWORD VARCHAR (100),
	@ACCION VARCHAR(10)
AS
BEGIN
	IF(@ACCION = 'INSERT')
		BEGIN
			INSERT INTO Usuarios(CorreoElectronico,Password) VALUES(@EMAIL,@PASSWORD);
		END
	ELSE IF(@ACCION = 'SEARCH')
		BEGIN
			SELECT Id, CorreoElectronico, Password
			FROM Usuarios 
			WHERE CorreoElectronico=@EMAIL;
		END
	ELSE IF(@ACCION = 'LOGGIN')
		BEGIN
			SELECT Id, CorreoElectronico, Password
			FROM Usuarios 
			WHERE CorreoElectronico=@EMAIL AND Password = @PASSWORD;
		END
	ELSE
		BEGIN
			SELECT Id, CorreoElectronico, Password
			FROM Usuarios;
		END
END
GO
