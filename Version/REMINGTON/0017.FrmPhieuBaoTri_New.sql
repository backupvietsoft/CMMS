﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'UserYeuCau') UPDATE LANGUAGES SET VIETNAM=N'User yêu cầu', ENGLISH=N'User request',CHINESE=N'User request', VIETNAM_OR=N'User yêu cầu', ENGLISH_OR=N'User request' , CHINESE_OR=N'User request' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'UserYeuCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuBaoTri_New',N'UserYeuCau',N'User yêu cầu',N'User request',N'User request',N'User yêu cầu',N'User request',N'User request','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'PhongBanYeuCau') UPDATE LANGUAGES SET VIETNAM=N'Bộ phận yêu cầu', ENGLISH=N'Department request',CHINESE=N'Department request', VIETNAM_OR=N'Bộ phận yêu cầu', ENGLISH_OR=N'Department request' , CHINESE_OR=N'Department request' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'PhongBanYeuCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmPhieuBaoTri_New',N'PhongBanYeuCau',N'Bộ phận yêu cầu',N'Department request',N'Department request',N'Bộ phận yêu cầu',N'Department request',N'Department request','ECOMAIN')
