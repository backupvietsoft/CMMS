IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmThongtinthietbi' AND KEYWORD =N'SO_LUONG') UPDATE LANGUAGES SET VIETNAM=N'SL sử dụng', ENGLISH=N'Used Qty', VIETNAM_OR=N'SL sử dụng', ENGLISH_OR=N'Used Qty' WHERE FORM=N'FrmThongtinthietbi' AND KEYWORD=N'SO_LUONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmThongtinthietbi',N'SO_LUONG',N'SL sử dụng',N'Used Qty',N'SL sử dụng',N'Used Qty')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'SL_MAX') UPDATE LANGUAGES SET VIETNAM=N'SL tổng', ENGLISH=N'Sum Qty', VIETNAM_OR=N'SL tổng', ENGLISH_OR=N'Sum Qty' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'SL_MAX' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'SL_MAX',N'SL tổng',N'Sum Qty',N'SL tổng',N'Sum Qty')
