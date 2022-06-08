﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnDuongDan') UPDATE LANGUAGES SET VIETNAM=N'...', ENGLISH=N'...', VIETNAM_OR=N'...', ENGLISH_OR=N'...' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnDuongDan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnDuongDan',N'...',N'...',N'...',N'...')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnGhi',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'btnKhongghi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'btnKhongghi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'btnKhongghi',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnSua',N'Sửa',N'Edit',N'Sửa',N'Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnThem',N'Thêm',N'Add',N'Thêm',N'Add')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnThoat') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnThoat',N'T&hoát',N'E&xit',N'T&hoát',N'E&xit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnTrove') UPDATE LANGUAGES SET VIETNAM=N'T&rở về', ENGLISH=N'&Return', VIETNAM_OR=N'T&rở về', ENGLISH_OR=N'&Return' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnTrove' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnTrove',N'T&rở về',N'&Return',N'T&rở về',N'&Return')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnXoa') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnXoa',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnXoagiatri') UPDATE LANGUAGES SET VIETNAM=N'Xóa &tình trạng HM', ENGLISH=N'Delete &condition', VIETNAM_OR=N'Xóa &tình trạng HM', ENGLISH_OR=N'Delete &condition' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnXoagiatri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnXoagiatri',N'Xóa &tình trạng HM',N'Delete &condition',N'Xóa &tình trạng HM',N'Delete &condition')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'BtnXoathongso') UPDATE LANGUAGES SET VIETNAM=N'Xóa &thông số', ENGLISH=N'Delete &parameter', VIETNAM_OR=N'Xóa &thông số', ENGLISH_OR=N'Delete &parameter' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'BtnXoathongso' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'BtnXoathongso',N'Xóa &thông số',N'Delete &parameter',N'Xóa &thông số',N'Delete &parameter')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'chkDinhtinh') UPDATE LANGUAGES SET VIETNAM=N'Định tính', ENGLISH=N'Qualitative', VIETNAM_OR=N'Định tính', ENGLISH_OR=N'Qualitative' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'chkDinhtinh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'chkDinhtinh',N'Định tính',N'Qualitative',N'Định tính',N'Qualitative')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'DAT') UPDATE LANGUAGES SET VIETNAM=N'Không cảnh báo', ENGLISH=N'No alert', VIETNAM_OR=N'Không cảnh báo', ENGLISH_OR=N'No alert' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'DAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'DAT',N'Không cảnh báo',N'No alert',N'Không cảnh báo',N'No alert')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'DUONG_DAN') UPDATE LANGUAGES SET VIETNAM=N'Đường dẫn file hướng dẫn', ENGLISH=N'Instruction file path', VIETNAM_OR=N'Đường dẫn file hướng dẫn', ENGLISH_OR=N'Instruction file path' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'DUONG_DAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'DUONG_DAN',N'Đường dẫn file hướng dẫn',N'Instruction file path',N'Đường dẫn file hướng dẫn',N'Instruction file path')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'frmThongsoGSTT') UPDATE LANGUAGES SET VIETNAM=N'Thông số giám sát tình trạng', ENGLISH=N'CM parameter', VIETNAM_OR=N'Thông số giám sát tình trạng', ENGLISH_OR=N'CM parameter' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'frmThongsoGSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'frmThongsoGSTT',N'Thông số giám sát tình trạng',N'CM parameter',N'Thông số giám sát tình trạng',N'CM parameter')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'GHI_CHU',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'GrpDanhmucthongso') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thông số', ENGLISH=N'List of parameter', VIETNAM_OR=N'Danh sách thông số', ENGLISH_OR=N'List of parameter' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'GrpDanhmucthongso' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'GrpDanhmucthongso',N'Danh sách thông số',N'List of parameter',N'Danh sách thông số',N'List of parameter')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'grpDieuKienLoc') UPDATE LANGUAGES SET VIETNAM=N'Điều kiện lọc', ENGLISH=N'Filter condition', VIETNAM_OR=N'Điều kiện lọc', ENGLISH_OR=N'Filter condition' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'grpDieuKienLoc' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'grpDieuKienLoc',N'Điều kiện lọc',N'Filter condition',N'Điều kiện lọc',N'Filter condition')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'grpGiatrithongsoGSTT') UPDATE LANGUAGES SET VIETNAM=N'Danh sách kết quả (có thể có) của thông số', ENGLISH=N'List of possible results of parameter', VIETNAM_OR=N'Danh sách kết quả (có thể có) của thông số', ENGLISH_OR=N'List of possible results of parameter' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'grpGiatrithongsoGSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'grpGiatrithongsoGSTT',N'Danh sách kết quả (có thể có) của thông số',N'List of possible results of parameter',N'Danh sách kết quả (có thể có) của thông số',N'List of possible results of parameter')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'GrpNhapthongso') UPDATE LANGUAGES SET VIETNAM=N'Nhập thông tin', ENGLISH=N'Input info', VIETNAM_OR=N'Nhập thông tin', ENGLISH_OR=N'Input info' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'GrpNhapthongso' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'GrpNhapthongso',N'Nhập thông tin',N'Input info',N'Nhập thông tin',N'Input info')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblChonTenbophan') UPDATE LANGUAGES SET VIETNAM=N'Lọc theo tên bộ phận', ENGLISH=N'Filter by component', VIETNAM_OR=N'Lọc theo tên bộ phận', ENGLISH_OR=N'Filter by component' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblChonTenbophan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblChonTenbophan',N'Lọc theo tên bộ phận',N'Filter by component',N'Lọc theo tên bộ phận',N'Filter by component')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblDinhtinh') UPDATE LANGUAGES SET VIETNAM=N'Định tính', ENGLISH=N'Qualitative', VIETNAM_OR=N'Định tính', ENGLISH_OR=N'Qualitative' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblDinhtinh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblDinhtinh',N'Định tính',N'Qualitative',N'Định tính',N'Qualitative')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblDonvido') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị đo', ENGLISH=N'UoM', VIETNAM_OR=N'Đơn vị đo', ENGLISH_OR=N'UoM' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblDonvido' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblDonvido',N'Đơn vị đo',N'UoM',N'Đơn vị đo',N'UoM')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblDonvido_loc') UPDATE LANGUAGES SET VIETNAM=N'Lọc theo đơn vị đo', ENGLISH=N'Filter by Unit', VIETNAM_OR=N'Lọc theo đơn vị đo', ENGLISH_OR=N'Filter by Unit' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblDonvido_loc' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblDonvido_loc',N'Lọc theo đơn vị đo',N'Filter by Unit',N'Lọc theo đơn vị đo',N'Filter by Unit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblDuongDan') UPDATE LANGUAGES SET VIETNAM=N'Đường dẫn file HD', ENGLISH=N'Instruction file path', VIETNAM_OR=N'Đường dẫn file HD', ENGLISH_OR=N'Instruction file path' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblDuongDan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblDuongDan',N'Đường dẫn file HD',N'Instruction file path',N'Đường dẫn file HD',N'Instruction file path')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblGhichu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblGhichu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblGhichu',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'LblMathongsoTB') UPDATE LANGUAGES SET VIETNAM=N'Mã số  ', ENGLISH=N'CM parameter ID', VIETNAM_OR=N'Mã số  ', ENGLISH_OR=N'CM parameter ID' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'LblMathongsoTB' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'LblMathongsoTB',N'Mã số  ',N'CM parameter ID',N'Mã số  ',N'CM parameter ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblMS_BP_GSTT') UPDATE LANGUAGES SET VIETNAM=N'Tên bộ phận', ENGLISH=N'Component name', VIETNAM_OR=N'Tên bộ phận', ENGLISH_OR=N'Component name' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblMS_BP_GSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblMS_BP_GSTT',N'Tên bộ phận',N'Component name',N'Tên bộ phận',N'Component name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'LblTenthongso') UPDATE LANGUAGES SET VIETNAM=N'Tên thông số', ENGLISH=N'Parameter name', VIETNAM_OR=N'Tên thông số', ENGLISH_OR=N'Parameter name' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'LblTenthongso' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'LblTenthongso',N'Tên thông số',N'Parameter name',N'Tên thông số',N'Parameter name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'LblTieudethongsoGSTT') UPDATE LANGUAGES SET VIETNAM=N'THÔNG SỐ GIÁM SÁT TÌNH TRẠNG', ENGLISH=N'CONDITION MONITORING PARAMETERS', VIETNAM_OR=N'THÔNG SỐ GIÁM SÁT TÌNH TRẠNG', ENGLISH_OR=N'CONDITION MONITORING PARAMETERS' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'LblTieudethongsoGSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'LblTieudethongsoGSTT',N'THÔNG SỐ GIÁM SÁT TÌNH TRẠNG',N'CONDITION MONITORING PARAMETERS',N'THÔNG SỐ GIÁM SÁT TÌNH TRẠNG',N'CONDITION MONITORING PARAMETERS')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'lblTinhtrang') UPDATE LANGUAGES SET VIETNAM=N'Tình trạng', ENGLISH=N'Condition', VIETNAM_OR=N'Tình trạng', ENGLISH_OR=N'Condition' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'lblTinhtrang' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'lblTinhtrang',N'Tình trạng',N'Condition',N'Tình trạng',N'Condition')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'LOAI_TS') UPDATE LANGUAGES SET VIETNAM=N'Định tính', ENGLISH=N'Qualitative', VIETNAM_OR=N'Định tính', ENGLISH_OR=N'Qualitative' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'LOAI_TS' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'LOAI_TS',N'Định tính',N'Qualitative',N'Định tính',N'Qualitative')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MS_BP_GSTT') UPDATE LANGUAGES SET VIETNAM=N'Mã BP GSTT', ENGLISH=N'CM Component ID', VIETNAM_OR=N'Mã BP GSTT', ENGLISH_OR=N'CM Component ID' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MS_BP_GSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MS_BP_GSTT',N'Mã BP GSTT',N'CM Component ID',N'Mã BP GSTT',N'CM Component ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MS_DV_DO') UPDATE LANGUAGES SET VIETNAM=N'Mã đơn vị đo', ENGLISH=N'UoM ID', VIETNAM_OR=N'Mã đơn vị đo', ENGLISH_OR=N'UoM ID' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MS_DV_DO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MS_DV_DO',N'Mã đơn vị đo',N'UoM ID',N'Mã đơn vị đo',N'UoM ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MS_TS_GSTT') UPDATE LANGUAGES SET VIETNAM=N'Mã số ', ENGLISH=N'CM parameter ID', VIETNAM_OR=N'Mã số ', ENGLISH_OR=N'CM parameter ID' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MS_TS_GSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MS_TS_GSTT',N'Mã số ',N'CM parameter ID',N'Mã số ',N'CM parameter ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgChonbophan') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn bộ phận giám sát!', ENGLISH=N'Please select component name!', VIETNAM_OR=N'Vui lòng chọn bộ phận giám sát!', ENGLISH_OR=N'Please select component name!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgChonbophan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgChonbophan',N'Vui lòng chọn bộ phận giám sát!',N'Please select component name!',N'Vui lòng chọn bộ phận giám sát!',N'Please select component name!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgChuachonbophan') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn lại tên bộ phận!', ENGLISH=N'Please re-select a component!', VIETNAM_OR=N'Vui lòng chọn lại tên bộ phận!', ENGLISH_OR=N'Please re-select a component!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgChuachonbophan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgChuachonbophan',N'Vui lòng chọn lại tên bộ phận!',N'Please re-select a component!',N'Vui lòng chọn lại tên bộ phận!',N'Please re-select a component!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgGhi1') UPDATE LANGUAGES SET VIETNAM=N'MS thông số này đã tồn tại. Vui lòng chọn thông số khác.', ENGLISH=N'CM parameter ID already exists. Please input again!', VIETNAM_OR=N'MS thông số này đã tồn tại. Vui lòng chọn thông số khác.', ENGLISH_OR=N'CM parameter ID already exists. Please input again!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgGhi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgGhi1',N'MS thông số này đã tồn tại. Vui lòng chọn thông số khác.',N'CM parameter ID already exists. Please input again!',N'MS thông số này đã tồn tại. Vui lòng chọn thông số khác.',N'CM parameter ID already exists. Please input again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgGhi2') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị đo không được rỗng! Vui lòng chọn đơn vị đo!', ENGLISH=N'Unit of measurement cannot be empty.', VIETNAM_OR=N'Đơn vị đo không được rỗng! Vui lòng chọn đơn vị đo!', ENGLISH_OR=N'Unit of measurement cannot be empty.' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgGhi2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgGhi2',N'Đơn vị đo không được rỗng! Vui lòng chọn đơn vị đo!',N'Unit of measurement cannot be empty.',N'Đơn vị đo không được rỗng! Vui lòng chọn đơn vị đo!',N'Unit of measurement cannot be empty.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgGhiChu') UPDATE LANGUAGES SET VIETNAM=N'Chiều dài của ghi chú lớn hơn qui định.', ENGLISH=N'Note exceeded permitted length!', VIETNAM_OR=N'Chiều dài của ghi chú lớn hơn qui định.', ENGLISH_OR=N'Note exceeded permitted length!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgGhiChu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgGhiChu',N'Chiều dài của ghi chú lớn hơn qui định.',N'Note exceeded permitted length!',N'Chiều dài của ghi chú lớn hơn qui định.',N'Note exceeded permitted length!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgGiatridinhtinhnull') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập giá trị!', ENGLISH=N'Please enter value!', VIETNAM_OR=N'Vui lòng nhập giá trị!', ENGLISH_OR=N'Please enter value!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgGiatridinhtinhnull' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgGiatridinhtinhnull',N'Vui lòng nhập giá trị!',N'Please enter value!',N'Vui lòng nhập giá trị!',N'Please enter value!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgKiemtra9') UPDATE LANGUAGES SET VIETNAM=N'Không tìm thấy đường dẫn!', ENGLISH=N'Path is not found!', VIETNAM_OR=N'Không tìm thấy đường dẫn!', ENGLISH_OR=N'Path is not found!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgKiemtra9' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgKiemtra9',N'Không tìm thấy đường dẫn!',N'Path is not found!',N'Không tìm thấy đường dẫn!',N'Path is not found!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgLikeName') UPDATE LANGUAGES SET VIETNAM=N'Tên thông số đã tồn tại. Vui lòng nhập lại!', ENGLISH=N'Item name already exists. Please input again!', VIETNAM_OR=N'Tên thông số đã tồn tại. Vui lòng nhập lại!', ENGLISH_OR=N'Item name already exists. Please input again!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgLikeName' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgLikeName',N'Tên thông số đã tồn tại. Vui lòng nhập lại!',N'Item name already exists. Please input again!',N'Tên thông số đã tồn tại. Vui lòng nhập lại!',N'Item name already exists. Please input again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgMSisNumber') UPDATE LANGUAGES SET VIETNAM=N'Mã số phải là số!', ENGLISH=N'Parameter ID must be a number!', VIETNAM_OR=N'Mã số phải là số!', ENGLISH_OR=N'Parameter ID must be a number!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgMSisNumber' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgMSisNumber',N'Mã số phải là số!',N'Parameter ID must be a number!',N'Mã số phải là số!',N'Parameter ID must be a number!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgNull') UPDATE LANGUAGES SET VIETNAM=N'Tình trạng không được để trống. Vui lòng nhập dữ liệu!', ENGLISH=N'Condition cannot be empty. Please input data!', VIETNAM_OR=N'Tình trạng không được để trống. Vui lòng nhập dữ liệu!', ENGLISH_OR=N'Condition cannot be empty. Please input data!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgNull' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgNull',N'Tình trạng không được để trống. Vui lòng nhập dữ liệu!',N'Condition cannot be empty. Please input data!',N'Tình trạng không được để trống. Vui lòng nhập dữ liệu!',N'Condition cannot be empty. Please input data!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'msgTEN_GIA_TRI') UPDATE LANGUAGES SET VIETNAM=N'Tên giá trị không được rỗng! Bạn vui lòng nhập vào tên giá trị!', ENGLISH=N'Value name cannot be empty. Please input value name!', VIETNAM_OR=N'Tên giá trị không được rỗng! Bạn vui lòng nhập vào tên giá trị!', ENGLISH_OR=N'Value name cannot be empty. Please input value name!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'msgTEN_GIA_TRI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'msgTEN_GIA_TRI',N'Tên giá trị không được rỗng! Bạn vui lòng nhập vào tên giá trị!',N'Value name cannot be empty. Please input value name!',N'Tên giá trị không được rỗng! Bạn vui lòng nhập vào tên giá trị!',N'Value name cannot be empty. Please input value name!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgTEN_TS') UPDATE LANGUAGES SET VIETNAM=N'Tên thông số này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH=N'This parameter already exists. Please input another!', VIETNAM_OR=N'Tên thông số này đã tồn tại. Vui lòng chọn tên khác.', ENGLISH_OR=N'This parameter already exists. Please input another!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgTEN_TS' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgTEN_TS',N'Tên thông số này đã tồn tại. Vui lòng chọn tên khác.',N'This parameter already exists. Please input another!',N'Tên thông số này đã tồn tại. Vui lòng chọn tên khác.',N'This parameter already exists. Please input another!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgTengiatri') UPDATE LANGUAGES SET VIETNAM=N'Tên giá trị đã tồn tại!', ENGLISH=N'This name of item already exists.', VIETNAM_OR=N'Tên giá trị đã tồn tại!', ENGLISH_OR=N'This name of item already exists.' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgTengiatri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgTengiatri',N'Tên giá trị đã tồn tại!',N'This name of item already exists.',N'Tên giá trị đã tồn tại!',N'This name of item already exists.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgTengiatriMax') UPDATE LANGUAGES SET VIETNAM=N'Tên giá trị dài hơn qui định!', ENGLISH=N'Value name is too long.', VIETNAM_OR=N'Tên giá trị dài hơn qui định!', ENGLISH_OR=N'Value name is too long.' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgTengiatriMax' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgTengiatriMax',N'Tên giá trị dài hơn qui định!',N'Value name is too long.',N'Tên giá trị dài hơn qui định!',N'Value name is too long.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgTenthongso') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập tên thông số!', ENGLISH=N'Please enter parameter name!', VIETNAM_OR=N'Vui lòng nhập tên thông số!', ENGLISH_OR=N'Please enter parameter name!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgTenthongso' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgTenthongso',N'Vui lòng nhập tên thông số!',N'Please enter parameter name!',N'Vui lòng nhập tên thông số!',N'Please enter parameter name!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgXoa1') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu để xóa!', ENGLISH=N'There is no data to delete!', VIETNAM_OR=N'Không có dữ liệu để xóa!', ENGLISH_OR=N'There is no data to delete!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgXoa1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgXoa1',N'Không có dữ liệu để xóa!',N'There is no data to delete!',N'Không có dữ liệu để xóa!',N'There is no data to delete!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgXoa2') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa dữ liệu không?', ENGLISH=N'Do you want to delete this data?', VIETNAM_OR=N'Bạn có muốn xóa dữ liệu không?', ENGLISH_OR=N'Do you want to delete this data?' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgXoa2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgXoa2',N'Bạn có muốn xóa dữ liệu không?',N'Do you want to delete this data?',N'Bạn có muốn xóa dữ liệu không?',N'Do you want to delete this data?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgXoa3') UPDATE LANGUAGES SET VIETNAM=N'Thông số này đang được sử dụng trong cấu trúc thiết bị, bạn không thể xóa!', ENGLISH=N'This parameter cannot be deleted because it is being used in condition monitoring!', VIETNAM_OR=N'Thông số này đang được sử dụng trong cấu trúc thiết bị, bạn không thể xóa!', ENGLISH_OR=N'This parameter cannot be deleted because it is being used in condition monitoring!' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgXoa3' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgXoa3',N'Thông số này đang được sử dụng trong cấu trúc thiết bị, bạn không thể xóa!',N'This parameter cannot be deleted because it is being used in condition monitoring!',N'Thông số này đang được sử dụng trong cấu trúc thiết bị, bạn không thể xóa!',N'This parameter cannot be deleted because it is being used in condition monitoring!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgXoa4') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng cho máy, bạn không thể xóa!', ENGLISH=N'The data cannot be deleted because it is being used in Equipment.', VIETNAM_OR=N'Dữ liệu đang sử dụng cho máy, bạn không thể xóa!', ENGLISH_OR=N'The data cannot be deleted because it is being used in Equipment.' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgXoa4' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgXoa4',N'Dữ liệu đang sử dụng cho máy, bạn không thể xóa!',N'The data cannot be deleted because it is being used in Equipment.',N'Dữ liệu đang sử dụng cho máy, bạn không thể xóa!',N'The data cannot be deleted because it is being used in Equipment.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgXoagiatri1') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu để xóa', ENGLISH=N'There is no data to delete', VIETNAM_OR=N'Không có dữ liệu để xóa', ENGLISH_OR=N'There is no data to delete' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgXoagiatri1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgXoagiatri1',N'Không có dữ liệu để xóa',N'There is no data to delete',N'Không có dữ liệu để xóa',N'There is no data to delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgXoagiatri2') UPDATE LANGUAGES SET VIETNAM=N'Bạn có thật sự muốn xóa giá trị thông số giám sát tình trạng này không?', ENGLISH=N'Do you really want to delete this CM parameter?', VIETNAM_OR=N'Bạn có thật sự muốn xóa giá trị thông số giám sát tình trạng này không?', ENGLISH_OR=N'Do you really want to delete this CM parameter?' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgXoagiatri2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgXoagiatri2',N'Bạn có thật sự muốn xóa giá trị thông số giám sát tình trạng này không?',N'Do you really want to delete this CM parameter?',N'Bạn có thật sự muốn xóa giá trị thông số giám sát tình trạng này không?',N'Do you really want to delete this CM parameter?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'MsgXoagiatri21') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu không thể xóa vì đang sử dụng trong bảng khác!', ENGLISH=N'This data cannot be deleted because it is currently in use', VIETNAM_OR=N'Dữ liệu không thể xóa vì đang sử dụng trong bảng khác!', ENGLISH_OR=N'This data cannot be deleted because it is currently in use' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'MsgXoagiatri21' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'MsgXoagiatri21',N'Dữ liệu không thể xóa vì đang sử dụng trong bảng khác!',N'This data cannot be deleted because it is currently in use',N'Dữ liệu không thể xóa vì đang sử dụng trong bảng khác!',N'This data cannot be deleted because it is currently in use')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'rdDinhluong') UPDATE LANGUAGES SET VIETNAM=N'Định lượng', ENGLISH=N'Quantitative', VIETNAM_OR=N'Định lượng', ENGLISH_OR=N'Quantitative' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'rdDinhluong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'rdDinhluong',N'Định lượng',N'Quantitative',N'Định lượng',N'Quantitative')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'rdDinhtinh') UPDATE LANGUAGES SET VIETNAM=N'Định tính', ENGLISH=N'Qualitative', VIETNAM_OR=N'Định tính', ENGLISH_OR=N'Qualitative' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'rdDinhtinh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'rdDinhtinh',N'Định tính',N'Qualitative',N'Định tính',N'Qualitative')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'STT') UPDATE LANGUAGES SET VIETNAM=N'STT', ENGLISH=N'No.', VIETNAM_OR=N'STT', ENGLISH_OR=N'No.' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'STT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'STT',N'STT',N'No.',N'STT',N'No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'TabDanhsachthongso') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thông số', ENGLISH=N'List of parameters', VIETNAM_OR=N'Danh sách thông số', ENGLISH_OR=N'List of parameters' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'TabDanhsachthongso' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'TabDanhsachthongso',N'Danh sách thông số',N'List of parameters',N'Danh sách thông số',N'List of parameters')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'TabGiatrithongso') UPDATE LANGUAGES SET VIETNAM=N'Danh sách kết quả (có thể có) của thông số', ENGLISH=N'List of possible results of parameter', VIETNAM_OR=N'Danh sách kết quả (có thể có) của thông số', ENGLISH_OR=N'List of possible results of parameter' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'TabGiatrithongso' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'TabGiatrithongso',N'Danh sách kết quả (có thể có) của thông số',N'List of possible results of parameter',N'Danh sách kết quả (có thể có) của thông số',N'List of possible results of parameter')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'TEN_BP_GSTT') UPDATE LANGUAGES SET VIETNAM=N'Tên BP GSTT', ENGLISH=N'CM Component', VIETNAM_OR=N'Tên BP GSTT', ENGLISH_OR=N'CM Component' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'TEN_BP_GSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'TEN_BP_GSTT',N'Tên BP GSTT',N'CM Component',N'Tên BP GSTT',N'CM Component')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'TEN_DV_DO') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị đo', ENGLISH=N'UoM', VIETNAM_OR=N'Đơn vị đo', ENGLISH_OR=N'UoM' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'TEN_DV_DO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'TEN_DV_DO',N'Đơn vị đo',N'UoM',N'Đơn vị đo',N'UoM')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'TEN_GIA_TRI') UPDATE LANGUAGES SET VIETNAM=N'Tên kết quả', ENGLISH=N'List of results', VIETNAM_OR=N'Tên kết quả', ENGLISH_OR=N'List of results' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'TEN_GIA_TRI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'TEN_GIA_TRI',N'Tên kết quả',N'List of results',N'Tên kết quả',N'List of results')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'TEN_TS_GSTT') UPDATE LANGUAGES SET VIETNAM=N'Tên thông số', ENGLISH=N'CM parameter name', VIETNAM_OR=N'Tên thông số', ENGLISH_OR=N'CM parameter name' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'TEN_TS_GSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'TEN_TS_GSTT',N'Tên thông số',N'CM parameter name',N'Tên thông số',N'CM parameter name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'TINH_TRANG') UPDATE LANGUAGES SET VIETNAM=N'Tình trạng', ENGLISH=N'Condition', VIETNAM_OR=N'Tình trạng', ENGLISH_OR=N'Condition' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'TINH_TRANG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'TINH_TRANG',N'Tình trạng',N'Condition',N'Tình trạng',N'Condition')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'btnVideo') UPDATE LANGUAGES SET VIETNAM=N'@btnVideo@', ENGLISH=N'@btnVideo@', VIETNAM_OR=N'@btnVideo@', ENGLISH_OR=N'@btnVideo@' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'btnVideo' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'btnVideo',N'@btnVideo@',N'@btnVideo@',N'@btnVideo@',N'@btnVideo@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongsoGSTT' AND KEYWORD =N'btnHelp') UPDATE LANGUAGES SET VIETNAM=N'@btnHelp@', ENGLISH=N'@btnHelp@', VIETNAM_OR=N'@btnHelp@', ENGLISH_OR=N'@btnHelp@' WHERE FORM=N'frmThongsoGSTT' AND KEYWORD=N'btnHelp' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongsoGSTT',N'btnHelp',N'@btnHelp@',N'@btnHelp@',N'@btnHelp@',N'@btnHelp@')
