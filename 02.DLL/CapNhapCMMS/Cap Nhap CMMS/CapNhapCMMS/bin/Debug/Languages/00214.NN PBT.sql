IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'msgBanCoMuonBoLockPhieuBaoTri') UPDATE LANGUAGES SET VIETNAM=N'Bạn có muốn unlock Phiếu bảo trì không? ', ENGLISH=N'Do you want to unlock this Work Order?', VIETNAM_OR=N'Bạn có muốn unlock Phiếu bảo trì không? ', ENGLISH_OR=N'Do you want to unlock this Work Order?' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'msgBanCoMuonBoLockPhieuBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmPhieuBaoTri_New',N'msgBanCoMuonBoLockPhieuBaoTri',N'Bạn có muốn unlock Phiếu bảo trì không? ',N'Do you want to unlock this Work Order?',N'Bạn có muốn unlock Phiếu bảo trì không? ',N'Do you want to unlock this Work Order?')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD =N'btnUnLock') UPDATE LANGUAGES SET VIETNAM=N'Unlock', ENGLISH=N'Unlock', VIETNAM_OR=N'Unlock', ENGLISH_OR=N'Unlock' WHERE FORM=N'FrmPhieuBaoTri_New' AND KEYWORD=N'btnUnLock' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'FrmPhieuBaoTri_New',N'btnUnLock',N'Unlock',N'Unlock',N'Unlock',N'Unlock')
