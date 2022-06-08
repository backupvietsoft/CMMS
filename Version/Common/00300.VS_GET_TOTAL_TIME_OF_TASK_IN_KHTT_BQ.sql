IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'FN' AND name = 'VS_GET_TOTAL_TIME_OF_TASK_IN_KHTT_BQ')
   exec('CREATE FUNCTION  dbo.VS_GET_TOTAL_TIME_OF_TASK_IN_KHTT_BQ () RETURNS  nvarchar(50) as Begin return null end')
GO


ALTER function [dbo].[VS_GET_TOTAL_TIME_OF_TASK_IN_KHTT_BQ]
(
 @HANG_MUC_ID INT
)
returns FLOAT
as 
begin
DECLARE @TOTAL_TIME FLOAT

SELECT @TOTAL_TIME= ( SELECT SUM(ISNULL(THOI_GIAN_DU_KIEN,0)) 
					  FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID = @HANG_MUC_ID
					  AND  (KE_HOACH_TONG_CONG_VIEC.THUE_NGOAI = 1) AND (KE_HOACH_TONG_CONG_VIEC.MS_PHIEU_BAO_TRI IS NULL) AND (KE_HOACH_TONG_CONG_VIEC.EOR_ID IS NULL) OR
				  (KE_HOACH_TONG_CONG_VIEC.MS_PHIEU_BAO_TRI IS NULL) AND (KE_HOACH_TONG_CONG_VIEC.EOR_ID IS NULL) AND (KE_HOACH_TONG_CONG_VIEC.KHONG_GQ = 1) )

return ISNULL(@TOTAL_TIME,0)
end
