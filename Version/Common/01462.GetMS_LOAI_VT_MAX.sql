
ALTER procedure [dbo].[GetMS_LOAI_VT_MAX]
AS

select ISNULL(max(MS_LOAI_VT),0) as MS_LOAI_VT from LOAI_VT where MS_LOAI_VT not like '%[^0-9]%'