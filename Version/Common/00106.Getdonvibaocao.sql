
ALTER procedure [dbo].[Getdonvibaocao]
AS
select ms_don_vi,ten_don_vi from  DON_VI 
UNION
SELECT 'ALL',N' < ALL > ' FROM DON_VI
ORDER BY TEN_DON_VI
return
