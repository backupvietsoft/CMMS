﻿
UPDATE dbo.MENU SET MENU_TEXT = N'9.4. Help',MENU_ENGLISH = N'9.4. Help', MENU_INDEX =4 WHERE MENU_ID = 'mnuHelp1'
GO	
UPDATE dbo.MENU SET MENU_LINE = 1, MENU_TEXT = N'9.5. Cập nhật bản mới',MENU_ENGLISH = N'9.5. Check for Update', MENU_INDEX =5 WHERE MENU_ID = 'mnuUpdate'
GO	
UPDATE dbo.MENU SET MENU_TEXT = N'9.6. About',MENU_ENGLISH = N'9.6. About', MENU_INDEX =6 WHERE MENU_ID = 'mnuAbout'
GO	
UPDATE dbo.MENU SET MENU_LINE = 1 WHERE MENU_ID = 'mnuELearning'