IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spDownTimeCause')
exec('CREATE PROCEDURE spDownTimeCause AS BEGIN SET NOCOUNT ON; END')
GO
ALTER	PROCEDURE [dbo].[spDownTimeCause]
	@Loai NVARCHAR(50) = 'grd',
	@ID INT = 3,
	@TEN_NGUYEN_NHAN NVARCHAR(250) = '-1',
	@TEN_NGUYEN_NHANA NVARCHAR(250) = '-1',
	@DownTimeTypeID INT = '-1',
	@HU_HONG BIT =1, 
	@BTDK BIT = 1,
	@MAC_DINH BIT =1 ,
	@Active BIT = 1,
	 @NNgu INT = 0
AS
BEGIN
--Get luoi
IF UPPER(@Loai) = UPPER('Grd')
BEGIN

	SELECT A.MS_NGUYEN_NHAN, A.TEN_NGUYEN_NHAN, A.TEN_NGUYEN_NHAN_ANH,  A.DownTimeTypeID,  CASE @NNgu WHEN 1 THEN B.DownTimeTypeNameA WHEN 2 THEN ISNULL(NULLIF(B.DownTimeTypeNameH, ''), B.DownTimeTypeName) ELSE ISNULL(NULLIF(B.DownTimeTypeName, ''), B.DownTimeTypeName)
            END AS DownTimeTypeName, ISNULL(HU_HONG,0) AS HU_HONG, ISNULL(BTDK,0) AS BTDK,
            ISNULL(MAC_DINH,0) AS MAC_DINH,ISNULL(A.Active,0) AS Active
	 FROM dbo.NGUYEN_NHAN_DUNG_MAY A 
	 INNER JOIN dbo.DownTimeType B ON B.ID = A.DownTimeTypeID
	 ORDER BY A.TEN_NGUYEN_NHAN
END
--Save
IF UPPER(@Loai) = UPPER('Save')
BEGIN
--THEM
	IF @ID = -1
	BEGIN
		INSERT INTO	dbo.NGUYEN_NHAN_DUNG_MAY ( TEN_NGUYEN_NHAN, HU_HONG, BTDK,
		                                    TEN_NGUYEN_NHAN_ANH, MAC_DINH,
		                                    DownTimeTypeID,Active)
		VALUES(@TEN_NGUYEN_NHAN, @HU_HONG, @BTDK,@TEN_NGUYEN_NHANA,
		                                    @MAC_DINH,
		                                    @DownTimeTypeID,@Active)
		SELECT SCOPE_IDENTITY();
	END
--SUA
	ELSE
	BEGIN
		UPDATE dbo.NGUYEN_NHAN_DUNG_MAY SET
		TEN_NGUYEN_NHAN =@TEN_NGUYEN_NHAN, HU_HONG=@HU_HONG, BTDK=@BTDK,
		                                    TEN_NGUYEN_NHAN_ANH = @TEN_NGUYEN_NHANA, MAC_DINH =@MAC_DINH,
		                                    DownTimeTypeID = @DownTimeTypeID,Active =@Active
		WHERE MS_NGUYEN_NHAN = @ID
		SELECT @ID;
	END
	END

--Delete 
IF UPPER(@Loai) = UPPER('Delete')
BEGIN
	IF EXISTS (SELECT	* FROM dbo.THOI_GIAN_NGUNG_MAY WHERE MS_NGUYEN_NHAN = @ID)
	BEGIN
		SELECT 1 AS TT		
	END
	ELSE
	BEGIN
		DELETE dbo.NGUYEN_NHAN_DUNG_MAY WHERE MS_NGUYEN_NHAN = @ID
		DBCC CHECKIDENT (NGUYEN_NHAN_DUNG_MAY,RESEED,0)
		DBCC CHECKIDENT (NGUYEN_NHAN_DUNG_MAY,RESEED)
		SELECT 0 AS TT		
	END
END	

END







