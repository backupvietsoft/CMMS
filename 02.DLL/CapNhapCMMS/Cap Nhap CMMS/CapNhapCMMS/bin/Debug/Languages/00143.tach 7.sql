﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'STT_MAY') UPDATE LANGUAGES SET VIETNAM=N'Thứ tự', ENGLISH=N'Order', VIETNAM_OR=N'Thứ tự', ENGLISH_OR=N'Order' WHERE FORM=N'frmThietBi' AND KEYWORD=N'STT_MAY' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'tabLoaiThietBi') UPDATE LANGUAGES SET VIETNAM=N'Loại thiết bị', ENGLISH=N'Equipment Type', VIETNAM_OR=N'Loại thiết bị', ENGLISH_OR=N'Equipment Type' WHERE FORM=N'frmThietBi' AND KEYWORD=N'tabLoaiThietBi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'tabNhomThietBi') UPDATE LANGUAGES SET VIETNAM=N'Nhóm thiết bị', ENGLISH=N'Equipment Group', VIETNAM_OR=N'Nhóm thiết bị', ENGLISH_OR=N'Equipment Group' WHERE FORM=N'frmThietBi' AND KEYWORD=N'tabNhomThietBi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'TEN_LOAI_MAY') UPDATE LANGUAGES SET VIETNAM=N'Loại thiết bị', ENGLISH=N'Type of equipment', VIETNAM_OR=N'Loại thiết bị', ENGLISH_OR=N'Type of equipment' WHERE FORM=N'frmThietBi' AND KEYWORD=N'TEN_LOAI_MAY' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'TEN_NHOM_MAY') UPDATE LANGUAGES SET VIETNAM=N'Tên nhóm', ENGLISH=N'Name of equipment group', VIETNAM_OR=N'Tên nhóm', ENGLISH_OR=N'Name of equipment group' WHERE FORM=N'frmThietBi' AND KEYWORD=N'TEN_NHOM_MAY' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'chkAttachment') UPDATE LANGUAGES SET VIETNAM=N'Attachment', ENGLISH=N'Attachment', VIETNAM_OR=N'Attachment', ENGLISH_OR=N'Attachment' WHERE FORM=N'frmThietBi' AND KEYWORD=N'chkAttachment' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'lblAttachment') UPDATE LANGUAGES SET VIETNAM=N'Attachment', ENGLISH=N'Attachment', VIETNAM_OR=N'Attachment', ENGLISH_OR=N'Attachment' WHERE FORM=N'frmThietBi' AND KEYWORD=N'lblAttachment' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'btnSuaNhom') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmThietBi' AND KEYWORD=N'btnSuaNhom' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'btnThemNhom') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmThietBi' AND KEYWORD=N'btnThemNhom' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'btnThoatNhom') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmThietBi' AND KEYWORD=N'btnThoatNhom' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'btnKhongGhiNhom') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmThietBi' AND KEYWORD=N'btnKhongGhiNhom' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'btnXoaNhom') UPDATE LANGUAGES SET VIETNAM=N'&Xóa', ENGLISH=N'&Delete', VIETNAM_OR=N'&Xóa', ENGLISH_OR=N'&Delete' WHERE FORM=N'frmThietBi' AND KEYWORD=N'btnXoaNhom' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'btnGhiNhom') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmThietBi' AND KEYWORD=N'btnGhiNhom' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'GHI CHÚ', ENGLISH=N'REMARK', VIETNAM_OR=N'GHI CHÚ', ENGLISH_OR=N'REMARK' WHERE FORM=N'frmThietBi' AND KEYWORD=N'GHI_CHU' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'lblGhiChu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmThietBi' AND KEYWORD=N'lblGhiChu' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThietBi' AND KEYWORD =N'lblGChu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmThietBi' AND KEYWORD=N'lblGChu' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'2.9.' AND KEYWORD =N'') UPDATE LANGUAGES SET VIETNAM=N'', ENGLISH=N'', VIETNAM_OR=N'', ENGLISH_OR=N'' WHERE FORM=N'2.9.' AND KEYWORD=N'' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'BtnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'BtnGhi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'BtnKhongghi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'BtnKhongghi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'BtnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'BtnSua' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'BtnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'BtnThem' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'BtnThoat') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'BtnThoat' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'BtnXoa') UPDATE LANGUAGES SET VIETNAM=N'&Xóa', ENGLISH=N'&Delete', VIETNAM_OR=N'&Xóa', ENGLISH_OR=N'&Delete' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'BtnXoa' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'frmLoaicongviec') UPDATE LANGUAGES SET VIETNAM=N'Loại công việc', ENGLISH=N'Type of work', VIETNAM_OR=N'Loại công việc', ENGLISH_OR=N'Type of work' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'frmLoaicongviec' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'GrpDanhmucloaicv') UPDATE LANGUAGES SET VIETNAM=N'Danh sách loại công việc', ENGLISH=N'List of works', VIETNAM_OR=N'Danh sách loại công việc', ENGLISH_OR=N'List of works' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'GrpDanhmucloaicv' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'GrpNhaploaicongviec') UPDATE LANGUAGES SET VIETNAM=N'Nhập thông tin', ENGLISH=N'Input info', VIETNAM_OR=N'Nhập thông tin', ENGLISH_OR=N'Input info' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'GrpNhaploaicongviec' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'LblTenloaicongviec') UPDATE LANGUAGES SET VIETNAM=N'Tên loại công việc', ENGLISH=N'Work type name', VIETNAM_OR=N'Tên loại công việc', ENGLISH_OR=N'Work type name' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'LblTenloaicongviec' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'LblTieudeloaiCV') UPDATE LANGUAGES SET VIETNAM=N'LOẠI CÔNG VIỆC', ENGLISH=N'TYPE OF WORK', VIETNAM_OR=N'LOẠI CÔNG VIỆC', ENGLISH_OR=N'TYPE OF WORK' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'LblTieudeloaiCV' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'MsgTEN_LOAI_CV') UPDATE LANGUAGES SET VIETNAM=N'Tên loại công việc này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH=N'This type of  work  already exists. Please input another one!', VIETNAM_OR=N'Tên loại công việc này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH_OR=N'This type of  work  already exists. Please input another one!' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'MsgTEN_LOAI_CV' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'MsgUser') UPDATE LANGUAGES SET VIETNAM=N'Loại công việc này đã được phân quyền cho nhóm người sử dụng khác!', ENGLISH=N'This work type is assigned to another user group!', VIETNAM_OR=N'Loại công việc này đã được phân quyền cho nhóm người sử dụng khác!', ENGLISH_OR=N'This work type is assigned to another user group!' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'MsgUser' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'MsgXoa1') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu để xóa!', ENGLISH=N'There is no data to delete!', VIETNAM_OR=N'Không có dữ liệu để xóa!', ENGLISH_OR=N'There is no data to delete!' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'MsgXoa1' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'MsgXoa2') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa loại công việc này không?', ENGLISH=N'Do you want to delete this work type?', VIETNAM_OR=N'Bạn có muốn xóa loại công việc này không?', ENGLISH_OR=N'Do you want to delete this work type?' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'MsgXoa2' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'MsgXoa3') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang được sử dụng trong danh mục công việc, bạn không thể xóa!', ENGLISH=N'Data cannot be deleted because it is being used in list of works.', VIETNAM_OR=N'Dữ liệu đang được sử dụng trong danh mục công việc, bạn không thể xóa!', ENGLISH_OR=N'Data cannot be deleted because it is being used in list of works.' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'MsgXoa3' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'MsgXoa4') UPDATE LANGUAGES SET VIETNAM=N'Loại công việc này đang được sử dụng trong phân quyền dữ liệu theo loại công việc, bạn không thể xoá!', ENGLISH=N'This work type cannot be deleted because it is being used in authorization', VIETNAM_OR=N'Loại công việc này đang được sử dụng trong phân quyền dữ liệu theo loại công việc, bạn không thể xoá!', ENGLISH_OR=N'This work type cannot be deleted because it is being used in authorization' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'MsgXoa4' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLoaicongviec' AND KEYWORD =N'TEN_LOAI_CV') UPDATE LANGUAGES SET VIETNAM=N'Tên loại công việc', ENGLISH=N'Work type name', VIETNAM_OR=N'Tên loại công việc', ENGLISH_OR=N'Work type name' WHERE FORM=N'frmLoaicongviec' AND KEYWORD=N'TEN_LOAI_CV' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'2.12.' AND KEYWORD =N'') UPDATE LANGUAGES SET VIETNAM=N'', ENGLISH=N'', VIETNAM_OR=N'', ENGLISH_OR=N'' WHERE FORM=N'2.12.' AND KEYWORD=N'' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'BtnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'BtnGhi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnGhi2') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnGhi2' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'BtnKhongghi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'BtnKhongghi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnKhongghi2') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnKhongghi2' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'BtnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'BtnSua' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'BtnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'BtnThem' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnThemsua') UPDATE LANGUAGES SET VIETNAM=N'Thêm/Sửa', ENGLISH=N'&Add/Edit', VIETNAM_OR=N'Thêm/Sửa', ENGLISH_OR=N'&Add/Edit' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnThemsua' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'BtnThoat') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'BtnThoat' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnThoat2') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'E&xit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnThoat2' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnTrove') UPDATE LANGUAGES SET VIETNAM=N'T&rở về', ENGLISH=N'&Return', VIETNAM_OR=N'T&rở về', ENGLISH_OR=N'&Return' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnTrove' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'BtnXoa') UPDATE LANGUAGES SET VIETNAM=N'&Xóa', ENGLISH=N'&Delete', VIETNAM_OR=N'&Xóa', ENGLISH_OR=N'&Delete' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'BtnXoa' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnXoa2') UPDATE LANGUAGES SET VIETNAM=N'&Xóa', ENGLISH=N'&Delete', VIETNAM_OR=N'&Xóa', ENGLISH_OR=N'&Delete' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnXoa2' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnXoaKH') UPDATE LANGUAGES SET VIETNAM=N'Xóa &NCC', ENGLISH=N'Delete &sup.', VIETNAM_OR=N'Xóa &NCC', ENGLISH_OR=N'Delete &sup.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnXoaKH' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'btnXoaNDD') UPDATE LANGUAGES SET VIETNAM=N'Xóa &NĐD', ENGLISH=N'Delete r&ep.', VIETNAM_OR=N'Xóa &NĐD', ENGLISH_OR=N'Delete r&ep.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'btnXoaNDD' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'CHUC_VU') UPDATE LANGUAGES SET VIETNAM=N'Chức vụ', ENGLISH=N'Position', VIETNAM_OR=N'Chức vụ', ENGLISH_OR=N'Position' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'CHUC_VU' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'DI_DONG') UPDATE LANGUAGES SET VIETNAM=N'ĐT di động', ENGLISH=N'Mobile no.', VIETNAM_OR=N'ĐT di động', ENGLISH_OR=N'Mobile no.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'DI_DONG' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'DIA_CHI') UPDATE LANGUAGES SET VIETNAM=N'Địa chỉ', ENGLISH=N'Address', VIETNAM_OR=N'Địa chỉ', ENGLISH_OR=N'Address' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'DIA_CHI' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'EMAIL') UPDATE LANGUAGES SET VIETNAM=N'Email', ENGLISH=N'Email', VIETNAM_OR=N'Email', ENGLISH_OR=N'Email' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'EMAIL' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'FAX') UPDATE LANGUAGES SET VIETNAM=N'FAX', ENGLISH=N'FAX', VIETNAM_OR=N'FAX', ENGLISH_OR=N'FAX' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'FAX' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'frmNhacungcap') UPDATE LANGUAGES SET VIETNAM=N'Danh sách nhà cung cấp', ENGLISH=N'List of suppliers', VIETNAM_OR=N'Danh sách nhà cung cấp', ENGLISH_OR=N'List of suppliers' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'frmNhacungcap' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'gbKhachhang') UPDATE LANGUAGES SET VIETNAM=N'Nhà cung cấp', ENGLISH=N'Supplier', VIETNAM_OR=N'Nhà cung cấp', ENGLISH_OR=N'Supplier' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'gbKhachhang' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'gbNguoidaidien') UPDATE LANGUAGES SET VIETNAM=N'Người đại diện', ENGLISH=N'Representative', VIETNAM_OR=N'Người đại diện', ENGLISH_OR=N'Representative' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'gbNguoidaidien' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'GHI_CHU' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'GrpDanhsachkhachhang') UPDATE LANGUAGES SET VIETNAM=N'Danh sách nhà cung cấp', ENGLISH=N'List of suppliers', VIETNAM_OR=N'Danh sách nhà cung cấp', ENGLISH_OR=N'List of suppliers' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'GrpDanhsachkhachhang' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'GrpNhapkhachhang') UPDATE LANGUAGES SET VIETNAM=N'Nhập thông tin', ENGLISH=N'Input info', VIETNAM_OR=N'Nhập thông tin', ENGLISH_OR=N'Input info' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'GrpNhapkhachhang' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'HOME_ADD') UPDATE LANGUAGES SET VIETNAM=N'Địa chỉ nhà', ENGLISH=N'Home add.', VIETNAM_OR=N'Địa chỉ nhà', ENGLISH_OR=N'Home add.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'HOME_ADD' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'HOME_TEL') UPDATE LANGUAGES SET VIETNAM=N'ĐT nhà riêng', ENGLISH=N'Home phone', VIETNAM_OR=N'ĐT nhà riêng', ENGLISH_OR=N'Home phone' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'HOME_TEL' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'Label1') UPDATE LANGUAGES SET VIETNAM=N'Số tài khoản', ENGLISH=N'Account No.', VIETNAM_OR=N'Số tài khoản', ENGLISH_OR=N'Account No.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'Label1' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'Label2') UPDATE LANGUAGES SET VIETNAM=N'MS thuế', ENGLISH=N'Tax code', VIETNAM_OR=N'MS thuế', ENGLISH_OR=N'Tax code' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'Label2' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'Label3') UPDATE LANGUAGES SET VIETNAM=N'Tìm công ty', ENGLISH=N'Search', VIETNAM_OR=N'Tìm công ty', ENGLISH_OR=N'Search' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'Label3' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'Label4') UPDATE LANGUAGES SET VIETNAM=N'Tên ngắn', ENGLISH=N'Short name', VIETNAM_OR=N'Tên ngắn', ENGLISH_OR=N'Short name' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'Label4' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblDiachi') UPDATE LANGUAGES SET VIETNAM=N'Địa chỉ', ENGLISH=N'Address', VIETNAM_OR=N'Địa chỉ', ENGLISH_OR=N'Address' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblDiachi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblDienthoai') UPDATE LANGUAGES SET VIETNAM=N'Điện thoại', ENGLISH=N'Telephone', VIETNAM_OR=N'Điện thoại', ENGLISH_OR=N'Telephone' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblDienthoai' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblFax') UPDATE LANGUAGES SET VIETNAM=N'Fax', ENGLISH=N'Fax', VIETNAM_OR=N'Fax', ENGLISH_OR=N'Fax' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblFax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'lblMakh') UPDATE LANGUAGES SET VIETNAM=N'Mã Nhà cung cấp', ENGLISH=N'Supplier ID', VIETNAM_OR=N'Mã Nhà cung cấp', ENGLISH_OR=N'Supplier ID' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'lblMakh' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblNguoidaidien') UPDATE LANGUAGES SET VIETNAM=N'Giám đốc', ENGLISH=N'Director', VIETNAM_OR=N'Giám đốc', ENGLISH_OR=N'Director' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblNguoidaidien' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'lblQuocGia') UPDATE LANGUAGES SET VIETNAM=N'Quốc gia', ENGLISH=N'Country', VIETNAM_OR=N'Quốc gia', ENGLISH_OR=N'Country' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'lblQuocGia' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblTencongty') UPDATE LANGUAGES SET VIETNAM=N'Tên công ty', ENGLISH=N'Full name', VIETNAM_OR=N'Tên công ty', ENGLISH_OR=N'Full name' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblTencongty' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'lblTenviettat') UPDATE LANGUAGES SET VIETNAM=N'Tên viết tắt', ENGLISH=N'Short name', VIETNAM_OR=N'Tên viết tắt', ENGLISH_OR=N'Short name' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'lblTenviettat' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblTieudeNCC') UPDATE LANGUAGES SET VIETNAM=N'DANH SÁCH NHÀ CUNG CẤP', ENGLISH=N'VENDOR', VIETNAM_OR=N'DANH SÁCH NHÀ CUNG CẤP', ENGLISH_OR=N'VENDOR' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblTieudeNCC' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblTongsoNCC') UPDATE LANGUAGES SET VIETNAM=N'Tổng số nhà cung cấp', ENGLISH=N'Total number of suppliers', VIETNAM_OR=N'Tổng số nhà cung cấp', ENGLISH_OR=N'Total number of suppliers' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblTongsoNCC' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'LblWebsite') UPDATE LANGUAGES SET VIETNAM=N'Website/E-mail', ENGLISH=N'Website / E-mail', VIETNAM_OR=N'Website/E-mail', ENGLISH_OR=N'Website / E-mail' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'LblWebsite' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MS_KH') UPDATE LANGUAGES SET VIETNAM=N'MS  NCC', ENGLISH=N'Supplier ID', VIETNAM_OR=N'MS  NCC', ENGLISH_OR=N'Supplier ID' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MS_KH' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MS_THUE') UPDATE LANGUAGES SET VIETNAM=N'MS thuế', ENGLISH=N'Tax code', VIETNAM_OR=N'MS thuế', ENGLISH_OR=N'Tax code' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MS_THUE' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgChucVuMax') UPDATE LANGUAGES SET VIETNAM=N'Chức vụ vượt quá chiều dài qui định.', ENGLISH=N'Job title exceeds permitted length!', VIETNAM_OR=N'Chức vụ vượt quá chiều dài qui định.', ENGLISH_OR=N'Job title exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgChucVuMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgDiDongMax') UPDATE LANGUAGES SET VIETNAM=N'Số di động vượt quá chiều dài qui định.', ENGLISH=N'Mobile number exceeds permitted length!', VIETNAM_OR=N'Số di động vượt quá chiều dài qui định.', ENGLISH_OR=N'Mobile number exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgDiDongMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgGhi01') UPDATE LANGUAGES SET VIETNAM=N'MS nhà cung cấp này đã tồn tại, bạn vui lòng nhập MS khác!', ENGLISH=N'This supplier ID already exists. Please enter another!', VIETNAM_OR=N'MS nhà cung cấp này đã tồn tại, bạn vui lòng nhập MS khác!', ENGLISH_OR=N'This supplier ID already exists. Please enter another!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgGhi01' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgGhi02') UPDATE LANGUAGES SET VIETNAM=N'Tên ngắn này đã tồn tại, bạn vui lòng nhập tên khác!', ENGLISH=N'This name already exists. Please enter another!', VIETNAM_OR=N'Tên ngắn này đã tồn tại, bạn vui lòng nhập tên khác!', ENGLISH_OR=N'This name already exists. Please enter another!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgGhi02' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgGhiChuMax') UPDATE LANGUAGES SET VIETNAM=N'Nội dung ghi chú vượt quá chiều dài qui định.', ENGLISH=N'Note exceeds permitted length!', VIETNAM_OR=N'Nội dung ghi chú vượt quá chiều dài qui định.', ENGLISH_OR=N'Note exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgGhiChuMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgHomeAddMax') UPDATE LANGUAGES SET VIETNAM=N'Địa chỉ nhà vượt quá chiều dài qui định.', ENGLISH=N'Home address exceeds permitted length!', VIETNAM_OR=N'Địa chỉ nhà vượt quá chiều dài qui định.', ENGLISH_OR=N'Home address exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgHomeAddMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgHomeTelMax') UPDATE LANGUAGES SET VIETNAM=N'Số điện thoại nhà vượt quá chiều dài qui định.', ENGLISH=N'Home phone number exceeds permitted length!', VIETNAM_OR=N'Số điện thoại nhà vượt quá chiều dài qui định.', ENGLISH_OR=N'Home phone number exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgHomeTelMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgMailMax') UPDATE LANGUAGES SET VIETNAM=N'Địa chỉ mail vượt quá chiều dài qui định.', ENGLISH=N'Email address exceeds permitted length!', VIETNAM_OR=N'Địa chỉ mail vượt quá chiều dài qui định.', ENGLISH_OR=N'Email address exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgMailMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgMS_KH') UPDATE LANGUAGES SET VIETNAM=N'MS nhà cung cấp này đã tồn tại. Vui lòng chọn MS nhà cung cấp khác.', ENGLISH=N'This supplier ID already exists. Please enter another!', VIETNAM_OR=N'MS nhà cung cấp này đã tồn tại. Vui lòng chọn MS nhà cung cấp khác.', ENGLISH_OR=N'This supplier ID already exists. Please enter another!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgMS_KH' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgQuyenSua') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used in Spare part!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used in Spare part!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgQuyenSua' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgQuyenThem') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used in Spare part!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used in Spare part!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgQuyenThem' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgQuyenXoa') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used in Spare part!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used in Spare part!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgQuyenXoa' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgTelMax') UPDATE LANGUAGES SET VIETNAM=N'Số di động vượt quá chiều dài qui định.', ENGLISH=N'Mobile number exceeds permitted length!', VIETNAM_OR=N'Số di động vượt quá chiều dài qui định.', ENGLISH_OR=N'Mobile number exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgTelMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgTenNDDMax') UPDATE LANGUAGES SET VIETNAM=N'Tên người đại diện vượt quá chiều dài qui định.', ENGLISH=N'Representative name exceeds permitted length!', VIETNAM_OR=N'Tên người đại diện vượt quá chiều dài qui định.', ENGLISH_OR=N'Representative name exceeds permitted length!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgTenNDDMax' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa1') UPDATE LANGUAGES SET VIETNAM=N'Không còn dữ liệu để xóa!', ENGLISH=N'There is no data to delete!', VIETNAM_OR=N'Không còn dữ liệu để xóa!', ENGLISH_OR=N'There is no data to delete!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa1' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa10') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang được sử dụng trong phiếu nhập kho.', ENGLISH=N'This data is being used in Receipts.', VIETNAM_OR=N'Dữ liệu đang được sử dụng trong phiếu nhập kho.', ENGLISH_OR=N'This data is being used in Receipts.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa10' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa11') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa người đại diện này không?', ENGLISH=N'Do you want to delete this representative?', VIETNAM_OR=N'Bạn có muốn xóa người đại diện này không?', ENGLISH_OR=N'Do you want to delete this representative?' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa11' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa15') UPDATE LANGUAGES SET VIETNAM=N'Người này đang tồn tại trong EOR! Bạn không thể xóa!', ENGLISH=N'This user cannot be deleted because it is being used in EOR.', VIETNAM_OR=N'Người này đang tồn tại trong EOR! Bạn không thể xóa!', ENGLISH_OR=N'This user cannot be deleted because it is being used in EOR.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa15' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa2') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa nhà cung cấp này không ?', ENGLISH=N'Do you want to delete this supplier?', VIETNAM_OR=N'Bạn có muốn xóa nhà cung cấp này không ?', ENGLISH_OR=N'Do you want to delete this supplier?' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa2' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa3') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong đơn đặt hàng, bạn không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used in Purchase Order!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong đơn đặt hàng, bạn không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used in Purchase Order!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa3' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa4') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong phần thiết bị, bạn không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used in Equipment', VIETNAM_OR=N'Dữ liệu đang sử dụng trong phần thiết bị, bạn không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used in Equipment' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa4' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa5') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used in Spare part!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong phần phụ tùng, bạn không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used in Spare part!' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa5' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa6') UPDATE LANGUAGES SET VIETNAM=N'MS công ty này đang được sử dụng trong người đại diện! Bạn không thể xóa!', ENGLISH=N'The company ID cannot be deleted because it is being used in Representative.', VIETNAM_OR=N'MS công ty này đang được sử dụng trong người đại diện! Bạn không thể xóa!', ENGLISH_OR=N'The company ID cannot be deleted because it is being used in Representative.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa6' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa7') UPDATE LANGUAGES SET VIETNAM=N'Công ty này đang được sử dụng trong đơn đặt hàng! Bạn không thể xóa!', ENGLISH=N'The company ID cannot be deleted because it is being used in Purchase Order.', VIETNAM_OR=N'Công ty này đang được sử dụng trong đơn đặt hàng! Bạn không thể xóa!', ENGLISH_OR=N'The company ID cannot be deleted because it is being used in Purchase Order.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa7' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa8') UPDATE LANGUAGES SET VIETNAM=N'Công ty này đang được sử dụng trong phiếu bảo trì dịch vụ! Bạn không thể xóa!', ENGLISH=N'The company ID cannot be deleted because it is being used in Work Order.', VIETNAM_OR=N'Công ty này đang được sử dụng trong phiếu bảo trì dịch vụ! Bạn không thể xóa!', ENGLISH_OR=N'The company ID cannot be deleted because it is being used in Work Order.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa8' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'MsgXoa9') UPDATE LANGUAGES SET VIETNAM=N'MS công ty này đang được sử dụng trong dịch vụ thuê ngòai! Bạn không thể xóa!', ENGLISH=N'The company ID cannot be deleted because it is being used in Service.', VIETNAM_OR=N'MS công ty này đang được sử dụng trong dịch vụ thuê ngòai! Bạn không thể xóa!', ENGLISH_OR=N'The company ID cannot be deleted because it is being used in Service.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'MsgXoa9' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'QUOCGIA') UPDATE LANGUAGES SET VIETNAM=N'Quốc gia', ENGLISH=N'Country', VIETNAM_OR=N'Quốc gia', ENGLISH_OR=N'Country' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'QUOCGIA' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'STT') UPDATE LANGUAGES SET VIETNAM=N'STT', ENGLISH=N'No.', VIETNAM_OR=N'STT', ENGLISH_OR=N'No.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'STT' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'tabDanhsach') UPDATE LANGUAGES SET VIETNAM=N'Danh sách nhà cung cấp', ENGLISH=N'List of Suppliers', VIETNAM_OR=N'Danh sách nhà cung cấp', ENGLISH_OR=N'List of Suppliers' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'tabDanhsach' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'tabNguoidaidien') UPDATE LANGUAGES SET VIETNAM=N'Người đại diện', ENGLISH=N'Representative', VIETNAM_OR=N'Người đại diện', ENGLISH_OR=N'Representative' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'tabNguoidaidien' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'TAI_KHOAN_ANH') UPDATE LANGUAGES SET VIETNAM=N'Số tài khoản', ENGLISH=N'Account No.', VIETNAM_OR=N'Số tài khoản', ENGLISH_OR=N'Account No.' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'TAI_KHOAN_ANH' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'TEL') UPDATE LANGUAGES SET VIETNAM=N'ĐT văn phòng', ENGLISH=N'Office phone', VIETNAM_OR=N'ĐT văn phòng', ENGLISH_OR=N'Office phone' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'TEL' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'TEN_CONG_TY') UPDATE LANGUAGES SET VIETNAM=N'Tên công ty', ENGLISH=N'Company full name', VIETNAM_OR=N'Tên công ty', ENGLISH_OR=N'Company full name' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'TEN_CONG_TY' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'TEN_NDD') UPDATE LANGUAGES SET VIETNAM=N'Người đại diện', ENGLISH=N'Representative', VIETNAM_OR=N'Người đại diện', ENGLISH_OR=N'Representative' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'TEN_NDD' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'TEN_RUT_GON') UPDATE LANGUAGES SET VIETNAM=N'Tên viết tắt', ENGLISH=N'Short name', VIETNAM_OR=N'Tên viết tắt', ENGLISH_OR=N'Short name' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'TEN_RUT_GON' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'DC_TEL_FAX') UPDATE LANGUAGES SET VIETNAM=N'Địa chỉ', ENGLISH=N'Address', VIETNAM_OR=N'Địa chỉ', ENGLISH_OR=N'Address' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'DC_TEL_FAX' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhacungcap' AND KEYWORD =N'lblTongSoKH') UPDATE LANGUAGES SET VIETNAM=N'Tổng', ENGLISH=N'Total', VIETNAM_OR=N'Tổng', ENGLISH_OR=N'Total' WHERE FORM=N'frmNhacungcap' AND KEYWORD=N'lblTongSoKH' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'2.13.' AND KEYWORD =N'') UPDATE LANGUAGES SET VIETNAM=N'', ENGLISH=N'', VIETNAM_OR=N'', ENGLISH_OR=N'' WHERE FORM=N'2.13.' AND KEYWORD=N'' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'btnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmDonvido' AND KEYWORD=N'btnGhi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'btnKhongghi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmDonvido' AND KEYWORD=N'btnKhongghi' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'btnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmDonvido' AND KEYWORD=N'btnSua' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'btnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmDonvido' AND KEYWORD=N'btnThem' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmDonvido' AND KEYWORD=N'btnThoat' 
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'btnXoa') UPDATE LANGUAGES SET VIETNAM=N'&Xóa', ENGLISH=N'&Delete', VIETNAM_OR=N'&Xóa', ENGLISH_OR=N'&Delete' WHERE FORM=N'frmDonvido' AND KEYWORD=N'btnXoa' 