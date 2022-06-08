IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDuyetSanXuat' AND KEYWORD =N'tabDuyetSanXuat') UPDATE LANGUAGES SET VIETNAM=N'Danh sách yêu cầu', ENGLISH=N'List of requests', VIETNAM_OR=N'Danh sách yêu cầu', ENGLISH_OR=N'List of requests' WHERE FORM=N'frmDuyetSanXuat' AND KEYWORD=N'tabDuyetSanXuat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDuyetSanXuat',N'tabDuyetSanXuat',N'Danh sách yêu cầu',N'List of requests',N'Danh sách yêu cầu',N'List of requests')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDuyetSanXuat' AND KEYWORD =N'tabBoPhanTheoYeuCau') UPDATE LANGUAGES SET VIETNAM=N'Bộ phần, phụ tùng theo yêu cầu', ENGLISH=N'Parts and spare parts by request', VIETNAM_OR=N'Bộ phần, phụ tùng theo yêu cầu', ENGLISH_OR=N'Parts and spare parts by request' WHERE FORM=N'frmDuyetSanXuat' AND KEYWORD=N'tabBoPhanTheoYeuCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDuyetSanXuat',N'tabBoPhanTheoYeuCau',N'Bộ phần, phụ tùng theo yêu cầu',N'Parts and spare parts by request',N'Bộ phần, phụ tùng theo yêu cầu',N'Parts and spare parts by request')



update LANGUAGES set VIETNAM = N'Mã bộ phận' WHERE KEYWORD = 'MS_BO_PHAN'
update LANGUAGES set VIETNAM = N'Tên bộ phận' WHERE KEYWORD = 'TEN_BO_PHAN'
update LANGUAGES set VIETNAM = N'Mã VT PT' WHERE KEYWORD = 'MS_PT'
