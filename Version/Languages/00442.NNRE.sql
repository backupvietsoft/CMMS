﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBaoCaoChung' AND KEYWORD =N'sNgayIn') UPDATE LANGUAGES SET VIETNAM=N'Ngày in : ', ENGLISH=N'Print date : ',CHINESE=N'Print date : ', VIETNAM_OR=N'Ngày in : ', ENGLISH_OR=N'Print date : ' , CHINESE_OR=N'Print date : ' WHERE FORM=N'ucBaoCaoChung' AND KEYWORD=N'sNgayIn' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBaoCaoChung',N'sNgayIn',N'Ngày in : ',N'Print date : ',N'Print date : ',N'Ngày in : ',N'Print date : ',N'Print date : ','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBaoCaoChung' AND KEYWORD =N'sTrang') UPDATE LANGUAGES SET VIETNAM=N'Trang : ', ENGLISH=N'Page : ',CHINESE=N'Page : ', VIETNAM_OR=N'Trang : ', ENGLISH_OR=N'Page : ' , CHINESE_OR=N'Page : ' WHERE FORM=N'ucBaoCaoChung' AND KEYWORD=N'sTrang' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBaoCaoChung',N'sTrang',N'Trang : ',N'Page : ',N'Page : ',N'Trang : ',N'Page : ',N'Page : ','ECOMAIN')
go
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmReminder_new' AND KEYWORD =N'sSoTaiLieu') UPDATE LANGUAGES SET VIETNAM=N'Số tài liệu:RIL-TM-MA-04', ENGLISH=N'Số tài liệu:RIL-TM-MA-04',CHINESE=N'Số tài liệu:RIL-TM-MA-04', VIETNAM_OR=N'Số tài liệu:RIL-TM-MA-04', ENGLISH_OR=N'Số tài liệu:RIL-TM-MA-04' , CHINESE_OR=N'Số tài liệu:RIL-TM-MA-04' WHERE FORM=N'frmReminder_new' AND KEYWORD=N'sSoTaiLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmReminder_new',N'sSoTaiLieu',N'Số tài liệu:RIL-TM-MA-04',N'Số tài liệu:RIL-TM-MA-04',N'Số tài liệu:RIL-TM-MA-04',N'Số tài liệu:RIL-TM-MA-04',N'Số tài liệu:RIL-TM-MA-04',N'Số tài liệu:RIL-TM-MA-04','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmReminder_new' AND KEYWORD =N'sPhienBan') UPDATE LANGUAGES SET VIETNAM=N'Phiên bản/Revision:03', ENGLISH=N'Phiên bản/Revision:03',CHINESE=N'Phiên bản/Revision:03', VIETNAM_OR=N'Phiên bản/Revision:03', ENGLISH_OR=N'Phiên bản/Revision:03' , CHINESE_OR=N'Phiên bản/Revision:03' WHERE FORM=N'frmReminder_new' AND KEYWORD=N'sPhienBan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmReminder_new',N'sPhienBan',N'Phiên bản/Revision:03',N'Phiên bản/Revision:03',N'Phiên bản/Revision:03',N'Phiên bản/Revision:03',N'Phiên bản/Revision:03',N'Phiên bản/Revision:03','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmReminder_new' AND KEYWORD =N'sNgayApDung') UPDATE LANGUAGES SET VIETNAM=N'Ngày áp dụng/Date:Aug.24.2026', ENGLISH=N'Ngày áp dụng/Date:Aug.24.2026',CHINESE=N'Ngày áp dụng/Date:Aug.24.2026', VIETNAM_OR=N'Ngày áp dụng/Date:Aug.24.2026', ENGLISH_OR=N'Ngày áp dụng/Date:Aug.24.2026' , CHINESE_OR=N'Ngày áp dụng/Date:Aug.24.2026' WHERE FORM=N'frmReminder_new' AND KEYWORD=N'sNgayApDung' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmReminder_new',N'sNgayApDung',N'Ngày áp dụng/Date:Aug.24.2026',N'Ngày áp dụng/Date:Aug.24.2026',N'Ngày áp dụng/Date:Aug.24.2026',N'Ngày áp dụng/Date:Aug.24.2026',N'Ngày áp dụng/Date:Aug.24.2026',N'Ngày áp dụng/Date:Aug.24.2026','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ApproveRequestWeb' AND KEYWORD =N'RequestNO') UPDATE LANGUAGES SET VIETNAM=N'Số yêu cầu', ENGLISH=N'Request No',CHINESE=N'Request No', VIETNAM_OR=N'Số yêu cầu', ENGLISH_OR=N'Request No' , CHINESE_OR=N'Request No' WHERE FORM=N'ApproveRequestWeb' AND KEYWORD=N'RequestNO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ApproveRequestWeb',N'RequestNO',N'Số yêu cầu',N'Request No',N'Request No',N'Số yêu cầu',N'Request No',N'Request No','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ApproveRequestWeb' AND KEYWORD =N'RequestedBy') UPDATE LANGUAGES SET VIETNAM=N'Người yêu cầu', ENGLISH=N'Requested by',CHINESE=N'Requested by', VIETNAM_OR=N'Người yêu cầu', ENGLISH_OR=N'Requested by' , CHINESE_OR=N'Requested by' WHERE FORM=N'ApproveRequestWeb' AND KEYWORD=N'RequestedBy' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ApproveRequestWeb',N'RequestedBy',N'Người yêu cầu',N'Requested by',N'Requested by',N'Người yêu cầu',N'Requested by',N'Requested by','ECOMAIN')