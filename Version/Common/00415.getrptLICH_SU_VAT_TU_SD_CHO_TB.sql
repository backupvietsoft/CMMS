﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'getrptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD =N'TIEU_DE') UPDATE LANGUAGES SET VIETNAM=N'LỊCH SỬ VTPT SỬ DỤNG CHO THIẾT BỊ', ENGLISH=N'EQUIPMENT MATERIAL & SPARE PARTS HISTORY', VIETNAM_OR=N'LỊCH SỬ VTPT SỬ DỤNG CHO THIẾT BỊ', ENGLISH_OR=N'EQUIPMENT MATERIAL & SPARE PARTS HISTORY' WHERE FORM=N'getrptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD=N'TIEU_DE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'getrptLICH_SU_VAT_TU_SD_CHO_TB',N'TIEU_DE',N'LỊCH SỬ VTPT SỬ DỤNG CHO THIẾT BỊ',N'EQUIPMENT MATERIAL & SPARE PARTS HISTORY',N'LỊCH SỬ VTPT SỬ DỤNG CHO THIẾT BỊ',N'EQUIPMENT MATERIAL & SPARE PARTS HISTORY')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'getrptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD =N'TEN_PT') UPDATE LANGUAGES SET VIETNAM=N'Tên VTPT', ENGLISH=N'M&SP name', VIETNAM_OR=N'Tên VTPT', ENGLISH_OR=N'M&SP name' WHERE FORM=N'getrptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD=N'TEN_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'getrptLICH_SU_VAT_TU_SD_CHO_TB',N'TEN_PT',N'Tên VTPT',N'M&SP name',N'Tên VTPT',N'M&SP name')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'getrptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD =N'MS_PT') UPDATE LANGUAGES SET VIETNAM=N'VTPT', ENGLISH=N'M&SP', VIETNAM_OR=N'VTPT', ENGLISH_OR=N'M&SP' WHERE FORM=N'getrptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD=N'MS_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'getrptLICH_SU_VAT_TU_SD_CHO_TB',N'MS_PT',N'VTPT',N'M&SP',N'VTPT',N'M&SP')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'rptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD =N'rptLICH_SU_VAT_TU_SD_CHO_TB') UPDATE LANGUAGES SET VIETNAM=N'Danh sách lịch sử vật tư & phụ tùng được sử dụng cho thiết bị', ENGLISH=N'List of materials & spare parts used for equipment ', VIETNAM_OR=N'Danh sách lịch sử vật tư & phụ tùng được sử dụng cho thiết bị', ENGLISH_OR=N'List of materials & spare parts used for equipment ' WHERE FORM=N'rptLICH_SU_VAT_TU_SD_CHO_TB' AND KEYWORD=N'rptLICH_SU_VAT_TU_SD_CHO_TB' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'rptLICH_SU_VAT_TU_SD_CHO_TB',N'rptLICH_SU_VAT_TU_SD_CHO_TB',N'Danh sách lịch sử vật tư & phụ tùng được sử dụng cho thiết bị',N'List of materials & spare parts used for equipment ',N'Danh sách lịch sử vật tư & phụ tùng được sử dụng cho thiết bị',N'List of materials & spare parts used for equipment ')
