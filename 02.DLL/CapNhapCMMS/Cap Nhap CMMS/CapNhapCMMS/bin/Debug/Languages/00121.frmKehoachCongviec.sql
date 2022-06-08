﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnGhi',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnIn') UPDATE LANGUAGES SET VIETNAM=N'In', ENGLISH=N'Print', VIETNAM_OR=N'In', ENGLISH_OR=N'Print' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnIn' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnIn',N'In',N'Print',N'In',N'Print')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnKhongghi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnKhongghi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnKhongghi',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnSua') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnSua',N'Sửa',N'Edit',N'Sửa',N'Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnThem',N'Thêm',N'Add',N'Thêm',N'Add')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnThemSua') UPDATE LANGUAGES SET VIETNAM=N'Thêm/Sửa', ENGLISH=N'Add/Edit', VIETNAM_OR=N'Thêm/Sửa', ENGLISH_OR=N'Add/Edit' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnThemSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnThemSua',N'Thêm/Sửa',N'Add/Edit',N'Thêm/Sửa',N'Add/Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'T&hoát', ENGLISH=N'E&xit', VIETNAM_OR=N'T&hoát', ENGLISH_OR=N'E&xit' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnThoat',N'T&hoát',N'E&xit',N'T&hoát',N'E&xit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnXemds') UPDATE LANGUAGES SET VIETNAM=N'Xem công việc đã xóa', ENGLISH=N'View deleted works', VIETNAM_OR=N'Xem công việc đã xóa', ENGLISH_OR=N'View deleted works' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnXemds' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnXemds',N'Xem công việc đã xóa',N'View deleted works',N'Xem công việc đã xóa',N'View deleted works')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnXoa') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnXoa',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'chkXong') UPDATE LANGUAGES SET VIETNAM=N'Hoàn thành', ENGLISH=N'Completed', VIETNAM_OR=N'Hoàn thành', ENGLISH_OR=N'Completed' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'chkXong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'chkXong',N'Hoàn thành',N'Completed',N'Hoàn thành',N'Completed')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'DA_XONG') UPDATE LANGUAGES SET VIETNAM=N'Đã xong', ENGLISH=N'Completed', VIETNAM_OR=N'Đã xong', ENGLISH_OR=N'Completed' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'DA_XONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'DA_XONG',N'Đã xong',N'Completed',N'Đã xong',N'Completed')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'frmKehoachCongviec') UPDATE LANGUAGES SET VIETNAM=N'Kế hoạch công việc', ENGLISH=N'Work Plan', VIETNAM_OR=N'Kế hoạch công việc', ENGLISH_OR=N'Work Plan' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'frmKehoachCongviec' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'frmKehoachCongviec',N'Kế hoạch công việc',N'Work Plan',N'Kế hoạch công việc',N'Work Plan')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'GHI_CHU') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'GHI_CHU',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'GhiChu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'GhiChu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'GhiChu',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'GrpChonXem') UPDATE LANGUAGES SET VIETNAM=N'Chọn xem', ENGLISH=N'Select to view', VIETNAM_OR=N'Chọn xem', ENGLISH_OR=N'Select to view' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'GrpChonXem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'GrpChonXem',N'Chọn xem',N'Select to view',N'Chọn xem',N'Select to view')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'Label1') UPDATE LANGUAGES SET VIETNAM=N'Đến ngày', ENGLISH=N'To date', VIETNAM_OR=N'Đến ngày', ENGLISH_OR=N'To date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'Label1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'Label1',N'Đến ngày',N'To date',N'Đến ngày',N'To date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblDenNgay') UPDATE LANGUAGES SET VIETNAM=N'Đến ngày', ENGLISH=N'To date', VIETNAM_OR=N'Đến ngày', ENGLISH_OR=N'To date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblDenNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblDenNgay',N'Đến ngày',N'To date',N'Đến ngày',N'To date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblDenNgay1') UPDATE LANGUAGES SET VIETNAM=N'Đến ngày', ENGLISH=N'To date', VIETNAM_OR=N'Đến ngày', ENGLISH_OR=N'To date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblDenNgay1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblDenNgay1',N'Đến ngày',N'To date',N'Đến ngày',N'To date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblGhichu') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblGhichu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblGhichu',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblManv') UPDATE LANGUAGES SET VIETNAM=N'MS nhân viên', ENGLISH=N'Employee ID', VIETNAM_OR=N'MS nhân viên', ENGLISH_OR=N'Employee ID' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblManv' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblManv',N'MS nhân viên',N'Employee ID',N'MS nhân viên',N'Employee ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblNgaybd') UPDATE LANGUAGES SET VIETNAM=N'Ngày bắt đầu làm', ENGLISH=N'Startinh date', VIETNAM_OR=N'Ngày bắt đầu làm', ENGLISH_OR=N'Startinh date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblNgaybd' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblNgaybd',N'Ngày bắt đầu làm',N'Startinh date',N'Ngày bắt đầu làm',N'Startinh date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblNgayhoanthanh') UPDATE LANGUAGES SET VIETNAM=N'Ngày dự định hoàn thành', ENGLISH=N'Completion date', VIETNAM_OR=N'Ngày dự định hoàn thành', ENGLISH_OR=N'Completion date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblNgayhoanthanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblNgayhoanthanh',N'Ngày dự định hoàn thành',N'Completion date',N'Ngày dự định hoàn thành',N'Completion date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblTencv') UPDATE LANGUAGES SET VIETNAM=N'Công việc phải làm', ENGLISH=N'Work Description', VIETNAM_OR=N'Công việc phải làm', ENGLISH_OR=N'Work Description' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblTencv' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblTencv',N'Công việc phải làm',N'Work Description',N'Công việc phải làm',N'Work Description')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblTennv') UPDATE LANGUAGES SET VIETNAM=N'Tên nhân viên', ENGLISH=N'Employee name', VIETNAM_OR=N'Tên nhân viên', ENGLISH_OR=N'Employee name' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblTennv' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblTennv',N'Tên nhân viên',N'Employee name',N'Tên nhân viên',N'Employee name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblThoigiandk') UPDATE LANGUAGES SET VIETNAM=N'Số giờ dự kiến', ENGLISH=N'Estimated hours', VIETNAM_OR=N'Số giờ dự kiến', ENGLISH_OR=N'Estimated hours' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblThoigiandk' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblThoigiandk',N'Số giờ dự kiến',N'Estimated hours',N'Số giờ dự kiến',N'Estimated hours')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblthongbao') UPDATE LANGUAGES SET VIETNAM=N'Nếu sau khi ghi mà bạn không tìm thấy dòng vừa ghi trên lưới, vui lòng kiểm tra điều kiện lọc.', ENGLISH=N'If you cannot find a record after saving, check filter condition.', VIETNAM_OR=N'Nếu sau khi ghi mà bạn không tìm thấy dòng vừa ghi trên lưới, vui lòng kiểm tra điều kiện lọc.', ENGLISH_OR=N'If you cannot find a record after saving, check filter condition.' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblthongbao' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblthongbao',N'Nếu sau khi ghi mà bạn không tìm thấy dòng vừa ghi trên lưới, vui lòng kiểm tra điều kiện lọc.',N'If you cannot find a record after saving, check filter condition.',N'Nếu sau khi ghi mà bạn không tìm thấy dòng vừa ghi trên lưới, vui lòng kiểm tra điều kiện lọc.',N'If you cannot find a record after saving, check filter condition.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblTieude') UPDATE LANGUAGES SET VIETNAM=N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC', ENGLISH=N'WORKING PLAN AND CONTROL', VIETNAM_OR=N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC', ENGLISH_OR=N'WORKING PLAN AND CONTROL' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblTieude' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblTieude',N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC',N'WORKING PLAN AND CONTROL',N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC',N'WORKING PLAN AND CONTROL')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblTuNgay') UPDATE LANGUAGES SET VIETNAM=N'Từ ngày', ENGLISH=N'From date', VIETNAM_OR=N'Từ ngày', ENGLISH_OR=N'From date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblTuNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblTuNgay',N'Từ ngày',N'From date',N'Từ ngày',N'From date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'lblUutien') UPDATE LANGUAGES SET VIETNAM=N'Mức ưu tiên', ENGLISH=N'Priority level', VIETNAM_OR=N'Mức ưu tiên', ENGLISH_OR=N'Priority level' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'lblUutien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'lblUutien',N'Mức ưu tiên',N'Priority level',N'Mức ưu tiên',N'Priority level')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgNgay_HTkhonghople') UPDATE LANGUAGES SET VIETNAM=N'Ngày hoàn thành không được nhỏ hơn ngày bắt đầu thực hiện.', ENGLISH=N'Completion date cannot be earlier than starting date!', VIETNAM_OR=N'Ngày hoàn thành không được nhỏ hơn ngày bắt đầu thực hiện.', ENGLISH_OR=N'Completion date cannot be earlier than starting date!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgNgay_HTkhonghople' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgNgay_HTkhonghople',N'Ngày hoàn thành không được nhỏ hơn ngày bắt đầu thực hiện.',N'Completion date cannot be earlier than starting date!',N'Ngày hoàn thành không được nhỏ hơn ngày bắt đầu thực hiện.',N'Completion date cannot be earlier than starting date!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgQuyenGhi1') UPDATE LANGUAGES SET VIETNAM=N'Mô tả công việc không được rỗng!', ENGLISH=N'Work description cannot be empty!', VIETNAM_OR=N'Mô tả công việc không được rỗng!', ENGLISH_OR=N'Work description cannot be empty!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgQuyenGhi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgQuyenGhi1',N'Mô tả công việc không được rỗng!',N'Work description cannot be empty!',N'Mô tả công việc không được rỗng!',N'Work description cannot be empty!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgQuyenGhi2') UPDATE LANGUAGES SET VIETNAM=N'Số giờ dự kiến không được rỗng!', ENGLISH=N'Estimated hour cannot be empty!', VIETNAM_OR=N'Số giờ dự kiến không được rỗng!', ENGLISH_OR=N'Estimated hour cannot be empty!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgQuyenGhi2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgQuyenGhi2',N'Số giờ dự kiến không được rỗng!',N'Estimated hour cannot be empty!',N'Số giờ dự kiến không được rỗng!',N'Estimated hour cannot be empty!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgQuyenGhi3') UPDATE LANGUAGES SET VIETNAM=N'Số giờ dự kiến phải là kiểu số!', ENGLISH=N'Estimated hours must be a number!', VIETNAM_OR=N'Số giờ dự kiến phải là kiểu số!', ENGLISH_OR=N'Estimated hours must be a number!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgQuyenGhi3' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgQuyenGhi3',N'Số giờ dự kiến phải là kiểu số!',N'Estimated hours must be a number!',N'Số giờ dự kiến phải là kiểu số!',N'Estimated hours must be a number!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgQuyenGhi4') UPDATE LANGUAGES SET VIETNAM=N'Ngày bắt đầu thực hiện không thể lớn hơn ngày dự kiến hoàn thành!', ENGLISH=N'Starting date cannot be later than planned completion date!', VIETNAM_OR=N'Ngày bắt đầu thực hiện không thể lớn hơn ngày dự kiến hoàn thành!', ENGLISH_OR=N'Starting date cannot be later than planned completion date!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgQuyenGhi4' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgQuyenGhi4',N'Ngày bắt đầu thực hiện không thể lớn hơn ngày dự kiến hoàn thành!',N'Starting date cannot be later than planned completion date!',N'Ngày bắt đầu thực hiện không thể lớn hơn ngày dự kiến hoàn thành!',N'Starting date cannot be later than planned completion date!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgQuyenGhi5') UPDATE LANGUAGES SET VIETNAM=N'Ngày dự kiến hoàn thành không thể nhỏ hơn ngày bắt đầu làm!', ENGLISH=N'Planned completion date cannot be earlier than starting date', VIETNAM_OR=N'Ngày dự kiến hoàn thành không thể nhỏ hơn ngày bắt đầu làm!', ENGLISH_OR=N'Planned completion date cannot be earlier than starting date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgQuyenGhi5' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgQuyenGhi5',N'Ngày dự kiến hoàn thành không thể nhỏ hơn ngày bắt đầu làm!',N'Planned completion date cannot be earlier than starting date',N'Ngày dự kiến hoàn thành không thể nhỏ hơn ngày bắt đầu làm!',N'Planned completion date cannot be earlier than starting date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgQuyenGhi6') UPDATE LANGUAGES SET VIETNAM=N'Mức ưu tiên không được rỗng! Vui lòng chọn mức ưu tiên!', ENGLISH=N'Priority cannot be empty!', VIETNAM_OR=N'Mức ưu tiên không được rỗng! Vui lòng chọn mức ưu tiên!', ENGLISH_OR=N'Priority cannot be empty!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgQuyenGhi6' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgQuyenGhi6',N'Mức ưu tiên không được rỗng! Vui lòng chọn mức ưu tiên!',N'Priority cannot be empty!',N'Mức ưu tiên không được rỗng! Vui lòng chọn mức ưu tiên!',N'Priority cannot be empty!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgQuyenXoa2') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa công việc này không?', ENGLISH=N'Do you want to delete this work?', VIETNAM_OR=N'Bạn có muốn xóa công việc này không?', ENGLISH_OR=N'Do you want to delete this work?' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgQuyenXoa2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgQuyenXoa2',N'Bạn có muốn xóa công việc này không?',N'Do you want to delete this work?',N'Bạn có muốn xóa công việc này không?',N'Do you want to delete this work?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgSoKhonghople') UPDATE LANGUAGES SET VIETNAM=N'Số giờ thực hiện phải là kiểu số! Vui lòng nhập lại!', ENGLISH=N'Actual hours must be a number. Please check!', VIETNAM_OR=N'Số giờ thực hiện phải là kiểu số! Vui lòng nhập lại!', ENGLISH_OR=N'Actual hours must be a number. Please check!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgSoKhonghople' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgSoKhonghople',N'Số giờ thực hiện phải là kiểu số! Vui lòng nhập lại!',N'Actual hours must be a number. Please check!',N'Số giờ thực hiện phải là kiểu số! Vui lòng nhập lại!',N'Actual hours must be a number. Please check!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MsgTenNull') UPDATE LANGUAGES SET VIETNAM=N'Công việc không được rỗng! Vui lòng nhập công việc!', ENGLISH=N'Work cannot be empty. Please enter!', VIETNAM_OR=N'Công việc không được rỗng! Vui lòng nhập công việc!', ENGLISH_OR=N'Work cannot be empty. Please enter!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MsgTenNull' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MsgTenNull',N'Công việc không được rỗng! Vui lòng nhập công việc!',N'Work cannot be empty. Please enter!',N'Công việc không được rỗng! Vui lòng nhập công việc!',N'Work cannot be empty. Please enter!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'NGAY') UPDATE LANGUAGES SET VIETNAM=N'Ngày bắt đầu', ENGLISH=N'Start date', VIETNAM_OR=N'Ngày bắt đầu', ENGLISH_OR=N'Start date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'NGAY' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'NGAY',N'Ngày bắt đầu',N'Start date',N'Ngày bắt đầu',N'Start date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'NgayDK') UPDATE LANGUAGES SET VIETNAM=N'Ngày bắt đầu', ENGLISH=N'Start date', VIETNAM_OR=N'Ngày bắt đầu', ENGLISH_OR=N'Start date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'NgayDK' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'NgayDK',N'Ngày bắt đầu',N'Start date',N'Ngày bắt đầu',N'Start date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'Ngayin') UPDATE LANGUAGES SET VIETNAM=N'Ngày in:', ENGLISH=N'Print date:', VIETNAM_OR=N'Ngày in:', ENGLISH_OR=N'Print date:' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'Ngayin' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'Ngayin',N'Ngày in:',N'Print date:',N'Ngày in:',N'Print date:')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'PREVIOUS_USER') UPDATE LANGUAGES SET VIETNAM=N'Người sửa trước', ENGLISH=N'Previous editor', VIETNAM_OR=N'Người sửa trước', ENGLISH_OR=N'Previous editor' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'PREVIOUS_USER' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'PREVIOUS_USER',N'Người sửa trước',N'Previous editor',N'Người sửa trước',N'Previous editor')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'PreviousUser') UPDATE LANGUAGES SET VIETNAM=N'Người sửa trước', ENGLISH=N'Previous editor', VIETNAM_OR=N'Người sửa trước', ENGLISH_OR=N'Previous editor' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'PreviousUser' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'PreviousUser',N'Người sửa trước',N'Previous editor',N'Người sửa trước',N'Previous editor')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'RadChuaHoanThanh') UPDATE LANGUAGES SET VIETNAM=N'Công việc chưa hoàn thành', ENGLISH=N'Incomplete', VIETNAM_OR=N'Công việc chưa hoàn thành', ENGLISH_OR=N'Incomplete' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'RadChuaHoanThanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'RadChuaHoanThanh',N'Công việc chưa hoàn thành',N'Incomplete',N'Công việc chưa hoàn thành',N'Incomplete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'RadDaHoanThanh') UPDATE LANGUAGES SET VIETNAM=N'Công việc đã hoàn thành', ENGLISH=N'Complete', VIETNAM_OR=N'Công việc đã hoàn thành', ENGLISH_OR=N'Complete' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'RadDaHoanThanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'RadDaHoanThanh',N'Công việc đã hoàn thành',N'Complete',N'Công việc đã hoàn thành',N'Complete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'STT') UPDATE LANGUAGES SET VIETNAM=N'STT', ENGLISH=N'No.', VIETNAM_OR=N'STT', ENGLISH_OR=N'No.' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'STT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'STT',N'STT',N'No.',N'STT',N'No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'TabDS') UPDATE LANGUAGES SET VIETNAM=N'Danh sách công việc', ENGLISH=N'List of works', VIETNAM_OR=N'Danh sách công việc', ENGLISH_OR=N'List of works' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'TabDS' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'TabDS',N'Danh sách công việc',N'List of works',N'Danh sách công việc',N'List of works')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'TabThem') UPDATE LANGUAGES SET VIETNAM=N'Thêm /sửa công việc', ENGLISH=N'&Add/Edit', VIETNAM_OR=N'Thêm /sửa công việc', ENGLISH_OR=N'&Add/Edit' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'TabThem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'TabThem',N'Thêm /sửa công việc',N'&Add/Edit',N'Thêm /sửa công việc',N'&Add/Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'TEN_CONG_VIEC') UPDATE LANGUAGES SET VIETNAM=N'Mô tả công việc', ENGLISH=N'Work Description', VIETNAM_OR=N'Mô tả công việc', ENGLISH_OR=N'Work Description' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'TEN_CONG_VIEC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'TEN_CONG_VIEC',N'Mô tả công việc',N'Work Description',N'Mô tả công việc',N'Work Description')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'TenCongViec') UPDATE LANGUAGES SET VIETNAM=N'Công việc', ENGLISH=N'Work', VIETNAM_OR=N'Công việc', ENGLISH_OR=N'Work' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'TenCongViec' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'TenCongViec',N'Công việc',N'Work',N'Công việc',N'Work')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'THOI_GIAN_DK') UPDATE LANGUAGES SET VIETNAM=N'Số phút', ENGLISH=N'No. of  hours', VIETNAM_OR=N'Số phút', ENGLISH_OR=N'No. of  hours' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'THOI_GIAN_DK' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'THOI_GIAN_DK',N'Số phút',N'No. of  hours',N'Số phút',N'No. of  hours')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'THOI_GIAN_SUA') UPDATE LANGUAGES SET VIETNAM=N'Thời gian sửa', ENGLISH=N'Editing time', VIETNAM_OR=N'Thời gian sửa', ENGLISH_OR=N'Editing time' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'THOI_GIAN_SUA' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'THOI_GIAN_SUA',N'Thời gian sửa',N'Editing time',N'Thời gian sửa',N'Editing time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'THOI_HAN') UPDATE LANGUAGES SET VIETNAM=N'Ngày kết thúc', ENGLISH=N'Completion date', VIETNAM_OR=N'Ngày kết thúc', ENGLISH_OR=N'Completion date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'THOI_HAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'THOI_HAN',N'Ngày kết thúc',N'Completion date',N'Ngày kết thúc',N'Completion date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'ThoiGianDK') UPDATE LANGUAGES SET VIETNAM=N'Số giờ', ENGLISH=N'Duration (h)', VIETNAM_OR=N'Số giờ', ENGLISH_OR=N'Duration (h)' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'ThoiGianDK' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'ThoiGianDK',N'Số giờ',N'Duration (h)',N'Số giờ',N'Duration (h)')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'ThoiGianSua') UPDATE LANGUAGES SET VIETNAM=N'Thời gian sửa', ENGLISH=N'Editing time', VIETNAM_OR=N'Thời gian sửa', ENGLISH_OR=N'Editing time' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'ThoiGianSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'ThoiGianSua',N'Thời gian sửa',N'Editing time',N'Thời gian sửa',N'Editing time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'ThoiHan') UPDATE LANGUAGES SET VIETNAM=N'Ngày kết thúc', ENGLISH=N'Completion date', VIETNAM_OR=N'Ngày kết thúc', ENGLISH_OR=N'Completion date' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'ThoiHan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'ThoiHan',N'Ngày kết thúc',N'Completion date',N'Ngày kết thúc',N'Completion date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'TieudeReport') UPDATE LANGUAGES SET VIETNAM=N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC', ENGLISH=N'WORK PLAN AND CONTROL', VIETNAM_OR=N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC', ENGLISH_OR=N'WORK PLAN AND CONTROL' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'TieudeReport' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'TieudeReport',N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC',N'WORK PLAN AND CONTROL',N'KẾ HOẠCH VÀ KIỂM SOÁT CÔNG VIỆC',N'WORK PLAN AND CONTROL')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'Trangin') UPDATE LANGUAGES SET VIETNAM=N'Trang', ENGLISH=N'Page', VIETNAM_OR=N'Trang', ENGLISH_OR=N'Page' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'Trangin' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'Trangin',N'Trang',N'Page',N'Trang',N'Page')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'USER_LAST') UPDATE LANGUAGES SET VIETNAM=N'Người sửa cuối', ENGLISH=N'Last editor', VIETNAM_OR=N'Người sửa cuối', ENGLISH_OR=N'Last editor' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'USER_LAST' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'USER_LAST',N'Người sửa cuối',N'Last editor',N'Người sửa cuối',N'Last editor')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'UserLast') UPDATE LANGUAGES SET VIETNAM=N'Người sửa cuối', ENGLISH=N'Last editor', VIETNAM_OR=N'Người sửa cuối', ENGLISH_OR=N'Last editor' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'UserLast' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'UserLast',N'Người sửa cuối',N'Last editor',N'Người sửa cuối',N'Last editor')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'UU_TIEN') UPDATE LANGUAGES SET VIETNAM=N'Mức ưu tiên', ENGLISH=N'Priority level', VIETNAM_OR=N'Mức ưu tiên', ENGLISH_OR=N'Priority level' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'UU_TIEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'UU_TIEN',N'Mức ưu tiên',N'Priority level',N'Mức ưu tiên',N'Priority level')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'UuTien') UPDATE LANGUAGES SET VIETNAM=N'Ưu tiên', ENGLISH=N'Priority level', VIETNAM_OR=N'Ưu tiên', ENGLISH_OR=N'Priority level' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'UuTien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'UuTien',N'Ưu tiên',N'Priority level',N'Ưu tiên',N'Priority level')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'btnTimNV') UPDATE LANGUAGES SET VIETNAM=N'...', ENGLISH=N'…', VIETNAM_OR=N'...', ENGLISH_OR=N'…' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'btnTimNV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'btnTimNV',N'...',N'…',N'...',N'…')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'msgChuaChonNhanVien') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn nhân viên trước khi chọn vật tư!', ENGLISH=N'Please select employees before materials!', VIETNAM_OR=N'Vui lòng chọn nhân viên trước khi chọn vật tư!', ENGLISH_OR=N'Please select employees before materials!' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'msgChuaChonNhanVien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'msgChuaChonNhanVien',N'Vui lòng chọn nhân viên trước khi chọn vật tư!',N'Please select employees before materials!',N'Vui lòng chọn nhân viên trước khi chọn vật tư!',N'Please select employees before materials!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'cboNgay_TH') UPDATE LANGUAGES SET VIETNAM=N'@cboNgay_TH@', ENGLISH=N'@cboNgay_TH@', VIETNAM_OR=N'@cboNgay_TH@', ENGLISH_OR=N'@cboNgay_TH@' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'cboNgay_TH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'cboNgay_TH',N'@cboNgay_TH@',N'@cboNgay_TH@',N'@cboNgay_TH@',N'@cboNgay_TH@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'cboTU_GIO') UPDATE LANGUAGES SET VIETNAM=N'Từ giờ', ENGLISH=N'From time', VIETNAM_OR=N'Từ giờ', ENGLISH_OR=N'From time' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'cboTU_GIO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'cboTU_GIO',N'Từ giờ',N'From time',N'Từ giờ',N'From time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'cboNgay_HT') UPDATE LANGUAGES SET VIETNAM=N'@cboNgay_HT@', ENGLISH=N'@cboNgay_HT@', VIETNAM_OR=N'@cboNgay_HT@', ENGLISH_OR=N'@cboNgay_HT@' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'cboNgay_HT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'cboNgay_HT',N'@cboNgay_HT@',N'@cboNgay_HT@',N'@cboNgay_HT@',N'@cboNgay_HT@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'cboDEN_GIO') UPDATE LANGUAGES SET VIETNAM=N'Đến giờ', ENGLISH=N'To time', VIETNAM_OR=N'Đến giờ', ENGLISH_OR=N'To time' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'cboDEN_GIO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'cboDEN_GIO',N'Đến giờ',N'To time',N'Đến giờ',N'To time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'TU_GIO') UPDATE LANGUAGES SET VIETNAM=N'Từ giờ', ENGLISH=N'From hour', VIETNAM_OR=N'Từ giờ', ENGLISH_OR=N'From hour' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'TU_GIO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'TU_GIO',N'Từ giờ',N'From hour',N'Từ giờ',N'From hour')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'cboMucUT') UPDATE LANGUAGES SET VIETNAM=N'@cboMucUT@', ENGLISH=N'@cboMucUT@', VIETNAM_OR=N'@cboMucUT@', ENGLISH_OR=N'@cboMucUT@' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'cboMucUT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'cboMucUT',N'@cboMucUT@',N'@cboMucUT@',N'@cboMucUT@',N'@cboMucUT@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'DEN_GIO') UPDATE LANGUAGES SET VIETNAM=N'Đến giờ', ENGLISH=N'To hour', VIETNAM_OR=N'Đến giờ', ENGLISH_OR=N'To hour' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'DEN_GIO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'DEN_GIO',N'Đến giờ',N'To hour',N'Đến giờ',N'To hour')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'SPHUT') UPDATE LANGUAGES SET VIETNAM=N'@SPHUT@', ENGLISH=N'@SPHUT@', VIETNAM_OR=N'@SPHUT@', ENGLISH_OR=N'@SPHUT@' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'SPHUT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'SPHUT',N'@SPHUT@',N'@SPHUT@',N'@SPHUT@',N'@SPHUT@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'MSCN_OLD') UPDATE LANGUAGES SET VIETNAM=N'@MSCN_OLD@', ENGLISH=N'@MSCN_OLD@', VIETNAM_OR=N'@MSCN_OLD@', ENGLISH_OR=N'@MSCN_OLD@' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'MSCN_OLD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'MSCN_OLD',N'@MSCN_OLD@',N'@MSCN_OLD@',N'@MSCN_OLD@',N'@MSCN_OLD@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'NGAY_OLD') UPDATE LANGUAGES SET VIETNAM=N'@NGAY_OLD@', ENGLISH=N'@NGAY_OLD@', VIETNAM_OR=N'@NGAY_OLD@', ENGLISH_OR=N'@NGAY_OLD@' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'NGAY_OLD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'NGAY_OLD',N'@NGAY_OLD@',N'@NGAY_OLD@',N'@NGAY_OLD@',N'@NGAY_OLD@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKehoachCongviec' AND KEYWORD =N'STT_OLD') UPDATE LANGUAGES SET VIETNAM=N'@STT_OLD@', ENGLISH=N'@STT_OLD@', VIETNAM_OR=N'@STT_OLD@', ENGLISH_OR=N'@STT_OLD@' WHERE FORM=N'frmKehoachCongviec' AND KEYWORD=N'STT_OLD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmKehoachCongviec',N'STT_OLD',N'@STT_OLD@',N'@STT_OLD@',N'@STT_OLD@',N'@STT_OLD@')