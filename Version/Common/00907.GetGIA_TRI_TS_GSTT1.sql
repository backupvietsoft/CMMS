
ALTER proc [dbo].[GetGIA_TRI_TS_GSTT1]
	@MS_TS_GSTT nvarchar(10)
AS
SELECT TEN_GIA_TRI,DAT,GHI_CHU,MS_TS_GSTT,STT
 FROM GIA_TRI_TS_GSTT
WHERE 
	MS_TS_GSTT=@MS_TS_GSTT
ORDER BY DAT desc
