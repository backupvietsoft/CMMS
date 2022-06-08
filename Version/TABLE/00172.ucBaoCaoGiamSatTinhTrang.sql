--Khi muon insert them 1 report vdu report "ucBangKePBT" thi ma hoa ra rui dem vao key
--SELECT * FROM dbo.LOAI_REPORT
DECLARE @Report nvarchar(500)
DECLARE @Report1 nvarchar(500)
DECLARE @LoaiRP INT
SET @LoaiRP = 8
SET @Report1 = N'ucBaoCaoGiamSatTinhTrang'
set @Report = N'ήΊ͈Ά΢͊Ά΢͒ΖΆΞͪΆάͬΖΠΔͬΨΆΠΒ'


IF NOT EXISTS (SELECT * FROM LIC_REPORT WHERE REPORT_NAME = @Report)
INSERT INTO LIC_REPORT (REPORT_NAME,TYPE_LIC) VALUES ( @Report,N'̦')
	
	--Lịch hiệu chuẩn và kiểm định theo năm

IF NOT EXISTS (SELECT * FROM DS_REPORT WHERE REPORT_NAME = @Report1)
INSERT INTO DS_REPORT(REPORT_NAME,TEN_REPORT_VIET,TEN_REPORT_ANH, LOAI_REPORT,STT,NOTE,NAMES,[TYPE],REPORT_MAIL)
VALUES(@Report1, N'Lịch giám sát tình trạng theo năm',N'Periodic condition monitoring by year',@LoaiRP,
(SELECT ISNULL(MAX(STT),0) + 1 FROM DS_REPORT WHERE LOAI_REPORT = 8 AND	STT < 100)
,N'Lịch giám sát tình trạng theo năm. Báo cáo Excel.',@Report1,1,1)


IF NOT EXISTS (SELECT * FROM NHOM_REPORT WHERE REPORT_NAME = @Report1)
INSERT INTO NHOM_REPORT(REPORT_NAME,GROUP_ID,QUYEN)
VALUES(@Report1, 1,N'Access')
