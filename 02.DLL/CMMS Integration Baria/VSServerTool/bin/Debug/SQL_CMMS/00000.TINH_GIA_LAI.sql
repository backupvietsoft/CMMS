

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TINH_GIA_LAI]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[TINH_GIA_LAI](
		[THANG_NAM] [datetime] NOT NULL,
		[NGAY_KHOA_SO] [datetime] NULL,
		[MS_KHO] [int] NULL,
		[MS_PT] [nvarchar](25) NULL,
		[DON_GIA] [float] NULL,
	 CONSTRAINT [PK_TINH_GIA_LAI] PRIMARY KEY CLUSTERED 
	(
		[THANG_NAM] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

