
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'TR' AND name = 'INSERT_TON_KHO_X')
   exec('CREATE TRIGGER [dbo].[INSERT_TON_KHO_X] ON  [dbo].[IC_DON_HANG_NHAP_X_VAT_TU_CHI_TIET] AFTER INSERT AS BEGIN SET NOCOUNT ON; SELECT 1  END')
GO
go


ALTER TRIGGER [dbo].[INSERT_TON_KHO_X]
   ON  [dbo].[IC_DON_HANG_NHAP_X_VAT_TU_CHI_TIET]
   AFTER INSERT 
AS 
BEGIN	

	INSERT INTO [VI_TRI_KHO_VAT_TU_X]([MS_KHO],[MS_VI_TRI],[MS_DH_NHAP_PT],[MS_PT],[SL_VT])
	SELECT dbo.IC_DON_HANG_NHAP_X.MS_KHO,INSERTED.MS_VI_TRI,dbo.IC_DON_HANG_NHAP_X.MS_DH_NHAP_PT,
	INSERTED.MS_PT ,ISNULL(SL_VT,0) AS SL_VT
	FROM dbo.IC_DON_HANG_NHAP_X INNER JOIN INSERTED ON 
	dbo.IC_DON_HANG_NHAP_X.MS_DH_NHAP_PT = INSERTED.MS_DH_NHAP_PT
END

GO

ALTER TABLE [dbo].[IC_DON_HANG_NHAP_VAT_TU_CHI_TIET] ENABLE TRIGGER [INSERT_TON_KHO]
GO

