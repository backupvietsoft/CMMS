-- Update ngon ngu cho phan Thoi gian ngung may
Update LANGUAGES set VIETNAM = N'Thời gian ngừng máy'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='FrmThoiGianNgungMayNew'
Update LANGUAGES set ENGLISH = N'Downtime'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='FrmThoiGianNgungMayNew'

Update LANGUAGES set VIETNAM = N''  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='lblTitle'
Update LANGUAGES set ENGLISH = N''  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='lblTitle'

Update LANGUAGES set VIETNAM = N'Thời gian ngừng máy'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='TUA_DE_FORM'
Update LANGUAGES set ENGLISH = N'Downtime'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='TUA_DE_FORM'


Update LANGUAGES set VIETNAM = N'Danh sách ngừng máy'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='gbLanNgungMay'
Update LANGUAGES set ENGLISH = N'Downtime list '  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='gbLanNgungMay'


Update LANGUAGES set VIETNAM = N'Loại thiết bị'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='lblLoaithietbi'
Update LANGUAGES set ENGLISH = N'Equipment type'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='lblLoaithietbi'

Update LANGUAGES set VIETNAM = N'Mã số thiết bị'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='lblMSMAY'


Update LANGUAGES set VIETNAM = N'...'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='btnNNNM'
Update LANGUAGES set ENGLISH = N'...'  where FORM = 'FrmThoiGianNgungMayNew' and KEYWORD ='btnNNNM'


--- Update ngon ngu cho 3 form Yeu cau nguoi su dung 


Update LANGUAGES set VIETNAM = N'Chấp nhận' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'chkThucHien'
Update LANGUAGES set ENGLISH = N'Accepted' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'chkThucHien'

Update LANGUAGES set VIETNAM = N'' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'lblThucHien'

Update LANGUAGES set ENGLISH = N'' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'lblThucHien'

Update LANGUAGES set ENGLISH = N'Dont have right to approve' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabKhongDuocDuyet'
Update LANGUAGES set VIETNAM = N'Không có quyền duyệt' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabKhongDuocDuyet'

Update LANGUAGES set ENGLISH = N'Have right to approve' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabDuocDuyet'
Update LANGUAGES set VIETNAM = N'Có quyền duyệt' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabDuocDuyet'


Update LANGUAGES set ENGLISH = N'Accepted, waiting for Maint dept' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabChuaXuLy'
Update LANGUAGES set VIETNAM = N'Chấp nhận, đợi bảo trì tiếp nhận' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabChuaXuLy'

Update LANGUAGES set ENGLISH = N'Unchecked' where FORM = 'frmDuyetSanXuat' and KEYWORD ='tabChuaKiemTra'
Update LANGUAGES set VIETNAM = N'Chưa duyệt' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabChuaKiemTra'

Update LANGUAGES set ENGLISH = N'Checked, rejected' where FORM = 'frmDuyetSanXuat' and KEYWORD ='tabKhongThucHien'
Update LANGUAGES set VIETNAM = N'Đã duyệt, không chấp nhận' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'tabKhongThucHien'

Update LANGUAGES set ENGLISH = N'Accept' where FORM = 'frmDuyetSanXuat' and KEYWORD ='cmdDuyet'
Update LANGUAGES set VIETNAM = N'Chấp nhận' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'cmdDuyet'


Update LANGUAGES set ENGLISH = N'Reject' where FORM = 'frmDuyetSanXuat' and KEYWORD ='btnKgDuyet'
Update LANGUAGES set VIETNAM = N'Không chấp nhận' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'btnKgDuyet'

Update LANGUAGES set VIETNAM = N'Ngày YC hoàn thành' where FORM = 'frmYeucaucuaNSD' and KEYWORD ='NGAY_HOAN_THANH'
Update LANGUAGES set VIETNAM = N'Ngày YC hoàn thành' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'lblNgayhoanthanh'

Update LANGUAGES set ENGLISH = N'REQ completion date' where FORM = 'frmYeucaucuaNSD' and KEYWORD ='NGAY_HOAN_THANH'
Update LANGUAGES set ENGLISH = N'REQ completion date' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'lblNgayhoanthanh'

Update LANGUAGES set ENGLISH = N'Incident date' where FORM = 'frmYeucaucuaNSD' and KEYWORD ='NGAY_XAY_RA'
Update LANGUAGES set ENGLISH = N'Incident time' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'GIO_XAY_RA'

Update LANGUAGES set VIETNAM = N'Nội dung yêu cầu' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'YEU_CAU'


Update LANGUAGES set ENGLISH = N'Sign with name ' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'APPROVED_BY'
Update LANGUAGES set VIETNAM = N'Ký và ghi rõ họ tên' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'APPROVED_BY'


Update LANGUAGES set ENGLISH = N'Sign with name ' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'KY_HO_TEN'
Update LANGUAGES set VIETNAM = N'Ký và ghi rõ họ tên' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'KY_HO_TEN'

Update LANGUAGES set ENGLISH = N'Request No.' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'MS_YC'
Update LANGUAGES set VIETNAM = N'Số yêu cầu' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'MS_YC'


Update LANGUAGES set ENGLISH = N'Request date' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGAY_YC'
Update LANGUAGES set VIETNAM = N'Ngày yêu cầu' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGAY_YC'

Update LANGUAGES set ENGLISH = N'Accepted by' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGUOI_DUYET_YC'
Update LANGUAGES set VIETNAM = N'Người chấp nhận' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGUOI_DUYET_YC'

Update LANGUAGES set ENGLISH = N'Requested by' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGUOI_YC_KT'
Update LANGUAGES set VIETNAM = N'Người yêu cầu' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGUOI_YC_KT'

Update LANGUAGES set ENGLISH = N'Requested by' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGUOI_YC'
Update LANGUAGES set VIETNAM = N'Người yêu cầu' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NGUOI_YC'

Update LANGUAGES set ENGLISH = N'Line' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'TEN_DC_YC'
Update LANGUAGES set VIETNAM = N'Dây chuyền' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'TEN_DC_YC'

Update LANGUAGES set ENGLISH = N'Request Details' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NOI_DUNG_YC'
Update LANGUAGES set VIETNAM = N'Nội dung yêu cầu' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'NOI_DUNG_YC'

Update LANGUAGES set ENGLISH = N'Failure description' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'TT_TB_TRUOC_SAU'
Update LANGUAGES set VIETNAM = N'Mô tả tình trạng' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'TT_TB_TRUOC_SAU'

Update LANGUAGES set ENGLISH = N'USER REQUEST' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'TIEU_DE_YC'
Update LANGUAGES set VIETNAM = N'YÊU CẦU CỦA NGƯỜI SỬ DỤNG' where FORM = 'frmChonInPhieuBaoTri' and KEYWORD = 'TIEU_DE_YC'

Update LANGUAGES set ENGLISH = N'Request Type' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'TEN_LOAI_YEU_CAU_BT'


Update LANGUAGES set ENGLISH = N'Search' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'lblMSMay'
Update LANGUAGES set VIETNAM = N'Tìm kiếm' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'lblMSMay'


Update LANGUAGES set ENGLISH = N'Request Status' where FORM = 'frmYeuCauCuaNSD' and KEYWORD = 'dockPanel_XuLy'
Update LANGUAGES set VIETNAM = N'Tình hình xử lý yêu cầu' where FORM = 'frmYeuCauCuaNSD' and KEYWORD = 'dockPanel_XuLy'


Update TINH_TRANG_YCSD set TEN_TTRANG = N'Chưa xem xét' where MS_TTRANG = 0 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Not checked' where MS_TTRANG = 0 


Update TINH_TRANG_YCSD set TEN_TTRANG = N'Đã duyệt, không chấp nhận' where MS_TTRANG = 1 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Checked, rejected' where MS_TTRANG = 1 


Update TINH_TRANG_YCSD set TEN_TTRANG = N'Đã chấp nhận, chờ bảo trì giải quyết' where MS_TTRANG = 2 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Accepted, waiting for maintenance dept' where MS_TTRANG = 2 

Update TINH_TRANG_YCSD set TEN_TTRANG =N'Chờ do chưa đủ điều kiện thực hiện' where MS_TTRANG = 3 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Waiting due to lack some condition ' where MS_TTRANG = 3 

Update TINH_TRANG_YCSD set TEN_TTRANG = N'Đã có kế hoạch bảo trì' where MS_TTRANG = 4 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Already has maintenance plan' where MS_TTRANG = 4

Update TINH_TRANG_YCSD set TEN_TTRANG = N'Đang thực hiện bảo trì' where MS_TTRANG = 5 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Maintenance is in progress' where MS_TTRANG = 5


Update TINH_TRANG_YCSD set TEN_TTRANG = N'Đã hoàn thành bảo trì' where MS_TTRANG = 6 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Maintenance is completed' where MS_TTRANG = 6

Update TINH_TRANG_YCSD set TEN_TTRANG = N'Bộ phận bảo trì hủy yêu cầu' where MS_TTRANG = 7 
Update TINH_TRANG_YCSD set TEN_TTRANG_ANH = 'Rejected by maint. department' where MS_TTRANG = 7


Update LANGUAGES set ENGLISH = N'Reviewer from Maintenance' where FORM = 'frmYeuCauCuaNSD' and KEYWORD = 'USERNAME_DBT'
Update LANGUAGES set VIETNAM = N'Người duyệt của bảo trì' where FORM = 'frmYeuCauCuaNSD' and KEYWORD = 'USERNAME_DBT'


Update LANGUAGES set ENGLISH = N'Reviewer from Production' where FORM = 'frmYeuCauCuaNSD' and KEYWORD = 'USERNAME_DSX'
Update LANGUAGES set VIETNAM = N'Người duyệt của sản xuất' where FORM = 'frmYeuCauCuaNSD' and KEYWORD = 'USERNAME_DSX'


Update LANGUAGES set ENGLISH = N'Checker opinion' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'lblYKien'

Update LANGUAGES set ENGLISH = N'Opinion of Production' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'Y_KIEN_DSX'
Update LANGUAGES set VIETNAM = N'Ý kiến của sản xuất' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'Y_KIEN_DSX'


Update LANGUAGES set ENGLISH = N'Opinion of Maintenance' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'Y_KIEN_DBT'
Update LANGUAGES set VIETNAM = N'Ý kiến của bảo trì' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'Y_KIEN_DBT'

Update LANGUAGES set ENGLISH = N'Planned start date' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'NGAY_BD_KH'
Update LANGUAGES set VIETNAM = N'Ngày bắt đầu kế hoạch' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'NGAY_BD_KH'


Update LANGUAGES set ENGLISH = N'Planned end date' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'NGAY_KT_KH'
Update LANGUAGES set VIETNAM = N'Ngày kết thúc kế hoạch' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'NGAY_KT_KH'

Update LANGUAGES set ENGLISH = N'Actual start date' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'TU_NGAY'
Update LANGUAGES set VIETNAM = N'Ngày bắt đầu thực tế' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'TU_NGAY'

Update LANGUAGES set ENGLISH = N'Actual end date' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'DEN_NGAY'
Update LANGUAGES set VIETNAM = N'Ngày kết thúc thực tế' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'DEN_NGAY'


Update LANGUAGES set ENGLISH = N'Used items' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'VAT_TU'
Update LANGUAGES set VIETNAM = N'VT PT sử dụng' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'VAT_TU'


Update LANGUAGES set ENGLISH = N'Carried out by ' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'MS_CONG_NHAN'
Update LANGUAGES set VIETNAM = N'Người bảo trì' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'MS_CONG_NHAN'	
	
	
Update LANGUAGES set ENGLISH = N'Status of Request' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'TEN_TINH_TRANG'
Update LANGUAGES set VIETNAM = N'Tình trạng của yêu cầu' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'TEN_TINH_TRANG'	


Update LANGUAGES set ENGLISH = N'Status of Request' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'TEN_TINH_TRANG'
Update LANGUAGES set VIETNAM = N'Tình trạng của yêu cầu' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'TEN_TINH_TRANG'

Update LANGUAGES set ENGLISH = N'Do you want to resend email? ' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'msgBanCoMuonGoiMailLai'
Update LANGUAGES set VIETNAM = N'Bạn có muốn gửi mail lại?' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'msgBanCoMuonGoiMailLai'

Update LANGUAGES set ENGLISH = N'Do you want to resend email for re-approving? ' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'msgBanCoMuonGoiMailLai'
Update LANGUAGES set VIETNAM = N'Bạn có muốn gửi mail để được duyệt lại?' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'msgBanCoMuonGoiMailLai'

Update LANGUAGES set ENGLISH = N'Attach' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'TAI_LIEU'
Update LANGUAGES set VIETNAM = N'Tài liệu' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'TAI_LIEU'


Update LANGUAGES set ENGLISH = N'User request input' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'frmYeucaucuaNSD'
Update LANGUAGES set VIETNAM = N'Nhập yêu cầu của người sử dụng' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'frmYeucaucuaNSD'

Update LANGUAGES set ENGLISH = N'' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'lblTieude'
Update LANGUAGES set VIETNAM = N'' where FORM = 'frmYeucaucuaNSD' and KEYWORD = 'lblTieude'

Update LANGUAGES set ENGLISH = N'Attach' where FORM = 'frmYeuCauBT' and KEYWORD = 'TAI_LIEU'
Update LANGUAGES set VIETNAM = N'Tài liệu' where FORM = 'frmYeuCauBT' and KEYWORD = 'TAI_LIEU'


Update LANGUAGES set ENGLISH = N'Accept' where FORM = 'frmYeuCauBT' and KEYWORD = 'cmdDuyet'
Update LANGUAGES set VIETNAM = N'Chấp nhận' where FORM = 'frmYeuCauBT' and KEYWORD = 'cmdDuyet'

Update LANGUAGES set ENGLISH = N'Reject' where FORM = 'frmYeuCauBT' and KEYWORD = 'btnBoQua'
Update LANGUAGES set VIETNAM = N'Không chấp nhận' where FORM = 'frmYeuCauBT' and KEYWORD = 'btnBoQua'

Update LANGUAGES set ENGLISH = N'Pend for planning' where FORM = 'frmYeuCauBT' and KEYWORD = 'btnChoTH'
Update LANGUAGES set VIETNAM = N'Đợi lập kế hoạch' where FORM = 'frmYeuCauBT' and KEYWORD = 'btnChoTH'

Update LANGUAGES set ENGLISH = N'Pend' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChoxuly'
Update LANGUAGES set VIETNAM = N'Đợi thực hiện' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChoxuly'

Update LANGUAGES set ENGLISH = N'User Request Receipt' where FORM = 'frmYeuCauBT' and KEYWORD = 'frmYeuCauBT'
Update LANGUAGES set VIETNAM = N'Tiếp nhận yêu cầu người sử dụng' where FORM = 'frmYeuCauBT' and KEYWORD = 'frmYeuCauBT'

Update LANGUAGES set ENGLISH = N'User Request Approval' where FORM = 'frmDuyetSanXuat' and KEYWORD = 'frmDuyetSanXuat'

Update Menu set MENU_ENGLISH ='User Request Receipt' where MENU_ID ='mnuYeucauNSD_DBT'


Update LANGUAGES set ENGLISH = N'' where FORM = 'frmYeuCauBT' and KEYWORD = 'LabelControl1'
Update LANGUAGES set VIETNAM = N'' where FORM = 'frmYeuCauBT' and KEYWORD = 'LabelControl1'


Update LANGUAGES set ENGLISH = N'Checked, Rejected' where FORM = 'frmYeuCauBT' and KEYWORD = 'optboqua'
Update LANGUAGES set VIETNAM = N'Không chấp nhận thực hiện' where FORM = 'frmYeuCauBT' and KEYWORD = 'optboqua'

Update LANGUAGES set ENGLISH = N'Maintenance completed' where FORM = 'frmYeuCauBT' and KEYWORD = 'optdahoanthanh'
Update LANGUAGES set VIETNAM = N'Đã hoàn thành bảo trì' where FORM = 'frmYeuCauBT' and KEYWORD = 'optdahoanthanh'


Update LANGUAGES set ENGLISH = N'Included in Mater Plan' where FORM = 'frmYeuCauBT' and KEYWORD = 'optKHTT'
Update LANGUAGES set VIETNAM = N'Đã đưa vào KH tổng thể' where FORM = 'frmYeuCauBT' and KEYWORD = 'optKHTT'

Update LANGUAGES set ENGLISH = N'Waiting for planning ' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChoxuly'
Update LANGUAGES set VIETNAM = N'Đợi đưa vào kế hoạch' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChoxuly'

Update LANGUAGES set ENGLISH = N'Waiting for planning ' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChoxuly'
Update LANGUAGES set VIETNAM = N'Đợi đưa vào kế hoạch' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChoxuly'

Update LANGUAGES set ENGLISH = N'Not checked' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChuaxemxet'
Update LANGUAGES set VIETNAM = N'Chưa kiểm tra' where FORM = 'frmYeuCauBT' and KEYWORD = 'optChuaxemxet'

Update LANGUAGES set ENGLISH = N'Opinion of maintenance' where FORM = 'frmYeuCauBT' and KEYWORD = 'lblYKienBT'
Update LANGUAGES set VIETNAM = N'Ý kiến của bảo trì' where FORM = 'frmYeuCauBT' and KEYWORD = 'lblYKienBT'


Update LANGUAGES set ENGLISH = N'Create new article in Master Plan' where FORM = 'frmTaoKHTT' and KEYWORD = 'frmTaoKHTT'
Update LANGUAGES set VIETNAM = N'Tạo mới hạng mục trên kế hoạch tổng thể' where FORM = 'frmTaoKHTT' and KEYWORD = 'frmTaoKHTT'

Update LANGUAGES set ENGLISH = N'Plan Article' where FORM = 'frmTaoKHTT' and KEYWORD = 'lblTHangMuc'
Update LANGUAGES set VIETNAM = N'Hạng mục kế hoạch' where FORM = 'frmTaoKHTT' and KEYWORD = 'lblTHangMuc'