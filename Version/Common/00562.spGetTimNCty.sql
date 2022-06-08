
--exec spGetTimNCty 5, 'TRUNGNV'
ALTER PROCEDURE [dbo].[spGetTimNCTy]
	@MsVaiTro int,
	@User nvarchar(50)
AS
	SELECT Distinct MS_TO, TEN_TO  INTO #TO_USER FROM [dbo].[MGetDonViPhongBanUser](@User)

SELECT * FROM 
(
SELECT	MS_KH, TEN_CONG_TY, TEN_RUT_GON, DIA_CHI, CONVERT(BIT, 1) AS KHACH_HANG FROM dbo.KHACH_HANG
UNION
SELECT     A.MS_CONG_NHAN AS MS_NGUOI_NHAP, A.HO + ' ' + A.TEN AS TEN_NGUOI_NHAP, A.MS_THE_CC, T.TEN_TO, CONVERT(BIT, 0) AS KHACH_HANG
FROM         dbo.CONG_NHAN AS A INNER JOIN
                    #TO_USER T on T.MS_TO = A.MS_TO 
					INNER JOIN dbo.CONG_NHAN_VAI_TRO D ON A.MS_CONG_NHAN = D.MS_CONG_NHAN
WHERE D.MS_VAI_TRO = @MsVaiTro     AND NGAY_NGHI_VIEC IS NULL                  
) A 
ORDER BY TEN_CONG_TY

