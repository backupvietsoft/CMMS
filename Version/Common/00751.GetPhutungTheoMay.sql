
--exec GetPhutungTheoMay '', ''
ALTER procedure [dbo].[GetPhutungTheoMay] 	
	@MS_LAN	VARCHAR(50), 
	@MS_MAY NVARCHAR(50)

AS
	SELECT T1.*, T2.TEN_BO_PHAN,T3.TEN_PT, CONVERT(INT, 0) AS DEL FROM THOI_GIAN_NGUNG_MAY_PHU_TUNG T1
	INNER JOIN CAU_TRUC_THIET_BI T2 ON T1.MS_BO_PHAN = T2.MS_BO_PHAN AND T1.MS_MAY = T2.MS_MAY 
	left JOIN IC_PHU_TUNG T3 ON T3.MS_PT = T1.MS_PT
	 WHERE T1.MS_MAY = @MS_MAY
	
	AND T1.MS_LAN = @MS_LAN 