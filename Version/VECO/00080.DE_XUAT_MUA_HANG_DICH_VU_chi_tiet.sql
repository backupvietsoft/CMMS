if not exists(select * from sys.columns 
            where Name = N'IMAGES' and Object_ID = Object_ID(N'DE_XUAT_MUA_HANG_DICH_VU'))
begin
    ALTER TABLE DE_XUAT_MUA_HANG_DICH_VU ADD IMAGES BINARY
END   
if not exists(select * from sys.columns 
            where Name = N'IMAGES' and Object_ID = Object_ID(N'DE_XUAT_MUA_HANG_CHI_TIET'))
begin
    ALTER TABLE DE_XUAT_MUA_HANG_CHI_TIET ADD IMAGES BINARY
END   