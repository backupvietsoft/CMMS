
CREATE PROC dbo.[INTEGRATION_GET_DATA_TO_CHECK_ALLOCATED_VTPT_PBT]
@MS_PHIEU_BT NVARCHAR(30)
AS 
--DECLARE @MS_PHIEU_BT NVARCHAR(30)
--SET @MS_PHIEU_BT = 'WO-201401000001'

SELECT MS_DH_XUAT_SYN AS MS_DH_XUAT_PT , MS_DH_NHAP_SYN AS MS_DH_NHAP_PT , ROW_ID_NHAP_SYN AS ROW_ID_NHAP,
ROW_ID_XUAT_SYN AS ROW_ID_XUAT , MS_PT , SUM(ISNULL(SL_VT,0)) AS SL_VT
FROM IC_DON_HANG_XUAT_VAT_TU_CHI_TIET WHERE MS_PHIEU_BT = @MS_PHIEU_BT
GROUP BY MS_DH_XUAT_SYN , MS_DH_NHAP_SYN  , ROW_ID_NHAP_SYN ,ROW_ID_XUAT_SYN  , MS_PT

