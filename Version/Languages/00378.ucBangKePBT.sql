﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'TEN_CA') UPDATE LANGUAGES SET VIETNAM=N'Tên ca', ENGLISH=N'Shift name',CHINESE=N'Shift name', VIETNAM_OR=N'Tên ca', ENGLISH_OR=N'Shift name' , CHINESE_OR=N'Shift name' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'TEN_CA' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'TEN_CA',N'Tên ca',N'Shift name',N'Shift name',N'Tên ca',N'Shift name',N'Shift name','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'MS_NNT') UPDATE LANGUAGES SET VIETNAM=N'MSNV nghiệm thu', ENGLISH=N'ID Accepted by',CHINESE=N'ID Accepted by', VIETNAM_OR=N'MSNV nghiệm thu', ENGLISH_OR=N'ID Accepted by' , CHINESE_OR=N'ID Accepted by' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'MS_NNT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'MS_NNT',N'MSNV nghiệm thu',N'ID Accepted by',N'ID Accepted by',N'MSNV nghiệm thu',N'ID Accepted by',N'ID Accepted by','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'HO_TEN_NNT') UPDATE LANGUAGES SET VIETNAM=N'Người nghiệm thu', ENGLISH=N'Accepted by',CHINESE=N'Accepted by', VIETNAM_OR=N'Người nghiệm thu', ENGLISH_OR=N'Accepted by' , CHINESE_OR=N'Accepted by' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'HO_TEN_NNT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'HO_TEN_NNT',N'Người nghiệm thu',N'Accepted by',N'Accepted by',N'Người nghiệm thu',N'Accepted by',N'Accepted by','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'MS_NGS') UPDATE LANGUAGES SET VIETNAM=N'MSNV giám sát', ENGLISH=N'ID Supervisors',CHINESE=N'ID Supervisors', VIETNAM_OR=N'MSNV giám sát', ENGLISH_OR=N'ID Supervisors' , CHINESE_OR=N'ID Supervisors' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'MS_NGS' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'MS_NGS',N'MSNV giám sát',N'ID Supervisors',N'ID Supervisors',N'MSNV giám sát',N'ID Supervisors',N'ID Supervisors','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'HO_TEN_GS_VIEN') UPDATE LANGUAGES SET VIETNAM=N'Người giám sát', ENGLISH=N'Supervisors',CHINESE=N'Supervisors', VIETNAM_OR=N'Người giám sát', ENGLISH_OR=N'Supervisors' , CHINESE_OR=N'Supervisors' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'HO_TEN_GS_VIEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'HO_TEN_GS_VIEN',N'Người giám sát',N'Supervisors',N'Supervisors',N'Người giám sát',N'Supervisors',N'Supervisors','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'bcTieuDe') UPDATE LANGUAGES SET VIETNAM=N'BẢNG KÊ TẤT CẢ CÁC PHIẾU BẢO TRÌ, SỮA CHỮA', ENGLISH=N'LIST OF WORK ORDERS ',CHINESE=N'LIST OF WORK ORDERS ', VIETNAM_OR=N'BẢNG KÊ TẤT CẢ CÁC PHIẾU BẢO TRÌ, SỮA CHỮA', ENGLISH_OR=N'LIST OF WORK ORDERS ' , CHINESE_OR=N'LIST OF WORK ORDERS ' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'bcTieuDe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'bcTieuDe',N'BẢNG KÊ TẤT CẢ CÁC PHIẾU BẢO TRÌ, SỮA CHỮA',N'LIST OF WORK ORDERS ',N'LIST OF WORK ORDERS ',N'BẢNG KÊ TẤT CẢ CÁC PHIẾU BẢO TRÌ, SỮA CHỮA',N'LIST OF WORK ORDERS ',N'LIST OF WORK ORDERS ','ECOMAIN')


IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'NGUON_DL') UPDATE LANGUAGES SET VIETNAM=N'Công việc chính / Công việc phụ', ENGLISH=N'Main work / Supporting work',CHINESE=N'Main work / Supporting work', VIETNAM_OR=N'Công việc chính / Công việc phụ', ENGLISH_OR=N'Main work / Supporting work' , CHINESE_OR=N'Main work / Supporting work' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'NGUON_DL' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'NGUON_DL',N'Công việc chính / Công việc phụ',N'Main work / Supporting work',N'Main work / Supporting work',N'Công việc chính / Công việc phụ',N'Main work / Supporting work',N'Main work / Supporting work','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'MS_N_XUONG') UPDATE LANGUAGES SET VIETNAM=N'MS địa điểm', ENGLISH=N'Work site ID',CHINESE=N'Work site ID', VIETNAM_OR=N'MS địa điểm', ENGLISH_OR=N'Work site ID' , CHINESE_OR=N'Work site ID' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'MS_N_XUONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'MS_N_XUONG',N'MS địa điểm',N'Work site ID',N'Work site ID',N'MS địa điểm',N'Work site ID',N'Work site ID','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'Ten_N_XUONG') UPDATE LANGUAGES SET VIETNAM=N'Địa điểm', ENGLISH=N'Work site',CHINESE=N'Work site', VIETNAM_OR=N'Địa điểm', ENGLISH_OR=N'Work site' , CHINESE_OR=N'Work site' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'Ten_N_XUONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'Ten_N_XUONG',N'Địa điểm',N'Work site',N'Work site',N'Địa điểm',N'Work site',N'Work site','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'MS_BP_CHIU_PHI') UPDATE LANGUAGES SET VIETNAM=N'Mã BP chịu phí', ENGLISH=N'Cost center ID',CHINESE=N'Cost center ID', VIETNAM_OR=N'Mã BP chịu phí', ENGLISH_OR=N'Cost center ID' , CHINESE_OR=N'Cost center ID' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'MS_BP_CHIU_PHI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'MS_BP_CHIU_PHI',N'Mã BP chịu phí',N'Cost center ID',N'Cost center ID',N'Mã BP chịu phí',N'Cost center ID',N'Cost center ID','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'TEN_BP_CHIU_PHI') UPDATE LANGUAGES SET VIETNAM=N'Bộ phận chịu phí', ENGLISH=N'Cost Center',CHINESE=N'Cost Center', VIETNAM_OR=N'Bộ phận chịu phí', ENGLISH_OR=N'Cost Center' , CHINESE_OR=N'Cost Center' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'TEN_BP_CHIU_PHI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'TEN_BP_CHIU_PHI',N'Bộ phận chịu phí',N'Cost Center',N'Cost Center',N'Bộ phận chịu phí',N'Cost Center',N'Cost Center','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'TG_KH_CO_KH') UPDATE LANGUAGES SET VIETNAM=N'Thời gian cho CV có KH (Kế hoạch)', ENGLISH=N'Time of planned work (Planed)',CHINESE=N'Time of planned work (Planed)', VIETNAM_OR=N'Thời gian cho CV có KH (Kế hoạch)', ENGLISH_OR=N'Time of planned work (Planed)' , CHINESE_OR=N'Time of planned work (Planed)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'TG_KH_CO_KH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'TG_KH_CO_KH',N'Thời gian cho CV có KH (Kế hoạch)',N'Time of planned work (Planed)',N'Time of planned work (Planed)',N'Thời gian cho CV có KH (Kế hoạch)',N'Time of planned work (Planed)',N'Time of planned work (Planed)','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'TG_KH_KG_KH') UPDATE LANGUAGES SET VIETNAM=N'Thời gian cho CV không KH (Kế hoạch)', ENGLISH=N'Time of un-planned work (Planed)',CHINESE=N'Time of un-planned work (Planed)', VIETNAM_OR=N'Thời gian cho CV không KH (Kế hoạch)', ENGLISH_OR=N'Time of un-planned work (Planed)' , CHINESE_OR=N'Time of un-planned work (Planed)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'TG_KH_KG_KH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'TG_KH_KG_KH',N'Thời gian cho CV không KH (Kế hoạch)',N'Time of un-planned work (Planed)',N'Time of un-planned work (Planed)',N'Thời gian cho CV không KH (Kế hoạch)',N'Time of un-planned work (Planed)',N'Time of un-planned work (Planed)','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'NGAY_BD_KH') UPDATE LANGUAGES SET VIETNAM=N'Ngày bắt đầu (Kế hoạch)', ENGLISH=N'Start date (Planed)',CHINESE=N'Start date (Planed)', VIETNAM_OR=N'Ngày bắt đầu (Kế hoạch)', ENGLISH_OR=N'Start date (Planed)' , CHINESE_OR=N'Start date (Planed)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'NGAY_BD_KH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'NGAY_BD_KH',N'Ngày bắt đầu (Kế hoạch)',N'Start date (Planed)',N'Start date (Planed)',N'Ngày bắt đầu (Kế hoạch)',N'Start date (Planed)',N'Start date (Planed)','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'NGAY_KT_KH') UPDATE LANGUAGES SET VIETNAM=N'Ngày kết thúc (Kế hoạch)', ENGLISH=N'Completion date  (Planed)',CHINESE=N'Completion date  (Planed)', VIETNAM_OR=N'Ngày kết thúc (Kế hoạch)', ENGLISH_OR=N'Completion date  (Planed)' , CHINESE_OR=N'Completion date  (Planed)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'NGAY_KT_KH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'NGAY_KT_KH',N'Ngày kết thúc (Kế hoạch)',N'Completion date  (Planed)',N'Completion date  (Planed)',N'Ngày kết thúc (Kế hoạch)',N'Completion date  (Planed)',N'Completion date  (Planed)','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'TG_TT_CO_KH') UPDATE LANGUAGES SET VIETNAM=N'Thời gian cho CV có KH (Thực tế)', ENGLISH=N'Time of planned work (Actual)',CHINESE=N'Time of planned work (Actual)', VIETNAM_OR=N'Thời gian cho CV có KH (Thực tế)', ENGLISH_OR=N'Time of planned work (Actual)' , CHINESE_OR=N'Time of planned work (Actual)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'TG_TT_CO_KH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'TG_TT_CO_KH',N'Thời gian cho CV có KH (Thực tế)',N'Time of planned work (Actual)',N'Time of planned work (Actual)',N'Thời gian cho CV có KH (Thực tế)',N'Time of planned work (Actual)',N'Time of planned work (Actual)','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'TG_TT_KG_KH') UPDATE LANGUAGES SET VIETNAM=N'Thời gian cho CV không KH (Thực tế)', ENGLISH=N'Time of un-planned work (Actual)',CHINESE=N'Time of un-planned work (Actual)', VIETNAM_OR=N'Thời gian cho CV không KH (Thực tế)', ENGLISH_OR=N'Time of un-planned work (Actual)' , CHINESE_OR=N'Time of un-planned work (Actual)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'TG_TT_KG_KH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'TG_TT_KG_KH',N'Thời gian cho CV không KH (Thực tế)',N'Time of un-planned work (Actual)',N'Time of un-planned work (Actual)',N'Thời gian cho CV không KH (Thực tế)',N'Time of un-planned work (Actual)',N'Time of un-planned work (Actual)','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'NGAY_BD_TT') UPDATE LANGUAGES SET VIETNAM=N'Ngày bắt đầu (Thực tế)', ENGLISH=N'Start date (Actual)',CHINESE=N'Start date (Actual)', VIETNAM_OR=N'Ngày bắt đầu (Thực tế)', ENGLISH_OR=N'Start date (Actual)' , CHINESE_OR=N'Start date (Actual)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'NGAY_BD_TT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucBangKePBT',N'NGAY_BD_TT',N'Ngày bắt đầu (Thực tế)',N'Start date (Actual)',N'Start date (Actual)',N'Ngày bắt đầu (Thực tế)',N'Start date (Actual)',N'Start date (Actual)','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBangKePBT' AND KEYWORD =N'NGAY_KT_TT') UPDATE LANGUAGES SET VIETNAM=N'Ngày kết thúc (Thực tế)', ENGLISH=N'Completion date  (Actual)',CHINESE=N'Completion date  (Actual)', VIETNAM_OR=N'Ngày kết thúc (Thực tế)', ENGLISH_OR=N'Completion date  (Actual)' , CHINESE_OR=N'Completion date  (Actual)' WHERE FORM=N'ucBangKePBT' AND KEYWORD=N'NGAY_KT_TT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'',N'NGAY_KT_TT',N'Ngày kết thúc (Thực tế)',N'Completion date  (Actual)',N'Completion date  (Actual)',N'Ngày kết thúc (Thực tế)',N'Completion date  (Actual)',N'Completion date  (Actual)','ECOMAIN')


IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'MS_N_XUONG') UPDATE LANGUAGES SET VIETNAM=N'MS địa điểm', ENGLISH=N'Work site ID',CHINESE=N'Work site ID', VIETNAM_OR=N'MS địa điểm', ENGLISH_OR=N'Work site ID' , CHINESE_OR=N'Work site ID' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'MS_N_XUONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'MS_N_XUONG',N'MS địa điểm',N'Work site ID',N'Work site ID',N'MS địa điểm',N'Work site ID',N'Work site ID','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'Ten_N_XUONG') UPDATE LANGUAGES SET VIETNAM=N'Địa điểm', ENGLISH=N'Work site',CHINESE=N'Work site', VIETNAM_OR=N'Địa điểm', ENGLISH_OR=N'Work site' , CHINESE_OR=N'Work site' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'Ten_N_XUONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'Ten_N_XUONG',N'Địa điểm',N'Work site',N'Work site',N'Địa điểm',N'Work site',N'Work site','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'MS_BP_CHIU_PHI') UPDATE LANGUAGES SET VIETNAM=N'Mã BP chịu phí', ENGLISH=N'Cost center ID',CHINESE=N'Cost center ID', VIETNAM_OR=N'Mã BP chịu phí', ENGLISH_OR=N'Cost center ID' , CHINESE_OR=N'Cost center ID' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'MS_BP_CHIU_PHI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'MS_BP_CHIU_PHI',N'Mã BP chịu phí',N'Cost center ID',N'Cost center ID',N'Mã BP chịu phí',N'Cost center ID',N'Cost center ID','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD =N'TEN_BP_CHIU_PHI') UPDATE LANGUAGES SET VIETNAM=N'Bộ phận chịu phí', ENGLISH=N'Cost Center',CHINESE=N'Cost Center', VIETNAM_OR=N'Bộ phận chịu phí', ENGLISH_OR=N'Cost Center' , CHINESE_OR=N'Cost Center' WHERE FORM=N'ucDanhMucMayMocThietBi' AND KEYWORD=N'TEN_BP_CHIU_PHI' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'ucDanhMucMayMocThietBi',N'TEN_BP_CHIU_PHI',N'Bộ phận chịu phí',N'Cost Center',N'Cost Center',N'Bộ phận chịu phí',N'Cost Center',N'Cost Center','ECOMAIN')


IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD =N'MS_LOAI_PT') UPDATE LANGUAGES SET VIETNAM=N'MS ĐTSD', ENGLISH=N'Item User ID',CHINESE=N'Item User ID', VIETNAM_OR=N'MS ĐTSD', ENGLISH_OR=N'Item User ID' , CHINESE_OR=N'Item User ID' WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD=N'MS_LOAI_PT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'rptDanhsach_VTPT',N'MS_LOAI_PT',N'MS ĐTSD',N'Item User ID',N'Item User ID',N'MS ĐTSD',N'Item User ID',N'Item User ID','ECOMAIN')


IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD =N'optExcel') UPDATE LANGUAGES SET VIETNAM=N'Xuất excel', ENGLISH=N'Export excel',CHINESE=N'Export excel', VIETNAM_OR=N'Xuất excel', ENGLISH_OR=N'Export excel' , CHINESE_OR=N'Export excel' WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD=N'optExcel' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'rptDanhsach_VTPT',N'optExcel',N'Xuất excel',N'Export excel',N'Export excel',N'Xuất excel',N'Export excel',N'Export excel','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD =N'optReport') UPDATE LANGUAGES SET VIETNAM=N'In theo ĐTSD', ENGLISH=N'Print by user type ',CHINESE=N'Print by user type ', VIETNAM_OR=N'In theo ĐTSD', ENGLISH_OR=N'Print by user type ' , CHINESE_OR=N'Print by user type ' WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD=N'optReport' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'rptDanhsach_VTPT',N'optReport',N'In theo ĐTSD',N'Print by user type ',N'Print by user type ',N'In theo ĐTSD',N'Print by user type ',N'Print by user type ','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD =N'optAll') UPDATE LANGUAGES SET VIETNAM=N'In tất cả vật tư', ENGLISH=N'Print all item',CHINESE=N'Print all item', VIETNAM_OR=N'In tất cả vật tư', ENGLISH_OR=N'Print all item' , CHINESE_OR=N'Print all item' WHERE FORM=N'rptDanhsach_VTPT' AND KEYWORD=N'optAll' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'rptDanhsach_VTPT',N'optAll',N'In tất cả vật tư',N'Print all item',N'Print all item',N'In tất cả vật tư',N'Print all item',N'Print all item','ECOMAIN')
