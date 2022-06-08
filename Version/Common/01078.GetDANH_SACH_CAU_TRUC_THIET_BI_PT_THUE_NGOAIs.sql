
ALTER procedure [dbo].[GetDANH_SACH_CAU_TRUC_THIET_BI_PT_THUE_NGOAIs]
@TYPE INT,
@MS_MAY NVARCHAR(30),
@MS_BO_PHAN NVARCHAR(50),
@USERNAME NVARCHAR(50),
@MS_PHIEU_BAO_TRI NVARCHAR(20),
@MS_CV INT
 AS

SELECT DISTINCT CONVERT(BIT, 0) CHON,CAU_TRUC_THIET_BI.MS_PT, IC_PHU_TUNG.TEN_PT, CAU_TRUC_THIET_BI.SO_LUONG AS SL_KH, LOAI_VT.TEN_LOAI_VT_TV,
 IC_PHU_TUNG.MS_PT_NCC, IC_PHU_TUNG.MS_PT_CTY,CASE @TYPE WHEN 0 THEN DON_VI_TINH.TEN_1 WHEN 1 THEN DON_VI_TINH.TEN_2 ELSE DON_VI_TINH.TEN_3 END AS TEN_1, 
'N' AS MS_PT_CHA, CAU_TRUC_THIET_BI.MS_MAY, CAU_TRUC_THIET_BI.MS_BO_PHAN  
FROM  CAU_TRUC_THIET_BI INNER JOIN IC_PHU_TUNG ON CAU_TRUC_THIET_BI.MS_PT = IC_PHU_TUNG.MS_PT 
INNER JOIN  IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT 
INNER JOIN  LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT 
INNER JOIN  NHOM_LOAI_PHU_TUNG ON LOAI_PHU_TUNG.MS_LOAI_PT = NHOM_LOAI_PHU_TUNG.MS_LOAI_PT 
INNER JOIN  NHOM ON NHOM_LOAI_PHU_TUNG.GROUP_ID = NHOM.GROUP_ID INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID 
INNER JOIN  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN LOAI_VT 
ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT 
 WHERE CAU_TRUC_THIET_BI.MS_MAY =@MS_MAY
AND CAU_TRUC_THIET_BI.MS_BO_PHAN = @MS_BO_PHAN  and USERNAME=@USERNAME
