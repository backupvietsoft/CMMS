﻿IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'MsgXoaBaoTri') UPDATE LANGUAGES SET VIETNAM=N'Loại bảo trì này đang tồn tại công việc, chọn YES nếu bạn muốn xóa và tất cả công việc,phụ tùng đi kèm, chọn NO để hủy', ENGLISH=N'This maintenance type has existing works. Choose YES to delete all these works and related spare parts, choose NO to abort.', VIETNAM_OR=N'Loại bảo trì này đang tồn tại công việc, chọn YES nếu bạn muốn xóa và tất cả công việc,phụ tùng đi kèm, chọn NO để hủy', ENGLISH_OR=N'This maintenance type has existing works. Choose YES to delete all these works and related spare parts, choose NO to abort.' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'MsgXoaBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'MsgXoaBaoTri',N'Loại bảo trì này đang tồn tại công việc, chọn YES nếu bạn muốn xóa và tất cả công việc,phụ tùng đi kèm, chọn NO để hủy',N'This maintenance type has existing works. Choose YES to delete all these works and related spare parts, choose NO to abort.',N'Loại bảo trì này đang tồn tại công việc, chọn YES nếu bạn muốn xóa và tất cả công việc,phụ tùng đi kèm, chọn NO để hủy',N'This maintenance type has existing works. Choose YES to delete all these works and related spare parts, choose NO to abort.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'MsgXoaCVBaoTri') UPDATE LANGUAGES SET VIETNAM=N'Công việc này có sử dụng phụ tùng, chọn YES nếu bạn muốn xóa công việc này và tất cả phụ tùng đi kèm, chọn NO để hủy', ENGLISH=N'This work is using spare parts. Choose YES to delete this work and related spare parts, choose NO to abort.', VIETNAM_OR=N'Công việc này có sử dụng phụ tùng, chọn YES nếu bạn muốn xóa công việc này và tất cả phụ tùng đi kèm, chọn NO để hủy', ENGLISH_OR=N'This work is using spare parts. Choose YES to delete this work and related spare parts, choose NO to abort.' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'MsgXoaCVBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'MsgXoaCVBaoTri',N'Công việc này có sử dụng phụ tùng, chọn YES nếu bạn muốn xóa công việc này và tất cả phụ tùng đi kèm, chọn NO để hủy',N'This work is using spare parts. Choose YES to delete this work and related spare parts, choose NO to abort.',N'Công việc này có sử dụng phụ tùng, chọn YES nếu bạn muốn xóa công việc này và tất cả phụ tùng đi kèm, chọn NO để hủy',N'This work is using spare parts. Choose YES to delete this work and related spare parts, choose NO to abort.')
IF EXISTS (SELECT * FROM LANGUAGES WHERE FORM=N'frmThongtinthietbi' AND KEYWORD =N'MsgXoaPTBaoTri') UPDATE LANGUAGES SET VIETNAM=N'Bạn vui lòng chọn YES nếu bạn muốn xóa tất cả dữ liệu phụ tùng của công việc này, NO nếu bạn muốn xóa phụ tùng đang chọn, CANCEL để hủy', ENGLISH=N'Please choose YES to delete all spare parts data of this work, NO to delete selected spare parts, CANCEL to abort.', VIETNAM_OR=N'Bạn vui lòng chọn YES nếu bạn muốn xóa tất cả dữ liệu phụ tùng của công việc này, NO nếu bạn muốn xóa phụ tùng đang chọn, CANCEL để hủy', ENGLISH_OR=N'Please choose YES to delete all spare parts data of this work, NO to delete selected spare parts, CANCEL to abort.' WHERE FORM=N'frmThongtinthietbi' AND KEYWORD=N'MsgXoaPTBaoTri' ELSE INSERT INTO LANGUAGES(FORM,KEYWORD,VIETNAM,ENGLISH,VIETNAM_OR,ENGLISH_OR) VALUES(N'frmThongtinthietbi',N'MsgXoaPTBaoTri',N'Bạn vui lòng chọn YES nếu bạn muốn xóa tất cả dữ liệu phụ tùng của công việc này, NO nếu bạn muốn xóa phụ tùng đang chọn, CANCEL để hủy',N'Please choose YES to delete all spare parts data of this work, NO to delete selected spare parts, CANCEL to abort.',N'Bạn vui lòng chọn YES nếu bạn muốn xóa tất cả dữ liệu phụ tùng của công việc này, NO nếu bạn muốn xóa phụ tùng đang chọn, CANCEL để hủy',N'Please choose YES to delete all spare parts data of this work, NO to delete selected spare parts, CANCEL to abort.')
