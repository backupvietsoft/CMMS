IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGET_PHIEU_BAO_TRI_HINH')
   exec('CREATE PROCEDURE spGET_PHIEU_BAO_TRI_HINH AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC [dbo].[spGET_PHIEU_BAO_TRI_HINH]
	@MS_PHIEU_BAO_TRI NVARCHAR(50)
AS
BEGIN

		SELECT *, Convert(nvarchar(500),'') AS HINH FROM  PHIEU_BAO_TRI_HINH WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI
		RETURN;
END