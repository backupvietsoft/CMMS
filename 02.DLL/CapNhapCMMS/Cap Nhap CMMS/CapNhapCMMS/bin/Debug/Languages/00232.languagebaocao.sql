IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvitinh' AND KEYWORD =N'MsgSaiMa') UPDATE LANGUAGES SET VIETNAM=N'Mã đơn vị tính phải là số', ENGLISH=N'Unit ID must be a number', VIETNAM_OR=N'Mã đơn vị tính phải là số', ENGLISH_OR=N'Unit ID must be a number' WHERE FORM=N'frmDonvitinh' AND KEYWORD=N'MsgSaiMa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDonvitinh',N'MsgSaiMa',N'Mã đơn vị tính phải là số',N'Unit ID must be a number',N'Mã đơn vị tính phải là số',N'Unit ID must be a number')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD =N'msgCoChacCopyDuLieuTuUser') UPDATE LANGUAGES SET VIETNAM=N'Bạn có chắc muốn copy quyền của user', ENGLISH=N'Are you sure you want to copy authorizations from user', VIETNAM_OR=N'Bạn có chắc muốn copy quyền của user', ENGLISH_OR=N'Are you sure you want to copy authorizations from user' WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD=N'msgCoChacCopyDuLieuTuUser' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmCopyPhanQuyen',N'msgCoChacCopyDuLieuTuUser',N'Bạn có chắc muốn copy quyền của user',N'Are you sure you want to copy authorizations from user',N'Bạn có chắc muốn copy quyền của user',N'Are you sure you want to copy authorizations from user')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD =N'msgsang') UPDATE LANGUAGES SET VIETNAM=N'sang user', ENGLISH=N'to user', VIETNAM_OR=N'sang user', ENGLISH_OR=N'to user' WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD=N'msgsang' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmCopyPhanQuyen',N'msgsang',N'sang user',N'to user',N'sang user',N'to user')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD =N'msgCopyThanhCong') UPDATE LANGUAGES SET VIETNAM=N'Copy thành công!', ENGLISH=N'Copying is successful!', VIETNAM_OR=N'Copy thành công!', ENGLISH_OR=N'Copying is successful!' WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD=N'msgCopyThanhCong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmCopyPhanQuyen',N'msgCopyThanhCong',N'Copy thành công!',N'Copying is successful!',N'Copy thành công!',N'Copying is successful!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD =N'frmCopyPhanQuyen') UPDATE LANGUAGES SET VIETNAM=N'Chọn dữ liệu copy', ENGLISH=N'Select data to copy', VIETNAM_OR=N'Chọn dữ liệu copy', ENGLISH_OR=N'Select data to copy' WHERE FORM=N'frmCopyPhanQuyen' AND KEYWORD=N'frmCopyPhanQuyen' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmCopyPhanQuyen',N'frmCopyPhanQuyen',N'Chọn dữ liệu copy',N'Select data to copy',N'Chọn dữ liệu copy',N'Select data to copy')

