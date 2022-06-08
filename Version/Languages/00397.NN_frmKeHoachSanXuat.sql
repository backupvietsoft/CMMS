﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD =N'GIO_KH') UPDATE LANGUAGES SET VIETNAM=N'Giá trị', ENGLISH=N'Value',CHINESE=N'Value', VIETNAM_OR=N'Giá trị', ENGLISH_OR=N'Value' , CHINESE_OR=N'Value' WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD=N'GIO_KH' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmKeHoachSanXuat',N'GIO_KH',N'Giá trị',N'Value',N'Value',N'Giá trị',N'Value',N'Value','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD =N'lblLoai') UPDATE LANGUAGES SET VIETNAM=N'Loại', ENGLISH=N'Species',CHINESE=N'Species', VIETNAM_OR=N'Loại', ENGLISH_OR=N'Species' , CHINESE_OR=N'Species' WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD=N'lblLoai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmKeHoachSanXuat',N'lblLoai',N'Loại',N'Species',N'Species',N'Loại',N'Species',N'Species','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD =N'Nhom') UPDATE LANGUAGES SET VIETNAM=N'Nhóm', ENGLISH=N'Group',CHINESE=N'Group', VIETNAM_OR=N'Nhóm', ENGLISH_OR=N'Group' , CHINESE_OR=N'Group' WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD=N'Nhom' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmKeHoachSanXuat',N'Nhom',N'Nhóm',N'Group',N'Group',N'Nhóm',N'Group',N'Group','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD =N'nhomDC') UPDATE LANGUAGES SET VIETNAM=N'Nhóm dây chuyền', ENGLISH=N'Group line',CHINESE=N'Group line', VIETNAM_OR=N'Nhóm dây chuyền', ENGLISH_OR=N'Group line' , CHINESE_OR=N'Group line' WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD=N'nhomDC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmKeHoachSanXuat',N'nhomDC',N'Nhóm dây chuyền',N'Group line',N'Group line',N'Nhóm dây chuyền',N'Group line',N'Group line','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD =N'HeThong') UPDATE LANGUAGES SET VIETNAM=N'Hệ Thống', ENGLISH=N'Line',CHINESE=N'Line', VIETNAM_OR=N'Hệ Thống', ENGLISH_OR=N'Line' , CHINESE_OR=N'Line' WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD=N'HeThong' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmKeHoachSanXuat',N'HeThong',N'Hệ Thống',N'Line',N'Line',N'Hệ Thống',N'Line',N'Line','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD =N'msgDuLieuThemDaTonTai') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu bạn thêm đã tồn tại, bạn có muốn ghi đè chúng ?', ENGLISH=N'The data you added already exists, do you want to overwrite them ?',CHINESE=N'The data you added already exists, do you want to overwrite them ?', VIETNAM_OR=N'Dữ liệu bạn thêm đã tồn tại, bạn có muốn ghi đè chúng ?', ENGLISH_OR=N'The data you added already exists, do you want to overwrite them ?' , CHINESE_OR=N'The data you added already exists, do you want to overwrite them ?' WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD=N'msgDuLieuThemDaTonTai' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmKeHoachSanXuat',N'msgDuLieuThemDaTonTai',N'Dữ liệu bạn thêm đã tồn tại, bạn có muốn ghi đè chúng ?',N'The data you added already exists, do you want to overwrite them ?',N'The data you added already exists, do you want to overwrite them ?',N'Dữ liệu bạn thêm đã tồn tại, bạn có muốn ghi đè chúng ?',N'The data you added already exists, do you want to overwrite them ?',N'The data you added already exists, do you want to overwrite them ?','ECOMAIN')


IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD =N'TEN_NHOM') UPDATE LANGUAGES SET VIETNAM=N'Nhóm', ENGLISH=N'Group',CHINESE=N'Group', VIETNAM_OR=N'Nhóm', ENGLISH_OR=N'Group' , CHINESE_OR=N'Group' WHERE FORM=N'frmKeHoachSanXuat' AND KEYWORD=N'TEN_NHOM' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmKeHoachSanXuat',N'TEN_NHOM',N'Nhóm',N'Group',N'Group',N'Nhóm',N'Group',N'Group','ECOMAIN')

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmBCYeuCauNSD' AND KEYWORD =N'MsgNullGiaTri') UPDATE LANGUAGES SET VIETNAM=N'Giá trị không được để trống!', ENGLISH=N'Value can not be null. Please input!',CHINESE=N'Value can not be null. Please input!', VIETNAM_OR=N'Giá trị không được để trống!', ENGLISH_OR=N'Value can not be null. Please input!' , CHINESE_OR=N'Value can not be null. Please input!' WHERE FORM=N'frmBCYeuCauNSD' AND KEYWORD=N'MsgNullGiaTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmBCYeuCauNSD',N'MsgNullGiaTri',N'Giá trị không được để trống!',N'Value can not be null. Please input!',N'Value can not be null. Please input!',N'Giá trị không được để trống!',N'Value can not be null. Please input!',N'Value can not be null. Please input!','ECOMAIN')




