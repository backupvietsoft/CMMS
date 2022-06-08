IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD =N'msgChonDonVi') UPDATE LANGUAGES SET VIETNAM=N'Chọn đơn vị', ENGLISH=N'Select unit', VIETNAM_OR=N'Chọn đơn vị', ENGLISH_OR=N'Select unit' WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD=N'msgChonDonVi' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBCThoiGianCVNhanVien',N'msgChonDonVi',N'Chọn đơn vị',N'Select unit',N'Chọn đơn vị',N'Select unit')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD =N'msgChonPhongBan') UPDATE LANGUAGES SET VIETNAM=N'Chọn phòng ban', ENGLISH=N'Select department', VIETNAM_OR=N'Chọn phòng ban', ENGLISH_OR=N'Select department' WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD=N'msgChonPhongBan' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBCThoiGianCVNhanVien',N'msgChonPhongBan',N'Chọn phòng ban',N'Select department',N'Chọn phòng ban',N'Select department')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD =N'ucBCThoiGianCVNhanVienTieuDe') UPDATE LANGUAGES SET VIETNAM=N'TỔNG HỢP CÔNG NHÂN VIÊN', ENGLISH=N'Total Hours Worked By Employees', VIETNAM_OR=N'TỔNG HỢP CÔNG NHÂN VIÊN', ENGLISH_OR=N'Total Hours Worked By Employees' WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD=N'ucBCThoiGianCVNhanVienTieuDe' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBCThoiGianCVNhanVien',N'ucBCThoiGianCVNhanVienTieuDe',N'TỔNG HỢP CÔNG NHÂN VIÊN',N'Total Hours Worked By Employees',N'TỔNG HỢP CÔNG NHÂN VIÊN',N'Total Hours Worked By Employees')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD =N'GSTT') UPDATE LANGUAGES SET VIETNAM=N'Giám sát tình trạng', ENGLISH=N'CM parameter', VIETNAM_OR=N'Giám sát tình trạng', ENGLISH_OR=N'CM parameter' WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD=N'GSTT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBCThoiGianCVNhanVien',N'GSTT',N'Giám sát tình trạng',N'CM parameter',N'Giám sát tình trạng',N'CM parameter')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD =N'CVVP') UPDATE LANGUAGES SET VIETNAM=N'Công việc văn phòng', ENGLISH=N'Office work', VIETNAM_OR=N'Công việc văn phòng', ENGLISH_OR=N'Office work' WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD=N'CVVP' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBCThoiGianCVNhanVien',N'CVVP',N'Công việc văn phòng',N'Office work',N'Công việc văn phòng',N'Office work')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD =N'TONG_CONG') UPDATE LANGUAGES SET VIETNAM=N'Tổng thời gian', ENGLISH=N'Total time', VIETNAM_OR=N'Tổng thời gian', ENGLISH_OR=N'Total time' WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD=N'TONG_CONG' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBCThoiGianCVNhanVien',N'TONG_CONG',N'Tổng thời gian',N'Total time',N'Tổng thời gian',N'Total time')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD =N'PBT') UPDATE LANGUAGES SET VIETNAM=N'Phiếu bảo trì', ENGLISH=N'Work order', VIETNAM_OR=N'Phiếu bảo trì', ENGLISH_OR=N'Work order' WHERE FORM=N'ucBCThoiGianCVNhanVien' AND KEYWORD=N'PBT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'ucBCThoiGianCVNhanVien',N'PBT',N'Phiếu bảo trì',N'Work order',N'Phiếu bảo trì',N'Work order')
