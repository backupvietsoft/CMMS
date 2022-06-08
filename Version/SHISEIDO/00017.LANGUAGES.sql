IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD =N'LabLyDo') UPDATE LANGUAGES SET VIETNAM=N'PO', ENGLISH=N'PO',CHINESE=N'PO', VIETNAM_OR=N'PO', ENGLISH_OR=N'PO' , CHINESE_OR=N'PO' WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD=N'LabLyDo' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmPhieuNhapKho_New',N'LabLyDo',N'PO',N'PO',N'PO',N'PO',N'PO',N'PO','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD =N'LabDanhGia') UPDATE LANGUAGES SET VIETNAM=N'Hóa đơn', ENGLISH=N'Invoice',CHINESE=N'Invoice', VIETNAM_OR=N'Hóa đơn', ENGLISH_OR=N'Invoice' , CHINESE_OR=N'Invoice' WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD=N'LabDanhGia' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmPhieuNhapKho_New',N'LabDanhGia',N'Hóa đơn',N'Invoice',N'Invoice',N'Hóa đơn',N'Invoice',N'Invoice','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD =N'LabSoCT') UPDATE LANGUAGES SET VIETNAM=N'Hải Quan', ENGLISH=N'Hải Quan',CHINESE=N'Hải Quan', VIETNAM_OR=N'Hải Quan', ENGLISH_OR=N'Hải Quan' , CHINESE_OR=N'Hải Quan' WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD=N'LabSoCT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmPhieuNhapKho_New',N'LabSoCT',N'Hải Quan',N'Hải Quan',N'Hải Quan',N'Hải Quan',N'Hải Quan',N'Hải Quan','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD =N'LabCanCu') UPDATE LANGUAGES SET VIETNAM=N'Số tờ khai', ENGLISH=N'Số tờ khai',CHINESE=N'Số tờ khai', VIETNAM_OR=N'Số tờ khai', ENGLISH_OR=N'Số tờ khai' , CHINESE_OR=N'Số tờ khai' WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD=N'LabCanCu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmPhieuNhapKho_New',N'LabCanCu',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'' AND KEYWORD =N'') UPDATE LANGUAGES SET VIETNAM=N'', ENGLISH=N'',CHINESE=N'', VIETNAM_OR=N'', ENGLISH_OR=N'' , CHINESE_OR=N'' WHERE FORM=N'' AND KEYWORD=N'' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'',N'',N'',N'',N'',N'',N'',N'','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD =N'LY_DO') UPDATE LANGUAGES SET VIETNAM=N'PO', ENGLISH=N'PO',CHINESE=N'PO', VIETNAM_OR=N'PO', ENGLISH_OR=N'PO' , CHINESE_OR=N'PO' WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD=N'LY_DO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhSachPhieuNhapKho',N'LY_DO',N'PO',N'PO',N'PO',N'PO',N'PO',N'PO','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD =N'DANH_GIA') UPDATE LANGUAGES SET VIETNAM=N'Hóa đơn', ENGLISH=N'Invoice',CHINESE=N'Invoice', VIETNAM_OR=N'Hóa đơn', ENGLISH_OR=N'Invoice' , CHINESE_OR=N'Invoice' WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD=N'DANH_GIA' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhSachPhieuNhapKho',N'DANH_GIA',N'Hóa đơn',N'Invoice',N'Invoice',N'Hóa đơn',N'Invoice',N'Invoice','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD =N'SO_CHUNG_TU') UPDATE LANGUAGES SET VIETNAM=N'Hải Quan', ENGLISH=N'Hải Quan',CHINESE=N'Hải Quan', VIETNAM_OR=N'Hải Quan', ENGLISH_OR=N'Hải Quan' , CHINESE_OR=N'Hải Quan' WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD=N'SO_CHUNG_TU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhSachPhieuNhapKho',N'SO_CHUNG_TU',N'Hải Quan',N'Hải Quan',N'Hải Quan',N'Hải Quan',N'Hải Quan',N'Hải Quan','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD =N'CAN_CU') UPDATE LANGUAGES SET VIETNAM=N'Số tờ khai', ENGLISH=N'Số tờ khai',CHINESE=N'Số tờ khai', VIETNAM_OR=N'Số tờ khai', ENGLISH_OR=N'Số tờ khai' , CHINESE_OR=N'Số tờ khai' WHERE FORM=N'ucDanhSachPhieuNhapKho' AND KEYWORD=N'CAN_CU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhSachPhieuNhapKho',N'CAN_CU',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai',N'Số tờ khai','ECOMAIN')
