
--DELETE dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT = 'PN-2010-0078'  AND SL_VT = 0
	--EXEC SP_Y_GET_DON_HANG_NHAP_VAT_TU_CHI_TIET
ALTER procedure [dbo].[SP_Y_GET_DON_HANG_NHAP_VAT_TU_CHI_TIET]
	@MsDHN NVARCHAR(14) = 'PN-2010-0078'
as
begin

      select MS_DH_NHAP_PT,MS_PT,T.MS_VI_TRI, T1.TEN_VI_TRI, SL_VT, ID      from IC_DON_HANG_NHAP_VAT_TU_CHI_TIET T 	  INNER JOIN VI_TRI_KHO T1 ON T.MS_VI_TRI = T1.MS_VI_TRI  	        WHERE MS_DH_NHAP_PT = @MsDHN       ORDER BY T1.TEN_VI_TRI
	  
	--SELECT DISTINCT T2.MS_DH_NHAP_PT,T2.MS_PT,T2.MS_VI_TRI,T2.TEN_VI_TRI, T2.ID,ISNULL(T1.SL_VT,0) AS SL_VT FROM (
	--  SELECT T1.MS_DH_NHAP_PT, MS_PT,T2.MS_VI_TRI,ID,T2.TEN_VI_TRI FROM dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET T1, (SELECT * FROM dbo.VI_TRI_KHO WHERE MS_KHO = (SELECT MS_KHO FROM dbo.IC_DON_HANG_NHAP WHERE MS_DH_NHAP_PT = @MsDHN)) T2 
	--  WHERE MS_DH_NHAP_PT = @MsDHN ) T2 LEFT JOIN  dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET T1 ON	  
	--  T2.MS_DH_NHAP_PT = T1.MS_DH_NHAP_PT AND T2.ID = T1.ID AND T2.MS_PT = T1.MS_PT AND T2.MS_VI_TRI = T1.MS_VI_TRI ORDER BY T2.MS_DH_NHAP_PT,T2.MS_PT,T2.ID,T2.TEN_VI_TRI
   
   
end
