CREATE DATABASE BookStoreDB;

Use BookStoreDB;

CREATE TABLE UserDetails(
UserId BIGINT IDENTITY(1,1) PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Email VARCHAR(max),
Password VARCHAR(max)
);

CREATE OR ALTER PROCEDURE spAddingNewDataUserDetails(

@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Email VARCHAR(max),
@Password VARCHAR(max)
)
AS BEGIN

BEGIN TRY

INSERT INTO UserDetails VALUES(@FirstName, @LastName, @Email, @Password);

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE() AS ErrorMessage; 

END CATCH

END



------------------------------------------------------------------------------------------------------------------

























CREATE or Alter PROCEDURE spRetriveBooks

AS BEGIN

BEGIN TRY

SELECT * FROM  Books;

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE() AS ErrorMessage; 

END CATCH

END

EXEC spRetriveBooks;

Create or Alter Procedure spDeleteBook(
	@BookId BIGINT
)
As
Begin
Begin Try
Delete from Books where BookId = @BookId;
End Try
Begin Catch
Select ERROR_MESSAGE() as ErrorMessage;
End Catch;
End