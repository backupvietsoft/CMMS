-----vi du insert menu
go
INSERT [dbo].[MENU] ([MENU_ID], [MENU_TEXT], [MENU_ENGLISH], [MENU_CHINESE], [MENU_PARENT], [MENU_LINE], [MENU_INDEX], [SHORT_KEY], [DLL_NAME], [CLASS_NAME], [FUNCTION_NAME], [CUSTUMER], [NOTE], [MENU_IMAGE], [PROJECT_NAME], [MENU_NOTE], [MENU_FONT], [MENU_POSITION], [MENU_TYPE], [AN_HIEN])
 VALUES (N'mnuAllocate', N'  6.30.  Allocate Bộ phận chịu phí', N'  6.30.  Allocate Bộ phận chịu phí', NULL, N'mnuQuanlykho', 0, 11, NULL, NULL, N'frmMain', N'ShowPhanBoChoBPCPSyn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT INTO NHOM_MENU SELECT 1, N'mnuAllocate'
go
go
INSERT INTO dbo.LIC_MENU
           ([TYPE_LIC]
           ,[MENU_ID])
     VALUES
           (N'̦'
           ,N'ΞΠή͆ΜΜ΢ΊΆάΎ')
GO

-----vi du chi tiet form
GO
INSERT [dbo].[CHI_TIET_FORMS] ([FORM_NAME], [TEN_FORMS_VIET], [TEN_FORMS_ANH], [TEN_FORMS_HOA], [CUSTUMER], [SHOW_IN], [NOTE])
 VALUES (N'frmAllocateVTPTForBPCP', N'  6.30.  Allocate Bộ phận chịu phí', N'  6.30.  Allocate Bộ phận chịu phí', NULL, NULL, NULL, NULL)
go
INSERT INTO NHOM_FORM
SELECT 1,N'frmAllocateVTPTForBPCP',N'Full access'

go
go
INSERT INTO dbo.LIC_FORM
           ([TYPE_LIC]
           ,[FORM_NAME])
     VALUES
           (N'̦'
           ,N'ΐΨΞ͆ΜΜ΢ΊΆάΎͰͬͤͬ͐΢Ψ͈ͤ͊ͤ')
GO


--select * from menu

