if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG' AND TABLE_SCHEMA = 'dbo')
BEGIN    

CREATE TABLE [dbo].[PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG](
	[MS_PHIEU_BAO_TRI] [nvarchar](20) NOT NULL,
	[STT] [int] NOT NULL,
	[MS_PT] [nvarchar](25) NOT NULL,
	[SL_KH] [float] NULL,
	[SL_TT] [float] NULL,
	[GHI_CHU] [nvarchar](255) NULL,
	[MS_PT_TT] [nvarchar](25) NOT NULL
 CONSTRAINT [PK_PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG] PRIMARY KEY CLUSTERED 
(
	[MS_PHIEU_BAO_TRI] ASC,
	[STT] ASC,
	[MS_PT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


END 

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[FK_PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG_IC_PHU_TUNG]') )
BEGIN
ALTER TABLE [dbo].[PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG_IC_PHU_TUNG] FOREIGN KEY([MS_PT])
REFERENCES [dbo].[IC_PHU_TUNG] ([MS_PT])

ALTER TABLE [dbo].[PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG] CHECK CONSTRAINT [FK_PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG_IC_PHU_TUNG]

ALTER TABLE [dbo].[PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG_PHIEU_BAO_TRI_CV_PHU_TRO] FOREIGN KEY([MS_PHIEU_BAO_TRI], [STT])
REFERENCES [dbo].[PHIEU_BAO_TRI_CV_PHU_TRO] ([MS_PHIEU_BAO_TRI], [STT])
ON UPDATE CASCADE

END
