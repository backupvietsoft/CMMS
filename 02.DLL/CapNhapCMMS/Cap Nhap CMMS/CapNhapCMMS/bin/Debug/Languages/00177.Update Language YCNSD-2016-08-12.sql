Update LANGUAGES set VIETNAM = N'Tiếp nhận yêu cầu người sử dụng' where FORM = 'frmYeuCauBT' and KEYWORD = 'frmYeuCauBT'
Update LANGUAGES set ENGLISH = N'Work Request Receipt' where FORM = 'frmYeuCauBT' and KEYWORD = 'frmYeuCauBT'

Update MENU set MENU_ENGLISH = '4.3.3 User Request Receipt' where MENU_ID = 'mnuYeucauNSD_DBT'
Update MENU set MENU_ENGLISH = ' 4.3.2. Request Approval' where MENU_ID = 'mnuYeucauNSD_DSX'

Update LANGUAGES set VIETNAM = N'Phiếu bảo trì này phải được ban hành trước khi xác nhận nghiệm thu! Chọn YES để ban hành phiếu bảo trì này.' where FORM = 'FrmPhieuBaoTri_New' and KEYWORD = 'MsgPhieuBTChuaDuyet'

Update LANGUAGES set VIETNAM = N'Bạn click "YES" nếu muốn cập nhật tổng thời gian vào Công việc và Cấu trúc thiết bị, click "NO" nếu muốn cập nhật vào Cấu trúc thiết bị và click "CANCEL" nếu không muốn cập nhật' where FORM = 'FrmPhieuBaoTri_New' and KEYWORD = 'msgBanMuonCapNhapLaiSoGioKeHoach'
Update LANGUAGES set ENGLISH = N'Please click "YES" to update total time to Maintence Work and Equipment Hierarchy, click "NO" to update to Equipment Hierarchy and click "CANCEL" if you do not want to update' where FORM = 'FrmPhieuBaoTri_New' and KEYWORD = 'msgBanMuonCapNhapLaiSoGioKeHoach'




