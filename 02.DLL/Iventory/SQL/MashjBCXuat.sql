
--exec MashjBCXuatCT MashjBCXuat 'PX-1112-0012',0

ALTER procedure [dbo].[MashjBCXuat]
			@MS_DH_XUAT_PT NVARCHAR (14),
			@LANGUAGE INT 
AS
BEGIN

SELECT     A.SO_PHIEU_XN, TMP.TEN_NGUOI_NHAP, A.SO_CHUNG_TU, 
CASE @LANGUAGE WHEN 1 THEN F.DANG_XUAT_ANH  WHEN 2 THEN F.DANG_XUAT_HOA  ELSE F.DANG_XUAT_VIET END AS DANG_XUAT, 
A.LY_DO_XUAT, A.NGAY, D.TEN_KHO
FROM         dbo.IC_DON_HANG_XUAT_X AS A INNER JOIN
                      dbo.DANG_XUAT_X AS F ON A.MS_DANG_XUAT = F.MS_DANG_XUAT INNER JOIN
                      dbo.IC_KHO AS D ON A.MS_KHO = D.MS_KHO INNER JOIN
                          (SELECT     MS_CONG_NHAN AS MS_NGUOI_NHAN, HO + TEN AS TEN_NGUOI_NHAP
                            FROM          dbo.CONG_NHAN
                            UNION
                            SELECT     MS_KH AS MS_NGUOI_NHAP, TEN_CONG_TY AS TEN_NGUOI_NHAP
                            FROM         dbo.KHACH_HANG) AS TMP ON A.NGUOI_NHAN = TMP.MS_NGUOI_NHAN
WHERE A.MS_DH_XUAT_PT = @MS_DH_XUAT_PT		                            

END