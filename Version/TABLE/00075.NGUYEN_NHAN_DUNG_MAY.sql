
ALTER TABLE NGUYEN_NHAN_DUNG_MAY ALTER COLUMN TEN_NGUYEN_NHAN NVARCHAR(250) 
GO

if not exists(select * from sys.columns 
            where Name = N'TEN_NGUYEN_NHAN_ANH' and Object_ID = Object_ID(N'NGUYEN_NHAN_DUNG_MAY'))
begin
    ALTER TABLE NGUYEN_NHAN_DUNG_MAY ADD TEN_NGUYEN_NHAN_ANH NVARCHAR(250) 
END    

GO
UPDATE NGUYEN_NHAN_DUNG_MAY SET TEN_NGUYEN_NHAN_ANH = TEN_NGUYEN_NHAN WHERE ISNULL(TEN_NGUYEN_NHAN_ANH,'') = ''

GO

if not exists(select * from sys.columns 
            where Name = N'MAC_DINH' and Object_ID = Object_ID(N'NGUYEN_NHAN_DUNG_MAY'))
begin
	ALTER TABLE NGUYEN_NHAN_DUNG_MAY
	ADD MAC_DINH BIT 
	CONSTRAINT DF_NGUYEN_NHAN_DUNG_MAY_MAC_DINH DEFAULT 0 WITH VALUES
END    

GO
UPDATE NGUYEN_NHAN_DUNG_MAY SET MAC_DINH = 0 WHERE MAC_DINH IS NULL