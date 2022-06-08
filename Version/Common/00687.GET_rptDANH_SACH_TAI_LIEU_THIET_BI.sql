
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GET_rptDANH_SACH_TAI_LIEU_THIET_BI')
   exec('CREATE PROCEDURE GET_rptDANH_SACH_TAI_LIEU_THIET_BI AS BEGIN SET NOCOUNT ON; END')
GO

alter procedure [dbo].[GET_rptDANH_SACH_TAI_LIEU_THIET_BI] 
	@MS_MAY NVARCHAR(30)
AS
SELECT     ROW_NUMBER() OVER(ORDER BY MAY_TAI_LIEU.ms_may DESC) AS STT, TEN_TAI_LIEU, NOI_LUU_TRU from MAY_TAI_LIEU 

where MS_MAY = @MS_MAY               