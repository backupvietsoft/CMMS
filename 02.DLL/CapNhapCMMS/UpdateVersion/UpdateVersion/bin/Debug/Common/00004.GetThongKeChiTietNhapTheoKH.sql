IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetThongKeChiTietNhapTheoKH')
   exec('CREATE PROCEDURE dbo.GetThongKeChiTietNhapTheoKH AS BEGIN SET NOCOUNT ON; END')
GO



--EXEC GetThongKeChiTietNhapTheoKH 'D00350O'	

ALTER PROC GetThongKeChiTietNhapTheoKH
	@MS_KH NVARCHAR (50)
AS
	
SELECT ROW_NUMBER() OVER (ORDER BY T1.MS_DH_NHAP_PT, T1.NGAY) AS STT,
	T1.MS_DH_NHAP_PT, T1.NGAY, T1.SO_CHUNG_TU, T1.NGAY_CHUNG_TU, T3.TT_VND, T3.TT_TAX
FROM         dbo.IC_DON_HANG_NHAP AS T1 INNER JOIN (
	SELECT     MS_DH_NHAP_PT, SUM(ISNULL(SL_THUC_NHAP, 0) * ISNULL(DON_GIA, 0) * ISNULL(TY_GIA, 0)) AS TT_VND, SUM(ISNULL(TT_TAX, 0)) AS TT_TAX
	FROM          dbo.IC_DON_HANG_NHAP_VAT_TU GROUP BY MS_DH_NHAP_PT) AS T3 ON T1.MS_DH_NHAP_PT = T3.MS_DH_NHAP_PT
WHERE NGUOI_NHAP = @MS_KH
ORDER BY T1.MS_DH_NHAP_PT, T1.NGAY