
--EXEC GetTHOI_GIAN_NGUNG_MAY_SO_LAN 'ADMIN','','-1','-1','-1','-1','10/27/2015','06/27/2016',0
ALTER procedure [dbo].[GetTHOI_GIAN_NGUNG_MAY_SO_LAN]
	@USERNAME NVARCHAR(50),
	@MS_MAY NVARCHAR(30),
	@LOAI_MAY NVARCHAR(30),
	@MS_HETHONG NVARCHAR(30),
	@MS_NHA_XUONG NVARCHAR(30),
	@MS_NGUYENNHAN NVARCHAR(30),
	@TU_NGAY Datetime,
	@DEN_NGAY Datetime,
	@LockTGNM bit
 AS

BEGIN

if @MS_MAY = ''
	set @MS_MAY = '-1'
if @TU_NGAY is null OR  @TU_NGAY  = '' set @TU_NGAY = DATEADD (YEAR,-1,GETDATE())
if @DEN_NGAY is null OR  @DEN_NGAY  = '' set @DEN_NGAY = DATEADD (YEAR,1,GETDATE())

SELECT DISTINCT * INTO #MAY_USER FROM dbo.MGetMayUserNgay(@DEN_NGAY,@USERNAME,@MS_NHA_XUONG,@MS_HETHONG,-1,-1,'-1',@MS_MAY,0)  A 
	


SELECT DISTINCT 
                      X.MS_MAY, X.MS_LAN, X.NGAY, X.TU_GIO, X.NGUOI_GIAI_QUYET, X.NGUYEN_NHAN AS NN_CGQ, A.MS_NGUYEN_NHAN, A.MS_PHIEU_BAO_TRI, X.HIEN_TUONG, X.NGUYEN_NHAN_CU_THE, 
                      X.NGAY_KT, X.GIO_KT, (SELECT TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY T1 WHERE A.MS_NGUYEN_NHAN = T1.MS_NGUYEN_NHAN) AS TEN_NGUYEN_NHAN
                      , X.NGAY_SX, MS_LOAI_MAY
FROM         #MAY_USER AS B INNER JOIN
                      dbo.THOI_GIAN_NGUNG_MAY_SO_LAN AS X ON B.MS_MAY = X.MS_MAY LEFT OUTER JOIN
                      dbo.THOI_GIAN_NGUNG_MAY AS A ON X.MS_LAN = A.MS_LAN
WHERE     (X.NGAY BETWEEN @TU_NGAY AND @DEN_NGAY) 
AND (A.MS_NGUYEN_NHAN = @MS_NGUYENNHAN OR @MS_NGUYENNHAN  = '-1') 
AND (ISNULL(A.LOCK,0) = @LockTGNM)                      
ORDER BY X.MS_MAY, X.MS_LAN, X.NGAY DESC, X.TU_GIO, X.NGUOI_GIAI_QUYET

END


