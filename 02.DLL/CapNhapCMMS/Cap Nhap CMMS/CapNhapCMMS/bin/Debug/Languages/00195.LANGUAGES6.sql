﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmucphutung_CS' AND KEYWORD =N'lblTong') UPDATE LANGUAGES SET VIETNAM=N'Tổng', ENGLISH=N'Sum', VIETNAM_OR=N'Tổng', ENGLISH_OR=N'Sum' WHERE FORM=N'frmDanhmucphutung_CS' AND KEYWORD=N'lblTong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmucphutung_CS',N'lblTong',N'Tổng',N'Sum',N'Tổng',N'Sum')
