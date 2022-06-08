﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'btnExecute') UPDATE LANGUAGES SET VIETNAM=N'Thực hiện', ENGLISH=N'Execute', VIETNAM_OR=N'Thực hiện', ENGLISH_OR=N'Execute' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'btnExecute' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'btnExecute',N'Thực hiện',N'Execute',N'Thực hiện',N'Execute')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'lblKho') UPDATE LANGUAGES SET VIETNAM=N'Kho', ENGLISH=N'Warehouse', VIETNAM_OR=N'Kho', ENGLISH_OR=N'Warehouse' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'lblKho' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'lblKho',N'Kho',N'Warehouse',N'Kho',N'Warehouse')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'lblTThang') UPDATE LANGUAGES SET VIETNAM=N'Từ', ENGLISH=N'From', VIETNAM_OR=N'Từ', ENGLISH_OR=N'From' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'lblTThang' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'lblTThang',N'Từ',N'From',N'Từ',N'From')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'lblLoaiVT') UPDATE LANGUAGES SET VIETNAM=N'Loại VT PT', ENGLISH=N'Item type', VIETNAM_OR=N'Loại VT PT', ENGLISH_OR=N'Item type' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'lblLoaiVT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'lblLoaiVT',N'Loại VT PT',N'Item type',N'Loại VT PT',N'Item type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'lblClassVT') UPDATE LANGUAGES SET VIETNAM=N'Class', ENGLISH=N'Class', VIETNAM_OR=N'Class', ENGLISH_OR=N'Class' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'lblClassVT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'lblClassVT',N'Class',N'Class',N'Class',N'Class')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'lblDThang') UPDATE LANGUAGES SET VIETNAM=N'Đến', ENGLISH=N'To', VIETNAM_OR=N'Đến', ENGLISH_OR=N'To' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'lblDThang' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'lblDThang',N'Đến',N'To',N'Đến',N'To')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'KhongCoDuLieu') UPDATE LANGUAGES SET VIETNAM=N'Không có dữ liệu in!', ENGLISH=N'No data to print!', VIETNAM_OR=N'Không có dữ liệu in!', ENGLISH_OR=N'No data to print!' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'KhongCoDuLieu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'KhongCoDuLieu',N'Không có dữ liệu in!',N'No data to print!',N'Không có dữ liệu in!',N'No data to print!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'TieuDe') UPDATE LANGUAGES SET VIETNAM=N'TỒN KHO AN TOÀN', ENGLISH=N'SAFETY STOCK REPORT', VIETNAM_OR=N'TỒN KHO AN TOÀN', ENGLISH_OR=N'SAFETY STOCK REPORT' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'TieuDe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'TieuDe',N'TỒN KHO AN TOÀN',N'SAFETY STOCK REPORT',N'TỒN KHO AN TOÀN',N'SAFETY STOCK REPORT')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'grpMay') UPDATE LANGUAGES SET VIETNAM=N'Thiết bị', ENGLISH=N'Equipment', VIETNAM_OR=N'Thiết bị', ENGLISH_OR=N'Equipment' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'grpMay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'grpMay',N'Thiết bị',N'Equipment',N'Thiết bị',N'Equipment')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'LonHonMotThang') UPDATE LANGUAGES SET VIETNAM=N'Khoảng thời gian chọn phải lớn hơn 1 tháng!', ENGLISH=N'The period must be longer than 1 month!', VIETNAM_OR=N'Khoảng thời gian chọn phải lớn hơn 1 tháng!', ENGLISH_OR=N'The period must be longer than 1 month!' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'LonHonMotThang' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'LonHonMotThang',N'Khoảng thời gian chọn phải lớn hơn 1 tháng!',N'The period must be longer than 1 month!',N'Khoảng thời gian chọn phải lớn hơn 1 tháng!',N'The period must be longer than 1 month!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'ucSafetyStock') UPDATE LANGUAGES SET VIETNAM=N'Tồn kho an toàn', ENGLISH=N'Safety stock', VIETNAM_OR=N'Tồn kho an toàn', ENGLISH_OR=N'Safety stock' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'ucSafetyStock' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'ucSafetyStock',N'Tồn kho an toàn',N'Safety stock',N'Tồn kho an toàn',N'Safety stock')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'TuThangLonHonDenThang') UPDATE LANGUAGES SET VIETNAM=N'Từ tháng phải nhỏ hơn đến tháng', ENGLISH=N'From must be earlier than To!', VIETNAM_OR=N'Từ tháng phải nhỏ hơn đến tháng', ENGLISH_OR=N'From must be earlier than To!' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'TuThangLonHonDenThang' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'TuThangLonHonDenThang',N'Từ tháng phải nhỏ hơn đến tháng',N'From must be earlier than To!',N'Từ tháng phải nhỏ hơn đến tháng',N'From must be earlier than To!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'MS_PT') UPDATE LANGUAGES SET VIETNAM=N'MS VT PT', ENGLISH=N'Item ID', VIETNAM_OR=N'MS VT PT', ENGLISH_OR=N'Item ID' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'MS_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'MS_PT',N'MS VT PT',N'Item ID',N'MS VT PT',N'Item ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'MS_PT_NCC') UPDATE LANGUAGES SET VIETNAM=N'Part No.', ENGLISH=N'Part No.', VIETNAM_OR=N'Part No.', ENGLISH_OR=N'Part No.' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'MS_PT_NCC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'MS_PT_NCC',N'Part No.',N'Part No.',N'Part No.',N'Part No.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'MS_PT_CTY') UPDATE LANGUAGES SET VIETNAM=N'Item code', ENGLISH=N'Item Code', VIETNAM_OR=N'Item code', ENGLISH_OR=N'Item Code' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'MS_PT_CTY' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'MS_PT_CTY',N'Item code',N'Item Code',N'Item code',N'Item Code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'TEN_PT') UPDATE LANGUAGES SET VIETNAM=N'Tên', ENGLISH=N'Name', VIETNAM_OR=N'Tên', ENGLISH_OR=N'Name' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'TEN_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'TEN_PT',N'Tên',N'Name',N'Tên',N'Name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'QUY_CACH') UPDATE LANGUAGES SET VIETNAM=N'Quy cách', ENGLISH=N'Specification', VIETNAM_OR=N'Quy cách', ENGLISH_OR=N'Specification' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'QUY_CACH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'QUY_CACH',N'Quy cách',N'Specification',N'Quy cách',N'Specification')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'TEN_DVT') UPDATE LANGUAGES SET VIETNAM=N'Đơn vị tính', ENGLISH=N'UoM ', VIETNAM_OR=N'Đơn vị tính', ENGLISH_OR=N'UoM ' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'TEN_DVT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'TEN_DVT',N'Đơn vị tính',N'UoM ',N'Đơn vị tính',N'UoM ')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'42339') UPDATE LANGUAGES SET VIETNAM=N'@12/2015@', ENGLISH=N'@12/2015@', VIETNAM_OR=N'@12/2015@', ENGLISH_OR=N'@12/2015@' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'42339' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'42339',N'@12/2015@',N'@12/2015@',N'@12/2015@',N'@12/2015@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'42370') UPDATE LANGUAGES SET VIETNAM=N'@01/2016@', ENGLISH=N'@01/2016@', VIETNAM_OR=N'@01/2016@', ENGLISH_OR=N'@01/2016@' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'42370' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'42370',N'@01/2016@',N'@01/2016@',N'@01/2016@',N'@01/2016@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'42401') UPDATE LANGUAGES SET VIETNAM=N'@02/2016@', ENGLISH=N'@02/2016@', VIETNAM_OR=N'@02/2016@', ENGLISH_OR=N'@02/2016@' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'42401' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'42401',N'@02/2016@',N'@02/2016@',N'@02/2016@',N'@02/2016@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'42430') UPDATE LANGUAGES SET VIETNAM=N'@03/2016@', ENGLISH=N'@03/2016@', VIETNAM_OR=N'@03/2016@', ENGLISH_OR=N'@03/2016@' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'42430' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'42430',N'@03/2016@',N'@03/2016@',N'@03/2016@',N'@03/2016@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'42461') UPDATE LANGUAGES SET VIETNAM=N'@04/2016@', ENGLISH=N'@04/2016@', VIETNAM_OR=N'@04/2016@', ENGLISH_OR=N'@04/2016@' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'42461' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'42461',N'@04/2016@',N'@04/2016@',N'@04/2016@',N'@04/2016@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'42491') UPDATE LANGUAGES SET VIETNAM=N'@05/2016@', ENGLISH=N'@05/2016@', VIETNAM_OR=N'@05/2016@', ENGLISH_OR=N'@05/2016@' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'42491' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'42491',N'@05/2016@',N'@05/2016@',N'@05/2016@',N'@05/2016@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'42522') UPDATE LANGUAGES SET VIETNAM=N'@06/2016@', ENGLISH=N'@06/2016@', VIETNAM_OR=N'@06/2016@', ENGLISH_OR=N'@06/2016@' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'42522' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'42522',N'@06/2016@',N'@06/2016@',N'@06/2016@',N'@06/2016@')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'AVARAGE') UPDATE LANGUAGES SET VIETNAM=N'Trung bình', ENGLISH=N'Average', VIETNAM_OR=N'Trung bình', ENGLISH_OR=N'Average' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'AVARAGE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'AVARAGE',N'Trung bình',N'Average',N'Trung bình',N'Average')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'SDEV') UPDATE LANGUAGES SET VIETNAM=N'SDEV', ENGLISH=N'SDEV', VIETNAM_OR=N'SDEV', ENGLISH_OR=N'SDEV' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'SDEV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'SDEV',N'SDEV',N'SDEV',N'SDEV',N'SDEV')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'SL') UPDATE LANGUAGES SET VIETNAM=N'Mức đảm bảo', ENGLISH=N'Service level', VIETNAM_OR=N'Mức đảm bảo', ENGLISH_OR=N'Service level' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'SL' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'SL',N'Mức đảm bảo',N'Service level',N'Mức đảm bảo',N'Service level')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'SF') UPDATE LANGUAGES SET VIETNAM=N'Hệ số đảm bảo', ENGLISH=N'Service factor', VIETNAM_OR=N'Hệ số đảm bảo', ENGLISH_OR=N'Service factor' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'SF' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'SF',N'Hệ số đảm bảo',N'Service factor',N'Hệ số đảm bảo',N'Service factor')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'LT') UPDATE LANGUAGES SET VIETNAM=N'Lead time', ENGLISH=N'Lead time', VIETNAM_OR=N'Lead time', ENGLISH_OR=N'Lead time' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'LT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'LT',N'Lead time',N'Lead time',N'Lead time',N'Lead time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'SS') UPDATE LANGUAGES SET VIETNAM=N'Tồn an toàn', ENGLISH=N'Safety stock', VIETNAM_OR=N'Tồn an toàn', ENGLISH_OR=N'Safety stock' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'SS' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'SS',N'Tồn an toàn',N'Safety stock',N'Tồn an toàn',N'Safety stock')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'MIN_STOCK') UPDATE LANGUAGES SET VIETNAM=N'Tồn tối thiểu tính toán', ENGLISH=N'Calculated min stock', VIETNAM_OR=N'Tồn tối thiểu tính toán', ENGLISH_OR=N'Calculated min stock' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'MIN_STOCK' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'MIN_STOCK',N'Tồn tối thiểu tính toán',N'Calculated min stock',N'Tồn tối thiểu tính toán',N'Calculated min stock')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucSafetyStock' AND KEYWORD =N'TON_TOI_THIEU') UPDATE LANGUAGES SET VIETNAM=N'Tồn tối thiểu hiện tại', ENGLISH=N'Current min stock', VIETNAM_OR=N'Tồn tối thiểu hiện tại', ENGLISH_OR=N'Current min stock' WHERE FORM=N'ucSafetyStock' AND KEYWORD=N'TON_TOI_THIEU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucSafetyStock',N'TON_TOI_THIEU',N'Tồn tối thiểu hiện tại',N'Current min stock',N'Tồn tối thiểu hiện tại',N'Current min stock')
