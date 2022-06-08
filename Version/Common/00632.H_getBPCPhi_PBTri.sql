

ALTER procedure [dbo].[H_getBPCPhi_PBTri] 
@MS_PHIEU_BT NVARCHAR(30)
AS

DECLARE @MsMay NVARCHAR(100)
SELECT @MsMay = MS_MAY FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BT

SELECT TOP 1 C.TEN_BP_CHIU_PHI,@MS_PHIEU_BT AS MS_PHIEU_BAO_TRI , A.MS_BP_CHIU_PHI  FROM MAY_BO_PHAN_CHIU_PHI A INNER JOIN  (
	SELECT MS_MAY, MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY = @MsMay GROUP BY MS_MAY) B ON   A.MS_MAY = B.MS_MAY AND A.NGAY_NHAP = B.NGAY_MAX 
INNER JOIN BO_PHAN_CHIU_PHI C ON A.MS_BP_CHIU_PHI = C.MS_BP_CHIU_PHI	
	WHERE A.MS_MAY = @MsMay

--SELECT DISTINCT dbo.BO_PHAN_CHIU_PHI.TEN_BP_CHIU_PHI, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI
--FROM         dbo.MAY INNER JOIN
--                      dbo.MAY_BO_PHAN_CHIU_PHI ON dbo.MAY.MS_MAY = dbo.MAY_BO_PHAN_CHIU_PHI.MS_MAY INNER JOIN
--                      dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN
--                      dbo.BO_PHAN_CHIU_PHI ON dbo.MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI = dbo.BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI
--WHERE   dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = @MS_PHIEU_BT



