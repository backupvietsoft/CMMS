﻿DECLARE @iSTT BIGINT = 1351
DECLARE @iLoai INT = 1

--1	Khi nhập yêu cầu bảo trì
--2	Khi duyệt yêu cầu bảo trì
--3	Khi tiếp nhận yêu cầu bảo trì

DECLARE @sMail NVARCHAR(2000)
SET @sMail = ''

SELECT   @sMail = COALESCE(ISNULL(@sMail,'') + CASE LEN(@sMail) WHEN 0 THEN '' ELSE '; ' END , '') + ISNULL(MAIL_NSD,'')  
FROM     (  
SELECT        
ISNULL(T3.USER_MAIL,'') + CASE ISNULL(T3.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
ISNULL(T1.EMAIL_NSD,'') + CASE ISNULL(T1.EMAIL_NSD,'') WHEN '' THEN '' ELSE '; ' END  + 
ISNULL(T5.USER_MAIL,'') + CASE ISNULL(T5.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
ISNULL(T2.EMAIL_DSX,'') + CASE ISNULL(T2.EMAIL_DSX,'') WHEN '' THEN '' ELSE '; ' END  + 
ISNULL(T4.USER_MAIL,'') + CASE ISNULL(T4.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
ISNULL(T2.EMAIL_DBT,'') + CASE ISNULL(T2.EMAIL_DBT,'') WHEN '' THEN '' ELSE '; ' END  AS MAIL_NSD
FROM            dbo.USERS AS T4 RIGHT OUTER JOIN
    dbo.YEU_CAU_NSD_CHI_TIET AS T2 ON T4.USERNAME = T2.USERNAME_DBT LEFT OUTER JOIN
    dbo.USERS AS T5 ON T2.USERNAME_DSX = T5.USERNAME RIGHT OUTER JOIN
    dbo.YEU_CAU_NSD AS T1 LEFT OUTER JOIN
    dbo.USERS AS T3 ON T1.USER_LAP = T3.USERNAME ON T2.STT = T1.STT 
WHERE        (T2.MS_PBT = 'WO-202010000003'  )
) A
 

IF @iLoai =1 
BEGIN
--Lấy mail theo to phong ban nguoi yeu cau
	DECLARE @sMailYC NVARCHAR(MAX) = ''
    SELECT @sMailYC = dbo.GetMailTheoUserYCSD (@iSTT)
	SET @sMail = @sMail + ISNULL(@sMailYC,'') + CASE ISNULL(@sMailYC,'') WHEN '' THEN '' ELSE '; ' END
END
SELECT @sMail 
