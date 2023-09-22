
-----------------------------------------------------------------------------------------------------------------
----------------------------------------[ User Table And Operations ]--------------------------------------------
-----------------------------------------------------------------------------------------------------------------

CREATE DATABASE BookStoreDB;

Use BookStoreDB;

CREATE TABLE UserDetails(
UserId BIGINT IDENTITY(1,1) PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Email VARCHAR(max),
Password VARCHAR(max)
);

-----------------------------------------------------------------------------------------------------------------


CREATE or Alter PROCEDURE spRetriveAllUsers

AS BEGIN

BEGIN TRY

	SELECT * FROM  UserDetails;

END TRY
	BEGIN CATCH

		SELECT ERROR_MESSAGE() AS ErrorMessage; 

	END CATCH

END
-----------------------------------------------------------------------------------------------------------------

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


-----------------------------------------------------------------------------------------------------------------

Create or Alter Procedure spUpdateUserDeatils(
    @UserId BIGINT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(max),
    @Password VARCHAR(max)
)
As
Begin
    Begin Try
        Update UserDetails Set FirstName = @FirstName, LastName = @LastName,
         Email = @Email, Password = @Password  where UserId = @UserId;
    End Try
    Begin Catch
        Select ERROR_MESSAGE() as ErrorMessage;
    End Catch;
End

-----------------------------------------------------------------------------------------------------------------

Create or Alter Procedure spDeleteUser(
	@UserId BIGINT
)
As
Begin
    Begin Try
        Delete from UserDetails where UserId = @UserId;
    End Try
    Begin Catch
        Select ERROR_MESSAGE() as ErrorMessage;
    End Catch;
End


-----------------------------------------------------------------------------------------------------------------
----------------------------------------[ Book Table And Operations ]--------------------------------------------
-----------------------------------------------------------------------------------------------------------------


CREATE or Alter PROCEDURE spRetriveBooks

AS BEGIN

BEGIN TRY

	SELECT * FROM  Books;

END TRY
	BEGIN CATCH

		SELECT ERROR_MESSAGE() AS ErrorMessage; 

	END CATCH

END

-----------------------------------------------------------------------------------------------------------------

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

-----------------------------------------------------------------------------------------------------------------

Create or Alter Procedure spUpdateBookDeatils(
	@BookId BIGINT,
    @BookName VARCHAR(max),
    @Author VARCHAR(max),
    @Details VARCHAR(max),
    @Price float,
    @Quantity VARCHAR(max),
    @Images VARCHAR(max)
)
As
Begin
    Begin Try
        Update  Books Set BookName=@BookName, Author=@Author, Details=@Details, 
        Price=@Price, Quantity=@Quantity, Images=@Images where BookId = @BookId;
    End Try
    Begin Catch
        Select ERROR_MESSAGE() as ErrorMessage;
    End Catch;
End

-----------------------------------------------------------------------------------------------------------------

Create or Alter Procedure spDeleteBook(
	@BookName BIGINT
)
As
Begin
    Begin Try
        Delete from Books where BookName = @BookName;
    End Try
    Begin Catch
        Select ERROR_MESSAGE() as ErrorMessage;
    End Catch;
End