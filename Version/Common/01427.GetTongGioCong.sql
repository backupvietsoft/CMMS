

--EXEC GetTongGioCong 'WO-201807000510',1


ALTER procedure [dbo].[GetTongGioCong]
	@MS_PHIEU_BAO_TRI NVARCHAR(50),
	@TINH_TRANG_PBT INT
AS
--PHUT_GIO_PBT: Định nghĩa đơn ví tính là giờ hay phút (0 - dùng giờ, 1 dùng phút )
-- QUY HET VE PHUT 
DECLARE @PBTTHOIGIO INT
SELECT @PBTTHOIGIO = PHUT_GIO_PBT FROM THONG_TIN_CHUNG

IF @PBTTHOIGIO = 1  
BEGIN
SELECT SUM(SO_GIO) AS SO_GIO FROM
	(SELECT ISNULL(SUM(SO_GIO),0) AS SO_GIO  ,1 AS CVC FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET
		WHERE MS_PHIEU_BAO_TRI=@MS_PHIEU_BAO_TRI
	UNION
	SELECT ISNULL(SUM(SO_GIO),0) AS SO_GIO  ,2 AS CVC FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO
		WHERE MS_PHIEU_BAO_TRI=@MS_PHIEU_BAO_TRI
	UNION
	SELECT ISNULL(SUM(SO_GIO),0) AS SO_GIO  ,3 AS CVC FROM PHIEU_BAO_TRI_NHAN_SU
		WHERE MS_PHIEU_BAO_TRI=@MS_PHIEU_BAO_TRI
	) A

END 
ELSE
BEGIN
SELECT SUM(SO_GIO) AS SO_GIO FROM
	(SELECT ISNULL(SUM(SO_GIO),0) * 60  AS SO_GIO ,1 AS CVC FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET
		WHERE MS_PHIEU_BAO_TRI=@MS_PHIEU_BAO_TRI
	UNION
	SELECT ISNULL(SUM(SO_GIO),0) * 60 AS SO_GIO ,2 AS CVC  FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO
		WHERE MS_PHIEU_BAO_TRI=@MS_PHIEU_BAO_TRI
	UNION
	SELECT ISNULL(SUM(SO_GIO),0) * 60 AS SO_GIO ,3 AS CVC  FROM PHIEU_BAO_TRI_NHAN_SU
		WHERE MS_PHIEU_BAO_TRI=@MS_PHIEU_BAO_TRI		
	) A
END  


