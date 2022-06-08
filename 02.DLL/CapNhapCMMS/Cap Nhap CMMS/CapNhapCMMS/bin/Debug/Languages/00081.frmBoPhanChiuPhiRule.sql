﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'btnAdd') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'btnAdd' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'btnAdd',N'Thêm',N'Add',N'Thêm',N'Add')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'btnCancel') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'btnCancel' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'btnCancel',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'btnDelete') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'btnDelete' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'btnDelete',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'btnEdit') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'btnEdit' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'btnEdit',N'Sửa',N'Edit',N'Sửa',N'Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'btnExit') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'btnExit' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'btnExit',N'T&hoát',N'E&xit',N'T&hoát',N'E&xit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'btnSave') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'btnSave' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'btnSave',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'frmBoPhanChiuPhiRule') UPDATE LANGUAGES SET VIETNAM=N'Distribution rule', ENGLISH=N'Distribution rule', VIETNAM_OR=N'Distribution rule', ENGLISH_OR=N'Distribution rule' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'frmBoPhanChiuPhiRule' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'frmBoPhanChiuPhiRule',N'Distribution rule',N'Distribution rule',N'Distribution rule',N'Distribution rule')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'GHI_CHU',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'lblGChu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'lblGChu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'lblGChu',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'lblLoaiCP') UPDATE LANGUAGES SET VIETNAM=N'Tên loại chi phí', ENGLISH=N'Cost type name', VIETNAM_OR=N'Tên loại chi phí', ENGLISH_OR=N'Cost type name' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'lblLoaiCP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'lblLoaiCP',N'Tên loại chi phí',N'Cost type name',N'Tên loại chi phí',N'Cost type name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'lblTenDistribution') UPDATE LANGUAGES SET VIETNAM=N'Tên Distribution rule', ENGLISH=N'Distribution rule name', VIETNAM_OR=N'Tên Distribution rule', ENGLISH_OR=N'Distribution rule name' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'lblTenDistribution' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'lblTenDistribution',N'Tên Distribution rule',N'Distribution rule name',N'Tên Distribution rule',N'Distribution rule name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'lblTenDV') UPDATE LANGUAGES SET VIETNAM=N'Tên đơn vị', ENGLISH=N'Department name', VIETNAM_OR=N'Tên đơn vị', ENGLISH_OR=N'Department name' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'lblTenDV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'lblTenDV',N'Tên đơn vị',N'Department name',N'Tên đơn vị',N'Department name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'MS_COSTCENTER') UPDATE LANGUAGES SET VIETNAM=N'Mã DV Chịu phí', ENGLISH=N'Cost Center ID', VIETNAM_OR=N'Mã DV Chịu phí', ENGLISH_OR=N'Cost Center ID' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'MS_COSTCENTER' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'MS_COSTCENTER',N'Mã DV Chịu phí',N'Cost Center ID',N'Mã DV Chịu phí',N'Cost Center ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'TEN') UPDATE LANGUAGES SET VIETNAM=N'Tên bộ phận chịu phí', ENGLISH=N'Cost Center name', VIETNAM_OR=N'Tên bộ phận chịu phí', ENGLISH_OR=N'Cost Center name' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'TEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'TEN',N'Tên bộ phận chịu phí',N'Cost Center name',N'Tên bộ phận chịu phí',N'Cost Center name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'TEN_BP_CHIU_PHI') UPDATE LANGUAGES SET VIETNAM=N'Tên Distribution rule', ENGLISH=N'Distribution rule name', VIETNAM_OR=N'Tên Distribution rule', ENGLISH_OR=N'Distribution rule name' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'TEN_BP_CHIU_PHI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'TEN_BP_CHIU_PHI',N'Tên Distribution rule',N'Distribution rule name',N'Tên Distribution rule',N'Distribution rule name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'TY_LE') UPDATE LANGUAGES SET VIETNAM=N'Tỷ lệ', ENGLISH=N'Proportion', VIETNAM_OR=N'Tỷ lệ', ENGLISH_OR=N'Proportion' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'TY_LE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'TY_LE',N'Tỷ lệ',N'Proportion',N'Tỷ lệ',N'Proportion')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'TenKhongTrung') UPDATE LANGUAGES SET VIETNAM=N'Tên không được trùng!', ENGLISH=N'This name already exists.', VIETNAM_OR=N'Tên không được trùng!', ENGLISH_OR=N'This name already exists.' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'TenKhongTrung' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'TenKhongTrung',N'Tên không được trùng!',N'This name already exists.',N'Tên không được trùng!',N'This name already exists.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD =N'MaCostCenterTrung') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị chịu phí', ENGLISH=N'Cost Center', VIETNAM_OR=N'Đơn vị chịu phí', ENGLISH_OR=N'Cost Center' WHERE FORM=N'frmBoPhanChiuPhiRule' AND KEYWORD=N'MaCostCenterTrung' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChiuPhiRule',N'MaCostCenterTrung',N'Đơn vị chịu phí',N'Cost Center',N'Đơn vị chịu phí',N'Cost Center')
