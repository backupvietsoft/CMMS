--DECLARE @t TABLE(form NVARCHAR(2500) ,KEYWORD  NVARCHAR(2500) , STT INT)

--INSERT INTO @t
--SELECT form,KEYWORD ,count(stt) AS STT FROM LANGUAGES B 	group by form,KEYWORD having count(stt) >1

--SELECT MIN(A.STT)  AS STT_MIN,A.FORM,A.KEYWORD  INTO #STT_MIN FROM LANGUAGES A INNER JOIN @t B ON A.FORM = B.form AND A.KEYWORD = B.KEYWORD
--GROUP BY A.FORM,A.KEYWORD 



--DELETE A FROM LANGUAGES A INNER JOIN @t C ON A.FORM = C.FORM AND A.KEYWORD = C.KEYWORD 
--WHERE A.STT NOT IN(
--SELECT DISTINCT STT_MIN FROM #STT_MIN B WHERE  A.FORM = B.FORM AND A.KEYWORD = B.KEYWORD AND A.STT = B.STT_MIN)

