
--EXEC H_GET_PHAN_TICH_GIA_TRI_HANG_TON_KHO -1
ALTER procedure [dbo].[H_GET_PHAN_TICH_GIA_TRI_HANG_TON_KHO] 
	
	@MS_KHO INT, 
	@USERNAME NVARCHAR(255)

AS

		SELECT  distinct  IC_KHO.MS_KHO, IC_KHO.TEN_KHO INTO #KHO
		FROM         IC_KHO LEFT JOIN
							  IC_DON_HANG_NHAP ON IC_KHO.MS_KHO = IC_DON_HANG_NHAP.MS_KHO INNER JOIN
							  NHOM_KHO ON IC_KHO.MS_KHO = NHOM_KHO.MS_KHO INNER JOIN
							  NHOM ON NHOM_KHO.GROUP_ID = NHOM.GROUP_ID INNER JOIN
							  USERS ON NHOM.GROUP_ID = USERS.GROUP_ID
		WHERE     (USERS.USERNAME = @USERNAME) AND (IC_KHO.MS_KHO = @MS_KHO OR @MS_KHO = -1)


--DON_GIA gồm phí là đơn giá cuối cùng đã nhân tỷ giá đổi ra VNĐ nên k cần nhân tỷ giá lại nữa
SELECT     A.MS_KHO, C.TEN_KHO, A.MS_PT, B.TEN_PT, B.QUY_CACH, B.MS_PT_NCC, SUM(A.SL_VT) AS SO_LUONG, SUM(A.SL_VT * E.DON_GIA) AS GIA_TRI, 1 AS ID,
	AVG(CASE THEO_KHO WHEN 1 THEN ISNULL(TTT,0) ELSE ISNULL(TON_TOI_THIEU,0) END) AS TTT, 
	AVG(CASE THEO_KHO WHEN 1 THEN ISNULL(TTD,0) ELSE ISNULL(TON_KHO_MAX,0) END) AS TTD  
FROM            dbo.VI_TRI_KHO_VAT_TU AS A INNER JOIN
                         dbo.IC_PHU_TUNG AS B ON A.MS_PT = B.MS_PT INNER JOIN
                         dbo.#KHO AS C ON A.MS_KHO = C.MS_KHO INNER JOIN
                         dbo.IC_DON_HANG_NHAP_VAT_TU AS E ON A.MS_DH_NHAP_PT = E.MS_DH_NHAP_PT AND A.MS_PT = E.MS_PT AND A.ID = E.ID LEFT OUTER JOIN
                             (SELECT        MS_PT, SUM(TON_TOI_THIEU) AS TTT, SUM(TON_KHO_MAX) AS TTD, MS_KHO
                               FROM            dbo.IC_PHU_TUNG_KHO AS A
                               GROUP BY MS_PT, MS_KHO) AS F ON F.MS_PT = A.MS_PT AND A.MS_KHO = F.MS_KHO
GROUP BY A.MS_KHO, C.TEN_KHO, A.MS_PT, B.TEN_PT, B.QUY_CACH, B.MS_PT_NCC, THEO_KHO
HAVING      (SUM(A.SL_VT) > 0)       
ORDER BY      A.MS_KHO, C.TEN_KHO, A.MS_PT, B.TEN_PT          

drop table #KHO