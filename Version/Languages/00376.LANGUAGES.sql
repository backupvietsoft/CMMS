﻿DELETE FROM LANGUAGES where form =N'frmPBTBanHanh'AND (VIETNAM LIKE N'%@%')
Delete from LANGUAGES where form =''

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'msgChuaNhapDonViThoiGian') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập đơn vị tính thời gian', ENGLISH=N'Vui lòng nhập đơn vị tính thời gian',CHINESE=N'Vui lòng nhập đơn vị tính thời gian', VIETNAM_OR=N'Vui lòng nhập đơn vị tính thời gian', ENGLISH_OR=N'Vui lòng nhập đơn vị tính thời gian' , CHINESE_OR=N'Vui lòng nhập đơn vị tính thời gian' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'msgChuaNhapDonViThoiGian' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmThongtinthietbi',N'msgChuaNhapDonViThoiGian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmChonVTPT' AND KEYWORD =N'ChonNhanVien') UPDATE LANGUAGES SET VIETNAM=N'Chọn vật tư', ENGLISH=N'Select items',CHINESE=N'Select items', VIETNAM_OR=N'Chọn vật tư', ENGLISH_OR=N'Select items' , CHINESE_OR=N'Select items' WHERE FORM=N'frmChonVTPT' AND KEYWORD=N'ChonNhanVien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmChonVTPT',N'ChonNhanVien',N'Chọn vật tư',N'Select items',N'Select items',N'Chọn vật tư',N'Select items',N'Select items','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhMucHeThong' AND KEYWORD =N'lblTLieu') UPDATE LANGUAGES SET VIETNAM=N'Tài liệu', ENGLISH=N'Document',CHINESE=N'Document', VIETNAM_OR=N'Tài liệu', ENGLISH_OR=N'Document' , CHINESE_OR=N'Document' WHERE FORM=N'frmDanhMucHeThong' AND KEYWORD=N'lblTLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmDanhMucHeThong',N'lblTLieu',N'Tài liệu',N'Document',N'Document',N'Tài liệu',N'Document',N'Document','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'ConPhuTungChuaNhapSLTT') UPDATE LANGUAGES SET VIETNAM=N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú', ENGLISH=N'You should note the reason why you do not have good issues for the planned spare parts in Note column',CHINESE=N'You should note the reason why you do not have good issues for the planned spare parts in Note column', VIETNAM_OR=N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú', ENGLISH_OR=N'You should note the reason why you do not have good issues for the planned spare parts in Note column' , CHINESE_OR=N'You should note the reason why you do not have good issues for the planned spare parts in Note column' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'ConPhuTungChuaNhapSLTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuBaoTri_New',N'ConPhuTungChuaNhapSLTT',N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú',N'You should note the reason why you do not have good issues for the planned spare parts in Note column',N'You should note the reason why you do not have good issues for the planned spare parts in Note column',N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú',N'You should note the reason why you do not have good issues for the planned spare parts in Note column',N'You should note the reason why you do not have good issues for the planned spare parts in Note column','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'CoChacHoanThanh') UPDATE LANGUAGES SET VIETNAM=N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ', ENGLISH=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',CHINESE=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?', VIETNAM_OR=N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ', ENGLISH_OR=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?' , CHINESE_OR=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'CoChacHoanThanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuBaoTri_New',N'CoChacHoanThanh',N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?','ECOMAIN')



IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optForm') UPDATE LANGUAGES SET VIETNAM=N'Chọn form ', ENGLISH=N'Select form ', VIETNAM_OR=N'Chọn form ', ENGLISH_OR=N'Select form ' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optForm' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLanguage',N'optForm',N'Chọn form ',N'Select form ',N'Chọn form ',N'Select form ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optReport') UPDATE LANGUAGES SET VIETNAM=N'Chọn báo cáo', ENGLISH=N'Select report ', VIETNAM_OR=N'Chọn báo cáo', ENGLISH_OR=N'Select report ' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optReport' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLanguage',N'optReport',N'Chọn báo cáo',N'Select report ',N'Chọn báo cáo',N'Select report ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'lblReplay') UPDATE LANGUAGES SET VIETNAM=N'Thay thế bằng ', ENGLISH=N'Replaced by ', VIETNAM_OR=N'Thay thế bằng ', ENGLISH_OR=N'Replaced by ' WHERE FORM=N'frmLanguage' AND KEYWORD=N'lblReplay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLanguage',N'lblReplay',N'Thay thế bằng ',N'Replaced by ',N'Thay thế bằng ',N'Replaced by ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optViet') UPDATE LANGUAGES SET VIETNAM=N'Tiếng Việt ', ENGLISH=N'Vietnamese ', VIETNAM_OR=N'Tiếng Việt ', ENGLISH_OR=N'Vietnamese ' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optViet' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLanguage',N'optViet',N'Tiếng Việt ',N'Vietnamese ',N'Tiếng Việt ',N'Vietnamese ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optAnh') UPDATE LANGUAGES SET VIETNAM=N'Tiếng Anh ', ENGLISH=N'English ', VIETNAM_OR=N'Tiếng Anh ', ENGLISH_OR=N'English ' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optAnh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLanguage',N'optAnh',N'Tiếng Anh ',N'English ',N'Tiếng Anh ',N'English ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'lblDKien') UPDATE LANGUAGES SET VIETNAM=N'Điều kiện ', ENGLISH=N'Condition', VIETNAM_OR=N'Điều kiện ', ENGLISH_OR=N'Condition' WHERE FORM=N'frmLanguage' AND KEYWORD=N'lblDKien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLanguage',N'lblDKien',N'Điều kiện ',N'Condition',N'Điều kiện ',N'Condition')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'chkChinhXac') UPDATE LANGUAGES SET VIETNAM=N'Tìm chính xác', ENGLISH=N'Exact value', VIETNAM_OR=N'Tìm chính xác', ENGLISH_OR=N'Exact value' WHERE FORM=N'frmLanguage' AND KEYWORD=N'chkChinhXac' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmLanguage',N'chkChinhXac',N'Tìm chính xác',N'Exact value',N'Tìm chính xác',N'Exact value')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD =N'MS_DH_NHAP_GOC') UPDATE LANGUAGES SET VIETNAM=N'Phiếu nhập gốc ', ENGLISH=N'Original GR', VIETNAM_OR=N'Phiếu nhập gốc ', ENGLISH_OR=N'Original GR' WHERE FORM=N'frmPhieuNhapKho_New' AND KEYWORD=N'MS_DH_NHAP_GOC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmPhieuNhapKho_New',N'MS_DH_NHAP_GOC',N'Phiếu nhập gốc ',N'Original GR',N'Phiếu nhập gốc ',N'Original GR')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhMucHeThong' AND KEYWORD =N'lblTLieu') UPDATE LANGUAGES SET VIETNAM=N'Tài liệu ', ENGLISH=N'Document ', VIETNAM_OR=N'Tài liệu ', ENGLISH_OR=N'Document ' WHERE FORM=N'frmDanhMucHeThong' AND KEYWORD=N'lblTLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhMucHeThong',N'lblTLieu',N'Tài liệu ',N'Document ',N'Tài liệu ',N'Document ')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'TEN_2') UPDATE LANGUAGES SET VIETNAM=N'Tên tiếng Anh ', ENGLISH=N'English Name ', VIETNAM_OR=N'Tên tiếng Anh ', ENGLISH_OR=N'English Name ' WHERE FORM=N'frmDonvido' AND KEYWORD=N'TEN_2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDonvido',N'TEN_2',N'Tên tiếng Anh ',N'English Name ',N'Tên tiếng Anh ',N'English Name ')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'DVT') UPDATE LANGUAGES SET VIETNAM=N'STT', ENGLISH=N'No', VIETNAM_OR=N'STT', ENGLISH_OR=N'No' WHERE FORM=N'frmDonvido' AND KEYWORD=N'DVT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDonvido',N'DVT',N'STT',N'No',N'STT',N'No')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDonvido' AND KEYWORD =N'TEN_1') UPDATE LANGUAGES SET VIETNAM=N'Tên tiếng Việt', ENGLISH=N'Vietnamese  Name ', VIETNAM_OR=N'Tên tiếng Việt', ENGLISH_OR=N'Vietnamese  Name ' WHERE FORM=N'frmDonvido' AND KEYWORD=N'TEN_1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDonvido',N'TEN_1',N'Tên tiếng Việt',N'Vietnamese  Name ',N'Tên tiếng Việt',N'Vietnamese  Name ')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optForm') UPDATE LANGUAGES SET VIETNAM=N'Form', ENGLISH=N'Form',CHINESE=N'Form', VIETNAM_OR=N'Form', ENGLISH_OR=N'Form' , CHINESE_OR=N'Form' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optForm' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmLanguage',N'optForm',N'Form',N'Form',N'Form',N'Form',N'Form',N'Form','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optReport') UPDATE LANGUAGES SET VIETNAM=N'Report', ENGLISH=N'Report',CHINESE=N'Report', VIETNAM_OR=N'Report', ENGLISH_OR=N'Report' , CHINESE_OR=N'Report' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optReport' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmLanguage',N'optReport',N'Report',N'Report',N'Report',N'Report',N'Report',N'Report','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'lblReplay') UPDATE LANGUAGES SET VIETNAM=N'Thay thế ', ENGLISH=N'Replay',CHINESE=N'Replay', VIETNAM_OR=N'Thay thế ', ENGLISH_OR=N'Replay' , CHINESE_OR=N'Replay' WHERE FORM=N'frmLanguage' AND KEYWORD=N'lblReplay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmLanguage',N'lblReplay',N'Thay thế ',N'Replay',N'Replay',N'Thay thế ',N'Replay',N'Replay','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optViet') UPDATE LANGUAGES SET VIETNAM=N'Việt', ENGLISH=N'Vietnamese',CHINESE=N'Vietnamese', VIETNAM_OR=N'Việt', ENGLISH_OR=N'Vietnamese' , CHINESE_OR=N'Vietnamese' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optViet' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmLanguage',N'optViet',N'Việt',N'Vietnamese',N'Vietnamese',N'Việt',N'Vietnamese',N'Vietnamese','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'optAnh') UPDATE LANGUAGES SET VIETNAM=N'Anh', ENGLISH=N'English',CHINESE=N'English', VIETNAM_OR=N'Anh', ENGLISH_OR=N'English' , CHINESE_OR=N'English' WHERE FORM=N'frmLanguage' AND KEYWORD=N'optAnh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmLanguage',N'optAnh',N'Anh',N'English',N'English',N'Anh',N'English',N'English','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'lblDKien') UPDATE LANGUAGES SET VIETNAM=N'Điều kiện', ENGLISH=N'Condition',CHINESE=N'Condition', VIETNAM_OR=N'Điều kiện', ENGLISH_OR=N'Condition' , CHINESE_OR=N'Condition' WHERE FORM=N'frmLanguage' AND KEYWORD=N'lblDKien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmLanguage',N'lblDKien',N'Điều kiện',N'Condition',N'Condition',N'Điều kiện',N'Condition',N'Condition','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmLanguage' AND KEYWORD =N'chkChinhXac') UPDATE LANGUAGES SET VIETNAM=N'Chính xác', ENGLISH=N'Exact',CHINESE=N'Exact', VIETNAM_OR=N'Chính xác', ENGLISH_OR=N'Exact' , CHINESE_OR=N'Exact' WHERE FORM=N'frmLanguage' AND KEYWORD=N'chkChinhXac' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmLanguage',N'chkChinhXac',N'Chính xác',N'Exact',N'Exact',N'Chính xác',N'Exact',N'Exact','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'msgChuaNhapDonViThoiGian') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập đơn vị tính thời gian', ENGLISH=N'Vui lòng nhập đơn vị tính thời gian',CHINESE=N'Vui lòng nhập đơn vị tính thời gian', VIETNAM_OR=N'Vui lòng nhập đơn vị tính thời gian', ENGLISH_OR=N'Vui lòng nhập đơn vị tính thời gian' , CHINESE_OR=N'Vui lòng nhập đơn vị tính thời gian' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'msgChuaNhapDonViThoiGian' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmThongtinthietbi',N'msgChuaNhapDonViThoiGian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian',N'Vui lòng nhập đơn vị tính thời gian','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'ConPhuTungChuaNhapSLTT') UPDATE LANGUAGES SET VIETNAM=N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú', ENGLISH=N'You should note the reason why you do not have good issues for the planned spare parts in Note column',CHINESE=N'You should note the reason why you do not have good issues for the planned spare parts in Note column', VIETNAM_OR=N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú', ENGLISH_OR=N'You should note the reason why you do not have good issues for the planned spare parts in Note column' , CHINESE_OR=N'You should note the reason why you do not have good issues for the planned spare parts in Note column' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'ConPhuTungChuaNhapSLTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuBaoTri_New',N'ConPhuTungChuaNhapSLTT',N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú',N'You should note the reason why you do not have good issues for the planned spare parts in Note column',N'You should note the reason why you do not have good issues for the planned spare parts in Note column',N'Bạn cần ghi nhận lý do không xuất kho cho những phụ tùng đã lên kế hoạch sử dụng vào cột Ghi chú',N'You should note the reason why you do not have good issues for the planned spare parts in Note column',N'You should note the reason why you do not have good issues for the planned spare parts in Note column','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmChonVTPT' AND KEYWORD =N'ChonNhanVien') UPDATE LANGUAGES SET VIETNAM=N'Chọn vật tư', ENGLISH=N'Select items',CHINESE=N'Select items', VIETNAM_OR=N'Chọn vật tư', ENGLISH_OR=N'Select items' , CHINESE_OR=N'Select items' WHERE FORM=N'frmChonVTPT' AND KEYWORD=N'ChonNhanVien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmChonVTPT',N'ChonNhanVien',N'Chọn vật tư',N'Select items',N'Select items',N'Chọn vật tư',N'Select items',N'Select items','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'CoChacHoanThanh') UPDATE LANGUAGES SET VIETNAM=N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ', ENGLISH=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',CHINESE=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?', VIETNAM_OR=N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ', ENGLISH_OR=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?' , CHINESE_OR=N'Some works has no completion date. Software will update today as completion date. Do you want to continue?' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'CoChacHoanThanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuBaoTri_New',N'CoChacHoanThanh',N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',N'Một số công việc chưa có ngày hoàn thành. Phần mềm sẽ cập nhật ngày hoàn thành bằng ngày hiện tại. Bạn có muốn tiếp tục? ',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?',N'Some works has no completion date. Software will update today as completion date. Do you want to continue?','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuXuatKhoVatTu_CS' AND KEYWORD =N'msgKhongDuTon') UPDATE LANGUAGES SET VIETNAM=N'Không đủ tồn để xuất kho', ENGLISH=N'There is not enough inventory for issuing',CHINESE=N'There is not enough inventory for issuing', VIETNAM_OR=N'Không đủ tồn để xuất kho', ENGLISH_OR=N'There is not enough inventory for issuing' , CHINESE_OR=N'There is not enough inventory for issuing' WHERE FORM=N'FrmPhieuXuatKhoVatTu_CS' AND KEYWORD=N'msgKhongDuTon' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuXuatKhoVatTu_CS',N'msgKhongDuTon',N'Không đủ tồn để xuất kho',N'There is not enough inventory for issuing',N'There is not enough inventory for issuing',N'Không đủ tồn để xuất kho',N'There is not enough inventory for issuing',N'There is not enough inventory for issuing','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuXuatKhoVatTu_CS' AND KEYWORD =N'msgXuatChuyenKhoKhongThanhCong') UPDATE LANGUAGES SET VIETNAM=N'Xuất chuyển kho không thành công', ENGLISH=N'Adding data to intermediate database is not successful',CHINESE=N'Adding data to intermediate database is not successful', VIETNAM_OR=N'Xuất chuyển kho không thành công', ENGLISH_OR=N'Adding data to intermediate database is not successful' , CHINESE_OR=N'Adding data to intermediate database is not successful' WHERE FORM=N'FrmPhieuXuatKhoVatTu_CS' AND KEYWORD=N'msgXuatChuyenKhoKhongThanhCong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuXuatKhoVatTu_CS',N'msgXuatChuyenKhoKhongThanhCong',N'Xuất chuyển kho không thành công',N'Adding data to intermediate database is not successful',N'Adding data to intermediate database is not successful',N'Xuất chuyển kho không thành công',N'Adding data to intermediate database is not successful',N'Adding data to intermediate database is not successful','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuXuatKhoVatTu_CS' AND KEYWORD =N'msgThemVaoDataTrungGianKhongThanhCong') UPDATE LANGUAGES SET VIETNAM=N'Thêm vào data trung gian không thành công', ENGLISH=N'Inventory issuing to intermediate warehouse is not successful',CHINESE=N'Inventory issuing to intermediate warehouse is not successful', VIETNAM_OR=N'Thêm vào data trung gian không thành công', ENGLISH_OR=N'Inventory issuing to intermediate warehouse is not successful' , CHINESE_OR=N'Inventory issuing to intermediate warehouse is not successful' WHERE FORM=N'FrmPhieuXuatKhoVatTu_CS' AND KEYWORD=N'msgThemVaoDataTrungGianKhongThanhCong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuXuatKhoVatTu_CS',N'msgThemVaoDataTrungGianKhongThanhCong',N'Thêm vào data trung gian không thành công',N'Inventory issuing to intermediate warehouse is not successful',N'Inventory issuing to intermediate warehouse is not successful',N'Thêm vào data trung gian không thành công',N'Inventory issuing to intermediate warehouse is not successful',N'Inventory issuing to intermediate warehouse is not successful','ECOMAIN')