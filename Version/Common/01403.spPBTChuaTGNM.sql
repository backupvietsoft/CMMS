

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spPBTChuaTGNM')
   exec('CREATE PROCEDURE spPBTChuaTGNM AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE [dbo].[spPBTChuaTGNM]
	@TuNgay DATETIME = '01/01/2015',
	@DenNgay DATETIME = '01/01/2017',
	@iLoai INT = 0,
	@UserName NVARCHAR(50) = 'Admin',
	@MsNXuong nvarchar(50) = '-1',
	@MsHeThong int = -1,
	@MsLoaiMay NVARCHAR (50) = '-1',
	@MsNhomMay NVARCHAR (50) = '-1',
	@NNgu int = 0
	
AS
BEGIN
	SELECT TOP 1 * FROM THOI_GIAN_NGUNG_MAY
END