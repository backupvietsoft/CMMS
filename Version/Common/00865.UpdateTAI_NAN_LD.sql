
ALTER proc [dbo].[UpdateTAI_NAN_LD]
	@MS_CONG_NHAN nvarchar(9),
	@NGAY_TAI_NAN DATETIME,
	@GIO_tmp nvarchar(20),
	@NOI_XAY_RA nvarchar(255),
	@TINH_TRANG nvarchar(255),
	@NGUYEN_NHAN nvarchar(255),
	@GIAI_QUYET nvarchar(255),
	@NGAY_TN_TMP DATETIME
AS
DECLARE  @GIO datetime
IF @GIO_tmp ='' 
	SET @GIO=NULL
ELSE
	SET @GIO=CONVERT(DATETIME,@GIO_tmp,114)
UPDATE TAI_NAN_LD SET
	NGAY_TAI_NAN=@NGAY_TAI_NAN,
	GIO=@GIO,
	NOI_XAY_RA=@NOI_XAY_RA,
	TINH_TRANG=@TINH_TRANG,
	NGUYEN_NHAN=@NGUYEN_NHAN,
	GIAI_QUYET=@GIAI_QUYET	
WHERE
	MS_CONG_NHAN=@MS_CONG_NHAN AND CONVERT(nvarchar(10), NGAY_TAI_NAN, 103)=CONVERT(nvarchar(10), @NGAY_TN_TMP, 103)


