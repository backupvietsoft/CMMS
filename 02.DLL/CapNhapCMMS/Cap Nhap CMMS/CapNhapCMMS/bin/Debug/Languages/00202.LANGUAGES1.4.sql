UPDATE MENU SET MENU_TEXT = N'6.1. Nhập kho vật tư/phụ tùng', MENU_ENGLISH = N'6.1. Good Receipt', MENU_INDEX = 1 WHERE MENU_ID = 'mnuNhapkhoVTPT'
UPDATE MENU SET MENU_TEXT = N'6.2. Xuất kho vật tư/phụ tùng', MENU_ENGLISH = N'6.2. Good Issue', MENU_INDEX = 2 WHERE MENU_ID = 'mnuXuatkhoVTPT'
UPDATE MENU SET MENU_TEXT = N'6.3. Đề xuất mua hàng ', MENU_ENGLISH = N'6.3. Purchasing Request', MENU_INDEX = 4 WHERE MENU_ID = 'mnuDeXuatMuaHang'
IF EXISTS (SELECT * FROM MENU WHERE MENU_ID = 'mnuDonDatHang') UPDATE MENU SET MENU_TEXT = N'6.4. Đơn đặt hàng', MENU_ENGLISH = N'6.4. Purchase order', MENU_INDEX = 5 WHERE MENU_ID = 'mnuDonDatHang' ELSE INSERT INTO MENU (MENU_ID, MENU_TEXT, MENU_ENGLISH , MENU_PARENT, MENU_LINE, MENU_INDEX, SHORT_KEY, CLASS_NAME , FUNCTION_NAME, AN_HIEN)
VALUES ('mnuDonDatHang', N'6.4. Đơn đặt hàng', N'6.4. Purchase order', N'mnuQuanlykho', 0, 5, NULL, 'frmMain', NULL, 0)
UPDATE MENU SET MENU_TEXT = N'6.5. Di chuyển vật tư trong kho', MENU_ENGLISH = N'6.5. Item Move', MENU_INDEX = 6 WHERE MENU_ID = 'mnuDichuyenVT'
UPDATE MENU SET MENU_TEXT = N'6.6. Kiểm kê vật tư/phụ tùng', MENU_ENGLISH = N'6.6. Physical counting', MENU_INDEX = 7 WHERE MENU_ID = 'mnuKiemke'
UPDATE MENU SET MENU_TEXT = N'6.7. Tìm vật tư trong kho', MENU_ENGLISH = N'6.7. Inventory Item Search', MENU_INDEX = 8 WHERE MENU_ID = 'mnuTimvattu'
UPDATE MENU SET MENU_TEXT = N'6.8. Tình hình tồn kho VTPT', MENU_ENGLISH = N'6.8. Stock Status', MENU_INDEX = 9 WHERE MENU_ID = 'mnuTinhhinhtonkho'
UPDATE MENU SET MENU_TEXT = N'6.9. Tìm vật tư đề xuất', MENU_ENGLISH = N'6.9. Requested Item Search', MENU_INDEX = 10 WHERE MENU_ID = 'mnuTimvattudexuat'
UPDATE MENU SET MENU_TEXT = N' 6.11. Tìm vật tư nhập kho', MENU_ENGLISH = N'6.11. Goods Receipt Item Search', MENU_INDEX = 12 WHERE MENU_ID = 'mnuVatTuPhuTung'
IF EXISTS (SELECT * FROM MENU WHERE MENU_ID = 'mnuVatTuXuatKho') UPDATE MENU SET MENU_TEXT = N'6.12. Tìm vật tư xuất kho', MENU_ENGLISH = N'6.12. Search for materials for warehousing', MENU_INDEX = 13 WHERE MENU_ID = 'mnuVatTuXuatKho' ELSE INSERT INTO MENU (MENU_ID, MENU_TEXT, MENU_ENGLISH , MENU_PARENT, MENU_LINE, MENU_INDEX, SHORT_KEY, CLASS_NAME , FUNCTION_NAME, AN_HIEN) VALUES ('mnuVatTuXuatKho', N'6.12. Tìm vật tư xuất kho', N'6.12. Search for materials for warehousing', N'mnuQuanlykho', 0,13, NULL, 'frmMain', NULL, 0)

IF EXISTS (SELECT * FROM MENU WHERE MENU_ID = 'mnuTimVatTuDonHang') UPDATE MENU SET MENU_TEXT = N'6.10. Tìm vật tư đơn hàng', MENU_ENGLISH = N'6.10. Search for materials for request', MENU_INDEX = 11 WHERE MENU_ID = 'mnuTimVatTuDonHang'  ELSE INSERT INTO MENU (MENU_ID, MENU_TEXT, MENU_ENGLISH , MENU_PARENT, MENU_LINE, MENU_INDEX, SHORT_KEY, CLASS_NAME , FUNCTION_NAME, AN_HIEN) VALUES ('mnuTimVatTuDonHang', N'6.10. Tìm vật tư đơn hàng', N'6.10. Search for materials for request', N'mnuQuanlykho', 0,11, NULL, 'frmMain', NULL, 0)
UPDATE MENU SET MENU_TEXT = N'6.13. Danh mục kho', MENU_ENGLISH = N'6.13. List of Warehouses', MENU_INDEX = 14 WHERE MENU_ID = 'mnuDanhmuckho'
UPDATE MENU SET MENU_TEXT = N'6.14. Quy trình duyệt tài liệu', MENU_ENGLISH = N'6.14. Document Approval Procedure', MENU_INDEX = 15 WHERE MENU_ID = 'mnuDuyetTaiLieu'
UPDATE MENU SET MENU_TEXT = N'6.15. Cập nhật Min-Max', MENU_ENGLISH = N'6.15. Min-max Setup', MENU_INDEX = 17 WHERE MENU_ID = 'mnuSetMin_Max'
UPDATE MENU SET MENU_TEXT = N'6.16. Nhập xác vật tư phụ tùng', MENU_ENGLISH = N'6.16. Old Goods Receipt', MENU_INDEX = 18 WHERE MENU_ID = 'mnuPhieuNhapXac'
UPDATE MENU SET MENU_TEXT = N'6.17. Xuất xác vật tư phụ tùng', MENU_ENGLISH = N'6.17. Old Goods Issue', MENU_INDEX = 19 WHERE MENU_ID = 'mnuPhieuXuatXac'


IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucNhapXuatTon' AND KEYWORD =N'XuatCho') UPDATE LANGUAGES SET VIETNAM=N'Xuất cho', ENGLISH=N'Issued for', VIETNAM_OR=N'Xuất cho', ENGLISH_OR=N'Issued for' WHERE FORM=N'ucNhapXuatTon' AND KEYWORD=N'XuatCho' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucNhapXuatTon',N'XuatCho',N'Xuất cho',N'Issued for',N'Xuất cho',N'Issued for')
