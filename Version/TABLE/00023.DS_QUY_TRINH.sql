IF NOT EXISTS(SELECT * FROM DS_QUY_TRINH WHERE MS_QT = 1)
BEGIN 
	INSERT INTO [DS_QUY_TRINH]([MS_QT],[TEN_QT_V],[TEN_QT_E]) VALUES (1, N'Đề xuất mua hàng', N'Purchase request' )
END 
GO
IF NOT EXISTS(SELECT * FROM DS_QUY_TRINH WHERE MS_QT = 2 )
BEGIN 
	INSERT INTO [DS_QUY_TRINH]([MS_QT],[TEN_QT_V],[TEN_QT_E]) VALUES (2, N'Đơn đặt hàng', N'Purchase order' )
END

GO 
UPDATE DS_TL SET MAC_DINH = 1 WHERE TEN_TL =  N'Đề xuất mua hàng' AND ISNULL(MAC_DINH,0) = 0

GO
UPDATE DS_TL SET MAC_DINH = 1 WHERE TEN_TL =  N'Đơn đặt hàng' AND ISNULL(MAC_DINH,0) = 0


GO 
UPDATE DS_TL SET [MS_QT] = 1 WHERE TEN_TL =  N'Đề xuất mua hàng' AND ISNULL([MS_QT],0) = 0

GO
UPDATE DS_TL SET [MS_QT] = 2 WHERE TEN_TL =  N'Đơn đặt hàng' AND ISNULL([MS_QT],0) = 0