﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmmain' AND KEYWORD =N'msgPhienLamViecDaHet') UPDATE LANGUAGES SET VIETNAM=N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?', ENGLISH=N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?',CHINESE=N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?', VIETNAM_OR=N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?', ENGLISH_OR=N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?' , CHINESE_OR=N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?' WHERE FORM=N'frmmain' AND KEYWORD=N'msgPhienLamViecDaHet' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,CHINESE,VIETNAM_OR,ENGLISH_OR,CHINESE_OR,MS_MODULE)  VALUES(N'frmmain',N'msgPhienLamViecDaHet',N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?',N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?',N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?',N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?',N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?',N'Phiên làm việc đã hết! Bạn có muốn tiếp tục?','ECOMAIN')
