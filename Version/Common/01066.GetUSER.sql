ALTER proc [dbo].[GetUSER]
	@USERNAME NVARCHAR(50)
AS
SELECT * FROM USERS
WHERE USERNAME=@USERNAME
