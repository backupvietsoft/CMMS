﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'BP_DEN_PHAI_KHAC_BP_DI') UPDATE LANGUAGES SET VIETNAM=N'Bộ phận chịu phí chuyển đến phải khác bộ phận chịu phí chuyển đi!', ENGLISH=N'To cost center cannot be the same as From cost center!', VIETNAM_OR=N'Bộ phận chịu phí chuyển đến phải khác bộ phận chịu phí chuyển đi!', ENGLISH_OR=N'To cost center cannot be the same as From cost center!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'BP_DEN_PHAI_KHAC_BP_DI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'BP_DEN_PHAI_KHAC_BP_DI',N'Bộ phận chịu phí chuyển đến phải khác bộ phận chịu phí chuyển đi!',N'To cost center cannot be the same as From cost center!',N'Bộ phận chịu phí chuyển đến phải khác bộ phận chịu phí chuyển đi!',N'To cost center cannot be the same as From cost center!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyen1') UPDATE LANGUAGES SET VIETNAM=N'Di chuyển', ENGLISH=N'Move', VIETNAM_OR=N'Di chuyển', ENGLISH_OR=N'Move' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyen1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyen1',N'Di chuyển',N'Move',N'Di chuyển',N'Move')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyen2') UPDATE LANGUAGES SET VIETNAM=N'Di chuyển', ENGLISH=N'Move', VIETNAM_OR=N'Di chuyển', ENGLISH_OR=N'Move' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyen2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyen2',N'Di chuyển',N'Move',N'Di chuyển',N'Move')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyendi') UPDATE LANGUAGES SET VIETNAM=N'>>', ENGLISH=N'>>', VIETNAM_OR=N'>>', ENGLISH_OR=N'>>' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyendi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyendi',N'>>',N'>>',N'>>',N'>>')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyenDi1') UPDATE LANGUAGES SET VIETNAM=N'>>', ENGLISH=N'>>', VIETNAM_OR=N'>>', ENGLISH_OR=N'>>' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyenDi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyenDi1',N'>>',N'>>',N'>>',N'>>')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyenDi2') UPDATE LANGUAGES SET VIETNAM=N'>>', ENGLISH=N'>>', VIETNAM_OR=N'>>', ENGLISH_OR=N'>>' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyenDi2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyenDi2',N'>>',N'>>',N'>>',N'>>')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyenLai') UPDATE LANGUAGES SET VIETNAM=N'<<', ENGLISH=N'<<', VIETNAM_OR=N'<<', ENGLISH_OR=N'<<' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyenLai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyenLai',N'<<',N'<<',N'<<',N'<<')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyenLai1') UPDATE LANGUAGES SET VIETNAM=N'<<', ENGLISH=N'<<', VIETNAM_OR=N'<<', ENGLISH_OR=N'<<' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyenLai1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyenLai1',N'<<',N'<<',N'<<',N'<<')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnChuyenLai2') UPDATE LANGUAGES SET VIETNAM=N'<<', ENGLISH=N'<<', VIETNAM_OR=N'<<', ENGLISH_OR=N'<<' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnChuyenLai2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnChuyenLai2',N'<<',N'<<',N'<<',N'<<')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnDiChuyen') UPDATE LANGUAGES SET VIETNAM=N'Di chuyển', ENGLISH=N'Move', VIETNAM_OR=N'Di chuyển', ENGLISH_OR=N'Move' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnDiChuyen' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnDiChuyen',N'Di chuyển',N'Move',N'Di chuyển',N'Move')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnGhi') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnGhi',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnGhi1') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnGhi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnGhi1',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnGhi2') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnGhi2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnGhi2',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnKhongGhi') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnKhongGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnKhongGhi',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnKhongGhi1') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnKhongGhi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnKhongGhi1',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnKhongGhi2') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnKhongGhi2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnKhongGhi2',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnThoat1') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnThoat1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnThoat1',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'btnThoat2') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'btnThoat2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'btnThoat2',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_CHON_BP_DEN') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn bộ phận chịu phí chuyển đến!', ENGLISH=N'Please select To cost center!', VIETNAM_OR=N'Vui lòng chọn bộ phận chịu phí chuyển đến!', ENGLISH_OR=N'Please select To cost center!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_CHON_BP_DEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_CHON_BP_DEN',N'Vui lòng chọn bộ phận chịu phí chuyển đến!',N'Please select To cost center!',N'Vui lòng chọn bộ phận chịu phí chuyển đến!',N'Please select To cost center!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_CHON_BP_DI') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn bộ phận chịu phí chuyển đi!', ENGLISH=N'Please select From cost center!', VIETNAM_OR=N'Vui lòng chọn bộ phận chịu phí chuyển đi!', ENGLISH_OR=N'Please select From cost center!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_CHON_BP_DI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_CHON_BP_DI',N'Vui lòng chọn bộ phận chịu phí chuyển đi!',N'Please select From cost center!',N'Vui lòng chọn bộ phận chịu phí chuyển đi!',N'Please select From cost center!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_CHON_HT_DEN') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn dây chuyền chuyển đến!', ENGLISH=N'Please select To line!', VIETNAM_OR=N'Vui lòng chọn dây chuyền chuyển đến!', ENGLISH_OR=N'Please select To line!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_CHON_HT_DEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_CHON_HT_DEN',N'Vui lòng chọn dây chuyền chuyển đến!',N'Please select To line!',N'Vui lòng chọn dây chuyền chuyển đến!',N'Please select To line!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_CHON_HT_DI') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn dây chuyền chuyển đi!', ENGLISH=N'Please select From line!', VIETNAM_OR=N'Vui lòng chọn dây chuyền chuyển đi!', ENGLISH_OR=N'Please select From line!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_CHON_HT_DI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_CHON_HT_DI',N'Vui lòng chọn dây chuyền chuyển đi!',N'Please select From line!',N'Vui lòng chọn dây chuyền chuyển đi!',N'Please select From line!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_CHON_NGAY_CHUYEN') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập ngày chuyển!', ENGLISH=N'Please input Date!', VIETNAM_OR=N'Vui lòng nhập ngày chuyển!', ENGLISH_OR=N'Please input Date!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_CHON_NGAY_CHUYEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_CHON_NGAY_CHUYEN',N'Vui lòng nhập ngày chuyển!',N'Please input Date!',N'Vui lòng nhập ngày chuyển!',N'Please input Date!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_CHON_TU_XUONG') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn địa điểm chuyển đi!', ENGLISH=N'Please select From work site!', VIETNAM_OR=N'Vui lòng chọn địa điểm chuyển đi!', ENGLISH_OR=N'Please select From work site!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_CHON_TU_XUONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_CHON_TU_XUONG',N'Vui lòng chọn địa điểm chuyển đi!',N'Please select From work site!',N'Vui lòng chọn địa điểm chuyển đi!',N'Please select From work site!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_CHON_XUONG_DEN') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng chọn địa điểm chuyển đến!', ENGLISH=N'Please select To work site!', VIETNAM_OR=N'Vui lòng chọn địa điểm chuyển đến!', ENGLISH_OR=N'Please select To work site!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_CHON_XUONG_DEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_CHON_XUONG_DEN',N'Vui lòng chọn địa điểm chuyển đến!',N'Please select To work site!',N'Vui lòng chọn địa điểm chuyển đến!',N'Please select To work site!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'CHUA_DUNG_DINH_DANG') UPDATE LANGUAGES SET VIETNAM=N'Nhập ngày chưa đúng định dạng', ENGLISH=N'Date is not in the right format!', VIETNAM_OR=N'Nhập ngày chưa đúng định dạng', ENGLISH_OR=N'Date is not in the right format!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'CHUA_DUNG_DINH_DANG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'CHUA_DUNG_DINH_DANG',N'Nhập ngày chưa đúng định dạng',N'Date is not in the right format!',N'Nhập ngày chưa đúng định dạng',N'Date is not in the right format!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'DENXUONG_PHAI_KHAC_TUXUONG') UPDATE LANGUAGES SET VIETNAM=N'Địa điểm chuyển đến phải khác địa điểm chuyển đi!', ENGLISH=N'To work site is not the same at From work site!', VIETNAM_OR=N'Địa điểm chuyển đến phải khác địa điểm chuyển đi!', ENGLISH_OR=N'To work site is not the same at From work site!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'DENXUONG_PHAI_KHAC_TUXUONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'DENXUONG_PHAI_KHAC_TUXUONG',N'Địa điểm chuyển đến phải khác địa điểm chuyển đi!',N'To work site is not the same at From work site!',N'Địa điểm chuyển đến phải khác địa điểm chuyển đi!',N'To work site is not the same at From work site!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'DI_CHUYEN_THANH_CONG') UPDATE LANGUAGES SET VIETNAM=N'Di chuyển thành công!', ENGLISH=N'Move successful!', VIETNAM_OR=N'Di chuyển thành công!', ENGLISH_OR=N'Move successful!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'DI_CHUYEN_THANH_CONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'DI_CHUYEN_THANH_CONG',N'Di chuyển thành công!',N'Move successful!',N'Di chuyển thành công!',N'Move successful!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'FrmDiChuyenThietBi') UPDATE LANGUAGES SET VIETNAM=N'Di chuyển thiết bị', ENGLISH=N'Equipment move', VIETNAM_OR=N'Di chuyển thiết bị', ENGLISH_OR=N'Equipment move' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'FrmDiChuyenThietBi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'FrmDiChuyenThietBi',N'Di chuyển thiết bị',N'Equipment move',N'Di chuyển thiết bị',N'Equipment move')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'HT_DEN_PHAI_KHAC_HT_DI') UPDATE LANGUAGES SET VIETNAM=N'Dây chuyền chuyển đến phải khác dây chuyền chuyển đi!', ENGLISH=N'To line is not the same at From line!', VIETNAM_OR=N'Dây chuyền chuyển đến phải khác dây chuyền chuyển đi!', ENGLISH_OR=N'To line is not the same at From line!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'HT_DEN_PHAI_KHAC_HT_DI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'HT_DEN_PHAI_KHAC_HT_DI',N'Dây chuyền chuyển đến phải khác dây chuyền chuyển đi!',N'To line is not the same at From line!',N'Dây chuyền chuyển đến phải khác dây chuyền chuyển đi!',N'To line is not the same at From line!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'KHONG_THANH_CONG') UPDATE LANGUAGES SET VIETNAM=N'Di chuyển không thành công. Vui lòng kiểm tra lại dữ liệu!', ENGLISH=N'Moving is unsuccessful. Please check data again!', VIETNAM_OR=N'Di chuyển không thành công. Vui lòng kiểm tra lại dữ liệu!', ENGLISH_OR=N'Moving is unsuccessful. Please check data again!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'KHONG_THANH_CONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'KHONG_THANH_CONG',N'Di chuyển không thành công. Vui lòng kiểm tra lại dữ liệu!',N'Moving is unsuccessful. Please check data again!',N'Di chuyển không thành công. Vui lòng kiểm tra lại dữ liệu!',N'Moving is unsuccessful. Please check data again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'KO_CON_TB') UPDATE LANGUAGES SET VIETNAM=N'Không còn thiết bị để chuyển!', ENGLISH=N'No equipment to move!', VIETNAM_OR=N'Không còn thiết bị để chuyển!', ENGLISH_OR=N'No equipment to move!' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'KO_CON_TB' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'KO_CON_TB',N'Không còn thiết bị để chuyển!',N'No equipment to move!',N'Không còn thiết bị để chuyển!',N'No equipment to move!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'label7') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thiết bị chuyển đi', ENGLISH=N'List of equipments', VIETNAM_OR=N'Danh sách thiết bị chuyển đi', ENGLISH_OR=N'List of equipments' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'label7' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'label7',N'Danh sách thiết bị chuyển đi',N'List of equipments',N'Danh sách thiết bị chuyển đi',N'List of equipments')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'label8') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thiết bị chuyển đến', ENGLISH=N'List of equipments', VIETNAM_OR=N'Danh sách thiết bị chuyển đến', ENGLISH_OR=N'List of equipments' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'label8' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'label8',N'Danh sách thiết bị chuyển đến',N'List of equipments',N'Danh sách thiết bị chuyển đến',N'List of equipments')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaBPden') UPDATE LANGUAGES SET VIETNAM=N'Đến BP chịu phí', ENGLISH=N'To cost center', VIETNAM_OR=N'Đến BP chịu phí', ENGLISH_OR=N'To cost center' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaBPden' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaBPden',N'Đến BP chịu phí',N'To cost center',N'Đến BP chịu phí',N'To cost center')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaDanhSachDen') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thiết bị chuyển đến', ENGLISH=N'List of equipments', VIETNAM_OR=N'Danh sách thiết bị chuyển đến', ENGLISH_OR=N'List of equipments' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaDanhSachDen' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaDanhSachDen',N'Danh sách thiết bị chuyển đến',N'List of equipments',N'Danh sách thiết bị chuyển đến',N'List of equipments')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaDanhSachDi') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thiết bị chuyển đi', ENGLISH=N'List of equipments', VIETNAM_OR=N'Danh sách thiết bị chuyển đi', ENGLISH_OR=N'List of equipments' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaDanhSachDi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaDanhSachDi',N'Danh sách thiết bị chuyển đi',N'List of equipments',N'Danh sách thiết bị chuyển đi',N'List of equipments')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaDenHT') UPDATE LANGUAGES SET VIETNAM=N'Đến dây chuyền', ENGLISH=N'To line', VIETNAM_OR=N'Đến dây chuyền', ENGLISH_OR=N'To line' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaDenHT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaDenHT',N'Đến dây chuyền',N'To line',N'Đến dây chuyền',N'To line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaDenXuong') UPDATE LANGUAGES SET VIETNAM=N'Đến địa điểm', ENGLISH=N'To work site', VIETNAM_OR=N'Đến địa điểm', ENGLISH_OR=N'To work site' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaDenXuong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaDenXuong',N'Đến địa điểm',N'To work site',N'Đến địa điểm',N'To work site')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaNgay') UPDATE LANGUAGES SET VIETNAM=N'Ngày', ENGLISH=N'Date', VIETNAM_OR=N'Ngày', ENGLISH_OR=N'Date' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaNgay',N'Ngày',N'Date',N'Ngày',N'Date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaThietbiden1') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thiết bị chuyển đến', ENGLISH=N'List of equipments', VIETNAM_OR=N'Danh sách thiết bị chuyển đến', ENGLISH_OR=N'List of equipments' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaThietbiden1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaThietbiden1',N'Danh sách thiết bị chuyển đến',N'List of equipments',N'Danh sách thiết bị chuyển đến',N'List of equipments')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaThietbidi1') UPDATE LANGUAGES SET VIETNAM=N'Danh sách thiết bị chuyển đi', ENGLISH=N'List of equipments', VIETNAM_OR=N'Danh sách thiết bị chuyển đi', ENGLISH_OR=N'List of equipments' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaThietbidi1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaThietbidi1',N'Danh sách thiết bị chuyển đi',N'List of equipments',N'Danh sách thiết bị chuyển đi',N'List of equipments')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaTieuDe') UPDATE LANGUAGES SET VIETNAM=N'DI CHUYỂN THIẾT BỊ', ENGLISH=N'EQUIPMENT MOVE', VIETNAM_OR=N'DI CHUYỂN THIẾT BỊ', ENGLISH_OR=N'EQUIPMENT MOVE' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaTieuDe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaTieuDe',N'DI CHUYỂN THIẾT BỊ',N'EQUIPMENT MOVE',N'DI CHUYỂN THIẾT BỊ',N'EQUIPMENT MOVE')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaTuBP') UPDATE LANGUAGES SET VIETNAM=N'Từ BP chịu phí', ENGLISH=N'From cost center', VIETNAM_OR=N'Từ BP chịu phí', ENGLISH_OR=N'From cost center' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaTuBP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaTuBP',N'Từ BP chịu phí',N'From cost center',N'Từ BP chịu phí',N'From cost center')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaTuHT') UPDATE LANGUAGES SET VIETNAM=N'Từ dây chuyền', ENGLISH=N'From line', VIETNAM_OR=N'Từ dây chuyền', ENGLISH_OR=N'From line' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaTuHT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaTuHT',N'Từ dây chuyền',N'From line',N'Từ dây chuyền',N'From line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'lbaTuxuong') UPDATE LANGUAGES SET VIETNAM=N'Từ địa điểm', ENGLISH=N'From work site', VIETNAM_OR=N'Từ địa điểm', ENGLISH_OR=N'From work site' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'lbaTuxuong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'lbaTuxuong',N'Từ địa điểm',N'From work site',N'Từ địa điểm',N'From work site')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'MS_MAY') UPDATE LANGUAGES SET VIETNAM=N'MS Thiết bị', ENGLISH=N'Equipment ID', VIETNAM_OR=N'MS Thiết bị', ENGLISH_OR=N'Equipment ID' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'MS_MAY' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'MS_MAY',N'MS Thiết bị',N'Equipment ID',N'MS Thiết bị',N'Equipment ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'MS_MAYBPDEN') UPDATE LANGUAGES SET VIETNAM=N'MS Thiết bị', ENGLISH=N'Equipment ID', VIETNAM_OR=N'MS Thiết bị', ENGLISH_OR=N'Equipment ID' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'MS_MAYBPDEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'MS_MAYBPDEN',N'MS Thiết bị',N'Equipment ID',N'MS Thiết bị',N'Equipment ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'MS_MAYBPDI') UPDATE LANGUAGES SET VIETNAM=N'MS Thiết bị', ENGLISH=N'Equipment ID', VIETNAM_OR=N'MS Thiết bị', ENGLISH_OR=N'Equipment ID' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'MS_MAYBPDI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'MS_MAYBPDI',N'MS Thiết bị',N'Equipment ID',N'MS Thiết bị',N'Equipment ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'MS_MAYDX') UPDATE LANGUAGES SET VIETNAM=N'MS Thiết bị', ENGLISH=N'Equipment ID', VIETNAM_OR=N'MS Thiết bị', ENGLISH_OR=N'Equipment ID' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'MS_MAYDX' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'MS_MAYDX',N'MS Thiết bị',N'Equipment ID',N'MS Thiết bị',N'Equipment ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'MS_MAYHTD') UPDATE LANGUAGES SET VIETNAM=N'MS Thiết bị', ENGLISH=N'Equipment ID', VIETNAM_OR=N'MS Thiết bị', ENGLISH_OR=N'Equipment ID' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'MS_MAYHTD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'MS_MAYHTD',N'MS Thiết bị',N'Equipment ID',N'MS Thiết bị',N'Equipment ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'MS_MAYHTDEN') UPDATE LANGUAGES SET VIETNAM=N'MS Thiết bị', ENGLISH=N'Equipment ID', VIETNAM_OR=N'MS Thiết bị', ENGLISH_OR=N'Equipment ID' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'MS_MAYHTDEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'MS_MAYHTDEN',N'MS Thiết bị',N'Equipment ID',N'MS Thiết bị',N'Equipment ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'NC_TRUOC_LH_NGAY_CHUYEN') UPDATE LANGUAGES SET VIETNAM=N'Ngày chuyển phải lớn hơn ngày nhập.', ENGLISH=N'Installation date must be earlier than Move date ! ', VIETNAM_OR=N'Ngày chuyển phải lớn hơn ngày nhập.', ENGLISH_OR=N'Installation date must be earlier than Move date ! ' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'NC_TRUOC_LH_NGAY_CHUYEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'NC_TRUOC_LH_NGAY_CHUYEN',N'Ngày chuyển phải lớn hơn ngày nhập.',N'Installation date must be earlier than Move date ! ',N'Ngày chuyển phải lớn hơn ngày nhập.',N'Installation date must be earlier than Move date ! ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'NGAY_NHAP') UPDATE LANGUAGES SET VIETNAM=N'Ngày nhập', ENGLISH=N'Installation date', VIETNAM_OR=N'Ngày nhập', ENGLISH_OR=N'Installation date' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'NGAY_NHAP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'NGAY_NHAP',N'Ngày nhập',N'Installation date',N'Ngày nhập',N'Installation date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'NGAY_NHAPBPDEN') UPDATE LANGUAGES SET VIETNAM=N'Ngày nhập BPDEN', ENGLISH=N'BPDEN date', VIETNAM_OR=N'Ngày nhập BPDEN', ENGLISH_OR=N'BPDEN date' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'NGAY_NHAPBPDEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'NGAY_NHAPBPDEN',N'Ngày nhập BPDEN',N'BPDEN date',N'Ngày nhập BPDEN',N'BPDEN date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'NGAY_NHAPBPDI') UPDATE LANGUAGES SET VIETNAM=N'Ngày nhập', ENGLISH=N'Installation date', VIETNAM_OR=N'Ngày nhập', ENGLISH_OR=N'Installation date' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'NGAY_NHAPBPDI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'NGAY_NHAPBPDI',N'Ngày nhập',N'Installation date',N'Ngày nhập',N'Installation date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'NGAY_NHAPDX') UPDATE LANGUAGES SET VIETNAM=N'Ngày nhập DX', ENGLISH=N'DX date', VIETNAM_OR=N'Ngày nhập DX', ENGLISH_OR=N'DX date' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'NGAY_NHAPDX' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'NGAY_NHAPDX',N'Ngày nhập DX',N'DX date',N'Ngày nhập DX',N'DX date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'NGAY_NHAPHTD') UPDATE LANGUAGES SET VIETNAM=N'Ngày nhập', ENGLISH=N'Installation date', VIETNAM_OR=N'Ngày nhập', ENGLISH_OR=N'Installation date' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'NGAY_NHAPHTD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'NGAY_NHAPHTD',N'Ngày nhập',N'Installation date',N'Ngày nhập',N'Installation date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'NGAY_NHAPHTDEN') UPDATE LANGUAGES SET VIETNAM=N'Ngày nhập HTDEN', ENGLISH=N'HTDEN date', VIETNAM_OR=N'Ngày nhập HTDEN', ENGLISH_OR=N'HTDEN date' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'NGAY_NHAPHTDEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'NGAY_NHAPHTDEN',N'Ngày nhập HTDEN',N'HTDEN date',N'Ngày nhập HTDEN',N'HTDEN date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'tabBoPhanChiuPhi') UPDATE LANGUAGES SET VIETNAM=N'Thay đổi bộ phận chịu phí', ENGLISH=N'Change cost center', VIETNAM_OR=N'Thay đổi bộ phận chịu phí', ENGLISH_OR=N'Change cost center' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'tabBoPhanChiuPhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'tabBoPhanChiuPhi',N'Thay đổi bộ phận chịu phí',N'Change cost center',N'Thay đổi bộ phận chịu phí',N'Change cost center')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'tabDiChuyenThietBi') UPDATE LANGUAGES SET VIETNAM=N'Thay đổi địa điểm', ENGLISH=N'Change work site', VIETNAM_OR=N'Thay đổi địa điểm', ENGLISH_OR=N'Change work site' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'tabDiChuyenThietBi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'tabDiChuyenThietBi',N'Thay đổi địa điểm',N'Change work site',N'Thay đổi địa điểm',N'Change work site')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'tabHeThong') UPDATE LANGUAGES SET VIETNAM=N'Thay đổi dây chuyền', ENGLISH=N'Change line', VIETNAM_OR=N'Thay đổi dây chuyền', ENGLISH_OR=N'Change line' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'tabHeThong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'tabHeThong',N'Thay đổi dây chuyền',N'Change line',N'Thay đổi dây chuyền',N'Change line')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'TEN_MAY') UPDATE LANGUAGES SET VIETNAM=N'Tên thiết bị', ENGLISH=N'Equipment', VIETNAM_OR=N'Tên thiết bị', ENGLISH_OR=N'Equipment' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'TEN_MAY' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'TEN_MAY',N'Tên thiết bị',N'Equipment',N'Tên thiết bị',N'Equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'TEN_MAYBPDEN') UPDATE LANGUAGES SET VIETNAM=N'Tên thiết bị', ENGLISH=N'Equipment', VIETNAM_OR=N'Tên thiết bị', ENGLISH_OR=N'Equipment' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'TEN_MAYBPDEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'TEN_MAYBPDEN',N'Tên thiết bị',N'Equipment',N'Tên thiết bị',N'Equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'TEN_MAYBPDI') UPDATE LANGUAGES SET VIETNAM=N'Tên thiết bị', ENGLISH=N'Equipment', VIETNAM_OR=N'Tên thiết bị', ENGLISH_OR=N'Equipment' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'TEN_MAYBPDI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'TEN_MAYBPDI',N'Tên thiết bị',N'Equipment',N'Tên thiết bị',N'Equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'TEN_MAYDX') UPDATE LANGUAGES SET VIETNAM=N'Tên thiết bị', ENGLISH=N'Equipment', VIETNAM_OR=N'Tên thiết bị', ENGLISH_OR=N'Equipment' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'TEN_MAYDX' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'TEN_MAYDX',N'Tên thiết bị',N'Equipment',N'Tên thiết bị',N'Equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'TEN_MAYHTD') UPDATE LANGUAGES SET VIETNAM=N'Tên thiết bị', ENGLISH=N'Equipment', VIETNAM_OR=N'Tên thiết bị', ENGLISH_OR=N'Equipment' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'TEN_MAYHTD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'TEN_MAYHTD',N'Tên thiết bị',N'Equipment',N'Tên thiết bị',N'Equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD =N'TEN_MAYHTDEN') UPDATE LANGUAGES SET VIETNAM=N'Tên thiết bị', ENGLISH=N'Equipment', VIETNAM_OR=N'Tên thiết bị', ENGLISH_OR=N'Equipment' WHERE FORM=N'FrmDiChuyenThietBi' AND KEYWORD=N'TEN_MAYHTDEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmDiChuyenThietBi',N'TEN_MAYHTDEN',N'Tên thiết bị',N'Equipment',N'Tên thiết bị',N'Equipment')
