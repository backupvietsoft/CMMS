
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DON_VI_DO_THOI_GIAN_RUNTIME')
   exec('CREATE PROCEDURE DON_VI_DO_THOI_GIAN_RUNTIME AS BEGIN SET NOCOUNT ON; END')
 Go

ALTER PROC DON_VI_DO_THOI_GIAN_RUNTIME
(	
	@ACTION NVARCHAR(200)=NULL,
	@TBDVD TVT_DON_VI_DO READONLY,
	@TBDVT TVT_DON_VI_TINH READONLY,
	@TBDVTRT TVT_DON_VI_TINH_RUN_TIME READONLY,
	@DVT VARCHAR(10)=NULL,
	@MS_DVT_RT INT =NULL,
	@MS_DV_DO SMALLINT =NULL
)
AS 
BEGIN
	IF @ACTION='LOAD_DVD_RUNTIME'
	BEGIN
		SELECT MS_DV_DO,TEN_DV_DO,CONVERT(BIT,0) IS_UPDATE FROM dbo.DON_VI_DO ORDER BY MS_DV_DO
		SELECT MS_DVT_RT,TEN_DVT_RT,CONVERT(BIT,0) IS_UPDATE FROM dbo.DON_VI_TINH_RUN_TIME ORDER BY MS_DVT_RT
	END
	--IF @ACTION='GET_DON_RUNTIME'
	--BEGIN
	--	SELECT MS_DVT_RT,TEN_DVT_RT,CONVERT(BIT,0) IS_UPDATE FROM dbo.DON_VI_TINH_RUN_TIME ORDER BY MS_DVT_RT
	--END
	IF @ACTION='LOAD_DVT'
	BEGIN
		SELECT DVT,TEN_1,TEN_2,TEN_3,GHI_CHU,CONVERT(BIT,0) IS_UPDATE FROM dbo.DON_VI_TINH ORDER BY DVT
	END
	IF @ACTION='SAVE_DVT'
	BEGIN
		INSERT INTO [dbo].[DON_VI_TINH]([DVT],[TEN_1],[TEN_2],[TEN_3],[GHI_CHU])
		SELECT T2.[DVT],T2.[TEN_1],T2.[TEN_2],T2.[TEN_3],T2.[GHI_CHU] 
		FROM @TBDVT T2 
		WHERE T2.DVT NOT IN(SELECT DISTINCT DVT FROM dbo.DON_VI_TINH)
		
		UPDATE T1 SET T1.TEN_1=T2.TEN_1,T1.TEN_2=T2.TEN_2,T1.TEN_3=T2.TEN_3,T1.GHI_CHU=T2.GHI_CHU
		FROM dbo.DON_VI_TINH T1 INNER JOIN @TBDVT T2 ON T1.DVT=T2.DVT
	END
	IF @ACTION='DELETE_DVT'
	BEGIN
		DELETE [dbo].[DON_VI_TINH] WHERE DVT = @DVT
	END
	IF @ACTION='SAVE'
	BEGIN
		
		INSERT INTO dbo.DON_VI_DO(TEN_DV_DO)
		SELECT TEN_DV_DO
		FROM @TBDVD 
		WHERE ISNULL(MS_DV_DO,-1) NOT IN(SELECT DISTINCT MS_DV_DO FROM dbo.DON_VI_DO)
		
		UPDATE T1 SET T1.TEN_DV_DO=T2.TEN_DV_DO
		FROM dbo.DON_VI_DO T1 INNER JOIN @TBDVD T2 ON ISNULL(T1.MS_DV_DO,-1)=ISNULL(T2.MS_DV_DO,-1)
		
		INSERT INTO dbo.DON_VI_TINH_RUN_TIME(TEN_DVT_RT)
		SELECT TEN_DVT_RT
		FROM @TBDVTRT 
		WHERE ISNULL(MS_DVT_RT,-1) NOT IN(SELECT DISTINCT MS_DVT_RT FROM dbo.DON_VI_TINH_RUN_TIME)
		
		UPDATE T1 SET T1.TEN_DVT_RT=T2.TEN_DVT_RT
		FROM dbo.DON_VI_TINH_RUN_TIME T1 INNER JOIN @TBDVTRT T2 ON ISNULL(T1.MS_DVT_RT,-1)=ISNULL(T2.MS_DVT_RT,-1)
	END
	IF @ACTION='DELETE_DVD'
	BEGIN
		DELETE [dbo].[DON_VI_DO] WHERE MS_DV_DO=@MS_DV_DO
		
	END
	IF @ACTION='DELETE_THOIGIAN'
	BEGIN
		
		DELETE dbo.DON_VI_TINH_RUN_TIME WHERE MS_DVT_RT=@MS_DVT_RT
	END
END