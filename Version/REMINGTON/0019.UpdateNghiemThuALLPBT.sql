
ALTER proc [dbo].[UpdateNghiemThuALLPBT]
	@TT_SAU_BT NVARCHAR(200),
	@NGUOI_NGHIEM_THU NVARCHAR(50),
	@NGAY_NGHIEM_THU DATETIME,
	@USERNAME_NGUOI_NT NVARCHAR(50),
	@CHI_PHI_KHAC FLOAT
AS
SELECT * INTO #PBT_TT_NT FROM PBT_TT_NT WHERE CHON = 1
drop table PBT_TT_NT


DECLARE @MS_TT_CT INT
SET @MS_TT_CT = NULL
SELECT TOP 1 @MS_TT_CT = MS_TT_CT FROM TINH_TRANG_PBT_CT WHERE STT = 4 AND MAC_DINH = 1

UPDATE PHIEU_BAO_TRI SET 
	TINH_TRANG_PBT = 4, 
	MS_TT_CT = @MS_TT_CT,
	TT_SAU_BT = @TT_SAU_BT,
	NGUOI_NGHIEM_THU = @NGUOI_NGHIEM_THU ,
	NGAY_NGHIEM_THU = @NGAY_NGHIEM_THU,
	USERNAME_NGUOI_NT = @USERNAME_NGUOI_NT
FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM #PBT_TT_NT )

SELECT A.MS_PHIEU_BAO_TRI, MAX(A.DEN_NGAY) AS NGAY_NGHIEM_THU 
INTO #BTNT
FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET A
WHERE A.MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CHI_PHI )
GROUP BY A.MS_PHIEU_BAO_TRI

UPDATE A
SET A.NGAY_NGHIEM_THU = B.NGAY_NGHIEM_THU
FROM dbo.PHIEU_BAO_TRI A
INNER JOIN #BTNT B ON B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI

INSERT INTO PHIEU_BAO_TRI_CHI_PHI(MS_PHIEU_BAO_TRI,CHI_PHI_KHAC)
	SELECT MS_PHIEU_BAO_TRI,@CHI_PHI_KHAC FROM #PBT_TT_NT A 
	WHERE MS_PHIEU_BAO_TRI NOT IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CHI_PHI)

	UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC = @CHI_PHI_KHAC WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM #PBT_TT_NT)



	UPDATE A
	SET A.NGAY_HOAN_THANH = B.NGAY_NGHIEM_THU
	FROM dbo.PHIEU_BAO_TRI_CONG_VIEC  A
	INNER JOIN #BTNT B ON B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI
	WHERE A.MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM #PBT_TT_NT ) AND (ISNULL(NGAY_HOAN_THANH,'') = '')


UPDATE PHIEU_BAO_TRI_CONG_VIEC SET H_THANH = 1 
	WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM #PBT_TT_NT ) AND (ISNULL(H_THANH,0) = 0)
            
UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=@NGAY_NGHIEM_THU  
	WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM #PBT_TT_NT ) AND (ISNULL(NGAY_HOAN_THANH,'') = '')
	
UPDATE PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  #PBT_TT_NT)

UPDATE [PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET] SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  #PBT_TT_NT)

UPDATE PHIEU_BAO_TRI_NHAN_SU SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  #PBT_TT_NT)

        
INSERT INTO PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET (MS_PHIEU_BAO_TRI,STT,MS_TT_CT,THOI_GIAN,USERNAME)
SELECT A.MS_PHIEU_BAO_TRI,
CONVERT(INT,(SELECT ISNULL(MAX(STT),0)+ 1 FROM PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET C WHERE C.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI)) AS STT,
B.MS_TT_CT,@NGAY_NGHIEM_THU, USERNAME_NGUOI_LAP
FROM PHIEU_BAO_TRI A INNER JOIN 
(SELECT * FROM TINH_TRANG_PBT_CT WHERE STT = 4 AND MAC_DINH = 1) B ON A.TINH_TRANG_PBT = B.STT
WHERE A.MS_PHIEU_BAO_TRI IN (SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  #PBT_TT_NT)
GO
