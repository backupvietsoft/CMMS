IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGET_LOAI_GIAY_PHEP')
exec('CREATE PROCEDURE spGET_LOAI_GIAY_PHEP AS BEGIN SET NOCOUNT ON; END')
GO
ALTER proc [dbo].[spGET_LOAI_GIAY_PHEP]
	@TYPE INT = 0
AS
	
SELECT     MS_LOAI_GP, (CASE @TYPE WHEN 0 THEN TEN_LOAI_GP WHEN 1 THEN ISNULL(TEN_LOAI_GP_A,TEN_LOAI_GP) ELSE ISNULL(TEN_LOAI_GP_H,TEN_LOAI_GP) END) AS TEN_LOAI_GP
FROM         dbo.LOAI_GIAY_PHEP
ORDER BY MS_LOAI_GP


