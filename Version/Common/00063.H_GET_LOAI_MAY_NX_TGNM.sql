--exec H_GET_LOAI_MAY_NX_TGNM 'GF-03-05'
ALTER procedure [dbo].[H_GET_LOAI_MAY_NX_TGNM] 
    @MS_N_XUONG NVARCHAR(50)
AS

--DECLARE @MS_N_XUONG NVARCHAR(5)
--SET @MS_N_XUONG = '-1'

IF @MS_N_XUONG = '-1'
BEGIN
	SELECT DISTINCT  dbo.LOAI_MAY.MS_LOAI_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY
	FROM         dbo.NHOM_MAY INNER JOIN
                      dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN
                      dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN
                      dbo.THOI_GIAN_NGUNG_MAY ON dbo.MAY.MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY
END
ELSE
BEGIN
	SELECT DISTINCT  dbo.LOAI_MAY.MS_LOAI_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY
	FROM         dbo.NHOM_MAY INNER JOIN
                      dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN
                      dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN
                      dbo.THOI_GIAN_NGUNG_MAY ON dbo.MAY.MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY
	WHERE dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = @MS_N_XUONG
END

