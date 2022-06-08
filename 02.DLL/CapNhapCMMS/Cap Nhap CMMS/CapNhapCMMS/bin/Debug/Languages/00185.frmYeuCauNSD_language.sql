﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'grdHinh') UPDATE LANGUAGES SET VIETNAM=N'Danh sách hình', ENGLISH=N'Image list', VIETNAM_OR=N'Danh sách hình', ENGLISH_OR=N'Image list' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'grdHinh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'grdHinh',N'Danh sách hình',N'Image list',N'Danh sách hình',N'Image list')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'btnThemBP') UPDATE LANGUAGES SET VIETNAM=N'Thêm bộ phận', ENGLISH=N'Add part', VIETNAM_OR=N'Thêm bộ phận', ENGLISH_OR=N'Add part' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'btnThemBP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'btnThemBP',N'Thêm bộ phận',N'Add part',N'Thêm bộ phận',N'Add part')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'btnChonBP') UPDATE LANGUAGES SET VIETNAM=N'Chọn bộ phận', ENGLISH=N'Select part', VIETNAM_OR=N'Chọn bộ phận', ENGLISH_OR=N'Select part' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'btnChonBP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'btnChonBP',N'Chọn bộ phận',N'Select part',N'Chọn bộ phận',N'Select part')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'grpDanhsachBP') UPDATE LANGUAGES SET VIETNAM=N'Danh sách bộ phận theo máy', ENGLISH=N'List of parts by equipment', VIETNAM_OR=N'Danh sách bộ phận theo máy', ENGLISH_OR=N'List of parts by equipment' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'grpDanhsachBP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'grpDanhsachBP',N'Danh sách bộ phận theo máy',N'List of parts by equipment',N'Danh sách bộ phận theo máy',N'List of parts by equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'btnGhi1') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'btnGhi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'btnGhi1',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'btnKhongGhi1') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'btnKhongGhi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'btnKhongGhi1',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'btnXoaBoPhan') UPDATE LANGUAGES SET VIETNAM=N'Xóa bộ phận', ENGLISH=N'&Delete part', VIETNAM_OR=N'Xóa bộ phận', ENGLISH_OR=N'&Delete part' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'btnXoaBoPhan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'btnXoaBoPhan',N'Xóa bộ phận',N'&Delete part',N'Xóa bộ phận',N'&Delete part')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'MsgQuyenXoa6') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa bộ phận đang chọn?', ENGLISH=N'Do you want to delete selected part', VIETNAM_OR=N'Bạn có muốn xóa bộ phận đang chọn?', ENGLISH_OR=N'Do you want to delete selected part' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'MsgQuyenXoa6' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'MsgQuyenXoa6',N'Bạn có muốn xóa bộ phận đang chọn?',N'Do you want to delete selected part',N'Bạn có muốn xóa bộ phận đang chọn?',N'Do you want to delete selected part')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'MsgNoYeuCauCT') UPDATE LANGUAGES SET VIETNAM=N'Yêu cầu chi tiết rỗng. Vui lòng nhập!', ENGLISH=N'Request detail is empty. Please enter request detail.', VIETNAM_OR=N'Yêu cầu chi tiết rỗng. Vui lòng nhập!', ENGLISH_OR=N'Request detail is empty. Please enter request detail.' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'MsgNoYeuCauCT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'MsgNoYeuCauCT',N'Yêu cầu chi tiết rỗng. Vui lòng nhập!',N'Request detail is empty. Please enter request detail.',N'Yêu cầu chi tiết rỗng. Vui lòng nhập!',N'Request detail is empty. Please enter request detail.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'MS_BO_PHAN') UPDATE LANGUAGES SET VIETNAM=N'Mã bộ phận', ENGLISH=N'Part code', VIETNAM_OR=N'Mã bộ phận', ENGLISH_OR=N'Part code' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'MS_BO_PHAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'MS_BO_PHAN',N'Mã bộ phận',N'Part code',N'Mã bộ phận',N'Part code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD =N'TEN_BO_PHAN') UPDATE LANGUAGES SET VIETNAM=N'Tên bộ phận', ENGLISH=N'Part name', VIETNAM_OR=N'Tên bộ phận', ENGLISH_OR=N'Part name' WHERE FORM=N'frmYeuCauCuaNSD' AND KEYWORD=N'TEN_BO_PHAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmYeuCauCuaNSD',N'TEN_BO_PHAN',N'Tên bộ phận',N'Part name',N'Tên bộ phận',N'Part name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD =N'MS_BO_PHAN') UPDATE LANGUAGES SET VIETNAM=N'Mã bộ phận', ENGLISH=N'Part code', VIETNAM_OR=N'Mã bộ phận', ENGLISH_OR=N'Part code' WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD=N'MS_BO_PHAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChoMay',N'MS_BO_PHAN',N'Mã bộ phận',N'Part code',N'Mã bộ phận',N'Part code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD =N'TEN_BO_PHAN') UPDATE LANGUAGES SET VIETNAM=N'Tên bộ phận', ENGLISH=N'Part name', VIETNAM_OR=N'Tên bộ phận', ENGLISH_OR=N'Part name' WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD=N'TEN_BO_PHAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChoMay',N'TEN_BO_PHAN',N'Tên bộ phận',N'Part name',N'Tên bộ phận',N'Part name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD =N'grpDanhsachBP') UPDATE LANGUAGES SET VIETNAM=N'Danh sách bộ phận theo máy', ENGLISH=N'List of parts by equipment', VIETNAM_OR=N'Danh sách bộ phận theo máy', ENGLISH_OR=N'List of parts by equipment' WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD=N'grpDanhsachBP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChoMay',N'grpDanhsachBP',N'Danh sách bộ phận theo máy',N'List of parts by equipment',N'Danh sách bộ phận theo máy',N'List of parts by equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD =N'frmBoPhanChoMay') UPDATE LANGUAGES SET VIETNAM=N'Chọn bộ phận cho máy', ENGLISH=N'Select part by equipment', VIETNAM_OR=N'Chọn bộ phận cho máy', ENGLISH_OR=N'Select part by equipment' WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD=N'frmBoPhanChoMay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChoMay',N'frmBoPhanChoMay',N'Chọn bộ phận cho máy',N'Select part by equipment',N'Chọn bộ phận cho máy',N'Select part by equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD =N'msgChonBP') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn bộ phận.', ENGLISH=N'Please select part!', VIETNAM_OR=N'Vui lòng chọn bộ phận.', ENGLISH_OR=N'Please select part!' WHERE FORM=N'frmBoPhanChoMay' AND KEYWORD=N'msgChonBP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBoPhanChoMay',N'msgChonBP',N'Vui lòng chọn bộ phận.',N'Please select part!',N'Vui lòng chọn bộ phận.',N'Please select part!')