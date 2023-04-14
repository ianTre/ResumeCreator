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
		IsMainProfile bit
	)
GO



--STORED PROCEDURES

-- =============================================
-- Author:		Itrejo002
-- Create date: 10-3-2023
-- Description:	Insert data 
-- =============================================
CREATE PROCEDURE ProfileDataSave
	(
        @DependentId int,
        @UserName varchar(100),
        @Email varchar(100),
        @DNI varchar(100),
        @UserAddress varchar(100),
        @IsMainProfile bit
	)
AS
BEGIN
	
	INSERT INTO ProfileData VALUES ( @DependentId , @UserName , @Email , @DNI , @UserAddress , @IsMainProfile )
	
END
GO


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
/****** Object:  StoredProcedure [dbo].[ProfileDataSave]    Script Date: 31/3/2023 19:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Itrejo002
-- Create date: 10-3-2023
-- Description:	Update a Profile data entry
-- =============================================
ALTER PROCEDURE [dbo].[ProfileDataUpdate]
	(
		@UserId int,
        @DependentId int,
        @UserName varchar(100),
        @Email varchar(100),
        @DNI varchar(100),
        @UserAddress varchar(100),
        @IsMainProfile bit
	)
AS
BEGIN
	
	UPDATE ProfileData SET DependentId = @DependentId , UserName = @UserName ,Email = @Email , dni = @DNI , UserAddress = @UserAddress , IsMainProfile = @IsMainProfile 
	where Id = @UserId
	
END


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
ALTER PROCEDURE [dbo].[ProfileDataSave]
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
ALTER PROCEDURE [dbo].[ProfileDataUpdate]
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
