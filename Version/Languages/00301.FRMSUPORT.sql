﻿
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblTIEU_DE') UPDATE LANGUAGES SET VIETNAM=N'BẠN VUI LÒNG THÔNG BÁO CHO CHÚNG TÔI CÁC YÊU CẦU HỖ TRỢ VÀ CÁC CẢI TIẾN PHẦN MỀM TRONG GIAO DIỆN DƯỚI ĐÂY:', ENGLISH=N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:',CHINESE=N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:', VIETNAM_OR=N'BẠN VUI LÒNG THÔNG BÁO CHO CHÚNG TÔI CÁC YÊU CẦU HỖ TRỢ VÀ CÁC CẢI TIẾN PHẦN MỀM TRONG GIAO DIỆN DƯỚI ĐÂY:', ENGLISH_OR=N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:' , CHINESE_OR=N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblTIEU_DE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblTIEU_DE',N'BẠN VUI LÒNG THÔNG BÁO CHO CHÚNG TÔI CÁC YÊU CẦU HỖ TRỢ VÀ CÁC CẢI TIẾN PHẦN MỀM TRONG GIAO DIỆN DƯỚI ĐÂY:',N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:',N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:',N'BẠN VUI LÒNG THÔNG BÁO CHO CHÚNG TÔI CÁC YÊU CẦU HỖ TRỢ VÀ CÁC CẢI TIẾN PHẦN MỀM TRONG GIAO DIỆN DƯỚI ĐÂY:',N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:',N'YOU PLEASE NOTICE US SUPPORT REQUIREMENTS AND SOFTWARE IMPROVEMENTS IN THE INTERFACE BELOW:',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblDescription') UPDATE LANGUAGES SET VIETNAM=N'Mô tả', ENGLISH=N'Description',CHINESE=N'Description', VIETNAM_OR=N'Mô tả', ENGLISH_OR=N'Description' , CHINESE_OR=N'Description' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblDescription' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblDescription',N'Mô tả',N'Description',N'Description',N'Mô tả',N'Description',N'Description',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblDUONG_DAN_TL') UPDATE LANGUAGES SET VIETNAM=N'Đường dẫn tài liệu', ENGLISH=N'Document path',CHINESE=N'Document path', VIETNAM_OR=N'Đường dẫn tài liệu', ENGLISH_OR=N'Document path' , CHINESE_OR=N'Document path' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblDUONG_DAN_TL' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblDUONG_DAN_TL',N'Đường dẫn tài liệu',N'Document path',N'Document path',N'Đường dẫn tài liệu',N'Document path',N'Document path',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblEmail') UPDATE LANGUAGES SET VIETNAM=N'Email', ENGLISH=N'Email',CHINESE=N'Email', VIETNAM_OR=N'Email', ENGLISH_OR=N'Email' , CHINESE_OR=N'Email' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblEmail' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblEmail',N'Email',N'Email',N'Email',N'Email',N'Email',N'Email',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblFULL_NAME') UPDATE LANGUAGES SET VIETNAM=N'Full Name', ENGLISH=N'Full Name',CHINESE=N'Full Name', VIETNAM_OR=N'Full Name', ENGLISH_OR=N'Full Name' , CHINESE_OR=N'Full Name' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblFULL_NAME' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblFULL_NAME',N'Full Name',N'Full Name',N'Full Name',N'Full Name',N'Full Name',N'Full Name',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblID_Priority') UPDATE LANGUAGES SET VIETNAM=N'Mức độ khẩn cấp', ENGLISH=N'Urgency level',CHINESE=N'Urgency level', VIETNAM_OR=N'Mức độ khẩn cấp', ENGLISH_OR=N'Urgency level' , CHINESE_OR=N'Urgency level' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblID_Priority' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblID_Priority',N'Mức độ khẩn cấp',N'Urgency level',N'Urgency level',N'Mức độ khẩn cấp',N'Urgency level',N'Urgency level',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblID_RequestType') UPDATE LANGUAGES SET VIETNAM=N'Loại yêu cầu', ENGLISH=N'Request Type',CHINESE=N'Request Type', VIETNAM_OR=N'Loại yêu cầu', ENGLISH_OR=N'Request Type' , CHINESE_OR=N'Request Type' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblID_RequestType' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblID_RequestType',N'Loại yêu cầu',N'Request Type',N'Request Type',N'Loại yêu cầu',N'Request Type',N'Request Type',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblPhone') UPDATE LANGUAGES SET VIETNAM=N'Điện thoại', ENGLISH=N'Phone',CHINESE=N'Phone', VIETNAM_OR=N'Điện thoại', ENGLISH_OR=N'Phone' , CHINESE_OR=N'Phone' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblPhone' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblPhone',N'Điện thoại',N'Phone',N'Phone',N'Điện thoại',N'Phone',N'Phone',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblRequestName') UPDATE LANGUAGES SET VIETNAM=N'Tên yêu cầu', ENGLISH=N'Request Name',CHINESE=N'Request Name', VIETNAM_OR=N'Tên yêu cầu', ENGLISH_OR=N'Request Name' , CHINESE_OR=N'Request Name' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblRequestName' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblRequestName',N'Tên yêu cầu',N'Request Name',N'Request Name',N'Tên yêu cầu',N'Request Name',N'Request Name',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblTEN_CT') UPDATE LANGUAGES SET VIETNAM=N'Tên công ty', ENGLISH=N'Company Name',CHINESE=N'Company Name', VIETNAM_OR=N'Tên công ty', ENGLISH_OR=N'Company Name' , CHINESE_OR=N'Company Name' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblTEN_CT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblTEN_CT',N'Tên công ty',N'Company Name',N'Company Name',N'Tên công ty',N'Company Name',N'Company Name',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblUSER_NAME') UPDATE LANGUAGES SET VIETNAM=N'User Name', ENGLISH=N'User Name',CHINESE=N'User Name', VIETNAM_OR=N'User Name', ENGLISH_OR=N'User Name' , CHINESE_OR=N'User Name' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblUSER_NAME' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblUSER_NAME',N'User Name',N'User Name',N'User Name',N'User Name',N'User Name',N'User Name',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblYEU_CAU_TT') UPDATE LANGUAGES SET VIETNAM=N'Tiếp tục của yêu cầu', ENGLISH=N'Continuation of the request',CHINESE=N'Continuation of the request', VIETNAM_OR=N'Tiếp tục của yêu cầu', ENGLISH_OR=N'Continuation of the request' , CHINESE_OR=N'Continuation of the request' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblYEU_CAU_TT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblYEU_CAU_TT',N'Tiếp tục của yêu cầu',N'Continuation of the request',N'Continuation of the request',N'Tiếp tục của yêu cầu',N'Continuation of the request',N'Continuation of the request',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'lblZalo') UPDATE LANGUAGES SET VIETNAM=N'Zalo', ENGLISH=N'Zalo',CHINESE=N'Zalo', VIETNAM_OR=N'Zalo', ENGLISH_OR=N'Zalo' , CHINESE_OR=N'Zalo' WHERE FORM=N'frmSupport' AND KEYWORD=N'lblZalo' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'lblZalo',N'Zalo',N'Zalo',N'Zalo',N'Zalo',N'Zalo',N'Zalo',N'VS.ERP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmSupport' AND KEYWORD =N'msgChanThanhCamOn') UPDATE LANGUAGES SET VIETNAM=N'Chân thành cám ơn bạn đã gửi yêu cầu. Chúng tôi sẽ liên hệ lại sớm nhất!', ENGLISH=N'Thank you very much for submitting your request. We will contact you as soon as possible!',CHINESE=N'Thank you very much for submitting your request. We will contact you as soon as possible!', VIETNAM_OR=N'Chân thành cám ơn bạn đã gửi yêu cầu. Chúng tôi sẽ liên hệ lại sớm nhất!', ENGLISH_OR=N'Thank you very much for submitting your request. We will contact you as soon as possible!' , CHINESE_OR=N'Thank you very much for submitting your request. We will contact you as soon as possible!' WHERE FORM=N'frmSupport' AND KEYWORD=N'msgChanThanhCamOn' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmSupport',N'msgChanThanhCamOn',N'Chân thành cám ơn bạn đã gửi yêu cầu. Chúng tôi sẽ liên hệ lại sớm nhất!',N'Thank you very much for submitting your request. We will contact you as soon as possible!',N'Thank you very much for submitting your request. We will contact you as soon as possible!',N'Chân thành cám ơn bạn đã gửi yêu cầu. Chúng tôi sẽ liên hệ lại sớm nhất!',N'Thank you very much for submitting your request. We will contact you as soon as possible!',N'Thank you very much for submitting your request. We will contact you as soon as possible!',N'VS.ERP')
