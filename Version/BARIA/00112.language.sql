IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhatSinhDichVu' AND KEYWORD =N'msgTonTaiPBTChuaPhanBoChiPhi') UPDATE LANGUAGES SET VIETNAM=N'Còn PBT chưa phân bổ chi phí', ENGLISH=N'There are some MO with undistributed costs', VIETNAM_OR=N'Còn PBT chưa phân bổ chi phí', ENGLISH_OR=N'There are some MO with undistributed costs' WHERE FORM=N'frmPhatSinhDichVu' AND KEYWORD=N'msgTonTaiPBTChuaPhanBoChiPhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmPhatSinhDichVu',N'msgTonTaiPBTChuaPhanBoChiPhi',N'Còn PBT chưa phân bổ chi phí',N'There are some MO with undistributed costs',N'Còn PBT chưa phân bổ chi phí',N'There are some MO with undistributed costs')
