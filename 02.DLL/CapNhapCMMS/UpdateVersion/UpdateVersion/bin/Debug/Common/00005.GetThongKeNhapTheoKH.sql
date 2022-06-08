IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetThongKeNhapTheoKH')
   exec('CREATE PROCEDURE dbo.GetThongKeNhapTheoKH AS BEGIN SET NOCOUNT ON; END')
GO


--	EXEC GetThongKeNhapTheoKH '01/16/2014','06/16/2014','17,19',-1

alter PROC  [dbo].[GetThongKeNhapTheoKH]
	@TuNgay datetime,
	@DenNgay datetime,
	@MS_KHO nvarchar(500),	
	@UserName nvarchar(50)
as	


CREATE TABLE #KHO_TMP([MS_KHO] INT)

DECLARE @sSql nvarchar(4000)
IF @MS_KHO = '-1'
	set @sSql = 'INSERT INTO #KHO_TMP SELECT MS_KHO FROM IC_KHO '
ELSE
	set @sSql = 'INSERT INTO #KHO_TMP SELECT MS_KHO FROM IC_KHO WHERE MS_KHO IN (' + @MS_KHO  + ') '
EXEC (@sSql)



SELECT ROW_NUMBER() OVER (ORDER BY T2.TEN_RUT_GON, T2.TEN_CONG_TY) AS STT,
 T2.MS_KH, T2.TEN_RUT_GON, T2.TEN_CONG_TY, T2.DIA_CHI, SUM(T3.TT_VND) AS TT_VND, SUM(T3.TT_TAX) AS TT_TAX
FROM         dbo.IC_DON_HANG_NHAP AS T1 INNER JOIN
                      dbo.KHACH_HANG AS T2 ON T1.NGUOI_NHAP = T2.MS_KH INNER JOIN
                          (SELECT     MS_DH_NHAP_PT, SUM(ISNULL(SL_THUC_NHAP, 0) * ISNULL(DON_GIA, 0) * ISNULL(TY_GIA, 0)) AS TT_VND, SUM(ISNULL(TT_TAX, 0)) AS TT_TAX
                            FROM          dbo.IC_DON_HANG_NHAP_VAT_TU
                            GROUP BY MS_DH_NHAP_PT) AS T3 ON T1.MS_DH_NHAP_PT = T3.MS_DH_NHAP_PT 
                            INNER JOIN #KHO_TMP T6 ON T1.MS_KHO = T6.MS_KHO
WHERE  (CONVERT(DATETIME,CONVERT(NVARCHAR(10),NGAY,101)) BETWEEN CONVERT(DATETIME,CONVERT(NVARCHAR(10),@TuNgay,101)) AND CONVERT(DATETIME,CONVERT(NVARCHAR(10),@DenNgay,101)))
GROUP BY T2.TEN_RUT_GON, T2.TEN_CONG_TY, T2.DIA_CHI, T2.MS_KH
ORDER BY T2.TEN_RUT_GON, T2.TEN_CONG_TY



