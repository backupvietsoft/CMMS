CREATE PROC INTEGRATION_SYN_TB_ALLOCATION_VTPT_FOR_PBT_INSERT
		   @MS_DH_XUAT_PT nvarchar(50),
           @ROW_ID_XUAT bigint,
           @MS_PT nvarchar(100),
           @MS_DH_NHAP_PT nvarchar(50),
           @ROW_ID_NHAP bigint,
           @MS_PHIEU_BT nvarchar(50),
           @SO_LUONG_PHAN_BO float
AS 

INSERT INTO dbo.[SYN_TB_ALLOCATION_VTPT_FOR_PBT]
           ([MS_DH_XUAT_PT]
           ,[ROW_ID_XUAT]
           ,[MS_PT]
           ,[MS_DH_NHAP_PT]
           ,[ROW_ID_NHAP]
           ,[MS_PHIEU_BT]
           ,[SO_LUONG_PHAN_BO])
     VALUES
           (@MS_DH_XUAT_PT
           ,@ROW_ID_XUAT
           ,@MS_PT
           ,@MS_DH_NHAP_PT
           ,@ROW_ID_NHAP
           ,@MS_PHIEU_BT
           ,@SO_LUONG_PHAN_BO )



