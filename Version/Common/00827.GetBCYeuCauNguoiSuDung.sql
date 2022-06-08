
--EXEC GetBCYeuCauNguoiSuDung 'ADMIN',N'WR-201612000016','12/13/2016',0

ALTER PROC [dbo].[GetBCYeuCauNguoiSuDung]
	@UserName NVARCHAR(50),
	@MsYCau NVARCHAR(50),
	@NgayYC DATETIME,
	@NNgu INT
AS

SELECT     dbo.YEU_CAU_NSD.MS_YEU_CAU, dbo.YEU_CAU_NSD.GIO_YEU_CAU, dbo.YEU_CAU_NSD.NGUOI_YEU_CAU, dbo.NHA_XUONG.Ten_N_XUONG, dbo.YEU_CAU_NSD.USER_COMMENT
FROM         dbo.YEU_CAU_NSD INNER JOIN
                      dbo.NHA_XUONG ON dbo.YEU_CAU_NSD.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG
WHERE     (dbo.YEU_CAU_NSD.MS_YEU_CAU = @MsYCau )

SELECT * INTO #MAY_TMP FROM dbo.MGetMayUserNgay(@NgayYC,@UserName,'-1',-1,-1,'-1','-1','-1',0)

SELECT        C.MS_MAY , C.TEN_MAY ,C.TEN_HE_THONG, A.MO_TA_TINH_TRANG, A.YEU_CAU, D.MS_BO_PHAN, E.TEN_BO_PHAN, F.MS_PT, 
CASE @NNgu WHEN 0 THEN F.TEN_PT WHEN 1 THEN F.TEN_PT_ANH ELSE F.TEN_PT_HOA END AS TEN_PT,
F.QUY_CACH, E.STT
FROM            dbo.YEU_CAU_NSD_CHI_TIET AS A INNER JOIN
                         dbo.YEU_CAU_NSD AS B ON A.STT = B.STT INNER JOIN
                         #MAY_TMP AS C ON A.MS_MAY = C.MS_MAY LEFT OUTER JOIN
                         dbo.YEU_CAU_NSD_CHI_TIET_BO_PHAN AS D ON A.STT = D.STT AND A.MS_MAY = D.MS_MAY AND A.STT_VAN_DE = D.STT_VAN_DE LEFT OUTER JOIN
                         dbo.CAU_TRUC_THIET_BI AS E ON D.MS_MAY = E.MS_MAY AND D.MS_BO_PHAN = E.MS_BO_PHAN LEFT OUTER JOIN
                         dbo.IC_PHU_TUNG AS F ON D.MS_PT = F.MS_PT
WHERE     (B.MS_YEU_CAU = @MsYCau)
ORDER BY C.TEN_HE_THONG,C.MS_MAY, ISNULL(E.STT, 9999)
