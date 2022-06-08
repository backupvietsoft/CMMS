﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnGhi',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnGhiLoai') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnGhiLoai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnGhiLoai',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnKhongghi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnKhongghi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnKhongghi',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnKhongghiLoai') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnKhongghiLoai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnKhongghiLoai',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnSua',N'Sửa',N'Edit',N'Sửa',N'Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnThem',N'Thêm',N'Add',N'Thêm',N'Add')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnThemsuaLoai') UPDATE LANGUAGES SET VIETNAM=N'Thêm/Sửa', ENGLISH=N'Add/Edit', VIETNAM_OR=N'Thêm/Sửa', ENGLISH_OR=N'Add/Edit' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnThemsuaLoai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnThemsuaLoai',N'Thêm/Sửa',N'Add/Edit',N'Thêm/Sửa',N'Add/Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnThoat') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnThoat',N'T&hoát',N'E&xit',N'T&hoát',N'E&xit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnThoatLoai') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnThoatLoai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnThoatLoai',N'T&hoát',N'E&xit',N'T&hoát',N'E&xit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnXoa') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnXoa',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnXoaLoai') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnXoaLoai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'BtnXoaLoai',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btQH') UPDATE LANGUAGES SET VIETNAM=N'Quan hệ', ENGLISH=N'Relationship', VIETNAM_OR=N'Quan hệ', ENGLISH_OR=N'Relationship' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btQH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'btQH',N'Quan hệ',N'Relationship',N'Quan hệ',N'Relationship')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'chkPHONG_NGUA') UPDATE LANGUAGES SET VIETNAM=N'Định kỳ', ENGLISH=N'Periodic', VIETNAM_OR=N'Định kỳ', ENGLISH_OR=N'Periodic' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'chkPHONG_NGUA' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'chkPHONG_NGUA',N'Định kỳ',N'Periodic',N'Định kỳ',N'Periodic')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'DaPSKoSuaThanks') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đã phát sinh, bạn không thể sửa!', ENGLISH=N'Data in use cannot be replaced.', VIETNAM_OR=N'Dữ liệu đã phát sinh, bạn không thể sửa!', ENGLISH_OR=N'Data in use cannot be replaced.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'DaPSKoSuaThanks' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'DaPSKoSuaThanks',N'Dữ liệu đã phát sinh, bạn không thể sửa!',N'Data in use cannot be replaced.',N'Dữ liệu đã phát sinh, bạn không thể sửa!',N'Data in use cannot be replaced.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'frmBaoTri') UPDATE LANGUAGES SET VIETNAM=N'Hình thức/ Loại bảo trì', ENGLISH=N'Form / Type of Maintenance', VIETNAM_OR=N'Hình thức/ Loại bảo trì', ENGLISH_OR=N'Form / Type of Maintenance' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'frmBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'frmBaoTri',N'Hình thức/ Loại bảo trì',N'Form / Type of Maintenance',N'Hình thức/ Loại bảo trì',N'Form / Type of Maintenance')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'frmHinhthucbaotri') UPDATE LANGUAGES SET VIETNAM=N'Hình thức bảo trì', ENGLISH=N'Maintenance form', VIETNAM_OR=N'Hình thức bảo trì', ENGLISH_OR=N'Maintenance form' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'frmHinhthucbaotri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'frmHinhthucbaotri',N'Hình thức bảo trì',N'Maintenance form',N'Hình thức bảo trì',N'Maintenance form')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'frmLoaibaotri') UPDATE LANGUAGES SET VIETNAM=N'Loại bảo trì', ENGLISH=N'Maintenance type', VIETNAM_OR=N'Loại bảo trì', ENGLISH_OR=N'Maintenance type' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'frmLoaibaotri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'frmLoaibaotri',N'Loại bảo trì',N'Maintenance type',N'Loại bảo trì',N'Maintenance type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Remark', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Remark' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'GHI_CHU',N'Ghi chú',N'Remark',N'Ghi chú',N'Remark')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'GrpChonhinhthucbaotri') UPDATE LANGUAGES SET VIETNAM=N'Chọn hình thức bảo trì', ENGLISH=N'Select maintenance method', VIETNAM_OR=N'Chọn hình thức bảo trì', ENGLISH_OR=N'Select maintenance method' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'GrpChonhinhthucbaotri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'GrpChonhinhthucbaotri',N'Chọn hình thức bảo trì',N'Select maintenance method',N'Chọn hình thức bảo trì',N'Select maintenance method')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'grpDanhSach') UPDATE LANGUAGES SET VIETNAM=N'Danh sách hình thức bảo trì', ENGLISH=N'List of maintenance methods', VIETNAM_OR=N'Danh sách hình thức bảo trì', ENGLISH_OR=N'List of maintenance methods' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'grpDanhSach' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'grpDanhSach',N'Danh sách hình thức bảo trì',N'List of maintenance methods',N'Danh sách hình thức bảo trì',N'List of maintenance methods')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'GrpLoaibaotri') UPDATE LANGUAGES SET VIETNAM=N'Loại bảo trì', ENGLISH=N'Maintenance type', VIETNAM_OR=N'Loại bảo trì', ENGLISH_OR=N'Maintenance type' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'GrpLoaibaotri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'GrpLoaibaotri',N'Loại bảo trì',N'Maintenance type',N'Loại bảo trì',N'Maintenance type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'grpNhapThongTin') UPDATE LANGUAGES SET VIETNAM=N'Nhập thông tin', ENGLISH=N'Input info', VIETNAM_OR=N'Nhập thông tin', ENGLISH_OR=N'Input info' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'grpNhapThongTin' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'grpNhapThongTin',N'Nhập thông tin',N'Input info',N'Nhập thông tin',N'Input info')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'hu_hong') UPDATE LANGUAGES SET VIETNAM=N'Hư hỏng', ENGLISH=N'Failure', VIETNAM_OR=N'Hư hỏng', ENGLISH_OR=N'Failure' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'hu_hong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'hu_hong',N'Hư hỏng',N'Failure',N'Hư hỏng',N'Failure')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'LblHinhthucbaotri') UPDATE LANGUAGES SET VIETNAM=N'Hình thức bảo trì', ENGLISH=N'Maintenance method', VIETNAM_OR=N'Hình thức bảo trì', ENGLISH_OR=N'Maintenance method' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'LblHinhthucbaotri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'LblHinhthucbaotri',N'Hình thức bảo trì',N'Maintenance method',N'Hình thức bảo trì',N'Maintenance method')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'lblTen') UPDATE LANGUAGES SET VIETNAM=N'Hình thức', ENGLISH=N'Method', VIETNAM_OR=N'Hình thức', ENGLISH_OR=N'Method' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'lblTen' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'lblTen',N'Hình thức',N'Method',N'Hình thức',N'Method')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'lblTieuDe') UPDATE LANGUAGES SET VIETNAM=N'HÌNH THỨC / LOẠI BẢO TRÌ', ENGLISH=N'FORM / TYPE OF MAINTENANCE', VIETNAM_OR=N'HÌNH THỨC / LOẠI BẢO TRÌ', ENGLISH_OR=N'FORM / TYPE OF MAINTENANCE' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'lblTieuDe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'lblTieuDe',N'HÌNH THỨC / LOẠI BẢO TRÌ',N'FORM / TYPE OF MAINTENANCE',N'HÌNH THỨC / LOẠI BẢO TRÌ',N'FORM / TYPE OF MAINTENANCE')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'LblTieudeloaiBT') UPDATE LANGUAGES SET VIETNAM=N'Loại bảo trì', ENGLISH=N'MAINTENANCE TYPE', VIETNAM_OR=N'Loại bảo trì', ENGLISH_OR=N'MAINTENANCE TYPE' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'LblTieudeloaiBT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'LblTieudeloaiBT',N'Loại bảo trì',N'MAINTENANCE TYPE',N'Loại bảo trì',N'MAINTENANCE TYPE')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MAU') UPDATE LANGUAGES SET VIETNAM=N'Màu', ENGLISH=N'Color', VIETNAM_OR=N'Màu', ENGLISH_OR=N'Color' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MAU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MAU',N'Màu',N'Color',N'Màu',N'Color')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgGhi1') UPDATE LANGUAGES SET VIETNAM=N'Tên loại bảo trì không được rỗng!', ENGLISH=N'Maintenance type cannot be empty.', VIETNAM_OR=N'Tên loại bảo trì không được rỗng!', ENGLISH_OR=N'Maintenance type cannot be empty.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgGhi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgGhi1',N'Tên loại bảo trì không được rỗng!',N'Maintenance type cannot be empty.',N'Tên loại bảo trì không được rỗng!',N'Maintenance type cannot be empty.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgGhi2') UPDATE LANGUAGES SET VIETNAM=N'Số TT phải là kiểu số!', ENGLISH=N'Ordinal must be a number', VIETNAM_OR=N'Số TT phải là kiểu số!', ENGLISH_OR=N'Ordinal must be a number' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgGhi2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgGhi2',N'Số TT phải là kiểu số!',N'Ordinal must be a number',N'Số TT phải là kiểu số!',N'Ordinal must be a number')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgGhichu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú vượt quá chiều dài cho phép!', ENGLISH=N'Note exceeds permitted length!', VIETNAM_OR=N'Ghi chú vượt quá chiều dài cho phép!', ENGLISH_OR=N'Note exceeds permitted length!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgGhichu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgGhichu',N'Ghi chú vượt quá chiều dài cho phép!',N'Note exceeds permitted length!',N'Ghi chú vượt quá chiều dài cho phép!',N'Note exceeds permitted length!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgKiemtra01') UPDATE LANGUAGES SET VIETNAM=N'Hình thức bảo trì định kỳ đã tồn tại, bạn có muốn chọn hình thức bảo trì này là bảo trì định kỳ không?', ENGLISH=N'This periodic maintenance type already exists. Do you want specify a new one?', VIETNAM_OR=N'Hình thức bảo trì định kỳ đã tồn tại, bạn có muốn chọn hình thức bảo trì này là bảo trì định kỳ không?', ENGLISH_OR=N'This periodic maintenance type already exists. Do you want specify a new one?' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgKiemtra01' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgKiemtra01',N'Hình thức bảo trì định kỳ đã tồn tại, bạn có muốn chọn hình thức bảo trì này là bảo trì định kỳ không?',N'This periodic maintenance type already exists. Do you want specify a new one?',N'Hình thức bảo trì định kỳ đã tồn tại, bạn có muốn chọn hình thức bảo trì này là bảo trì định kỳ không?',N'This periodic maintenance type already exists. Do you want specify a new one?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgQuyenThemSua') UPDATE LANGUAGES SET VIETNAM=N'Bạn không có quyền thêm sửa dữ liệu!', ENGLISH=N'Authorization required to add new data.', VIETNAM_OR=N'Bạn không có quyền thêm sửa dữ liệu!', ENGLISH_OR=N'Authorization required to add new data.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgQuyenThemSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgQuyenThemSua',N'Bạn không có quyền thêm sửa dữ liệu!',N'Authorization required to add new data.',N'Bạn không có quyền thêm sửa dữ liệu!',N'Authorization required to add new data.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgSAME_THU_TU') UPDATE LANGUAGES SET VIETNAM=N'Thứ tự bảo trì này đã tồn tại. Vui lòng chọn thứ tự khác.', ENGLISH=N'This ordinal already exists. Please input another one!', VIETNAM_OR=N'Thứ tự bảo trì này đã tồn tại. Vui lòng chọn thứ tự khác.', ENGLISH_OR=N'This ordinal already exists. Please input another one!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgSAME_THU_TU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgSAME_THU_TU',N'Thứ tự bảo trì này đã tồn tại. Vui lòng chọn thứ tự khác.',N'This ordinal already exists. Please input another one!',N'Thứ tự bảo trì này đã tồn tại. Vui lòng chọn thứ tự khác.',N'This ordinal already exists. Please input another one!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgTEN_HT_BT') UPDATE LANGUAGES SET VIETNAM=N'Tên hình thức bảo trì này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH=N'This maintenance method already exists. Please enter another.', VIETNAM_OR=N'Tên hình thức bảo trì này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH_OR=N'This maintenance method already exists. Please enter another.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgTEN_HT_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgTEN_HT_BT',N'Tên hình thức bảo trì này đã tồn tại. Vui lòng chọn tên khác.',N'This maintenance method already exists. Please enter another.',N'Tên hình thức bảo trì này đã tồn tại. Vui lòng chọn tên khác.',N'This maintenance method already exists. Please enter another.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgTEN_LOAI_BT') UPDATE LANGUAGES SET VIETNAM=N'Tên loại bảo trì này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH=N'This maintenance type already exists. Please enter another.', VIETNAM_OR=N'Tên loại bảo trì này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH_OR=N'This maintenance type already exists. Please enter another.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgTEN_LOAI_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgTEN_LOAI_BT',N'Tên loại bảo trì này đã tồn tại. Vui lòng chọn tên khác.',N'This maintenance type already exists. Please enter another.',N'Tên loại bảo trì này đã tồn tại. Vui lòng chọn tên khác.',N'This maintenance type already exists. Please enter another.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgTEN_LOAI_BT22') UPDATE LANGUAGES SET VIETNAM=N'Tên loại bảo trì không được rỗng! Vui lòng nhập tên loạI bảo trì!', ENGLISH=N'Maintenance type cannot be empty. Please enter maintenance type.', VIETNAM_OR=N'Tên loại bảo trì không được rỗng! Vui lòng nhập tên loạI bảo trì!', ENGLISH_OR=N'Maintenance type cannot be empty. Please enter maintenance type.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgTEN_LOAI_BT22' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgTEN_LOAI_BT22',N'Tên loại bảo trì không được rỗng! Vui lòng nhập tên loạI bảo trì!',N'Maintenance type cannot be empty. Please enter maintenance type.',N'Tên loại bảo trì không được rỗng! Vui lòng nhập tên loạI bảo trì!',N'Maintenance type cannot be empty. Please enter maintenance type.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgTenLoaiBT') UPDATE LANGUAGES SET VIETNAM=N'Tên loại bảo trì vượt quá chiều dài cho phép!', ENGLISH=N'Name of maintenance type exceeds permitted length.', VIETNAM_OR=N'Tên loại bảo trì vượt quá chiều dài cho phép!', ENGLISH_OR=N'Name of maintenance type exceeds permitted length.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgTenLoaiBT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgTenLoaiBT',N'Tên loại bảo trì vượt quá chiều dài cho phép!',N'Name of maintenance type exceeds permitted length.',N'Tên loại bảo trì vượt quá chiều dài cho phép!',N'Name of maintenance type exceeds permitted length.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgThemsua') UPDATE LANGUAGES SET VIETNAM=N'Bạn vui lòng chọn hình thức bảo trì!', ENGLISH=N'Please choose maintenance method!', VIETNAM_OR=N'Bạn vui lòng chọn hình thức bảo trì!', ENGLISH_OR=N'Please choose maintenance method!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgThemsua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgThemsua',N'Bạn vui lòng chọn hình thức bảo trì!',N'Please choose maintenance method!',N'Bạn vui lòng chọn hình thức bảo trì!',N'Please choose maintenance method!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgTHU_TU') UPDATE LANGUAGES SET VIETNAM=N'Thứ tự bảo trì không hợp lệ.', ENGLISH=N'Ordinal is invalid!', VIETNAM_OR=N'Thứ tự bảo trì không hợp lệ.', ENGLISH_OR=N'Ordinal is invalid!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgTHU_TU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgTHU_TU',N'Thứ tự bảo trì không hợp lệ.',N'Ordinal is invalid!',N'Thứ tự bảo trì không hợp lệ.',N'Ordinal is invalid!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgTHU_TU_AM') UPDATE LANGUAGES SET VIETNAM=N'Số thứ tự phải là một số nguyên dương!', ENGLISH=N'Order must be an integer.', VIETNAM_OR=N'Số thứ tự phải là một số nguyên dương!', ENGLISH_OR=N'Order must be an integer.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgTHU_TU_AM' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgTHU_TU_AM',N'Số thứ tự phải là một số nguyên dương!',N'Order must be an integer.',N'Số thứ tự phải là một số nguyên dương!',N'Order must be an integer.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgXacNhanXoa') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa hình thức này không?', ENGLISH=N'Do you want to delete this form ?', VIETNAM_OR=N'Bạn có muốn xóa hình thức này không?', ENGLISH_OR=N'Do you want to delete this form ?' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgXacNhanXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgXacNhanXoa',N'Bạn có muốn xóa hình thức này không?',N'Do you want to delete this form ?',N'Bạn có muốn xóa hình thức này không?',N'Do you want to delete this form ?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaotri' AND KEYWORD =N'MsgXacNhanXoa1') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xoá hình thức bảo trì và loại bảo trì liên quan?', ENGLISH=N'Do you want to delete this maintenance form and  its related types?', VIETNAM_OR=N'Bạn có muốn xoá hình thức bảo trì và loại bảo trì liên quan?', ENGLISH_OR=N'Do you want to delete this maintenance form and  its related types?' WHERE FORM=N'frmBaotri' AND KEYWORD=N'MsgXacNhanXoa1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaotri',N'MsgXacNhanXoa1',N'Bạn có muốn xoá hình thức bảo trì và loại bảo trì liên quan?',N'Do you want to delete this maintenance form and  its related types?',N'Bạn có muốn xoá hình thức bảo trì và loại bảo trì liên quan?',N'Do you want to delete this maintenance form and  its related types?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgXoa') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu để xóa!', ENGLISH=N'There is no data to delete!', VIETNAM_OR=N'Không có dữ liệu để xóa!', ENGLISH_OR=N'There is no data to delete!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgXoa',N'Không có dữ liệu để xóa!',N'There is no data to delete!',N'Không có dữ liệu để xóa!',N'There is no data to delete!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgXoa1') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong danh mục loại bảo trì và cách thưc hiện, bạn không thể xóa!', ENGLISH=N'This data cannot be deleted because it is being used in list of maintenance type,', VIETNAM_OR=N'Dữ liệu đang sử dụng trong danh mục loại bảo trì và cách thưc hiện, bạn không thể xóa!', ENGLISH_OR=N'This data cannot be deleted because it is being used in list of maintenance type,' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgXoa1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgXoa1',N'Dữ liệu đang sử dụng trong danh mục loại bảo trì và cách thưc hiện, bạn không thể xóa!',N'This data cannot be deleted because it is being used in list of maintenance type,',N'Dữ liệu đang sử dụng trong danh mục loại bảo trì và cách thưc hiện, bạn không thể xóa!',N'This data cannot be deleted because it is being used in list of maintenance type,')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgXoa2') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa loại bảo trì này không?', ENGLISH=N'Do you want to delete this maintenance type?', VIETNAM_OR=N'Bạn có muốn xóa loại bảo trì này không?', ENGLISH_OR=N'Do you want to delete this maintenance type?' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgXoa2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgXoa2',N'Bạn có muốn xóa loại bảo trì này không?',N'Do you want to delete this maintenance type?',N'Bạn có muốn xóa loại bảo trì này không?',N'Do you want to delete this maintenance type?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgXoa3') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang được sử dụng bạn, không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used.', VIETNAM_OR=N'Dữ liệu đang được sử dụng bạn, không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgXoa3' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'MsgXoa3',N'Dữ liệu đang được sử dụng bạn, không thể xóa!',N'The data cannot be deleted because it is being used.',N'Dữ liệu đang được sử dụng bạn, không thể xóa!',N'The data cannot be deleted because it is being used.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'PHONG_NGUA') UPDATE LANGUAGES SET VIETNAM=N'Định kỳ', ENGLISH=N'Periodic', VIETNAM_OR=N'Định kỳ', ENGLISH_OR=N'Periodic' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'PHONG_NGUA' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'PHONG_NGUA',N'Định kỳ',N'Periodic',N'Định kỳ',N'Periodic')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'tabHinhThucBaoTri') UPDATE LANGUAGES SET VIETNAM=N'Hình thức bảo trì', ENGLISH=N'Maintenance Method', VIETNAM_OR=N'Hình thức bảo trì', ENGLISH_OR=N'Maintenance Method' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'tabHinhThucBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'tabHinhThucBaoTri',N'Hình thức bảo trì',N'Maintenance Method',N'Hình thức bảo trì',N'Maintenance Method')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'tabLoaiBaoTri') UPDATE LANGUAGES SET VIETNAM=N'Loại bảo trì', ENGLISH=N'Maintenance Type', VIETNAM_OR=N'Loại bảo trì', ENGLISH_OR=N'Maintenance Type' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'tabLoaiBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'tabLoaiBaoTri',N'Loại bảo trì',N'Maintenance Type',N'Loại bảo trì',N'Maintenance Type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'TEN_HT_BT') UPDATE LANGUAGES SET VIETNAM=N'Hình thức bảo trì', ENGLISH=N'Maintenance method', VIETNAM_OR=N'Hình thức bảo trì', ENGLISH_OR=N'Maintenance method' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'TEN_HT_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'TEN_HT_BT',N'Hình thức bảo trì',N'Maintenance method',N'Hình thức bảo trì',N'Maintenance method')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'TEN_LOAI_BT') UPDATE LANGUAGES SET VIETNAM=N'Tên loại bảo trì', ENGLISH=N'Maintenance type', VIETNAM_OR=N'Tên loại bảo trì', ENGLISH_OR=N'Maintenance type' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'TEN_LOAI_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'TEN_LOAI_BT',N'Tên loại bảo trì',N'Maintenance type',N'Tên loại bảo trì',N'Maintenance type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'THU_TU') UPDATE LANGUAGES SET VIETNAM=N'Thứ tự', ENGLISH=N'Ordinal', VIETNAM_OR=N'Thứ tự', ENGLISH_OR=N'Ordinal' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'THU_TU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'THU_TU',N'Thứ tự',N'Ordinal',N'Thứ tự',N'Ordinal')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'tontaimau') UPDATE LANGUAGES SET VIETNAM=N'Màu này đã được chọn!', ENGLISH=N'This color name already exists.', VIETNAM_OR=N'Màu này đã được chọn!', ENGLISH_OR=N'This color name already exists.' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'tontaimau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmBaoTri',N'tontaimau',N'Màu này đã được chọn!',N'This color name already exists.',N'Màu này đã được chọn!',N'This color name already exists.')