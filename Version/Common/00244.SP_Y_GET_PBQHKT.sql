
--EXEC [SP_Y_GET_PBQHKT] 'ADMIN',0,'-1','-1','-1','-1','-1','-1','-1'
ALTER procedure [dbo].[SP_Y_GET_PBQHKT]
@USERNAME NVARCHAR (64), 
@LANGUAGE INT,
@MS_NHA_XUONG NVARCHAR (50), 
@MS_HE_THONG INT ,
@MS_LOAI_MAY NVARCHAR(30),
@MS_MAY NVARCHAR (30),
@MS_TINH NVARCHAR(100),
@MS_QUAN NVARCHAR(100),
@MS_DUONG NVARCHAR(100)
AS
DECLARE @DENNGAY DATETIME
SET @DENNGAY = GETDATE()

SELECT * INTO #MAY FROM dbo.MGetMayUserNgay(@DENNGAY, @USERNAME, @MS_NHA_XUONG, @MS_HE_THONG, -1, @MS_LOAI_MAY, '-1',@MS_MAY, @LANGUAGE)

SELECT dbo.Get_Street(MS_DUONG) AS TEN_DUONG, dbo.Get_Distrct(MS_QG)  AS TEN_TP, 
		ISNULL(dbo.Get_City([dbo].[Get_CityCode](MS_QG)),'') AS TEN_QG ,
		[dbo].[Get_CityCode](A.MS_QG) AS MS_TINH,A.MS_QG AS MS_QUAN, A.* 
INTO #NXUONG		
FROM NHA_XUONG A 		



SELECT TEMP.MS_PHIEU_BAO_TRI,TEMP.MS_MAY,TEMP.TEN_MAY,TEMP.TEN_LOAI_BT,
       CONVERT(NVARCHAR(10),TEMP.NGAY_BD_KH,103)NGAY_BD_KH,CONVERT(NVARCHAR(10),TEMP.NGAY_KT_KH,103)NGAY_KT_KH,TEMP.TEN_N_XUONG
FROM
(
SELECT DISTINCT T2.MS_PHIEU_BAO_TRI, T2.MS_MAY, T1.TEN_MAY, T3.TEN_LOAI_BT, T2.NGAY_BD_KH, T2.NGAY_KT_KH, T1.Ten_N_XUONG
FROM         #MAY AS T1 INNER JOIN
                      dbo.PHIEU_BAO_TRI AS T2 ON T1.MS_MAY = T2.MS_MAY INNER JOIN
                      dbo.LOAI_BAO_TRI AS T3 ON T2.MS_LOAI_BT = T3.MS_LOAI_BT INNER JOIN #NXUONG T4 ON T1.MS_N_XUONG = T4.MS_N_XUONG
WHERE T2.TINH_TRANG_PBT = 2 AND T2.NGAY_KT_KH < CONVERT(NVARCHAR (10),@DENNGAY,102) 

AND (@MS_TINH = '-1' OR T4.MS_TINH = @MS_TINH )
AND (@MS_QUAN = '-1' OR T4.MS_QUAN = @MS_QUAN )
AND (@MS_DUONG = '-1' OR T4.MS_DUONG = @MS_DUONG ) 

) TEMP




