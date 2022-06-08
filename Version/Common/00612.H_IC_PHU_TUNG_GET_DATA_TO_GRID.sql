



IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'H_IC_PHU_TUNG_GET_DATA_TO_GRID')
   exec('CREATE PROCEDURE H_IC_PHU_TUNG_GET_DATA_TO_GRID AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE [dbo].[H_IC_PHU_TUNG_GET_DATA_TO_GRID] AS

SELECT DISTINCT 
                      PT.MS_PT, PT.TEN_PT,TEN_PT_VIET, PT.QUY_CACH, PT.MS_PT_CTY, PT.MS_PT_NCC,TEN_HSX, PT.ANH_PT, PT.MS_LOAI_VT, PT.MS_CACH_DAT_HANG, PT.SO_NGAY_DAT_MUA_HANG, 
                      PT.TON_TOI_THIEU, PT.DVT, PT.DUNG_CU_DO, PT.MS_KH, PT.MS_HSX, PT.MS_VI_TRI, PT.MS_CLASS, PT.TON_KHO_MAX, 
                      dbo.VI_TRI_KHO.MS_KHO,HANG_NGOAI,PT.SERVICE_ID , THEO_KHO,
                      ACTIVE_PT, USER_INSERT_PT,NGAY_INSERT_PT, USER_UPDATE_PT, NGAY_UPDATE_PT, KY_PB 
FROM         dbo.IC_PHU_TUNG PT INNER JOIN
                      dbo.IC_PHU_TUNG_LOAI_MAY ON PT.MS_PT = dbo.IC_PHU_TUNG_LOAI_MAY.MS_PT INNER JOIN
                      dbo.IC_PHU_TUNG_LOAI_PHU_TUNG ON PT.MS_PT = dbo.IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT LEFT OUTER JOIN
                      dbo.VI_TRI_KHO ON PT.MS_VI_TRI = dbo.VI_TRI_KHO.MS_VI_TRI
					LEFT JOIN HANG_SAN_XUAT HSX ON PT.MS_HSX = HSX.MS_HSX 
ORDER BY PT.MS_PT, PT.MS_PT_NCC, PT.MS_PT_CTY, PT.TEN_PT

