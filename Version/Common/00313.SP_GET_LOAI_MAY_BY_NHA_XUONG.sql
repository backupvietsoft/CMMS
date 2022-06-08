
--EXEC [SP_GET_LOAI_MAY_BY_NHA_XUONG] 'ADMIN','-1','-1','-1','-1'
ALTER PROC [dbo].[SP_GET_LOAI_MAY_BY_NHA_XUONG]
	@USERNAME NVARCHAR(100),
	@MS_NHA_XUONG nvarchar(50),
	 @MS_TINH NVARCHAR(100),
	 @MS_QUAN NVARCHAR(100),
	 @MS_DUONG NVARCHAR(100)
AS
DECLARE @GROUP nvarchar(10)
SET @GROUP= isnull((SELECT [dbo].[Get_GroupID] (@USERNAME)),0)

DECLARE @SQL VARCHAR(8000)	

	SET @SQL='IF EXISTS (SELECT * FROM SYSOBJECTS WHERE [NAME] =' + CHAR(39) +'LOAI_MAY_NHA_XUONG_TEMP' +  @USERNAME + CHAR(39) + ' AND XTYPE = ''U'' )
			BEGIN DROP TABLE LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+' END
		
			
			IF '''+@MS_NHA_XUONG+'''=''-1''
			BEGIN
				SELECT MS_N_XUONG  INTO LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+' FROM NHA_XUONG 
				END
ELSE
BEGIN
CREATE TABLE LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+'(MS_N_XUONG NVARCHAR(50))
DECLARE @NewInsertCount int;
INSERT INTO LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+'(MS_N_XUONG)
SELECT MS_N_XUONG FROM NHA_XUONG  WHERE MS_N_XUONG =' + CHAR(39) + @MS_NHA_XUONG + CHAR(39)+ ';
SET @NewInsertCount = @@ROWCOUNT;
WHILE @NewInsertCount > 0
BEGIN
   
    INSERT INTO LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+'(MS_N_XUONG) 
        SELECT MS_N_XUONG FROM NHA_XUONG  WHERE EXISTS
               (SELECT MS_N_XUONG  FROM LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+'
                WHERE NHA_XUONG.MS_CHA = LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+'.MS_N_XUONG)
         AND  NOT EXISTS
              (SELECT MS_N_XUONG FROM LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+'
               WHERE NHA_XUONG.MS_N_XUONG  = LOAI_MAY_NHA_XUONG_TEMP'+@USERNAME+'.MS_N_XUONG);    
    
         SET @NewInsertCount = @@ROWCOUNT;
       
END
END
'
EXEC (@SQL) 


SET @SQL='
SELECT TEMP.* FROM
(
	SELECT 
		   TEMP.MS_N_XUONG,MS_MAY
		  ,MS_TINH=[dbo].[Get_CityCode](NHA_XUONG.MS_QG),MS_QUAN = NHA_XUONG.MS_QG,NHA_XUONG.MS_DUONG
		  ,TEMP.MS_NHOM_MAY,TEMP.MS_LOAI_MAY,TEMP.TEN_LOAI_MAY
	FROM 
	(
	SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY,TEN_LOAI_MAY , MAY_NHA_XUONG.MS_N_XUONG,NHOM_MAY.MS_NHOM_MAY,GIAM_SAT_TINH_TRANG_TS.MS_MAY
			 FROM GIAM_SAT_TINH_TRANG_TS INNER JOIN MAY ON GIAM_SAT_TINH_TRANG_TS.MS_MAY=MAY.MS_MAY  
			 INNER JOIN MAY_NHA_XUONG ON MAY.MS_MAY =MAY_NHA_XUONG.MS_MAY   
			 AND MAY_NHA_XUONG.NGAY_NHAP =(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY =GIAM_SAT_TINH_TRANG_TS.MS_MAY)  
			 INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY   
			 INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY  
			 INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY  
			 INNER JOIN NHOM ON NHOM.GROUP_ID=' + CHAR(39) + @GROUP  + CHAR(39) + ' AND NHOM_LOAI_MAY.GROUP_ID=' + CHAR(39) + @GROUP  + CHAR(39) + ' 
			 INNER JOIN NHOM_NHA_XUONG ON NHOM_NHA_XUONG.GROUP_ID='+ CHAR(39) + @GROUP  + CHAR(39) +'  
			 INNER JOIN USERS ON USERS.GROUP_ID='+ CHAR(39) + @GROUP  + CHAR(39) +' 
			 WHERE USERS.USERNAME=' + CHAR(39) + @USERNAME + CHAR(39) +'
	)TEMP INNER JOIN NHA_XUONG ON NHA_XUONG.MS_N_XUONG = TEMP.MS_N_XUONG
)TEMP WHERE MS_N_XUONG IN (SELECT MS_N_XUONG FROM LOAI_MAY_NHA_XUONG_TEMP'+ @USERNAME +')'
IF @MS_TINH <>'-1'
	SET @SQL=@SQL + ' AND TEMP.MS_TINH=' + CHAR(39) + @MS_TINH + CHAR(39)
IF @MS_QUAN <>'-1' 
 SET @SQL=@SQL + ' AND TEMP.MS_QUAN=' + CHAR(39) + @MS_QUAN  + CHAR(39)
 IF @MS_DUONG <>'-1' 
 SET @SQL=@SQL + ' AND TEMP.MS_DUONG=' + CHAR(39) + @MS_DUONG  + CHAR(39)
 SET @SQL=@SQL +'ORDER BY TEMP.TEN_LOAI_MAY'
 EXEC (@SQL)
