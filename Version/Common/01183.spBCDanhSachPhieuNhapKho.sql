IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spBCDanhSachPhieuNhapKho')
   exec('CREATE PROCEDURE spBCDanhSachPhieuNhapKho AS BEGIN SET NOCOUNT ON; END')
GO



ALTER PROC [dbo].[spBCDanhSachPhieuNhapKho]
	@TuNgay DATETIME = '07/01/2017',
	@DenNgay DATETIME = '07/31/2017',
	@LVTu NVARCHAR(100) = '-1',
	@MsKho INT= -1,
	@UserName NVARCHAR(50) = 'Admin',
	@NNgu INT = 0
AS


SELECT 

ROW_NUMBER() OVER (ORDER BY T1.MS_DH_NHAP_PT,T2.MS_PT) AS STT, 

T1.MS_DH_NHAP_PT, T2.MS_PT, T3.TEN_PT, 
CASE @NNgu WHEN 0 THEN T4.TEN_LOAI_VT_TV WHEN 1 THEN T4.TEN_LOAI_VT_TA ELSE T4.TEN_LOAI_VT_TH END AS TEN_LOAI_VT, 
CASE @NNgu WHEN 0 THEN T6.TEN_1 WHEN 1 THEN T6.TEN_2 ELSE T6.TEN_3 END AS TEN_DVT, 
 T2.SL_THUC_NHAP, T5.MS_KH, T5.TEN_RUT_GON, 
 CASE T1.MS_DDH WHEN '-1' THEN NULL ELSE T1.MS_DDH END AS MS_DDH 
 , NULL AS SO_TO_KHAI, NULL AS LE_PHI_HQ, T2.XUAT_XU, T2.GHI_CHU

FROM            dbo.IC_DON_HANG_NHAP AS T1 INNER JOIN
                         dbo.IC_DON_HANG_NHAP_VAT_TU AS T2 ON T1.MS_DH_NHAP_PT = T2.MS_DH_NHAP_PT INNER JOIN
                         dbo.IC_PHU_TUNG AS T3 ON T2.MS_PT = T3.MS_PT INNER JOIN
                         dbo.LOAI_VT AS T4 ON T3.MS_LOAI_VT = T4.MS_LOAI_VT LEFT JOIN
                         (SELECT MS_KH, TEN_RUT_GON FROM KHACH_HANG UNION SELECT MS_CONG_NHAN, HO + ' ' + TEN  FROM CONG_NHAN) AS T5 ON T1.NGUOI_NHAP = T5.MS_KH LEFT JOIN
                         dbo.DON_VI_TINH AS T6 ON T3.DVT = T6.DVT
WHERE (CONVERT(DATE,T1.NGAY) BETWEEN @TuNgay AND @DenNgay) AND (T3.MS_LOAI_VT = @LVTu OR @LVTu = '-1')
AND (T1.MS_KHO = @MsKho OR @MsKho = -1)
ORDER BY T1.MS_DH_NHAP_PT,T2.MS_PT



