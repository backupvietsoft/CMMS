

DELETE dbo.NHOM_MENU WHERE MENU_ID = 'mnuPhanTichNNNMTheoNN'
go
DELETE MENU WHERE MENU_ID = 'mnuPhanTichNNNMTheoNN'
go
UPDATE dbo.MENU SET FUNCTION_NAME = N'ShowPhanTichNNNMTheoNN',MENU_PARENT = 'mnuSudung' WHERE MENU_ID = 'mnuPhanTichNNNM'


