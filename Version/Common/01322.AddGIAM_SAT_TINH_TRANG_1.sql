


ALTER procedure [dbo].[AddGIAM_SAT_TINH_TRANG_1]
	@GIO_KT	NVARCHAR(10),
	@DEN_GIO NVARCHAR(10),
	@NGAY_KT NVARCHAR(10),
	@MS_CONG_NHAN NVARCHAR(9), 
	@GIO_CHAY_MAY NVARCHAR(9),
    @NHAN_XET NVARCHAR(255),
    @USERNAME NVARCHAR(255),
    @SO_PHIEU NVARCHAR(50),
    @HOAN_THANH INT,
    @NGAY_KT_GOC DATE 
AS
	DECLARE @GIO DATETIME
	DECLARE @NGAY DATETIME
	DECLARE @DENGIO DATETIME
	IF @GIO_KT='  :' 
		SET @GIO=NULL
	ELSE
		SET @GIO=CONVERT(DATETIME,@GIO_KT,114)
	IF @DEN_GIO='  :'
		SET @DENGIO=NULL
	ELSE
		SET @DENGIO=CONVERT(DATETIME,@DEN_GIO,114)
	IF @NGAY_KT='  /  /'
		set @NGAY=NULL
	ELSE
		SET @NGAY=CONVERT(DATETIME,@NGAY_KT,103)
	INSERT INTO GIAM_SAT_TINH_TRANG (GIO_KT,DEN_GIO,NGAY_KT,MS_CONG_NHAN,GIO_CHAY_MAY, NHAN_XET, USERNAME, SO_PHIEU, HOAN_THANH, NGAY_KT_GOC )
	VALUES ( @GIO,@DENGIO,@NGAY,@MS_CONG_NHAN, @GIO_CHAY_MAY, @NHAN_XET, @USERNAME, @SO_PHIEU, @HOAN_THANH, @NGAY_KT_GOC  )
	
	SELECT SCOPE_IDENTITY()
