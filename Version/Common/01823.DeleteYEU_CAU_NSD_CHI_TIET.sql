
ALTER procedure [dbo].[DeleteYEU_CAU_NSD_CHI_TIET] 
@STT INTEGER,
@MS_MAY NVARCHAR (30),
@STT_VAN_DE INTEGER 
AS
DELETE FROM YEU_CAU_NSD_CHI_TIET_HINH WHERE STT=@STT AND MS_MAY=@MS_MAY AND STT_VAN_DE=@STT_VAN_DE
DELETE FROM YEU_CAU_NSD_CHI_TIET_BO_PHAN WHERE STT=@STT AND MS_MAY=@MS_MAY AND STT_VAN_DE=@STT_VAN_DE
DELETE FROM YEU_CAU_NSD_CHI_TIET WHERE STT=@STT AND MS_MAY=@MS_MAY AND STT_VAN_DE=@STT_VAN_DE
declare @DONG INT
SELECT @DONG=COUNT(*) FROM YEU_CAU_NSD_CHI_TIET WHERE STT=@STT
--IF @DONG=0
--	DELETE FROM YEU_CAU_NSD WHERE STT=@STT

--DBCC CHECKIDENT (YEU_CAU_NSD_CHI_TIET_HINH,RESEED,0)
--DBCC CHECKIDENT (YEU_CAU_NSD_CHI_TIET_HINH,RESEED)

--DBCC CHECKIDENT (YEU_CAU_NSD_CHI_TIET,RESEED,0)
--DBCC CHECKIDENT (YEU_CAU_NSD_CHI_TIET,RESEED)

--DBCC CHECKIDENT (YEU_CAU_NSD,RESEED,0)
--DBCC CHECKIDENT (YEU_CAU_NSD,RESEED)
