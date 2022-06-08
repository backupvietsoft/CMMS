


ALTER procedure [dbo].[SP_NHU_Y_GET_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG]
@MS_PHIEU_BAO_TRI NVARCHAR(20),
@MS_CV INT,
@MS_BO_PHAN NVARCHAR(50)

 AS

SELECT DISTINCT T1.MS_PHIEU_BAO_TRI, T1.MS_CV, T1.MS_BO_PHAN, T1.MS_PT, T2.TEN_PT, T2.TEN_PT_VIET, T1.SL_KH, T1.SL_TT, 
	T1.GHI_CHU, T2.MS_PT_NCC, T2.MS_PT_CTY, T1.DON_GIA, T1.NGOAI_TE, T1.TY_GIA, T1.TY_GIA_USD, 
	dbo.LOAI_VT.VAT_TU, MS_PT_TT,CONVERT(BIT,0) AS VTPT, T2.QUY_CACH
FROM         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T1 INNER JOIN
                      dbo.IC_PHU_TUNG T2 ON T1.MS_PT = T2.MS_PT INNER JOIN
                      dbo.LOAI_VT ON T2.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT
WHERE MS_CV=@MS_CV  and MS_BO_PHAN=@MS_BO_PHAN  and MS_PHIEU_BAO_TRI=@MS_PHIEU_BAO_TRI
