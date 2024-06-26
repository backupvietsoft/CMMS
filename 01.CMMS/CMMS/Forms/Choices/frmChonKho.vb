Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository

Public Class frmChonKho

    Private _MsPT As String
    Private _dtKho As DataTable
    Private _dtVTri As DataTable

    Public Property MsPT() As String
        Get
            Return _MsPT
        End Get
        Set(ByVal value As String)
            _MsPT = value
        End Set
    End Property


    Public Property dtKho() As DataTable
        Get
            Return _dtKho
        End Get
        Set(ByVal value As DataTable)
            _dtKho = value
        End Set
    End Property


    Public Property dtVTri() As DataTable
        Get
            Return _dtVTri
        End Get
        Set(ByVal value As DataTable)
            _dtVTri = value
        End Set
    End Property
    Private Sub frmChonKho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            grdKho.DataSource = _dtKho
            Dim cbo As RepositoryItemLookUpEdit = New RepositoryItemLookUpEdit()
            Dim dt As New DataTable
            dt.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetViTriDSPT"))
            cbo.DataSource = dt
            cbo.NullText = ""
            cbo.DisplayMember = "TEN_VI_TRI"
            cbo.ValueMember = "MS_VI_TRI"
            cbo.PopulateColumns()
            cbo.Columns("CHON").Visible = False
            cbo.Columns("MS_KHO").Visible = False
            cbo.Columns("MS_VI_TRI").Visible = False
            cbo.Columns("TEN_KHO").Visible = False
            cbo.Columns("TEN_VI_TRI").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_VI_TRI", Commons.Modules.TypeLanguage)
            grvKho.Columns("MS_VI_TRI").ColumnEdit = cbo

            grvKho.OptionsBehavior.Editable = True
            grvKho.Columns("MS_KHO").Visible = False
            grvKho.Columns("TEN_KHO").OptionsColumn.ReadOnly = True
            grvKho.OptionsView.ColumnAutoWidth = True
            grvKho.Columns("CHON").Width = 70
            grvKho.Columns("TEN_KHO").Width = 200

        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub grvKho_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvKho.FocusedRowChanged
        Try
            dtVTri.DefaultView.RowFilter = "MS_KHO = " & grvKho.GetFocusedDataRow()("MS_KHO").ToString()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim dtTmp = New DataTable()
        dtTmp = CType(grdKho.DataSource, DataTable)
        grvKho.UpdateCurrentRow()
        Dim SLMin, SLMax As Double
        Dim sTmp As String
        Dim count As Integer = 0
        For Each drRow As DataRow In dtTmp.Rows
            drRow.ClearErrors()
            If Boolean.Parse(drRow("CHON").ToString()) Then
                Try
                    sTmp = Convert.ToInt32(drRow("MS_VI_TRI"))
                Catch ex As Exception
                    If drRow("MS_VI_TRI") Is Nothing Or drRow("MS_VI_TRI").ToString() = "" Then
                        sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCoKhoChuaChonViTri", Commons.Modules.TypeLanguage)
                        drRow.SetColumnError(3, sTmp)
                        count = count + 1
                    End If
                End Try

                Try
                    SLMax = drRow("TON_KHO_MAX")
                Catch ex As Exception
                    SLMax = 0
                End Try
                Try
                    SLMin = drRow("TON_TOI_THIEU")
                Catch ex As Exception
                    SLMin = 0
                End Try
                If SLMax < SLMin Then

                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SLMaxNhoHonSlMin", Commons.Modules.TypeLanguage)
                    drRow.SetColumnError(4, sTmp)

                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SLMinLonHonMax", Commons.Modules.TypeLanguage)
                    drRow.SetColumnError(3, sTmp)
                    count = count + 1
                End If
            End If
        Next
        If (count > 0) Then Exit Sub
        dtTmp.DefaultView.RowFilter = " Chon = 1 "
        SLMin = 0
        SLMax = 0
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub grvKho_ShownEditor(sender As Object, e As EventArgs) Handles grvKho.ShownEditor
        Dim view = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "MS_VI_TRI" AndAlso TypeOf view.ActiveEditor Is LookUpEdit Then
            ' GET SELECTED DATAROW OF LookupEdit City here

            Dim row As DataRow = view.GetDataRow(view.FocusedRowHandle)
            Dim edit = DirectCast(view.ActiveEditor, LookUpEdit)
            Dim dt As DataTable = CType(edit.Properties.DataSource, DataTable).Copy()
            dt.DefaultView.RowFilter = "MS_KHO = '" & view.GetFocusedDataRow("MS_KHO") & "'"
            edit.Properties.DataSource = dt.DefaultView.ToTable().Copy()

        End If
    End Sub
End Class