

--	EXEC GetBCPBTBARIA 'ADMIN','WO-201510000003','2014-04-24 00:00:00.000',0

ALTER PROC [dbo].[GetBCPBTBARIA]
	@UserName NVARCHAR(50),
	@MsPBT NVARCHAR(100),
	@NgayBDKH DATETIME,
	@NNgu INT
AS	


-- Lay thong tin phieu bao tri
SELECT     A.MS_PHIEU_BAO_TRI, CONVERT(DATETIME, CONVERT(NVARCHAR(10), A.NGAY_LAP, 101) + ' ' + CONVERT(NVARCHAR(10), A.GIO_LAP, 108)) AS NGAY_LAP, D.TEN_LOAI_BT, 
                      I.SO_YEU_CAU AS PHIEU_YC, E.TEN_UU_TIEN, dbo.Get_NoiDungYeuCau(A.MS_PHIEU_BAO_TRI) AS NOI_DUNG_YC, C.MS_MAY, C.TEN_MAY, C.Ten_N_XUONG, C.TEN_BP_CHIU_PHI, 
                      F.HO + ' ' + F.TEN AS HT_NGUOI_LAP, A.SO_PHIEU_BAO_TRI, 
                      CASE 0 WHEN 0 THEN B.TEN_TINH_TRANG WHEN 1 THEN B.TEN_TINH_TRANG_ANH ELSE B.TEN_TINH_TRANG_HOA END AS TEN_TTRANG, G.TEN_HT_BT, A.LY_DO_BT, A.NGAY_BD_KH, 
                      A.NGAY_KT_KH, NGS.HO + ' ' + NGS.TEN AS HT_NGS
FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
                      dbo.TINH_TRANG_PBT AS B ON A.TINH_TRANG_PBT = B.STT INNER JOIN
                          (SELECT     MS_MAY, MS_NHOM_MAY, MS_LOAI_MAY, MS_HSX, MS_HIEN_TRANG, MS_KH, SO_NAM_KHAU_HAO, MO_TA, NHIEM_VU_THIET_BI, MODEL, SERIAL_NUMBER, NGAY_SX, 
                                                   NUOC_SX, NGAY_MUA, NGAY_BD_BAO_HANH, NGAY_DUA_VAO_SD, SO_THE, SO_NGAY_LV_TRONG_TUAN, SO_GIO_LV_TRONG_NGAY, MS_DVT_RT, TY_LE_CON_LAI, 
                                                   MUC_UU_TIEN, SO_THANG_BH, GIA_MUA, NGOAI_TE, LUU_Y_SU_DUNG, Anh_TB, CHU_KY_HC_TB, TEN_MAY, AN_TOAN, MS_HO_SO, TEN_HO_SO, NGAY_HIEU_LUC_HO_SO, 
                                                   SO_CT, TI_GIA_VND, TI_GIA_USD, CHU_KY_HIEU_CHUAN_TB_NGOAI, CHU_KY_KD_TB, DON_VI_THOI_GIAN, MS_N_XUONG, MS_HE_THONG, MS_BP_CHIU_PHI, USER_INSERT, 
                                                   NGAY_INSERT, USER_UPDATE, NGAY_UPDATE, Ten_N_XUONG, TEN_HE_THONG, TEN_NHOM_MAY, TEN_LOAI_MAY, TEN_BP_CHIU_PHI
                            FROM          dbo.MGetMayUserNgay(@NgayBDKH, @UserName, '-1', - 1, - 1, '-1', '-1', '-1', 0) AS MGetMayUserNgay_1) AS C ON A.MS_MAY = C.MS_MAY INNER JOIN
                      dbo.LOAI_BAO_TRI AS D ON A.MS_LOAI_BT = D.MS_LOAI_BT INNER JOIN
                      dbo.MUC_UU_TIEN AS E ON A.MS_UU_TIEN = E.MS_UU_TIEN INNER JOIN
                      dbo.HINH_THUC_BAO_TRI AS G ON D.MS_HT_BT = G.MS_HT_BT INNER JOIN
                      dbo.CONG_NHAN AS F ON A.NGUOI_LAP = F.MS_CONG_NHAN LEFT OUTER JOIN
                      dbo.CONG_NHAN AS NGS ON A.NGUOI_GIAM_SAT = NGS.MS_CONG_NHAN LEFT OUTER JOIN
                      dbo.YEU_CAU_NSD AS I INNER JOIN
                      dbo.YEU_CAU_NSD_CHI_TIET AS H ON I.STT = H.STT ON A.MS_PHIEU_BAO_TRI = H.MS_PBT
WHERE     (A.MS_PHIEU_BAO_TRI = @MsPBT)

-- Lay thong tin phieu bao tri cong viec
DECLARE @PBT_CV TABLE (
	[TEN_BO_PHAN] [nvarchar](max) NULL,
	[MO_TA_CV] [nvarchar](max) NULL,
	[NHAN_SU] [nvarchar](max) NULL,
	[YEU_CAU_DUNG_CU] [nvarchar](max) NULL,
	[SO_GIO_KH] [float] NULL,
	[TU_NGAY] [datetime] NULL,
	[DEN_NGAY] [datetime] NULL,
	[CVPT] [int] NULL,
	[STT] [int]
	--[STT] [int] IDENTITY(1,1) NOT NULL
) 

INSERT INTO @PBT_CV (STT,[TEN_BO_PHAN],[MO_TA_CV],[NHAN_SU],[YEU_CAU_DUNG_CU],[SO_GIO_KH],[TU_NGAY],[DEN_NGAY],[CVPT])
SELECT    ROW_NUMBER() OVER (ORDER BY CVPT,TEN_BO_PHAN, MO_TA_CV) AS STT,
	[TEN_BO_PHAN],[MO_TA_CV],[NHAN_SU],[YEU_CAU_DUNG_CU],[SO_GIO_KH],[TU_NGAY],[DEN_NGAY],[CVPT]
FROM 
(
SELECT DISTINCT
 T2.TEN_BO_PHAN, 
 CASE ISNULL(T3.THAO_TAC,'') WHEN '' THEN T4.MO_TA_CV  ELSE T4.MO_TA_CV+': '+ char(13) + T3.THAO_TAC END AS MO_TA_CV, 
dbo.GetNhanSuPBT(T3.MS_PHIEU_BAO_TRI, T3.MS_BO_PHAN, T3.MS_CV,0) AS NHAN_SU, T3.YEU_CAU_DUNG_CU,T3.SO_GIO_KH
,(SELECT 
	CONVERT(DATETIME,CONVERT(NVARCHAR(10), MIN(NGAY),101) + ' ' + CONVERT(NVARCHAR(10),MIN(TU_GIO),108) ) AS TU_NGAY 		
FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET A WHERE   A.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI AND A.MS_BO_PHAN = T3.MS_BO_PHAN AND A.MS_CV = T3.MS_CV
) AS TU_NGAY
,(SELECT 	
	CONVERT(DATETIME,CONVERT(NVARCHAR(10),MAX(DEN_NGAY),101) + ' ' + CONVERT(NVARCHAR(10),MAX(DEN_GIO),108) ) AS DEN_NGAY
FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET B WHERE   B.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI AND B.MS_BO_PHAN = T3.MS_BO_PHAN AND B.MS_CV = T3.MS_CV
) AS DEN_NGAY,0 AS CVPT
FROM         dbo.PHIEU_BAO_TRI AS T1 INNER JOIN
                      dbo.CAU_TRUC_THIET_BI AS T2 ON T1.MS_MAY = T2.MS_MAY INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC AS T3 ON T1.MS_PHIEU_BAO_TRI = T3.MS_PHIEU_BAO_TRI AND T2.MS_BO_PHAN = T3.MS_BO_PHAN INNER JOIN
                      dbo.CONG_VIEC AS T4 ON T3.MS_CV = T4.MS_CV
WHERE     (T1.MS_PHIEU_BAO_TRI = @MsPBT)  AND (T3.STT_SERVICE IS NULL)

UNION
SELECT   NULL AS BO_PHAN, TEN_CONG_VIEC,  dbo.GetNhanSuPBT(MS_PHIEU_BAO_TRI, '-1', STT,1) AS NHAN_SU,NULL AS YEU_CAU_DUNG_CU, SO_GIO_KH
,(SELECT CONVERT(DATETIME,CONVERT(NVARCHAR(10), MIN(NGAY),101) + ' ' + CONVERT(NVARCHAR(10),MIN(TU_GIO),108) ) AS TU_NGAY 		
FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO A WHERE   A.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI AND A.STT = T1.STT
) AS TU_NGAY
,(SELECT 	
	CONVERT(DATETIME,CONVERT(NVARCHAR(10),MAX(DEN_NGAY),101) + ' ' + CONVERT(NVARCHAR(10),MAX(DEN_GIO),108) ) AS DEN_NGAY
FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO B WHERE   B.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI AND B.STT = T1.STT
) AS DEN_NGAY ,1 AS CVPT
		FROM         dbo.PHIEU_BAO_TRI_CV_PHU_TRO T1
	WHERE     (MS_PHIEU_BAO_TRI = @MsPBT)
) A
ORDER BY CVPT,TEN_BO_PHAN, MO_TA_CV
SELECT * FROM @PBT_CV ORDER BY CVPT,TEN_BO_PHAN, MO_TA_CV


--INSERT INTO @PBT_CV (STT,[TEN_BO_PHAN],CVPT)
SELECT DISTINCT  STT,NULL AS [TEN_BO_PHAN],3  AS CVPT FROM @PBT_CV  ORDER BY STT



-- Lay thong tin phieu bao tri phu tung + vat tu
DECLARE @PBT_PT TABLE (
	[MS_PT] [nvarchar](25) NULL,
	[TEN_PT] [nvarchar](500) NULL,
	[MS_PT_NCC] [nvarchar](25) NULL,
	[TEN_DVT] [nvarchar](20) NULL,
	[SL_KH] [float] NULL,
	[SL_TT] [float] NULL,
	[QUY_CACH] [nvarchar](500) NULL
)
DECLARE @TTPBT INT
SELECT @TTPBT = ISNULL(TINH_TRANG_PBT,0) FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = @MsPBT

-- GET PHU TUNG
IF @TTPBT = 3
BEGIN
		INSERT INTO @PBT_PT ([MS_PT],[TEN_PT],[MS_PT_NCC],[TEN_DVT],[SL_KH],[SL_TT],QUY_CACH)
		SELECT     A.MS_PT, CASE ISNULL(A.TEN_PT_VIET,'') WHEN '' THEN A.TEN_PT ELSE A.TEN_PT_VIET END AS TEN_PT, A.MS_PT_NCC, 
			CASE @NNgu WHEN 0 THEN B.TEN_1 WHEN 1 THEN B.TEN_2 ELSE B.TEN_3 END AS TEN_DVT, 
			SUM(D.SL_KH) AS SL_KH, SUM(C.SL_TT) AS SL_TT, A.QUY_CACH
		FROM         dbo.IC_PHU_TUNG AS A INNER JOIN
                      dbo.DON_VI_TINH AS B ON A.DVT = B.DVT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO AS C ON A.MS_PT = C.MS_PTTT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS D ON C.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI AND C.MS_CV = D.MS_CV AND C.MS_BO_PHAN = D.MS_BO_PHAN AND 
                      C.MS_PT = D.MS_PT INNER JOIN
                      dbo.LOAI_VT AS E ON A.MS_LOAI_VT = E.MS_LOAI_VT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC AS F ON D.MS_PHIEU_BAO_TRI = F.MS_PHIEU_BAO_TRI AND D.MS_CV = F.MS_CV AND D.MS_BO_PHAN = F.MS_BO_PHAN
		WHERE     (C.MS_PHIEU_BAO_TRI = @MsPBT) AND (E.VAT_TU = 0) AND (F.STT_SERVICE IS NULL)
		GROUP BY A.MS_PT, A.TEN_PT,A.TEN_PT_VIET, A.QUY_CACH, A.MS_PT_NCC, B.TEN_1,B.TEN_2, B.TEN_3
END
ELSE
BEGIN
	IF @TTPBT > 3
	BEGIN
		INSERT INTO @PBT_PT ([MS_PT],[TEN_PT],[MS_PT_NCC],[TEN_DVT],[SL_KH],[SL_TT],QUY_CACH)
		SELECT     A.MS_PT, CASE ISNULL(A.TEN_PT_VIET,'') WHEN '' THEN A.TEN_PT ELSE A.TEN_PT_VIET END AS TEN_PT,A.MS_PT_NCC, 
			CASE @NNgu WHEN 0 THEN B.TEN_1 WHEN 1 THEN B.TEN_2 ELSE B.TEN_3 END AS TEN_DVT, 
			SUM(D.SL_KH) AS SL_KH, SUM(C.SL_TT) AS SL_TT,A.QUY_CACH
		FROM dbo.IC_PHU_TUNG AS A INNER JOIN
                      dbo.DON_VI_TINH AS B ON A.DVT = B.DVT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO AS C ON A.MS_PT = C.MS_PTTT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS D ON C.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI AND C.MS_CV = D.MS_CV AND C.MS_BO_PHAN = D.MS_BO_PHAN AND 
                      C.MS_PT = D.MS_PT INNER JOIN
                      dbo.LOAI_VT AS E ON A.MS_LOAI_VT = E.MS_LOAI_VT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC AS F ON D.MS_PHIEU_BAO_TRI = F.MS_PHIEU_BAO_TRI AND D.MS_CV = F.MS_CV AND D.MS_BO_PHAN = F.MS_BO_PHAN
		WHERE    (C.MS_PHIEU_BAO_TRI = @MsPBT) AND (E.VAT_TU = 0)  AND (F.STT_SERVICE IS NULL)
		GROUP BY A.MS_PT, A.TEN_PT,A.TEN_PT_VIET, A.QUY_CACH, A.MS_PT_NCC, B.TEN_1,B.TEN_2, B.TEN_3
	END 
	ELSE
	BEGIN
		INSERT INTO @PBT_PT ([MS_PT],[TEN_PT],[MS_PT_NCC],[TEN_DVT],[SL_KH],[SL_TT],QUY_CACH)
		SELECT     A.MS_PT, CASE ISNULL(B.TEN_PT_VIET,'') WHEN '' THEN B.TEN_PT ELSE B.TEN_PT_VIET END AS TEN_PT,B.MS_PT_NCC, 
			CASE @NNgu WHEN 0 THEN C.TEN_1 WHEN 1 THEN C.TEN_2 ELSE C.TEN_3 END AS TEN_DVT, 
			SUM(A.SL_KH) AS SL_KH, SUM(A.SL_TT) AS SL_TT,B.QUY_CACH
		FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS A INNER JOIN
                      dbo.IC_PHU_TUNG AS B ON A.MS_PT = B.MS_PT INNER JOIN
                      dbo.DON_VI_TINH AS C ON B.DVT = C.DVT INNER JOIN
                      dbo.LOAI_VT AS E ON B.MS_LOAI_VT = E.MS_LOAI_VT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC AS F ON A.MS_PHIEU_BAO_TRI = F.MS_PHIEU_BAO_TRI AND A.MS_CV = F.MS_CV AND A.MS_BO_PHAN = F.MS_BO_PHAN
		WHERE     (E.VAT_TU = 0) AND (A.MS_PHIEU_BAO_TRI = @MsPBT) AND (F.STT_SERVICE IS NULL)
		GROUP BY A.MS_PT, B.TEN_PT,B.TEN_PT_VIET, B.QUY_CACH, B.MS_PT_NCC,C.TEN_1, C.TEN_2, C.TEN_3
END
END

-- GET VAT TU
IF @TTPBT >=3 
BEGIN
		INSERT INTO @PBT_PT ([MS_PT],[TEN_PT],[MS_PT_NCC],[TEN_DVT],[SL_KH],[SL_TT],QUY_CACH)
		SELECT     A.MS_PT, CASE ISNULL(A.TEN_PT_VIET,'') WHEN '' THEN A.TEN_PT ELSE A.TEN_PT_VIET END AS TEN_PT, A.MS_PT_NCC, 
			CASE @NNgu WHEN 0 THEN E.TEN_1 WHEN 1 THEN E.TEN_2 ELSE E.TEN_3 END AS TEN_DVT, 
			SUM(F.SL_KH) AS SL_KH, SUM(G.SL_VT) AS SL_TT	, A.QUY_CACH
		FROM dbo.PHIEU_BAO_TRI_CONG_VIEC AS T1 INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS F ON T1.MS_PHIEU_BAO_TRI = F.MS_PHIEU_BAO_TRI AND T1.MS_CV = F.MS_CV AND T1.MS_BO_PHAN = F.MS_BO_PHAN RIGHT OUTER JOIN
                      dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS H INNER JOIN
                      dbo.IC_DON_HANG_NHAP_VAT_TU AS K ON H.MS_DH_NHAP_PT = K.MS_DH_NHAP_PT AND H.MS_PT = K.MS_PT AND H.ID = K.ID INNER JOIN
                      dbo.IC_PHU_TUNG AS A INNER JOIN
                      dbo.IC_DON_HANG_XUAT AS B INNER JOIN
                      dbo.IC_DON_HANG_XUAT_VAT_TU AS C ON B.MS_DH_XUAT_PT = C.MS_DH_XUAT_PT ON A.MS_PT = C.MS_PT INNER JOIN
                      dbo.LOAI_VT AS D ON A.MS_LOAI_VT = D.MS_LOAI_VT INNER JOIN
                      dbo.DON_VI_TINH AS E ON A.DVT = E.DVT INNER JOIN
                      dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS G ON C.MS_DH_XUAT_PT = G.MS_DH_XUAT_PT AND C.MS_PT = G.MS_PT ON H.MS_DH_NHAP_PT = G.MS_DH_NHAP_PT AND 
                      H.MS_PT = G.MS_PT AND H.MS_VI_TRI = G.MS_VI_TRI AND H.ID = G.ID_XUAT ON F.MS_PT = C.MS_PT AND F.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI LEFT OUTER JOIN
                      dbo.HANG_SAN_XUAT AS X ON A.MS_HSX = X.MS_HSX
		WHERE     (B.MS_PHIEU_BAO_TRI = @MsPBT) AND (D.VAT_TU = 1)  AND (T1.STT_SERVICE IS NULL)
		GROUP BY A.MS_PT, A.TEN_PT,A.TEN_PT_VIET, A.QUY_CACH, A.MS_PT_NCC, E.TEN_1,E.TEN_2, E.TEN_3
	
END
ELSE 
BEGIN
	
	INSERT INTO @PBT_PT ([MS_PT],[TEN_PT],[MS_PT_NCC],[TEN_DVT],[SL_KH],[SL_TT],QUY_CACH)
	SELECT     A.MS_PT, CASE ISNULL(A.TEN_PT_VIET,'') WHEN '' THEN A.TEN_PT ELSE A.TEN_PT_VIET END AS TEN_PT,A.MS_PT_NCC, 
			CASE @NNgu WHEN 0 THEN E.TEN_1 WHEN 1 THEN E.TEN_2 ELSE E.TEN_3 END AS TEN_DVT, 
			SUM(F.SL_KH) AS SL_KH, SUM(C.SO_LUONG_THUC_XUAT) AS SL_TT, A.QUY_CACH
	FROM dbo.PHIEU_BAO_TRI_CONG_VIEC AS T1 INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS F ON T1.MS_PHIEU_BAO_TRI = F.MS_PHIEU_BAO_TRI AND T1.MS_CV = F.MS_CV AND T1.MS_BO_PHAN = F.MS_BO_PHAN RIGHT OUTER JOIN
                      dbo.IC_PHU_TUNG AS A INNER JOIN
                      dbo.IC_DON_HANG_XUAT AS B INNER JOIN
                      dbo.IC_DON_HANG_XUAT_VAT_TU AS C ON B.MS_DH_XUAT_PT = C.MS_DH_XUAT_PT ON A.MS_PT = C.MS_PT INNER JOIN
                      dbo.LOAI_VT AS D ON A.MS_LOAI_VT = D.MS_LOAI_VT INNER JOIN
                      dbo.DON_VI_TINH AS E ON A.DVT = E.DVT ON F.MS_PT = C.MS_PT AND F.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI LEFT OUTER JOIN
                      dbo.HANG_SAN_XUAT AS X ON A.MS_HSX = X.MS_HSX
	WHERE     (D.VAT_TU = 1) AND (B.MS_PHIEU_BAO_TRI = @MsPBT) AND (T1.STT_SERVICE IS NULL)
	GROUP BY A.MS_PT, A.TEN_PT,A.TEN_PT_VIET, A.QUY_CACH, A.MS_PT_NCC, E.TEN_1,E.TEN_2, E.TEN_3
	UNION
	SELECT     A.MS_PT, CASE ISNULL(A.TEN_PT_VIET,'') WHEN '' THEN A.TEN_PT ELSE A.TEN_PT_VIET END AS TEN_PT,A.MS_PT_NCC, 
			CASE @NNgu WHEN 0 THEN D.TEN_1 WHEN 1 THEN D.TEN_2 ELSE D.TEN_3 END AS TEN_DVT, 
			SUM(B.SL_KH) AS SL_KH, SUM(B.SL_TT) AS SL_TT,A.QUY_CACH
	FROM dbo.IC_PHU_TUNG AS A INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS B ON A.MS_PT = B.MS_PT INNER JOIN
                      dbo.LOAI_VT AS C ON C.MS_LOAI_VT = A.MS_LOAI_VT INNER JOIN
                      dbo.DON_VI_TINH AS D ON A.DVT = D.DVT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC AS T1 ON B.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI AND B.MS_CV = T1.MS_CV AND B.MS_BO_PHAN = T1.MS_BO_PHAN LEFT OUTER JOIN
                      dbo.HANG_SAN_XUAT AS X ON A.MS_HSX = X.MS_HSX
	WHERE     (C.VAT_TU = 1) AND (B.MS_PHIEU_BAO_TRI = @MsPBT) AND (T1.STT_SERVICE IS NULL) AND (B.MS_PT NOT IN
							  (SELECT Y.MS_PT FROM dbo.IC_DON_HANG_XUAT AS X INNER JOIN dbo.IC_DON_HANG_XUAT_VAT_TU AS Y ON 
								X.MS_DH_XUAT_PT = Y.MS_DH_XUAT_PT WHERE (X.MS_PHIEU_BAO_TRI = @MsPBT)))
	GROUP BY A.MS_PT, A.TEN_PT,A.TEN_PT_VIET, A.QUY_CACH, A.MS_PT_NCC, D.TEN_1,D.TEN_2,D.TEN_3	
END

SELECT MS_PT,TEN_PT,MS_PT_NCC,QUY_CACH,TEN_DVT,SL_KH,SL_TT FROM @PBT_PT ORDER BY [MS_PT],[TEN_PT]

---- Lay thong tin phieu bao tri dich vu
SELECT   CONVERT(nvarchar,NULL) AS LOAI_DV, T1.NOI_DUNG_SERVICE, T2.TEN_CONG_TY, T1.SO_LUONG, T1.DON_GIA,
(T1.SO_LUONG * T1.DON_GIA ) * T1.TY_GIA AS TT
FROM         dbo.PHIEU_BAO_TRI_SERVICE AS T1 INNER JOIN
                      dbo.KHACH_HANG AS T2 ON T1.MS_KH = T2.MS_KH
WHERE     (T1.MS_PHIEU_BAO_TRI = @MsPBT)