IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhieuBaoTri_New' AND KEYWORD =N'MsgNhapNgayGioHongFull') UPDATE LANGUAGES SET VIETNAM=N'Vui lòng nhập đầy đủ thông tin từ ngày giờ/ đến ngày giờ hỏng hoặc để trống', ENGLISH=N'Please enter start/end time of breakdown, or leave blank', VIETNAM_OR=N'Vui lòng nhập đầy đủ thông tin từ ngày giờ/ đến ngày giờ hỏng hoặc để trống', ENGLISH_OR=N'Please enter start/end time of breakdown, or leave blank' WHERE FORM=N'frmPhieuBaoTri_New' AND KEYWORD=N'MsgNhapNgayGioHongFull' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmPhieuBaoTri_New',N'MsgNhapNgayGioHongFull',N'Vui lòng nhập đầy đủ thông tin từ ngày giờ/ đến ngày giờ hỏng hoặc để trống',N'Please enter start/end time of breakdown, or leave blank',N'Vui lòng nhập đầy đủ thông tin từ ngày giờ/ đến ngày giờ hỏng hoặc để trống',N'Please enter start/end time of breakdown, or leave blank')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhatSinhDichVu' AND KEYWORD =N'msgChiDuocPhanboTrenYeuCauCoWO') UPDATE LANGUAGES SET VIETNAM=N'Không được phân bổ khi chưa có Phiếu bảo trì', ENGLISH=N'Cannot distribute without existing Maintenance Order', VIETNAM_OR=N'Không được phân bổ khi chưa có Phiếu bảo trì', ENGLISH_OR=N'Cannot distribute without existing Maintenance Order' WHERE FORM=N'frmPhatSinhDichVu' AND KEYWORD=N'msgChiDuocPhanboTrenYeuCauCoWO' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmPhatSinhDichVu',N'msgChiDuocPhanboTrenYeuCauCoWO',N'Không được phân bổ khi chưa có Phiếu bảo trì',N'Cannot distribute without existing Maintenance Order',N'Không được phân bổ khi chưa có Phiếu bảo trì',N'Cannot distribute without existing Maintenance Order')
