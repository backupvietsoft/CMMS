IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuBaoTri_New' AND KEYWORD =N'msgDichVu_ChuaCoDichVu') UPDATE LANGUAGES SET VIETNAM=N'Chưa nhập dịch vụ', ENGLISH=N'Please input service', VIETNAM_OR=N'Chưa nhập dịch vụ', ENGLISH_OR=N'Please input service' WHERE FORM=N'frmPhieuBaoTri_New' AND KEYWORD=N'msgDichVu_ChuaCoDichVu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmPhieuBaoTri_New',N'msgDichVu_ChuaCoDichVu',N'Chưa nhập dịch vụ',N'Please input service',N'Chưa nhập dịch vụ',N'Please input service')
