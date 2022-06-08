﻿UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Phiếu công việc theo nhân viên (từ PBT và CV VP)', TEN_REPORT_ANH = N'List of maintenance works by employee', STT =1 , NOTE = N'Phiếu công việc theo nhân viên lấy nguồn từ Phiếu bảo trì và Công việc văn phòng (cả kế hoạch và thực hiện). Báo cáo Excel.' WHERE REPORT_NAME = N'ucBaoCaoPhieuCongViec'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Kế hoạch các công việc trong khoảng thời gian (KHTT, PBT, CV VP)', TEN_REPORT_ANH = N'List of maintenance works in period of time (Master Plan, Work Order, Office Work)', STT =2 , NOTE = N'Công việc được liệt kê là những công việc từ KHTT, Phiếu bảo trì chưa hoàn thành và các công việc văn phòng chưa hoàn thành. Có thời gian kế hoạch để ước lượng khối lượng công việc. Báo cáo Excel.' WHERE REPORT_NAME = N'ucKeHoachCongViecBaoTri'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'DS công việc từ PBT theo giai đoạn và tình trạng PBT (Gantt Chart)', TEN_REPORT_ANH = N'List of maintenance works by period of time (Gantt Chart)', STT =3 , NOTE = N'Có thể in danh sách công việc theo giai đoạn (không quá 31 ngày). Khá tiện dụng cho việc lập kế hoạch bảo trì khi chọn Phiếu bảo trì đang soạn và Đang thực hiện. Có hiển thị Gantt Chart. Dữ liệu chỉ lấy từ Phiếu bảo trì. Báo cáo dạng Excel ' WHERE REPORT_NAME = N'ucKeHoachBTTuan'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ tuần', TEN_REPORT_ANH = N'Weekly periodic maintenance plan', STT =4 , NOTE = N'Phần mềm tính lịch xích cho bảo trì định kỳ trong tuần bao gồm thông tin chi tiết về thiết bị, công việc cần làm, chu kỳ và ngày cần phải bảo trì in theo tuần được chọn' WHERE REPORT_NAME = N'rptKeHoachBaoTriTrongTuan'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Biểu mẫu ghi nhận kết quả thực hiện bảo trì định kỳ tuần ', TEN_REPORT_ANH = N'Template for weekly periodic maintenance ', STT =5 , NOTE = N'Phần mềm tính lịch xích bảo trì định kỳ và lập danh sách công việc. Có các cột để trống để nhân viên bảo trì ghi nhận bằng tay khi thực hiện. Có thể dùng như biểu mẫu. Dữ liệu đã điền có thể giao cho nhân viên văn phòng nhập vào phần mềm.  In theo từng tuần. Báo cáo Excel. ' WHERE REPORT_NAME = N'ucKeHoachTuan'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ tháng in theo máy (Gantt chart)', TEN_REPORT_ANH = N'Monthly periodic maintenance plan of equipment (Gantt chart)', STT =7 , NOTE = N'Tính lịch xích bảo trì rồi in ra kế hoạch cho từng máy (không có công việc chi tiết). Có thể hiện trên Gantt chart. Báo cáo Excel.' WHERE REPORT_NAME = N'ucMaintainMonth'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ tháng chi tiết theo công việc ', TEN_REPORT_ANH = N'Monthly periodic maintenance plan with work list ', STT =8 , NOTE = N'Tính lịch xích bảo trì định kỳ theo tháng cho từng máy có kèm theo công việc chi tiết. Dùng để lập kế hoạch bảo trì định kỳ. Xuất ra form cho xem và có thể in ra Excel.' WHERE REPORT_NAME = N'UCKeHoachBT_Thang'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ theo năm in theo máy ', TEN_REPORT_ANH = N'Anual periodic maintenance plan of equipment ', STT =9 , NOTE = N'Tính toán lịch xích bảo trì định kỳ rồi xuất ra báo cáo những máy, bộ phận nào cần bảo trì vào tháng nào của năm. Không bao gồm các thông tin về công việc. Báo cáo dạng Excel.' WHERE REPORT_NAME = N'ucKHBDThietBi'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ năm chi tiết theo từng công việc ', TEN_REPORT_ANH = N'Annual periodic maintenance report with work list ', STT =10 , NOTE = N'Tính lịch xích bảo trì định kỳ cho năm cho từng máy có kèm theo công việc chi tiết. Dùng để lập kế hoạch bảo trì định kỳ. Xuất ra form cho xem và có thể in ra Excel.' WHERE REPORT_NAME = N'UCKeHoachBT_Nam'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách phiếu bảo trì', TEN_REPORT_ANH = N'List of work orders', STT =13 , NOTE = N'Danh sách các Phiếu bảo trì theo giai đoạn, lọc theo nhiều tiêu chí khác nhau ' WHERE REPORT_NAME = N'ucDanhSachPBT'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách Phiếu bảo trì cuối cùng của thiết bị ', TEN_REPORT_ANH = N'List of last work orders of equipment ', STT =45 , NOTE = N'Danh sách các thiết bị kèm theo thông tin Phiếu bảo trì cuối cùng của từng thiết bị' WHERE REPORT_NAME = N'rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Tổng số lượng VTPT dùng cho bảo trì tất cả các thiết bị ', TEN_REPORT_ANH = N'Total quantity of items used for maintenance ', STT =46 , NOTE = N'Danh sách vật tư phụ tùng đã sử dụng cho bảo trì (lấy từ Phiếu bảo trì chứ không phải lấy từ xuất kho)' WHERE REPORT_NAME = N'ucDanhSachVTPT'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách VTPT sử dụng để bảo trì cho từng thiết bị', TEN_REPORT_ANH = N'List of items used for maintenance for each equipment ', STT =47 , NOTE = N'Danh sách các vật tư cũng như số lượng đã sử dụng để bảo trì thiết bị.' WHERE REPORT_NAME = N'rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Báo cáo tổng hợp công việc bảo trì thiết bị (dạng 1) ', TEN_REPORT_ANH = N'Maintenance report summary (format 1) ', STT =51 , NOTE = N'Tổng hợp các công việc bảo trì bao gồm tên công việc, vật tư phụ tùng đã sử dụng và nhân sự đã tham gia. Excel report ' WHERE REPORT_NAME = N'ucDSBaoTri'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Báo cáo tổng hợp công việc bảo trì thiết bị (dạng 2) ', TEN_REPORT_ANH = N'Maintenance report summary (format 2) ', STT =53 , NOTE = N'Báo cáo so sánh kế hoạch các công việc bảo trì và thực tế thực hiện. Tính phần trăm hoàn thanh va có vẽ biểu đồ ' WHERE REPORT_NAME = N'ucBaoCaoCongViecBaoTri'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Báo cáo đánh giá dịch vụ của nhà cung cấp ', TEN_REPORT_ANH = N'Supplier service assessment', STT =75 , NOTE = N'Bảng đánh giá các nhà cung cấp dịch vụ khi thuê ngoài (từ Phiếu bảo trì)' WHERE REPORT_NAME = N'rptDANH_GIA_DICH_VU_KH'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Phiếu công việc', TEN_REPORT_ANH = N'Job card', STT =100 , NOTE = N'Phiếu công việc' WHERE REPORT_NAME = N'rptPHIEU_CONG_VIEC'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'z_Kế hoạch bảo trì dự phòng hàng năm ', TEN_REPORT_ANH = N'Yearly maintenance plan', STT =101 , NOTE = N'Lịch bảo trì định kỳ trong năm bao gồm thông tin về thiết bị, công việc cần làm, chu kỳ và ngày cần phải bảo trì in theo từng năm' WHERE REPORT_NAME = N'rptKehoachbaotriduphong'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Kế hoạch bảo dưỡng tháng (DS công việc) - kho dung - bo ', TEN_REPORT_ANH = N'Monthly maintenance plan (work list)', STT =101 , NOTE = N'Kế hoạch bảo dưỡng tháng theo địa điểm, dây chuyền, loại máy' WHERE REPORT_NAME = N'ucKeHoachBaoDuong'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Kế hoạch bảo trì năm theo loại máy (trung lap)', TEN_REPORT_ANH = N'Annual maintenance plan', STT =102 , NOTE = N'Kế hoạch bảo trì năm theo loại máy' WHERE REPORT_NAME = N'ucKeHoachNam'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Báo cáo bảo trì thiết bị chi tiết (theo công việc -nhân viên) - Trung lap', TEN_REPORT_ANH = N'Maintenance report at branch office', STT =102 , NOTE = N'Báo cáo bảo trì thiết bị tại chi nhánh theo địa điểm, dây chuyền, loại máy, loại bảo trì' WHERE REPORT_NAME = N'ucBaoCaoBaoTriThietBi'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách Phiếu bảo trì nhóm theo địa điểm (da co bao cao thay the)', TEN_REPORT_ANH = N'List of work orders by work site', STT =102 , NOTE = N'Danh sách các phiếu bảo trì theo từng địa điểm' WHERE REPORT_NAME = N'rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách PBT nhóm theo loại máy', TEN_REPORT_ANH = N'List of work orders by equipment type', STT =102 , NOTE = N'Danh sách các phiếu bảo trì theo từng loại máy có thể xem theo đã nghiệm thu , chưa nghiệm thu ' WHERE REPORT_NAME = N'rptDSCPBTTLoaiMay_LoaiTB'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách PBT chưa nghiệm thu theo nhân viên (không cần, kết hợp vào phiếu CV)', TEN_REPORT_ANH = N'List of unaccepted work orders by workers', STT =102 , NOTE = N'Danh sách phiếu bảo trì chưa nghiệm thu theo từng nhân viên' WHERE REPORT_NAME = N'rptDSCYCBTChuaNghiemThuTheoNV'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách PBT đã nghiệm thu theo nhân viên (sẽ kết hợp với PCV)', TEN_REPORT_ANH = N'List of accepted work orders by workers', STT =102 , NOTE = N'Danh sách phiếu bảo trì đã nghiệm thu theo từng nhân viên' WHERE REPORT_NAME = N'rptDSCYCBTDaNghiemThuTheoNV'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách PBT chưa nghiệm thu (da co bao cao thay the)', TEN_REPORT_ANH = N'List of unaccepted work orders by maintenant type', STT =102 , NOTE = N'Danh sách phiếu bảo trì chưa nghiệm thu ' WHERE REPORT_NAME = N'rptDSPBTChuaNghiemThuTLBT'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Danh sách PBT đã nghiệm thu theo loại bảo trì (da co BC thay the)', TEN_REPORT_ANH = N'List of accepted work orders by maintenant type', STT =102 , NOTE = N'Danh sách phiếu bảo trì đã nghiệm thu theo từng loại bảo trì' WHERE REPORT_NAME = N'rptDSPBTDaNghiemThuTLBT'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Báo cáo bảo trì thiết bị tổng quát (theo máy) - tạm bỏ ', TEN_REPORT_ANH = N'General Maintenance report (by machine) ', STT =105 , NOTE = N'Báo cáo bảo trì thiết bị tuần tại chi nhánh theo địa điểm, dây chuyền, loại máy, loại bảo trì' WHERE REPORT_NAME = N'ucBaoCaoBaoTriThietBiTuan'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ tuần theo loại công việc 3 - khong len du lieu ', TEN_REPORT_ANH = N'Weekly maintenance plan', STT =120 , NOTE = N'Lịch bảo trì định kỳ trong tháng bao gồm thông tin về thiết bị, công việc cần làm, chu kỳ và ngày cần phải bảo trì in theo từng tuần trong tháng.' WHERE REPORT_NAME = N'rptKE_HOACH_BT_TUAN'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ năm theo địa điểm (trung lap) - in khong ra du lieu ', TEN_REPORT_ANH = N'Plan for periodic maintenance ', STT =121 , NOTE = N'Lịch bảo trì định kỳ trong năm bao gồm thông tin về thiết bị, công việc cần làm, chu kỳ và ngày cần phải bảo trì in theo từng năm' WHERE REPORT_NAME = N'rptKeHoachSuaChuaThietBi_KKTL_KHTT'
UPDATE DS_REPORT SET TEN_REPORT_VIET = N'Lịch bảo trì định kỳ năm theo địa điểm, dây chuyền, loại máy - khong in ra du lieu ', TEN_REPORT_ANH = N'Annual maintenance plan', STT =122 , NOTE = N'Kế hoạch bảo trì hằng năm theo dây chuyền, địa điểm, loại thiết bị' WHERE REPORT_NAME = N'ucKeHoachBatTriNamNutifood'