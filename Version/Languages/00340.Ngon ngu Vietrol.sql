IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucKHKDThietBi' AND KEYWORD =N'NGAY_HC') UPDATE LANGUAGES SET VIETNAM=N'Ngày HC-KĐ', ENGLISH=N'Calib. Ver Date', VIETNAM_OR=N'Ngày HC-KĐ', ENGLISH_OR=N'Calib. Ver Date' WHERE FORM=N'ucKHKDThietBi' AND KEYWORD=N'NGAY_HC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucKHKDThietBi',N'NGAY_HC',N'Ngày HC-KĐ',N'Calib. Ver Date',N'Ngày HC-KĐ',N'Calib. Ver Date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucKHKDThietBi1' AND KEYWORD =N'NGAY_HC') UPDATE LANGUAGES SET VIETNAM=N'Ngày HC-KĐ', ENGLISH=N'Calib. Ver Date', VIETNAM_OR=N'Ngày HC-KĐ', ENGLISH_OR=N'Calib. Ver Date' WHERE FORM=N'ucKHKDThietBi1' AND KEYWORD=N'NGAY_HC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucKHKDThietBi1',N'NGAY_HC',N'Ngày HC-KĐ',N'Calib. Ver Date',N'Ngày HC-KĐ',N'Calib. Ver Date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'' AND KEYWORD =N'NGAY_HC') UPDATE LANGUAGES SET VIETNAM=N'Ngày HC-KĐ', ENGLISH=N'Calib. Ver Date', VIETNAM_OR=N'Ngày HC-KĐ', ENGLISH_OR=N'Calib. Ver Date' WHERE FORM=N'' AND KEYWORD=N'NGAY_HC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'',N'NGAY_HC',N'Ngày HC-KĐ',N'Calib. Ver Date',N'Ngày HC-KĐ',N'Calib. Ver Date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmReminder_new' AND KEYWORD =N'NGAY_HC') UPDATE LANGUAGES SET VIETNAM=N'Ngày HC-KĐ', ENGLISH=N'Calib. Ver Date', VIETNAM_OR=N'Ngày HC-KĐ', ENGLISH_OR=N'Calib. Ver Date' WHERE FORM=N'frmReminder_new' AND KEYWORD=N'NGAY_HC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmReminder_new',N'NGAY_HC',N'Ngày HC-KĐ',N'Calib. Ver Date',N'Ngày HC-KĐ',N'Calib. Ver Date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmucphutung_CS' AND KEYWORD =N'DuLieuPTKhoDaCoKhongThayDoiDc') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đã có không thể bỏ check được!', ENGLISH=N'Data already existed. Cannot uncheck!', VIETNAM_OR=N'Dữ liệu đã có không thể bỏ check được!', ENGLISH_OR=N'Data already existed. Cannot uncheck!' WHERE FORM=N'frmDanhmucphutung_CS' AND KEYWORD=N'DuLieuPTKhoDaCoKhongThayDoiDc' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmDanhmucphutung_CS',N'DuLieuPTKhoDaCoKhongThayDoiDc',N'Dữ liệu đã có không thể bỏ check được!',N'Data already existed. Cannot uncheck!',N'Dữ liệu đã có không thể bỏ check được!',N'Data already existed. Cannot uncheck!','ECOMAIN')
