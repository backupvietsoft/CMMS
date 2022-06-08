
ALTER VIEW [dbo].[MAY_HE_THONG_NGAY_MAX]
AS
SELECT DISTINCT MHT.MS_MAY, MHT.MS_HE_THONG, MAY_MAX.NGAY_MAX, dbo.HE_THONG.TEN_HE_THONG,TEN_HE_THONG_ANH AS TEN_HT_A, TEN_HE_THONG_HOA AS TEN_HT_H
FROM         dbo.MAY_HE_THONG AS MHT INNER JOIN
                          (SELECT     MS_MAY, MAX(NGAY_NHAP) AS NGAY_MAX
                            FROM          dbo.MAY_HE_THONG
                            GROUP BY MS_MAY) AS MAY_MAX ON MHT.MS_MAY = MAY_MAX.MS_MAY AND MHT.NGAY_NHAP = MAY_MAX.NGAY_MAX INNER JOIN
                      dbo.HE_THONG ON MHT.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG

GO


