﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonVatTuXuatKho' AND KEYWORD =N'FrmChonVatTuXuatKho') UPDATE LANGUAGES SET VIETNAM=N'Chọn vật tư, phụ tùng xuất kho', ENGLISH=N'Select items to issue',CHINESE=N'Select items to issue', VIETNAM_OR=N'Chọn vật tư, phụ tùng xuất kho', ENGLISH_OR=N'Select items to issue' , CHINESE_OR=N'Select items to issue' WHERE FORM=N'FrmChonVatTuXuatKho' AND KEYWORD=N'FrmChonVatTuXuatKho' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmChonVatTuXuatKho',N'FrmChonVatTuXuatKho',N'Chọn vật tư, phụ tùng xuất kho',N'Select items to issue',N'Select items to issue',N'Chọn vật tư, phụ tùng xuất kho',N'Select items to issue',N'Select items to issue','ECOMAIN')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmChonVatTuXuatKho' AND KEYWORD =N'lblGhichu') UPDATE LANGUAGES SET VIETNAM=N'( Bạn có thể chọn VTPT bằng cách nhấp đúp vào cái cần chọn)', ENGLISH=N'(You can select item by double clicking on it)',CHINESE=N'(You can select item by double clicking on it)', VIETNAM_OR=N'( Bạn có thể chọn VTPT bằng cách nhấp đúp vào cái cần chọn)', ENGLISH_OR=N'(You can select item by double clicking on it)' , CHINESE_OR=N'(You can select item by double clicking on it)' WHERE FORM=N'FrmChonVatTuXuatKho' AND KEYWORD=N'lblGhichu' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'FrmChonVatTuXuatKho',N'lblGhichu',N'( Bạn có thể chọn VTPT bằng cách nhấp đúp vào cái cần chọn)',N'(You can select item by double clicking on it)',N'(You can select item by double clicking on it)',N'( Bạn có thể chọn VTPT bằng cách nhấp đúp vào cái cần chọn)',N'(You can select item by double clicking on it)',N'(You can select item by double clicking on it)','ECOMAIN')
