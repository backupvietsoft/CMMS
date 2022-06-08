﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'NGAY_DUA_VAO_SD') UPDATE LANGUAGES SET VIETNAM=N'NĐVS Dụng', ENGLISH=N'Start working date',CHINESE=N'Start working date', VIETNAM_OR=N'NĐVS Dụng', ENGLISH_OR=N'Start working date' , CHINESE_OR=N'Start working date' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'NGAY_DUA_VAO_SD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'NGAY_DUA_VAO_SD',N'NĐVS Dụng',N'Start working date',N'Start working date',N'NĐVS Dụng',N'Start working date',N'Start working date','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'NGAY_HET_BAO_HANH') UPDATE LANGUAGES SET VIETNAM=N'NHết B Hành', ENGLISH=N'End of warranty on:',CHINESE=N'End of warranty on:', VIETNAM_OR=N'NHết B Hành', ENGLISH_OR=N'End of warranty on:' , CHINESE_OR=N'End of warranty on:' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'NGAY_HET_BAO_HANH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'NGAY_HET_BAO_HANH',N'NHết B Hành',N'End of warranty on:',N'End of warranty on:',N'NHết B Hành',N'End of warranty on:',N'End of warranty on:','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'NHIEM_VU_THIET_BI') UPDATE LANGUAGES SET VIETNAM=N'Nhiệm vụ thiết bị', ENGLISH=N'Equipment function',CHINESE=N'Equipment function', VIETNAM_OR=N'Nhiệm vụ thiết bị', ENGLISH_OR=N'Equipment function' , CHINESE_OR=N'Equipment function' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'NHIEM_VU_THIET_BI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'NHIEM_VU_THIET_BI',N'Nhiệm vụ thiết bị',N'Equipment function',N'Equipment function',N'Nhiệm vụ thiết bị',N'Equipment function',N'Equipment function','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'AN_TOAN') UPDATE LANGUAGES SET VIETNAM=N'An toàn', ENGLISH=N'Safety',CHINESE=N'Safety', VIETNAM_OR=N'An toàn', ENGLISH_OR=N'Safety' , CHINESE_OR=N'Safety' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'AN_TOAN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'AN_TOAN',N'An toàn',N'Safety',N'Safety',N'An toàn',N'Safety',N'Safety','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'sConBaoHanh') UPDATE LANGUAGES SET VIETNAM=N'Còn bảo hành', ENGLISH=N'In Warranty',CHINESE=N'In Warranty', VIETNAM_OR=N'Còn bảo hành', ENGLISH_OR=N'In Warranty' , CHINESE_OR=N'In Warranty' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'sConBaoHanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'sConBaoHanh',N'Còn bảo hành',N'In Warranty',N'In Warranty',N'Còn bảo hành',N'In Warranty',N'In Warranty','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'sHetBaoHanh') UPDATE LANGUAGES SET VIETNAM=N'Hết bảo hành', ENGLISH=N'No warranty',CHINESE=N'No warranty', VIETNAM_OR=N'Hết bảo hành', ENGLISH_OR=N'No warranty' , CHINESE_OR=N'No warranty' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'sHetBaoHanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'sHetBaoHanh',N'Hết bảo hành',N'No warranty',N'No warranty',N'Hết bảo hành',N'No warranty',N'No warranty','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'sBinhThuong') UPDATE LANGUAGES SET VIETNAM=N'Bình thường', ENGLISH=N'Not safety related',CHINESE=N'Not safety related', VIETNAM_OR=N'Bình thường', ENGLISH_OR=N'Not safety related' , CHINESE_OR=N'Not safety related' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'sBinhThuong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'sBinhThuong',N'Bình thường',N'Not safety related',N'Not safety related',N'Bình thường',N'Not safety related',N'Not safety related','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'sDamBaoAnToan') UPDATE LANGUAGES SET VIETNAM=N'Đảm bảo an toàn', ENGLISH=N'Safety Related',CHINESE=N'Safety Related', VIETNAM_OR=N'Đảm bảo an toàn', ENGLISH_OR=N'Safety Related' , CHINESE_OR=N'Safety Related' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'sDamBaoAnToan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'sDamBaoAnToan',N'Đảm bảo an toàn',N'Safety Related',N'Safety Related',N'Đảm bảo an toàn',N'Safety Related',N'Safety Related','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'sConKhauHao') UPDATE LANGUAGES SET VIETNAM=N'Còn khấu hao', ENGLISH=N'In depreciation',CHINESE=N'In depreciation', VIETNAM_OR=N'Còn khấu hao', ENGLISH_OR=N'In depreciation' , CHINESE_OR=N'In depreciation' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'sConKhauHao' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'sConKhauHao',N'Còn khấu hao',N'In depreciation',N'In depreciation',N'Còn khấu hao',N'In depreciation',N'In depreciation','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'sHetKhauHao') UPDATE LANGUAGES SET VIETNAM=N'Hết khấu hao', ENGLISH=N'Out of Depreciation',CHINESE=N'Out of Depreciation', VIETNAM_OR=N'Hết khấu hao', ENGLISH_OR=N'Out of Depreciation' , CHINESE_OR=N'Out of Depreciation' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'sHetKhauHao' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'sHetKhauHao',N'Hết khấu hao',N'Out of Depreciation',N'Out of Depreciation',N'Hết khấu hao',N'Out of Depreciation',N'Out of Depreciation','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'btnIN') UPDATE LANGUAGES SET VIETNAM=N'In', ENGLISH=N'Print',CHINESE=N'Print', VIETNAM_OR=N'In', ENGLISH_OR=N'Print' , CHINESE_OR=N'Print' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'btnIN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'btnIN',N'In',N'Print',N'Print',N'In',N'Print',N'Print','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblBPCP') UPDATE LANGUAGES SET VIETNAM=N'Bộ phận chịu phí', ENGLISH=N'Cost center',CHINESE=N'Cost center', VIETNAM_OR=N'Bộ phận chịu phí', ENGLISH_OR=N'Cost center' , CHINESE_OR=N'Cost center' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblBPCP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblBPCP',N'Bộ phận chịu phí',N'Cost center',N'Cost center',N'Bộ phận chịu phí',N'Cost center',N'Cost center','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblNMay') UPDATE LANGUAGES SET VIETNAM=N'Nhóm máy ', ENGLISH=N'Equipment group',CHINESE=N'Equipment group', VIETNAM_OR=N'Nhóm máy ', ENGLISH_OR=N'Equipment group' , CHINESE_OR=N'Equipment group' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblNMay' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblNMay',N'Nhóm máy ',N'Equipment group',N'Equipment group',N'Nhóm máy ',N'Equipment group',N'Equipment group','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblHienTrangSD') UPDATE LANGUAGES SET VIETNAM=N'Tình trạng SD', ENGLISH=N'Status',CHINESE=N'Status', VIETNAM_OR=N'Tình trạng SD', ENGLISH_OR=N'Status' , CHINESE_OR=N'Status' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblHienTrangSD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblHienTrangSD',N'Tình trạng SD',N'Status',N'Status',N'Tình trạng SD',N'Status',N'Status','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblBaoHanh') UPDATE LANGUAGES SET VIETNAM=N'Bảo hành', ENGLISH=N'Warantty',CHINESE=N'Warantty', VIETNAM_OR=N'Bảo hành', ENGLISH_OR=N'Warantty' , CHINESE_OR=N'Warantty' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblBaoHanh' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblBaoHanh',N'Bảo hành',N'Warantty',N'Warantty',N'Bảo hành',N'Warantty',N'Warantty','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblKhauHao') UPDATE LANGUAGES SET VIETNAM=N'Khấu hao', ENGLISH=N'Depreciation',CHINESE=N'Depreciation', VIETNAM_OR=N'Khấu hao', ENGLISH_OR=N'Depreciation' , CHINESE_OR=N'Depreciation' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblKhauHao' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblKhauHao',N'Khấu hao',N'Depreciation',N'Depreciation',N'Khấu hao',N'Depreciation',N'Depreciation','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblDamBaoAT') UPDATE LANGUAGES SET VIETNAM=N'Đảm bảo AT', ENGLISH=N'Safety related',CHINESE=N'Safety related', VIETNAM_OR=N'Đảm bảo AT', ENGLISH_OR=N'Safety related' , CHINESE_OR=N'Safety related' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblDamBaoAT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblDamBaoAT',N'Đảm bảo AT',N'Safety related',N'Safety related',N'Đảm bảo AT',N'Safety related',N'Safety related','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblGroup1') UPDATE LANGUAGES SET VIETNAM=N'Nhóm cấp 1', ENGLISH=N'Group 1',CHINESE=N'Group 1', VIETNAM_OR=N'Nhóm cấp 1', ENGLISH_OR=N'Group 1' , CHINESE_OR=N'Group 1' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblGroup1' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblGroup1',N'Nhóm cấp 1',N'Group 1',N'Group 1',N'Nhóm cấp 1',N'Group 1',N'Group 1','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblGroup2') UPDATE LANGUAGES SET VIETNAM=N'Nhóm cấp 2', ENGLISH=N'Group 2',CHINESE=N'Group 2', VIETNAM_OR=N'Nhóm cấp 2', ENGLISH_OR=N'Group 2' , CHINESE_OR=N'Group 2' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblGroup2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblGroup2',N'Nhóm cấp 2',N'Group 2',N'Group 2',N'Nhóm cấp 2',N'Group 2',N'Group 2','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'lblGroup3') UPDATE LANGUAGES SET VIETNAM=N'Nhóm cấp 3', ENGLISH=N'Group 3',CHINESE=N'Group 3', VIETNAM_OR=N'Nhóm cấp 3', ENGLISH_OR=N'Group 3' , CHINESE_OR=N'Group 3' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'lblGroup3' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'lblGroup3',N'Nhóm cấp 3',N'Group 3',N'Group 3',N'Nhóm cấp 3',N'Group 3',N'Group 3','ECOMAIN')
