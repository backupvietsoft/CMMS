IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GL_ACOUNT]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[GL_ACOUNT](
		[MS_GL] [nvarchar](50) NOT NULL,
		[TEN_GL] [nvarchar](250) NULL,
		[MS_CHA] [nvarchar](20) NULL,
	 CONSTRAINT [PK_GL_ACOUNT] PRIMARY KEY CLUSTERED 
	(
		[MS_GL] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

END


