
--SELECT * FROM dbo.IC_PHU_TUNG_KHO WHERE MS_PT = 'BHL-009'
--exec MGetIcPTKho 'BHL-009'
ALTER PROCEDURE [dbo].[MGetIcPTKho] @MS_PT VARCHAR(25)
AS
    SELECT   DISTINCT
            dbo.IC_KHO.TEN_KHO, ISNULL(T.SL_VT, 0) TON_HT,
            ISNULL(dbo.IC_PHU_TUNG_KHO.TON_TOI_THIEU, 0) AS TON_TOI_THIEU,
            ISNULL(dbo.IC_PHU_TUNG_KHO.TON_KHO_MAX, 0) AS TON_KHO_MAX,
            SO_NGAY_DAT_MUA_HANG, dbo.VI_TRI_KHO.TEN_VI_TRI,
            dbo.IC_PHU_TUNG_KHO.GHI_CHU, dbo.IC_PHU_TUNG_KHO.MS_PT,
            dbo.IC_PHU_TUNG_KHO.MS_KHO, dbo.IC_PHU_TUNG_KHO.MS_VI_TRI
    FROM    dbo.IC_PHU_TUNG_KHO
            INNER JOIN dbo.IC_KHO ON dbo.IC_PHU_TUNG_KHO.MS_KHO = dbo.IC_KHO.MS_KHO
            LEFT OUTER JOIN dbo.VI_TRI_KHO ON dbo.IC_PHU_TUNG_KHO.MS_VI_TRI = dbo.VI_TRI_KHO.MS_VI_TRI
                                              AND dbo.IC_PHU_TUNG_KHO.MS_KHO = dbo.VI_TRI_KHO.MS_KHO
            LEFT JOIN ( SELECT  MS_PT, SUM(SL_VT) AS SL_VT, MS_KHO
                        FROM    VI_TRI_KHO_VAT_TU
                        WHERE   ISNULL(SL_VT, 0) > 0
                        GROUP BY MS_PT, MS_KHO
                      ) T ON VI_TRI_KHO.MS_KHO = T.MS_KHO
                             AND IC_PHU_TUNG_KHO.MS_PT = T.MS_PT
    WHERE   ( dbo.IC_PHU_TUNG_KHO.MS_PT = @MS_PT )
    ORDER BY dbo.IC_KHO.TEN_KHO, dbo.VI_TRI_KHO.TEN_VI_TRI
