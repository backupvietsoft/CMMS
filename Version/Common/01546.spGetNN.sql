
 
 IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetNN')
    
 exec('CREATE PROCEDURE spGetNN AS BEGIN SET NOCOUNT ON; END')
 
 GO
 
 
 

ALTER PROCEDURE [dbo].[spGetNN]
	@ModuleName nvarchar(MAX) = 'ECOMAIN',
	@FormName nvarchar(MAX) = 'FrmGSTT_CV',
	@Keyword nvarchar(MAX) = 'btnGhi',
	@NNgu INT = 0
AS	

DECLARE @NN NVARCHAR(MAX) = ''

SELECT @NN = CASE	@NNgu WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END FROM dbo.LANGUAGES WHERE	 MS_MODULE = @ModuleName AND FORM = @FormName AND KEYWORD =  @Keyword 

IF @NN = '' 
BEGIN
	IF ISNUMERIC(@Keyword) = 1 
		SET @NN = @Keyword
	ELSE	
	BEGIN
		INSERT INTO [LANGUAGES]([MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[CHINESE],[FORM_HAY_REPORT],[VIETNAM_OR],[ENGLISH_OR],[CHINESE_OR])
		SELECT TOP 1 [MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[CHINESE],[FORM_HAY_REPORT],[VIETNAM_OR],[ENGLISH_OR],[CHINESE_OR]  FROM (
		SELECT TOP 1 @ModuleName AS [MS_MODULE],@FormName AS [FORM],[KEYWORD],[VIETNAM],[ENGLISH],[CHINESE],0 AS [FORM_HAY_REPORT],[VIETNAM_OR],[ENGLISH_OR],[CHINESE_OR],1 AS STT FROM LANGUAGES WHERE KEYWORD = @Keyword
		UNION
		SELECT TOP 1 @ModuleName AS [MS_MODULE],@FormName AS [FORM],@Keyword AS [KEYWORD], '@' + @Keyword + '@'  AS [VIETNAM], '@' + @Keyword + '@'  AS [ENGLISH],'@' + @Keyword + '@'  AS [CHINESE],0 AS [FORM_HAY_REPORT],'@' + @Keyword + '@' AS [VIETNAM_OR],'@' + @Keyword + '@'  AS [ENGLISH_OR],'@' + @Keyword + '@' AS [CHINESE_OR],2 AS STT  FROM dbo.LANGUAGES 
		) T1 ORDER BY T1.STT,	  T1.VIETNAM DESC	

		SELECT @NN = CASE	@NNgu WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END FROM dbo.LANGUAGES WHERE	 MS_MODULE = @ModuleName AND FORM = @FormName AND KEYWORD =  @Keyword 
	END
END

SELECT	@NN AS NNGU