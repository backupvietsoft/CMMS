﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhomquyen' AND KEYWORD =N'sBaoCao') UPDATE LANGUAGES SET VIETNAM=N'Báo cáo', ENGLISH=N'Report',CHINESE=N'Report', VIETNAM_OR=N'Báo cáo', ENGLISH_OR=N'Report' , CHINESE_OR=N'Report' WHERE FORM=N'frmNhomquyen' AND KEYWORD=N'sBaoCao' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmNhomquyen',N'sBaoCao',N'Báo cáo',N'Report',N'Report',N'Báo cáo',N'Report',N'Report','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhomquyen' AND KEYWORD =N'sBaoCaoGuiMail') UPDATE LANGUAGES SET VIETNAM=N'Báo cáo gửi mail', ENGLISH=N'Reports send mail',CHINESE=N'Reports send mail', VIETNAM_OR=N'Báo cáo gửi mail', ENGLISH_OR=N'Reports send mail' , CHINESE_OR=N'Reports send mail' WHERE FORM=N'frmNhomquyen' AND KEYWORD=N'sBaoCaoGuiMail' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmNhomquyen',N'sBaoCaoGuiMail',N'Báo cáo gửi mail',N'Reports send mail',N'Reports send mail',N'Báo cáo gửi mail',N'Reports send mail',N'Reports send mail','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhomquyen' AND KEYWORD =N'sCheDoHienThi') UPDATE LANGUAGES SET VIETNAM=N'Chế độ hiển thị', ENGLISH=N'Display mode',CHINESE=N'Display mode', VIETNAM_OR=N'Chế độ hiển thị', ENGLISH_OR=N'Display mode' , CHINESE_OR=N'Display mode' WHERE FORM=N'frmNhomquyen' AND KEYWORD=N'sCheDoHienThi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmNhomquyen',N'sCheDoHienThi',N'Chế độ hiển thị',N'Display mode',N'Display mode',N'Chế độ hiển thị',N'Display mode',N'Display mode','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmNhomquyen' AND KEYWORD =N'Tab_Menu') UPDATE LANGUAGES SET VIETNAM=N'Menu', ENGLISH=N'Menu',CHINESE=N'Menu', VIETNAM_OR=N'Menu', ENGLISH_OR=N'Menu' , CHINESE_OR=N'Menu' WHERE FORM=N'frmNhomquyen' AND KEYWORD=N'Tab_Menu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmNhomquyen',N'Tab_Menu',N'Menu',N'Menu',N'Menu',N'Menu',N'Menu',N'Menu','ECOMAIN')
