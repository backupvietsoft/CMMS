IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoNXThang' AND KEYWORD =N'TieuDeTGNM') UPDATE LANGUAGES SET VIETNAM=N'DIỄN BIẾN THỜI GIAN NGỪNG MÁY THEO THÁNG ', ENGLISH=N'DOWNTIME PROGRESS BY MONTH ', VIETNAM_OR=N'DIỄN BIẾN THỜI GIAN NGỪNG MÁY THEO THÁNG ', ENGLISH_OR=N'DOWNTIME PROGRESS BY MONTH ' WHERE FORM=N'ucBieuDoTGNMayTheoNXThang' AND KEYWORD=N'TieuDeTGNM' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoNXThang',N'TieuDeTGNM',N'DIỄN BIẾN THỜI GIAN NGỪNG MÁY THEO THÁNG ',N'DOWNTIME PROGRESS BY MONTH ',N'DIỄN BIẾN THỜI GIAN NGỪNG MÁY THEO THÁNG ',N'DOWNTIME PROGRESS BY MONTH ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoMay' AND KEYWORD =N'TDTGSC') UPDATE LANGUAGES SET VIETNAM=N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ', ENGLISH=N'REPAIR TIME PROGRESS BY MONTH', VIETNAM_OR=N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ', ENGLISH_OR=N'REPAIR TIME PROGRESS BY MONTH' WHERE FORM=N'ucBieuDoTGNMayTheoMay' AND KEYWORD=N'TDTGSC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoMay',N'TDTGSC',N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ',N'REPAIR TIME PROGRESS BY MONTH',N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ',N'REPAIR TIME PROGRESS BY MONTH')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoThang' AND KEYWORD =N'TieuDeTGSC') UPDATE LANGUAGES SET VIETNAM=N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ', ENGLISH=N'REPAIR TIME PROGRESS BY MONTH', VIETNAM_OR=N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ', ENGLISH_OR=N'REPAIR TIME PROGRESS BY MONTH' WHERE FORM=N'ucBieuDoTGNMayTheoThang' AND KEYWORD=N'TieuDeTGSC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoThang',N'TieuDeTGSC',N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ',N'REPAIR TIME PROGRESS BY MONTH',N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ',N'REPAIR TIME PROGRESS BY MONTH')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoNXThang' AND KEYWORD =N'TieuDeTGSC') UPDATE LANGUAGES SET VIETNAM=N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ', ENGLISH=N'REPAIR TIME PROGRESS BY MONTH', VIETNAM_OR=N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ', ENGLISH_OR=N'REPAIR TIME PROGRESS BY MONTH' WHERE FORM=N'ucBieuDoTGNMayTheoNXThang' AND KEYWORD=N'TieuDeTGSC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoNXThang',N'TieuDeTGSC',N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ',N'REPAIR TIME PROGRESS BY MONTH',N'DIỄN BIẾN THỜI GIAN SỬA CHỮA THEO THÁNG ',N'REPAIR TIME PROGRESS BY MONTH')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'Expr1') UPDATE LANGUAGES SET VIETNAM=N'Tên phụ tùng ', ENGLISH=N'Spare part name', VIETNAM_OR=N'Tên phụ tùng ', ENGLISH_OR=N'Spare part name' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'Expr1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'Expr1',N'Tên phụ tùng ',N'Spare part name',N'Tên phụ tùng ',N'Spare part name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoNX' AND KEYWORD =N'TieuDeLTB') UPDATE LANGUAGES SET VIETNAM=N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ', ENGLISH=N'TOTAL DOWNTIME IN PERIOD OF TIME ', VIETNAM_OR=N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ', ENGLISH_OR=N'TOTAL DOWNTIME IN PERIOD OF TIME ' WHERE FORM=N'ucBieuDoTGNMayTheoNX' AND KEYWORD=N'TieuDeLTB' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoNX',N'TieuDeLTB',N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ',N'TOTAL DOWNTIME IN PERIOD OF TIME ',N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ',N'TOTAL DOWNTIME IN PERIOD OF TIME ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoNX' AND KEYWORD =N'TieuDeNX') UPDATE LANGUAGES SET VIETNAM=N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ', ENGLISH=N'TOTAL DOWNTIME IN PERIOD OF TIME ', VIETNAM_OR=N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ', ENGLISH_OR=N'TOTAL DOWNTIME IN PERIOD OF TIME ' WHERE FORM=N'ucBieuDoTGNMayTheoNX' AND KEYWORD=N'TieuDeNX' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoNX',N'TieuDeNX',N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ',N'TOTAL DOWNTIME IN PERIOD OF TIME ',N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ',N'TOTAL DOWNTIME IN PERIOD OF TIME ')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoNX' AND KEYWORD =N'TieuDeDC') UPDATE LANGUAGES SET VIETNAM=N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ', ENGLISH=N'TOTAL DOWNTIME IN PERIOD OF TIME ', VIETNAM_OR=N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ', ENGLISH_OR=N'TOTAL DOWNTIME IN PERIOD OF TIME ' WHERE FORM=N'ucBieuDoTGNMayTheoNX' AND KEYWORD=N'TieuDeDC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoNX',N'TieuDeDC',N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ',N'TOTAL DOWNTIME IN PERIOD OF TIME ',N'THỜI GIAN NGỪNG MÁY TỔNG CỘNG THEO GIAI ĐOẠN ',N'TOTAL DOWNTIME IN PERIOD OF TIME ')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBieuDoTGNMayTheoNXThang' AND KEYWORD =N'TieuDeMTTR') UPDATE LANGUAGES SET VIETNAM=N'THỜI GIAN SỬA CHỮA TRUNG BÌNH TRONG GIAI ĐOẠN', ENGLISH=N'MEAN TIME TO REPAIR IN PERIOD OF TIME', VIETNAM_OR=N'THỜI GIAN SỬA CHỮA TRUNG BÌNH TRONG GIAI ĐOẠN', ENGLISH_OR=N'MEAN TIME TO REPAIR IN PERIOD OF TIME' WHERE FORM=N'ucBieuDoTGNMayTheoNXThang' AND KEYWORD=N'TieuDeMTTR' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBieuDoTGNMayTheoNXThang',N'TieuDeMTTR',N'THỜI GIAN SỬA CHỮA TRUNG BÌNH TRONG GIAI ĐOẠN',N'MEAN TIME TO REPAIR IN PERIOD OF TIME',N'THỜI GIAN SỬA CHỮA TRUNG BÌNH TRONG GIAI ĐOẠN',N'MEAN TIME TO REPAIR IN PERIOD OF TIME')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmDanhmuchethong' AND KEYWORD =N'msgDaychuyenNull') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập tên dây chuyền', ENGLISH=N'Line name not empty', VIETNAM_OR=N'Vui lòng nhập tên dây chuyền', ENGLISH_OR=N'Line name not empty' WHERE FORM=N'frmDanhmuchethong' AND KEYWORD=N'msgDaychuyenNull' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmDanhmuchethong',N'msgDaychuyenNull',N'Vui lòng nhập tên dây chuyền',N'Line name not empty',N'Vui lòng nhập tên dây chuyền',N'Line name not empty')

