IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmMaintaince_Colgate' AND KEYWORD =N'lblDatesofMantenance') UPDATE LANGUAGES SET VIETNAM=N'Ngày bảo trì', ENGLISH=N'Dates of maintenance', VIETNAM_OR=N'Ngày bảo trì', ENGLISH_OR=N'Dates of maintenance' WHERE FORM=N'frmMaintaince_Colgate' AND KEYWORD=N'lblDatesofMantenance' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmMaintaince_Colgate',N'lblDatesofMantenance',N'Ngày bảo trì',N'Dates of maintenance',N'Ngày bảo trì',N'Dates of maintenance')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD =N'msgCoChacCopyDuLieuTuUser') UPDATE LANGUAGES SET VIETNAM=N'Bạn có chắc muốn copy? ', ENGLISH=N'Do you want to copy? ', VIETNAM_OR=N'Bạn có chắc muốn copy? ', ENGLISH_OR=N'Do you want to copy? ' WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD=N'msgCoChacCopyDuLieuTuUser' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmCopyPhanQuyen',N'msgCoChacCopyDuLieuTuUser',N'Bạn có chắc muốn copy? ',N'Do you want to copy? ',N'Bạn có chắc muốn copy? ',N'Do you want to copy? ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuBaoTri_New' AND KEYWORD =N'MucUuTienHint') UPDATE LANGUAGES SET VIETNAM=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH=N'Update start/end date by priority level', VIETNAM_OR=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH_OR=N'Update start/end date by priority level' WHERE FORM=N'frmPhieuBaoTri_New' AND KEYWORD=N'MucUuTienHint' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmPhieuBaoTri_New',N'MucUuTienHint',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachtongthe_odd' AND KEYWORD =N'MucUuTienHint') UPDATE LANGUAGES SET VIETNAM=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH=N'Update start/end date by priority level', VIETNAM_OR=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH_OR=N'Update start/end date by priority level' WHERE FORM=N'frmKehoachtongthe_odd' AND KEYWORD=N'MucUuTienHint' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachtongthe_odd',N'MucUuTienHint',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmTaoKHTT' AND KEYWORD =N'MucUuTienHint') UPDATE LANGUAGES SET VIETNAM=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH=N'Update start/end date by priority level', VIETNAM_OR=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH_OR=N'Update start/end date by priority level' WHERE FORM=N'frmTaoKHTT' AND KEYWORD=N'MucUuTienHint' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmTaoKHTT',N'MucUuTienHint',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLapphieubaotri_CS' AND KEYWORD =N'MucUuTienHint') UPDATE LANGUAGES SET VIETNAM=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH=N'Update start/end date by priority level', VIETNAM_OR=N'Cập nhật ngày BĐ/KT theo mức ưu tiên', ENGLISH_OR=N'Update start/end date by priority level' WHERE FORM=N'frmLapphieubaotri_CS' AND KEYWORD=N'MucUuTienHint' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLapphieubaotri_CS',N'MucUuTienHint',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level',N'Cập nhật ngày BĐ/KT theo mức ưu tiên',N'Update start/end date by priority level')


IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmMaintaince_Colgate' AND KEYWORD =N'lblDatesofMantenance') UPDATE LANGUAGES SET VIETNAM=N'Ngày bảo trì', ENGLISH=N'Dates of maintenance', VIETNAM_OR=N'Ngày bảo trì', ENGLISH_OR=N'Dates of maintenance' WHERE FORM=N'frmMaintaince_Colgate' AND KEYWORD=N'lblDatesofMantenance' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmMaintaince_Colgate',N'lblDatesofMantenance',N'Ngày bảo trì',N'Dates of maintenance',N'Ngày bảo trì',N'Dates of maintenance')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD =N'msgCoChacCopyDuLieuTuUser') UPDATE LANGUAGES SET VIETNAM=N'Bạn có chắc muốn copy? ', ENGLISH=N'Do you want to copy? ', VIETNAM_OR=N'Bạn có chắc muốn copy? ', ENGLISH_OR=N'Do you want to copy? ' WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD=N'msgCoChacCopyDuLieuTuUser' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmCopyPhanQuyen',N'msgCoChacCopyDuLieuTuUser',N'Bạn có chắc muốn copy? ',N'Do you want to copy? ',N'Bạn có chắc muốn copy? ',N'Do you want to copy? ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmReports' AND KEYWORD =N'THONGTINPHIEUBAOTRI') UPDATE LANGUAGES SET VIETNAM=N'CÔNG TÁC BẢO TRÌ', ENGLISH=N'MAINTENANCE WORKS', VIETNAM_OR=N'CÔNG TÁC BẢO TRÌ', ENGLISH_OR=N'MAINTENANCE WORKS' WHERE FORM=N'FrmReports' AND KEYWORD=N'THONGTINPHIEUBAOTRI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmReports',N'THONGTINPHIEUBAOTRI',N'CÔNG TÁC BẢO TRÌ',N'MAINTENANCE WORKS',N'CÔNG TÁC BẢO TRÌ',N'MAINTENANCE WORKS')