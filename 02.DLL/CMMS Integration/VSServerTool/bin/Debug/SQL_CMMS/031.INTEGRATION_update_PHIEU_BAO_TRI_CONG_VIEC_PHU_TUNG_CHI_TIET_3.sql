CREATE procedure [dbo].[INTEGRATION_update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_3]

	(@MS_BO_PHAN_3 	[nvarchar](50),
	 @MS_PT_4 	[nvarchar](25),
	 @MS_VI_TRI_PT_11 	[nvarchar](30),
	 @SL_KH_12	[float],
	 @SL_ALLOCATED_12	[float],
	 @MS_CV_2 	[int],
	 @VICT_NHA_THAU_14 	[bit],
	 @MS_PT1_19 	[nvarchar](25),
	 @SL_TT_13 	[float],	
	 @NGUOI_THAY_THE_15	[nvarchar](80),
	 @NGAY_THAY_THE_16 	[datetime],
	 @DON_GIA_20 	[float],
	 @NGOAI_TE_21	[nvarchar](50),
	 @TY_GIA_22 	[float],
	 @TY_GIA_USD_23 	[float],
 	@STT_5 INT  , 
	 @MS_DH_NHAP_PT_18	[nvarchar](14),	
	 @GHI_CHU_24 	[nvarchar](512) , 
	@MS_PHIEU_BAO_TRI_1 	[nvarchar](20))

AS UPDATE [dbo].[PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG] 

SET   	
	 [SL_TT]	 =  (SELECT  SUM (CASE when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT  IS NULL THEN 0 ELSE dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT END ) 
	FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET
	WHERE 
	( [MS_PHIEU_BAO_TRI]	 = @MS_PHIEU_BAO_TRI_1 AND
		 [MS_CV]	 = @MS_CV_2 AND
		 [MS_BO_PHAN]	 = @MS_BO_PHAN_3 AND
		 [MS_PT]	 = @MS_PT_4 
		)),
	[SL_ALLOCATED] = (SELECT  SUM (CASE when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_ALLOCATED  IS NULL THEN 0 ELSE dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_ALLOCATED END ) 
	FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET
	WHERE 
	( [MS_PHIEU_BAO_TRI]	 = @MS_PHIEU_BAO_TRI_1 AND
		 [MS_CV]	 = @MS_CV_2 AND
		 [MS_BO_PHAN]	 = @MS_BO_PHAN_3 AND
		 [MS_PT]	 = @MS_PT_4 
		))
WHERE 
	( [MS_PHIEU_BAO_TRI]	 = @MS_PHIEU_BAO_TRI_1 AND
	 [MS_CV]	 = @MS_CV_2 AND
	 [MS_BO_PHAN]	 = @MS_BO_PHAN_3 AND
	 [MS_PT]	 = @MS_PT_4 
	)

