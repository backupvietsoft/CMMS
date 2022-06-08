﻿
DECLARE @menu nvarchar(500)
DECLARE @menu1 nvarchar(500)

SET @menu1 = 'mnuTamXuatTaiNhap'
set @menu =  N'ΞΠήͬΆΞʹήΆάͬΆΖ͠ΔΆΤ'

IF NOT EXISTS (SELECT * FROM dbo.LIC_MENU WHERE MENU_ID = @menu)
	INSERT INTO LIC_MENU (MENU_ID,TYPE_LIC) VALUES ( @menu,N'̦')

IF NOT EXISTS (SELECT * FROM dbo.MENU WHERE MENU_ID = @menu1)
	INSERT	dbo.MENU(MENU_ID,MENU_TEXT,MENU_ENGLISH,MENU_PARENT,MENU_LINE,MENU_INDEX,CLASS_NAME,FUNCTION_NAME,AN_HIEN)
		VALUES(@menu1, N'6.19. Tạm xuất tái nhập',  N'6.19. Tạm xuất tái nhập', 'mnuQuanlykho',0,21,'frmMain','ShowTamXuatTaiNhap',1)
	
IF NOT EXISTS (SELECT * FROM NHOM_MENU WHERE MENU_ID = @menu1)
	INSERT INTO NHOM_MENU(MENU_ID,GROUP_ID)
	VALUES(@menu1, 1)

DECLARE @frmname NVARCHAR(100) = 'frmPhieuTamXuatTaiNhap'
DECLARE @frmnameMH NVARCHAR(100) = N'ΐΨΞͤΔΖΎήͬΆΞʹήΆάͬΆΖ͠ΔΆΤ'

IF NOT EXISTS (SELECT * FROM CHI_TIET_FORMS WHERE FORM_NAME = @frmname)
BEGIN
	INSERT INTO CHI_TIET_FORMS(FORM_NAME, TEN_FORMS_VIET, TEN_FORMS_ANH ) VALUES (@frmname, N'6.19. Tạm xuất tái nhập', N'6.19. Tạm xuất tái nhập')
END

IF NOT EXISTS (SELECT * FROM NHOM_FORM  WHERE FORM_NAME = @frmname AND GROUP_ID = 1)
BEGIN
	INSERT INTO NHOM_FORM(GROUP_ID,FORM_NAME) VALUES (1,@frmname)
END
IF NOT EXISTS (SELECT * FROM LIC_FORM WHERE FORM_NAME  = @frmnameMH)
	INSERT INTO LIC_FORM (FORM_NAME,TYPE_LIC) VALUES ( @frmnameMH,N'̦')


