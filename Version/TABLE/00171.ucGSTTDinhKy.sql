--Khi muon insert them 1 report vdu report "ucBangKePBT" thi ma hoa ra rui dem vao key
--SELECT * FROM dbo.LOAI_REPORT
DECLARE @Report nvarchar(500)
DECLARE @Report1 nvarchar(500)
DECLARE @LoaiRP INT
SET @LoaiRP = 8
SET @Report1 = N'ucGSTTDinhKy'
set @Report = N'ήΊ͒ͪͬͬ͌ΖΠΔ͚ζ'


IF NOT EXISTS (SELECT * FROM LIC_REPORT WHERE REPORT_NAME = @Report)
INSERT INTO LIC_REPORT (REPORT_NAME,TYPE_LIC) VALUES ( @Report,N'̦')
	


IF NOT EXISTS (SELECT * FROM DS_REPORT WHERE REPORT_NAME = @Report1)
INSERT INTO DS_REPORT(REPORT_NAME,TEN_REPORT_VIET,TEN_REPORT_ANH, LOAI_REPORT,STT,NOTE,NAMES,[TYPE],REPORT_MAIL)
VALUES(@Report1, N'Lịch giám sát tình trạng định kỳ',N'Periodic condition monitoring schedule  ',@LoaiRP,
(SELECT ISNULL(MAX(STT),0) + 1 FROM DS_REPORT WHERE LOAI_REPORT = 8 AND	STT < 100)
,N'Tính lịch xích giám sát tình trạng rồi in ra kế hoạch cho từng máy theo từng thông số giám sát. Báo cáo Excel.',@Report1,1,1)


IF NOT EXISTS (SELECT * FROM NHOM_REPORT WHERE REPORT_NAME = @Report1)
INSERT INTO NHOM_REPORT(REPORT_NAME,GROUP_ID,QUYEN)
VALUES(@Report1, 1,N'Access')

