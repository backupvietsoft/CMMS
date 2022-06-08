﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'tabRequest') UPDATE LANGUAGES SET VIETNAM=N'Yêu cầu của người sử dụng', ENGLISH=N'User request',CHINESE=N'User request', VIETNAM_OR=N'Yêu cầu của người sử dụng', ENGLISH_OR=N'User request' , CHINESE_OR=N'User request' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'tabRequest' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'tabRequest',N'Yêu cầu của người sử dụng',N'User request',N'User request',N'Yêu cầu của người sử dụng',N'User request',N'User request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'tabRequestDetail') UPDATE LANGUAGES SET VIETNAM=N'Chi tiết yêu cầu', ENGLISH=N'Details of Request',CHINESE=N'Details of Request', VIETNAM_OR=N'Chi tiết yêu cầu', ENGLISH_OR=N'Details of Request' , CHINESE_OR=N'Details of Request' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'tabRequestDetail' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'tabRequestDetail',N'Chi tiết yêu cầu',N'Details of Request',N'Details of Request',N'Chi tiết yêu cầu',N'Details of Request',N'Details of Request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'UserRequestID') UPDATE LANGUAGES SET VIETNAM=N'Số yêu cầu', ENGLISH=N'Request No.',CHINESE=N'Request No.', VIETNAM_OR=N'Số yêu cầu', ENGLISH_OR=N'Request No.' , CHINESE_OR=N'Request No.' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'UserRequestID' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'UserRequestID',N'Số yêu cầu',N'Request No.',N'Request No.',N'Số yêu cầu',N'Request No.',N'Request No.','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'DateCreated') UPDATE LANGUAGES SET VIETNAM=N'Ngày yêu cầu', ENGLISH=N'Request date',CHINESE=N'Request date', VIETNAM_OR=N'Ngày yêu cầu', ENGLISH_OR=N'Request date' , CHINESE_OR=N'Request date' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'DateCreated' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'DateCreated',N'Ngày yêu cầu',N'Request date',N'Request date',N'Ngày yêu cầu',N'Request date',N'Request date','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'HourCreated') UPDATE LANGUAGES SET VIETNAM=N'Giờ yêu cầu', ENGLISH=N'Request time',CHINESE=N'Request time', VIETNAM_OR=N'Giờ yêu cầu', ENGLISH_OR=N'Request time' , CHINESE_OR=N'Request time' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'HourCreated' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'HourCreated',N'Giờ yêu cầu',N'Request time',N'Request time',N'Giờ yêu cầu',N'Request time',N'Request time','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'RequestedBy') UPDATE LANGUAGES SET VIETNAM=N'Người yêu cầu', ENGLISH=N'Requested by',CHINESE=N'Requested by', VIETNAM_OR=N'Người yêu cầu', ENGLISH_OR=N'Requested by' , CHINESE_OR=N'Requested by' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'RequestedBy' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'RequestedBy',N'Người yêu cầu',N'Requested by',N'Requested by',N'Người yêu cầu',N'Requested by',N'Requested by','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'DateCompleted') UPDATE LANGUAGES SET VIETNAM=N'Ngày hoàn thành', ENGLISH=N'Completion date',CHINESE=N'Completion date', VIETNAM_OR=N'Ngày hoàn thành', ENGLISH_OR=N'Completion date' , CHINESE_OR=N'Completion date' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'DateCompleted' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'DateCompleted',N'Ngày hoàn thành',N'Completion date',N'Completion date',N'Ngày hoàn thành',N'Completion date',N'Completion date','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnGhi') UPDATE LANGUAGES SET VIETNAM=N'Ghi', ENGLISH=N'Save',CHINESE=N'Save', VIETNAM_OR=N'Ghi', ENGLISH_OR=N'Save' , CHINESE_OR=N'Save' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnGhi',N'Ghi',N'Save',N'Save',N'Ghi',N'Save',N'Save','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnHuy') UPDATE LANGUAGES SET VIETNAM=N'Hủy', ENGLISH=N'Cancel',CHINESE=N'Cancel', VIETNAM_OR=N'Hủy', ENGLISH_OR=N'Cancel' , CHINESE_OR=N'Cancel' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnHuy' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnHuy',N'Hủy',N'Cancel',N'Cancel',N'Hủy',N'Cancel',N'Cancel','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit',CHINESE=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' , CHINESE_OR=N'Edit' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnSua',N'Sửa',N'Edit',N'Edit',N'Sửa',N'Edit',N'Edit','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnSuahinh') UPDATE LANGUAGES SET VIETNAM=N'Thêm hình', ENGLISH=N'Add picture',CHINESE=N'Add picture', VIETNAM_OR=N'Thêm hình', ENGLISH_OR=N'Add picture' , CHINESE_OR=N'Add picture' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnSuahinh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnSuahinh',N'Thêm hình',N'Add picture',N'Add picture',N'Thêm hình',N'Add picture',N'Add picture','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add',CHINESE=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' , CHINESE_OR=N'Add' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnThem',N'Thêm',N'Add',N'Add',N'Thêm',N'Add',N'Add','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add',CHINESE=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' , CHINESE_OR=N'Add' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnThem',N'Thêm',N'Add',N'Add',N'Thêm',N'Add',N'Add','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add',CHINESE=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' , CHINESE_OR=N'Add' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnThem',N'Thêm',N'Add',N'Add',N'Thêm',N'Add',N'Add','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnTroVe') UPDATE LANGUAGES SET VIETNAM=N'Trở về', ENGLISH=N'Cancel',CHINESE=N'Cancel', VIETNAM_OR=N'Trở về', ENGLISH_OR=N'Cancel' , CHINESE_OR=N'Cancel' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnTroVe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnTroVe',N'Trở về',N'Cancel',N'Cancel',N'Trở về',N'Cancel',N'Cancel','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnXoa') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete',CHINESE=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' , CHINESE_OR=N'Delete' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnXoa',N'Xóa',N'Delete',N'Delete',N'Xóa',N'Delete',N'Delete','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'btnXoabp') UPDATE LANGUAGES SET VIETNAM=N'Xóa bộ phận', ENGLISH=N'Delete component',CHINESE=N'Delete component', VIETNAM_OR=N'Xóa bộ phận', ENGLISH_OR=N'Delete component' , CHINESE_OR=N'Delete component' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'btnXoabp' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'btnXoabp',N'Xóa bộ phận',N'Delete component',N'Delete component',N'Xóa bộ phận',N'Delete component',N'Delete component','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'CauseID') UPDATE LANGUAGES SET VIETNAM=N'Tên nguyên nhân', ENGLISH=N'Cause name',CHINESE=N'Cause name', VIETNAM_OR=N'Tên nguyên nhân', ENGLISH_OR=N'Cause name' , CHINESE_OR=N'Cause name' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'CauseID' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'CauseID',N'Tên nguyên nhân',N'Cause name',N'Cause name',N'Tên nguyên nhân',N'Cause name',N'Cause name','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'ComponentID') UPDATE LANGUAGES SET VIETNAM=N'Mã bộ phận', ENGLISH=N'Component',CHINESE=N'Component', VIETNAM_OR=N'Mã bộ phận', ENGLISH_OR=N'Component' , CHINESE_OR=N'Component' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'ComponentID' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'ComponentID',N'Mã bộ phận',N'Component',N'Component',N'Mã bộ phận',N'Component',N'Component','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'ComponentName') UPDATE LANGUAGES SET VIETNAM=N'Tên bộ phận', ENGLISH=N'Component',CHINESE=N'Component', VIETNAM_OR=N'Tên bộ phận', ENGLISH_OR=N'Component' , CHINESE_OR=N'Component' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'ComponentName' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'ComponentName',N'Tên bộ phận',N'Component',N'Component',N'Tên bộ phận',N'Component',N'Component','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'Email') UPDATE LANGUAGES SET VIETNAM=N'Email', ENGLISH=N'Email',CHINESE=N'Email', VIETNAM_OR=N'Email', ENGLISH_OR=N'Email' , CHINESE_OR=N'Email' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'Email' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'Email',N'Email',N'Email',N'Email',N'Email',N'Email',N'Email','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'grpDanhsachBP') UPDATE LANGUAGES SET VIETNAM=N'Danh sách bộ phận, phụ tùng có vấn đề', ENGLISH=N'Components, spare parts causing problems',CHINESE=N'Components, spare parts causing problems', VIETNAM_OR=N'Danh sách bộ phận, phụ tùng có vấn đề', ENGLISH_OR=N'Components, spare parts causing problems' , CHINESE_OR=N'Components, spare parts causing problems' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'grpDanhsachBP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'grpDanhsachBP',N'Danh sách bộ phận, phụ tùng có vấn đề',N'Components, spare parts causing problems',N'Components, spare parts causing problems',N'Danh sách bộ phận, phụ tùng có vấn đề',N'Components, spare parts causing problems',N'Components, spare parts causing problems','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'grpHinh') UPDATE LANGUAGES SET VIETNAM=N'Danh sách hình', ENGLISH=N'Image list',CHINESE=N'Image list', VIETNAM_OR=N'Danh sách hình', ENGLISH_OR=N'Image list' , CHINESE_OR=N'Image list' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'grpHinh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'grpHinh',N'Danh sách hình',N'Image list',N'Image list',N'Danh sách hình',N'Image list',N'Image list','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'HourOccurred') UPDATE LANGUAGES SET VIETNAM=N'Giờ sự cố', ENGLISH=N'Occurrence time',CHINESE=N'Occurrence time', VIETNAM_OR=N'Giờ sự cố', ENGLISH_OR=N'Occurrence time' , CHINESE_OR=N'Occurrence time' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'HourOccurred' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'HourOccurred',N'Giờ sự cố',N'Occurrence time',N'Occurrence time',N'Giờ sự cố',N'Occurrence time',N'Occurrence time','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'KhongCoDuLieu') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu.', ENGLISH=N'Data is null.',CHINESE=N'Data is null.', VIETNAM_OR=N'Không có dữ liệu.', ENGLISH_OR=N'Data is null.' , CHINESE_OR=N'Data is null.' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'KhongCoDuLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'KhongCoDuLieu',N'Không có dữ liệu.',N'Data is null.',N'Data is null.',N'Không có dữ liệu.',N'Data is null.',N'Data is null.','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'KhongCoDuLieu') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu.', ENGLISH=N'Data is null.',CHINESE=N'Data is null.', VIETNAM_OR=N'Không có dữ liệu.', ENGLISH_OR=N'Data is null.' , CHINESE_OR=N'Data is null.' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'KhongCoDuLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'KhongCoDuLieu',N'Không có dữ liệu.',N'Data is null.',N'Data is null.',N'Không có dữ liệu.',N'Data is null.',N'Data is null.','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'KhongCoDuLieu') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu.', ENGLISH=N'Data is null.',CHINESE=N'Data is null.', VIETNAM_OR=N'Không có dữ liệu.', ENGLISH_OR=N'Data is null.' , CHINESE_OR=N'Data is null.' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'KhongCoDuLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'KhongCoDuLieu',N'Không có dữ liệu.',N'Data is null.',N'Data is null.',N'Không có dữ liệu.',N'Data is null.',N'Data is null.','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lb_nguyennhan') UPDATE LANGUAGES SET VIETNAM=N'Nguyên nhân', ENGLISH=N'Cause',CHINESE=N'Cause', VIETNAM_OR=N'Nguyên nhân', ENGLISH_OR=N'Cause' , CHINESE_OR=N'Cause' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lb_nguyennhan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lb_nguyennhan',N'Nguyên nhân',N'Cause',N'Cause',N'Nguyên nhân',N'Cause',N'Cause','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblChiTietYeuCau') UPDATE LANGUAGES SET VIETNAM=N'Chi tiết yêu cầu', ENGLISH=N'Details of request',CHINESE=N'Details of request', VIETNAM_OR=N'Chi tiết yêu cầu', ENGLISH_OR=N'Details of request' , CHINESE_OR=N'Details of request' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblChiTietYeuCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblChiTietYeuCau',N'Chi tiết yêu cầu',N'Details of request',N'Details of request',N'Chi tiết yêu cầu',N'Details of request',N'Details of request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblDenngay') UPDATE LANGUAGES SET VIETNAM=N'Đến ngày', ENGLISH=N'To date',CHINESE=N'To date', VIETNAM_OR=N'Đến ngày', ENGLISH_OR=N'To date' , CHINESE_OR=N'To date' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblDenngay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblDenngay',N'Đến ngày',N'To date',N'To date',N'Đến ngày',N'To date',N'To date','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblDevice') UPDATE LANGUAGES SET VIETNAM=N'Thiết bị', ENGLISH=N'Equipment',CHINESE=N'Equipment', VIETNAM_OR=N'Thiết bị', ENGLISH_OR=N'Equipment' , CHINESE_OR=N'Equipment' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblDevice' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblDevice',N'Thiết bị',N'Equipment',N'Equipment',N'Thiết bị',N'Equipment',N'Equipment','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblDSYeuCau') UPDATE LANGUAGES SET VIETNAM=N'Yêu cầu của người sử dụng', ENGLISH=N'User request',CHINESE=N'User request', VIETNAM_OR=N'Yêu cầu của người sử dụng', ENGLISH_OR=N'User request' , CHINESE_OR=N'User request' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblDSYeuCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblDSYeuCau',N'Yêu cầu của người sử dụng',N'User request',N'User request',N'Yêu cầu của người sử dụng',N'User request',N'User request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblDSYeuCau') UPDATE LANGUAGES SET VIETNAM=N'Yêu cầu của người sử dụng', ENGLISH=N'User request',CHINESE=N'User request', VIETNAM_OR=N'Yêu cầu của người sử dụng', ENGLISH_OR=N'User request' , CHINESE_OR=N'User request' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblDSYeuCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblDSYeuCau',N'Yêu cầu của người sử dụng',N'User request',N'User request',N'Yêu cầu của người sử dụng',N'User request',N'User request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblGio') UPDATE LANGUAGES SET VIETNAM=N'Giờ yêu cầu', ENGLISH=N'Request time',CHINESE=N'Request time', VIETNAM_OR=N'Giờ yêu cầu', ENGLISH_OR=N'Request time' , CHINESE_OR=N'Request time' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblGio' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblGio',N'Giờ yêu cầu',N'Request time',N'Request time',N'Giờ yêu cầu',N'Request time',N'Request time','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblMoTa') UPDATE LANGUAGES SET VIETNAM=N'Mô tả tình trạng', ENGLISH=N'Failure description',CHINESE=N'Failure description', VIETNAM_OR=N'Mô tả tình trạng', ENGLISH_OR=N'Failure description' , CHINESE_OR=N'Failure description' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblMoTa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblMoTa',N'Mô tả tình trạng',N'Failure description',N'Failure description',N'Mô tả tình trạng',N'Failure description',N'Failure description','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblNgay') UPDATE LANGUAGES SET VIETNAM=N'Ngày yêu cầu', ENGLISH=N'Request date',CHINESE=N'Request date', VIETNAM_OR=N'Ngày yêu cầu', ENGLISH_OR=N'Request date' , CHINESE_OR=N'Request date' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblNgay',N'Ngày yêu cầu',N'Request date',N'Request date',N'Ngày yêu cầu',N'Request date',N'Request date','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblNgayhoanthanh') UPDATE LANGUAGES SET VIETNAM=N'Ngày YC HT', ENGLISH=N'Complete before',CHINESE=N'Complete before', VIETNAM_OR=N'Ngày YC HT', ENGLISH_OR=N'Complete before' , CHINESE_OR=N'Complete before' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblNgayhoanthanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblNgayhoanthanh',N'Ngày YC HT',N'Complete before',N'Complete before',N'Ngày YC HT',N'Complete before',N'Complete before','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblNguoiYC') UPDATE LANGUAGES SET VIETNAM=N'Người yêu cầu', ENGLISH=N'Requested by',CHINESE=N'Requested by', VIETNAM_OR=N'Người yêu cầu', ENGLISH_OR=N'Requested by' , CHINESE_OR=N'Requested by' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblNguoiYC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblNguoiYC',N'Người yêu cầu',N'Requested by',N'Requested by',N'Người yêu cầu',N'Requested by',N'Requested by','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblNguoiyeucau') UPDATE LANGUAGES SET VIETNAM=N'Người yêu cầu', ENGLISH=N'Requested by',CHINESE=N'Requested by', VIETNAM_OR=N'Người yêu cầu', ENGLISH_OR=N'Requested by' , CHINESE_OR=N'Requested by' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblNguoiyeucau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblNguoiyeucau',N'Người yêu cầu',N'Requested by',N'Requested by',N'Người yêu cầu',N'Requested by',N'Requested by','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblNoiDungYC') UPDATE LANGUAGES SET VIETNAM=N'Yêu cầu', ENGLISH=N'Request detail',CHINESE=N'Request detail', VIETNAM_OR=N'Yêu cầu', ENGLISH_OR=N'Request detail' , CHINESE_OR=N'Request detail' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblNoiDungYC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblNoiDungYC',N'Yêu cầu',N'Request detail',N'Request detail',N'Yêu cầu',N'Request detail',N'Request detail','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblNXuong') UPDATE LANGUAGES SET VIETNAM=N'Địa điểm', ENGLISH=N'Work site',CHINESE=N'Work site', VIETNAM_OR=N'Địa điểm', ENGLISH_OR=N'Work site' , CHINESE_OR=N'Work site' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblNXuong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblNXuong',N'Địa điểm',N'Work site',N'Work site',N'Địa điểm',N'Work site',N'Work site','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lbloaibt') UPDATE LANGUAGES SET VIETNAM=N'Loại yêu cầu bảo trì', ENGLISH=N'Request type',CHINESE=N'Request type', VIETNAM_OR=N'Loại yêu cầu bảo trì', ENGLISH_OR=N'Request type' , CHINESE_OR=N'Request type' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lbloaibt' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lbloaibt',N'Loại yêu cầu bảo trì',N'Request type',N'Request type',N'Loại yêu cầu bảo trì',N'Request type',N'Request type','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblthemhinh') UPDATE LANGUAGES SET VIETNAM=N'Chèn hình', ENGLISH=N'Add picture',CHINESE=N'Add picture', VIETNAM_OR=N'Chèn hình', ENGLISH_OR=N'Add picture' , CHINESE_OR=N'Add picture' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblthemhinh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblthemhinh',N'Chèn hình',N'Add picture',N'Add picture',N'Chèn hình',N'Add picture',N'Add picture','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblTungay') UPDATE LANGUAGES SET VIETNAM=N'Từ ngày', ENGLISH=N'From date',CHINESE=N'From date', VIETNAM_OR=N'Từ ngày', ENGLISH_OR=N'From date' , CHINESE_OR=N'From date' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblTungay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblTungay',N'Từ ngày',N'From date',N'From date',N'Từ ngày',N'From date',N'From date','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblYCau') UPDATE LANGUAGES SET VIETNAM=N'Yêu cầu', ENGLISH=N'Request',CHINESE=N'Request', VIETNAM_OR=N'Yêu cầu', ENGLISH_OR=N'Request' , CHINESE_OR=N'Request' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblYCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblYCau',N'Yêu cầu',N'Request',N'Request',N'Yêu cầu',N'Request',N'Request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lblYeuCauChiTiet') UPDATE LANGUAGES SET VIETNAM=N'Chi tiết yêu cầu', ENGLISH=N'Details of Request',CHINESE=N'Details of Request', VIETNAM_OR=N'Chi tiết yêu cầu', ENGLISH_OR=N'Details of Request' , CHINESE_OR=N'Details of Request' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lblYeuCauChiTiet' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lblYeuCauChiTiet',N'Chi tiết yêu cầu',N'Details of Request',N'Details of Request',N'Chi tiết yêu cầu',N'Details of Request',N'Details of Request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'lbuutien') UPDATE LANGUAGES SET VIETNAM=N'Mức ưu tiên', ENGLISH=N'Priority level',CHINESE=N'Priority level', VIETNAM_OR=N'Mức ưu tiên', ENGLISH_OR=N'Priority level' , CHINESE_OR=N'Priority level' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'lbuutien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'lbuutien',N'Mức ưu tiên',N'Priority level',N'Priority level',N'Mức ưu tiên',N'Priority level',N'Priority level','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'Path') UPDATE LANGUAGES SET VIETNAM=N'Đường dẫn file', ENGLISH=N'File path',CHINESE=N'File path', VIETNAM_OR=N'Đường dẫn file', ENGLISH_OR=N'File path' , CHINESE_OR=N'File path' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'Path' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'Path',N'Đường dẫn file',N'File path',N'File path',N'Đường dẫn file',N'File path',N'File path','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'UserRequestWeb' AND KEYWORD =N'SparePartName') UPDATE LANGUAGES SET VIETNAM=N'Mã VTPT', ENGLISH=N'Item ID',CHINESE=N'Item ID', VIETNAM_OR=N'Mã VTPT', ENGLISH_OR=N'Item ID' , CHINESE_OR=N'Item ID' WHERE FORM=N'UserRequestWeb' AND KEYWORD=N'SparePartName' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'UserRequestWeb',N'SparePartName',N'Mã VTPT',N'Item ID',N'Item ID',N'Mã VTPT',N'Item ID',N'Item ID','ECOMAIN')