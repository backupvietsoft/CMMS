﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MS_HT_BT' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'MS hình thức BT', ENGLISH=N'Maint form ID', VIETNAM_OR=N'MS hình thức BT', ENGLISH_OR=N'Maint form ID' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MS_HT_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'MS_HT_BT',N'MS hình thức BT',N'Maint form ID',N'MS hình thức BT',N'Maint form ID','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'TEN_HT_BT' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Hình thức bảo trì', ENGLISH=N'Maintenance form', VIETNAM_OR=N'Hình thức bảo trì', ENGLISH_OR=N'Maintenance form' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'TEN_HT_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'TEN_HT_BT',N'Hình thức bảo trì',N'Maintenance form',N'Hình thức bảo trì',N'Maintenance form','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'PHONG_NGUA' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Định kỳ', ENGLISH=N'Periodic', VIETNAM_OR=N'Định kỳ', ENGLISH_OR=N'Periodic' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'PHONG_NGUA' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'PHONG_NGUA',N'Định kỳ',N'Periodic',N'Định kỳ',N'Periodic','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btnColor' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Chọn màu', ENGLISH=N'Select color', VIETNAM_OR=N'Chọn màu', ENGLISH_OR=N'Select color' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btnColor' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'btnColor',N'Chọn màu',N'Select color',N'Chọn màu',N'Select color','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btnGhi' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btnGhi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'btnGhi',N'&Lưu',N'&Save',N'&Lưu',N'&Save','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btnThoat' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btnThemSua' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Thêm/Sửa', ENGLISH=N'Add/Edit', VIETNAM_OR=N'Thêm/Sửa', ENGLISH_OR=N'Add/Edit' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btnThemSua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'btnThemSua',N'Thêm/Sửa',N'Add/Edit',N'Thêm/Sửa',N'Add/Edit','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btnKhongghi' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btnKhongghi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'btnKhongghi',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btnTroVe' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'T&rở về', ENGLISH=N'&Return', VIETNAM_OR=N'T&rở về', ENGLISH_OR=N'&Return' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btnTroVe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'btnTroVe',N'T&rở về',N'&Return',N'T&rở về',N'&Return','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'btnXoa' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'btnXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'btnXoa',N'Xóa',N'Delete',N'Xóa',N'Delete','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'TEN_LOAI_BT' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Tên loại bảo trì', ENGLISH=N'Maintenance type', VIETNAM_OR=N'Tên loại bảo trì', ENGLISH_OR=N'Maintenance type' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'TEN_LOAI_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'TEN_LOAI_BT',N'Tên loại bảo trì',N'Maintenance type',N'Tên loại bảo trì',N'Maintenance type','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'THU_TU' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Thứ tự', ENGLISH=N'Ordinal', VIETNAM_OR=N'Thứ tự', ENGLISH_OR=N'Ordinal' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'THU_TU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'THU_TU',N'Thứ tự',N'Ordinal',N'Thứ tự',N'Ordinal','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'HU_HONG' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Hư hỏng', ENGLISH=N'Failure', VIETNAM_OR=N'Hư hỏng', ENGLISH_OR=N'Failure' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'HU_HONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'HU_HONG',N'Hư hỏng',N'Failure',N'Hư hỏng',N'Failure','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MS_LOAI_CV' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Mã loại công việc', ENGLISH=N'Work type', VIETNAM_OR=N'Mã loại công việc', ENGLISH_OR=N'Work type' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MS_LOAI_CV' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'MS_LOAI_CV',N'Mã loại công việc',N'Work type',N'Mã loại công việc',N'Work type','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'GHI_CHU' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'GHI CHÚ', ENGLISH=N'REMARK', VIETNAM_OR=N'GHI CHÚ', ENGLISH_OR=N'REMARK' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'GHI_CHU',N'GHI CHÚ',N'REMARK',N'GHI CHÚ',N'REMARK','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MS_LOAI_BT' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'MS Loại BT', ENGLISH=N'Maint type ID', VIETNAM_OR=N'MS Loại BT', ENGLISH_OR=N'Maint type ID' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MS_LOAI_BT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'MS_LOAI_BT',N'MS Loại BT',N'Maint type ID',N'MS Loại BT',N'Maint type ID','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MAU' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Màu', ENGLISH=N'Color', VIETNAM_OR=N'Màu', ENGLISH_OR=N'Color' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MAU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'MAU',N'Màu',N'Color',N'Màu',N'Color','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnXoaLoai' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Xóa &loại', ENGLISH=N'&Delete type', VIETNAM_OR=N'Xóa &loại', ENGLISH_OR=N'&Delete type' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnXoaLoai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'BtnXoaLoai',N'Xóa &loại',N'&Delete type',N'Xóa &loại',N'&Delete type','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'BtnXoaNhomBT' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Xóa &HThức', ENGLISH=N'&Delete form', VIETNAM_OR=N'Xóa &HThức', ENGLISH_OR=N'&Delete form' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'BtnXoaNhomBT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'BtnXoaNhomBT',N'Xóa &HThức',N'&Delete form',N'Xóa &HThức',N'&Delete form','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'msgLoaiBaoTriDangSuDungKhongTheXoa' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong loại bảo trì!', ENGLISH=N'This data cannot be deleted because it is being used in list of maintenance type!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong loại bảo trì!', ENGLISH_OR=N'This data cannot be deleted because it is being used in list of maintenance type!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'msgLoaiBaoTriDangSuDungKhongTheXoa' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'msgLoaiBaoTriDangSuDungKhongTheXoa',N'Dữ liệu đang sử dụng trong loại bảo trì!',N'This data cannot be deleted because it is being used in list of maintenance type!',N'Dữ liệu đang sử dụng trong loại bảo trì!',N'This data cannot be deleted because it is being used in list of maintenance type!','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'msgXoaDSDCachThucHien' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong cách thực hiện!', ENGLISH=N'This data cannot be deleted because it is being used in method!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong cách thực hiện!', ENGLISH_OR=N'This data cannot be deleted because it is being used in method!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'msgXoaDSDCachThucHien' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'msgXoaDSDCachThucHien',N'Dữ liệu đang sử dụng trong cách thực hiện!',N'This data cannot be deleted because it is being used in method!',N'Dữ liệu đang sử dụng trong cách thực hiện!',N'This data cannot be deleted because it is being used in method!','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'msgXoaDSDPhieuBaoTri' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong phiếu bảo trì!', ENGLISH=N'This data cannot be deleted because it is being used in work order!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong phiếu bảo trì!', ENGLISH_OR=N'This data cannot be deleted because it is being used in work order!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'msgXoaDSDPhieuBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'msgXoaDSDPhieuBaoTri',N'Dữ liệu đang sử dụng trong phiếu bảo trì!',N'This data cannot be deleted because it is being used in work order!',N'Dữ liệu đang sử dụng trong phiếu bảo trì!',N'This data cannot be deleted because it is being used in work order!','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'msgXoaDSDMayLoaiBaoTriPhongNgua' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong bảo trì phòng ngừa!', ENGLISH=N'This data cannot be deleted because it is being used in preventive maintenance!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong bảo trì phòng ngừa!', ENGLISH_OR=N'This data cannot be deleted because it is being used in preventive maintenance!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'msgXoaDSDMayLoaiBaoTriPhongNgua' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'msgXoaDSDMayLoaiBaoTriPhongNgua',N'Dữ liệu đang sử dụng trong bảo trì phòng ngừa!',N'This data cannot be deleted because it is being used in preventive maintenance!',N'Dữ liệu đang sử dụng trong bảo trì phòng ngừa!',N'This data cannot be deleted because it is being used in preventive maintenance!','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'msgXoaDSDKeHoachTongThe' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong kế hoạch tổng thể!', ENGLISH=N'This data cannot be deleted because it is being used in master plan!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong kế hoạch tổng thể!', ENGLISH_OR=N'This data cannot be deleted because it is being used in master plan!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'msgXoaDSDKeHoachTongThe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'msgXoaDSDKeHoachTongThe',N'Dữ liệu đang sử dụng trong kế hoạch tổng thể!',N'This data cannot be deleted because it is being used in master plan!',N'Dữ liệu đang sử dụng trong kế hoạch tổng thể!',N'This data cannot be deleted because it is being used in master plan!','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'msgXoaDSDLoaiBaoTriQuanHe' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu đang sử dụng trong loại bảo trì quan hệ!', ENGLISH=N'This data cannot be deleted because it is being used in relation between maintenance type!', VIETNAM_OR=N'Dữ liệu đang sử dụng trong loại bảo trì quan hệ!', ENGLISH_OR=N'This data cannot be deleted because it is being used in relation between maintenance type!' WHERE FORM=N'frmBaoTri' AND KEYWORD=N'msgXoaDSDLoaiBaoTriQuanHe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR,MS_MODULE) VALUES(N'frmBaoTri',N'msgXoaDSDLoaiBaoTriQuanHe',N'Dữ liệu đang sử dụng trong loại bảo trì quan hệ!',N'This data cannot be deleted because it is being used in relation between maintenance type!',N'Dữ liệu đang sử dụng trong loại bảo trì quan hệ!',N'This data cannot be deleted because it is being used in relation between maintenance type!','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmLoaiBTQH' AND KEYWORD =N'MS_LOAI_BT_CD' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Loại bảo trì cấp dưới', ENGLISH=N'Child maintenance type' , CHINESE=N'Child maintenance type' , VIETNAM_OR=N'Loại bảo trì cấp dưới' , ENGLISH_OR=N'Child maintenance type'  , CHINESE_OR=N'Child maintenance type'  WHERE FORM=N'FrmLoaiBTQH' AND KEYWORD=N'MS_LOAI_BT_CD' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE) VALUES(N'FrmLoaiBTQH',N'MS_LOAI_BT_CD',N'Loại bảo trì cấp dưới',N'Child maintenance type',N'Child maintenance type',N'Loại bảo trì cấp dưới',N'Child maintenance type',N'Child maintenance type','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBaoCaoTongHopPBT' AND KEYWORD =N'GSTT' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'GSTT', ENGLISH=N'GSTT' , CHINESE=N'GSTT' , VIETNAM_OR=N'GSTT' , ENGLISH_OR=N'GSTT'  , CHINESE_OR=N'GSTT'  WHERE FORM=N'ucBaoCaoTongHopPBT' AND KEYWORD=N'GSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE) VALUES(N'ucBaoCaoTongHopPBT',N'GSTT',N'GSTT',N'GSTT',N'GSTT',N'GSTT',N'GSTT',N'GSTT','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'MsgXoa2' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa loại bảo trì này không?', ENGLISH=N'Do you want to delete this maintenance type?' , CHINESE=N'Do you want to delete this maintenance type?' , VIETNAM_OR=N'Bạn có muốn xóa loại bảo trì này không?' , ENGLISH_OR=N'Do you want to delete this maintenance type?'  , CHINESE_OR=N'Do you want to delete this maintenance type?'  WHERE FORM=N'frmBaoTri' AND KEYWORD=N'MsgXoa2' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE) VALUES(N'frmBaoTri',N'MsgXoa2',N'Bạn có muốn xóa loại bảo trì này không?',N'Do you want to delete this maintenance type?',N'Do you want to delete this maintenance type?',N'Bạn có muốn xóa loại bảo trì này không?',N'Do you want to delete this maintenance type?',N'Do you want to delete this maintenance type?','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBaoTri' AND KEYWORD =N'GHI_CHU' AND MS_MODULE = 'ECOMAIN') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note' , CHINESE=N'Note' , VIETNAM_OR=N'Ghi chú' , ENGLISH_OR=N'Note'  , CHINESE_OR=N'Note'  WHERE FORM=N'frmBaoTri' AND KEYWORD=N'GHI_CHU' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE) VALUES(N'frmBaoTri',N'GHI_CHU',N'Ghi chú',N'Note',N'Note',N'Ghi chú',N'Note',N'Note','ECOMAIN')