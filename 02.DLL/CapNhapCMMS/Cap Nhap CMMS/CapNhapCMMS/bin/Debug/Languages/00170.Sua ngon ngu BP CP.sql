

Update LANGUAGES set VIETNAM = N'Bạn có muốn xóa ngân sách năm này không?' where FORM = 'frmBoPhanChiuPhi' and KEYWORD ='MsgXOA_NGAN_SACH'

Update LANGUAGES set ENGLISH = N'Do you want to delete budget of this year?' where FORM = 'frmBoPhanChiuPhi' and KEYWORD ='MsgXOA_NGAN_SACH'


Update LANGUAGES set VIETNAM = N'Bộ phận chịu phí này đang có dữ liệu ngân sách nên bạn không thể xóa.' where FORM = 'frmBoPhanChiuPhi' and KEYWORD ='MsgDATA_NGAN_SACH'

Update LANGUAGES set ENGLISH = N'This Cost Center cannot be deleted because it has budget.' where FORM = 'frmBoPhanChiuPhi' and KEYWORD ='MsgDATA_NGAN_SACH'

Update LANGUAGES set VIETNAM = N'Bạn có muốn xóa ngân sách năm này không?' where FORM = 'frmBoPhanChiuPhi' and KEYWORD ='MsgXOA_NGAN_SACH'

Update LANGUAGES set ENGLISH = N'Do you want to delete budget of this year?' where FORM = 'frmBoPhanChiuPhi' and KEYWORD ='MsgXOA_NGAN_SACH'


Update LANGUAGES set VIETNAM = N'Bộ phận chịu phí này đang có dữ liệu ngân sách nên bạn không thể xóa.' where FORM = 'frmBophanchiuphi_cs' and KEYWORD ='MsgDATA_NGAN_SACH'

Update LANGUAGES set ENGLISH = N'This Cost Center cannot be deleted because it has budget.' where FORM = 'frmBophanchiuphi_cs' and KEYWORD ='MsgDATA_NGAN_SACH'

-- Sua ten report 

Update DS_REPORT set TEN_REPORT_VIET = N'Theo dõi yêu cầu bảo trì' where REPORT_NAME = 'ucBaoCaoYCNSD'

Update DS_REPORT set TEN_REPORT_ANH = N'Tracking Work Request' where REPORT_NAME = 'ucBaoCaoYCNSD'


