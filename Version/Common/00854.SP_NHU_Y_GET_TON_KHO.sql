
---EXEC SP_NHU_Y_GET_TON_KHO 21,'12-19-2016','12-20-2016',0,'ADMIN'

ALTER PROCEDURE [dbo].[SP_NHU_Y_GET_TON_KHO]
	@MS_KHO INT ,
	@TU_NGAY DATETIME ,
	@DEN_NGAY DATETIME ,
	@TYPE_LANGUAGE INT ,
	@UserName NVARCHAR(50)
AS
BEGIN


SELECT  DISTINCT T1.MS_KHO, T1.TEN_KHO INTO #KHO_USER
FROM            dbo.IC_KHO AS T1 INNER JOIN
                         dbo.NHOM_KHO AS T2 ON T1.MS_KHO = T2.MS_KHO INNER JOIN
                         dbo.USERS AS T3 ON T2.GROUP_ID = T3.GROUP_ID
WHERE        (T3.USERNAME = @UserName)

--Lấy tồn hiện tại
SELECT dbo.VI_TRI_KHO_VAT_TU.MS_PT,VI_TRI_KHO_VAT_TU.MS_VI_TRI, SUM (dbo.VI_TRI_KHO_VAT_TU.SL_VT) AS SL_TON_HT
INTO #TON_HT
FROM dbo.VI_TRI_KHO_VAT_TU  INNER JOIN #KHO_USER T2 ON VI_TRI_KHO_VAT_TU.MS_KHO = T2.MS_KHO
where (dbo.VI_TRI_KHO_VAT_TU.MS_KHO = @MS_KHO OR @MS_KHO = -1)
GROUP BY dbo.VI_TRI_KHO_VAT_TU.MS_PT,VI_TRI_KHO_VAT_TU.MS_VI_TRI 

--Lấy số lượng xuất từ đến ngày đến hiện tại
SELECT        T4.MS_PT, T4.MS_VI_TRI, SUM(T4.SL_VT) AS SL_XUAT_TMP
INTO #XUAT_HT
FROM            dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN
                         dbo.IC_DON_HANG_XUAT_VAT_TU AS T3 ON T1.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT INNER JOIN
                         dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T4 ON T3.MS_DH_XUAT_PT = T4.MS_DH_XUAT_PT AND T3.MS_PT = T4.MS_PT INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE (T1.NGAY > @DEN_NGAY)  AND (T1.MS_KHO = @MS_KHO OR @MS_KHO = -1) 
GROUP BY T4.MS_PT, T4.MS_VI_TRI

--Lấy số lượng xuất trong khoảng từ ngày đến ngày
SELECT        T4.MS_PT, T4.MS_VI_TRI, SUM(T4.SL_VT) AS SL_XUAT
INTO #XUAT_TK
FROM            dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN
                         dbo.IC_DON_HANG_XUAT_VAT_TU AS T3 ON T1.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT INNER JOIN
                         dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T4 ON T3.MS_DH_XUAT_PT = T4.MS_DH_XUAT_PT AND T3.MS_PT = T4.MS_PT INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE        (T1.NGAY >= @TU_NGAY) AND (T1.MS_KHO = @MS_KHO) AND (T1.NGAY <= @DEN_NGAY) OR
                         (@MS_KHO = - 1) AND (T1.NGAY >= @TU_NGAY) AND (T1.NGAY <= @DEN_NGAY)
GROUP BY T4.MS_PT, T4.MS_VI_TRI

--Lấy số lượng nhập từ đến ngày đến hiện tại
SELECT        T4.MS_PT, T4.MS_VI_TRI, SUM(T4.SL_VT) AS SL_NHAP_TMP
INTO #NHAP_HT
FROM            dbo.IC_DON_HANG_NHAP AS T1 INNER JOIN
                         dbo.IC_DON_HANG_NHAP_VAT_TU AS T3 ON T1.MS_DH_NHAP_PT = T3.MS_DH_NHAP_PT INNER JOIN
                         dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS T4 ON T3.MS_DH_NHAP_PT = T4.MS_DH_NHAP_PT AND T3.ID = T4.ID AND T3.MS_PT = T4.MS_PT INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE (T1.NGAY > @DEN_NGAY  ) AND (T1.MS_KHO = @MS_KHO OR @MS_KHO = -1)
GROUP BY T4.MS_PT, T4.MS_VI_TRI

--Lấy số lượng nhập từ ngày đến ngày
SELECT        T4.MS_PT, T4.MS_VI_TRI, SUM(T4.SL_VT) AS SL_NHAP
INTO #NHAP_TN_DN
FROM            dbo.IC_DON_HANG_NHAP AS T1 INNER JOIN
                         dbo.IC_DON_HANG_NHAP_VAT_TU AS T3 ON T1.MS_DH_NHAP_PT = T3.MS_DH_NHAP_PT INNER JOIN
                         dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS T4 ON T3.MS_DH_NHAP_PT = T4.MS_DH_NHAP_PT AND T3.MS_PT = T4.MS_PT AND T3.ID = T4.ID INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE        (T1.MS_KHO = @MS_KHO OR @MS_KHO = -1) AND (T1.NGAY >= @TU_NGAY) AND (T1.NGAY <= @DEN_NGAY)
GROUP BY T4.MS_PT, T4.MS_VI_TRI

--Lấy số lượng di chuyển đi từ đến ngày đến hiện tại
SELECT        T1.MS_PT, T1.MS_VI_TRI, SUM(T1.SL_CHUYEN) AS SL_CHUYEN_DI_TMP
INTO #DC_DI_HT
FROM            dbo.DI_CHUYEN_VI_TRI_TRONG_KHO AS T1 INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE (T1.NGAY_CHUYEN > @DEN_NGAY)  AND (T1.MS_KHO = @MS_KHO OR @MS_KHO = -1)
GROUP BY T1.MS_PT, T1.MS_VI_TRI

--Lấy số lượng di chuyển đi từ ngày đến ngày
SELECT        T1.MS_PT, T1.MS_VI_TRI, SUM(T1.SL_CHUYEN) AS SL_CHUYEN_DI
INTO #DC_DI_TN_DN
FROM            dbo.DI_CHUYEN_VI_TRI_TRONG_KHO AS T1 INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE (T1.NGAY_CHUYEN >= @TU_NGAY) AND (T1.NGAY_CHUYEN <= @DEN_NGAY) AND (T1.MS_KHO  = @MS_KHO OR @MS_KHO = -1)
GROUP BY T1.MS_PT, T1.MS_VI_TRI


--Lấy số lượng di chuyển đến từ đến ngày đến hiện tại
SELECT        T1.MS_PT, T1.MS_VI_TRI_1 AS MS_VI_TRI, SUM(T1.SL_CHUYEN) AS SL_CHUYEN_DEN_TMP
INTO #DC_DEN_HT
FROM            dbo.DI_CHUYEN_VI_TRI_TRONG_KHO AS T1 INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO_1 = T2.MS_KHO
WHERE (T1.NGAY_CHUYEN > @DEN_NGAY) AND (T1.MS_KHO_1 = @MS_KHO OR @MS_KHO = -1)
GROUP BY T1.MS_PT, T1.MS_VI_TRI_1

--Lấy số lượng di chuyển đến từ ngày đến ngày
SELECT        T1.MS_PT, T1.MS_VI_TRI_1 AS MS_VI_TRI, SUM(T1.SL_CHUYEN) AS SL_CHUYEN_DEN
INTO #DC_DEN_TN_DN
FROM            dbo.DI_CHUYEN_VI_TRI_TRONG_KHO AS T1 INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO_1 = T2.MS_KHO
WHERE (T1.NGAY_CHUYEN >= @TU_NGAY) AND (T1.NGAY_CHUYEN <= @DEN_NGAY) AND (T1.MS_KHO_1 = @MS_KHO OR @MS_KHO = -1)
GROUP BY T1.MS_PT, T1.MS_VI_TRI_1

--Tính chênh lệch kiểm kê từ đến ngày đến hiện tại
SELECT        T1.MS_PT, T1.MS_VI_TRI, SUM(T1.SL_KK_CT - T1.SL_CHUNG_TU) AS CHENH_LECH_KIEM_KE_TMP
INTO #CL_KK_HT
FROM            dbo.KIEM_KE_VAT_TU_CHI_TIET AS T1 INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE (T1.NGAY > @DEN_NGAY ) AND (T1.MS_KHO = @MS_KHO OR @MS_KHO = -1)
GROUP BY T1.MS_PT, T1.MS_VI_TRI

--Tính chênh lệch kiểm kê từ ngày đến ngày
SELECT        T1.MS_PT, T1.MS_VI_TRI, SUM(T1.SL_KK_CT - T1.SL_CHUNG_TU) AS CHENH_LECH_KIEM_KE
INTO #CL_KK_TN_DN
FROM            dbo.KIEM_KE_VAT_TU_CHI_TIET AS T1 INNER JOIN
                         #KHO_USER AS T2 ON T1.MS_KHO = T2.MS_KHO
WHERE (T1.NGAY >= @TU_NGAY) AND (T1.NGAY <= @DEN_NGAY )
	AND (T1.MS_KHO = @MS_KHO OR @MS_KHO = -1)GROUP BY T1.MS_PT, T1.MS_VI_TRI

SELECT    A.MS_PT, A.TEN_PT,A.QUY_CACH, CASE @TYPE_LANGUAGE WHEN 0 THEN B.TEN_1 ELSE B.TEN_2 END AS TEN_DVT , SUM (CASE WHEN C.SL_TON_HT IS NULL THEN 0 ELSE  C.SL_TON_HT END ) AS SL_TON_HT ,SUM ( CASE WHEN  D.SL_XUAT_TMP IS NULL THEN 0 ELSE D.SL_XUAT_TMP END ) AS SL_XUAT_TMP ,
SUM (CASE WHEN E.SL_XUAT IS NULL THEN 0 ELSE E.SL_XUAT END ) AS SL_XUAT , SUM ( CASE WHEN F.SL_NHAP_TMP IS NULL THEN 0 ELSE F.SL_NHAP_TMP END ) AS SL_NHAP_TMP ,
SUM (CASE WHEN  G.SL_NHAP IS NULL THEN 0 ELSE G.SL_NHAP END ) AS SL_NHAP , SUM ( CASE WHEN H.SL_CHUYEN_DI_TMP IS NULL THEN 0 ELSE H.SL_CHUYEN_DI_TMP END ) AS SL_CHUYEN_DI_TMP  ,
SUM ( CASE WHEN  I.SL_CHUYEN_DI IS NULL THEN 0 ELSE I.SL_CHUYEN_DI END ) AS SL_CHUYEN_DI , SUM ( CASE WHEN  J.SL_CHUYEN_DEN_TMP IS NULL THEN 0 ELSE  J.SL_CHUYEN_DEN_TMP END ) AS SL_CHUYEN_DEN_TMP ,
SUM ( CASE WHEN  K.SL_CHUYEN_DEN IS NULL THEN 0 ELSE K.SL_CHUYEN_DEN END ) AS SL_CHUYEN_DEN ,SUM(CASE  WHEN L.CHENH_LECH_KIEM_KE_TMP IS NULL THEN 0 ELSE L.CHENH_LECH_KIEM_KE_TMP END ) AS CHENH_LECH_KIEM_KE_TMP  ,
SUM (CASE WHEN M.CHENH_LECH_KIEM_KE IS NULL THEN 0 ELSE M.CHENH_LECH_KIEM_KE END ) AS CHENH_LECH_KIEM_KE 
INTO #TON_KHO_KHONG_THEO_VI_TRI_TMP_NHU_Y
FROM dbo.IC_PHU_TUNG A INNER JOIN dbo.DON_VI_TINH B ON A.DVT = B.DVT LEFT JOIN 
--Lấy tồn hiện tại
#TON_HT C ON A.MS_PT = C.MS_PT 
LEFT OUTER JOIN 
--Lấy số lượng xuất từ đến ngày đến hiện tại
#XUAT_HT D ON C.MS_PT = D.MS_PT AND C.MS_VI_TRI = D.MS_VI_TRI 
LEFT OUTER JOIN 
--Lấy số lượng xuất trong khoảng từ ngày đến ngày
#XUAT_TK E ON C.MS_PT = E.MS_PT AND C.MS_VI_TRI = E.MS_VI_TRI 
LEFT OUTER JOIN 
--Lấy số lượng nhập từ đến ngày đến hiện tại
#NHAP_HT F ON C.MS_PT = F.MS_PT AND C.MS_VI_TRI = F.MS_VI_TRI 
LEFT OUTER JOIN
--Lấy số lượng nhập từ ngày đến ngày
#NHAP_TN_DN G ON C.MS_PT = G.MS_PT AND C.MS_VI_TRI = G.MS_VI_TRI 
LEFT OUTER JOIN 
--Lấy số lượng di chuyển đi từ đến ngày đến hiện tại
#DC_DI_HT H ON C.MS_PT = H.MS_PT AND C.MS_VI_TRI = H.MS_VI_TRI 
LEFT OUTER JOIN 
--Lấy số lượng di chuyển đi từ ngày đến ngày
#DC_DI_TN_DN I ON C.MS_PT = I.MS_PT AND C.MS_VI_TRI = I.MS_VI_TRI 
LEFT OUTER JOIN 
--Lấy số lượng di chuyển đến từ đến ngày đến hiện tại
#DC_DEN_HT J ON C.MS_PT = J.MS_PT AND C.MS_VI_TRI = J.MS_VI_TRI 
LEFT OUTER JOIN 
--Lấy số lượng di chuyển đến từ ngày đến ngày
#DC_DEN_TN_DN K ON C.MS_PT = K.MS_PT AND C.MS_VI_TRI = K.MS_VI_TRI
LEFT OUTER JOIN
--Tính chênh lệch kiểm kê từ đến ngày đến hiện tại
#CL_KK_HT L ON C.MS_PT = L.MS_PT AND C.MS_VI_TRI = L.MS_VI_TRI 
LEFT OUTER JOIN 
--Tính chênh lệch kiểm kê từ ngày đến ngày
#CL_KK_TN_DN M ON C.MS_PT = M.MS_PT AND C.MS_VI_TRI = M.MS_VI_TRI
GROUP BY  A.MS_PT, A.TEN_PT ,A.QUY_CACH , B.TEN_1 , B.TEN_2  


--NHAP XAC
SELECT T2.*
INTO #NHAP_XAC
FROM            dbo.IC_DON_HANG_NHAP_X_VAT_TU AS T2 INNER JOIN
                         dbo.IC_DON_HANG_NHAP_X AS T1 ON T1.MS_DH_NHAP_PT = T2.MS_DH_NHAP_PT
WHERE (T1.NGAY >= @TU_NGAY) AND (T1.NGAY < @DEN_NGAY )
	AND (T1.MS_KHO = @MS_KHO OR @MS_KHO = -1)


   select temp.ms_pt,temp.ten_pt,temp.quy_cach,temp.ten_dvt,
          tondauky = temp.SL_TON_HT + temp.SL_XUAT_TMP+ temp.SL_XUAT + temp.SL_CHUYEN_DI_TMP + temp.SL_CHUYEN_DI - temp.SL_NHAP_TMP - temp.SL_NHAP - temp.SL_CHUYEN_DEN_TMP - temp.SL_CHUYEN_DEN -  temp.CHENH_LECH_KIEM_KE_TMP -  temp.CHENH_LECH_KIEM_KE,         
           temp.sl_nhap,temp.sl_xuat,temp.chenh_lech_kiem_ke  ,dichuyen = temp.SL_CHUYEN_DEN - temp.SL_CHUYEN_DI          
          ,toncuoiky = temp.SL_TON_HT + temp.SL_XUAT_TMP - temp.SL_NHAP_TMP  - temp.SL_CHUYEN_DEN_TMP + temp.SL_CHUYEN_DI_TMP - temp.CHENH_LECH_KIEM_KE_TMP , 
         
          
          ISNULL(TEMP1.SL_THUC_NHAP,0) AS SL_CU,ghi_chu='' 
	from #TON_KHO_KHONG_THEO_VI_TRI_TMP_NHU_Y as temp
	LEFT JOIN 
	(	SELECT TEMP.*,A.MS_PT,A.SL_THUC_NHAP FROM
		(
			select MS_DH_NHAP_PT,SO_DE_XUAT  from IC_DON_HANG_NHAP_X T1 INNER JOIN #KHO_USER T2 ON T1.MS_KHO = T2.MS_KHO
			WHERE SO_DE_XUAT IS NOT NULL AND SO_DE_XUAT<>'' AND SO_DE_XUAT<>'-1'
		) TEMP INNER JOIN #NHAP_XAC  A ON TEMP.MS_DH_NHAP_PT=A.MS_DH_NHAP_PT
	)TEMP1 ON  TEMP.MS_PT=TEMP1.MS_PT
END
