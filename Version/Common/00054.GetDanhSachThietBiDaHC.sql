
-- drop table rptDanhSachThietBiDaHC
-- EXEC GetDanhSachThietBiDaHC 2015,-1,'ADMIN'
-- SELECT * FROM rptDanhSachThietBiDaHC

ALTER procedure [dbo].[GetDanhSachThietBiDaHC]
	@NAM INT,
	@MS_LOAI_HIEU_CHUAN nvarchar(20),
	@USERID nvarchar(20)
AS

SELECT * INTO #MAY_USER FROM [dbo].[MashjGetMayUser](@USERID)


SELECT     dbo.HIEU_CHUAN_MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THE,
 MAX(dbo.HIEU_CHUAN_MAY.NGAY_HC) AS NGAYHCCUOI,convert( nvarchar,CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 1 THEN MAY.CHU_KY_HC_TB ELSE 
				CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 2 THEN MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI
 ELSE    MAY.CHU_KY_KD_TB	END	 END) + ' ' + isnull(dbo.DON_VI_THOI_GIAN.TEN_DV_TG,'') as  CHU_KY_HC_TB ,dbo.HIEU_CHUAN_MAY.CO_QUAN_HIEU_CHUAN, dbo.HIEU_CHUAN_MAY.GIAY_CHUNG_NHAN, dbo.NHA_XUONG.Ten_N_XUONG,
case when  MAY.DON_VI_THOI_GIAN =1 then 
	MAX(dbo.HIEU_CHUAN_MAY.NGAY_HC) + CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 1 THEN MAY.CHU_KY_HC_TB ELSE 
				CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 2 THEN MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI ELSE    MAY.CHU_KY_KD_TB	END	 END
else 
	case when  MAY.DON_VI_THOI_GIAN =2 THEN 
		MAX(dbo.HIEU_CHUAN_MAY.NGAY_HC) + 7*(CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 1 THEN MAY.CHU_KY_HC_TB ELSE 
				CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 2 THEN MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI ELSE    MAY.CHU_KY_KD_TB	END	 END)
	ELSE 
		case when  MAY.DON_VI_THOI_GIAN =3 THEN 
			DATEADD(MONTH,(CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 1 THEN MAY.CHU_KY_HC_TB ELSE 
				CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 2 THEN MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI ELSE    MAY.CHU_KY_KD_TB	END	 END),MAX(dbo.HIEU_CHUAN_MAY.NGAY_HC))
		else
			DATEADD(year,(CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 1 THEN MAY.CHU_KY_HC_TB ELSE 
				CASE WHEN dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = 2 THEN MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI ELSE    MAY.CHU_KY_KD_TB	END	 END),MAX(dbo.HIEU_CHUAN_MAY.NGAY_HC))
	    end
	END
END
AS NGAYHCKE
INTO rptDanhSachThietBiDaHC         
FROM     dbo.HIEU_CHUAN_MAY INNER JOIN
         #MAY_USER MAY ON dbo.HIEU_CHUAN_MAY.MS_MAY = MAY.MS_MAY INNER JOIN
         dbo.NHOM_MAY ON MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN
         dbo.MAY_NHA_XUONG ON dbo.HIEU_CHUAN_MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN
         dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN
         dbo.DON_VI_THOI_GIAN ON MAY.DON_VI_THOI_GIAN = dbo.DON_VI_THOI_GIAN.MS_DV_TG 
         
WHERE   (YEAR(dbo.HIEU_CHUAN_MAY.NGAY_HC) = @NAM) 
	AND (dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = @MS_LOAI_HIEU_CHUAN OR @MS_LOAI_HIEU_CHUAN = -1)
GROUP BY dbo.HIEU_CHUAN_MAY.MS_MAY, MAY.CHU_KY_HC_TB, dbo.NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THE, 
         dbo.NHA_XUONG.Ten_N_XUONG, dbo.DON_VI_THOI_GIAN.TEN_DV_TG, dbo.HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN,MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI,MAY.CHU_KY_KD_TB
		 ,dbo.HIEU_CHUAN_MAY.CO_QUAN_HIEU_CHUAN, dbo.HIEU_CHUAN_MAY.GIAY_CHUNG_NHAN,MAY.DON_VI_THOI_GIAN
