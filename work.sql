
--Database creation
Create Database StudentData
go
--DATABASE USING
Use StudentData
go

--Functions 

--Function for ID in marks
CREATE FUNCTION dbo.Id()
RETURNS CHAR(4)
AS
BEGIN
     DECLARE @Id CHAR(4)
     IF NOT EXISTS(SELECT Id FROM Marks)
          SET @Id='M101'
     ELSE
          SELECT @Id='M'+
              CAST(CAST(SUBSTRING(MAX(Id),2,3) AS INT)+1 AS CHAR)     
              FROM Marks
     RETURN @Id
END
GO

--Function for user login
CREATE FUNCTION ufn_ValidateUserCredentials
(
	@EmailId VARCHAR(50),
    @UserPassword VARCHAR(15)
)
RETURNS bit
AS
BEGIN
	if exists(SELECT EmailId FROM ALogin WHERE EmailId=@EmailId AND Passwd=@UserPassword)
    Begin
	RETURN 1
    end
    else
    begin
    RETURN 0
    end
   RETURN 0
END
GO
--Function For RollNo
CREATE FUNCTION RollNo
(
@sRollNo BIGINT,
@sYr BIGINT
)
RETURNS BIGINT
AS
BEGIN
DECLARE @Roll BIGINT
SET @Roll= CONCAT(@sRollNo,@sYr)
RETURN @Roll
END
GO

--Function For Average
CREATE FUNCTION Average
(
@Maths BIGINT,
@Science BIGINT,
@History BIGINT,
@Geo BIGINT, 
@Eng BIGINT
)
RETURNS decimal(10,2)
AS
BEGIN
DECLARE @Average decimal(10,2) 
DECLARE @Sum decimal
SET @Sum= @Maths+@Science+@History+@Geo+@Eng
SET @Average = @Sum / 5
RETURN @Average  
END
GO

--Previous Year Average
CREATE FUNCTION SM_Avg
(@Maths BIGINT,
@Science BIGINT
)
RETURNS DECIMAL(10,2)
AS 
BEGIN
DECLARE @Avg DECIMAL(10,2)
DECLARE @Add DECIMAL
SET @Add = @Maths+@Science
SET @Avg = @Add/2
RETURN @Avg
END
GO

--Procedure
--Procedure for Registration 
CREATE PROCEDURE dbo.AddStudent
    @sRollNo BIGINT, 
    @sContact BIGINT, 
    @sFirstName VARCHAR(16), 
    @sLastName VARCHAR(16),
    @sJYear VARCHAR(4),
    @sFatherName VARCHAR(30),
    @sClass CHAR(1)
AS
BEGIN
Declare @ResponseMessage BIGINT
SET NOCOUNT Off
    BEGIN TRY 
    INSERT INTO Student (RollNo, JoiningYear, StudentFName, StudentLName, Contact, FatherName, Class) 
    VALUES
    (dbo.RollNo(@sRollNo,@sJYear), @sJYear, @sFirstName, @sLastName, @sContact, @sFatherName,@sClass)
    	SET @ResponseMessage = 1
        Return @ResponseMessage
        	END TRY
	BEGIN CATCH
		SET @ResponseMessage = 0
        Return @ResponseMessage
	END CATCH    
END 
GO

--Procedure for deleting marks
CREATE PROCEDURE dbo.del
@RollNo BIGINT,
@Year Bigint
AS
BEGIN
DECLARE @RESPONSE BIGINT
BEGIN TRY
DELETE FROM Marks WHERE RollNo = @RollNo AND Yr = @Year
IF(@@ROWCOUNT >= 1)
BEGIN
SET @RESPONSE =1
END
END TRY
BEGIN CATCH
SET @RESPONSE = 0
END CATCH
RETURN @RESPONSE
END
GO


--PROCEDURE FOR MARKS ENTRY
CREATE PROCEDURE dbo.MarksAdd
@Id varchar(5),
@Yr BIGINT,
@RollNo BIGINT,  
@Maths BIGINT,
@Science BIGINT,
@History BIGINT,
@Geo BIGINT,
@Eng BIGINT,
@Avg Decimal(10,2),
@SAvg Decimal(10,2)

AS 
BEGIN
DECLARE @Message BIGINT
SET NOCOUNT OFF
BEGIN TRY
INSERT INTO Marks ( Id, RollNo, Maths, Science, History, Geography, English, Marks_Average,SM_Average,Yr ) 
VALUES
(@Id,@RollNo, @Maths, @Science, @History, @Geo, @Eng,@Avg,@SAvg,@Yr)
SET @Message = 1
RETURN 1
END TRY
BEGIN CATCH
SET @Message = 0
RETURN 0
END CATCH
END
GO
--drop procedure MarksAdd

--Exec dbo.MarksEntry 
-- @Id = 'M101',
--@Yr  = 2019,
--@RollNo =32022,
--@Maths  = 47,
--@Science  = 63,
--@History  = 53,
--@Geo  = 51,
--@Eng  = 75


--drop procedure dbo.MarksEntry
--Table Creation
--Admin Login 
CREATE TABLE ALogin
(
UserID CHAR(4) PRIMARY KEY, 
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
EmailId VARCHAR(30) NOT NULL,
Passwd VARCHAR(20) NOT NULL
)
GO

--insert into ALogin values('A101','Mayank','Gigras','abc@email.com', 'abcc@ggg')

--student 
CREATE TABLE Student
(
RollNo BIGINT PRIMARY KEY,
JoiningYear BIGINT NOT NULL,
StudentFName VARCHAR(16) NOT NULL,
StudentLName VARCHAR(16) NOT NULL,
Contact BIGINT NOT NULL,
FatherName VARCHAR(30) NOT NULL,
Class CHAR(1) NOT NULL
)
GO


--marks 
CREATE TABLE Marks
(
Id varchar(5)  primary key,
Yr BIGINT NOT NULL,
RollNo BIGINT NOT NULL CONSTRAINT FK_RNo FOREIGN KEY (RollNo) REFERENCES Student(RollNo),
Maths BIGINT NOT NULL,
Science BIGINT NOT NULL,
History BIGINT NOT NULL,
Geography BIGINT NOT NULL,
English BIGINT NOT NULL,
Marks_Average Decimal(10,2) , 
SM_Average Decimal(10,2) 
)
GO
--insert into Marks values('M101',2022,32022,100,85,85,85,85,85,85)
--drop table marks
--Exec AddStudent 

--insert into marks values('M101',42022,'A',2022,100,85,60,52,44,55.4,55.4)

--select Count(RollNo) from Marks where yr = Year(GETDATE())-2 and Maths = (select max(Maths) from Marks where yr = Year(GETDATE())-2)  

--select * from Marks

--select * from Student
--insert into Student values(42022,2022,'Maanit','Singal',8740908577,'Mayank Gigras','A')
--insert into marks (Yr,Class,RollNo,Maths,Science,History,Geography,English,Marks_Average,SM_Average)values(2020,'A',42022,100,85,60,52,44,55.4,92)
--select * from ALogin

select Count(Science) from Marks where Science = (select  Max(Science) from Marks where Yr =2022)
go
CREATE FUNCTION ufn_maxsci
()
RETURNS bigint
as 
begin
declare @message bigint
set @message =( select Count(Science) from Marks where Science = (select  Max(Science) from Marks where Yr =Year(GETDATE())))
return @message
END
GO
--drop function ufn_maxsci
CREATE FUNCTION ufn_maxmaths
()
RETURNS bigint
as 
begin
declare @message bigint
set @message =( select Count(Maths) from Marks where Maths = (select  Max(Maths) from Marks where Yr =Year(GETDATE())))
return @message
END
GO
--drop function ufn_maxmaths
CREATE FUNCTION ufn_maxeng
()
RETURNS bigint
as 
begin
declare @message bigint
set @message =( select Count(English) from Marks where English = (select  Max(English) from Marks where Yr =Year(GETDATE())))
return @message
END
GO
--drop function ufn_maxmaths