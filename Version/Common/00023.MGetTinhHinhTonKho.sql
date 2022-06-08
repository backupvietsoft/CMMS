
--EXEC MGetTinhHinhTonKho -1,'-1',-1,0,N'Hết kho', N'Thiếu',N'Đủ',N'Dư',N'ALL0'
ALTER PROCEDURE [dbo].[MGetTinhHinhTonKho]
		@MsKho int, 
		@MsLVTu nvarchar(10),
		@MsClass int,
		@NNgu int,
		@Het nvarchar(500),
		@Thieu nvarchar(500),
		@VuaDu nvarchar(500),
		@Du nvarchar(500),
		@All0 nvarchar(500)
as
--=0			Hết kho 0
--0<TT<min			Thiếu 1
--min<=TT<=max			Đủ 2
--Max<TT			Dư 3
--min = 0 max = 0 tt = 0 TON MIN = 0 TON = 0 TON MAX = 0

SELECT     T1.MS_PT, T1.MS_PT_CTY, T1.TEN_PT, T1.TEN_PT_VIET, T1.MS_PT_NCC, T1.QUY_CACH, T2.TEN_HSX, T4.TEN_CLASS, 
		ISNULL(T1.TTT, 0) AS TON_TOI_THIEU, ISNULL(T1.TTD, 0) AS TON_KHO_MAX, ISNULL(A.TON_TT, 0) AS TON_TT, T1.SO_NGAY_DAT_MUA_HANG, 
      CASE @NNgu WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT, 
      CONVERT(nvarchar(500), 
      CASE WHEN ISNULL(TON_TT, 0) <= 0 THEN 
		CASE WHEN ISNULL(TTT, 0) = 0 AND ISNULL(TTD, 0) = 0 AND ISNULL(TON_TT, 0) = 0 THEN @All0 ELSE @Het END
		  WHEN 0 < ISNULL(TON_TT, 0) AND ISNULL(TON_TT, 0) < ISNULL(TTT, 0) THEN @Thieu 
		  WHEN ISNULL(TTT, 0) <= ISNULL(TON_TT, 0) AND ISNULL(TON_TT, 0) <= ISNULL(TTD, 0) THEN @VuaDu 
		  WHEN ISNULL(TTD, 0) < ISNULL(TON_TT,0) THEN @Du 
		  
		  END
      ) AS TINH_TRANG, 
      CONVERT(INT, 
      CASE 
		WHEN ISNULL(TON_TT, 0) <= 0 THEN 
			CASE WHEN ISNULL(TTT, 0) = 0 AND ISNULL(TTD, 0) = 0 AND ISNULL(TON_TT, 0) = 0 THEN 4 ELSE 0 END 
		WHEN 0 < ISNULL(TON_TT, 0) AND ISNULL(TON_TT, 0) < ISNULL(TTT, 0) THEN 1 
		WHEN ISNULL(TTT, 0) <= ISNULL(TON_TT, 0) AND ISNULL(TON_TT, 0) <= ISNULL(TTD, 0) THEN 2 
		WHEN ISNULL(TTD, 0) < ISNULL(TON_TT, 0) THEN 3 
		END) AS TT
FROM (SELECT A.*, 
		CASE THEO_KHO WHEN 1 THEN ISNULL(TTT,0) ELSE ISNULL(TON_TOI_THIEU,0) END AS TTT, 
		CASE THEO_KHO WHEN 1 THEN ISNULL(TTD,0) ELSE ISNULL(TON_KHO_MAX,0) END AS TTD 
		FROM IC_PHU_TUNG A LEFT JOIN (SELECT MS_PT, SUM(TON_TOI_THIEU) AS TTT, SUM(TON_KHO_MAX) AS TTD FROM IC_PHU_TUNG_KHO 
	WHERE (@MsKho = - 1 OR MS_KHO = @MsKho) GROUP BY MS_PT) B ON A.MS_PT = B.MS_PT) AS T1 LEFT OUTER JOIN
                      dbo.HANG_SAN_XUAT AS T2 ON T1.MS_HSX = T2.MS_HSX LEFT OUTER JOIN
                      dbo.DON_VI_TINH AS T3 ON T1.DVT = T3.DVT LEFT OUTER JOIN
                      dbo.CLASS_VT AS T4 ON T1.MS_CLASS = T4.MS_CLASS LEFT OUTER JOIN
                          (SELECT     MS_PT, SUM(SL_VT) AS TON_TT
                            FROM          dbo.VI_TRI_KHO_VAT_TU
                            WHERE      (@MsKho = - 1 OR MS_KHO = @MsKho)
                            GROUP BY MS_PT) AS A ON A.MS_PT = T1.MS_PT
WHERE ('-1' = @MsLVTu OR T1.MS_LOAI_VT = @MsLVTu)
AND (-1 = @MsClass OR T1.MS_CLASS = @MsClass)