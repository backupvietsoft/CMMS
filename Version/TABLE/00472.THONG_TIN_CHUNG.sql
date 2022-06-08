
if not exists(select * from sys.columns 
            where Name = N'CusID' and Object_ID = Object_ID(N'THONG_TIN_CHUNG'))
begin
    ALTER TABLE dbo.THONG_TIN_CHUNG ADD CusID bigint
END    
GO	
if not exists(select * from sys.columns 
            where Name = N'iConID' and Object_ID = Object_ID(N'THONG_TIN_CHUNG'))
begin
    ALTER TABLE dbo.THONG_TIN_CHUNG ADD iConID bigint
END    
GO	