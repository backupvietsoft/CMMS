
--EXEC GetHeThongAll 1,'ADMIN',1
ALTER proc [dbo].[GetHeThongAll]
	@CoALL bit,
	@UserName nvarchar(50),
	@NNgu INT
AS


if @CoALL = 0
BEGIN
	SELECT DISTINCT    H.MS_HE_THONG, 
	CASE @NNgu WHEN 0 THEN H.TEN_HE_THONG WHEN 1 THEN ISNULL(NULLIF (H.TEN_HE_THONG_ANH, ''), H.TEN_HE_THONG) 
							 ELSE ISNULL(NULLIF (H.TEN_HE_THONG_HOA, ''), H.TEN_HE_THONG) END AS TEN_HE_THONG,
							 ISNULL(STT,9999) AS STT 
	FROM    dbo.HE_THONG AS H INNER JOIN
			dbo.NHOM_HE_THONG AS NT ON H.MS_HE_THONG = NT.MS_HE_THONG INNER JOIN
			dbo.USERS ON NT.GROUP_ID = dbo.USERS.GROUP_ID  
	WHERE     (dbo.USERS.USERNAME = @UserName OR @UserName = '-1')
	ORDER BY ISNULL(STT,9999) , 	CASE @NNgu WHEN 0 THEN H.TEN_HE_THONG WHEN 1 THEN ISNULL(NULLIF (H.TEN_HE_THONG_ANH, ''), H.TEN_HE_THONG) 
							 ELSE ISNULL(NULLIF (H.TEN_HE_THONG_HOA, ''), H.TEN_HE_THONG) END 
	
END
else
BEGIN
	SELECT DISTINCT H.MS_HE_THONG, 
	CASE @NNgu WHEN 0 THEN H.TEN_HE_THONG WHEN 1 THEN ISNULL(NULLIF (H.TEN_HE_THONG_ANH, ''), H.TEN_HE_THONG) 
							 ELSE ISNULL(NULLIF (H.TEN_HE_THONG_HOA, ''), H.TEN_HE_THONG) END AS TEN_HE_THONG,
	ISNULL(STT,9999) AS STT  
	FROM	dbo.HE_THONG AS H INNER JOIN
			dbo.NHOM_HE_THONG AS NT ON H.MS_HE_THONG = NT.MS_HE_THONG INNER JOIN
			dbo.USERS ON NT.GROUP_ID = dbo.USERS.GROUP_ID 
	WHERE     (dbo.USERS.USERNAME = @UserName OR @UserName = '-1')
UNION
	SELECT '-1', ' < ALL > ' ,-1
	ORDER BY ISNULL(STT,9999), 
		CASE @NNgu WHEN 0 THEN H.TEN_HE_THONG WHEN 1 THEN ISNULL(NULLIF (H.TEN_HE_THONG_ANH, ''), H.TEN_HE_THONG) 
							 ELSE ISNULL(NULLIF (H.TEN_HE_THONG_HOA, ''), H.TEN_HE_THONG) END 



END