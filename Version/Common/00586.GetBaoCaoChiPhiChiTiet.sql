
--	GetBaoCaoChiPhiChiTiet '08/01/2000','08/31/2016','-1',-1,-1,'-1','ADMIN','-1'
ALTER PROC [dbo].[GetBaoCaoChiPhiChiTiet] 
	@TNgay AS DATETIME,
	@DNgay AS DATETIME,
	@NXuong AS NVARCHAR(50),
	@HThong AS INT,
	@BPCPhi AS int,
	@MsLMay AS NVARCHAR(50),
	@UName AS NVARCHAR(50),
	@MsMay AS NVARCHAR(50)
AS


DECLARE @NgayHT DATETIME
	SET @NgayHT = GETDATE()
	
	--@NgayHT DATETIME,
	--@UserName NVARCHAR(50),
	--@MsNXuong nvarchar(50),
	--@MsHeThong int,
	--@MsBPCPhi int,
	--@MsLoaiMay NVARCHAR (20),
	--@NhomMay NVARCHAR (20),
	--@MSMay NVARCHAR (100),
	--@NNgu int
	

SELECT * INTO #MAY FROM dbo.MGetMayUserNgay(@NgayHT,@UName,@NXuong,@HThong,@BPCPhi,@MsLMay,'-1',@MsMay,0) 	

--SELECT * FROM #MAY

	--SELECT DISTINCT  MS_MAY, TEN_MAY ,MSNX,MS_HT,MSBP,MS_LOAI_MAY  INTO #MAY  FROM
	--(
	--SELECT DISTINCT A.MS_N_XUONG AS MSNX, DBO.MGetHTTheoNgay (M.MS_MAY,@NgayHT) AS  MS_HT, 
	--DBO.MGetBPCPhiTheoNgay(M.MS_MAY,@NgayHT) AS MSBP, M.* ,X.MS_LOAI_MAY
	--	FROM MAY M INNER JOIN PHIEU_BAO_TRI N ON M.MS_MAY = N.MS_MAY INNER JOIN dbo.NHOM_MAY AS X ON 
	--	M.MS_NHOM_MAY = X.MS_NHOM_MAY INNER JOIN dbo.LOAI_MAY AS Y ON X.MS_LOAI_MAY = Y.MS_LOAI_MAY
	--	INNER JOIN (SELECT * FROM [dbo].[MGetNXMayUserDiaDiem]('-1',@NXuong,@NgayHT,@UName,'-1','-1','-1') ) A
	--	ON A.MS_MAY = M.MS_MAY INNER JOIN dbo.PHIEU_BAO_TRI_CHI_PHI AS C ON N.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI			
	--WHERE TINH_TRANG_PBT > 3 AND (NGAY_BD_KH BETWEEN @TNgay AND DATEADD(DAY,1,@DNgay)) AND 
	--	(@MsLMay = '-1' OR X.MS_LOAI_MAY = @MsLMay)   AND (@MsMay = '-1' OR N.MS_MAY = @MsMay)   
	--) A INNER JOIN (SELECT MS_N_XUONG FROM [dbo].[MGetNhaXuongDiaDiem]('-1','-1','-1',@UName) ) B 
	--ON A.MSNX = B.MS_N_XUONG 
	--WHERE (@HThong = -1 OR MS_HT = @HThong)   AND	(@BPCPhi = -1 OR MSBP = @BPCPhi)   
	
--Chu Y, Doi voi Cang Baria thi lay ngay tinh Chi Phi la ngay Nghiem Thu
DECLARE @CTY NVARCHAR(50)
SELECT @CTY = [PRIVATE] FROM THONG_TIN_CHUNG
IF @CTY = 'BARIA'
BEGIN
		SELECT CONVERT(INT,NULL) AS STT, 
		A.MS_MAY, B.TEN_MAY, B.TEN_HE_THONG, B.Ten_N_XUONG, B.TEN_BP_CHIU_PHI, A.MS_PHIEU_BAO_TRI, A.NGAY_BD_KH, A.NGAY_KT_KH, G.TEN_LOAI_BT, H.TEN_NGUYEN_NHAN, 
		SUM(ISNULL(C.CHI_PHI_VAT_TU,0)) AS CHI_PHI_VAT_TU,
		SUM(ISNULL(C.CHI_PHI_PHU_TUNG,0))  AS CHI_PHI_PHU_TUNG ,
		SUM(ISNULL(C.CHI_PHI_NHAN_CONG,0))  AS CHI_PHI_NHAN_CONG,
		SUM(ISNULL(C.CHI_PHI_DV,0))  AS CHI_PHI_DV,
		SUM(ISNULL(C.CHI_PHI_KHAC,0))  AS CHI_PHI_KHAC,
		(
		SUM(ISNULL(C.CHI_PHI_VAT_TU,0)) + 
		SUM(ISNULL(C.CHI_PHI_PHU_TUNG,0)) + 
		SUM(ISNULL(C.CHI_PHI_NHAN_CONG,0)) + 
		SUM(ISNULL(C.CHI_PHI_DV,0)) + 
		SUM(ISNULL(C.CHI_PHI_KHAC,0)) 
		) AS  TONG

		FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
							  #MAY AS B ON A.MS_MAY = B.MS_MAY INNER JOIN
							  dbo.PHIEU_BAO_TRI_CHI_PHI AS C ON A.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI INNER JOIN
							  dbo.LOAI_BAO_TRI AS G ON A.MS_LOAI_BT = G.MS_LOAI_BT LEFT OUTER JOIN
							  dbo.NGUYEN_NHAN_DUNG_MAY AS H ON A.MS_NGUYEN_NHAN = H.MS_NGUYEN_NHAN
		WHERE     (A.TINH_TRANG_PBT > 2) AND (NGAY_NGHIEM_THU  BETWEEN @TNgay AND DATEADD(DAY,1,@DNgay))
		GROUP BY A.MS_MAY, B.TEN_MAY, B.TEN_HE_THONG, B.Ten_N_XUONG, B.TEN_BP_CHIU_PHI, A.MS_PHIEU_BAO_TRI, A.NGAY_BD_KH, A.NGAY_KT_KH, G.TEN_LOAI_BT, H.TEN_NGUYEN_NHAN
END
ELSE
BEGIN
	SELECT CONVERT(INT,NULL) AS STT, 
	A.MS_MAY, B.TEN_MAY, B.TEN_HE_THONG, B.Ten_N_XUONG, B.TEN_BP_CHIU_PHI, A.MS_PHIEU_BAO_TRI, A.NGAY_BD_KH, A.NGAY_KT_KH, G.TEN_LOAI_BT, H.TEN_NGUYEN_NHAN, 
	SUM(ISNULL(C.CHI_PHI_VAT_TU,0)) AS CHI_PHI_VAT_TU,
	SUM(ISNULL(C.CHI_PHI_PHU_TUNG,0))  AS CHI_PHI_PHU_TUNG ,
	SUM(ISNULL(C.CHI_PHI_NHAN_CONG,0))  AS CHI_PHI_NHAN_CONG,
	SUM(ISNULL(C.CHI_PHI_DV,0))  AS CHI_PHI_DV,
	SUM(ISNULL(C.CHI_PHI_KHAC,0))  AS CHI_PHI_KHAC,
	(
	SUM(ISNULL(C.CHI_PHI_VAT_TU,0)) + 
	SUM(ISNULL(C.CHI_PHI_PHU_TUNG,0)) + 
	SUM(ISNULL(C.CHI_PHI_NHAN_CONG,0)) + 
	SUM(ISNULL(C.CHI_PHI_DV,0)) + 
	SUM(ISNULL(C.CHI_PHI_KHAC,0)) 
	) AS  TONG

	FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
						  #MAY AS B ON A.MS_MAY = B.MS_MAY INNER JOIN
						  dbo.PHIEU_BAO_TRI_CHI_PHI AS C ON A.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI INNER JOIN
						  dbo.LOAI_BAO_TRI AS G ON A.MS_LOAI_BT = G.MS_LOAI_BT LEFT OUTER JOIN
						  dbo.NGUYEN_NHAN_DUNG_MAY AS H ON A.MS_NGUYEN_NHAN = H.MS_NGUYEN_NHAN
	WHERE     (A.TINH_TRANG_PBT > 2) AND (NGAY_BD_KH  BETWEEN @TNgay AND DATEADD(DAY,1,@DNgay))
	GROUP BY A.MS_MAY, B.TEN_MAY, B.TEN_HE_THONG, B.Ten_N_XUONG, B.TEN_BP_CHIU_PHI, A.MS_PHIEU_BAO_TRI, A.NGAY_BD_KH, A.NGAY_KT_KH, G.TEN_LOAI_BT, H.TEN_NGUYEN_NHAN

END


