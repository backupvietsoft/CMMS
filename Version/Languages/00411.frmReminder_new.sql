﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmReminder_new' AND KEYWORD =N'tabDSYeuCau') UPDATE LANGUAGES SET VIETNAM=N'Danh sách yêu cầu', ENGLISH=N'List of requests',CHINESE=N'List of requests', VIETNAM_OR=N'Danh sách yêu cầu', ENGLISH_OR=N'List of requests' , CHINESE_OR=N'List of requests' WHERE FORM=N'frmReminder_new' AND KEYWORD=N'tabDSYeuCau' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmReminder_new',N'tabDSYeuCau',N'Danh sách yêu cầu',N'List of requests',N'List of requests',N'Danh sách yêu cầu',N'List of requests',N'List of requests','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmReminder_new' AND KEYWORD =N'mnuHyperLinkmnuDSYC') UPDATE LANGUAGES SET VIETNAM=N'Link đến duyệt yêu cầu', ENGLISH=N'link to approve request',CHINESE=N'link to approve request', VIETNAM_OR=N'Link đến duyệt yêu cầu', ENGLISH_OR=N'link to approve request' , CHINESE_OR=N'link to approve request' WHERE FORM=N'frmReminder_new' AND KEYWORD=N'mnuHyperLinkmnuDSYC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmReminder_new',N'mnuHyperLinkmnuDSYC',N'Link đến duyệt yêu cầu',N'link to approve request',N'link to approve request',N'Link đến duyệt yêu cầu',N'link to approve request',N'link to approve request','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'MornitoringWeb' AND KEYWORD =N'tabGSTTKD') UPDATE LANGUAGES SET VIETNAM=N'Thông số không đạt', ENGLISH=N'CM parameter is out of range',CHINESE=N'CM parameter is out of range', VIETNAM_OR=N'Thông số không đạt', ENGLISH_OR=N'CM parameter is out of range' , CHINESE_OR=N'CM parameter is out of range' WHERE FORM=N'MornitoringWeb' AND KEYWORD=N'tabGSTTKD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'MornitoringWeb',N'tabGSTTKD',N'Thông số không đạt',N'CM parameter is out of range',N'CM parameter is out of range',N'Thông số không đạt',N'CM parameter is out of range',N'CM parameter is out of range','ECOMAIN')
