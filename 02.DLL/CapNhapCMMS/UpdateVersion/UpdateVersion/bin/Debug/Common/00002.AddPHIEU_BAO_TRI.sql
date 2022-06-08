IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddPHIEU_BAO_TRI')
   exec('CREATE PROCEDURE [dbo].[AddPHIEU_BAO_TRI] AS BEGIN SET NOCOUNT ON; END')
GO


ALTER proc [dbo].[AddPHIEU_BAO_TRI]
	@MS_PHIEU_BAO_TRI NVARCHAR(20),
	@MS_MAY NVARCHAR(30),
	@MS_LOAI_BT INT,
	@NGAY_LAP DATETIME,
	@GIO_LAP DATETIME,
	@LY_DO_BT NVARCHAR(100),
	@TINH_TRANG_PBT INT,
	@NGAY_BTPN DATETIME,
	@NGUOI_LAP NVARCHAR(50),
	@USERNAME_NGUOI_LAP NVARCHAR(50),
	@NGAY_BD_KH DATETIME,
	@NGAY_KT_KH DATETIME,
	@NGUOI_GS NVARCHAR(50),
	@MS_UU_TIEN INT
AS

IF @NGUOI_GS = '-1' 
BEGIN
	SET @NGUOI_GS = NULL
END

INSERT INTO PHIEU_BAO_TRI(
	MS_PHIEU_BAO_TRI,	
	MS_MAY ,
	MS_LOAI_BT ,	
	NGAY_LAP ,
	GIO_LAP,
	LY_DO_BT,
	TINH_TRANG_PBT,
	NGAY_BTPN,
	NGUOI_LAP,
	USERNAME_NGUOI_LAP ,
	NGAY_BD_KH, 
	NGAY_KT_KH,
	MS_UU_TIEN,
	NGUOI_GIAM_SAT
)
values (
	@MS_PHIEU_BAO_TRI,	
	@MS_MAY ,
	@MS_LOAI_BT ,	
	@NGAY_LAP ,
	@GIO_LAP,
	@LY_DO_BT,
	@TINH_TRANG_PBT,
	@NGAY_BTPN,
	@NGUOI_LAP,
	@USERNAME_NGUOI_LAP,
	@NGAY_BD_KH,
	@NGAY_BD_KH,
	ISNULL(@MS_UU_TIEN,3),
	@NGUOI_GS
)

select SCOPE_IDENTITY()

