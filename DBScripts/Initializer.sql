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
