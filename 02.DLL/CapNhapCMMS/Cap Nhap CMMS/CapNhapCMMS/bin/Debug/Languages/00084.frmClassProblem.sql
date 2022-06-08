﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnAdd') UPDATE LANGUAGES SET VIETNAM=N'Thêm', ENGLISH=N'Add', VIETNAM_OR=N'Thêm', ENGLISH_OR=N'Add' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnAdd' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnAdd',N'Thêm',N'Add',N'Thêm',N'Add')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnCancel') UPDATE LANGUAGES SET VIETNAM=N'&Không lưu', ENGLISH=N'&Cancel', VIETNAM_OR=N'&Không lưu', ENGLISH_OR=N'&Cancel' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnCancel' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnCancel',N'&Không lưu',N'&Cancel',N'&Không lưu',N'&Cancel')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnChoice') UPDATE LANGUAGES SET VIETNAM=N'Chọn', ENGLISH=N'Check', VIETNAM_OR=N'Chọn', ENGLISH_OR=N'Check' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnChoice' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnChoice',N'Chọn',N'Check',N'Chọn',N'Check')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnDelete') UPDATE LANGUAGES SET VIETNAM=N'Xóa', ENGLISH=N'Delete', VIETNAM_OR=N'Xóa', ENGLISH_OR=N'Delete' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnDelete' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnDelete',N'Xóa',N'Delete',N'Xóa',N'Delete')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnEdit') UPDATE LANGUAGES SET VIETNAM=N'Sửa', ENGLISH=N'Edit', VIETNAM_OR=N'Sửa', ENGLISH_OR=N'Edit' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnEdit' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnEdit',N'Sửa',N'Edit',N'Sửa',N'Edit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnExit') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnExit' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnExit',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnSave') UPDATE LANGUAGES SET VIETNAM=N'&Lưu', ENGLISH=N'&Save', VIETNAM_OR=N'&Lưu', ENGLISH_OR=N'&Save' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnSave' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnSave',N'&Lưu',N'&Save',N'&Lưu',N'&Save')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'btnThoat') UPDATE LANGUAGES SET VIETNAM=N'Thoát', ENGLISH=N'Exit', VIETNAM_OR=N'Thoát', ENGLISH_OR=N'Exit' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'btnThoat' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'btnThoat',N'Thoát',N'Exit',N'Thoát',N'Exit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'CAUSE_CODE') UPDATE LANGUAGES SET VIETNAM=N'Mã nguyên nhân', ENGLISH=N'Cause code', VIETNAM_OR=N'Mã nguyên nhân', ENGLISH_OR=N'Cause code' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'CAUSE_CODE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'CAUSE_CODE',N'Mã nguyên nhân',N'Cause code',N'Mã nguyên nhân',N'Cause code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'CAUSE_ID') UPDATE LANGUAGES SET VIETNAM=N'Mã nguyên nhân', ENGLISH=N'Cause ID', VIETNAM_OR=N'Mã nguyên nhân', ENGLISH_OR=N'Cause ID' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'CAUSE_ID' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'CAUSE_ID',N'Mã nguyên nhân',N'Cause ID',N'Mã nguyên nhân',N'Cause ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'CAUSE_NAME') UPDATE LANGUAGES SET VIETNAM=N'Nguyên nhân', ENGLISH=N'Cause', VIETNAM_OR=N'Nguyên nhân', ENGLISH_OR=N'Cause' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'CAUSE_NAME' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'CAUSE_NAME',N'Nguyên nhân',N'Cause',N'Nguyên nhân',N'Cause')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'CLASS_CODE') UPDATE LANGUAGES SET VIETNAM=N'Mã Class', ENGLISH=N'Class code', VIETNAM_OR=N'Mã Class', ENGLISH_OR=N'Class code' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'CLASS_CODE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'CLASS_CODE',N'Mã Class',N'Class code',N'Mã Class',N'Class code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'CLASS_ID') UPDATE LANGUAGES SET VIETNAM=N'Mã loại hư hỏng', ENGLISH=N'Class ID', VIETNAM_OR=N'Mã loại hư hỏng', ENGLISH_OR=N'Class ID' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'CLASS_ID' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'CLASS_ID',N'Mã loại hư hỏng',N'Class ID',N'Mã loại hư hỏng',N'Class ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'CLASS_NAME') UPDATE LANGUAGES SET VIETNAM=N'Tên Class', ENGLISH=N'Class', VIETNAM_OR=N'Tên Class', ENGLISH_OR=N'Class' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'CLASS_NAME' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'CLASS_NAME',N'Tên Class',N'Class',N'Tên Class',N'Class')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'CLASS_NOTE') UPDATE LANGUAGES SET VIETNAM=N'CLASS_NOTE', ENGLISH=N'CLASS_NOTE', VIETNAM_OR=N'CLASS_NOTE', ENGLISH_OR=N'CLASS_NOTE' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'CLASS_NOTE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'CLASS_NOTE',N'CLASS_NOTE',N'CLASS_NOTE',N'CLASS_NOTE',N'CLASS_NOTE')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'frmClassProblem') UPDATE LANGUAGES SET VIETNAM=N'Class hư hỏng', ENGLISH=N'Class list', VIETNAM_OR=N'Class hư hỏng', ENGLISH_OR=N'Class list' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'frmClassProblem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'frmClassProblem',N'Class hư hỏng',N'Class list',N'Class hư hỏng',N'Class list')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'labClassCode') UPDATE LANGUAGES SET VIETNAM=N'Mã Class', ENGLISH=N'Class code', VIETNAM_OR=N'Mã Class', ENGLISH_OR=N'Class code' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'labClassCode' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'labClassCode',N'Mã Class',N'Class code',N'Mã Class',N'Class code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'labClassName') UPDATE LANGUAGES SET VIETNAM=N'Tên Class', ENGLISH=N'Class', VIETNAM_OR=N'Tên Class', ENGLISH_OR=N'Class' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'labClassName' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'labClassName',N'Tên Class',N'Class',N'Tên Class',N'Class')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'labClassNote') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'labClassNote' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'labClassNote',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'labTitle') UPDATE LANGUAGES SET VIETNAM=N'Class hư hỏng', ENGLISH=N'Class list', VIETNAM_OR=N'Class hư hỏng', ENGLISH_OR=N'Class list' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'labTitle' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'labTitle',N'Class hư hỏng',N'Class list',N'Class hư hỏng',N'Class list')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgAskBeforeDeleteClass') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa Class hư hỏng này không?', ENGLISH=N'Do you want to delete this Class?', VIETNAM_OR=N'Bạn có muốn xóa Class hư hỏng này không?', ENGLISH_OR=N'Do you want to delete this Class?' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgAskBeforeDeleteClass' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgAskBeforeDeleteClass',N'Bạn có muốn xóa Class hư hỏng này không?',N'Do you want to delete this Class?',N'Bạn có muốn xóa Class hư hỏng này không?',N'Do you want to delete this Class?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgAskDeleteProblem') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn xóa hư hỏng này không?', ENGLISH=N'Do you want to delete this problem?', VIETNAM_OR=N'Bạn có muốn xóa hư hỏng này không?', ENGLISH_OR=N'Do you want to delete this problem?' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgAskDeleteProblem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgAskDeleteProblem',N'Bạn có muốn xóa hư hỏng này không?',N'Do you want to delete this problem?',N'Bạn có muốn xóa hư hỏng này không?',N'Do you want to delete this problem?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgClassCodeIsExist') UPDATE LANGUAGES SET VIETNAM=N'Nhập trùng mã Class hư hỏng, vui lòng nhập lại!', ENGLISH=N'Class code already exists. Please check again!', VIETNAM_OR=N'Nhập trùng mã Class hư hỏng, vui lòng nhập lại!', ENGLISH_OR=N'Class code already exists. Please check again!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgClassCodeIsExist' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgClassCodeIsExist',N'Nhập trùng mã Class hư hỏng, vui lòng nhập lại!',N'Class code already exists. Please check again!',N'Nhập trùng mã Class hư hỏng, vui lòng nhập lại!',N'Class code already exists. Please check again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgClassExistInPBTC') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!', ENGLISH=N'This data already exists in Work order. Please check again!', VIETNAM_OR=N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!', ENGLISH_OR=N'This data already exists in Work order. Please check again!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgClassExistInPBTC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgClassExistInPBTC',N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!',N'This data already exists in Work order. Please check again!',N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!',N'This data already exists in Work order. Please check again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgErrorDeleteClass') UPDATE LANGUAGES SET VIETNAM=N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!', ENGLISH=N'Cannot delete this data. Please check again!', VIETNAM_OR=N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!', ENGLISH_OR=N'Cannot delete this data. Please check again!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgErrorDeleteClass' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgErrorDeleteClass',N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!',N'Cannot delete this data. Please check again!',N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!',N'Cannot delete this data. Please check again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgErrorDeleteProblem') UPDATE LANGUAGES SET VIETNAM=N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!', ENGLISH=N'Cannot delete this data. Please check again!', VIETNAM_OR=N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!', ENGLISH_OR=N'Cannot delete this data. Please check again!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgErrorDeleteProblem' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgErrorDeleteProblem',N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!',N'Cannot delete this data. Please check again!',N'Xóa dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu đã phát sinh!',N'Cannot delete this data. Please check again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgErrorUpdateClass') UPDATE LANGUAGES SET VIETNAM=N'Cập nhật dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu!', ENGLISH=N'Cannot update this data. Please check again!', VIETNAM_OR=N'Cập nhật dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu!', ENGLISH_OR=N'Cannot update this data. Please check again!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgErrorUpdateClass' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgErrorUpdateClass',N'Cập nhật dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu!',N'Cannot update this data. Please check again!',N'Cập nhật dữ liệu không thành công, vui lòng kiểm tra lại dữ liệu!',N'Cannot update this data. Please check again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgInputClassCode') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập mã class hư hỏng!', ENGLISH=N'Please enter Class code!', VIETNAM_OR=N'Vui lòng nhập mã class hư hỏng!', ENGLISH_OR=N'Please enter Class code!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgInputClassCode' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgInputClassCode',N'Vui lòng nhập mã class hư hỏng!',N'Please enter Class code!',N'Vui lòng nhập mã class hư hỏng!',N'Please enter Class code!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgInputClassName') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập tên class hư hỏng!', ENGLISH=N'Please enter Class name!', VIETNAM_OR=N'Vui lòng nhập tên class hư hỏng!', ENGLISH_OR=N'Please enter Class name!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgInputClassName' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgInputClassName',N'Vui lòng nhập tên class hư hỏng!',N'Please enter Class name!',N'Vui lòng nhập tên class hư hỏng!',N'Please enter Class name!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'MsgProblemExistInPBTC') UPDATE LANGUAGES SET VIETNAM=N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!', ENGLISH=N'This data is already exist in Work order, please check data again!', VIETNAM_OR=N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!', ENGLISH_OR=N'This data is already exist in Work order, please check data again!' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'MsgProblemExistInPBTC' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'MsgProblemExistInPBTC',N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!',N'This data is already exist in Work order, please check data again!',N'Dữ liệu này đã tồn tại trong phiếu bảo trì, vui lòng kiểm tra lại!',N'This data is already exist in Work order, please check data again!')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'NOTE') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'NOTE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'NOTE',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'NOTES') UPDATE LANGUAGES SET VIETNAM=N'Ghi chú', ENGLISH=N'Note', VIETNAM_OR=N'Ghi chú', ENGLISH_OR=N'Note' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'NOTES' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'NOTES',N'Ghi chú',N'Note',N'Ghi chú',N'Note')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'PROBLEM_CODE') UPDATE LANGUAGES SET VIETNAM=N'Mã hư hỏng', ENGLISH=N'Failure code', VIETNAM_OR=N'Mã hư hỏng', ENGLISH_OR=N'Failure code' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'PROBLEM_CODE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'PROBLEM_CODE',N'Mã hư hỏng',N'Failure code',N'Mã hư hỏng',N'Failure code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'PROBLEM_ID') UPDATE LANGUAGES SET VIETNAM=N'Mã hư hỏng', ENGLISH=N'Failure ID', VIETNAM_OR=N'Mã hư hỏng', ENGLISH_OR=N'Failure ID' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'PROBLEM_ID' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'PROBLEM_ID',N'Mã hư hỏng',N'Failure ID',N'Mã hư hỏng',N'Failure ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'PROBLEM_NAME') UPDATE LANGUAGES SET VIETNAM=N'Hư hỏng', ENGLISH=N'Failure', VIETNAM_OR=N'Hư hỏng', ENGLISH_OR=N'Failure' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'PROBLEM_NAME' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'PROBLEM_NAME',N'Hư hỏng',N'Failure',N'Hư hỏng',N'Failure')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'REMEDY_CODE') UPDATE LANGUAGES SET VIETNAM=N'Mã phương pháp KP', ENGLISH=N'Remedy code', VIETNAM_OR=N'Mã phương pháp KP', ENGLISH_OR=N'Remedy code' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'REMEDY_CODE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'REMEDY_CODE',N'Mã phương pháp KP',N'Remedy code',N'Mã phương pháp KP',N'Remedy code')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'REMEDY_ID') UPDATE LANGUAGES SET VIETNAM=N'Mã phương pháp', ENGLISH=N'Remedy ID', VIETNAM_OR=N'Mã phương pháp', ENGLISH_OR=N'Remedy ID' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'REMEDY_ID' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'REMEDY_ID',N'Mã phương pháp',N'Remedy ID',N'Mã phương pháp',N'Remedy ID')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'REMEDY_NAME') UPDATE LANGUAGES SET VIETNAM=N'Phương pháp KP', ENGLISH=N'Remedy', VIETNAM_OR=N'Phương pháp KP', ENGLISH_OR=N'Remedy' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'REMEDY_NAME' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'REMEDY_NAME',N'Phương pháp KP',N'Remedy',N'Phương pháp KP',N'Remedy')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmClassProblem' AND KEYWORD =N'UU_TIEN') UPDATE LANGUAGES SET VIETNAM=N'Mức ưu tiên', ENGLISH=N'Priority', VIETNAM_OR=N'Mức ưu tiên', ENGLISH_OR=N'Priority' WHERE FORM=N'frmClassProblem' AND KEYWORD=N'UU_TIEN' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmClassProblem',N'UU_TIEN',N'Mức ưu tiên',N'Priority',N'Mức ưu tiên',N'Priority')
