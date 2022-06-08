


ALTER PROC [dbo].[spKiemNgiemThu]
	@PBT NVARCHAR(100) = 'WO-201306000003'
AS
DECLARE @PBT_THEO_GIO NVARCHAR(100) = 1
DECLARE @CTY NVARCHAR(100) = 'VIETSOFT'
DECLARE @iCoDV INT = 0


--NUTIFOOD KIEM NEU LA BAO TRI DINH KY THI KHONG KIEM NHAP NHAN VIEN
SELECT TOP 1 @CTY = ISNULL([PRIVATE],'VIETSOFT') FROM dbo.THONG_TIN_CHUNG
SELECT @CTY
	--0 : Nhập từ ngày, đến ngày, từ giờ đến giờ , tính ra số giờ và lock cột số giờ.
	--1 : Nhập từ ngày, đến ngày, từ giờ đến giờ , tính ra số giờ, nhưng có thể chỉnh sửa số giờ. 
	--2 : Nhập Từ ngày, từ giờ, Đến ngày đến giờ và nhập cả số giờ độc lập. Trong trường hợp này, đến giờ - từ giờ <> số giờ. Lúc này không bắt buộc nhập từ ngày đến ngày.
IF EXISTS(SELECT T1.MS_PHIEU_BAO_TRI, T3.MS_HT_BT, T3.TEN_HT_BT, T3.PHONG_NGUA FROM dbo.PHIEU_BAO_TRI T1 INNER JOIN dbo.LOAI_BAO_TRI T2 ON T2.MS_LOAI_BT = T1.MS_LOAI_BT INNER JOIN dbo.HINH_THUC_BAO_TRI T3 ON T3.MS_HT_BT = T2.MS_HT_BT WHERE T3.PHONG_NGUA = 1 AND T1.MS_PHIEU_BAO_TRI = @PBT AND @CTY = 'NUTIFOOD') 
BEGIN
    SET @iCoDV = 1
	SELECT	@iCoDV
END
ELSE	
BEGIN
	-- Kiểm tra nếu chỉ có mỗi DV cho NT luôn @iCoDV = 1
	SELECT @iCoDV = SUM(LOAI)  FROM (
		SELECT TOP 1 MS_PHIEU_BAO_TRI,1 AS LOAI  FROM dbo.PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = @PBT AND ISNULL(STT_SERVICE,'') <> ''
		UNION
		SELECT TOP 1 MS_PHIEU_BAO_TRI,2 AS LOAI FROM dbo.PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = @PBT AND ISNULL(STT_SERVICE,'') = ''
	) T1



	SELECT TOP 1 CASE 
	WHEN @iCoDV > 1 THEN
	COUNT(*) 
	ELSE 1 END  FROM (
	SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_CONG_NHAN,SO_GIO FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET  WHERE MS_PHIEU_BAO_TRI = @PBT
	UNION
	SELECT MS_PHIEU_BAO_TRI,STT,NULL,MS_CONG_NHAN,SO_GIO FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = @PBT
	UNION
	SELECT MS_PHIEU_BAO_TRI,STT,NULL,MS_CONG_NHAN,SO_GIO FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = @PBT
	) T WHERE SO_GIO > 0
END

