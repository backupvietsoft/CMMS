
ALTER proc [dbo].[Get_TO]
	@MS_TO INT --láy các tổ thuộc phòng ban @MS_TO
AS
SELECT * FROM [TO]
WHERE MS_TO=@MS_TO


