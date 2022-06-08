

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'rptKE_HOACH_THUC_HIEN') AND type in (N'U'))
	DROP TABLE rptKE_HOACH_THUC_HIEN

GO

CREATE TABLE [dbo].rptKE_HOACH_THUC_HIEN ( TEN_CONG_VIEC NVARCHAR(255),THOI_GIAN_DK FLOAT, 
					NGAY DATETIME,THOI_HAN DATETIME,GHI_CHU NVARCHAR(255),UU_TIEN NVARCHAR(50),
					USER_LAST NVARCHAR(50),THOI_GIAN_SUA DATETIME,PREVIOUS_USER NVARCHAR(50) ,  TU_GIO DATETIME ,  
					DEN_GIO DATETIME ,  SPHUT FLOAT )
GO


ALTER procedure [dbo].[InsertKE_HOACH_THUC_HIEN]
	@MS_CN NVARCHAR(9),
	@NGAY NVARCHAR(10),
	@DEN_NGAY NVARCHAR(10),
	@HOAN_THANH BIT
AS
	IF @HOAN_THANH=0
	BEGIN
	INSERT INTO rptKE_HOACH_THUC_HIEN
	SELECT dbo.KE_HOACH_THUC_HIEN.TEN_CONG_VIEC, dbo.KE_HOACH_THUC_HIEN.THOI_GIAN_DK, dbo.KE_HOACH_THUC_HIEN.NGAY, 
       		dbo.KE_HOACH_THUC_HIEN.THOI_HAN,dbo.KE_HOACH_THUC_HIEN.GHI_CHU, dbo.MUC_UU_TIEN.TEN_UU_TIEN AS UU_TIEN, dbo.KE_HOACH_THUC_HIEN.USER_LAST, 
 		dbo.KE_HOACH_THUC_HIEN.THOI_GIAN_SUA ,	 dbo.KE_HOACH_THUC_HIEN.PREVIOUS_USER , TU_GIO, DEN_GIO,SPHUT
        	FROM   dbo.KE_HOACH_THUC_HIEN LEFT JOIN 
              	dbo.MUC_UU_TIEN ON dbo.KE_HOACH_THUC_HIEN.MS_UU_TIEN = dbo.MUC_UU_TIEN.MS_UU_TIEN 
        	WHERE dbo.KE_HOACH_THUC_HIEN.MS_CONG_NHAN =@MS_CN  AND dbo.KE_HOACH_THUC_HIEN.NGAY <=  CONVERT(DATETIME,@NGAY,103) AND  
             		 (dbo.KE_HOACH_THUC_HIEN.DA_XONG = 0) 
        	ORDER BY dbo.KE_HOACH_THUC_HIEN.THOI_GIAN_SUA, dbo.KE_HOACH_THUC_HIEN.STT
	END
	ELSE
	BEGIN
	INSERT INTO rptKE_HOACH_THUC_HIEN
	SELECT dbo.KE_HOACH_THUC_HIEN.TEN_CONG_VIEC, dbo.KE_HOACH_THUC_HIEN.THOI_GIAN_DK, dbo.KE_HOACH_THUC_HIEN.NGAY, 
	       	dbo.KE_HOACH_THUC_HIEN.THOI_HAN,dbo.KE_HOACH_THUC_HIEN.GHI_CHU, dbo.MUC_UU_TIEN.TEN_UU_TIEN AS UU_TIEN, dbo.KE_HOACH_THUC_HIEN.USER_LAST, 
	 	dbo.KE_HOACH_THUC_HIEN.THOI_GIAN_SUA ,	 dbo.KE_HOACH_THUC_HIEN.PREVIOUS_USER , TU_GIO, DEN_GIO,SPHUT
        	FROM   dbo.KE_HOACH_THUC_HIEN LEFT JOIN 
              	 dbo.MUC_UU_TIEN ON dbo.KE_HOACH_THUC_HIEN.MS_UU_TIEN = dbo.MUC_UU_TIEN.MS_UU_TIEN 
       	 WHERE dbo.KE_HOACH_THUC_HIEN.MS_CONG_NHAN =@MS_CN  AND dbo.KE_HOACH_THUC_HIEN.NGAY BETWEEN  CONVERT(DATETIME,@NGAY,103)  AND CONVERT(DATETIME,@DEN_NGAY,103)
 		 AND   (dbo.KE_HOACH_THUC_HIEN.DA_XONG =1) 
       	 ORDER BY dbo.KE_HOACH_THUC_HIEN.THOI_GIAN_SUA, dbo.KE_HOACH_THUC_HIEN.STT
	END
