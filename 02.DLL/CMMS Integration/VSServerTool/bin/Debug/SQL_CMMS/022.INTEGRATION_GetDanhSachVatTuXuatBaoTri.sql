
--EXEC [INTEGRATION_GetDanhSachVatTuXuatBaoTri] 'WO-201112004'
CREATE procedure [dbo].[INTEGRATION_GetDanhSachVatTuXuatBaoTri] 
	@MS_PHIEU_BAO_TRI nvarchar(30)
AS

SELECT      dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT, dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT, dbo.IC_PHU_TUNG.TEN_PT,
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_KH, ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_ALLOCATED,0) AS SL_ALLOCATED, dbo.IC_DON_HANG_XUAT_VAT_TU.SO_LUONG_THUC_XUAT, 
                      ISNULL(dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.DON_GIA) AS DON_GIA,
                      ISNULL(dbo.IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.NGOAI_TE)AS NGOAI_TE,
                      ISNULL(dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA)AS TY_GIA ,
                      ISNULL(dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA_USD,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA_USD) AS TY_GIA_USD
FROM         dbo.IC_PHU_TUNG INNER JOIN
                      dbo.IC_DON_HANG_XUAT INNER JOIN
                      dbo.IC_DON_HANG_XUAT_VAT_TU ON dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT INNER JOIN
                      dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET ON 
                      dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_XUAT_PT AND 
                      dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT INNER JOIN
                      dbo.IC_DON_HANG_NHAP_VAT_TU ON 
                      dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND 
                      dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ON 
                      dbo.IC_PHU_TUNG.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT INNER JOIN
                      dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT LEFT OUTER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON 
                      dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND 
                      dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI
where  dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI and  dbo.LOAI_VT.VAT_TU = 1

UNION 

SELECT    NULL  AS MS_DH_XUAT_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, dbo.IC_PHU_TUNG.TEN_PT,
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_KH , ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_ALLOCATED,0) AS SL_ALLOCATED , dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_TT AS SO_LUONG_THUC_XUAT, 
                     dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.DON_GIA,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.NGOAI_TE,
                     dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA, 
                     dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA_USD
FROM         dbo.IC_PHU_TUNG INNER JOIN                      
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON 
                     dbo.IC_PHU_TUNG.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT 
	INNER JOIN dbo.LOAI_VT ON  dbo.LOAI_VT.MS_LOAI_VT = dbo.IC_PHU_TUNG.MS_LOAI_VT
where  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI and  dbo.LOAI_VT.VAT_TU = 1 AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT NOT IN 
(
	SELECT     dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT
	FROM         dbo.IC_DON_HANG_XUAT INNER JOIN
                      dbo.IC_DON_HANG_XUAT_VAT_TU ON dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT
	WHERE dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI
)

--SELECT * FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG