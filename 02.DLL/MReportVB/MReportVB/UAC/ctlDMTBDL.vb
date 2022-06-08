Imports Microsoft.ApplicationBlocks.Data
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Public Class ctlDMTBDL
    Private vtbDSThietBi As New DataTable
    Private vtbLoaiMay As New DataTable
    Private SQL As String

    Private Sub ctlDMTBDL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'Commons.IConnections.Server = "THIENHANG\SQL2005"
            'Commons.IConnections.Username = "sa"
            'Commons.IConnections.Password = "123"
            'Commons.IConnections.Database = "CMMS_ECOMAINT"

            SQL = "SELECT convert(nvarchar,MS_LOAI_MAY) as MS_LOAI_MAY , TEN_LOAI_MAY FROM dbo.LOAI_MAY " & _
                  " union select 'ALL',' <ALL>' ORDER BY  TEN_LOAI_MAY "
            vtbLoaiMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
            Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cmbLoaiMay, vtbLoaiMay, "MS_LOAI_MAY", "TEN_LOAI_MAY", "")
            'cmbLoaiMay.Properties.DataSource = vtbLoaiMay
            'cmbLoaiMay.Properties.DisplayMember = "TEN_LOAI_MAY"
            'cmbLoaiMay.Properties.ValueMember = "MS_LOAI_MAY"

            'Dim coll As LookUpColumnInfoCollection = cmbLoaiMay.Properties.Columns
            'coll.Add(New LookUpColumnInfo("MS_LOAI_MAY", 0))
            'coll("MS_LOAI_MAY").Visible = False
            'coll.Add(New LookUpColumnInfo("TEN_LOAI_MAY", 0))
            'cmbLoaiMay.Properties.BestFitMode = BestFitMode.BestFitResizePopup
            'cmbLoaiMay.Properties.SearchMode = SearchMode.AutoComplete
            'cmbLoaiMay.Properties.AutoSearchColumnIndex = 1

            If vtbLoaiMay.Rows.Count > 0 Then
                cmbLoaiMay.EditValue = vtbLoaiMay.Rows(0).Item("MS_LOAI_MAY").ToString
            End If


        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadMay()
        Try
            SQL = "SELECT    convert(bit,0) as CHON, dbo.MAY.MS_MAY, dbo.MAY.TEN_MAY " & _
                    " FROM         dbo.NHOM_MAY INNER JOIN " & _
                    " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY where 1=1 "
            If cmbLoaiMay.EditValue.ToString <> "ALL" Then
                SQL = SQL & " and  dbo.NHOM_MAY.MS_LOAI_MAY='" & cmbLoaiMay.EditValue.ToString & "'"
            End If
            vtbDSThietBi = New DataTable
            vtbDSThietBi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
            vtbDSThietBi.Columns("CHON").ReadOnly = False
            GridControl1.DataSource = vtbDSThietBi
            GridView1.Columns("CHON").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "CHON", Commons.Modules.TypeLanguage)
            GridView1.Columns("MS_MAY").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "MS_MAY", Commons.Modules.TypeLanguage)
            GridView1.Columns("TEN_MAY").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "TEN_MAY", Commons.Modules.TypeLanguage)
            GridView1.Columns("CHON").Width = 10
            GridView1.Columns("MS_MAY").OptionsColumn.AllowEdit = False
            GridView1.Columns("MS_MAY").OptionsColumn.AllowFocus = False
            GridView1.Columns("TEN_MAY").OptionsColumn.AllowEdit = False
            GridView1.Columns("TEN_MAY").OptionsColumn.AllowFocus = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbLoaiMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoaiMay.EditValueChanged
        Try
            LoadMay()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            For Each VR As DataRow In vtbDSThietBi.Rows
                VR("CHON") = 1
            Next
        Catch ex As Exception

        End Try
    End Sub

   

   
    Public Function LayDSThietBi() As String
        Dim DS As String
        LayDSThietBi = ""
        Try
            DS = "<ROOT>"
            Dim j As Integer
            j = 0
            For Each VR As DataRow In vtbDSThietBi.Rows
                If IsDBNull(VR("CHON")) = False Then
                    If CBool(VR("CHON")) = True Then
                        DS = DS & "<MSMAY id=""" + VR("MS_MAY").ToString() & """></MSMAY>"
                    End If
                End If
                j = j + 1
            Next

            DS += "</ROOT>"
            LayDSThietBi = DS
        Catch ex As Exception

        End Try
    End Function



    
    Private Sub btnUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelect.Click
        Try
            For Each VR As DataRow In vtbDSThietBi.Rows
                VR("CHON") = 0
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim vtbtam As New DataTable

        Dim DSTB As String = ""
        Try
            DSTB = LayDSThietBi()
            If DSTB.Length = 13 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "Khong_chon_TB", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            SQL = " EXEC ProcDanhMucTBDoLUong '" & DSTB & "'"
            vtbtam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
            If vtbtam.Rows.Count > 0 Then
                Dim frm As New frmDanhSach
                frm.vtbTB = vtbtam
                frm.ShowDialog()
            Else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ctlDMTBDL", "Khong_co_DL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
