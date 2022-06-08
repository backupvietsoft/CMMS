IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_getDanhSachKHTT')
   exec('CREATE PROCEDURE [dbo].[sp_getDanhSachKHTT] AS BEGIN SET NOCOUNT ON; END')
GO

--sp_getDanhSachKHTT 12 ,'HO1-05-ROS-004', 38
--EXEC sp_getKHTT 12 ,'HO1-05-ROS-004', 38
ALTER PROC [dbo].[sp_getDanhSachKHTT]
	@STT INT,
	@MS_MAY NVARCHAR(50),
	@STT_VAN_DE INT
AS
BEGIN
	
	declare @NGAY_DSX datetime
	set @NGAY_DSX =(SELECT CONVERT(DATETIME,CONVERT(NVARCHAR(10),YEU_CAU_NSD_CHI_TIET.THOI_GIAN_DSX,101)) 
			FROM YEU_CAU_NSD_CHI_TIET where STT=@STT AND MS_MAY=@MS_MAY AND STT_VAN_DE =@STT_VAN_DE )
			

		SELECT     F.MS_MAY, F.TEN_MAY, A.TEN_HANG_MUC, A.NGAY, A.NGAY_DK_HT, C.TEN_LY_DO_VIET, E.TEN_UU_TIEN, G.HO + ' ' + G.TEN AS HO_TEN, A.HANG_MUC_ID
		FROM         dbo.KE_HOACH_TONG_THE AS A LEFT JOIN
                      dbo.LY_DO_SUA_CHUA AS C ON A.LY_DO_SC = C.MS_LY_DO LEFT JOIN
                      dbo.LOAI_BAO_TRI AS D ON A.MS_LOAI_BT = D.MS_LOAI_BT LEFT JOIN
                      dbo.MUC_UU_TIEN AS E ON A.MS_UU_TIEN = E.MS_UU_TIEN LEFT JOIN
                      dbo.MAY AS F ON A.MS_MAY = F.MS_MAY LEFT OUTER JOIN
                      dbo.CONG_NHAN AS G ON A.MS_CN_PT = G.MS_CONG_NHAN
		WHERE A.MS_MAY = @MS_MAY AND NGAY_DK_HT >=  @NGAY_DSX AND HANG_MUC_ID NOT IN
			(SELECT DISTINCT HANG_MUC_ID FROM dbo.KE_HOACH_TONG_CONG_VIEC WHERE (ISNULL(MS_PHIEU_BAO_TRI,'') <> ''  OR ISNULL(KHONG_GQ,0) = 1 ) AND MS_MAY = @MS_MAY)
END	






