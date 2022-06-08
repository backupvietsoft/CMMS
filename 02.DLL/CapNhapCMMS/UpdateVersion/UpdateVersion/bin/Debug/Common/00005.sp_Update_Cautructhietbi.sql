--sp_Update_Cautructhietbi
ALTER PROCEDURE [dbo].[sp_Update_Cautructhietbi] 
	@MS_MAY nvarchar(30),
	@MS_BOPHAN nvarchar(50),
	@TEN_BP nvarchar(250),
	@SL int,	
	@GHI_CHU nvarchar(250),
	@RUN_TIME float,
	@MS_DVT int,
	@MS_BP_OLD nvarchar(30),
	@HINH NVARCHAR(255),
	@MS_PT NVARCHAR(30),
	@CLASS_ID NVARCHAR(50)

AS

IF @MS_DVT = 0
SET @MS_DVT = NULL
	SET NOCOUNT ON;
	
	UPDATE CAU_TRUC_THIET_BI SET
		MS_BO_PHAN = @MS_BOPHAN,		
		TEN_BO_PHAN=@TEN_BP,
		SO_LUONG=@SL,		
		GHI_CHU=@GHI_CHU,
		RUN_TIME=@RUN_TIME,
		MS_DVT_RT=@MS_DVT,
		HINH=@HINH,
		MS_PT=@MS_PT,
		CLASS_ID = @CLASS_ID
	WHERE MS_MAY=@MS_MAY AND MS_BO_PHAN=@MS_BP_OLD	
--Cap nhat cho cap cha
UPDATE CAU_TRUC_THIET_BI SET MS_BO_PHAN_CHA =@MS_BOPHAN
WHERE MS_MAY=@MS_MAY AND MS_BO_PHAN_CHA=@MS_BP_OLD
