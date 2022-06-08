﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'BtnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'BtnGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'BtnGhi',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'BtnKhongGhi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'BtnKhongGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'BtnKhongGhi',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'btnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'btnSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'btnSua',N'Sửa',N'Edit',N'Sửa',N'Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'BtnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'BtnThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'BtnThem',N'Thêm',N'Add',N'Thêm',N'Add')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'BtnXoa') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'BtnXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'BtnXoa',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'frmDanhmuchethong') UPDATE LANGUAGES SET VIETNAM=N'Danh mục dây chuyền', ENGLISH=N'List of Lines', VIETNAM_OR=N'Danh mục dây chuyền', ENGLISH_OR=N'List of Lines' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'frmDanhmuchethong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'frmDanhmuchethong',N'Danh mục dây chuyền',N'List of Lines',N'Danh mục dây chuyền',N'List of Lines')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'GrpDanhsachHT') UPDATE LANGUAGES SET VIETNAM=N'Danh sách dây chuyền', ENGLISH=N'List of Lines', VIETNAM_OR=N'Danh sách dây chuyền', ENGLISH_OR=N'List of Lines' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'GrpDanhsachHT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'GrpDanhsachHT',N'Danh sách dây chuyền',N'List of Lines',N'Danh sách dây chuyền',N'List of Lines')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'GrpNhapHT') UPDATE LANGUAGES SET VIETNAM=N'Nhập dây chuyền', ENGLISH=N'Enter Line', VIETNAM_OR=N'Nhập dây chuyền', ENGLISH_OR=N'Enter Line' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'GrpNhapHT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'GrpNhapHT',N'Nhập dây chuyền',N'Enter Line',N'Nhập dây chuyền',N'Enter Line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'LblTenHT') UPDATE LANGUAGES SET VIETNAM=N'Dây chuyền', ENGLISH=N'Line', VIETNAM_OR=N'Dây chuyền', ENGLISH_OR=N'Line' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'LblTenHT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'LblTenHT',N'Dây chuyền',N'Line',N'Dây chuyền',N'Line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'LblTieudeHT') UPDATE LANGUAGES SET VIETNAM=N'DÂY CHUYỀN', ENGLISH=N'LINE', VIETNAM_OR=N'DÂY CHUYỀN', ENGLISH_OR=N'LINE' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'LblTieudeHT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'LblTieudeHT',N'DÂY CHUYỀN',N'LINE',N'DÂY CHUYỀN',N'LINE')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'MsgMS_HE_THONG') UPDATE LANGUAGES SET VIETNAM=N'Dây chuyền này đang được sử dụng trong form phân quyền!', ENGLISH=N'This line is being used!', VIETNAM_OR=N'Dây chuyền này đang được sử dụng trong form phân quyền!', ENGLISH_OR=N'This line is being used!' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'MsgMS_HE_THONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'MsgMS_HE_THONG',N'Dây chuyền này đang được sử dụng trong form phân quyền!',N'This line is being used!',N'Dây chuyền này đang được sử dụng trong form phân quyền!',N'This line is being used!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'MsgQuyenXoa1') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu để xóa', ENGLISH=N'No data to delete!', VIETNAM_OR=N'Không có dữ liệu để xóa', ENGLISH_OR=N'No data to delete!' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'MsgQuyenXoa1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'MsgQuyenXoa1',N'Không có dữ liệu để xóa',N'No data to delete!',N'Không có dữ liệu để xóa',N'No data to delete!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'MsgQuyenXoa2') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa dây chuyền này không?', ENGLISH=N'Are you sure you want to delete this line ?', VIETNAM_OR=N'Bạn có muốn xóa dây chuyền này không?', ENGLISH_OR=N'Are you sure you want to delete this line ?' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'MsgQuyenXoa2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'MsgQuyenXoa2',N'Bạn có muốn xóa dây chuyền này không?',N'Are you sure you want to delete this line ?',N'Bạn có muốn xóa dây chuyền này không?',N'Are you sure you want to delete this line ?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'MsgQuyenXoa3') UPDATE LANGUAGES SET VIETNAM=N'Dây chuyền này đang được sử dụng trong form Thiết bị', ENGLISH=N'This line is being used in Equipment!', VIETNAM_OR=N'Dây chuyền này đang được sử dụng trong form Thiết bị', ENGLISH_OR=N'This line is being used in Equipment!' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'MsgQuyenXoa3' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'MsgQuyenXoa3',N'Dây chuyền này đang được sử dụng trong form Thiết bị',N'This line is being used in Equipment!',N'Dây chuyền này đang được sử dụng trong form Thiết bị',N'This line is being used in Equipment!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'MsgTHOI_GIAN_NGUNG_MAY') UPDATE LANGUAGES SET VIETNAM=N'Dây chuyền này đang được sử dụng trong thời gian ngừng máy.', ENGLISH=N'This line is being used in Downtime!', VIETNAM_OR=N'Dây chuyền này đang được sử dụng trong thời gian ngừng máy.', ENGLISH_OR=N'This line is being used in Downtime!' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'MsgTHOI_GIAN_NGUNG_MAY' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'MsgTHOI_GIAN_NGUNG_MAY',N'Dây chuyền này đang được sử dụng trong thời gian ngừng máy.',N'This line is being used in Downtime!',N'Dây chuyền này đang được sử dụng trong thời gian ngừng máy.',N'This line is being used in Downtime!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'TEN_HE_THONG') UPDATE LANGUAGES SET VIETNAM=N'Tên dây chuyền', ENGLISH=N'Line name', VIETNAM_OR=N'Tên dây chuyền', ENGLISH_OR=N'Line name' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'TEN_HE_THONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'TEN_HE_THONG',N'Tên dây chuyền',N'Line name',N'Tên dây chuyền',N'Line name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'lblGhiChu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Remark', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Remark' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'lblGhiChu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'lblGhiChu',N'Ghi chú',N'Remark',N'Ghi chú',N'Remark')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'lblNoLine') UPDATE LANGUAGES SET VIETNAM=N'Non-line', ENGLISH=N'Non-line', VIETNAM_OR=N'Non-line', ENGLISH_OR=N'Non-line' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'lblNoLine' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'lblNoLine',N'Non-line',N'Non-line',N'Non-line',N'Non-line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'chkNoLine') UPDATE LANGUAGES SET VIETNAM=N'', ENGLISH=N'', VIETNAM_OR=N'', ENGLISH_OR=N'' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'chkNoLine' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'chkNoLine',N'',N'',N'',N'')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'MS_HE_THONG') UPDATE LANGUAGES SET VIETNAM=N'Mã dây chuyền', ENGLISH=N'Line ID', VIETNAM_OR=N'Mã dây chuyền', ENGLISH_OR=N'Line ID' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'MS_HE_THONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'MS_HE_THONG',N'Mã dây chuyền',N'Line ID',N'Mã dây chuyền',N'Line ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'GHI_CHU',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'NO_LINE') UPDATE LANGUAGES SET VIETNAM=N'Không thuộc dây chuyền', ENGLISH=N'Non-line', VIETNAM_OR=N'Không thuộc dây chuyền', ENGLISH_OR=N'Non-line' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'NO_LINE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'NO_LINE',N'Không thuộc dây chuyền',N'Non-line',N'Không thuộc dây chuyền',N'Non-line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'lblMSHThong') UPDATE LANGUAGES SET VIETNAM=N'Dây chuyển', ENGLISH=N'Line', VIETNAM_OR=N'Dây chuyển', ENGLISH_OR=N'Line' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'lblMSHThong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'lblMSHThong',N'Dây chuyển',N'Line',N'Dây chuyển',N'Line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'MA_HE_THONG') UPDATE LANGUAGES SET VIETNAM=N'Mã dây chuyền', ENGLISH=N'ID', VIETNAM_OR=N'Mã dây chuyền', ENGLISH_OR=N'ID' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'MA_HE_THONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'MA_HE_THONG',N'Mã dây chuyền',N'ID',N'Mã dây chuyền',N'ID')
