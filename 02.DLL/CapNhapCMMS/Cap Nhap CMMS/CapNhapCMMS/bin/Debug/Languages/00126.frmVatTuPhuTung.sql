﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'MS_DH_XUAT_PT') UPDATE LANGUAGES SET VIETNAM=N'MS phiếu xuất', ENGLISH=N'Goods Issue No.', VIETNAM_OR=N'MS phiếu xuất', ENGLISH_OR=N'Goods Issue No.' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'MS_DH_XUAT_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'MS_DH_XUAT_PT',N'MS phiếu xuất',N'Goods Issue No.',N'MS phiếu xuất',N'Goods Issue No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'SO_PHIEU_XN') UPDATE LANGUAGES SET VIETNAM=N'Số phiếu nhập', ENGLISH=N'Goods receipt No.', VIETNAM_OR=N'Số phiếu nhập', ENGLISH_OR=N'Goods receipt No.' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'SO_PHIEU_XN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'SO_PHIEU_XN',N'Số phiếu nhập',N'Goods receipt No.',N'Số phiếu nhập',N'Goods receipt No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'NGAY') UPDATE LANGUAGES SET VIETNAM=N'Ngày', ENGLISH=N'Date', VIETNAM_OR=N'Ngày', ENGLISH_OR=N'Date' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'NGAY' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'NGAY',N'Ngày',N'Date',N'Ngày',N'Date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'GIO') UPDATE LANGUAGES SET VIETNAM=N'Giờ', ENGLISH=N'Hour', VIETNAM_OR=N'Giờ', ENGLISH_OR=N'Hour' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'GIO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'GIO',N'Giờ',N'Hour',N'Giờ',N'Hour')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'TEN_KHO') UPDATE LANGUAGES SET VIETNAM=N'Tên kho', ENGLISH=N'Name of warehouse', VIETNAM_OR=N'Tên kho', ENGLISH_OR=N'Name of warehouse' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'TEN_KHO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'TEN_KHO',N'Tên kho',N'Name of warehouse',N'Tên kho',N'Name of warehouse')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'DANG_XUAT_VIET') UPDATE LANGUAGES SET VIETNAM=N'Dạng xuất', ENGLISH=N'Issue type', VIETNAM_OR=N'Dạng xuất', ENGLISH_OR=N'Issue type' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'DANG_XUAT_VIET' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'DANG_XUAT_VIET',N'Dạng xuất',N'Issue type',N'Dạng xuất',N'Issue type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'lblTieuDe') UPDATE LANGUAGES SET VIETNAM=N'TÌM VẬT TƯ NHẬP KHO', ENGLISH=N'Item search in goods receipt', VIETNAM_OR=N'TÌM VẬT TƯ NHẬP KHO', ENGLISH_OR=N'Item search in goods receipt' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'lblTieuDe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'lblTieuDe',N'TÌM VẬT TƯ NHẬP KHO',N'Item search in goods receipt',N'TÌM VẬT TƯ NHẬP KHO',N'Item search in goods receipt')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'lblLVT') UPDATE LANGUAGES SET VIETNAM=N'Loại vật tư', ENGLISH=N'Item type', VIETNAM_OR=N'Loại vật tư', ENGLISH_OR=N'Item type' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'lblLVT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'lblLVT',N'Loại vật tư',N'Item type',N'Loại vật tư',N'Item type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'MS_DE_XUAT') UPDATE LANGUAGES SET VIETNAM=N'MS Đề xuất', ENGLISH=N'Request ID', VIETNAM_OR=N'MS Đề xuất', ENGLISH_OR=N'Request ID' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'MS_DE_XUAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'MS_DE_XUAT',N'MS Đề xuất',N'Request ID',N'MS Đề xuất',N'Request ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'SO_DE_XUAT') UPDATE LANGUAGES SET VIETNAM=N'Số đề xuất', ENGLISH=N'Request No.', VIETNAM_OR=N'Số đề xuất', ENGLISH_OR=N'Request No.' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'SO_DE_XUAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'SO_DE_XUAT',N'Số đề xuất',N'Request No.',N'Số đề xuất',N'Request No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'NGAY_LAP') UPDATE LANGUAGES SET VIETNAM=N'Ngày lập', ENGLISH=N'Created date', VIETNAM_OR=N'Ngày lập', ENGLISH_OR=N'Created date' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'NGAY_LAP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'NGAY_LAP',N'Ngày lập',N'Created date',N'Ngày lập',N'Created date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'NGUOI_LAP') UPDATE LANGUAGES SET VIETNAM=N'Người lập', ENGLISH=N'Created by', VIETNAM_OR=N'Người lập', ENGLISH_OR=N'Created by' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'NGUOI_LAP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'NGUOI_LAP',N'Người lập',N'Created by',N'Người lập',N'Created by')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'NGUOI_DE_XUAT') UPDATE LANGUAGES SET VIETNAM=N'Người đề xuất', ENGLISH=N'Requested by', VIETNAM_OR=N'Người đề xuất', ENGLISH_OR=N'Requested by' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'NGUOI_DE_XUAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'NGUOI_DE_XUAT',N'Người đề xuất',N'Requested by',N'Người đề xuất',N'Requested by')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'NGAY_DE_XUAT') UPDATE LANGUAGES SET VIETNAM=N'Ngày đề xuất', ENGLISH=N'Request date', VIETNAM_OR=N'Ngày đề xuất', ENGLISH_OR=N'Request date' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'NGAY_DE_XUAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'NGAY_DE_XUAT',N'Ngày đề xuất',N'Request date',N'Ngày đề xuất',N'Request date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'MS_DON_DAT_HANG') UPDATE LANGUAGES SET VIETNAM=N'MS Đơn hàng', ENGLISH=N'PO ID', VIETNAM_OR=N'MS Đơn hàng', ENGLISH_OR=N'PO ID' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'MS_DON_DAT_HANG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'MS_DON_DAT_HANG',N'MS Đơn hàng',N'PO ID',N'MS Đơn hàng',N'PO ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'SO_DON_DAT_HANG') UPDATE LANGUAGES SET VIETNAM=N'Số Đơn hàng', ENGLISH=N'PO No.', VIETNAM_OR=N'Số Đơn hàng', ENGLISH_OR=N'PO No.' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'SO_DON_DAT_HANG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'SO_DON_DAT_HANG',N'Số Đơn hàng',N'PO No.',N'Số Đơn hàng',N'PO No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'NGUOI_DAT') UPDATE LANGUAGES SET VIETNAM=N'Người đặt hàng', ENGLISH=N'Ordered by', VIETNAM_OR=N'Người đặt hàng', ENGLISH_OR=N'Ordered by' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'NGUOI_DAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'NGUOI_DAT',N'Người đặt hàng',N'Ordered by',N'Người đặt hàng',N'Ordered by')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'NGAY_DAT') UPDATE LANGUAGES SET VIETNAM=N'Ngày đặt hàng', ENGLISH=N'Order date', VIETNAM_OR=N'Ngày đặt hàng', ENGLISH_OR=N'Order date' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'NGAY_DAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'NGAY_DAT',N'Ngày đặt hàng',N'Order date',N'Ngày đặt hàng',N'Order date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'MS_DH_NHAP_PT') UPDATE LANGUAGES SET VIETNAM=N'MS Phiếu nhập', ENGLISH=N'Receipt No.', VIETNAM_OR=N'MS Phiếu nhập', ENGLISH_OR=N'Receipt No.' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'MS_DH_NHAP_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'MS_DH_NHAP_PT',N'MS Phiếu nhập',N'Receipt No.',N'MS Phiếu nhập',N'Receipt No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'DANG_NHAP_VIET') UPDATE LANGUAGES SET VIETNAM=N'Dạng nhập', ENGLISH=N'Type of receipt', VIETNAM_OR=N'Dạng nhập', ENGLISH_OR=N'Type of receipt' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'DANG_NHAP_VIET' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'DANG_NHAP_VIET',N'Dạng nhập',N'Type of receipt',N'Dạng nhập',N'Type of receipt')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'lblDNgay') UPDATE LANGUAGES SET VIETNAM=N'Đến ngày', ENGLISH=N'To date', VIETNAM_OR=N'Đến ngày', ENGLISH_OR=N'To date' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'lblDNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'lblDNgay',N'Đến ngày',N'To date',N'Đến ngày',N'To date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'lblTNgay') UPDATE LANGUAGES SET VIETNAM=N'Từ ngày', ENGLISH=N'From date', VIETNAM_OR=N'Từ ngày', ENGLISH_OR=N'From date' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'lblTNgay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'lblTNgay',N'Từ ngày',N'From date',N'Từ ngày',N'From date')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'chkPNhap') UPDATE LANGUAGES SET VIETNAM=N'Chọn nhập', ENGLISH=N'Check ', VIETNAM_OR=N'Chọn nhập', ENGLISH_OR=N'Check ' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'chkPNhap' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'chkPNhap',N'Chọn nhập',N'Check ',N'Chọn nhập',N'Check ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'frmVatTuPhuTung') UPDATE LANGUAGES SET VIETNAM=N'Tìm vật tư nhập kho', ENGLISH=N'Item search in goods receipt', VIETNAM_OR=N'Tìm vật tư nhập kho', ENGLISH_OR=N'Item search in goods receipt' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'frmVatTuPhuTung' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'frmVatTuPhuTung',N'Tìm vật tư nhập kho',N'Item search in goods receipt',N'Tìm vật tư nhập kho',N'Item search in goods receipt')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD =N'label1') UPDATE LANGUAGES SET VIETNAM=N'Mã VTPT', ENGLISH=N'ID', VIETNAM_OR=N'Mã VTPT', ENGLISH_OR=N'ID' WHERE FORM=N'frmVatTuPhuTung' AND KEYWORD=N'label1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmVatTuPhuTung',N'label1',N'Mã VTPT',N'ID',N'Mã VTPT',N'ID')