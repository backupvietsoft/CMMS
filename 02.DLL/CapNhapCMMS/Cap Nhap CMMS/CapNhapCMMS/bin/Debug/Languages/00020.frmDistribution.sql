﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'btnAdd') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmDistribution' AND KEYWORD=N'btnAdd' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'btnAdd',N'Thêm',N'Add',N'Thêm',N'Add')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'btnCancel') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmDistribution' AND KEYWORD=N'btnCancel' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'btnCancel',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'btnDelete') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmDistribution' AND KEYWORD=N'btnDelete' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'btnDelete',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'btnEdit') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmDistribution' AND KEYWORD=N'btnEdit' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'btnEdit',N'Sửa',N'Edit',N'Sửa',N'Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'btnExit') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmDistribution' AND KEYWORD=N'btnExit' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'btnExit',N'T&hoát',N'E&xit',N'T&hoát',N'E&xit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'btnSave') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmDistribution' AND KEYWORD=N'btnSave' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'btnSave',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmDistribution' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'DuLieuCos') UPDATE LANGUAGES SET VIETNAM=N'Danh sách đơn vị chịu phí', ENGLISH=N'List of Cost Center', VIETNAM_OR=N'Danh sách đơn vị chịu phí', ENGLISH_OR=N'List of Cost Center' WHERE FORM=N'frmDistribution' AND KEYWORD=N'DuLieuCos' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'DuLieuCos',N'Danh sách đơn vị chịu phí',N'List of Cost Center',N'Danh sách đơn vị chịu phí',N'List of Cost Center')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'frmDistribution') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị chịu phí', ENGLISH=N'Cost Center', VIETNAM_OR=N'Đơn vị chịu phí', ENGLISH_OR=N'Cost Center' WHERE FORM=N'frmDistribution' AND KEYWORD=N'frmDistribution' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'frmDistribution',N'Đơn vị chịu phí',N'Cost Center',N'Đơn vị chịu phí',N'Cost Center')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmDistribution' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'GHI_CHU',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'lblGChu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmDistribution' AND KEYWORD=N'lblGChu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'lblGChu',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'lblLoaiCP') UPDATE LANGUAGES SET VIETNAM=N'Tên loại chi phí', ENGLISH=N'Name of expenditure type', VIETNAM_OR=N'Tên loại chi phí', ENGLISH_OR=N'Name of expenditure type' WHERE FORM=N'frmDistribution' AND KEYWORD=N'lblLoaiCP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'lblLoaiCP',N'Tên loại chi phí',N'Name of expenditure type',N'Tên loại chi phí',N'Name of expenditure type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'lblMa') UPDATE LANGUAGES SET VIETNAM=N'Mã DV Chịu phí', ENGLISH=N'Cost Center ID', VIETNAM_OR=N'Mã DV Chịu phí', ENGLISH_OR=N'Cost Center ID' WHERE FORM=N'frmDistribution' AND KEYWORD=N'lblMa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'lblMa',N'Mã DV Chịu phí',N'Cost Center ID',N'Mã DV Chịu phí',N'Cost Center ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'lblTen') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị chịu phí', ENGLISH=N'Cost Center', VIETNAM_OR=N'Đơn vị chịu phí', ENGLISH_OR=N'Cost Center' WHERE FORM=N'frmDistribution' AND KEYWORD=N'lblTen' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'lblTen',N'Đơn vị chịu phí',N'Cost Center',N'Đơn vị chịu phí',N'Cost Center')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'lblTenDVi') UPDATE LANGUAGES SET VIETNAM=N'Tên đơn vị', ENGLISH=N'Org.unit name', VIETNAM_OR=N'Tên đơn vị', ENGLISH_OR=N'Org.unit name' WHERE FORM=N'frmDistribution' AND KEYWORD=N'lblTenDVi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'lblTenDVi',N'Tên đơn vị',N'Org.unit name',N'Tên đơn vị',N'Org.unit name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'MS_COSTCENTER') UPDATE LANGUAGES SET VIETNAM=N'Mã DV Chịu phí', ENGLISH=N'Cost Center ID', VIETNAM_OR=N'Mã DV Chịu phí', ENGLISH_OR=N'Cost Center ID' WHERE FORM=N'frmDistribution' AND KEYWORD=N'MS_COSTCENTER' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'MS_COSTCENTER',N'Mã DV Chịu phí',N'Cost Center ID',N'Mã DV Chịu phí',N'Cost Center ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'TEN_COSTCENTER') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị chịu phí', ENGLISH=N'Cost Center', VIETNAM_OR=N'Đơn vị chịu phí', ENGLISH_OR=N'Cost Center' WHERE FORM=N'frmDistribution' AND KEYWORD=N'TEN_COSTCENTER' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'TEN_COSTCENTER',N'Đơn vị chịu phí',N'Cost Center',N'Đơn vị chịu phí',N'Cost Center')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'TEN_DON_VI') UPDATE LANGUAGES SET VIETNAM=N'Tên đơn vị', ENGLISH=N'Org.unit name', VIETNAM_OR=N'Tên đơn vị', ENGLISH_OR=N'Org.unit name' WHERE FORM=N'frmDistribution' AND KEYWORD=N'TEN_DON_VI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'TEN_DON_VI',N'Tên đơn vị',N'Org.unit name',N'Tên đơn vị',N'Org.unit name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'TEN_LOAI_CHI_PHI') UPDATE LANGUAGES SET VIETNAM=N'Tên loại chi phí', ENGLISH=N'Name of expenditure type', VIETNAM_OR=N'Tên loại chi phí', ENGLISH_OR=N'Name of expenditure type' WHERE FORM=N'frmDistribution' AND KEYWORD=N'TEN_LOAI_CHI_PHI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'TEN_LOAI_CHI_PHI',N'Tên loại chi phí',N'Name of expenditure type',N'Tên loại chi phí',N'Name of expenditure type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'ThongTinCos') UPDATE LANGUAGES SET VIETNAM=N'Thông tin chung', ENGLISH=N'General info', VIETNAM_OR=N'Thông tin chung', ENGLISH_OR=N'General info' WHERE FORM=N'frmDistribution' AND KEYWORD=N'ThongTinCos' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'ThongTinCos',N'Thông tin chung',N'General info',N'Thông tin chung',N'General info')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'groupControl2') UPDATE LANGUAGES SET VIETNAM=N'Danh sách đơn vị chịu phí', ENGLISH=N'groupControl2', VIETNAM_OR=N'Danh sách đơn vị chịu phí', ENGLISH_OR=N'groupControl2' WHERE FORM=N'frmDistribution' AND KEYWORD=N'groupControl2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'groupControl2',N'Danh sách đơn vị chịu phí',N'groupControl2',N'Danh sách đơn vị chịu phí',N'groupControl2')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDistribution' AND KEYWORD =N'groupControl1') UPDATE LANGUAGES SET VIETNAM=N'Thông tin đơn vị chịu phí', ENGLISH=N'groupControl1', VIETNAM_OR=N'Thông tin đơn vị chịu phí', ENGLISH_OR=N'groupControl1' WHERE FORM=N'frmDistribution' AND KEYWORD=N'groupControl1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDistribution',N'groupControl1',N'Thông tin đơn vị chịu phí',N'groupControl1',N'Thông tin đơn vị chịu phí',N'groupControl1')
