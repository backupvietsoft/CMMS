
ALTER PROC [dbo].[SP_NHAC_DUYET_MAIL]
AS
IF OBJECT_ID('TVT_LIST_APPROVAL_DOC') IS NOT NULL
	DROP TABLE TVT_LIST_APPROVAL_DOC
SELECT TOP 0 T.* INTO TVT_LIST_APPROVAL_DOC FROM
(
SELECT T1.FORM_ID,T1.APPROVAL_LEVEL1 [UserAproval],T3.USER_MAIL,T2.Department,0 [Type] FROM DBO.ST_APPROVAL_USER T1 INNER JOIN DBO.ST_Safety T2 ON ISNULL(T1.APPROVAL_LEVEL1,'')=T2.Userlogin INNER JOIN DBO.USERS T3 ON T2.Userlogin=T3.USERNAME WHERE T1.FORM_ID='FrmIncidentAndAccident'
UNION ALL
SELECT T1.FORM_ID,T1.APPROVAL_LEVEL2 [UserAproval],T3.USER_MAIL,T2.Department,1 [Type] FROM DBO.ST_APPROVAL_USER T1 INNER JOIN DBO.ST_Safety T2 ON ISNULL(T1.APPROVAL_LEVEL2,'')=T2.Userlogin INNER JOIN DBO.USERS T3 ON T2.Userlogin=T3.USERNAME WHERE T1.FORM_ID='FrmIncidentAndAccident'
UNION ALL
SELECT T1.FORM_ID,T1.APPROVAL_LEVEL1 [UserAproval],T3.USER_MAIL,T2.Department,2 [Type] FROM DBO.ST_APPROVAL_USER T1 INNER JOIN DBO.ST_Safety T2 ON ISNULL(T1.APPROVAL_LEVEL1,'')=T2.Userlogin INNER JOIN DBO.USERS T3 ON T2.Userlogin=T3.USERNAME WHERE T1.FORM_ID <> 'FrmIncidentAndAccident'
)T

SELECT DISTINCT REPLACE( T0.USER_MAIL,' ','')USER_MAIL,T2.Staffname,T1.DocNum,'HazardReport' DocType ,CONVERT(VARCHAR(10), T1.DocDate,103) CreatedDate ,CASE WHEN  ISNULL(REPORT_PARENT,'')='' THEN [CreatedBy] ELSE REPORT_PARENT END [CreatedBy]
FROM TVT_LIST_APPROVAL_DOC T0 INNER JOIN DBO.ST_HazardReport T1 ON T0.Department=T1.Department
INNER JOIN DBO.ST_Safety T2 ON  T0.UserAproval =T2.Userlogin
WHERE T0.[Type]=2 AND ISNULL(T1.IS_APPROVED,'False')='False' AND T0.FORM_ID='FrmHazardReport'  AND isnull(T1.IS_DELETE,'False')='False'
UNION ALL
SELECT DISTINCT REPLACE( T0.USER_MAIL,' ','')USER_MAIL,T2.Staffname,T1.DocNum,'StopCard' DocType ,CONVERT(VARCHAR(10), T1.DocDate,103) CreatedDate ,CASE WHEN  ISNULL(REPORT_PARENT,'')='' THEN [CreatedBy] ELSE REPORT_PARENT END [CreatedBy]
FROM TVT_LIST_APPROVAL_DOC T0 INNER JOIN DBO.ST_Safety T2 ON  T0.UserAproval =T2.Userlogin
INNER JOIN DBO.ST_StopCard T1 ON T0.Department IN(SELECT T.Department FROM DBO.ST_Safety T WHERE T.Userlogin IN(CASE WHEN  ISNULL(REPORT_PARENT,'')='' THEN [CreatedBy] ELSE REPORT_PARENT END))
WHERE T0.[Type]=2 AND  ISNULL(T1.IS_APPROVED,'False')='False' AND T0.FORM_ID='FrmStopCard'  AND isnull(T1.IS_DELETE,'False')='False'
UNION ALL
SELECT DISTINCT REPLACE( T0.USER_MAIL,' ','')USER_MAIL,T2.Staffname,T1.DocNum,'IncidentAndAccident' DocType ,CONVERT(VARCHAR(10), T1.DocDate,103) CreatedDate ,T1.IncidentReportingPerson [CreatedBy]
FROM TVT_LIST_APPROVAL_DOC T0 INNER JOIN DBO.ST_Safety T2 ON  T0.UserAproval =T2.Userlogin
INNER JOIN DBO.ST_IncidentAndAccident T1 ON T0.Department IN(SELECT T.Department FROM DBO.ST_Safety T WHERE T.Userlogin =T1.IncidentReportingPerson)
WHERE T0.[Type]=0 AND ISNULL(T1.ApprovalBy,'')='' AND T0.FORM_ID='FrmIncidentAndAccident'  AND isnull(T1.IS_DELETE,'False')='False'
UNION ALL
--SELECT DISTINCT REPLACE( T0.USER_MAIL,' ','')USER_MAIL,T2.Staffname,T1.DocNum,'IncidentAndAccident' DocType ,CONVERT(VARCHAR(10), T1.DocDate,103) CreatedDate ,T1.IncidentReportingPerson [CreatedBy]
--FROM TVT_LIST_APPROVAL_DOC T0 INNER JOIN DBO.ST_Safety T2 ON  T0.UserAproval =T2.Userlogin
--INNER JOIN DBO.ST_IncidentAndAccident T1 ON T0.Department IN(SELECT T.Department FROM DBO.ST_Safety T WHERE T.Userlogin =T1.IncidentReportingPerson)
--WHERE ISNULL(T1.ApprovalBy,'')<>'' AND ISNULL(T1.ApprovalByHSE,'') = '' AND T0.FORM_ID='FrmIncidentAndAccident'  AND isnull(T1.IS_DELETE,'False')='False'
SELECT DISTINCT REPLACE( T0.USER_MAIL,' ','')USER_MAIL,T2.Staffname,T1.DocNum,'IncidentAndAccident' DocType ,CONVERT(VARCHAR(10), T1.DocDate,103) CreatedDate ,T1.IncidentReportingPerson [CreatedBy]
FROM TVT_LIST_APPROVAL_DOC T0 INNER JOIN DBO.ST_Safety T2 ON  T0.UserAproval =T2.Userlogin
INNER JOIN DBO.ST_IncidentAndAccident T1 ON 1=1
WHERE T0.Department=1 and T0.[Type]=1 and ISNULL(T1.ApprovalBy,'')<>'' AND ISNULL(T1.ApprovalByHSE,'') = '' AND T0.FORM_ID='FrmIncidentAndAccident'  AND isnull(T1.IS_DELETE,'False')='False'

GO
