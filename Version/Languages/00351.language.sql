IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmGiamsattinhtrang' AND KEYWORD =N'TG_TT') UPDATE LANGUAGES SET VIETNAM=N'TG TT', ENGLISH=N'Actual time ', VIETNAM_OR=N'TG TT', ENGLISH_OR=N'Actual time ' WHERE FORM=N'frmGiamsattinhtrang' AND KEYWORD=N'TG_TT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmGiamsattinhtrang',N'TG_TT',N'TG TT',N'Actual time ',N'TG TT',N'Actual time ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmGiamsattinhtrang' AND KEYWORD =N'THOI_GIAN') UPDATE LANGUAGES SET VIETNAM=N'TG KH', ENGLISH=N'Plan time', VIETNAM_OR=N'TG KH', ENGLISH_OR=N'Plan time' WHERE FORM=N'frmGiamsattinhtrang' AND KEYWORD=N'THOI_GIAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmGiamsattinhtrang',N'THOI_GIAN',N'TG KH',N'Plan time',N'TG KH',N'Plan time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmGiamsattinhtrang' AND KEYWORD =N'CT_CVIEC') UPDATE LANGUAGES SET VIETNAM=N'…', ENGLISH=N'…', VIETNAM_OR=N'…', ENGLISH_OR=N'…' WHERE FORM=N'frmGiamsattinhtrang' AND KEYWORD=N'CT_CVIEC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmGiamsattinhtrang',N'CT_CVIEC',N'…',N'…',N'…',N'…')
