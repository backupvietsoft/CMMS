
Imports Commons.VS.Classes.Catalogue
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization

Public Class FrmCongViecNhanVien
    Public MS_PBT As String = ""
    Public MS_CONG_NHAN As String = ""

    Private Sub FrmCongViecNhanVien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strselect As String
        strselect = "SELECT DISTINCT T3.MS_PHIEU_BAO_TRI, T3.MS_MAY,T1.MS_BO_PHAN, T4.TEN_BO_PHAN, T2.MO_TA_CV,
                        T1.NGAY, T1.TU_GIO, T1.DEN_NGAY, T1.DEN_GIO,ISNULL(T4.STT,9999) AS STT_BP
                        FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET AS T1 INNER JOIN
	                        dbo.CONG_VIEC AS T2 ON T1.MS_CV = T2.MS_CV INNER JOIN
	                        dbo.PHIEU_BAO_TRI AS T3 ON T1.MS_PHIEU_BAO_TRI = T3.MS_PHIEU_BAO_TRI INNER JOIN
	                        dbo.CAU_TRUC_THIET_BI AS T4 ON T1.MS_BO_PHAN = T4.MS_BO_PHAN AND T3.MS_MAY = T4.MS_MAY
                        WHERE (T1.MS_CONG_NHAN = N'" & MS_CONG_NHAN & "') 
                        AND (T1.NGAY >= (SELECT NGAY_BD_KH FROM dbo.PHIEU_BAO_TRI WHERE (MS_PHIEU_BAO_TRI = N'" & MS_PBT & "'))) 
                        AND (T1.NGAY <= (SELECT NGAY_KT_KH FROM dbo.PHIEU_BAO_TRI WHERE (MS_PHIEU_BAO_TRI = N'" & MS_PBT & "')))
                        UNION
                        SELECT DISTINCT 
                        T4.MS_PHIEU_BAO_TRI, T2.MS_MAY,NULL AS MS_BO_PHAN,NULL AS TEN_BO_PHAN, T3.TEN_CONG_VIEC AS MO_TA_CV,
                        T4.NGAY, T4.TU_GIO, T4.DEN_NGAY, T4.DEN_GIO,ISNULL(T1.STT,9999) AS STT_BP
                        FROM dbo.CAU_TRUC_THIET_BI AS T1 INNER JOIN
	                        dbo.PHIEU_BAO_TRI AS T2 ON T1.MS_MAY = T2.MS_MAY INNER JOIN
	                        dbo.PHIEU_BAO_TRI_CV_PHU_TRO AS T3 ON T2.MS_PHIEU_BAO_TRI = T3.MS_PHIEU_BAO_TRI INNER JOIN
	                        dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO AS T4 ON T3.MS_PHIEU_BAO_TRI = T4.MS_PHIEU_BAO_TRI AND T3.STT = T4.STT
                        WHERE (T4.MS_CONG_NHAN = N'" & MS_CONG_NHAN & "') 
                        AND (T4.NGAY >= (SELECT NGAY_BD_KH FROM dbo.PHIEU_BAO_TRI WHERE (MS_PHIEU_BAO_TRI = N'" & MS_PBT & "'))) 
                        AND (T4.NGAY <= (SELECT NGAY_KT_KH FROM dbo.PHIEU_BAO_TRI WHERE (MS_PHIEU_BAO_TRI = N'" & MS_PBT & "')))
                        ORDER BY STT_BP,T3.MS_PHIEU_BAO_TRI, T3.MS_MAY, T2.MO_TA_CV,
                        T1.NGAY, T1.TU_GIO, T1.DEN_NGAY, T1.DEN_GIO"

        Dim tbCongviec As DataTable = New DataTable()
        'gvCongViecNhanVien.ReadOnly = True
        tbCongviec.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strselect))


        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDS, grvDS, tbCongviec, False, True, True, False, False, Me.Name)
        grvDS.Columns("STT_BP").Visible = False
        grvDS.Columns("NGAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvDS.Columns("NGAY").DisplayFormat.FormatString = "d"
        grvDS.Columns("NGAY").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grvDS.Columns("TU_GIO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvDS.Columns("TU_GIO").DisplayFormat.FormatString = "HH:mm"
        grvDS.Columns("TU_GIO").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grvDS.Columns("DEN_NGAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvDS.Columns("DEN_NGAY").DisplayFormat.FormatString = "d"
        grvDS.Columns("DEN_NGAY").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grvDS.Columns("DEN_GIO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvDS.Columns("DEN_GIO").DisplayFormat.FormatString = "HH:mm"
        grvDS.Columns("DEN_GIO").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Commons.Modules.ObjSystems.ThayDoiNN(Me)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class