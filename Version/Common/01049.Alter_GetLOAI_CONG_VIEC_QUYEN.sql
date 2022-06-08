--EXEC DBO.GetLOAI_CONG_VIEC_QUYEN 1
ALTER procedure [dbo].[GetLOAI_CONG_VIEC_QUYEN]
	@GROUP_ID INT
 AS

SELECT     dbo.LOAI_CONG_VIEC.MS_LOAI_CV, dbo.LOAI_CONG_VIEC.TEN_LOAI_CV, CASE NHOM_LOAI_CONG_VIEC.GROUP_ID 
			WHEN ISNULL(NHOM_LOAI_CONG_VIEC.GROUP_ID,0) THEN CONVERT(BIT,1)
			ELSE CONVERT(BIT,0) END AS CHON, CONVERT(BIT,'False') IS_UPDATE, @GROUP_ID GROUP_ID
FROM         dbo.LOAI_CONG_VIEC LEFT OUTER JOIN
                      dbo.NHOM_LOAI_CONG_VIEC ON dbo.LOAI_CONG_VIEC.MS_LOAI_CV = dbo.NHOM_LOAI_CONG_VIEC.MS_LOAI_CV AND NHOM_LOAI_CONG_VIEC.GROUP_ID =@GROUP_ID
