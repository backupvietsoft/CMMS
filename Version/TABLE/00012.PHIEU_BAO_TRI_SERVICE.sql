--ALTER TABLE PHIEU_BAO_TRI_SERVICE ADD COU
if not exists(select * from sys.columns 
            where Name = N'SER_GROUP_CODE' and Object_ID = Object_ID(N'PHIEU_BAO_TRI_SERVICE'))
begin
    ALTER TABLE PHIEU_BAO_TRI_SERVICE ADD SER_GROUP_CODE NVARCHAR(10)
END    

