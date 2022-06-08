

ALTER procedure [dbo].[InsertKE_HOACH_THUC_HIEN]
	@MS_CN NVARCHAR(9),
	@NGAY DATETIME,
	@DEN_NGAY DATETIME,
	@HOAN_THANH INT
AS
-- @HOAN_THANH = 0 all 
if @HOAN_THANH = 0 set @HOAN_THANH = -1
-- @HOAN_THANH = 1 Chua Hoan Thanh
if @HOAN_THANH = 1 set @HOAN_THANH = 0
-- @HOAN_THANH = 2 Hoan Thanh
if @HOAN_THANH = 2 set @HOAN_THANH = 1


SELECT        TOP (100) PERCENT T1.TEN_CONG_VIEC, T1.THOI_GIAN_DK, T1.NGAY, T1.THOI_HAN, T1.GHI_CHU, T2.TEN_UU_TIEN AS UU_TIEN, T1.USER_LAST, T1.THOI_GIAN_SUA, T1.PREVIOUS_USER, T1.TU_GIO, T1.DEN_GIO, 
                         T1.SPHUT
FROM            dbo.KE_HOACH_THUC_HIEN AS T1 LEFT OUTER JOIN
                         dbo.MUC_UU_TIEN AS T2 ON T1.MS_UU_TIEN = T2.MS_UU_TIEN
WHERE        (T1.MS_CONG_NHAN = @MS_CN) 
	AND (CONVERT(DATE, T1.NGAY) BETWEEN CONVERT(DATETIME, @NGAY, 101) AND CONVERT(DATETIME, @DEN_NGAY, 101)) 
	AND (T1.DA_XONG = @HOAN_THANH OR @HOAN_THANH = -1) 

ORDER BY T1.THOI_GIAN_SUA, T1.STT