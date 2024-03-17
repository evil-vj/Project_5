
CREATE TABLE Books (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    publisher NVARCHAR(MAX),
    title NVARCHAR(MAX),
    authorLastName NVARCHAR(MAX),
    authorFirstName NVARCHAR(MAX),
    price DECIMAL(18, 2)
);


CREATE PROCEDURE prcGetBooksDataByAuthor
AS
BEGIN 

SELECT * FROM Books ORDER BY authorLastName, authorFirstName, title

END


CREATE PROCEDURE prcGetBooksDataByPublisher
AS
BEGIN 

SELECT * FROM Books ORDER BY publisher, authorLastName, authorFirstName, title

END

