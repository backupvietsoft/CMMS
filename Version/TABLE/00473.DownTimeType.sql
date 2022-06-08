--thêm table DowtimeType
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = N'DownTimeType')
BEGIN
	CREATE TABLE [dbo].[DownTimeType]
	(
	[ID] [int] NOT NULL IDENTITY(1, 1),
	[DownTimeTypeName] [nvarchar] (250)  NULL,
	[DownTimeTypeNameA] [nvarchar] (250)  NULL,
	[DownTimeTypeNameH] [nvarchar] (250)  NULL,
	[Note] [nvarchar] (500)  NULL,
	[Planned] [bit] NULL,
	[Active] BIT NULL) ON [PRIMARY]

	ALTER TABLE [dbo].[DownTimeType] ADD CONSTRAINT [PK_DownTimeType] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
END

-- thêm colums DownTimeTypeID và active cho table nguyen nhân ngừng mấy
if not exists(select * from sys.columns 
            where Name = N'DownTimeTypeID' and Object_ID = Object_ID(N'NGUYEN_NHAN_DUNG_MAY'))
begin
    ALTER TABLE dbo.NGUYEN_NHAN_DUNG_MAY ADD DownTimeTypeID INT

	ALTER TABLE dbo.NGUYEN_NHAN_DUNG_MAY
	ADD CONSTRAINT fk_NGUYEN_NHAN_DUNG_MAY_DownTimeType FOREIGN KEY (DownTimeTypeID) REFERENCES DownTimeType (ID);
END    
GO	
if not exists(select * from sys.columns 
            where Name = N'Active' and Object_ID = Object_ID(N'NGUYEN_NHAN_DUNG_MAY'))
begin
    ALTER TABLE dbo.NGUYEN_NHAN_DUNG_MAY ADD Active BIT
END    
GO	
--thêm colums cho THOI_GIAN_NGUNG_MAY
if not exists(select * from sys.columns 
            where Name = N'ID' and Object_ID = Object_ID(N'THOI_GIAN_NGUNG_MAY'))
BEGIN
    ALTER TABLE dbo.THOI_GIAN_NGUNG_MAY ADD ID  BIGINT NOT NULL IDENTITY(1, 1)
	ALTER TABLE [dbo].[THOI_GIAN_NGUNG_MAY] ADD CONSTRAINT [PK_THOI_GIAN_NGUNG_MAY] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY] 
END    
GO	

if not exists(select * from sys.columns 
            where Name = N'ID_CHA' and Object_ID = Object_ID(N'THOI_GIAN_NGUNG_MAY'))
begin
    ALTER TABLE dbo.THOI_GIAN_NGUNG_MAY ADD ID_CHA BIGINT
END    
GO


if not exists(select * from sys.columns 
            where Name = N'ID_CHA' and Object_ID = Object_ID(N'THOI_GIAN_NGUNG_MAY'))
begin
    ALTER TABLE dbo.THOI_GIAN_NGUNG_MAY ADD ID_CHA BIT
END    
GO

if not exists(select * from sys.columns 
            where Name = N'MS_PHIEU_BAO_TRI' and Object_ID = Object_ID(N'THOI_GIAN_NGUNG_MAY'))
begin
    ALTER TABLE dbo.THOI_GIAN_NGUNG_MAY ADD MS_PHIEU_BAO_TRI NVARCHAR(20)
END    
GO

if not exists(select * from sys.columns 
            where Name = N'MS_TO' and Object_ID = Object_ID(N'THOI_GIAN_NGUNG_MAY'))
begin
    ALTER TABLE dbo.THOI_GIAN_NGUNG_MAY ADD MS_TO INT
END    
GO

if not exists(select * from sys.columns 
            where Name = N'LOCK' and Object_ID = Object_ID(N'THOI_GIAN_NGUNG_MAY'))
begin
    ALTER TABLE dbo.THOI_GIAN_NGUNG_MAY ADD LOCK BIT
END    
GO

if not exists(select * from sys.columns 
            where Name = N'ID_TGNM' and Object_ID = Object_ID(N'THOI_GIAN_NGUNG_MAY_PHU_TUNG'))
begin
    ALTER TABLE dbo.THOI_GIAN_NGUNG_MAY_PHU_TUNG ADD ID_TGNM BIGINT
END    
GO

