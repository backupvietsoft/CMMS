
CREATE PROC dbo.[INTEGRATION_DELETE_XUAT_VT_PT_FOR_PBT]
	@MS_PHIEU_BT NVARCHAR(30)
AS 

--DECLARE @MS_PHIEU_BT NVARCHAR(30)
--SET @MS_PHIEU_BT = 'WO-201401000001'


DECLARE @TBDATA AS TABLE (
		   MS_DH_XUAT_PT nvarchar(30),
           MS_DH_NHAP_PT nvarchar(30)
)

INSERT INTO  @TBDATA
SELECT DISTINCT DHXCT.MS_DH_XUAT_PT, DHXCT.MS_DH_NHAP_PT
FROM dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS DHXCT INNER JOIN
dbo.IC_DON_HANG_XUAT AS DHX ON DHXCT.MS_DH_XUAT_PT = DHX.MS_DH_XUAT_PT
WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BT

--SELECT * FROM @TBDATA

DELETE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_DH_NHAP_PT IN (SELECT MS_DH_NHAP_PT FROM @TBDATA) OR MS_DH_XUAT_PT IN (SELECT MS_DH_XUAT_PT FROM @TBDATA)

DELETE FROM VI_TRI_KHO_VAT_TU WHERE MS_DH_NHAP_PT IN (SELECT MS_DH_NHAP_PT FROM @TBDATA)

DELETE FROM IC_DON_HANG_XUAT_VAT_TU_CHI_TIET WHERE MS_DH_XUAT_PT IN (SELECT MS_DH_XUAT_PT FROM @TBDATA)
DELETE FROM IC_DON_HANG_XUAT_VAT_TU WHERE MS_DH_XUAT_PT IN (SELECT MS_DH_XUAT_PT FROM @TBDATA)
DELETE FROM IC_DON_HANG_XUAT WHERE MS_DH_XUAT_PT IN (SELECT MS_DH_XUAT_PT FROM @TBDATA)


DELETE FROM IC_DON_HANG_NHAP_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT IN (SELECT MS_DH_NHAP_PT FROM @TBDATA)
DELETE FROM IC_DON_HANG_NHAP_VAT_TU WHERE MS_DH_NHAP_PT IN (SELECT MS_DH_NHAP_PT FROM @TBDATA)
DELETE FROM IC_DON_HANG_NHAP WHERE MS_DH_NHAP_PT IN (SELECT MS_DH_NHAP_PT FROM @TBDATA)



 
 



 
