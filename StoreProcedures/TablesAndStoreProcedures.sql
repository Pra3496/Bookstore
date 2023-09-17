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