IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBaoCaoCongViecBaoTri' AND KEYWORD =N'bcTieuDeBaoCaoTongCongViecBaoTri') UPDATE LANGUAGES SET VIETNAM=N'BÁO CÁO TỔNG CÔNG VIỆC', ENGLISH=N'GENERIC WORK REPORT', VIETNAM_OR=N'BÁO CÁO TỔNG CÔNG VIỆC', ENGLISH_OR=N'GENERIC WORK REPORT' WHERE FORM=N'ucBaoCaoCongViecBaoTri' AND KEYWORD=N'bcTieuDeBaoCaoTongCongViecBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBaoCaoCongViecBaoTri',N'bcTieuDeBaoCaoTongCongViecBaoTri',N'BÁO CÁO TỔNG CÔNG VIỆC',N'GENERIC WORK REPORT',N'BÁO CÁO TỔNG CÔNG VIỆC',N'GENERIC WORK REPORT')
