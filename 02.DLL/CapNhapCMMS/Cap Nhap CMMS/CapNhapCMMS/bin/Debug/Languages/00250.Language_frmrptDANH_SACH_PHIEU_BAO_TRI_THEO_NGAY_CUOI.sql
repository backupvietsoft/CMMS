﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI' AND KEYWORD =N'TIEU_DE') UPDATE LANGUAGES SET VIETNAM=N'DANH SÁCH PHIẾU BẢO TRÌ THEO NGÀY BẢO TRÌ CUỐI', ENGLISH=N'LIST OF MAINTENANCE ORDERS BY LAST MAINTENANCE DATE', VIETNAM_OR=N'DANH SÁCH PHIẾU BẢO TRÌ THEO NGÀY BẢO TRÌ CUỐI', ENGLISH_OR=N'LIST OF MAINTENANCE ORDERS BY LAST MAINTENANCE DATE' WHERE FORM=N'frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI' AND KEYWORD=N'TIEU_DE' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI',N'TIEU_DE',N'DANH SÁCH PHIẾU BẢO TRÌ THEO NGÀY BẢO TRÌ CUỐI',N'LIST OF MAINTENANCE ORDERS BY LAST MAINTENANCE DATE',N'DANH SÁCH PHIẾU BẢO TRÌ THEO NGÀY BẢO TRÌ CUỐI',N'LIST OF MAINTENANCE ORDERS BY LAST MAINTENANCE DATE')
