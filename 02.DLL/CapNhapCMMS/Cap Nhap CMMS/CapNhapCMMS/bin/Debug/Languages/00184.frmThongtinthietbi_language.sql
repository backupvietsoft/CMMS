IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'lblSTT') UPDATE LANGUAGES SET VIETNAM=N'Số thứ tự', ENGLISH=N'No.', VIETNAM_OR=N'Số thứ tự', ENGLISH_OR=N'No.' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'lblSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'lblSTT',N'Số thứ tự',N'No.',N'Số thứ tự',N'No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'msgSTTLaSo') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập số', ENGLISH=N'Please enter the No.', VIETNAM_OR=N'Vui lòng nhập số', ENGLISH_OR=N'Please enter the No.' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'msgSTTLaSo' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'msgSTTLaSo',N'Vui lòng nhập số',N'Please enter the No.',N'Vui lòng nhập số',N'Please enter the No.')
