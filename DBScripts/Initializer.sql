Create dataBase DBResumeCreator
use DBResumeCreator

create table ProfileData
	(
		Id int IDENTITY(1,1) NOT NULL Primary Key,
		DependentId int null ,
		UserName varchar(200) ,
		Email varchar(200) ,
		DNI varchar(200),
		IsMainProfile bit
	)