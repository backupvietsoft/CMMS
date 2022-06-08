Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmChonMay_TGNM' and KEYWORD ='MS_MAY'

Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmExportData' and KEYWORD ='MS_MAY'

IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmPhatSinhDichVu' AND KEYWORD =N'msgConDuLieuPSDVPBT') UPDATE LANGUAGES SET VIETNAM=N'Còn dữ liệu yêu cầu dịch vụ PBT! Bạn có muốn xóa luôn?', ENGLISH=N'There is undeleted data in the system. Do you want to delete these data?', VIETNAM_OR=N'Còn dữ liệu yêu cầu dịch vụ PBT! Bạn có muốn xóa luôn?', ENGLISH_OR=N'There is undeleted data in the system. Do you want to delete these data?' WHERE FORM=N'frmPhatSinhDichVu' AND KEYWORD=N'msgConDuLieuPSDVPBT' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmPhatSinhDichVu',N'msgConDuLieuPSDVPBT',N'Còn dữ liệu yêu cầu dịch vụ PBT! Bạn có muốn xóa luôn?',N'There is undeleted data in the system. Do you want to delete these data?',N'Còn dữ liệu yêu cầu dịch vụ PBT! Bạn có muốn xóa luôn?',N'There is undeleted data in the system. Do you want to delete these data?')


Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmGiamsattinhtrang' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmHieuchuan' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmHieuchuan' and KEYWORD ='LblMS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmKehoachtongthe' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmKehoachtongthe_odd' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmMaintenance' and KEYWORD ='lblMS_May'



Update LANGUAGES set VIETNAM = N'Mã thiết bị'  where FORM = 'frmMaterialStatistical' and KEYWORD ='lblMs_May'
Update LANGUAGES set VIETNAM = N'Mã thiết bị'  where FORM = 'FrmNXHTBPCP' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị'  where FORM = 'FrmPhieuBaoTri' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị'  where FORM = 'FrmPhieuBaoTri_New' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị'  where FORM = 'frmMaintenance' and KEYWORD ='lblMS_May'


Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'FrmPhieuXuatKhoVatTu' and KEYWORD ='lblMSMAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'FrmThongtinthietbi' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã bộ phận không được trùng mã thiết bị!' where FORM = 'FrmThongtinthietbi' and KEYWORD ='MsgQuyenkt52'
Update LANGUAGES set VIETNAM = N'Bạn vui lòng nhập mã thiết bị' where FORM = 'FrmThongtinthietbi' and KEYWORD ='MsgQuyenKT6'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmYeucaucuaNSD' and KEYWORD ='cboMS_May'



Update LANGUAGES set VIETNAM = N'Mã thiết bị không được rỗng' where FORM = 'frmYeucaucuaNSD' and KEYWORD ='Msgnullmsmay'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'frmYeucaucuaNSD_Duyet' and KEYWORD ='cboMS_May'
Update LANGUAGES set VIETNAM = N'Mã thiết bị không được rỗng.' where FORM = 'frmYeucaucuaNSD_Duyet' and KEYWORD ='Msgnullmsmay'
Update LANGUAGES set VIETNAM = N'Bạn vui lòng nhập mã thiết bị' where FORM = 'FrnThongtinthietbi' and KEYWORD ='MsgQuyenKT6'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'rptKeHoachPhanCongBT' and KEYWORD ='MS_MAY'



Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'rptThamDinhThietBi' and KEYWORD ='MS_MAY'
Update LANGUAGES set VIETNAM = N'Mã thiết bị' where FORM = 'rptTIEU_DE_DANH_GIA_DICH_VU_KH' and KEYWORD ='ThietBi'
Update LANGUAGES set VIETNAM = N'Mã thiết bị ' where FORM = 'rptTieuDeDanhSachDHDDaHC' and KEYWORD ='MS_MAY_'
Update LANGUAGES set VIETNAM = N'Mã thiết bị ' where FORM = 'frmYeuCauBT' and KEYWORD ='lblMS_MAY'


Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'frmChonMay_TGNM' and KEYWORD ='TEN_MAY'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'frmExportData' and KEYWORD ='TEN_MAY'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'frmThoiGianChayMay' and KEYWORD ='TEN_MAY'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'FrmThongtinthietbi' and KEYWORD ='chkTenTB'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'rptDanhSachConHanBaoHanh' and KEYWORD ='TenMay'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'rptKeHoachGiamSatTinhTrang' and KEYWORD ='TenMay'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'rptThamDinhThietBi' and KEYWORD ='TEN_MAY'

Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'rptTHONG_TIN_CHUNG_VA_THONG_SO_TB' and KEYWORD ='TEN_MAY'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'ucBaoCaoChiPhiChiTiet' and KEYWORD ='TenMay'
Update LANGUAGES set VIETNAM = N'Tên thiết bị' where FORM = 'frmThoiGianChayMay' and KEYWORD ='TEN_MAY'



