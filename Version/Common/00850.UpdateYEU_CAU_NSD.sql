

ALTER procedure [dbo].[UpdateYEU_CAU_NSD] 
	@STT INTEGER,
	@NGAY NVARCHAR(10),
	@GIO_YEU_CAU NVARCHAR(8),
	@NGUOI_YEU_CAU NVARCHAR(50),
	@NGAY_HOAN_THANH_TMP NVARCHAR(10),
	@USER_COMMENT NVARCHAR(MAX),
	@DA_KIEM_TRA	BIT,
	@USERNAME	NVARCHAR(50),
	@REVIEWER_COMMENT	NVARCHAR(255),
	@USER_LAP NVARCHAR(30),
	@EMAIL_NSD NVARCHAR(100),
	@SO_YEU_CAU NVARCHAR(250)
AS

DECLARE @NGAY_HOAN_THANH DATETIME

IF @NGAY_HOAN_THANH_TMP='  /  /'
	SET @NGAY_HOAN_THANH=NULL
ELSE
	SET @NGAY_HOAN_THANH=CONVERT(DATETIME,@NGAY_HOAN_THANH_TMP,103)
DECLARE @GIO_TMP AS DATETIME
IF @GIO_YEU_CAU='  :'
	SET @GIO_TMP=NULL
ELSE
	SET @GIO_TMP=CONVERT(DATETIME,@GIO_YEU_CAU,114)
UPDATE YEU_CAU_NSD SET
	NGAY=CONVERT(DATETIME,@NGAY,103),
	GIO_YEU_CAU=@GIO_TMP,
	NGUOI_YEU_CAU=@NGUOI_YEU_CAU,
	NGAY_HOAN_THANH=@NGAY_HOAN_THANH,
	USER_COMMENT=@USER_COMMENT,
	DA_KIEM_TRA=@DA_KIEM_TRA,
	USERNAME=@USERNAME,
	REVIEWER_COMMENT=@REVIEWER_COMMENT,
	USER_LAP = @USER_LAP,
	EMAIL_NSD = @EMAIL_NSD,
	SO_YEU_CAU = @SO_YEU_CAU
WHERE STT=@STT

