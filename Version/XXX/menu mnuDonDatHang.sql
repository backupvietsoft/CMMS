﻿

UPDATE THONG_TIN_CHUNG SET DDH_DXMH = 1
UPDATE MENU SET AN_HIEN = 1 WHERE MENU_ID = 'mnuDonDatHang'

IF NOT EXISTS (SELECT * FROM NHOM_MENU WHERE MENU_ID = 'mnuDonDatHang' AND GROUP_ID = 1)
BEGIN
	INSERT INTO NHOM_MENU(GROUP_ID,MENU_ID) VALUES (1,'mnuDonDatHang')
END

IF NOT EXISTS (SELECT * FROM CHI_TIET_FORMS WHERE FORM_NAME = 'frmDonDatHang')
BEGIN
	INSERT INTO CHI_TIET_FORMS(FORM_NAME, TEN_FORMS_VIET, TEN_FORMS_ANH ) VALUES ('frmDonDatHang', N'6.4. Đơn đặt hàng', N'6.4. Đơn đặt hàng')
END

IF NOT EXISTS (SELECT * FROM NHOM_FORM  WHERE FORM_NAME = 'frmDonDatHang' AND GROUP_ID = 1)
BEGIN
	INSERT INTO NHOM_FORM(GROUP_ID,FORM_NAME) VALUES (1,'frmDonDatHang')
END

UPDATE MENU SET FUNCTION_NAME = 'ShowDonDatHang_New' WHERE MENU_ID = 'mnuDonDatHang'


IF NOT EXISTS (SELECT * FROM LIC_FORM WHERE FORM_NAME  = N'ΐΨΞ͌΢Π͌Άά͔ΆΠΒ')
	INSERT INTO LIC_FORM (FORM_NAME,TYPE_LIC) VALUES ( N'ΐΨΞ͌΢Π͌Άά͔ΆΠΒ',N'̦')
	