﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'rptPHIEU_BAO_TRI_NT' AND KEYWORD =N'TMP6') UPDATE LANGUAGES SET VIETNAM=N'MS bộ phận', ENGLISH=N'Component ID',CHINESE=N'Component ID', VIETNAM_OR=N'MS bộ phận', ENGLISH_OR=N'Component ID' , CHINESE_OR=N'Component ID' WHERE FORM=N'rptPHIEU_BAO_TRI_NT' AND KEYWORD=N'TMP6' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'rptPHIEU_BAO_TRI_NT',N'TMP6',N'MS bộ phận',N'Component ID',N'Component ID',N'MS bộ phận',N'Component ID',N'Component ID','ECOMAIN')