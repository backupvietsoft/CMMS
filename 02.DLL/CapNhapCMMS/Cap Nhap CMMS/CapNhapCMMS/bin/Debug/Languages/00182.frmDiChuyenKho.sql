﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'MS_DH_NHAP_PT') UPDATE LANGUAGES SET VIETNAM=N'Đơn hàng nhập', ENGLISH=N'Receipt ID', VIETNAM_OR=N'Đơn hàng nhập', ENGLISH_OR=N'Receipt ID' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'MS_DH_NHAP_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'MS_DH_NHAP_PT',N'Đơn hàng nhập',N'Receipt ID',N'Đơn hàng nhập',N'Receipt ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'MS_PT') UPDATE LANGUAGES SET VIETNAM=N'MS VT PT', ENGLISH=N'Item ID', VIETNAM_OR=N'MS VT PT', ENGLISH_OR=N'Item ID' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'MS_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'MS_PT',N'MS VT PT',N'Item ID',N'MS VT PT',N'Item ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'msgKhongCoDuLieu') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu in!', ENGLISH=N'No data to print!', VIETNAM_OR=N'Không có dữ liệu in!', ENGLISH_OR=N'No data to print!' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'msgKhongCoDuLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'msgKhongCoDuLieu',N'Không có dữ liệu in!',N'No data to print!',N'Không có dữ liệu in!',N'No data to print!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'SL_CHUYEN') UPDATE LANGUAGES SET VIETNAM=N'Số lượng chuyển', ENGLISH=N'@SL_CHUYEN@', VIETNAM_OR=N'Số lượng chuyển', ENGLISH_OR=N'@SL_CHUYEN@' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'SL_CHUYEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'SL_CHUYEN',N'Số lượng chuyển',N'@SL_CHUYEN@',N'Số lượng chuyển',N'@SL_CHUYEN@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'STT') UPDATE LANGUAGES SET VIETNAM=N'STT', ENGLISH=N'NO', VIETNAM_OR=N'STT', ENGLISH_OR=N'NO' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'STT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'STT',N'STT',N'NO',N'STT',N'NO')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'TEN_KHO') UPDATE LANGUAGES SET VIETNAM=N'Kho', ENGLISH=N'Warehouse', VIETNAM_OR=N'Kho', ENGLISH_OR=N'Warehouse' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'TEN_KHO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'TEN_KHO',N'Kho',N'Warehouse',N'Kho',N'Warehouse')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'TEN_KHO_1') UPDATE LANGUAGES SET VIETNAM=N'Kho', ENGLISH=N'Warehouse', VIETNAM_OR=N'Kho', ENGLISH_OR=N'Warehouse' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'TEN_KHO_1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'TEN_KHO_1',N'Kho',N'Warehouse',N'Kho',N'Warehouse')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'TEN_PT') UPDATE LANGUAGES SET VIETNAM=N'Tên', ENGLISH=N'Name', VIETNAM_OR=N'Tên', ENGLISH_OR=N'Name' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'TEN_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'TEN_PT',N'Tên',N'Name',N'Tên',N'Name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'TEN_VI_TRI') UPDATE LANGUAGES SET VIETNAM=N'Vị trí', ENGLISH=N'Position', VIETNAM_OR=N'Vị trí', ENGLISH_OR=N'Position' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'TEN_VI_TRI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'TEN_VI_TRI',N'Vị trí',N'Position',N'Vị trí',N'Position')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'TEN_VI_TRI_1') UPDATE LANGUAGES SET VIETNAM=N'Vị trí', ENGLISH=N'Position', VIETNAM_OR=N'Vị trí', ENGLISH_OR=N'Position' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'TEN_VI_TRI_1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'TEN_VI_TRI_1',N'Vị trí',N'Position',N'Vị trí',N'Position')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'TieuDeDSDiChuyenKho') UPDATE LANGUAGES SET VIETNAM=N'DANH SÁCH CHUYỂN VẬT TƯ', ENGLISH=N'INVENTORY REPORT', VIETNAM_OR=N'DANH SÁCH CHUYỂN VẬT TƯ', ENGLISH_OR=N'INVENTORY REPORT' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'TieuDeDSDiChuyenKho' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'TieuDeDSDiChuyenKho',N'DANH SÁCH CHUYỂN VẬT TƯ',N'INVENTORY REPORT',N'DANH SÁCH CHUYỂN VẬT TƯ',N'INVENTORY REPORT')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N' frmInDSDiChuyenKho') UPDATE LANGUAGES SET VIETNAM=N'In danh sách di chuyển VT', ENGLISH=N'…', VIETNAM_OR=N'In danh sách di chuyển VT', ENGLISH_OR=N'…' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N' frmInDSDiChuyenKho' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N' frmInDSDiChuyenKho',N'In danh sách di chuyển VT',N'…',N'In danh sách di chuyển VT',N'…')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'msgTuNgayLonHonDenNgay') UPDATE LANGUAGES SET VIETNAM=N'Từ ngày phải nhỏ hơn đến ngày!', ENGLISH=N'From Date should be earlier than to date!', VIETNAM_OR=N'Từ ngày phải nhỏ hơn đến ngày!', ENGLISH_OR=N'From Date should be earlier than to date!' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'msgTuNgayLonHonDenNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'msgTuNgayLonHonDenNgay',N'Từ ngày phải nhỏ hơn đến ngày!',N'From Date should be earlier than to date!',N'Từ ngày phải nhỏ hơn đến ngày!',N'From Date should be earlier than to date!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'lblTNgay') UPDATE LANGUAGES SET VIETNAM=N'Từ ngày', ENGLISH=N'From date', VIETNAM_OR=N'Từ ngày', ENGLISH_OR=N'From date' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'lblTNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'lblTNgay',N'Từ ngày',N'From date',N'Từ ngày',N'From date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'lblDNgay') UPDATE LANGUAGES SET VIETNAM=N'Đến ngày', ENGLISH=N'From to', VIETNAM_OR=N'Đến ngày', ENGLISH_OR=N'From to' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'lblDNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'lblDNgay',N'Đến ngày',N'From to',N'Đến ngày',N'From to')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'lblKhoDi') UPDATE LANGUAGES SET VIETNAM=N'Kho chuyển', ENGLISH=N'WH transfer', VIETNAM_OR=N'Kho chuyển', ENGLISH_OR=N'WH transfer' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'lblKhoDi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'lblKhoDi',N'Kho chuyển',N'WH transfer',N'Kho chuyển',N'WH transfer')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD =N'lblKhoDen') UPDATE LANGUAGES SET VIETNAM=N'Kho nhận', ENGLISH=N'WH receipt', VIETNAM_OR=N'Kho nhận', ENGLISH_OR=N'WH receipt' WHERE FORM=N'frmInDSDiChuyenKho' AND KEYWORD=N'lblKhoDen' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmInDSDiChuyenKho',N'lblKhoDen',N'Kho nhận',N'WH receipt',N'Kho nhận',N'WH receipt')