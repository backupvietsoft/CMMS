
-- exec S_PHIEU_BAO_TRI 'administrator' , '03/05/2014','03/05/2014',0, '-1', '-1', '-1', '-1', '-1', '-1', '-1', -1,-1
ALTER PROC [dbo].[S_PHIEU_BAO_TRI]
	@USERNAME NVARCHAR(50),
	@TUNGAY NVARCHAR(10),
	@DENNGAY NVARCHAR(10),
	@NGHIEMTHU int,
	@LOAY_MAY NVARCHAR(200),
    @NHOM_MAY NVARCHAR(100),	
	@MS_MAY NVARCHAR(100),
	@MS_NHA_XUONG NVARCHAR(50),
	@MS_TINH NVARCHAR(100),
	@MS_QUAN NVARCHAR(100),
	@MS_DUONG NVARCHAR(100), 
	@MsHThong as int,
	@LoaiBT as int
AS
--@NGHIEMTHU = 0 chua ngiem thu TINH_TRANG_PBT  <3
--@NGHIEMTHU = 1 hoan thanh TINH_TRANG_PBT = 3
--@NGHIEMTHU = 2 ngiem thu TINH_TRANG_PBT > 3 34


SELECT * INTO #MAY FROM dbo.MGetMayUserNgay(@DENNGAY, @USERNAME, @MS_NHA_XUONG, @MsHThong, -1, @LOAY_MAY, @NHOM_MAY,@MS_MAY, 0)

SELECT dbo.Get_Street(MS_DUONG) AS TEN_DUONG, dbo.Get_Distrct(MS_QG)  AS TEN_TP, 
		ISNULL(dbo.Get_City([dbo].[Get_CityCode](MS_QG)),'') AS TEN_QG ,
		[dbo].[Get_CityCode](A.MS_QG) AS MS_TINH,A.MS_QG AS MS_QUAN, A.* INTO #NXUONG FROM NHA_XUONG A 
		

			
SELECT * INTO #PBT FROM dbo.PHIEU_BAO_TRI		
WHERE  CONVERT(DATETIME, CONVERT(NVARCHAR(10),NGAY_BD_KH,101)) BETWEEN CONVERT(DATETIME,CONVERT(NVARCHAR(10),@TUNGAY ,101)) AND CONVERT(DATETIME,@DENNGAY ,101)
				AND  ( ((@NGHIEMTHU = 0) AND TINH_TRANG_PBT < 3)  OR  ( (@NGHIEMTHU = 1) AND TINH_TRANG_PBT = 3 ) 
				OR  ( (@NGHIEMTHU = 2) AND TINH_TRANG_PBT > 3 ) )
				AND (@LoaiBT = '-1' OR MS_LOAI_BT = @LoaiBT)
						
SELECT (ISNULL(T3.DIA_CHI,'') +  ' ' + ISNULL(TEN_DUONG,'') + ' ' + ISNULL(TEN_TP,'')  + ' ' +  
	ISNULL(TEN_QG,'')) AS DIA_CHI1,MS_TINH,T3.MS_QG AS MS_QUAN,T3.MS_DUONG,T3.DIA_CHI,
 	
	T1.MS_HE_THONG AS MS_HT, T1.MS_LOAI_MAY, T1.MS_NHOM_MAY, T2.MS_PHIEU_BAO_TRI, T2.SO_PHIEU_BAO_TRI, T1.MS_MAY,	
 TEN_MAY, TINH_TRANG_PBT, TEN_TINH_TRANG, T2.MS_LOAI_BT, TEN_LOAI_BT, LY_DO_BT, NGAY_LAP, T1.Ten_N_XUONG AS TEN_N_XUONG , 
 T1.MS_N_XUONG, GIO_LAP, T2.MS_UU_TIEN, TEN_UU_TIEN, NGUOI_LAP, USERNAME_NGUOI_LAP, HO + ' ' + TEN AS HO_TEN, 
                      NGUOI_GIAM_SAT, NGAY_BD_KH, NGAY_KT_KH, GIO_HONG, NGAY_HONG, MS_NGUYEN_NHAN, DEN_GIO_HONG, DEN_NGAY_HONG,DHX 
                      --CONVERT(NVARCHAR(500),dbo.GetDHXTheoPBT(MS_PHIEU_BAO_TRI)) AS DHX 
FROM #MAY AS T1 INNER JOIN
	#PBT AS T2 ON T1.MS_MAY = T2.MS_MAY INNER JOIN
	#NXUONG AS T3 ON T1.MS_N_XUONG = T3.MS_N_XUONG INNER JOIN  
	TINH_TRANG_PBT T4 ON T2.TINH_TRANG_PBT = T4.STT LEFT JOIN      
	MUC_UU_TIEN T5 ON T2.MS_UU_TIEN = T5.MS_UU_TIEN INNER JOIN  
	LOAI_BAO_TRI T6 ON T2.MS_LOAI_BT = T6.MS_LOAI_BT INNER JOIN  
	CONG_NHAN T7 ON T2.NGUOI_LAP =    T7.MS_CONG_NHAN
WHERE (@MS_TINH = '-1' OR T3.MS_TINH = @MS_TINH )
AND (@MS_QUAN = '-1' OR T3.MS_QUAN = @MS_QUAN )
AND (@MS_DUONG = '-1' OR T3.MS_DUONG = @MS_DUONG ) 


