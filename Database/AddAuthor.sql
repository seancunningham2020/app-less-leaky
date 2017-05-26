USE BookshelfDB
GO

CREATE PROCEDURE AddAuthor (
	@AuthorName	NVARCHAR(100)
) AS
BEGIN
	BEGIN TRY
	IF EXISTS (SELECT TOP 1 1 FROM Authors WHERE [Name] = @AuthorName)
		THROW 10001, 'Duplicate author - insert aborted', 1;
	ELSE
		INSERT INTO Authors ([Name]) VALUES (@AuthorName)
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO
