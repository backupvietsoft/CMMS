

UPDATE DS_REPORT SET NOTE = N'Có thể in danh sách công việc theo giai đoạn (không quá 31 ngày). Khá tiện dụng cho việc lập kế hoạch bảo trì khi chọn Phiếu bảo trì đang soạn và Đang thực hiện. Nếu PBT chưa phân công nhân sự thì lấy theo ngày kế hoạch của PBT, khi đã có phân công nhân sự thì lấy theo ngày min của nhân sự. Có hiển thị Gantt Chart. Dữ liệu chỉ lấy từ Phiếu bảo trì. Báo cáo dạng Excel '
WHERE REPORT_NAME = 'ucKeHoachBTTuan'