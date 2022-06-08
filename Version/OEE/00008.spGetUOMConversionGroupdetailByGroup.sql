
ALTER PROCEDURE [dbo].[spGetUOMConversionGroupdetailByGroup]
@IDConversionGroup BIGINT =-1
AS 
BEGIN
SELECT DISTINCT A.ID,C.UOMName FROM dbo.UOMConversionGroupDetails A
INNER JOIN dbo.UOMConversionGroup B ON B.ID = A.UOMConversionGroupID
INNER JOIN dbo.UOM C ON C.ID = A.UOMID
WHERE A.UOMConversionGroupID = @IDConversionGroup OR @IDConversionGroup =-1
END


