CREATE PROC [dbo].[INTEGRATION_NHAP_KHO_SYN_UPDATE_TO_CMMS]

AS

--SELECT DISTINCT MS_DH_XUAT_PT, NGAY, MS_KHO, UPDATE_DATE
--FROM dbo.SYN_TB_XUAT_KHO_INTEGRATION 
--WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)
--ORDER BY UPDATE_DATE , MS_DH_XUAT_PT ,NGAY 


DECLARE @MS_DH_NHAP_PT_FOR NVARCHAR(50)
DECLARE @NGAY_FOR DATETIME 
DECLARE @MS_KHO_FOR NVARCHAR(50)
DECLARE @UPDATE_DATE_FOR DATETIME


DECLARE PXK_SYN CURSOR FOR 
	SELECT DISTINCT MS_DH_NHAP_PT, NGAY, MS_KHO, UPDATE_DATE
	FROM dbo.SYN_TB_NHAP_KHO_INTEGRATION 
	WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)
	ORDER BY UPDATE_DATE , MS_DH_NHAP_PT ,NGAY  
	
OPEN PXK_SYN
FETCH NEXT FROM PXK_SYN 
INTO @MS_DH_NHAP_PT_FOR, @NGAY_FOR,@MS_KHO_FOR,@UPDATE_DATE_FOR
WHILE @@FETCH_STATUS = 0
BEGIN

	--SELECT * FROM dbo.SYN_TB_XUAT_KHO_INTEGRATION  
	--WHERE 	MS_DH_XUAT_PT = @MS_DH_XUAT_PT_FOR AND NGAY = @NGAY_FOR AND MS_KHO= @MS_KHO_FOR AND UPDATE_DATE = @UPDATE_DATE_FOR
	DECLARE @MS_KHO_CMMS INT
	SELECT @MS_KHO_CMMS = MS_KHO  FROM IC_KHO WHERE MS_KHO_INT = ISNULL(@MS_KHO_FOR,0)
	-- XOA PHIEU XUAT CU DI
	DELETE dbo.SYN_TB_NHAP_KHO_CMMS 
	WHERE 	MS_DH_NHAP_PT = @MS_DH_NHAP_PT_FOR AND NGAY = @NGAY_FOR AND MS_KHO= @MS_KHO_CMMS AND UPDATE_DATE = @UPDATE_DATE_FOR
	
	-- CAP NHAT PHIEU XUAT MOI
	
	INSERT INTO dbo.SYN_TB_NHAP_KHO_CMMS (MS_DH_NHAP_PT, SO_PHIEU_XN, GIO, ROW_ID, NGAY, MS_KHO, MS_VI_TRI, MS_PT, SO_LUONG_CTU, SL_THUC_NHAP, DON_GIA, THANH_TIEN, MS_DANG_NHAP, DANG_NHAP_VIET, 
                      NGUOI_NHAP, NGAY_CHUNG_TU, SO_CHUNG_TU, GHI_CHU, THU_KHO, MS_DDH, SO_DE_XUAT, NGUOI_GIAO, LY_DO, CAN_CU, THU_KHO_KY, NGUOI_LAP, BAO_HANH_DEN_NGAY, XUAT_XU, 
                      TAX, MS_KH, TEN_VI_TRI_1, TEN_VI_TRI_2, TEN_VI_TRI_3, INSERT_DATE, UPDATE_DATE, DA_CHUYEN, NGAY_CHUYEN)
	SELECT MS_DH_NHAP_PT, SO_PHIEU_XN, GIO, ROW_ID, NGAY, @MS_KHO_CMMS, MS_VI_TRI, MS_PT, SO_LUONG_CTU, SL_THUC_NHAP, DON_GIA, THANH_TIEN, MS_DANG_NHAP, DANG_NHAP_VIET, 
                      NGUOI_NHAP, NGAY_CHUNG_TU, SO_CHUNG_TU, GHI_CHU, THU_KHO, MS_DDH, SO_DE_XUAT, NGUOI_GIAO, LY_DO, CAN_CU, THU_KHO_KY, NGUOI_LAP, BAO_HANH_DEN_NGAY, XUAT_XU, 
                      TAX, MS_KH, TEN_VI_TRI_1, TEN_VI_TRI_2, TEN_VI_TRI_3, INSERT_DATE, UPDATE_DATE, DA_CHUYEN, NGAY_CHUYEN
	FROM dbo.SYN_TB_NHAP_KHO_INTEGRATION  
	WHERE 	MS_DH_NHAP_PT = @MS_DH_NHAP_PT_FOR AND NGAY = @NGAY_FOR AND MS_KHO= @MS_KHO_FOR AND UPDATE_DATE = @UPDATE_DATE_FOR

	-- UPDATE TRANG THAI DA CHUYEN
	
	UPDATE dbo.SYN_TB_NHAP_KHO_INTEGRATION SET DA_CHUYEN = CONVERT(BIT,1)
	WHERE 	MS_DH_NHAP_PT = @MS_DH_NHAP_PT_FOR AND NGAY = @NGAY_FOR AND MS_KHO= @MS_KHO_FOR AND UPDATE_DATE = @UPDATE_DATE_FOR
	

	FETCH NEXT FROM PXK_SYN 
	INTO @MS_DH_NHAP_PT_FOR, @NGAY_FOR,@MS_KHO_FOR,@UPDATE_DATE_FOR
END 
CLOSE PXK_SYN;
DEALLOCATE PXK_SYN;