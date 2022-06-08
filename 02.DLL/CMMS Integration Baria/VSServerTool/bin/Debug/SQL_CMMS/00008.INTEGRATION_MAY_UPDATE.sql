IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'INTEGRATION_MAY_UPDATE')
   exec('CREATE PROCEDURE [dbo].[INTEGRATION_MAY_UPDATE] AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROC [dbo].[INTEGRATION_MAY_UPDATE]	
	@MS_MAY nvarchar(50),
	@MS_MAY_CU nvarchar(50),
	@TEN_MAY nvarchar(255),
	@MS_NHOM_MAY nvarchar(20),
	@MS_KH varchar(20),
	@SO_THANG_KHAU_HAO int,
	@SERIAL_NUMBER nvarchar(50),
	@NGAY_DUA_VAO_SD datetime,
	@GIA_MUA float,
	@SO_CT nvarchar(30),
	@TI_GIA_VND float,
	@STATUS nvarchar(1)
AS

-- Kiem Nhom may khong co thi Insert moi (mac dinh loai may la order by ms_loai_may)
IF @MS_NHOM_MAY = ''
BEGIN
	IF NOT EXISTS (SELECT TOP 1 MS_NHOM_MAY FROM NHOM_MAY WHERE TEN_NHOM_MAY = N'Nhóm máy chưa xác định khi synchronize')
	BEGIN
		
		IF NOT EXISTS (SELECT TOP 1 MS_LOAI_MAY FROM LOAI_MAY WHERE TEN_LOAI_MAY = N'Loại máy chưa xác định khi synchronize')
		BEGIN
			-- Them loai may moi neu khong ton tai khong csdl voi ten mac dinh la N'LM_CXD',N'Loại máy chưa xác định khi synchronize'
			INSERT INTO LOAI_MAY(MS_LOAI_MAY,TEN_LOAI_MAY,STT_MAY)
			VALUES (N'LM_CXD',N'Loại máy chưa xác định khi synchronize',(SELECT ISNULL(MAX(STT_MAY),0) + 1 FROM LOAI_MAY))
			
			-- Insert vao nhom loai may
			IF NOT EXISTS (SELECT MS_LOAI_MAY FROM NHOM_LOAI_MAY WHERE MS_LOAI_MAY = N'LM_CXD' AND GROUP_ID = 1)
			BEGIN
				INSERT INTO NHOM_LOAI_MAY (MS_LOAI_MAY,GROUP_ID)
				VALUES (N'LM_CXD',1)
			END			
		END
		
		DECLARE @MSLMay NVARCHAR(20)
		SET @MSLMay = (SELECT TOP 1 MS_LOAI_MAY FROM LOAI_MAY WHERE TEN_LOAI_MAY = N'Loại máy chưa xác định khi synchronize')
		INSERT INTO NHOM_MAY (MS_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY)
		VALUES(@MSLMay,'NM_CXD', N'Nhóm máy chưa xác định khi synchronize')
	END
	SET @MS_NHOM_MAY = (SELECT TOP 1 MS_NHOM_MAY FROM NHOM_MAY WHERE TEN_NHOM_MAY = N'Nhóm máy chưa xác định khi synchronize')
END
ELSE
BEGIN
	IF NOT EXISTS (SELECT TOP 1 MS_NHOM_MAY FROM NHOM_MAY WHERE MS_NHOM_MAY = @MS_NHOM_MAY)
	BEGIN
		INSERT INTO NHOM_MAY (MS_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY)
		VALUES((SELECT TOP 1 MS_LOAI_MAY FROM LOAI_MAY	ORDER BY MS_LOAI_MAY) , @MS_NHOM_MAY, @MS_NHOM_MAY)
	END
END
-- Kiem Khach Hang khong co thi Insert moi
IF @MS_KH = ''
BEGIN
	SET @MS_KH = NULL
END
ELSE
BEGIN
	IF NOT EXISTS (SELECT TOP 1 MS_KH FROM KHACH_HANG WHERE MS_KH = @MS_KH)
BEGIN
		INSERT INTO KHACH_HANG(MS_KH, TEN_CONG_TY)
		VALUES( @MS_KH, N'Khách hàng chưa xác định khi synchronize')
END
END

IF @STATUS = 'N'
BEGIN
	IF EXISTS (SELECT TOP 1 MS_MAY FROM MAY WHERE MS_MAY = @MS_MAY)
	BEGIN
		UPDATE MAY SET TEN_MAY = @TEN_MAY,MS_NHOM_MAY = @MS_NHOM_MAY,MS_KH = @MS_KH,SO_NAM_KHAU_HAO = @SO_THANG_KHAU_HAO,SERIAL_NUMBER = @SERIAL_NUMBER,
				NGAY_DUA_VAO_SD = @NGAY_DUA_VAO_SD,GIA_MUA = @GIA_MUA,SO_CT = @SO_CT,TI_GIA_VND = @TI_GIA_VND
		WHERE MS_MAY = @MS_MAY 
	END
	ELSE
	BEGIN
		INSERT INTO [MAY]([MS_MAY],[TEN_MAY],[MS_NHOM_MAY],[MS_KH],[SO_NAM_KHAU_HAO],[SERIAL_NUMBER],[NGAY_DUA_VAO_SD],[GIA_MUA],[SO_CT],
			[TI_GIA_VND], MS_HIEN_TRANG,NGOAI_TE, USER_INSERT,NGAY_INSERT)
		VALUES(@MS_MAY,@TEN_MAY,@MS_NHOM_MAY,@MS_KH,@SO_THANG_KHAU_HAO,@SERIAL_NUMBER,@NGAY_DUA_VAO_SD,@GIA_MUA,@SO_CT,
			@TI_GIA_VND,2,'VND', 'Admin', GETDATE() )
		---- Insert vao may nha xuong
		--IF EXISTS (SELECT TOP 1 MS_MAY FROM MAY_NHA_XUONG WHERE MS_MAY = @MS_MAY)
		--BEGIN
		--	INSERT INTO MAY_NHA_XUONG(MS_MAY, MS_N_XUONG,NGAY_NHAP)
			
		--END
					
	END	
END

IF @STATUS = 'E'
BEGIN
	IF @MS_MAY = @MS_MAY_CU
	BEGIN
		UPDATE MAY SET TEN_MAY = @TEN_MAY,MS_NHOM_MAY = @MS_NHOM_MAY,MS_KH = @MS_KH,SO_NAM_KHAU_HAO = @SO_THANG_KHAU_HAO,SERIAL_NUMBER = @SERIAL_NUMBER,
				NGAY_DUA_VAO_SD = @NGAY_DUA_VAO_SD,GIA_MUA = @GIA_MUA,SO_CT = @SO_CT,TI_GIA_VND = @TI_GIA_VND
		WHERE MS_MAY = @MS_MAY 
	END
	ELSE
	BEGIN
		EXEC spCapNhapMsMay  @MS_MAY_CU, @MS_MAY
		
		UPDATE MAY SET TEN_MAY = @TEN_MAY,MS_NHOM_MAY = @MS_NHOM_MAY,MS_KH = @MS_KH,SO_NAM_KHAU_HAO = @SO_THANG_KHAU_HAO,SERIAL_NUMBER = @SERIAL_NUMBER,
				NGAY_DUA_VAO_SD = @NGAY_DUA_VAO_SD,GIA_MUA = @GIA_MUA,SO_CT = @SO_CT,TI_GIA_VND = @TI_GIA_VND
		WHERE MS_MAY = @MS_MAY 
	END	
END	

IF @STATUS = 'D'
BEGIN
	DELETE MAY WHERE MS_MAY = @MS_MAY 
END	







