
--EXEC QL_LOAD_VAT_TU_KHO_VI_TRI 5 , 424

ALTER proc [dbo].[QL_LOAD_VAT_TU_KHO_VI_TRI]
	@MS_KHO INT,
	@MS_VI_TRI INT
AS
SELECT DISTINCT PT.MS_PT, VTKVT.MS_DH_NHAP_PT, VTKVT.SL_VT, 
	PT.MS_PT_NCC, PT.MS_PT_CTY, PT.TEN_PT, PT.QUY_CACH, VTKVT.ID AS ID_DC
FROM dbo.IC_PHU_TUNG AS PT INNER JOIN
	dbo.VI_TRI_KHO_VAT_TU AS VTKVT ON PT.MS_PT = VTKVT.MS_PT
WHERE VTKVT.MS_KHO=@MS_KHO
AND VTKVT.MS_VI_TRI=@MS_VI_TRI
AND VTKVT.SL_VT>0
order by MS_PT 