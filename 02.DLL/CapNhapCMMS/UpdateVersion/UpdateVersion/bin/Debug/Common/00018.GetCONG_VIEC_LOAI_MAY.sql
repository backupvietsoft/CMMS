--EXEC [dbo].[GetCONG_VIEC_LOAI_MAY] '-1', '-1','ADMIN' 

ALTER proc [dbo].[GetCONG_VIEC_LOAI_MAY]
	@MS_LOAI_MAY NVARCHAR(20),
	@MS_LOAI_CV NVARCHAR(20) ,
	@USERLOGED NVARCHAR(50)
AS
if @MS_LOAI_MAY <> '-1'
begin
SELECT DISTINCT [MS_CV], [MA_CV], [MO_TA_CV], CONG_VIEC.[MS_LOAI_CV],[KY_HIEU_CV],  [PATH_HD], CONG_VIEC.[MS_LOAI_MAY], [THOI_GIAN_DU_KIEN], [THAO_TAC], [TIEU_CHUAN_KT], [GHI_CHU], 
	[MS_CHUYEN_MON], [MS_BAC_THO],TEN_LOAI_MAY,AN_TOAN , DINH_MUC, NGOAI_TE,SO_NGUOI,YEU_CAU_NS,YEU_CAU_DUNG_CU
FROM CONG_VIEC INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY 
		INNER JOIN NHOM_LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV=NHOM_LOAI_CONG_VIEC.MS_LOAI_CV
		INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_CONG_VIEC.GROUP_ID
		INNER JOIN USERS ON USERS.GROUP_ID=NHOM.GROUP_ID
WHERE CONG_VIEC.MS_LOAI_MAY=@MS_LOAI_MAY AND USERS.USERNAME=@USERLOGED 
AND (@MS_LOAI_CV = '-1' OR CONG_VIEC.[MS_LOAI_CV] = @MS_LOAI_CV)
ORDER BY CONG_VIEC.MO_TA_CV
end
else
begin
		SELECT DISTINCT [MS_CV], [MA_CV], [MO_TA_CV], CONG_VIEC.[MS_LOAI_CV],[KY_HIEU_CV],  [PATH_HD], CONG_VIEC.[MS_LOAI_MAY], [THOI_GIAN_DU_KIEN], [THAO_TAC], [TIEU_CHUAN_KT], [GHI_CHU], 
			[MS_CHUYEN_MON], [MS_BAC_THO],TEN_LOAI_MAY,AN_TOAN , DINH_MUC, NGOAI_TE,SO_NGUOI,YEU_CAU_NS,YEU_CAU_DUNG_CU
		FROM CONG_VIEC INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY 
				INNER JOIN NHOM_LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV=NHOM_LOAI_CONG_VIEC.MS_LOAI_CV
				INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_CONG_VIEC.GROUP_ID
				INNER JOIN USERS ON USERS.GROUP_ID=NHOM.GROUP_ID
		WHERE USERS.USERNAME=@USERLOGED AND (@MS_LOAI_CV = '-1' OR CONG_VIEC.[MS_LOAI_CV] = @MS_LOAI_CV)
		ORDER BY CONG_VIEC.MO_TA_CV
end
