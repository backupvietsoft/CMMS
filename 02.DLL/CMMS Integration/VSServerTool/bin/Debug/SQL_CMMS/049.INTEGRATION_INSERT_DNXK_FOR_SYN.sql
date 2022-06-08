CREATE PROC dbo.[INTEGRATION_INSERT_DNXK_FOR_SYN]	   
		   @MAKHO nvarchar(100),
           @MASOYC nvarchar(100),
           @GIOLAP time(7),
           @NGAYLAP date,
           @MASOPB nvarchar(100),
           @TENPB nvarchar(100),
           @TENNVYC nvarchar(100),
           @NOIDUNG nvarchar(100),
           @MAVT nvarchar(100),
           @MAHANGMUC nvarchar(100),
           @MALYDOXUAT nvarchar(100),
           @SOLUONG nvarchar(100),
           @INSERT_DATE datetime
 AS 

INSERT INTO [dbo].[TB_DNXK]
           ([MAKHO],[MASOYC],[GIOLAP],[NGAYLAP],[MASOPB],[TENPB],[TENNVYC],[NOIDUNG],[MAVT],[MAHANGMUC],[MALYDOXUAT],[SOLUONG])
     VALUES
           (@MAKHO,@MASOYC,@GIOLAP ,@NGAYLAP ,@MASOPB ,@TENPB,@TENNVYC,@NOIDUNG, @MAVT ,@MAHANGMUC, @MALYDOXUAT ,@SOLUONG )
GO


