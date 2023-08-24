--exec UpdateLockALLPBT
ALTER PROC [dbo].[UpdateLockALLPBT]
AS

SELECT DISTINCT MS_PHIEU_BAO_TRI INTO #PBT FROM PBT_TT_LOCK WHERE (CHON = 1)

SELECT DISTINCT MS_MAY ,MS_LOAI_BT ,ISNULL(MAX(B.DEN_NGAY),MAX(NGAY_BD_KH)) AS NGAY_BD_KH INTO #MAY_LBT 
FROM PBT_TT_LOCK  A 
LEFT JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
WHERE (MS_HT_BT = 1) GROUP BY MS_MAY ,MS_LOAI_BT 
DROP TABLE PBT_TT_LOCK

DECLARE @MS_TT_CT INT
SET @MS_TT_CT = NULL
SELECT TOP 1 @MS_TT_CT = MS_TT_CT FROM TINH_TRANG_PBT_CT WHERE STT = 5 AND MAC_DINH = 1


UPDATE  PHIEU_BAO_TRI SET TINH_TRANG_PBT = 5, MS_TT_CT = @MS_TT_CT
WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  #PBT)


INSERT INTO MAY_LOAI_BTPN(MS_MAY ,MS_LOAI_BT ,NGAY_CUOI)
SELECT MS_MAY ,MS_LOAI_BT ,NGAY_BD_KH FROM #MAY_LBT  A 
WHERE (NOT EXISTS ( SELECT * FROM MAY_LOAI_BTPN B WHERE B.MS_MAY = A.MS_MAY AND B.MS_LOAI_BT = A.MS_LOAI_BT ))



UPDATE MAY_LOAI_BTPN SET NGAY_CUOI = NGAY_BD_KH FROM MAY_LOAI_BTPN A INNER JOIN 
(SELECT MS_MAY ,MS_LOAI_BT ,NGAY_BD_KH FROM #MAY_LBT) B ON 
B.MS_MAY = A.MS_MAY AND B.MS_LOAI_BT = A.MS_LOAI_BT



INSERT INTO PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET (MS_PHIEU_BAO_TRI,STT,MS_TT_CT,THOI_GIAN,USERNAME)
SELECT A.MS_PHIEU_BAO_TRI,
CONVERT(INT,(SELECT ISNULL(MAX(STT),0)+ 1 FROM PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET C WHERE C.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI)) AS STT,
B.MS_TT_CT,GETDATE(), USERNAME_NGUOI_LAP
FROM PHIEU_BAO_TRI A INNER JOIN 
(SELECT * FROM TINH_TRANG_PBT_CT WHERE STT = 5 AND MAC_DINH = 1) B ON A.TINH_TRANG_PBT = B.STT
WHERE A.MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  #PBT)


GO
