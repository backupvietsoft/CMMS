CREATE TABLE [dbo].[SYN_TB_NHAP_KHO_INTEGRATION](
	[STT] [bigint] IDENTITY(1,1) NOT NULL,
	[MS_DH_NHAP_PT] [nvarchar](14) NOT NULL,
	[SO_PHIEU_XN] [nvarchar](20) NULL,
	[GIO] [datetime] NULL,
	[ROW_ID] [bigint] NULL,
	[NGAY] [datetime] NULL,
	[MS_KHO] [nchar](10) NULL,
	[MS_VI_TRI] [int] NULL,
	[MS_PT] [nvarchar](25) NULL,
	[SO_LUONG_CTU] [float] NULL,
	[SL_THUC_NHAP] [float] NULL,
	[DON_GIA] [float] NULL,
	[THANH_TIEN] [float] NULL,
	[MS_DANG_NHAP] [int] NULL,
	[DANG_NHAP_VIET] [nvarchar](255) NULL,
	[NGUOI_NHAP] [nvarchar](20) NULL,
	[NGAY_CHUNG_TU] [datetime] NULL,
	[SO_CHUNG_TU] [nvarchar](255) NULL,
	[GHI_CHU] [nvarchar](255) NULL,
	[THU_KHO] [nvarchar](50) NULL,
	[MS_DDH] [nvarchar](30) NULL,
	[SO_DE_XUAT] [nvarchar](50) NULL,
	[NGUOI_GIAO] [nvarchar](100) NULL,
	[LY_DO] [nvarchar](255) NULL,
	[CAN_CU] [nvarchar](255) NULL,
	[THU_KHO_KY] [nvarchar](100) NULL,
	[NGUOI_LAP] [nvarchar](20) NULL,
	[BAO_HANH_DEN_NGAY] [datetime] NULL,
	[XUAT_XU] [nvarchar](50) NULL,
	[TAX] [float] NULL,
	[MS_KH] [varchar](20) NULL,
	[TEN_VI_TRI_1] [nvarchar](255) NULL,
	[TEN_VI_TRI_2] [nvarchar](255) NULL,
	[TEN_VI_TRI_3] [nvarchar](255) NULL,
	[INSERT_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[DA_CHUYEN] [bit] NULL,
	[NGAY_CHUYEN] [datetime] NULL,
	[STT_SYN] [bigint] NULL,
 CONSTRAINT [PK_TB_NHAP_KHO] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[SYN_TB_NHAP_KHO_INTEGRATION] ADD  CONSTRAINT [DF_SYN_TB_NHAP_KHO_DA_CHUYEN]  DEFAULT ((0)) FOR [DA_CHUYEN]



