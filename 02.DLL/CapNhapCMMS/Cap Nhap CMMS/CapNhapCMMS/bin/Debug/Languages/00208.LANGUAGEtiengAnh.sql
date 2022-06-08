

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'lblfrmThongtinthietbiAnh') UPDATE LANGUAGES SET VIETNAM=N'Tên bộ phận (tiếng Anh)', ENGLISH=N'Part name (English)', VIETNAM_OR=N'Tên bộ phận (tiếng Anh)', ENGLISH_OR=N'Part name (English)' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'lblfrmThongtinthietbiAnh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'lblfrmThongtinthietbiAnh',N'Tên bộ phận (tiếng Anh)',N'Part name (English)',N'Tên bộ phận (tiếng Anh)',N'Part name (English)')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'lblfrmThongtinthietbi_may_Anh') UPDATE LANGUAGES SET VIETNAM=N'Tên máy (tiếng Anh)', ENGLISH=N'Equipment name (English)', VIETNAM_OR=N'Tên máy (tiếng Anh)', ENGLISH_OR=N'Equipment name (English)' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'lblfrmThongtinthietbi_may_Anh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'lblfrmThongtinthietbi_may_Anh',N'Tên máy (tiếng Anh)',N'Equipment name (English)',N'Tên máy (tiếng Anh)',N'Equipment name (English)')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNguyenNhanDungMay' AND KEYWORD =N'lblNguyenNhanNgungMayAnh') UPDATE LANGUAGES SET VIETNAM=N'Nguyên nhân ngừng máy (tiếng Anh)', ENGLISH=N'Downtime cause (English)', VIETNAM_OR=N'Nguyên nhân ngừng máy (tiếng Anh)', ENGLISH_OR=N'Downtime cause (English)' WHERE FORM=N'frmNguyenNhanDungMay' AND KEYWORD=N'lblNguyenNhanNgungMayAnh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmNguyenNhanDungMay',N'lblNguyenNhanNgungMayAnh',N'Nguyên nhân ngừng máy (tiếng Anh)',N'Downtime cause (English)',N'Nguyên nhân ngừng máy (tiếng Anh)',N'Downtime cause (English)')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'lblfrmThongtinthietbi_bo_phan_Anh') UPDATE LANGUAGES SET VIETNAM=N'Tên bộ phận (tiếng Anh)', ENGLISH=N'Part name (English)', VIETNAM_OR=N'Tên bộ phận (tiếng Anh)', ENGLISH_OR=N'Part name (English)' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'lblfrmThongtinthietbi_bo_phan_Anh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'lblfrmThongtinthietbi_bo_phan_Anh',N'Tên bộ phận (tiếng Anh)',N'Part name (English)',N'Tên bộ phận (tiếng Anh)',N'Part name (English)')


IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_PT_ANH') and Object_ID = Object_ID(N'IC_PHU_TUNG'))
BEGIN
		ALTER TABLE IC_PHU_TUNG ADD TEN_PT_ANH NVARCHAR(250)		
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_PT_HOA') and Object_ID = Object_ID(N'IC_PHU_TUNG'))
BEGIN
		ALTER TABLE IC_PHU_TUNG ADD TEN_PT_HOA NVARCHAR(250)	
END



IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_HE_THONG_ANH') and Object_ID = Object_ID(N'HE_THONG'))
BEGIN
		ALTER TABLE HE_THONG ADD TEN_HE_THONG_ANH NVARCHAR(250)
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_HE_THONG_HOA') and Object_ID = Object_ID(N'HE_THONG'))
BEGIN	
		ALTER TABLE HE_THONG ADD TEN_HE_THONG_HOA NVARCHAR(250)
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_BO_PHAN_ANH') and Object_ID = Object_ID(N'CAU_TRUC_THIET_BI'))
BEGIN
		ALTER TABLE CAU_TRUC_THIET_BI ADD TEN_BO_PHAN_ANH NVARCHAR(250)
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_BO_PHAN_HOA') and Object_ID = Object_ID(N'CAU_TRUC_THIET_BI'))
BEGIN	
		ALTER TABLE CAU_TRUC_THIET_BI ADD TEN_BO_PHAN_HOA NVARCHAR(250)
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_MAY_ANH') and Object_ID = Object_ID(N'MAY'))
BEGIN
		ALTER TABLE MAY ADD TEN_MAY_ANH NVARCHAR(250)		
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_MAY_HOA') and Object_ID = Object_ID(N'MAY'))
BEGIN
		ALTER TABLE MAY ADD TEN_MAY_HOA NVARCHAR(250)	
END

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_PT_ANH') and Object_ID = Object_ID(N'IC_PHU_TUNG'))
BEGIN
		ALTER TABLE IC_PHU_TUNG ADD TEN_PT_ANH NVARCHAR(250)		
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_PT_HOA') and Object_ID = Object_ID(N'IC_PHU_TUNG'))
BEGIN
		ALTER TABLE IC_PHU_TUNG ADD TEN_PT_HOA NVARCHAR(250)	
END

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_TS_GSTT_ANH') and Object_ID = Object_ID(N'THONG_SO_GSTT'))
BEGIN
		ALTER TABLE THONG_SO_GSTT ADD TEN_TS_GSTT_ANH NVARCHAR(250)		
END	

IF NOT EXISTS(select * from sys.columns 
            where Name IN (N'TEN_TS_GSTT_HOA') and Object_ID = Object_ID(N'THONG_SO_GSTT'))
BEGIN
		ALTER TABLE THONG_SO_GSTT ADD TEN_TS_GSTT_HOA NVARCHAR(250)	
END


IF NOT EXISTS (SELECT * FROM [LOAI_YEU_CAU_BAO_TRI] WHERE MS_LOAI_YEU_CAU_BT = 1)
BEGIN	
		INSERT [dbo].[LOAI_YEU_CAU_BAO_TRI] 
		([MS_LOAI_YEU_CAU_BT], [TEN_LOAI_YEU_CAU_BT], [GHI_CHU]) VALUES (1, N'NSD yêu cầu', NULL)
END

IF NOT EXISTS (SELECT * FROM [LOAI_YEU_CAU_BAO_TRI] WHERE MS_LOAI_YEU_CAU_BT = 2)
BEGIN
INSERT [dbo].[LOAI_YEU_CAU_BAO_TRI] 
([MS_LOAI_YEU_CAU_BT], [TEN_LOAI_YEU_CAU_BT], [GHI_CHU]) VALUES (2, N'Từ GSTT', NULL)
END