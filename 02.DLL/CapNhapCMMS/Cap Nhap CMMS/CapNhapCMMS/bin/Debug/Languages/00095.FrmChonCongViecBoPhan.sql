﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'BtnThucHien') UPDATE LANGUAGES SET VIETNAM=N'Thực hiện', ENGLISH=N'Execute', VIETNAM_OR=N'Thực hiện', ENGLISH_OR=N'Execute' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'BtnThucHien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'BtnThucHien',N'Thực hiện',N'Execute',N'Thực hiện',N'Execute')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'CHON') UPDATE LANGUAGES SET VIETNAM=N'Chọn', ENGLISH=N'Select', VIETNAM_OR=N'Chọn', ENGLISH_OR=N'Select' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'CHON' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'CHON',N'Chọn',N'Select',N'Chọn',N'Select')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'FrmChonCongViecBoPhan') UPDATE LANGUAGES SET VIETNAM=N'Chọn công việc cho bộ phận', ENGLISH=N'Select work for component', VIETNAM_OR=N'Chọn công việc cho bộ phận', ENGLISH_OR=N'Select work for component' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'FrmChonCongViecBoPhan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'FrmChonCongViecBoPhan',N'Chọn công việc cho bộ phận',N'Select work for component',N'Chọn công việc cho bộ phận',N'Select work for component')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'KY_HIEU_CV') UPDATE LANGUAGES SET VIETNAM=N'Ký hiệu công việc', ENGLISH=N'Work symbol', VIETNAM_OR=N'Ký hiệu công việc', ENGLISH_OR=N'Work symbol' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'KY_HIEU_CV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'KY_HIEU_CV',N'Ký hiệu công việc',N'Work symbol',N'Ký hiệu công việc',N'Work symbol')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'label1') UPDATE LANGUAGES SET VIETNAM=N'Tìm kiếm theo ký hiệu', ENGLISH=N'Search by symbol', VIETNAM_OR=N'Tìm kiếm theo ký hiệu', ENGLISH_OR=N'Search by symbol' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'label1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'label1',N'Tìm kiếm theo ký hiệu',N'Search by symbol',N'Tìm kiếm theo ký hiệu',N'Search by symbol')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'LblChonCV') UPDATE LANGUAGES SET VIETNAM=N'Loại công việc', ENGLISH=N'Work type', VIETNAM_OR=N'Loại công việc', ENGLISH_OR=N'Work type' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'LblChonCV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'LblChonCV',N'Loại công việc',N'Work type',N'Loại công việc',N'Work type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'LblTieudechukyBTPN') UPDATE LANGUAGES SET VIETNAM=N'CHỌN CÔNG VIỆC CHO BỘ PHẬN', ENGLISH=N'SELECT WORK FOR COMPONENT', VIETNAM_OR=N'CHỌN CÔNG VIỆC CHO BỘ PHẬN', ENGLISH_OR=N'SELECT WORK FOR COMPONENT' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'LblTieudechukyBTPN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'LblTieudechukyBTPN',N'CHỌN CÔNG VIỆC CHO BỘ PHẬN',N'SELECT WORK FOR COMPONENT',N'CHỌN CÔNG VIỆC CHO BỘ PHẬN',N'SELECT WORK FOR COMPONENT')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'lblTimkiem') UPDATE LANGUAGES SET VIETNAM=N'Tìm kiếm', ENGLISH=N'Search', VIETNAM_OR=N'Tìm kiếm', ENGLISH_OR=N'Search' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'lblTimkiem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'lblTimkiem',N'Tìm kiếm',N'Search',N'Tìm kiếm',N'Search')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'MO_TA_CV') UPDATE LANGUAGES SET VIETNAM=N'Mô tả công việc', ENGLISH=N'Work Description', VIETNAM_OR=N'Mô tả công việc', ENGLISH_OR=N'Work Description' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'MO_TA_CV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'MO_TA_CV',N'Mô tả công việc',N'Work Description',N'Mô tả công việc',N'Work Description')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'chkChon') UPDATE LANGUAGES SET VIETNAM=N'Chọn', ENGLISH=N'Check', VIETNAM_OR=N'Chọn', ENGLISH_OR=N'Check' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'chkChon' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'chkChon',N'Chọn',N'Check',N'Chọn',N'Check')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'MS_CV') UPDATE LANGUAGES SET VIETNAM=N'MS công việc', ENGLISH=N'Work ID', VIETNAM_OR=N'MS công việc', ENGLISH_OR=N'Work ID' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'MS_CV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'MS_CV',N'MS công việc',N'Work ID',N'MS công việc',N'Work ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'MS_LOAI_CV') UPDATE LANGUAGES SET VIETNAM=N'Mã loại công việc', ENGLISH=N'Work type', VIETNAM_OR=N'Mã loại công việc', ENGLISH_OR=N'Work type' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'MS_LOAI_CV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'MS_LOAI_CV',N'Mã loại công việc',N'Work type',N'Mã loại công việc',N'Work type')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'THOI_GIAN_DU_KIEN') UPDATE LANGUAGES SET VIETNAM=N'Thời gian chuẩn', ENGLISH=N'Standard time', VIETNAM_OR=N'Thời gian chuẩn', ENGLISH_OR=N'Standard time' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'THOI_GIAN_DU_KIEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'THOI_GIAN_DU_KIEN',N'Thời gian chuẩn',N'Standard time',N'Thời gian chuẩn',N'Standard time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'btnTaoMoiCV') UPDATE LANGUAGES SET VIETNAM=N'Thêm CV', ENGLISH=N'Add work', VIETNAM_OR=N'Thêm CV', ENGLISH_OR=N'Add work' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'btnTaoMoiCV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'btnTaoMoiCV',N'Thêm CV',N'Add work',N'Thêm CV',N'Add work')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'MS_CV_TIM') UPDATE LANGUAGES SET VIETNAM=N'Mã CV', ENGLISH=N'Work ID', VIETNAM_OR=N'Mã CV', ENGLISH_OR=N'Work ID' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'MS_CV_TIM' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'MS_CV_TIM',N'Mã CV',N'Work ID',N'Mã CV',N'Work ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD =N'MA_CV') UPDATE LANGUAGES SET VIETNAM=N'Công việc', ENGLISH=N'Work', VIETNAM_OR=N'Công việc', ENGLISH_OR=N'Work' WHERE FORM=N'FrmChonCongViecBoPhan' AND KEYWORD=N'MA_CV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmChonCongViecBoPhan',N'MA_CV',N'Công việc',N'Work',N'Công việc',N'Work')
