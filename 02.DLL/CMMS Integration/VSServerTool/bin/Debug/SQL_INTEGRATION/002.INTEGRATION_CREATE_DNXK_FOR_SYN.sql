CREATE PROC dbo.[INTEGRATION_CREATE_DNXK_FOR_SYN]
	@MS_PHIEU_BAO_TRI NVARCHAR(50)
AS

--DECLARE @MS_PHIEU_BAO_TRI NVARCHAR(50)
--SET @MS_PHIEU_BAO_TRI = 'WO-201312000002'

DECLARE @MS_KHO NVARCHAR(100)
DECLARE @MASOPB NVARCHAR(100)
DECLARE @TENPB NVARCHAR(100)
DECLARE @MALYDOXUAT NVARCHAR(100)
DECLARE @INSERT_DATE DATETIME

SET @INSERT_DATE  = GETDATE()

SELECT  @MS_KHO AS MAKHO, T1.MS_PHIEU_BAO_TRI AS MASOYC, @MASOPB AS MASOPB, @TENPB AS TENPB, T1.GIO_LAP, T1.NGAY_LAP, T3.HO + ' ' + T3.TEN AS TENNVYC, T1.LY_DO_BT AS NOIDUNG, 
                      T2.MS_PT AS MAVT, T1.MS_MAY AS MAHANGMUC, @MALYDOXUAT AS MALYDOXUAT, SUM(ISNULL(T2.SL_KH,0)) AS SOLUONG, @INSERT_DATE AS INSERT_DATE
FROM         dbo.PHIEU_BAO_TRI AS T1 INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS T2 ON T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI INNER JOIN
                      dbo.CONG_NHAN AS T3 ON T1.NGUOI_LAP = T3.MS_CONG_NHAN
WHERE T1.TINH_TRANG_PBT = 2 AND T1.MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI
GROUP BY T1.MS_PHIEU_BAO_TRI , T1.GIO_LAP, T1.NGAY_LAP, T3.HO, T1.LY_DO_BT ,T2.MS_PT,T3.TEN ,T2.MS_PT,T1.MS_MAY