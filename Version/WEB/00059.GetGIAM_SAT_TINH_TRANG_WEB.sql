
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetGIAM_SAT_TINH_TRANG_WEB')  
exec('CREATE PROCEDURE GetGIAM_SAT_TINH_TRANG_WEB AS BEGIN SET NOCOUNT ON; END')
GO
-- EXEC GetGIAM_SAT_TINH_TRANG_WEB '01/01/2011', '11/01/2020','-1','HCSHCM0005'
ALTER proc [dbo].[GetGIAM_SAT_TINH_TRANG_WEB]
	@TU_NGAY datetime,
	@DEN_NGAY	datetime,
	@MS_CONG_NHAN	NVARCHAR(50),
	@MS_MAY NVARCHAR(30)
AS
SELECT * FROM 
	(SELECT     STT, SO_PHIEU, NGAY_KH, NGAY_KT,GIO_KT,  
                      T.HO + ' ' + T.TEN AS HO_TEN, T.MS_CONG_NHAN,DEN_GIO,
                      dbo.GetMSMayGSTT(STT) AS MS_MAY ,dbo.GettenMayGSTT(STT) AS TEN_MAY , NHAN_XET, ISNULL(TONG_GIO,0) AS TONG_GIO
	FROM         GIAM_SAT_TINH_TRANG LEFT JOIN
	                      CONG_NHAN T ON T.MS_CONG_NHAN = GIAM_SAT_TINH_TRANG.MS_CONG_NHAN 
	WHERE (CONVERT(DATE,NGAY_KT) BETWEEN CONVERT(DATE,@TU_NGAY) AND  CONVERT(DATE,@DEN_NGAY)) 
		AND (T.MS_CONG_NHAN = @MS_CONG_NHAN OR @MS_CONG_NHAN = '-1'))A
	WHERE (A.MS_MAY LIKE'%'+@MS_MAY+'%' OR @MS_MAY = '-1')
		ORDER BY A.NGAY_KT DESC ,A.GIO_KT DESC
		
		