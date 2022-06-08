IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PSDV_TAI_LIEU]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[PSDV_TAI_LIEU](
		[ID_PSDV_TL] [bigint] IDENTITY(1,1) NOT NULL,
		[MS_YEU_CAU] [nvarchar](20) NOT NULL,
		[TAI_LIEU_THAU] [nvarchar](250) NULL,
		[TL_SO] [nvarchar](250) NULL,
		[NOI_DUNG] [nvarchar](250) NULL,
		[GHI_CHU] [nvarchar](250) NULL,
		[DUONG_DAN] [nvarchar](250) NULL,
	 CONSTRAINT [PK_PSDV_TAI_LIEU] PRIMARY KEY CLUSTERED 
	(
		[ID_PSDV_TL] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

