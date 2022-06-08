IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spCHECK_MAC_DINH_TINH_TRANG_PBT_CT')
   exec('CREATE PROCEDURE spCHECK_MAC_DINH_TINH_TRANG_PBT_CT AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC [dbo].[spCHECK_MAC_DINH_TINH_TRANG_PBT_CT]
	@STT INT
AS
BEGIN
		DECLARE @flag BIT = 0
		IF EXISTS (SELECT * FROM TINH_TRANG_PBT_CT WHERE STT = @STT AND MAC_DINH = 1)
		begin
			SET @flag = 1;
		end
		ELSE
		begin
			SET @flag = 0;
		end

		SELECT @flag;
END