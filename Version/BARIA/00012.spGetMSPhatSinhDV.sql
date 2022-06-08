IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetMSPhatSinhDV')
   exec('CREATE PROCEDURE [dbo].[spGetMSPhatSinhDV] AS BEGIN SET NOCOUNT ON; END')
GO


--EXEC spGetMSPhatSinhDV '201508', 'PR'


ALTER proc spGetMSPhatSinhDV
	@MONTH NVARCHAR(6), 
	@Ms NVARCHAR(5)
AS
DECLARE @TonTai INT
SELECT @TonTai = COUNT (*) FROM PHAT_SINH_DICH_VU  WHERE [MS_YEU_CAU] LIKE @Ms + '-'+@MONTH+'%'

IF (@TonTai = 0 )
BEGIN
	SELECT @MONTH + '000001'
END
ELSE
BEGIN
	SELECT MAX(CONVERT(FLOAT, SUBSTRING([MS_YEU_CAU], LEN(@Ms) + 2 ,LEN([MS_YEU_CAU])))) + 1 AS 'MS_YEU_CAU' 
	FROM [PHAT_SINH_DICH_VU]
	WHERE [MS_YEU_CAU] LIKE @Ms + '-'+@MONTH+'%'
END


