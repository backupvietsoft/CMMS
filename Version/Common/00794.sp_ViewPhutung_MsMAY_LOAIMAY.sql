
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_ViewPhutung_MsMAY_LOAIMAY')
   exec('CREATE PROCEDURE sp_ViewPhutung_MsMAY_LOAIMAY AS BEGIN SET NOCOUNT ON; END')
GO
--exec sp_ViewPhutung_MsMAY_LOAIMAY 'ROS',0,-1, 'admin'
ALTER procedure [dbo].[sp_ViewPhutung_MsMAY_LOAIMAY]	
	@sLOAI_MAY varchar(30),
	@NNgu INT,
	@MS_LOAI_PT INT,
	@UserName NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT DISTINCT MS_LOAI_PT INTO #LPT_USER FROM NHOM_LOAI_PHU_TUNG A INNER JOIN USERS B ON A.GROUP_ID = B.GROUP_ID WHERE USERNAME = @UserName


	SELECT DISTINCT CONVERT(BIT,0) AS chkChon, IC_PHU_TUNG_LOAI_MAY.MS_PT,MS_PT_NCC,MS_PT_CTY, TEN_PT ,TEN_PT_VIET, CASE @NNgu WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT,
		QUY_CACH ,IC_PHU_TUNG.DVT AS DVT1
	FROM         IC_PHU_TUNG INNER JOIN
					  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN
					  IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT INNER JOIN
					  IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT INNER JOIN
					  LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT INNER JOIN 
					  #LPT_USER X ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = X.MS_LOAI_PT
	WHERE (MS_LOAI_MAY=@sLOAI_MAY OR @sLOAI_MAY = '-1' ) AND (IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT=@MS_LOAI_PT OR @MS_LOAI_PT = -1 )  
		AND (LOAI_VT.VAT_TU = 0) AND (IC_PHU_TUNG.ACTIVE_PT = 1)
	ORDER BY IC_PHU_TUNG_LOAI_MAY.MS_PT
			
END			
