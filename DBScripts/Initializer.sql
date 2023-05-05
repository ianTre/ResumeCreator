Create dataBase DBResumeCreator
GO
use DBResumeCreator
GO
create table ProfileData
	(
		Id int IDENTITY(1,1) NOT NULL Primary Key,
		DependentId int null ,
		UserName varchar(200) ,
		Email varchar(200) ,
		DNI varchar(200),
		UserAddress varchar(200),
		IsMainProfile bit,
		Age int
	)
GO



--STORED PROCEDURES

-- =============================================
-- Author:		itrejo002
-- Create date: 10-3-2023
-- Description:	Get all Data from ProfileData
-- =============================================
CREATE PROCEDURE dbo.ProfileDataGetAll
	
AS
BEGIN
	SELECT * from ProfileData
END
GO


USE [DBResumeCreator]
GO
/****** Object:  StoredProcedure [dbo].[ProfileDataGetAll]    Script Date: 17/3/2023 20:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		itrejo002
-- Create date: 17-3-2023
-- Description:	Get a single raw from ProfileData
-- =============================================
CREATE PROCEDURE [dbo].[ProfileDataGet]
	(
		@UserId int
	)
AS
BEGIN
	SELECT * from ProfileData where Id = @UserId
END



GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		itrejo002
-- Create date: 31-3-2023
-- Description:	Delete a Profile Data entry
-- =============================================
CREATE PROCEDURE ProfileDataDelete
	(
		@id int
	)
AS
BEGIN
	DELETE ProfileData where Id = @id 
END
GO




GO
/****** Object:  StoredProcedure [dbo].[ProfileDataSave]    Script Date: 14/4/2023 19:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProfileDataSave]
	(
        @DependentId int,
        @UserName varchar(100),
        @Email varchar(100),
        @DNI varchar(100),
        @UserAddress varchar(100),
        @IsMainProfile bit,
		@Age int
	)
AS
BEGIN
	
	INSERT INTO ProfileData VALUES ( @DependentId , @UserName , @Email , @DNI , @UserAddress , @IsMainProfile , @Age)
	
END



GO
/****** Object:  StoredProcedure [dbo].[ProfileDataUpdate]    Script Date: 14/4/2023 19:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Itrejo002
-- Create date: 10-3-2023
-- Description:	Update a Profile data entry
-- =============================================
CREATE PROCEDURE [dbo].[ProfileDataUpdate]
	(
		@UserId int,
        @DependentId int,
        @UserName varchar(100),
        @Email varchar(100),
        @DNI varchar(100),
        @UserAddress varchar(100),
        @IsMainProfile bit,
		@Age int
	)
AS
BEGIN
	
	UPDATE ProfileData SET DependentId = @DependentId , UserName = @UserName ,Email = @Email , dni = @DNI , UserAddress = @UserAddress , IsMainProfile = @IsMainProfile  , Age = @Age
	where Id = @UserId
	
END

USE [DBResumeCreator]
GO

/****** Object:  Table [dbo].[ProfileData]    Script Date: 26/4/2023 16:39:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[EducationLevelId] [int] NULL, /* Ac� ir�a el id de referencia de la tabla nivel */
	[Institution] [varchar](200) NOT NULL,
	[FieldOfStudyId] [int] NULL,  /* Ac� ir�a el id de la tabla de camoo de estudio, lo mas abarcativa posible (Ciencias exactas, humanidades,etc)  */
	[StartDate] [date] NULL, 
	[EndDate] [date] NULL,
    [AttendingCheck] [bit] NULL,
	[Description] [varchar] (1000) NULL,



PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DBResumeCreator]
GO

/****** Object:  Table [dbo].[Education]    Script Date: 5/5/2023 15:49:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EducationLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EdLevelItem] [varchar] (200) NULL,
	
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO EducationLevel (EdLevelItem) VALUES ('Secundario')
INSERT INTO EducationLevel (EdLevelItem) VALUES ('Terciario')
INSERT INTO EducationLevel (EdLevelItem) VALUES ('Licenciatura')
INSERT INTO EducationLevel (EdLevelItem) VALUES ('Universitario')
INSERT INTO EducationLevel (EdLevelItem) VALUES ('Posgrado')
INSERT INTO EducationLevel (EdLevelItem) VALUES ('Doctorado')
INSERT INTO EducationLevel (EdLevelItem) VALUES ('Otro')
INSERT INTO EducationLevel (EdLevelItem) VALUES ('No Especificado')

USE [DBResumeCreator]
GO

/****** Object:  Table [dbo].[Education]    Script Date: 5/5/2023 15:49:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FieldOfStudy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FieldItem] [varchar] (200) NULL,
	
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO FieldOfStudy (FieldItem) VALUES ('Administraci�n')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Arte')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Ciencias Exactas')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Ciencias Naturales')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Ciencias Pol�ticas')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Ciencias Sociales')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Defensa Civil y Seguridad')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Econom�a y Gesti�n')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Educaci�n')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Humanidades')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Idiomas')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Ingenier�a')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Log�stica')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Medicina')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Profesi�n')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Religi�n')
INSERT INTO FieldOfStudy (FieldItem) VALUES ('Tecnolog�a e Inform�tica')












