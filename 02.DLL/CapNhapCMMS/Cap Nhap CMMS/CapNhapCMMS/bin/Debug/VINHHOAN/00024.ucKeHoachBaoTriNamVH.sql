-- FORM-- Kế hoạch kiểm tra bảo dưỡng tổng thể 

UPDATE LANGUAGES SET VIETNAM = N'FOR-6004' , ENGLISH = N'FOR-6004',CHINESE= N'FOR-6004' ,VIETNAM_OR = N'FOR-6004' , ENGLISH_OR = N'FOR-6004' ,CHINESE_OR= N'FOR-6004'
 WHERE FORM = 'ucKeHoachBaoTriNamVH' AND KEYWORD = 'bcMaSo1'

UPDATE LANGUAGES SET VIETNAM = N'Mã số:' , ENGLISH = N'Mã số:',CHINESE= N'Mã số:' ,VIETNAM_OR = N'Mã số:' , ENGLISH_OR = N'Mã số:' ,CHINESE_OR= N'Mã số:'
 WHERE FORM = 'ucKeHoachBaoTriNamVH' AND KEYWORD = 'bcMaSo'

UPDATE LANGUAGES SET VIETNAM = N'Phê duyệt' , ENGLISH = N'Approve by',CHINESE= N'Mã số:' ,
					VIETNAM_OR = N'Phê duyệt' , ENGLISH_OR = N'Approve by' ,CHINESE_OR= N'Phê duyệt'
WHERE FORM = 'ucKeHoachBaoTriNamVH' AND KEYWORD = 'bcThamTra'


	
	
	
SELECT * FROM LANGUAGES WHERE VIETNAM like N'%6038%'	