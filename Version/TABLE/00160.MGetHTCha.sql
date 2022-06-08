IF OBJECT_ID (N'MGetHTCha', N'IF') IS NOT NULL  
    DROP FUNCTION MGetHTCha;  
GO  

--	SELECT * FROM [dbo].MGetHTCha(0) order by MS_HE_THONG

CREATE FUNCTION MGetHTCha
    (@NNgu int)
RETURNS TABLE 
AS RETURN
with cte(MS_HE_THONG, MS_CHA,[ALL_CHA],TEN_HE_THONG)
AS 
(
select MS_HE_THONG,MS_CHA , CAST('' AS VARCHAR(8000))  AS ALL_CHA,
CASE @NNgu WHEN 0 THEN TEN_HE_THONG WHEN 1 THEN TEN_HE_THONG_ANH ELSE TEN_HE_THONG_HOA END AS TEN_HE_THONG
from 
dbo.HE_THONG
where MS_CHA is null 
UNION ALL
select A.MS_HE_THONG, A.MS_CHA,cast ((B.ALL_CHA + cast(A.MS_CHA as varchar(10)) +'; ') as varchar(8000)),
CASE @NNgu WHEN 0 THEN A.TEN_HE_THONG WHEN 1 THEN A.TEN_HE_THONG_ANH ELSE A.TEN_HE_THONG_HOA END AS TEN_HE_THONG
from 
dbo.HE_THONG A 
inner join cte B
ON A.MS_CHA=B.MS_HE_THONG
) 
select MS_HE_THONG, CASE substring(ALL_CHA,0,LEN(ALL_CHA)) WHEN '' THEN MS_HE_THONG ELSE substring(ALL_CHA,0,LEN(ALL_CHA)) END  AS HT_CHA,TEN_HE_THONG from cte 

