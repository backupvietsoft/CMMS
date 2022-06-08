
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Management
Imports DevExpress.XtraEditors.Controls
Imports System.Text
Imports System.Xml
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraEditors
Imports System.IO
Imports System.Net.Sockets
Imports System.ComponentModel
Imports System.Reflection

Public Class HardDrive
    Private _model As String = ""
    Private _type As String = ""
    Private _serialNo As String = ""

    Public Property Model() As String
        Get
            Return _model
        End Get
        Set(ByVal value As String)
            _model = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Public Property serialNo() As String
        Get
            Return _serialNo
        End Get
        Set(ByVal value As String)
            _serialNo = value
        End Set
    End Property
End Class

Public Class OSystems
    Private strSql As String
    Private dtReader As SqlDataReader
    Private vtb As New DataTable

    Private _PBTKho As Boolean
    Private _KhoMoi As Boolean


    Public Property PBTKho() As Boolean
        Get
            Return _PBTKho
        End Get
        Set(ByVal value As Boolean)
            _PBTKho = value
        End Set
    End Property

    Public Property KhoMoi() As Boolean
        Get
            Return _KhoMoi
        End Get
        Set(ByVal value As Boolean)
            _KhoMoi = value
        End Set
    End Property

    Public Function DoiRaNgay(ByVal BienVao As String) As Long
        Dim Tong, i, ThangTruoc, ngay, NamTruoc
        NamTruoc = Val(Mid(BienVao, 7, 4)) - 1
        ThangTruoc = Val(Mid(BienVao, 4, 2)) - 1
        ngay = Val(Mid(BienVao, 1, 2))
        Tong = 0
        For i = 1980 To NamTruoc
            If (i Mod 400 = 0) Or ((i Mod 4 = 0) And (i Mod 100 <> 0)) Then
                Tong = Tong + 366
            Else
                Tong = Tong + 365
            End If
        Next i
        For i = 1 To ThangTruoc
            Select Case i
                Case 1, 3, 5, 7, 8, 10, 12
                    Tong = Tong + 31
                Case 4, 6, 9, 11
                    Tong = Tong + 30
                Case 2
                    If (i Mod 400 = 0) Or ((i Mod 4 = 0) And (i Mod 100 <> 0)) Then
                        Tong = Tong + 29
                    Else
                        Tong = Tong + 28
                    End If
            End Select
        Next
        Tong = Tong + ngay
        DoiRaNgay = Tong
    End Function
    '557
    '543
    Public Sub DinhDang()
        Modules.DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Modules.DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Modules.DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Modules.DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        Modules.DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Modules.DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        ' DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]

        Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        'DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    End Sub

    Function KiemTraTrung(ByVal strTenBang As String, ByVal strTenCot As String, ByVal strDK As String, ByVal strChuoiKT As String) As Boolean

        If strDK = "" Then
            strSql = "SELECT " & strTenCot & " FROM " & strTenBang
        Else
            strSql = "SELECT " & strTenCot & " FROM " & strTenBang & " WHERE " & strDK
        End If
        dtReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, strSql)
        While dtReader.Read
            If KiemTraTrungSub(dtReader.Item(0)) = KiemTraTrungSub(strChuoiKT) Then
                Return True
            End If
        End While
        dtReader.Close()
        Return False
    End Function
    Function KiemTraTrungSub(ByVal chuoi As String) As String
        Dim I As Integer
        KiemTraTrungSub = ""
        For I = 1 To Len(chuoi)
            KiemTraTrungSub = KiemTraTrungSub & Asc(Mid(chuoi, I, 1))
        Next I
    End Function
    Function KiemTraSoNguyen(ByVal dGiatri As String) As Boolean
        If Math.Round(Double.Parse(dGiatri)) <> Double.Parse(dGiatri) Then
            Return False
        End If
        Return True
    End Function
    Function TangMS_PBT() As String
        Dim strTmp = ""
        Dim strThang, strNam As String
        strSql = "SELECT MAX(MS_PHIEU_BAO_TRI) FROM PHIEU_BAO_TRI"
        dtReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, strSql)
        While dtReader.Read
            strTmp = dtReader.Item(0)
        End While
        dtReader.Close()
        If IsDBNull(strTmp) Or strTmp.ToString = "" Then
            strTmp = "001"
            TangMS_PBT = "WO-" & Year(Now) & IIf(Month(Now) < 10, "0" & Month(Now), Month(Now)) & strTmp
            Exit Function
        End If
        strThang = Val(Left(Right(strTmp, 5), 2))
        strNam = Val(Left(Right(strTmp, 9), 4))
        If strThang = Month(Now) And strNam = Year(Now) Then
            If Not IsDBNull(strTmp) Then
                strTmp = Right(strTmp, 3) + 1
                strTmp = Right("00" & strTmp, 3)
                strTmp = strTmp
            Else
                strTmp = "001"
            End If
        Else
            strTmp = "001"
        End If
        TangMS_PBT = "WO-" & Year(Now) & IIf(Month(Now) < 10, "0" & Month(Now), Month(Now)) & strTmp
    End Function

    Public Sub ThayDoiNN(ByVal frm As Windows.Forms.Form)

        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT KEYWORD , CASE " & Modules.TypeLanguage &
                " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" & frm.Name & "' "))

        Try
            RemoveHandler frm.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try

        Try
            AddHandler frm.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try

        frm.Text = GetNN(dtTmp, frm.Name, frm.Name)
        Try
            RemoveHandler frm.MouseDoubleClick, AddressOf Me.Label_MouseDoubleClick
        Catch ex As Exception
        End Try
        Try
            AddHandler frm.MouseDoubleClick, AddressOf Me.Label_MouseDoubleClick
        Catch ex As Exception
        End Try

        Dim resultControlList As New List(Of Control)()
        GetControlsCollection(frm, resultControlList, Nothing)
        For Each control1 As Control In resultControlList
            Try
                DoiNN(control1, frm, dtTmp)
            Catch ex As Exception
            End Try
        Next
        Try
            Dim MTab As MTabOrder = New MTabOrder(frm)
            MTab.MSetTabOrder(MTabOrder.TabScheme.AcrossFirst)
        Catch ex As Exception
        End Try
    End Sub


    Public Sub DoiNN(ByVal Ctl As Control, ByVal frm As Windows.Forms.Form, ByVal dtNgu As DataTable)
        'iFontsize
        'sFontForm
        Try
            Select Case Ctl.GetType.Name.ToString()
                Case "LookUpEdit"
                    Dim CtlDev As DevExpress.XtraEditors.LookUpEdit
                    CtlDev = CType(Ctl, DevExpress.XtraEditors.LookUpEdit)
                    CtlDev.Properties.NullText = ""
                Case "Label", "RadioButton", "CheckBox"
                    If Ctl.Name.ToUpper.Substring(0, 4) <> "NONN" And Ctl.Name.Length > 4 Then
                        Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name)          'Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                    End If

                    If Ctl.GetType.Name.ToString() = "Label" Then
                        Try
                            RemoveHandler Ctl.MouseDoubleClick, AddressOf Me.Label_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                        Try
                            AddHandler Ctl.MouseDoubleClick, AddressOf Me.Label_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                    End If

                    If Ctl.GetType.Name.ToString() = "RadioButton" Then
                        Try
                            RemoveHandler Ctl.MouseDoubleClick, AddressOf Me.RadioButton_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                        Try
                            AddHandler Ctl.MouseDoubleClick, AddressOf Me.RadioButton_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                    End If

                    If Ctl.GetType.Name.ToString() = "CheckBox" Then
                        Try
                            RemoveHandler Ctl.MouseDoubleClick, AddressOf Me.CheckBox_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                        Try
                            AddHandler Ctl.MouseDoubleClick, AddressOf Me.CheckBox_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                    End If
                Case "GroupBox"
                    Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name)
                    If (Ctl.Name = "grbList") Then
                        Dim dtItem As New DataTable
                        Try
                            dtItem.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_lstDanhsachbaocao", Commons.Modules.UserName, -1, Commons.Modules.TypeLanguage, 1))
                        Catch ex As Exception
                        End Try
                        For Each ctl1 As Windows.Forms.Control In Ctl.Controls
                            If (ctl1.GetType().Name.ToLower() = "navbarcontrol") Then
                                For Each cl As NavBarGroup In CType(ctl1, NavBarControl).Groups
                                    cl.Caption = GetNN(dtNgu, cl.Name, frm.Name)
                                Next
                                For Each cl As NavBarItem In CType(ctl1, NavBarControl).Items
                                    Try
                                        cl.Caption = dtItem.Select().Where(Function(x) x("REPORT_NAME").ToString().Trim() = cl.Name.Trim()).Take(1).Single()("TEN_REPORT")
                                    Catch ex As Exception
                                        cl.Caption = GetNN(dtNgu, cl.Name, frm.Name)
                                    End Try
                                Next
                                Exit For
                            End If
                        Next
                    End If
                    'Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                Case "TabPage"
                    Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name)          'Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                Case "LabelControl", "CheckButton", "CheckEdit", "XtraTabPage", "GroupControl"
                    If Ctl.Name.ToUpper.Substring(0, 4) <> "NONN" And Ctl.Name.Length > 4 Then
                        Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name)          'Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                    End If
                    If Ctl.GetType.Name.ToString() = "CheckEdit" Then
                        Try
                            RemoveHandler Ctl.MouseDoubleClick, AddressOf Me.CheckEdit_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                        Try
                            AddHandler Ctl.MouseDoubleClick, AddressOf Me.CheckEdit_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                    End If
                    If Ctl.GetType.Name.ToString() = "LabelControl" Then
                        Try
                            RemoveHandler Ctl.MouseDoubleClick, AddressOf Me.LabelControl_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                        Try
                            AddHandler Ctl.MouseDoubleClick, AddressOf Me.LabelControl_MouseDoubleClick
                        Catch ex As Exception
                        End Try
                    End If
                Case "Button"
                    If Ctl.Name.ToUpper.Substring(0, 4) <> "NONN" And Ctl.Name.Length > 4 Then
                        Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name)
                        LoadImage(Ctl)
                    End If
                Case "SimpleButton"
                    Dim CtlDev As DevExpress.XtraEditors.SimpleButton
                    CtlDev = CType(Ctl, DevExpress.XtraEditors.SimpleButton)
                    If Ctl.Name.ToUpper.Substring(0, 4) <> "NONN" And Ctl.Name.Length > 4 Then
                        Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name)
                        LoadImageDev(CtlDev)
                    End If

                Case "RadioGroup"
                    Dim radGroup As DevExpress.XtraEditors.RadioGroup
                    radGroup = CType(Ctl, DevExpress.XtraEditors.RadioGroup)
                    For i As Integer = 0 To radGroup.Properties.Items.Count - 1
                        If String.IsNullOrEmpty(radGroup.Properties.Items(i).Value) Then
                            radGroup.Properties.Items(i).Value = radGroup.Properties.Items(i).Description
                        End If
                        radGroup.Properties.Items(i).Description = GetNN(dtNgu, radGroup.Properties.Items(i).Value, frm.Name)

                        Try
                            AddHandler Ctl.MouseDoubleClick, AddressOf Me.RadioGroup_MouseDoubleClick
                        Catch ex As Exception
                        End Try

                    Next
                    Try
                        If radGroup.SelectedIndex = -1 Then radGroup.SelectedIndex = 0
                    Catch ex As Exception
                    End Try

                Case "CheckedListBoxControl"
                    Dim chkGroup As DevExpress.XtraEditors.CheckedListBoxControl
                    chkGroup = CType(Ctl, DevExpress.XtraEditors.CheckedListBoxControl)

                    For i As Integer = 0 To chkGroup.Items.Count - 1
                        If String.IsNullOrEmpty(chkGroup.Items(i).Value) Then
                            chkGroup.Items(i).Value = chkGroup.Items(i).Description
                        End If

                        chkGroup.Items(i).Description = GetNN(dtNgu, chkGroup.Items(i).Description, frm.Name)          'Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, chkGroup.Items(i).Description, Modules.TypeLanguage)
                    Next
                    Try
                        AddHandler Ctl.MouseDoubleClick, AddressOf Me.CheckedListBoxControl_MouseDoubleClick
                    Catch ex As Exception
                    End Try

                Case "XtraTabControl"
                    Dim tabControl As DevExpress.XtraTab.XtraTabControl
                    tabControl = CType(Ctl, DevExpress.XtraTab.XtraTabControl)
                    For i As Integer = 0 To tabControl.TabPages.Count - 1
                        tabControl.TabPages(i).Text = GetNN(dtNgu, tabControl.TabPages(i).Name, frm.Name)
                    Next

                Case "GridControl"
                    Dim grid As DevExpress.XtraGrid.GridControl
                    grid = CType(Ctl, DevExpress.XtraGrid.GridControl)
                    Dim mainView As DevExpress.XtraGrid.Views.Grid.GridView = grid.MainView


                    For Each view As DevExpress.XtraGrid.Views.Base.ColumnView In grid.ViewCollection
                        If TypeOf (view) Is DevExpress.XtraGrid.Views.Grid.GridView Then
                            For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
                                If col.Visible Then
                                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                                    col.AppearanceHeader.Options.UseTextOptions = True
                                    col.Caption = GetNN(dtNgu, col.FieldName, frm.Name)      'Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, col.Name, Modules.TypeLanguage),

                                    AutoCotDev(col)
                                End If
                            Next
                            MVisGrid(view, frm.Name, view.Name.ToString(), Commons.Modules.UserName, True)
                            Try
                                RemoveHandler view.MouseUp, AddressOf Me.GridView_MouseUp
                            Catch ex As Exception
                            End Try
                            Try
                                AddHandler view.MouseUp, AddressOf Me.GridView_MouseUp
                            Catch ex As Exception
                            End Try

                            Try
                                RemoveHandler view.DoubleClick, AddressOf Me.GridView_DoubleClick
                            Catch ex As Exception
                            End Try

                            Try
                                AddHandler view.DoubleClick, AddressOf Me.GridView_DoubleClick
                            Catch ex As Exception
                            End Try
                        End If
                    Next



                Case "DataGridView"
                    For Each cl As DataGridViewColumn In CType(Ctl, DataGridView).Columns
                        cl.HeaderText = GetNN(dtNgu, cl.Name, frm.Name)
                        AutoCotGrid(cl)
                    Next
                    CType(Ctl, DataGridView).ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                    CType(Ctl, DataGridView).DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
                    MVisGrid(CType(Ctl, DataGridView), frm.Name, CType(Ctl, DataGridView).Name.ToString(), Commons.Modules.UserName)
                Case "DataGridViewNew"
                    For Each cl As DataGridViewColumn In CType(Ctl, DataGridView).Columns
                        cl.HeaderText = GetNN(dtNgu, cl.Name, frm.Name)
                        AutoCotGrid(cl)
                    Next

                    MVisGrid(CType(Ctl, DataGridView), frm.Name, CType(Ctl, DataGridView).Name.ToString(), Commons.Modules.UserName)
                Case "DataGridViewEditor"
                    For Each cl As DataGridViewColumn In CType(Ctl, DataGridView).Columns
                        cl.HeaderText = GetNN(dtNgu, cl.Name, frm.Name)
                        AutoCotGrid(cl)
                    Next

                    CType(Ctl, DataGridView).ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                    CType(Ctl, DataGridView).DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

                    MVisGrid(CType(Ctl, DataGridView), frm.Name, CType(Ctl, DataGridView).Name.ToString(), Commons.Modules.UserName)
                Case "NavBarControl" Or "navBarControl"
                    For Each cl As NavBarGroup In CType(Ctl, NavBarControl).Groups
                        cl.Caption = GetNN(dtNgu, cl.Name, frm.Name)
                    Next
                    For Each cl As NavBarItem In CType(Ctl, NavBarControl).Items
                        cl.Caption = GetNN(dtNgu, cl.Name, frm.Name)
                    Next



            End Select
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ThayDoiNN(ByVal UcCtl As System.Windows.Forms.Control, ByVal fName As String)
        Dim frm As New System.Windows.Forms.Form()
        frm.Name = fName
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select KEYWORD , CASE " & Modules.TypeLanguage &
                " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" & frm.Name & "' "))

        Try
            RemoveHandler UcCtl.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try

        Try
            AddHandler UcCtl.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try

        For Each ctl As Windows.Forms.Control In UcCtl.Controls
            ControlType(ctl, frm, dtTmp)
        Next
        Try
            Dim MTab As MTabOrder = New MTabOrder(frm)
            MTab.MSetTabOrder(MTabOrder.TabScheme.AcrossFirst)
        Catch ex As Exception
        End Try


    End Sub

    Public Sub ThayDoiNN(ByVal frmContent As Windows.Forms.Form, ByVal UcCtl As System.Windows.Forms.Control)
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT KEYWORD , CASE " & Modules.TypeLanguage &
                " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" & UcCtl.Name & "' "))

        Try
            RemoveHandler frmContent.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try

        Try
            AddHandler frmContent.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try


        frmContent.Text = GetNN(dtTmp, frmContent.Name, frmContent.Name)

        For Each ctl As Windows.Forms.Control In frmContent.Controls
            ControlType(ctl, frmContent, dtTmp)

        Next
        For Each ctl1 As Windows.Forms.Control In UcCtl.Controls
            ControlType(ctl1, UcCtl, dtTmp)

        Next
        Try
            Dim MTab As MTabOrder = New MTabOrder(frmContent)
            MTab.MSetTabOrder(MTabOrder.TabScheme.AcrossFirst)
        Catch ex As Exception
        End Try
    End Sub

    Sub AutoCotDev(ByVal col As DevExpress.XtraGrid.Columns.GridColumn)
        Try

            If col.ColumnType.ToString() = GetType(DateTime).ToString() Then
                col.BestFit()
            ElseIf col.Name.Contains("MS_MAY") Then
                col.BestFit()
            ElseIf col.Name.Contains("MS_PT") Then
                col.BestFit()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub AutoCotGrid(ByVal col As DataGridViewColumn)
        Try

            If col.ValueType.ToString() = GetType(DateTime).ToString() Then
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ElseIf col.Name.Contains("MS_MAY") Then
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ElseIf col.Name.Contains("MS_PT") Then
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If

        Catch ex As Exception

        End Try
    End Sub


    Sub ControlType(ByVal Ctl As Windows.Forms.Control, ByVal frm As Windows.Forms.Form, ByVal dtNNgu As DataTable)
        If Ctl.Controls.Count >= 1 Then

            If Ctl.GetType.Name = "TabPage" Or Ctl.GetType.Name = "GroupBox" Or Ctl.GetType.Name = "RadioGroup" Or Ctl.GetType.Name = "CheckedListBoxControl" Or Ctl.GetType.Name = "GroupControl" Or Ctl.GetType.Name = "DataGridView" Or Ctl.GetType.Name = "XtraTabControl" Or Ctl.GetType.Name = "DataGridViewNew" Then DoiNN(Ctl, frm, dtNNgu)
            If Ctl.GetType.Name = "GridControl" Then
                Dim grid As DevExpress.XtraGrid.GridControl
                grid = CType(Ctl, DevExpress.XtraGrid.GridControl)
                For Each view As DevExpress.XtraGrid.Views.Base.ColumnView In grid.ViewCollection
                    If TypeOf (view) Is DevExpress.XtraGrid.Views.Grid.GridView Then
                        For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
                            If col.Visible Then
                                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                                col.AppearanceHeader.Options.UseTextOptions = True
                                col.Caption = GetNN(dtNNgu, col.FieldName, frm.Name)           'Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, col.FieldName, Modules.TypeLanguage)
                                AutoCotDev(col)
                            End If
                        Next
                        MVisGrid(view, frm.Name, view.Name.ToString(), Commons.Modules.UserName, True)
                    End If
                Next
            End If

            For Each type As Windows.Forms.Control In Ctl.Controls
                If type.GetType.Name = "DataGridView" Or type.GetType.Name = "DataGridViewEditor" Or type.GetType.Name = "DataGridViewNew" Then
                    For Each cl As DataGridViewColumn In CType(type, DataGridView).Columns
                        cl.HeaderText = GetNN(dtNNgu, cl.Name, frm.Name)
                        AutoCotGrid(cl)
                    Next
                    MVisGrid(CType(type, DataGridView), frm.Name, CType(type, DataGridView).Name.ToString(), Commons.Modules.UserName)
                Else
                    If type.GetType.Equals(GetType(TextBox)) Or type.GetType.Equals(GetType(Windows.Forms.ComboBox)) Or type.GetType.ToString.Equals("VS.UserControls.utcTextBox") Or type.GetType.ToString.Equals("VS.UserControls.UtcComboBox") Then
                        type.BackColor = Color.White
                    End If
                    If Not type.GetType.Equals(GetType(Windows.Forms.ComboBox)) And Not type.GetType.Equals(GetType(utcTextBox)) Then
                        ControlType(type, frm, dtNNgu)
                    End If
                End If
            Next

        Else
            DoiNN(Ctl, frm, dtNNgu)
        End If
    End Sub
    Public Sub GetControlsCollection(root As Control, ByRef AllControls As List(Of Control), filter As Func(Of Control, Control))
        For Each child As Control In root.Controls
            If Commons.Modules.lstControlName.Any(Function(x) x.ToString() = child.GetType.Name) Then
                AllControls.Add(child)
            End If
            If child.Controls.Count > 0 Then
                GetControlsCollection(child, AllControls, filter)
            End If
        Next
    End Sub

    Private Function EnumerateComponents(ByVal frm As Windows.Forms.Form) As IEnumerable(Of Component)
        Return frm.[GetType]().GetFields(BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic).Where(Function(x) GetType(Component).IsAssignableFrom(x.FieldType) AndAlso CType(x.GetValue(frm), Component) IsNot Nothing AndAlso "BarManager" = x.FieldType.Name).[Select](Function(x) CType(x.GetValue(frm), Component)).ToList()
    End Function

    Public Sub ThayDoiNNNew(ByVal frm As Windows.Forms.Form)
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT KEYWORD , CASE " & Modules.TypeLanguage &
                " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" & frm.Name & "' "))
        frm.Text = GetNN(dtTmp, frm.Name, frm.Name)

        Try
            RemoveHandler frm.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try

        Try
            AddHandler frm.MouseDoubleClick, AddressOf Me.Form_MouseDoubleClick
        Catch ex As Exception
        End Try

        Dim resultControlList As New List(Of Control)()
        GetControlsCollection(frm, resultControlList, Nothing)
        For Each control In resultControlList
            DoiNN(control, frm, dtTmp)
        Next
        Try
            Dim MTab As MTabOrder = New MTabOrder(frm)
            MTab.MSetTabOrder(MTabOrder.TabScheme.AcrossFirst)
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetNNReport(ByVal dtNN As DataTable, ByVal sKeyWord As String, ByVal sFormName As String) As String
        Dim sNN As String = ""
        Try
            sNN = CType(dtNN.Select("KEYWORD = '" & sKeyWord & "'"), DataRow())(0)(1).ToString()
        Catch ex As Exception
            sNN = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, sFormName, sKeyWord, Modules.TypeLanguage)
        End Try
        Return sNN
    End Function
    Public Function GetNN(ByVal dtNN As DataTable, ByVal sKeyWord As String, ByVal sFormName As String) As String
        Dim sNN As String = ""
        Try
            sNN = CType(dtNN.Select("KEYWORD = '" & sKeyWord & "'"), DataRow())(0)(1).ToString()
        Catch ex As Exception
            sNN = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, sFormName, sKeyWord, Modules.TypeLanguage)
        End Try
        Return sNN
    End Function

    Sub LoadImage(ByVal Ctl As Windows.Forms.Control)
        Dim CtlFrm As System.Windows.Forms.Button
        CtlFrm = CType(Ctl, System.Windows.Forms.Button)
        CtlFrm.BackgroundImageLayout = ImageLayout.None
        CtlFrm.BackgroundImage = Nothing
        CtlFrm.ImageAlign = ContentAlignment.MiddleLeft
        CtlFrm.TextAlign = ContentAlignment.MiddleCenter
        CtlFrm.Image = Nothing
        CtlFrm.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        CtlFrm.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
        CtlFrm.ImageAlign = ContentAlignment.MiddleLeft
        Dim sTenControl As String
        sTenControl = Ctl.Name.ToUpper
        Try
            If sTenControl.Contains("IMPORT") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Import : Exit Sub
            If sTenControl.Contains("THEM") Or sTenControl.Contains("ADD") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Add : Exit Sub
            If sTenControl.Contains("SUA") Or sTenControl.Contains("EDIT") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Edit : Exit Sub
            If sTenControl.Contains("DEL") Or sTenControl.Contains("XOA") Or sTenControl.Contains("DELETE") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Delete : Exit Sub
            If sTenControl.Contains("THOAT") Or sTenControl.Contains("EXIT") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Thoat : Exit Sub
            If sTenControl.Contains("LUA") Or sTenControl.Contains("LUU") Or sTenControl.Contains("GHI") Or sTenControl.Contains("SAVE") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Save : Exit Sub
            If sTenControl.Contains("KHONG") Or sTenControl.Contains("CANCEL") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Cancel : Exit Sub
            If sTenControl.Contains("SCHEDULE") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Schedule : Exit Sub
            If sTenControl.Contains("ALL") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Check : Exit Sub
            If sTenControl.Contains("NOALL") Or sTenControl.Contains("NOTALL") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck : Exit Sub
            If sTenControl.Contains("IN") Or sTenControl.Contains("PRINT") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Print : Exit Sub
            If sTenControl.Contains("EXCEL") Or sTenControl.Contains("XUATEXCEL") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.Excel : Exit Sub
            If sTenControl.Contains("EXCUTE") Or sTenControl.Contains("EXECUTE") Or sTenControl.Contains("THUCHIEN") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien : Exit Sub
            If sTenControl.Contains("TROVE") Or sTenControl.Contains("RETURN") Then Ctl.BackgroundImage = Global.Commons.My.Resources.Resources.TroVe : Exit Sub
        Catch ex As Exception
        End Try

    End Sub

    Sub LoadImageDev(ByVal CtlDev As DevExpress.XtraEditors.SimpleButton)
        Dim sTenControl As String
        sTenControl = CtlDev.Name.ToUpper
        CtlDev.Image = Nothing
        CtlDev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Try
            If sTenControl.Contains("IMPORT") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Import : Exit Sub
            If sTenControl.Contains("THEM") Or sTenControl.Contains("ADD") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Add : Exit Sub
            If sTenControl.Contains("SUA") Or sTenControl.Contains("EDIT") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Edit : Exit Sub
            If sTenControl.Contains("DEL") Or sTenControl.Contains("XOA") Or sTenControl.Contains("DELETE") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Delete : Exit Sub
            If sTenControl.Contains("THOAT") Or sTenControl.Contains("EXIT") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Thoat : Exit Sub
            If sTenControl.Contains("LUA") Or sTenControl.Contains("LUU") Or sTenControl.Contains("GHI") Or sTenControl.Contains("SAVE") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Save : Exit Sub
            If sTenControl.Contains("KHONG") Or sTenControl.Contains("CANCEL") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Cancel : Exit Sub
            If sTenControl.Contains("SCHEDULE") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Schedule : Exit Sub
            If sTenControl.Contains("ALL") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Check : Exit Sub
            If sTenControl.Contains("NOALL") Or sTenControl.Contains("NOTALL") Then CtlDev.Image = Global.Commons.My.Resources.Resources.UnCheck : Exit Sub
            If sTenControl.Contains("IN") Or sTenControl.Contains("PRINT") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Print : Exit Sub
            If sTenControl.Contains("EXCEL") Or sTenControl.Contains("XUATEXCEL") Then CtlDev.Image = Global.Commons.My.Resources.Resources.Excel : Exit Sub
            If sTenControl.Contains("EXCUTE") Or sTenControl.Contains("EXECUTE") Or sTenControl.Contains("THUCHIEN") Then CtlDev.Image = Global.Commons.My.Resources.Resources.ThucHien : Exit Sub
            If sTenControl.Contains("TROVE") Or sTenControl.Contains("RETURN") Then CtlDev.Image = Global.Commons.My.Resources.Resources.TroVe : Exit Sub

            If sTenControl.Contains("btnHelp".ToUpper()) Then
                CtlDev.Image = Global.Commons.My.Resources.Resources.IconElearning
                CtlDev.Text = ""
                Try
                    RemoveHandler CtlDev.Click, AddressOf Me.btnHelp_Click
                Catch ex As Exception
                End Try
                Try
                    AddHandler CtlDev.Click, AddressOf Me.btnHelp_Click
                Catch ex As Exception
                End Try
                Exit Sub
            End If

            If sTenControl.Contains("btnVideo".ToUpper()) Then
                CtlDev.Image = Global.Commons.My.Resources.Resources.IconLinkVideo
                CtlDev.Text = ""
                Try
                    RemoveHandler CtlDev.Click, AddressOf Me.btnVideo_Click
                    CtlDev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter

                Catch ex As Exception
                End Try
                Try
                    AddHandler CtlDev.Click, AddressOf Me.btnVideo_Click
                    CtlDev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
                Catch ex As Exception
                End Try

                Exit Sub
            End If

        Catch ex As Exception

        End Try

    End Sub

    Sub LoadLinkWeb(ByVal CtlDev As DevExpress.XtraEditors.SimpleButton)
        Dim sTenControl As String
        sTenControl = CtlDev.Name.ToUpper
        CtlDev.Image = Nothing

        If sTenControl.Contains("btnHelp".ToUpper()) Then
            CtlDev.Image = Global.Commons.My.Resources.Resources.IconElearning
            CtlDev.Text = ""
            Try
                RemoveHandler CtlDev.Click, AddressOf Me.btnHelp_Click
            Catch ex As Exception
            End Try
            Try
                AddHandler CtlDev.Click, AddressOf Me.btnHelp_Click
            Catch ex As Exception
            End Try
            Exit Sub
        End If

        If sTenControl.Contains("btnVideo".ToUpper()) Then
            CtlDev.Image = Global.Commons.My.Resources.Resources.IconLinkVideo
            CtlDev.Text = ""
            Try
                RemoveHandler CtlDev.Click, AddressOf Me.btnVideo_Click
            Catch ex As Exception
            End Try
            Try
                AddHandler CtlDev.Click, AddressOf Me.btnVideo_Click
            Catch ex As Exception
            End Try

            Exit Sub
        End If
    End Sub

    Function DoiDDNgay(ByVal Ngay As String) As String
        Try

            Dim NgayDoi As Date
            NgayDoi = Date.Parse(Ngay)

            Dim thang As Integer
            Dim Nam As Integer
            Dim SONGAY As Integer
            Dim chuoi As String
            thang = NgayDoi.Month
            Nam = NgayDoi.Year
            SONGAY = NgayDoi.Day

            If thang < 10 Then
                chuoi = Nam & "0" & thang
            Else
                chuoi = Nam & thang
            End If
            If SONGAY < 10 Then
                chuoi = chuoi & "0" & SONGAY
            Else
                chuoi = chuoi & SONGAY
            End If
            DoiDDNgay = chuoi
        Catch ex As Exception
            DoiDDNgay = ""
        End Try

    End Function

    Public Function LocalIP() As String
        Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Return CType(h.AddressList.GetValue(0), Net.IPAddress).ToString
    End Function

    Function LayGroup(ByVal UserName As String) As Integer
        strSql = "SELECT GROUP_ID FROM USERS WHERE USERNAME='" & UserName & "'"
        dtReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, strSql)
        While dtReader.Read
            LayGroup = dtReader.Item(0)
        End While
        dtReader.Close()
    End Function

    Function check_permission(ByVal userlog As String, ByVal formname As String) As Boolean
        Modules.PermisString = ""
        If CheckLic(userlog, formname) = False Then
            MsgBox(Modules.ObjLanguages.GetLanguage(Modules.ModuleName, "frmMain", "MsgNoAccess1", Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End If
        Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(userlog, formname)
        If Modules.PermisString = "" Then
            MsgBox(Modules.ObjLanguages.GetLanguage(Modules.ModuleName, "frmMain", "MsgNoAccess1", Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        Else
            If Modules.PermisString.Equals("No access") Then
                MsgBox(Modules.GetNNgu("frmMain", "MsgNoAccess"), MsgBoxStyle.Exclamation)
                Return False
            End If
        End If
        Modules.PermisString = Modules.PermisString.ToUpper()
        Return True

    End Function

    Function CheckLic(ByVal sUserName As String, ByVal sFormName As String) As Boolean
        Dim sBTLic, sSql As String
        sBTLic = "AAA_COMM_LIC" + Modules.UserName
        sSql = MGetLicUser(sUserName)

        MGiaiMaTable(sBTLic, "LIC_FORM", "FORM_NAME", sSql)
        sSql = "SELECT ISNULL( COUNT(*) ,0) AS IDD FROM " + sBTLic + "  WHERE TYPE_LIC = N'" + sSql + "' AND FORM_NAME = N'" + sFormName + "'  "
        Dim i As Integer
        i = CType(SqlHelper.ExecuteScalar(IConnections.ConnectionString, CommandType.Text, sSql), Integer)
        Commons.Modules.ObjSystems.XoaTable(sBTLic)
        If i <= 0 Then
            Return False
        End If
        Return True
    End Function

    Sub Kiemtralaiphanquyen(ByVal formname As String)
        'If frmKho.IsActivated Then
        '    str_permission = _OGroups.GetNHOM_FORM_QUYEN(_UserID, frmKho.Name)
        'End If
        'If FrmThongtinthietbi.IsActivated Then
        '    str_permission = _OGroups.GetNHOM_FORM_QUYEN(_UserID, frmThongsothietbi.Name)
        '    If formname = frmThietBi.Name.ToString Then
        '        FrmThongtinthietbi.LoadNhomMay()
        '        FrmThongtinthietbi.LoadLoaiMay()
        '    End If
        '    If formname = frmHangsanxuat.Name.ToString Then
        '        FrmThongtinthietbi.LoadNSX()
        '    End If
        '    If formname = frmMucUT.Name.ToString Then
        '        FrmThongtinthietbi.LoadMUC_UU_TIEN()
        '    End If
        '    If formname = frmNhacungcap.Name.ToString Then
        '        FrmThongtinthietbi.LoadNCC()
        '    End If
        '    If formname = frmDonvitinhRuntime.Name.ToString Then
        '        FrmThongtinthietbi.LoadDON_VI_TINH_RUN_TIME()
        '        FrmThongtinthietbi.LoadDVT_RT()
        '    End If
        'End If
        'If frmLanguage.IsActivated Then
        '    str_permission = _OGroups.GetNHOM_FORM_QUYEN(_UserID, frmLanguage.Name)
        'End If
        'If frmQuanlynhanvien.IsActivated Then
        '    str_permission = _OGroups.GetNHOM_FORM_QUYEN(_UserID, frmQuanlynhanvien.Name)
        '    If formname = frmDanhmucdonvi.Name.ToString Then
        '        frmQuanlynhanvien.LoadcboDON_VI2()
        '    End If
        '    If formname = frmDanhmucto.Name.ToString Then
        '        frmQuanlynhanvien.LoadcboTO2()
        '        frmQuanlynhanvien.LoadcboTo3()
        '    End If
        '    If formname = frmTrinhdo.Name.ToString Then
        '        frmQuanlynhanvien.LoadcboTRINH_DO()
        '    End If
        '    If formname = frmNgoaite.Name.ToString Then
        '        frmQuanlynhanvien.LoadcboNgoaiTe()
        '    End If
        'End If
        'If frmKehoachCongviec.IsActivated Then
        '    str_permission = _OGroups.GetNHOM_FORM_QUYEN(_UserID, frmKehoachCongviec.Name)
        'End If
        'If frmDanhmuccongviec.IsActivated Then
        '    str_permission = _OGroups.GetNHOM_FORM_QUYEN(_UserID, frmDanhmuccongviec.Name)
        '    If (formname = frmThietBi.Name.ToString) Or (formname = frmLoaicongviec.Name.ToString) Or (formname = frmBactho.Name.ToString) Or (formname = frmChuyenmon.Name.ToString) Then
        '        frmDanhmuccongviec.BindCombo()
        '    End If
        'End If
        'If frmDanhmucphutung.IsActivated Then
        '    str_permission = _OGroups.GetNHOM_FORM_QUYEN(_UserID, frmDanhmucphutung.Name)
        '    If (formname = frmDonvitinh.Name.ToString) Or (formname = frmNhacungcap.Name.ToString) Or (formname = frmLoaiphutung.Name.ToString) Or (formname = frmCachdathang.Name.ToString) Then
        '        frmDanhmucphutung.BindDataCombo()
        '    End If
        'End If
    End Sub

    ''' <summary>
    ''' Tăng thêm ngày 28/06/2007.
    ''' Hàm này dùng để cắt bỏ những khoảng trắng dư thừa giữa hai ký tự trong một chuổi.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 

    Public Function SplitString(ByVal str As String) As String
        'Dim strarray() As String = str.Split(" ")
        'Dim tmp As String = ""
        'For i As Integer = 0 To strarray.Length - 1
        '    If strarray(i).ToString.Trim <> "" Then
        '        tmp += strarray(i).ToString + " "
        '    End If
        'Next
        'tmp = tmp.ToString.Trim
        Return str
    End Function

    Sub XoaTable(ByVal strTableName As String)
        Try
            strSql = "DROP TABLE " & strTableName
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, CommandType.Text, strSql)
        Catch ex As Exception
        End Try
    End Sub

    Function CheckTime(ByVal strTime As String) As Boolean
        Dim blnCheck As Boolean = False
        If Len(strTime) <> 5 Then Return False
        If Mid(strTime, 3, 1) <> ":" Then Return False
        If (Not IsNumeric(Mid(strTime, 1, 2))) Or (Not IsNumeric(Mid(strTime, 4, 2))) Then Return False
        If InStr(strTime, "_") Then Return False
        If Integer.Parse(Mid(strTime, 1, 2)) > 24 Or Integer.Parse(Mid(strTime, 1, 2)) < 1 Then Return False
        If Integer.Parse(Mid(strTime, 4, 2)) > 60 Or Integer.Parse(Mid(strTime, 4, 2)) < 0 Then Return False
        Return True
    End Function
#Region "hinh"
    '-----------------------------------------------------------------------------------------------------------
    Public Function GetDUONG_DAN_HINH(ByVal STT As Integer) As DataTable
        Dim objDataTable As New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetDUONG_DAN_HINH", STT))
        Return objDataTable
    End Function

    Function LocKyTuDB(ByVal sChuoi As String) As String

        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace("/", "-")
        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace("\", "-")
        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace("*", "-")
        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace("-", "-")
        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace(".", "-")
        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace("!", "-")
        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace("@", "-")
        If sChuoi.Length() > 0 Then sChuoi = sChuoi.Replace("#", "-")
        Return sChuoi
    End Function


    Function CapnhatTL(ByVal bHinh As Boolean, ByVal strMS_MAY As String) As String

        strMS_MAY = LocKyTuDB(strMS_MAY)
        Dim SERVER_FOLDER_PATH As String = ""
        Dim SERVER_PATH As String = ""
        Dim dtReader As SqlDataReader, iStt As Integer = 0
        dtReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, "SELECT MAX(STT) FROM THONG_TIN_CHUNG")
        While dtReader.Read
            iStt = dtReader.Item(0)
        End While
        dtReader.Close()
        SERVER_PATH = GetDUONG_DAN_HINH(iStt).Rows(0).Item(0).ToString
        If Not System.IO.Directory.Exists(SERVER_PATH) Then
            SERVER_PATH = ""
        End If
        If Not SERVER_PATH.EndsWith("\") Then
            SERVER_PATH = SERVER_PATH & "\"
        End If
        SERVER_FOLDER_PATH = SERVER_PATH
        If System.IO.Directory.Exists(SERVER_PATH) Then
            If bHinh Then
                Dim FILE_TEMPArr As String()
                FILE_TEMPArr = System.IO.Directory.GetFileSystemEntries(SERVER_PATH)
                Dim i As Integer = 0
                Dim arr As String()
                While i < FILE_TEMPArr.Length 'tài liệu
                    arr = FILE_TEMPArr(i).Split("\")
                    If arr(arr.Length - 1).Equals("Tai_Lieu_May") Then
                        SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & arr(arr.Length - 1)
                        'kiểm tra folder MS_MAY đã tồn tại chưa
                        Dim FILE_TEMPArr1 As String()
                        FILE_TEMPArr1 = System.IO.Directory.GetFileSystemEntries(SERVER_FOLDER_PATH)
                        Dim j As Integer = 0 'MS_MAY
                        While j < FILE_TEMPArr1.Length
                            arr = FILE_TEMPArr1(j).Split("\")
                            If arr(arr.Length - 1).Equals(strMS_MAY) Then
                                SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "\" & arr(arr.Length - 1)
                                Exit While 'MS_MAY
                            End If
                            j = j + 1
                        End While 'MS_MAY
                        If j = FILE_TEMPArr1.Length Then
                            SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "\" & strMS_MAY
                            System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH)
                        End If
                        Exit While 'tài liệu
                    End If
                    i = i + 1
                End While 'tài liệu
                If i = FILE_TEMPArr.Length Then
                    ' nếu chưa tồn tại folder bảo trì thì tạo mới folder bảo trì và các folder hình máy và tài liệu máy
                    SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "Tai_Lieu_May\" & strMS_MAY
                    System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH)

                End If
            Else
                Dim FILE_TEMPArr As String()
                FILE_TEMPArr = System.IO.Directory.GetFileSystemEntries(SERVER_PATH)
                Dim i As Integer = 0
                Dim arr As String()
                While i < FILE_TEMPArr.Length  'hinh máy
                    'nếu tồn tại folder hình máy
                    arr = FILE_TEMPArr(i).Split("\")
                    If arr(arr.Length - 1).Equals("Hinh_May") Then
                        SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & arr(arr.Length - 1)
                        Dim TMP As String()
                        TMP = System.IO.Directory.GetFileSystemEntries(SERVER_FOLDER_PATH)
                        Dim j As Integer = 0
                        While j < TMP.Length  'MS_MAY
                            'nếu tồn tại folder MS_MAY
                            arr = TMP(j).Split("\")
                            If arr(arr.Length - 1).Equals(strMS_MAY) Then
                                SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "\" & arr(arr.Length - 1)
                                Dim TMP1 As String()
                                TMP1 = System.IO.Directory.GetFileSystemEntries(SERVER_FOLDER_PATH)
                                Dim k As Integer = 0
                                'kiểm tra ngày
                                Dim s As String = ""
                                s = Microsoft.VisualBasic.DateAndTime.Day(Now()) & "_" & Month(Now()) & "_" & Year(Now())
                                While k < TMP1.Length  'ngày
                                    'nếu tồn tại folder ngày
                                    arr = TMP1(k).Split("\")
                                    If arr(arr.Length - 1).Equals(s) Then
                                        SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "\" & arr(arr.Length - 1)
                                        Exit While 'ngày
                                    End If
                                    k = k + 1
                                End While 'ngày
                                If k = TMP1.Length Then
                                    SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "\" & s
                                    System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH)

                                End If
                                Exit While 'MS_MAY
                            End If
                            j = j + 1
                        End While 'MS_MAY
                        'nếu chưa tồn tại folder MS_MAY
                        If j = TMP.Length Then
                            Dim s As String = ""
                            s = Microsoft.VisualBasic.DateAndTime.Day(Now()) & "_" & Month(Now()) & "_" & Year(Now())
                            SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "\" & strMS_MAY & "\" & s
                            System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH) 'Format(Now(), "dd_mm_yyyy"))
                        End If
                        Exit While 'hình máy
                    End If
                    i = i + 1
                End While 'hình máy
                'trường hợp chưa tồn tại folder hình máy
                If i = FILE_TEMPArr.Length Then
                    Dim s As String = ""
                    s = Microsoft.VisualBasic.DateAndTime.Day(Now()) & "_" & Month(Now()) & "_" & Year(Now())
                    SERVER_FOLDER_PATH = SERVER_FOLDER_PATH & "Hinh_May\" & strMS_MAY & "\" & s 'Format(Now(), "dd_mm_yyyy")
                    System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH) 'Format(Now(), "dd_mm_yyyy"))
                End If
            End If
        Else
            'MessageBox.Show("Không tồn tại đường dẫn. Vui lòng nhập đường dẫn mới")
        End If
        Return SERVER_FOLDER_PATH
    End Function
    Function LaySTTChoTaiLieu(ByVal strQuery As String) As Integer
        Dim TBTmp As New DataTable()
        TBTmp = SqlHelper.ExecuteDataset(IConnections.ConnectionString, CommandType.Text, strQuery).Tables(0)
        Dim stt As Integer = 0
        For i As Integer = 0 To TBTmp.Rows.Count - 1
            If stt < SoThuTu(TBTmp.Rows(i).Item(0)) Then
                stt = SoThuTu(TBTmp.Rows(i).Item(0))
            End If
        Next
        Return stt + 1
    End Function

    Function SoThuTu(ByVal strDuongDanHinh As String) As Integer
        Dim stt As Integer = 0
        Dim arr, arr1, arr2 As String()
        arr = strDuongDanHinh.Split("\")
        arr1 = arr(arr.Length - 1).Split(".")
        arr2 = arr1(arr1.Length - 2).Split("_")
        If IsNumeric(arr2(arr2.Length - 1)) Then
            stt = Integer.Parse(arr2(arr2.Length - 1))
        End If
        Return stt
    End Function

    Sub Xoahinh(ByVal strDuongdan As String)
        If System.IO.File.Exists(strDuongdan) Then
            Try
                System.IO.File.Delete(strDuongdan)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub LuuDuongDan(ByVal strDUONG_DAN As String, ByVal strHINH As String)
        If strHINH.Equals("") Then
            Exit Sub
        End If
        If System.IO.File.Exists(strDUONG_DAN) And Not System.IO.File.Exists(strHINH) Then
            Try
                System.IO.File.Copy(strDUONG_DAN, strHINH)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Function LayDuoiFile(ByVal strFile As String) As String
        Dim FILE_NAMEArr, arr As String()
        Dim FILE_NAME As String = ""
        Dim str As String = ""
        FILE_NAMEArr = strFile.Split("\")
        FILE_NAME = FILE_NAMEArr(FILE_NAMEArr.Length - 1)
        arr = FILE_NAME.Split(".")
        Return "." & arr(arr.Length - 1)
    End Function

    Sub OpenHinh(ByVal strDuongdan As String)
        If strDuongdan.Equals("") Then
            Exit Sub
        End If
        If System.IO.File.Exists(strDuongdan) Then
            Try
                System.Diagnostics.Process.Start(strDuongdan)
            Catch ex As Exception
            End Try

        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------
    Function GetIDInteger(ByVal Hkey As String) As Integer
        Dim SQL As String
        Dim VTB As New DataTable
        Try
            SQL = " EXEC sp_get_id_int '" & Hkey & "'"
            VTB.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, SQL))

            Try
                Return VTB.Rows(0).Item(0)
            Catch ex As Exception
                Return 1
            End Try
        Catch ex As Exception

        End Try
    End Function

    Function KiemThuMucTonTai(ByVal sThuMuc As String) As Boolean
        Try
            Return (System.IO.Directory.Exists(sThuMuc))
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function KiemFileTonTai(ByVal sFile As String) As Boolean
        Try
            Return (System.IO.File.Exists(sFile))
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function STTFileCungThuMuc(ByVal sThuMuc As String, ByVal sFile As String) As String
        Dim TenFile As String = sFile
        Dim DuoiFile As String
        Try
            DuoiFile = LayDuoiFile(sFile)
        Catch ex As Exception
            DuoiFile = ""
        End Try


        Try
            Dim sTongFile() As String
            Dim i As Integer = 1

            TenFile = sFile
            sTongFile = System.IO.Directory.GetFiles(sThuMuc)


            For i = 1 To sTongFile.Length + 1
                If System.IO.File.Exists(sThuMuc & "\" & TenFile) = True Then
                    If i.ToString.Length = 1 Then
                        TenFile = sFile.Replace(DuoiFile, "-00" + i.ToString()) & DuoiFile
                    Else
                        If i.ToString.Length = 2 Then
                            TenFile = sFile.Replace(DuoiFile, "-0" + i.ToString()) & DuoiFile
                        Else
                            TenFile = sFile.Replace(DuoiFile, "-" + i.ToString()) & DuoiFile
                        End If
                    End If
                Else
                    Exit For
                End If
            Next
        Catch ex As Exception
            TenFile = ""
        End Try

        Return TenFile
    End Function

    Function GetSerial() As String
        Dim strHD As String
        strHD = ""
        Try
            Dim hdCollection As ArrayList
            hdCollection = New ArrayList()


            Dim searcher As ManagementObjectSearcher
            searcher = New ManagementObjectSearcher("SELECT  * FROM Win32_DiskDrive")

            For Each wmi_HD As ManagementObject In searcher.Get()
                Dim hd As New HardDrive()
                hd.Model = wmi_HD("Model").ToString()
                hd.Type = wmi_HD("InterfaceType").ToString()
                hdCollection.Add(hd)
            Next

            searcher = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")

            Dim i As Integer = 0
            For Each wmi_HD As ManagementObject In searcher.Get()
                Dim hd As HardDrive = DirectCast(hdCollection(i), HardDrive)
                If wmi_HD("SerialNumber").ToString() = "null" Then
                    hd.serialNo = ""
                Else
                    hd.serialNo = wmi_HD("SerialNumber").ToString().Trim
                End If
                Exit For
            Next

            For Each hd As HardDrive In hdCollection
                strHD = hd.serialNo
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            strHD = ""
        End Try
        Return strHD

    End Function

    Function MGetSoNgayThang(ByVal Tu As Date, ByVal Den As Date) As Integer
        If Tu > Den Then
            Dim tmp As Date
            tmp = Tu
            Tu = Den
            Den = tmp

        End If

        Dim month As Integer
        month = 0
        While (Tu <= Den)
            Tu = Tu.AddMonths(1)
            month = month + 1
        End While
        Return month - 1
    End Function

#Region "MLoadCboTreeList"
    Function MLoadCboTreeList(ByRef cboTree As MVControl.ucComboboxTreeList, ByVal dtTmp As DataTable, ByVal MaCha As String, ByVal Ma As String,
                             ByVal Ten As String) As Boolean
        Try
            cboTree.DataSource = Nothing
            cboTree.KeyFieldName = Ma
            cboTree.ParentFieldName = MaCha
            cboTree.ColumnDisplayName = Ten
            cboTree.DataSource = dtTmp
            cboTree.DataBind()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "MLoadLookUpEdit"
    Function MLoadGridLookUpEdit(ByVal cbo As DevExpress.XtraEditors.GridLookUpEdit, ByVal dtTmp As DataTable, ByVal Ma As String,
                             ByVal Ten As String, ByVal sForm As String) As Boolean
        Try

            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma
            cbo.Properties.View.BestFitColumns()

            cbo.EditValue = dtTmp.Rows(0)(Ma)
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In cbo.Properties.View.Columns
                If col.Visible Then
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                    col.AppearanceHeader.Options.UseTextOptions = True
                    col.Caption = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, sForm, col.FieldName, Modules.TypeLanguage)

                End If
            Next

            Try
                AddHandler cbo.SizeChanged, AddressOf Me.GridLookUpEdit_SizeChanged
            Catch ex As Exception
            End Try

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Sub GridLookUpEdit_SizeChanged(sender As Object, e As EventArgs)
        Dim editor As GridLookUpEdit = CType(sender, GridLookUpEdit)
        Dim properties As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = editor.Properties
        properties.PopupFormSize = New Size(editor.Width + 25, properties.PopupFormSize.Height)
    End Sub


#End Region
#Region "MLoadLookUpEdit"
    Function MLoadLookUpEdit(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sQuery As String, ByVal Ma As String,
                            ByVal Ten As String, ByVal TenCot As String) As Boolean
        Try
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""

            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sQuery))
            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma
            cbo.Properties.Columns.Clear()
            cbo.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten))
            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoComplete
            cbo.EditValue = dtTmp.Rows(0)(Ma)
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            cbo.Properties.Columns(Ten).Caption = TenCot
            If TenCot.Trim = "" Then
                cbo.Properties.ShowHeader = False
            Else
                cbo.Properties.ShowHeader = True
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Function MLoadLookUpEdit(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal dtTmp As DataTable, ByVal Ma As String,
                             ByVal Ten As String, ByVal TenCot As String) As Boolean
        Try
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""
            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma
            cbo.Properties.Columns.Clear()
            cbo.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten))
            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoComplete
            cbo.EditValue = dtTmp.Rows(0)(Ma)
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            cbo.Properties.Columns(Ten).Caption = TenCot
            If TenCot.Trim = "" Then
                cbo.Properties.ShowHeader = False
            Else
                cbo.Properties.ShowHeader = True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadLookUpEdit(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal TenCot As String, ByVal bStored As Boolean) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""
            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma
            cbo.Properties.Columns.Clear()
            cbo.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten))
            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoComplete
            cbo.EditValue = dtTmp.Rows(0)(Ma)
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            cbo.Properties.Columns(Ten).Caption = TenCot
            If TenCot.Trim = "" Then
                cbo.Properties.ShowHeader = False
            Else
                cbo.Properties.ShowHeader = True
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadLookUpEdit(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal TenCot As String, ByVal bStored As Boolean, ByVal Param As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored, Param))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""

            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma
            cbo.Properties.Columns.Clear()
            cbo.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten))
            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoComplete
            cbo.EditValue = dtTmp.Rows(0)(Ma)
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            cbo.Properties.Columns(Ten).Caption = TenCot
            If TenCot.Trim = "" Then
                cbo.Properties.ShowHeader = False
            Else
                cbo.Properties.ShowHeader = True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadLookUpEdit(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal TenCot As String, ByVal bStored As Boolean, ByVal Param As String,
                        ByVal Param1 As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored, Param, Param1))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""
            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma
            cbo.Properties.Columns.Clear()
            cbo.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten))
            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoComplete
            cbo.EditValue = dtTmp.Rows(0)(Ma)
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            cbo.Properties.Columns(Ten).Caption = TenCot
            If TenCot.Trim = "" Then
                cbo.Properties.ShowHeader = False
            Else
                cbo.Properties.ShowHeader = True
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region



#Region "MLoadCheckedComboBoxEdit"
    Function MLoadCheckedComboBoxEdit(ByVal cbo As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal dtTmp As DataTable, ByVal Ma As String,
                             ByVal Ten As String) As Boolean
        Try
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""
            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma
            cbo.Properties.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.EditValue = dtTmp.Rows(0)(Ma)
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            Dim sTmp As String = ""
            For Each drRow As DataRow In dtTmp.Rows
                sTmp = sTmp & ", " & drRow(Ma).ToString()
            Next
            cbo.SetEditValue(sTmp.Substring(1, sTmp.Length - 1))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadCheckedComboBoxEdit(ByVal cbo As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal sQuery As String, ByVal Ma As String,
                            ByVal Ten As String) As Boolean
        Try
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sQuery))
            Return MLoadCheckedComboBoxEdit(cbo, dtTmp, Ma, Ten)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadCheckedComboBoxEdit(ByVal cbo As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal bStored As Boolean) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            Return MLoadCheckedComboBoxEdit(cbo, dtTmp, Ma, Ten)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadCheckedComboBoxEdit(ByVal cbo As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal bStored As Boolean, ByVal Param As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored, Param))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            Return MLoadCheckedComboBoxEdit(cbo, dtTmp, Ma, Ten)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadCheckedComboBoxEdit(ByVal cbo As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal bStored As Boolean, ByVal Param As String, ByVal Param1 As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored, Param, Param1))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            Return MLoadCheckedComboBoxEdit(cbo, dtTmp, Ma, Ten)
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "MLoadLookUpEditNoRemove"
    Function MLoadLookUpEditNoRemove(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sQuery As String, ByVal Ma As String,
                            ByVal Ten As String, ByVal sForm As String) As Boolean
        Try
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""


            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sQuery))
            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma

            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoFilter
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            Try

                cbo.Properties.Columns.Clear()
                Dim column As DevExpress.XtraEditors.Controls.LookUpColumnInfo
                For intColumn As Integer = 0 To dtTmp.Columns.Count - 1
                    column = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    column.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sForm, dtTmp.Columns(intColumn).ColumnName, Commons.Modules.TypeLanguage)
                    column.FieldName = dtTmp.Columns(intColumn).ColumnName
                    cbo.Properties.Columns.Add(column)
                Next
            Catch ex As Exception

            End Try
            cbo.EditValue = dtTmp.Rows(0)(Ma)
            BestFitColumns(cbo)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadLookUpEditNoRemove(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal dtTmp As DataTable, ByVal Ma As String,
                             ByVal Ten As String, ByVal sForm As String) As Boolean
        Try
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""

            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma

            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoFilter
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            Try
                cbo.Properties.Columns.Clear()
                Dim column As DevExpress.XtraEditors.Controls.LookUpColumnInfo
                For intColumn As Integer = 0 To dtTmp.Columns.Count - 1
                    column = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    column.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sForm, dtTmp.Columns(intColumn).ColumnName, Commons.Modules.TypeLanguage)
                    column.FieldName = dtTmp.Columns(intColumn).ColumnName
                    cbo.Properties.Columns.Add(column)
                Next
            Catch ex As Exception

            End Try

            cbo.EditValue = dtTmp.Rows(0)(Ma)
            BestFitColumns(cbo)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadLookUpEditNoRemove(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal sForm As String, ByVal bStored As Boolean) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""

            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma

            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoFilter
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            Try
                cbo.Properties.Columns.Clear()
                Dim column As DevExpress.XtraEditors.Controls.LookUpColumnInfo
                For intColumn As Integer = 0 To dtTmp.Columns.Count - 1
                    column = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    column.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sForm, dtTmp.Columns(intColumn).ColumnName, Commons.Modules.TypeLanguage)
                    column.FieldName = dtTmp.Columns(intColumn).ColumnName
                    cbo.Properties.Columns.Add(column)
                Next
            Catch ex As Exception

            End Try

            cbo.EditValue = dtTmp.Rows(0)(Ma)
            BestFitColumns(cbo)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadLookUpEditNoRemove(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal sForm As String, ByVal bStored As Boolean, ByVal Param As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored, Param))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""

            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma

            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoFilter
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            Try
                cbo.Properties.Columns.Clear()
                Dim column As DevExpress.XtraEditors.Controls.LookUpColumnInfo
                For intColumn As Integer = 0 To dtTmp.Columns.Count - 1
                    column = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    column.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sForm, dtTmp.Columns(intColumn).ColumnName, Commons.Modules.TypeLanguage)
                    column.FieldName = dtTmp.Columns(intColumn).ColumnName
                    cbo.Properties.Columns.Add(column)
                Next
            Catch ex As Exception

            End Try

            cbo.EditValue = dtTmp.Rows(0)(Ma)
            BestFitColumns(cbo)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadLookUpEditNoRemove(ByVal cbo As DevExpress.XtraEditors.LookUpEdit, ByVal sStored As String, ByVal Ma As String,
                        ByVal Ten As String, ByVal sForm As String, ByVal bStored As Boolean, ByVal Param As String,
                        ByVal Param1 As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            If bStored Then
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, sStored, Param, Param1))
            Else
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sStored))
            End If
            cbo.Properties.DataSource = Nothing
            cbo.Properties.DisplayMember = ""
            cbo.Properties.ValueMember = ""
            cbo.Properties.DataSource = dtTmp
            cbo.Properties.DisplayMember = Ten
            cbo.Properties.ValueMember = Ma

            cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            cbo.Properties.BestFitMode = BestFitMode.BestFit
            cbo.Properties.SearchMode = SearchMode.AutoFilter
            If dtTmp.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
            Try

                cbo.Properties.Columns.Clear()
                Dim column As DevExpress.XtraEditors.Controls.LookUpColumnInfo
                For intColumn As Integer = 0 To dtTmp.Columns.Count - 1
                    column = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    column.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sForm, dtTmp.Columns(intColumn).ColumnName, Commons.Modules.TypeLanguage)
                    column.FieldName = dtTmp.Columns(intColumn).ColumnName
                    cbo.Properties.Columns.Add(column)
                Next
            Catch ex As Exception

            End Try

            cbo.EditValue = dtTmp.Rows(0)(Ma)
            BestFitColumns(cbo)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub BestFitColumns(ByRef lookUpEdit As DevExpress.XtraEditors.LookUpEdit)
        lookUpEdit.Properties.BestFit()
        Dim width As Integer = 0
        For Each column As DevExpress.XtraEditors.Controls.LookUpColumnInfo In lookUpEdit.Properties.Columns
            If column.Visible Then
                width += column.Width
            End If
        Next
        lookUpEdit.Properties.PopupWidth = width + 4 + SystemInformation.VerticalScrollBarWidth
    End Sub

#End Region

    'dang lam
#Region "MAutoCompleteTextEdit"
    Function MAutoCompleteTextEdit(ByVal txt As DevExpress.XtraEditors.TextEdit, ByVal sQuery As String, ByVal Ma As String) As Boolean
        Try
            txt.MaskBox.AutoCompleteCustomSource = Nothing
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sQuery))
            Dim postSource As String()
            dtTmp = dtTmp.DefaultView.ToTable(True, Ma)
            postSource = dtTmp.Rows.Cast(Of DataRow).Select(Function(dr) dr(Ma).ToString).ToArray()
            Dim source = New AutoCompleteStringCollection()
            source.AddRange(postSource)
            txt.MaskBox.AutoCompleteCustomSource = source
            txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MAutoCompleteTextEdit(ByVal txt As DevExpress.XtraEditors.TextEdit, ByVal dtData As DataTable, ByVal Ma As String) As Boolean
        Try
            txt.MaskBox.AutoCompleteCustomSource = Nothing
            Dim postSource As String()
            dtData = dtData.DefaultView.ToTable(True, Ma)
            postSource = dtData.Rows.Cast(Of DataRow).Select(Function(dr) dr(Ma).ToString).ToArray()
            Dim source = New AutoCompleteStringCollection()
            source.AddRange(postSource)
            txt.MaskBox.AutoCompleteCustomSource = source
            txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "MLoadXtraGrid"

    Function MLoadXtraGrid(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView,
                           ByVal sQuery As String, ByVal MEditable As Boolean, ByVal MPopulateColumns As Boolean,
                           ByVal MColumnAutoWidth As Boolean, ByVal MBestFitColumns As Boolean) As Boolean
        Try

            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sQuery))
            grd.DataSource = dtTmp

            grv.OptionsBehavior.Editable = MEditable
            If MPopulateColumns = True Then grv.PopulateColumns()
            grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth
            grv.OptionsView.AllowHtmlDrawHeaders = True
            grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
            grv.OptionsBehavior.FocusLeaveOnTab = True
            If MBestFitColumns Then grv.BestFitColumns()
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function




    Function LapBPTDinhKy(ByVal dtBTDK As DataTable, ByVal sNLap As String, ByVal sNGSat As String) As Boolean
        Dim sPBTCVCT As String
        sPBTCVCT = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName
        Try
            'grd.Update()
            Dim i As Integer = 0, j As Integer = 0
            Dim strGioTam, MS_PBT As String
            MS_PBT = ""
            Dim dtReader As SqlDataReader
            Dim sql As String
            Dim vtbTam As New DataTable
            strGioTam = TimeValue(Now)
            Dim _temp As New DataTable()
            _temp = dtBTDK.Copy()


            For Each _row In _temp.Rows
                Dim NgayBDKH As Date
                Dim NgayKTKH As Date
                Try
                    NgayBDKH = CDate(_row("NGAY_BTKT"))
                Catch ex As Exception
                    NgayBDKH = Now.Date
                End Try
                Try
                    NgayKTKH = CDate(_row("NGAY_BTKT"))
                Catch ex As Exception
                    NgayKTKH = Now.Date
                End Try
                MS_PBT = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(NgayBDKH.Year, NgayBDKH.Month)

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI", MS_PBT, _row("MS_MAY"), _row("MS_LOAI_BT"),
                        DateValue(Now), strGioTam.ToString, _row("TEN_LOAI_BT"), 1, _row("NGAY_BTKT"), sNLap,
                        Commons.Modules.UserName, NgayBDKH, NgayKTKH, sNGSat, _row("MUC_UU_TIEN"))


                If Commons.Modules.iMacDinhCVPT = 0 Or Commons.Modules.iMacDinhCVPT = 1 Then
                    Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH) " &
                            " SELECT '" & MS_PBT & "',MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN, " &
                            " CASE ISNULL(CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH,0) WHEN 0 THEN  ISNULL(CONG_VIEC.THOI_GIAN_DU_KIEN,0) ELSE ISNULL(CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH,0) END AS THOI_GIAN_DU_KIEN " &
                            " FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CONG_VIEC.MS_CV INNER JOIN " &
                            " CAU_TRUC_THIET_BI_CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND " &
                            " MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND " &
                            " MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV AND dbo.CAU_TRUC_THIET_BI_CONG_VIEC.ACTIVE = 1 WHERE " &
                            " MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = N'" & _row("MS_MAY") & "' AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                    'UPDATE THAO TAC SO NGUOI, DV NS VAO PHIEU BAO TRI CONG VIEC
                    Commons.Modules.SQLString = " UPDATE PHIEU_BAO_TRI_CONG_VIEC SET [THAO_TAC]  = A.[THAO_TAC],  [TIEU_CHUAN_KT] = A.[TIEU_CHUAN_KT] ,[PATH_HD] = A.[PATH_HD] , " &
                                " [SO_NGUOI] = A.[SO_NGUOI] ,[YEU_CAU_NS] = A.[YEU_CAU_NS] ,[YEU_CAU_DUNG_CU] = A.[YEU_CAU_DUNG_CU]  " &
                                " FROM PHIEU_BAO_TRI_CONG_VIEC B INNER JOIN CONG_VIEC A ON A.MS_CV = B.MS_CV WHERE MS_PHIEU_BAO_TRI = '" & MS_PBT & "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    Try
                        sql = "SELECT '" & MS_PBT & "' as MS_PHIEU_BAO_TRI ,MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN,CONG_VIEC.THOI_GIAN_DU_KIEN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CONG_VIEC.MS_CV INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV WHERE MAY_LOAI_BTPN_CONG_VIEC.MS_MAY=N'" & _row("MS_MAY") & "' AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                        vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                        For Each vr As DataRow In vtbTam.Rows
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_PHIEU_BAO_TRI_CONG_VIEC_LOG", vr("MS_PHIEU_BAO_TRI"), vr("MS_CV"), vr("MS_BO_PHAN"), "frmKehoachtongthe_odd", Commons.Modules.UserName, 1)
                        Next
                    Catch ex As Exception
                    End Try
                    sql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_BDCV = '" & NgayBDKH & "' AND NGAY_KTCV = '" & NgayKTKH & "' WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                    Catch ex As Exception
                    End Try

                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertCongNhanPBT", MS_PBT)
                    Catch ex As Exception
                    End Try
                End If

                If Commons.Modules.iMacDinhCVPT = 0 Then
                    Commons.Modules.SQLString = "SELECT MS_CV FROM PHIEU_BAO_TRI_CONG_VIEC INNER JOIN PHIEU_BAO_TRI ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI WHERE MS_MAY ='" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                    While dtReader.Read
                        Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH) " &
                            " SELECT '" & MS_PBT & "'," & dtReader.Item("MS_CV") & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG " &
                            " WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & dtReader.Item(0)
                        Try
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        Catch ex As Exception
                        End Try
                        Try
                            sql = "SELECT '" & MS_PBT & "' as MS_PHIEU_BAO_TRI ," & dtReader.Item("MS_CV") & " as MS_CV ,MS_BO_PHAN,MS_PT,SO_LUONG " &
                                    " FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' " &
                                    " AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & dtReader.Item(0)
                            vtbTam = New DataTable
                            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                            For Each vr As DataRow In vtbTam.Rows
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_LOG", vr("MS_PHIEU_BAO_TRI"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), "frmKehoachtongthe_odd", Commons.Modules.UserName, 1)
                            Next

                        Catch ex As Exception

                        End Try
                    End While
                    dtReader.Close()


                    Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, sPBTCVCT)
                    Commons.Modules.SQLString = "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV, " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, " &
                            "0 AS SL_KH, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT " &
                            "INTO " & sPBTCVCT & " " &
                            "FROM         CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON " &
                            "CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN And " &
                            "CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT INNER JOIN " &
                            "MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG ON " &
                            "CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY And " &
                            "CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_BO_PHAN And " &
                            "CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT INNER JOIN " &
                            "PHIEU_BAO_TRI ON MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT = PHIEU_BAO_TRI.MS_LOAI_BT AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
                            "WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI='" & MS_PBT & "'"

                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    Dim dtReaderTam As SqlDataReader
                    Dim iSL_BTPN As Integer = 0, iSL_CTTB As Integer = 0
                    Dim iSL_KH As Integer = 0

                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM " & sPBTCVCT)
                    While dtReader.Read
                        'lay so luong can thuc hien cho phu tung trong lich bao tri dinh ky
                        Commons.Modules.SQLString = "SELECT ISNULL(SO_LUONG,0) AS SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_CV=" & dtReader.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "'"
                        dtReaderTam = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        While dtReaderTam.Read
                            iSL_BTPN = dtReaderTam.Item("SO_LUONG")
                        End While
                        dtReaderTam.Close()
                        'lay so luong tren tung vi tri cua phu tung trong cau truc thiet bi
                        Commons.Modules.SQLString = "SELECT MS_MAY,MS_BO_PHAN,MS_PT, SUM(SO_LUONG) AS SL_TAT_CA_VI_TRI FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "' GROUP BY MS_MAY,MS_BO_PHAN,MS_PT"
                        dtReaderTam = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        While dtReaderTam.Read
                            iSL_CTTB = dtReaderTam.Item("SL_TAT_CA_VI_TRI")
                        End While
                        dtReaderTam.Close()

                        'tim so luong tren tung vi tri co bao nhieu do so luong ben btnpn sang cho hop le
                        dtReaderTam = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                "SELECT * FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE ACTIVE = 1 AND MS_MAY=N'" & _row("MS_MAY") &
                                "' AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "'")
                        While dtReaderTam.Read And iSL_BTPN > 0
                            iSL_KH = iSL_BTPN - dtReaderTam.Item("SO_LUONG")
                            If iSL_KH <= 0 Then
                                iSL_KH = iSL_BTPN 'dtReaderTam.Item("SO_LUONG")
                            ElseIf iSL_KH > dtReaderTam.Item("SO_LUONG") Then
                                iSL_KH = dtReaderTam.Item("SO_LUONG")
                            Else
                                iSL_KH = dtReaderTam.Item("SO_LUONG")
                            End If
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE " & sPBTCVCT & " SET SL_KH=" & iSL_KH & " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' AND MS_CV=" & dtReader.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "' AND MS_VI_TRI_PT='" & dtReaderTam.Item("MS_VI_TRI_PT") & "'")
                            iSL_BTPN -= dtReaderTam.Item("SO_LUONG")
                        End While
                        dtReaderTam.Close()
                    End While

                End If
                'tu dong insert cong nhan neu cot auto_cn = 1 trong thong tin chung
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertCongNhanPBT", MS_PBT)
                Catch ex As Exception
                End Try


            Next
            If Commons.Modules.iMacDinhCVPT = 0 Then
                Commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, SL_KH, MS_VI_TRI_PT)" & " SELECT DISTINCT * FROM " & sPBTCVCT & " WHERE SL_KH > 0"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                Try
                    sql = " SELECT DISTINCT MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT FROM " & sPBTCVCT & " WHERE SL_KH>0"
                    vtbTam = New DataTable
                    vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                    For Each vr As DataRow In vtbTam.Rows
                        Dim vtbT As New DataTable
                        sql = "select STT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & vr("MS_PHIEU_BAO_TRI") & "' AND  MS_CV='" & vr("MS_CV") & "' AND  MS_BO_PHAN='" & vr("MS_BO_PHAN") & "' AND  MS_PT='" & vr("MS_PT") & "'"
                        vtbT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                        For Each VR1 As DataRow In vtbT.Rows
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_LOG", vr("MS_PHIEU_BAO_TRI"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), VR1("STT"), "frmKehoachtongthe_odd", Commons.Modules.UserName, 1)
                        Next
                    Next
                Catch ex As Exception

                End Try
                'CAP NHAT LAI SO LUONG CHO  BANG CHA
                Commons.Modules.SQLString = "SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SUM(SL_KH) AS SL_TONG FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' GROUP BY MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_LOG", MS_PBT, dtReader.Item("MS_CV"), dtReader.Item("MS_BO_PHAN"), dtReader.Item("MS_PT"), "frmKehoachtongthe_odd", Commons.Modules.UserName, 2)
                    Catch ex As Exception

                    End Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH=" & dtReader.Item("SL_TONG") & " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' AND MS_CV=" & dtReader.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "'")
                End While

            End If
            Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, sPBTCVCT)
            Commons.MssBox.Show("frmKehoachtongthe_odd", "MsgQuyenKT23")
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", "msgLapPhieuBaoTriKhongThanhCong", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString, "frmKehoachtongthe_odd", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, sPBTCVCT)
            Return False
        End Try
    End Function


    Function MLoadXtraGrid(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView,
                           ByVal dtTmp As DataTable, ByVal MEditable As Boolean, ByVal MPopulateColumns As Boolean,
                           ByVal MColumnAutoWidth As Boolean, ByVal MBestFitColumns As Boolean) As Boolean
        Try
            grd.DataSource = dtTmp
            grv.OptionsBehavior.Editable = MEditable
            If MPopulateColumns = True Then grv.PopulateColumns()
            grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth
            grv.OptionsView.AllowHtmlDrawHeaders = True
            grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
            If MBestFitColumns Then grv.BestFitColumns()
            grv.OptionsBehavior.FocusLeaveOnTab = True
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function MLoadXtraGridDD(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView,
                        ByVal sQuery As String, ByVal MEditable As Boolean, ByVal MPopulateColumns As Boolean,
                        ByVal MColumnAutoWidth As Boolean, ByVal MBestFitColumns As Boolean,
                        ByVal MloadNNgu As Boolean, ByVal fName As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sQuery))
            grd.DataSource = dtTmp
            If Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DD_LUOI WHERE ID_FORM = '" & fName & "' AND ID_GRID  ='" & grv.Name & "'")) = 1 Then
                Dim text As String = (Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_XML FROM dbo.DD_LUOI  WHERE ID_FORM = '" & fName & "' AND ID_GRID  ='" & grv.Name & "'")))
                Dim byteArray As Byte() = Encoding.ASCII.GetBytes(text)
                Dim stream As MemoryStream = New MemoryStream(byteArray)
                grv.RestoreLayoutFromStream(stream)
            Else
                MyMenuItemSave(Nothing, Nothing, grv, fName)
            End If
            If Commons.Modules.UserName.ToLower() = "admin" Or Commons.Modules.UserName.ToLower() = "administrator" Then
                AddHandler grv.ShowGridMenu, Sub(ByVal a As Object, ByVal b As EventArgs) Grv_ShowGridMenu(a, b, grv, fName)
            End If
            grv.OptionsBehavior.Editable = MEditable
            If MPopulateColumns = True Then grv.PopulateColumns()
            grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth
            grv.OptionsView.AllowHtmlDrawHeaders = True
            grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
            If MBestFitColumns Then grv.BestFitColumns()
            If MloadNNgu Then MLoadNNXtraGrid(grv, fName)
            grv.OptionsBehavior.FocusLeaveOnTab = True
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadXtraGrid(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView,
                        ByVal sQuery As String, ByVal MEditable As Boolean, ByVal MPopulateColumns As Boolean,
                        ByVal MColumnAutoWidth As Boolean, ByVal MBestFitColumns As Boolean,
                        ByVal MloadNNgu As Boolean, ByVal fName As String) As Boolean
        Try
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sQuery))
            grd.DataSource = dtTmp
            grv.OptionsBehavior.Editable = MEditable
            If MPopulateColumns = True Then grv.PopulateColumns()
            grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth
            grv.OptionsView.AllowHtmlDrawHeaders = True
            grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
            If MBestFitColumns Then grv.BestFitColumns()
            If MloadNNgu Then MLoadNNXtraGrid(grv, fName)
            grv.OptionsBehavior.FocusLeaveOnTab = True
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadXtraGridDD(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView,
                       ByVal dtTmp As DataTable, ByVal MEditable As Boolean, ByVal MPopulateColumns As Boolean,
                       ByVal MColumnAutoWidth As Boolean, ByVal MBestFitColumns As Boolean, ByVal MloadNNgu As Boolean, ByVal fName As String) As Boolean
        Try
            grd.DataSource = dtTmp
            If Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DD_LUOI WHERE ID_FORM = '" & fName & "' AND ID_GRID  ='" & grv.Name & "'")) = 1 Then
                Dim text As String = (Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_XML FROM dbo.DD_LUOI  WHERE ID_FORM = '" & fName & "' AND ID_GRID  ='" & grv.Name & "'")))
                Dim byteArray As Byte() = Encoding.ASCII.GetBytes(text)
                Dim stream As MemoryStream = New MemoryStream(byteArray)
                grv.RestoreLayoutFromStream(stream)
            Else
                MyMenuItemSave(Nothing, Nothing, grv, fName)
            End If
            If Commons.Modules.UserName.ToLower() = "admin" Or Commons.Modules.UserName.ToLower() = "administrator" Then
                AddHandler grv.ShowGridMenu, Sub(ByVal a As Object, ByVal b As EventArgs) Grv_ShowGridMenu(a, b, grv, fName)
            End If
            grv.OptionsBehavior.Editable = MEditable
            If MPopulateColumns = True Then grv.PopulateColumns()
            grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth
            grv.OptionsView.AllowHtmlDrawHeaders = True
            grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
            If MBestFitColumns Then grv.BestFitColumns()
            If MloadNNgu Then MLoadNNXtraGrid(grv, fName)
            grv.OptionsBehavior.FocusLeaveOnTab = True

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function MLoadXtraGrid(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView,
                       ByVal dtTmp As DataTable, ByVal MEditable As Boolean, ByVal MPopulateColumns As Boolean,
                       ByVal MColumnAutoWidth As Boolean, ByVal MBestFitColumns As Boolean, ByVal MloadNNgu As Boolean, ByVal fName As String) As Boolean
        Try
            grd.DataSource = dtTmp
            grv.OptionsBehavior.Editable = MEditable
            If MPopulateColumns = True Then grv.PopulateColumns()
            grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth
            grv.OptionsView.AllowHtmlDrawHeaders = True
            grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
            If MBestFitColumns Then grv.BestFitColumns()
            If MloadNNgu Then MLoadNNXtraGrid(grv, fName)
            grv.OptionsBehavior.FocusLeaveOnTab = True
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Grv_ShowGridMenu(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fName As String)
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then Return
        Try
            Dim headerMenu As DevExpress.XtraGrid.Menu.GridViewMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewMenu)
            'Dim menuItem As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Reset Grid")
            'menuItem.BeginGroup = True
            'menuItem.Tag = e.Menu
            'AddHandler menuItem.Click, Sub(ByVal a As Object, ByVal b As EventArgs) MenuItemReset_Click(sender, e, grv, fName)
            'headerMenu.Items.Add(menuItem)
            Dim menuSave As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Save Grid")
            menuSave.BeginGroup = True
            menuSave.Tag = e.Menu
            AddHandler menuSave.Click, Sub(ByVal a As Object, ByVal b As EventArgs) MyMenuItemSave(sender, e, grv, fName)
            headerMenu.Items.Add(menuSave)
        Catch
        End Try
    End Sub

    'Public Sub MenuItemReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fName As String)
    '    Try
    '        Dim text As String = (Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_GOC FROM dbo.DD_LUOI WHERE ID_FORM = '" & fName & "' AND ID_GRID  ='" & grv.Name & "'")))
    '        Dim byteArray As Byte() = Encoding.ASCII.GetBytes(text)
    '        Dim stream As MemoryStream = New MemoryStream(byteArray)
    '        grv.RestoreLayoutFromStream(stream)
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Public Sub MyMenuItemSave(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fName As String)
        Try
            Dim str As Stream = New System.IO.MemoryStream()
            grv.SaveLayoutToStream(str)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Dim reader As StreamReader = New StreamReader(str)
            Dim text As String = reader.ReadToEnd()
            'Dim doc As XmlDocument = New XmlDocument()
            'doc.LoadXml(text)
            'Dim nodes As XmlNodeList = doc.SelectNodes("//property[@name='VisibleIndex']")
            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='Width']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='MinWidth']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='MaxWidth']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='GroupSummary']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='ActiveFilterString']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='GroupSummarySortInfoState']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='FindFilterText']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='FindPanelVisible']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next

            'nodes = doc.SelectNodes("//property[@name='ActiveFilterEnabled']")

            'For Each xn As XmlNode In nodes
            '    Dim parent As XmlNode = xn.ParentNode
            '    parent.RemoveChild(xn)
            'Next
            If Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DD_LUOI WHERE ID_FORM = '" & fName & "' AND ID_GRID  ='" & grv.Name & "'")) = 0 Then
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "INSERT INTO dbo.DD_LUOI (ID_FORM,ID_GRID,ID_XML,ID_GOC)VALUES(   N'" & fName & "', N'" & grv.Name & "', N'" & text & "',  N'" & text & "' )")
            Else
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.DD_LUOI SET ID_XML = N'" & text & "' WHERE ID_FORM = '" & fName & "' AND ID_GRID  ='" & grv.Name & "'")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub MLoadNNXtraGrid(ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fName As String)
        Dim dtTmp As New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT DISTINCT KEYWORD , CASE " & Modules.TypeLanguage & " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" & fName & "' "))

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grv.Columns
            If col.Visible Then
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                col.AppearanceHeader.Options.UseTextOptions = True
                'col.Caption = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, fName, col.FieldName, Modules.TypeLanguage)
                col.Caption = GetNN(dtTmp, col.FieldName, fName)
            End If
        Next
    End Sub

    Sub MLoadNNXtraGrid(ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fName As String, ByVal NN As Integer)

        Dim dtTmp As New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT DISTINCT KEYWORD , CASE " & Modules.TypeLanguage & " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" & fName & "' "))
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grv.Columns
            If col.Visible Then
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                col.AppearanceHeader.Options.UseTextOptions = True
                'col.Caption = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, fName, col.FieldName, NN)
                col.Caption = GetNN(dtTmp, col.FieldName, fName)
            End If
        Next
    End Sub

#End Region

#End Region


#Region "exportt file word"

    Sub WordReplace(ByVal doc As Microsoft.Office.Interop.Word.Document, ByVal sFindText As String, ByVal sReplaceText As String)
    Dim missing As Object = System.Type.Missing
    For Each tmpRange As Microsoft.Office.Interop.Word.Range In doc.StoryRanges
        tmpRange.Find.Text = sFindText
        tmpRange.Find.Replacement.Text = sReplaceText
        tmpRange.Find.Replacement.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify
        tmpRange.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
        Dim replaceAll As Object = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll
        tmpRange.Find.Execute(missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, replaceAll, missing, missing, missing, missing)
        Exit For
    Next
End Sub

    #End Region


#Region "MLoadXtraTreeList"

    Function MLoadXtraTreeList(ByVal XtraTreeList As DevExpress.XtraTreeList.TreeList, Editable As Boolean, dtTmp As DataTable, ByVal MaCha As String, ByVal Ma As String) As Boolean
        Try
            XtraTreeList.DataSource = Nothing
            XtraTreeList.BeginUpdate()
            XtraTreeList.KeyFieldName = Ma
            XtraTreeList.ParentFieldName = MaCha
            XtraTreeList.OptionsBehavior.Editable = Editable
            XtraTreeList.DataSource = dtTmp
            XtraTreeList.EndUpdate()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function MLoadXtraTreeList(ByVal XtraTreeList As DevExpress.XtraTreeList.TreeList, Editable As Boolean, dtTmp As DataTable, ByVal MaCha As String, ByVal Ma As String, ByVal fName As String) As Boolean
        Try
            XtraTreeList.DataSource = Nothing
            XtraTreeList.BeginUpdate()
            XtraTreeList.KeyFieldName = Ma
            XtraTreeList.ParentFieldName = MaCha
            XtraTreeList.OptionsBehavior.Editable = Editable
            XtraTreeList.DataSource = dtTmp
            XtraTreeList.PopulateColumns()
            XtraTreeList.EndUpdate()
            MLoadNNXtraTreeList(XtraTreeList, fName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub MLoadNNXtraTreeList(ByVal XtraTreeList As DevExpress.XtraTreeList.TreeList, ByVal fName As String)
        For i = 0 To XtraTreeList.Columns.Count - 1
            XtraTreeList.Columns(i).Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, fName, XtraTreeList.Columns(i).Name, Commons.Modules.TypeLanguage)
        Next
    End Sub

#End Region
#Region "Create datatable to table SQL"



    Public Function ConvertToDataTable(Of T)(list As IList(Of T)) As DataTable
        Dim entityType As Type = GetType(T)
        Dim table As New DataTable()
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(entityType)
        For Each prop As PropertyDescriptor In properties
            table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each prop As PropertyDescriptor In properties
                row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function
    Function MCreateTableToDatatable(ByVal connectionString As String, ByVal tableSQLName As String, ByVal table As DataTable, ByVal sTaoTable As String) As Boolean
        Try
            If sTaoTable = "" Then
                If Not MCreateTable(tableSQLName, table, connectionString) Then
                    Return False
                End If
            Else
                Commons.Modules.ObjSystems.XoaTable(tableSQLName)
                SqlHelper.ExecuteReader(connectionString, CommandType.Text, sTaoTable)
            End If

            Using connection As New System.Data.SqlClient.SqlConnection(connectionString)
                Dim bulkCopy As New System.Data.SqlClient.SqlBulkCopy(connection, System.Data.SqlClient.SqlBulkCopyOptions.TableLock Or System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers Or System.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction, Nothing)

                bulkCopy.DestinationTableName = tableSQLName
                connection.Open()

                bulkCopy.WriteToServer(table)
                connection.Close()
            End Using
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function MCreateTable(ByVal tableName As String, ByVal table As DataTable, ByVal connectionString As String) As Boolean
        Try
            Dim sql As String = "CREATE TABLE " & tableName & " (" & vbLf

            ' columns
            Dim i As Integer = 1
            For Each col As DataColumn In table.Columns
                sql += "[" & col.ColumnName & "] " & MGetTypeSql(col.DataType, col.MaxLength, 10, 2) & "," & vbLf
                i += 1
            Next
            sql = sql.TrimEnd(New Char() {","c, ControlChars.Lf}) & vbLf & ")"

            Commons.Modules.ObjSystems.XoaTable(tableName)
            SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql)
            Return True
        Catch
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Kiem ký tự đặc biệt cả khoảng trống cho phép dấu "-" và "_"
    ''' </summary>    
    Function MKiemKyTuDacBiet(sChuoi As String) As Boolean
        Try
            Dim result As Boolean = sChuoi.All(Function(c) Char.IsLetterOrDigit(c) OrElse c = "_"c OrElse c = "-"c)
            If Not result Then Return False Else Return True
        Catch ex As Exception
            Return True
        End Try

    End Function

    ''' <summary>
    ''' Kiem ký tự đặc biệt theo điều kiện
    ''' </summary> 
    Function MKiemKyTuDacBiet(sChuoi As String, bKhoangTrang As Boolean, bDauNoi As Boolean) As Boolean
        Try
            Dim result As Boolean
            If bKhoangTrang Then
                If bDauNoi Then
                    result = sChuoi.All(Function(c) Char.IsLetterOrDigit(c) OrElse c = "_"c OrElse c = "-"c OrElse c = " "c)
                Else
                    result = sChuoi.All(Function(c) Char.IsLetterOrDigit(c) OrElse c = " "c)
                End If
            Else
                If bDauNoi Then
                    result = sChuoi.All(Function(c) Char.IsLetterOrDigit(c) OrElse c = "_"c OrElse c = "-"c)
                Else
                    result = sChuoi.All(Function(c) Char.IsLetterOrDigit(c))
                End If
            End If

            If Not result Then Return False Else Return True
        Catch ex As Exception
            Return True
        End Try

    End Function
    Function MCreateTableToDatatable(ByVal objTrans As SqlTransaction, ByVal tableSQLName As String, ByVal table As DataTable, ByVal sTaoTable As String) As Boolean
        Try
            If sTaoTable = "" Then
                If Not MCreateTable(tableSQLName, table, objTrans) Then
                    Return False
                End If
            Else
                Commons.Modules.ObjSystems.XoaTable(tableSQLName)
                SqlHelper.ExecuteReader(objTrans, CommandType.Text, sTaoTable)
            End If

            Using connection As New System.Data.SqlClient.SqlConnection(objTrans.Connection.ToString)
                Dim bulkCopy As New System.Data.SqlClient.SqlBulkCopy(connection, System.Data.SqlClient.SqlBulkCopyOptions.TableLock Or System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers Or System.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction, Nothing)

                bulkCopy.DestinationTableName = tableSQLName
                connection.Open()

                bulkCopy.WriteToServer(table)
                connection.Close()
            End Using
        Catch
            Return False
        End Try
        Return True
    End Function

    Public Function MCreateTable(ByVal tableName As String, ByVal table As DataTable, ByVal objTrans As SqlTransaction) As Boolean
        Try
            Dim sql As String = "CREATE TABLE " & tableName & " (" & vbLf

            Dim i As Integer = 1
            For Each col As DataColumn In table.Columns
                sql += "[" & col.ColumnName & "] " & MGetTypeSql(col.DataType, col.MaxLength, 10, 2) & "," & vbLf
                i += 1
            Next
            sql = sql.TrimEnd(New Char() {","c, ControlChars.Lf}) & vbLf & ")"

            Commons.Modules.ObjSystems.XoaTable(tableName)
            SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql)
            Return True
        Catch
            Return False
        End Try

    End Function

    Public Function MGetTypeSql(ByVal type As Object, ByVal columnSize As Integer, ByVal numericPrecision As Integer, ByVal numericScale As Integer) As String
        Select Case type.ToString()
            Case "System.String"
                If (columnSize >= 2147483646) Then
                    Return "NVARCHAR(MAX)"
                Else
                    Return IIf(columnSize = -1, "NVARCHAR(MAX)", "NVARCHAR(" & columnSize.ToString() & ")")
                End If
            Case "System.Decimal"
                If numericScale > 0 Then
                    Return "REAL"
                ElseIf numericPrecision > 10 Then
                    Return "BIGINT"
                Else
                    Return "INT"
                End If
            Case "System.Boolean"
                Return "BIT"

            Case "System.Double"
                Return "FLOAT"

            Case "System.Single"
                Return "REAL"

            Case "System.Int64"
                Return "BIGINT"

            Case "System.Int16"
                Return "INT"

            Case "System.Int32"
                Return "INT"

            Case "System.DateTime"
                Return "DATETIME"
            Case "System.Byte[]"
                Return "IMAGE"
            Case "System.Drawing.Image"
                Return "IMAGE"
            Case Else
                Throw New Exception(type.ToString() & " not implemented.")
        End Select
    End Function

    Public Function KiemKyTu(ByVal strInput As String, ByVal strChuoi As String) As Boolean
        If strChuoi = "" Then
            strChuoi = "'"
        End If

        For i As Integer = 0 To strInput.Length - 1
            For j As Integer = 0 To strChuoi.Length - 1
                If strInput(i) = strChuoi(j) Then
                    Return True
                End If

            Next
        Next
        Return False
    End Function


#End Region

    Public Function MaHoaDL(ByVal str As String) As String
        Dim dLen As Double = str.Length
        Dim sTam As String = ""
        Const _CODE_ = 354

        MaHoaDL = ""
        For i As Integer = 1 To dLen
            sTam += ChrW((AscW(Mid(str, i, 1)) + _CODE_) * 2).ToString
        Next

        Return sTam
    End Function

    Public Function MaHoaDL(ByVal str As String, ByVal iCODE As Integer) As String
        Dim dLen As Double = str.Length
        Dim sTam As String = ""

        MaHoaDL = ""
        For i As Integer = 1 To dLen
            sTam += ChrW((AscW(Mid(str, i, 1)) + iCODE) * 2).ToString
        Next

        Return sTam
    End Function

    Public Function GiaiMaDL(ByVal str As String) As String
        Dim dLen As Double = str.Length
        Dim sTam As String = ""
        Const _CODE_ = 354

        GiaiMaDL = ""
        For i As Integer = 1 To dLen
            sTam += ChrW((AscW(Mid(str, i, 1)) / 2) - _CODE_).ToString
        Next

        Return sTam
    End Function

    Public Function GiaiMaDL(ByVal str As String, ByVal iCODE As Integer) As String
        Dim dLen As Double = str.Length
        Dim sTam As String = ""

        GiaiMaDL = ""
        For i As Integer = 1 To dLen
            sTam += ChrW((AscW(Mid(str, i, 1)) / 2) - iCODE).ToString
        Next

        Return sTam
    End Function

    Public Function MGhiFileTxt(ByVal strPath As String, ByVal strNoiDung As String) As Boolean
        Dim dLen As Double = strNoiDung.Length
        Dim sTam As String = ""
        Const _CODE_ = 354

        sTam = ""
        For i As Integer = 1 To dLen
            sTam += ChrW((AscW(Mid(strNoiDung, i, 1)) / 2) - _CODE_).ToString
        Next

        Return sTam
    End Function

    Public Sub MVisGrid(ByVal grd As DataGridView, ByVal sForm As String, ByVal sControl As String, ByVal UName As String)
        Try

            Dim dtTmp As New DataTable()
            Dim sDLieuForm As String = ""
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDsCotVis", sForm, sControl, UName))
            If dtTmp.Rows.Count <= 0 Then Return

            sDLieuForm = Convert.ToString(dtTmp.Rows(0)("COL_VIS").ToString())
            If sDLieuForm.ToUpper() = "ALL" Then Return


            Dim chuoi_tach As String() = sDLieuForm.Split(New [Char]() {"@"c})

            For Each s As String In chuoi_tach
                If s.ToString().Trim() <> "" Then
                    Try
                        grd.Columns(s).Visible = False
                    Catch ex As Exception

                    End Try
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Sub MVisGrid(ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sForm As String,
                    ByVal sControl As String, ByVal UName As String, ByVal MDev As Boolean)
        Try
            Dim dtTmp As New DataTable()
            Dim sDLieuForm As String = ""
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDsCotVis", sForm, sControl, UName))
            If dtTmp.Rows.Count <= 0 Then Return

            sDLieuForm = Convert.ToString(dtTmp.Rows(0)("COL_VIS").ToString())
            If sDLieuForm.ToUpper() = "ALL" Then Return


            Dim chuoi_tach As String() = sDLieuForm.Split(New [Char]() {"@"c})

            For Each s As String In chuoi_tach
                If s.ToString().Trim() <> "" Then
                    Try
                        grv.Columns(s).Visible = False
                    Catch ex As Exception

                    End Try
                End If
            Next
        Catch ex As Exception

        End Try




    End Sub

    Public Sub MChooseGrid(ByVal bChose As Boolean, ByVal sCot As String, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView)
        Try

            Dim i As Integer
            i = 0
            For i = 0 To grv.RowCount
                grv.SetRowCellValue(i, sCot, bChose)
                grv.UpdateCurrentRow()
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Function MGetLicUser(ByVal sUserName As String) As Integer
        Dim sTypeLic As String = 0
        Try
            sTypeLic = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        " SELECT ISNULL(B.TYPE_LIC,0) AS TYPE_LIC FROM dbo.USERS AS A INNER JOIN dbo.NHOM AS B ON A.GROUP_ID = B.GROUP_ID " &
                        " WHERE     (A.USERNAME = N'" & sUserName & "') "), Integer)
        Catch ex As Exception

        End Try
        Return sTypeLic
    End Function

    Public Function MGetQuyenChucNang(ByVal sUserName As String, ByVal iSTT As Integer) As Boolean
        Dim bQuyen As Boolean = False
        Try
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT STT FROM USER_CHUC_NANG WHERE USERNAME = '" + sUserName + "' AND STT = " & iSTT.ToString))
            If dtTmp.Rows.Count > 0 Then bQuyen = True
        Catch ex As Exception
            bQuyen = False
        End Try
        Return bQuyen

    End Function

    Public Function Licences(ByVal sUserName As String) As Integer
        Dim iLoaiLic, iLic As Integer
        iLoaiLic = 0
        iLic = 0
        iLoaiLic = Modules.ObjSystems.MGetLicUser(sUserName)
        If iLoaiLic = 1 Then iLic = Commons.Modules.LicensePro
        If iLoaiLic = 2 Then iLic = Commons.Modules.LicenseProduction
        If iLoaiLic = 3 Then iLic = Commons.Modules.LicenseWarehouse

        Return iLic
    End Function

    Public Sub MGiaiMaTable(ByVal sBTamLic As String, ByVal sTable As String, ByVal sCot As String, ByVal sTypeLic As String)
        Dim dtTmpLic As New DataTable
        Try
            sTypeLic = MaHoaDL(sTypeLic)

            dtTmpLic = New DataTable
            dtTmpLic.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT * FROM " + sTable + " WHERE TYPE_LIC = N'" + sTypeLic + "' "))

            For Each row As DataRow In dtTmpLic.Rows
                row("TYPE_LIC") = GiaiMaDL(row("TYPE_LIC").ToString())
                row(sCot) = GiaiMaDL(row(sCot).ToString())
            Next

            Commons.Modules.ObjSystems.XoaTable(sBTamLic)
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTamLic, dtTmpLic, "")
        Catch ex As Exception

        End Try

    End Sub

    Public Sub MGiaiMaTable(ByVal sBTamLic As String, ByVal sTable As String, ByVal sCot As String, ByVal sUserName As String, ByVal bUser As Boolean)
        Dim dtTmpLic As New DataTable

        Dim sTypeLic As String

        sTypeLic = MaHoaDL(MGetLicUser(sUserName))

        dtTmpLic = New DataTable
        dtTmpLic.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT * FROM " + sTable + " WHERE TYPE_LIC = N'" + sTypeLic + "' "))

        For Each row As DataRow In dtTmpLic.Rows
            row("TYPE_LIC") = GiaiMaDL(row("TYPE_LIC").ToString())
            row(sCot) = GiaiMaDL(row(sCot).ToString())
        Next

        Commons.Modules.ObjSystems.XoaTable(sBTamLic)
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTamLic, dtTmpLic, "")

    End Sub

    Public Function MCheckEmail(ByVal inputEmail As String) As Boolean
        If Microsoft.VisualBasic.Right(inputEmail, 1) = ";" Then
            inputEmail = inputEmail.Substring(0, Len(inputEmail) - 1)
        End If
        Dim ALL_EMAILS As [String]() = inputEmail.Split(";"c)
        Dim strRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" & "\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" & ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim re As New System.Text.RegularExpressions.Regex(strRegex)

        If ALL_EMAILS.Count > 1 Then
            For Each emailaddress As String In ALL_EMAILS
                emailaddress = If(emailaddress, String.Empty)
                If Not re.IsMatch(emailaddress.Trim()) Then
                    Return (False)
                End If
            Next
            Return True
        Else
            inputEmail = If(inputEmail, String.Empty)
            If re.IsMatch(inputEmail.Trim()) Then
                Return (True)
            Else
                Return (False)
            End If
        End If
    End Function

    Public Function MCheckEmail(ByVal inputEmail As String, ByRef sMailF As String) As Boolean
        If Microsoft.VisualBasic.Right(inputEmail, 1) = ";" Then
            inputEmail = inputEmail.Substring(0, Len(inputEmail) - 1)
        End If

        Dim ALL_EMAILS As [String]() = inputEmail.Split(";"c)
        Dim strRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" & "\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" & ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim re As New System.Text.RegularExpressions.Regex(strRegex)

        If ALL_EMAILS.Count > 1 Then
            For Each emailaddress As String In ALL_EMAILS
                emailaddress = If(emailaddress, String.Empty)
                If Not re.IsMatch(emailaddress.Trim()) Then
                    sMailF = emailaddress.Trim()
                    Return (False)
                End If
            Next
            sMailF = ""
            Return True
        Else
            inputEmail = If(inputEmail, String.Empty)
            If re.IsMatch(inputEmail.Trim()) Then
                sMailF = ""
                Return (True)
            Else
                sMailF = inputEmail.Trim()
                Return (False)
            End If
        End If
    End Function

    Public Sub MReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Function MLoadMailNX(ByVal MsNXuong As String, ByVal eMailThem As String, ByVal iLoaiMail As Integer) As String
        Dim sSql, sNXuong As String
        Try

            sSql = "SELECT DBO.MGetNXuongCha( N'" + MsNXuong + "')"
            sNXuong = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            Dim sMsNx As String() = sNXuong.Split(New [Char]() {";"c})
            sSql = ""
            sNXuong = ""
            For i As Integer = 0 To sMsNx.Length - 1
                sSql = sSql & IIf(sSql = "", "", " UNION ") & "SELECT EMAIL FROM dbo.NHA_XUONG_EMAIL WHERE (MS_LOAI_EMAIL = " & iLoaiMail.ToString & ") AND (MS_N_XUONG = N'" & sMsNx.GetValue(i).ToString() & "')"
            Next
            sSql = sSql & IIf(sSql = "", "", " UNION ") & " SELECT EMAIL FROM dbo.NHA_XUONG_EMAIL WHERE (MS_LOAI_EMAIL = " & iLoaiMail.ToString & ") AND (MS_N_XUONG = N'" & MsNXuong & "')"

            sSql = " DECLARE @listStr1 VARCHAR(1000) " &
                                    " SELECT @listStr1 = COALESCE(ISNULL( RTRIM(LTRIM(@listStr1)),'') ,'') +  " &
                                    " + CASE LEN(ISNULL(RTRIM(LTRIM(@listStr1)),'')) WHEN 0 THEN '' ELSE '; ' END + " &
                                    " ISNULL(EMAIL,'')  " &
                                    " FROM (" + sSql + ") A  " &
                                    " SELECT ISNULL(@listStr1,'') AS EMAIL "

            sNXuong = sNXuong & IIf(sNXuong = "", "", "; ") & Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

            If eMailThem <> "" Then
                sNXuong = sNXuong & IIf(sNXuong = "", "", "; ") & eMailThem
            End If
            sMsNx = sNXuong.Split(New [Char]() {";"c})

            sSql = ""
            For i As Integer = 0 To sMsNx.Length - 1
                sSql = sSql & IIf(sSql = "", "", " UNION ") & "SELECT N'" + sMsNx.GetValue(i).ToString() + "' AS MAIL "
            Next
            sSql = " DECLARE @listStr1 VARCHAR(1000) " &
                        " SELECT @listStr1 = COALESCE(ISNULL( RTRIM(LTRIM(@listStr1)),'') ,'') +  " &
                        " + CASE LEN(ISNULL(RTRIM(LTRIM(@listStr1)),'')) WHEN 0 THEN '' ELSE '; ' END + " &
                        " ISNULL(MAIL,'')  " &
                        " FROM (" + sSql + ") A  " &
                        " SELECT ISNULL(@listStr1,'') AS EMAIL "
            sNXuong = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        Catch ex As Exception
            Return ""
        End Try

        Return sNXuong

    End Function

    Public Function sDinhDangSoLe(ByVal iSoLe As Integer) As String
        Dim sChuoi As String = "#,##0"
        If iSoLe <> 0 Then
            sChuoi = sChuoi + "."
            For i As Integer = 0 To iSoLe - 1
                sChuoi = sChuoi + "0"
            Next
        End If
        sDinhDangSoLe = sChuoi
    End Function

    Public Function sDinhDangSoLe(ByVal iSoLe As Integer, ByVal sChuoi As String) As String
        If iSoLe <> 0 Then
            sChuoi = sChuoi + "."
            For i As Integer = 0 To iSoLe - 1
                sChuoi = sChuoi + "0"
            Next
        End If
        sDinhDangSoLe = sChuoi
    End Function

    Public Sub DesignerReport(ByVal rptMain As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Commons.clsXuLy.CreateTitleReport()
        For Each rptObjectMain As CrystalDecisions.CrystalReports.Engine.ReportObject In rptMain.ReportDefinition.ReportObjects
            If rptObjectMain.Name.Length >= 5 And rptObjectMain.Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
                If (rptObjectMain.Name.Trim().ToUpper().Substring(0, 5).Equals("TITLE")) Then
                    Dim rptDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    rptDocument = rptMain.Subreports("rptTitle.rpt")
                    Dim tbrptHeader As DataTable = New DataTable()
                    tbrptHeader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTHONG_TIN_CHUNG"))
                    If (tbrptHeader.Rows.Count > 0) Then
                        For Each rptObject As CrystalDecisions.CrystalReports.Engine.ReportObject In rptDocument.ReportDefinition.ReportObjects
                            If rptObject.Name.Length >= 4 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO")) Then
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH"))
                                    rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("HEIGHT"))
                                End If
                            End If
                            If rptObject.Name.Length >= 8 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE")) Then
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO")) + Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH")) + 200
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_CAO"))
                                    rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_RONG"))
                                End If
                            End If
                            If rptObject.Name.Length >= 6 Then
                                If (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) Then
                                    rptObject.Width = 2500
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                    Try
                                        rptObject.Left = rptObjectMain.Width - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                    Catch ex As Exception
                                    End Try
                                    rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                Dim tbrptHeader As DataTable = New DataTable()
                tbrptHeader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTHONG_TIN_CHUNG"))
                If (tbrptHeader.Rows.Count > 0) Then
                    For Each rptObject As CrystalDecisions.CrystalReports.Engine.ReportObject In rptMain.ReportDefinition.ReportObjects
                        If rptObject.Name.Length >= 4 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO")) Then
                                rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH"))
                                rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("HEIGHT"))
                            End If
                        End If
                        If rptObject.Name.Length >= 8 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE")) Then
                                rptObject.Left = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO")) + Convert.ToInt32(tbrptHeader.Rows(0)("WIDTH")) + 200
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                rptObject.Height = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_CAO"))
                                rptObject.Width = Convert.ToInt32(tbrptHeader.Rows(0)("TTC_RONG"))
                            End If
                        End If
                        If rptObject.Name.Length >= 6 Then
                            If (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) Then
                                rptObject.Width = 2500
                                rptObject.Top = Convert.ToInt32(tbrptHeader.Rows(0)("LE_TREN_LOGO"))
                                Try
                                    rptObject.Left = rptMain.PrintOptions.PageContentWidth - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows(0)("LE_TRAI_LOGO"))
                                Catch ex As Exception
                                End Try
                                rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Public Function GetNgayHeThong() As DateTime
        Dim sSql As String = " DECLARE @NGAYIN DATETIME SET @NGAYIN = GETDATE() SELECT @NGAYIN AS NGAY_HT"
        Dim dtTmp As New DataTable()
        Dim NgayIn As Date = System.DateTime.Now
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, sSql))
            If (dtTmp.Rows.Count > 0) Then
                NgayIn = Convert.ToDateTime(dtTmp.Rows(0)(0).ToString())
            Else
                NgayIn = System.DateTime.Now
            End If
        Catch ex As Exception
            NgayIn = System.DateTime.Now
        End Try
        Return NgayIn
    End Function

    Public Function GetMSNhanVienTheoUser(ByVal sUser As String) As String
        Dim sSql As String
        Try

            sSql = " SELECT MS_CONG_NHAN FROM USERS WHERE USERNAME = '" + sUser + "'"
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, sSql))
            If (dtTmp.Rows.Count > 0) Then
                sSql = dtTmp.Rows(0)(0).ToString()
            Else
                sSql = ""
            End If
        Catch ex As Exception
            sSql = ""
        End Try
        Return sSql
    End Function

    Public Function GetTenNhanVienTheoUser(ByVal sUser As String) As String
        Dim sSql As String
        Try
            sSql = " SELECT B.HO + ' ' + B.TEN AS HO_TEN FROM dbo.USERS AS A INNER JOIN dbo.CONG_NHAN AS B ON " &
                        " A.MS_CONG_NHAN = B.MS_CONG_NHAN WHERE USERNAME = '" + sUser + "'"
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, sSql))
            If (dtTmp.Rows.Count > 0) Then
                sSql = dtTmp.Rows(0)(0).ToString()
            Else
                sSql = ""
            End If
        Catch ex As Exception
            sSql = ""
        End Try
        Return sSql
    End Function

    Public Function GetMaSoPBTTheoDonVi(ByVal sUser As String) As String
        If Commons.Modules.iMaPBT = 0 Then Return "WO"

        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT     ISNULL(C.TEN_RUT_GON, N'') AS TEN_RUT_GON FROM dbo.USERS AS A " &
                " INNER JOIN dbo.TO_PHONG_BAN AS B ON A.MS_TO = B.MS_TO INNER JOIN dbo.DON_VI AS C ON B.MS_DON_VI = C.MS_DON_VI " &
                " WHERE USERNAME = '" + sUser + "'"))
        Catch ex As Exception
        End Try
        Try

            If dtTmp.Rows.Count = 0 Or dtTmp.Rows(0)("").ToString = "" Then
                dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT TEN_RUT_GON FROM DON_VI WHERE MAC_DINH = 1 AND ISNULL(TEN_RUT_GON,'') <> '' "))
                If dtTmp.Rows.Count > 0 Then GoTo 1 Else Return "WO"

            End If


1:
            Dim sTmp As String
            sTmp = dtTmp.Rows(0)("TEN_RUT_GON").ToString
            Dim r As New System.Text.RegularExpressions.Regex("(?:[^a-z0-9 ]|(?<=['""])s)", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.CultureInvariant Or System.Text.RegularExpressions.RegexOptions.Compiled)
            sTmp = r.Replace(sTmp, [String].Empty)
            Dim MyStringBuilder As New System.Text.StringBuilder(sTmp)
            MyStringBuilder.Replace(" ", "")
            Return MyStringBuilder.ToString

        Catch ex As Exception
            Return "WO"
        End Try
    End Function

    Public Sub mGetSoPhieu(ByVal sTable As String, ByVal sField As String, ByVal sFieldNgay As String,
                           ByVal sFieldLock As String, ByVal sMaSo As String, ByRef dNgay As DateTime, ByRef bLock As Integer)
        Dim sSql As String
        Dim dtTmp As New DataTable

        Try
            sSql = "SELECT " & sFieldNgay & " AS NGAY, " & sFieldLock & " AS LOCK FROM " & sTable & " WHERE " & sField & " = '" & sMaSo & "' "
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count > 0 Then
                dNgay = DateTime.Parse(dtTmp.Rows(0)("NGAY").ToString)
                bLock = Integer.Parse(dtTmp.Rows(0)("LOCK").ToString)
            End If
        Catch ex As Exception
            dNgay = dNgay
            bLock = bLock
        End Try

    End Sub

    Public Function CreateMsDieuDo() As String
        Dim sMS = "SCH"
        Dim MS_DIEU_DO As String = ""
        Dim temp As String = ""
        Dim param As String = Now.Year.ToString()
        If Now.Month < 10 Then
            param += "0" + Now.Month.ToString
        Else
            param += Now.Month.ToString
        End If
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getMaxMsDieuDo", param, sMS)
        While (dtReader.Read)
            temp = dtReader(0).ToString
        End While

        If temp.ToString.Length > 5 Then
            temp = sMS + "-" + temp.Replace(sMS + "-", "")

            Dim sTmp As String
            sTmp = temp.Replace(sMS + "-", "")
            Dim temp1 As String = sTmp.Substring(4, 2)
            Dim month = Integer.Parse(temp1)
            If month <> Now.Month Then
                MS_DIEU_DO = New_MsDieuDo()
            Else
                If temp.Length = 10 + sMS.Length Then
                    temp1 = "000" + temp.Substring(7 + sMS.Length, 3)
                Else
                    If temp.Length = 11 + sMS.Length Then
                        temp1 = temp.Substring(7 + sMS.Length, 4)
                    Else
                        temp1 = temp.Substring(7 + sMS.Length, 6)
                    End If

                End If
                MS_DIEU_DO = temp.Substring(0, 7 + sMS.Length)
                Dim SrNo As Integer = Integer.Parse(temp1) + 1
                For i As Integer = SrNo.ToString.Length() To 5
                    MS_DIEU_DO = MS_DIEU_DO & "0"
                Next
                MS_DIEU_DO = MS_DIEU_DO + SrNo.ToString
            End If
        Else
            MS_DIEU_DO = New_MsDieuDo()
        End If
        Return MS_DIEU_DO

    End Function

    Private Function New_MsDieuDo() As String
        Dim sMS = "SCH"
        Dim MS_DIEU_DO As String = sMS + "-"
        MS_DIEU_DO += Now.Year.ToString
        If Now.Month > 9 Then
            MS_DIEU_DO += Now.Month.ToString
        Else
            MS_DIEU_DO += "0" + Now.Month.ToString
        End If
        MS_DIEU_DO += "000001"
        Return MS_DIEU_DO
    End Function

    Public Function MChuyenFileHinhQuaByte(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function MChuyenTuByteSangFileHinh(ByVal ImageData As Byte(), ByVal FilePath As String) As Boolean
        If IsNothing(ImageData) = True Then
            Return False
        End If
        Try
            Dim fs As IO.FileStream = New IO.FileStream(FilePath, IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            Dim bw As IO.BinaryWriter = New IO.BinaryWriter(fs)
            bw.Write(ImageData)
            bw.Flush()
            bw.Close()
            fs.Close()
            bw = Nothing
            fs.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function MChuyeTuByteQuaMemoryStream(ByVal ImageData As Byte()) As IO.MemoryStream
        Try
            If IsNothing(ImageData) = True Then
                Return Nothing
            End If
            Return New System.IO.MemoryStream(ImageData)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function MChuyenFileHinhQuaMemoryStream(ByVal ImageFilePath As String) As IO.MemoryStream
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Return Nothing
        End If
        Return MChuyeTuByteQuaMemoryStream(MChuyenFileHinhQuaByte(ImageFilePath))
    End Function

    Private Function MKiemFaiSo(ByVal value As String) As String
        Dim result As String
        If value.Contains(",") Then : result = CDbl(value).ToString("###.##")
        Else : result = CDbl(value).ToString("###.00") : End If
        Return result
    End Function

    Private Function MDocSoBaoNhieuByte(ByVal ObjectSize As String) As String
        Dim oneByte As Integer = 1
        Dim kiloByte As Integer = 1024
        Dim megaByte As Integer = 1048576
        Dim gigaByte As Integer = 1073741824
        Dim terraByte As Long = 1099511627776
        Dim pettaByte As Long = 1125899906842624

        Select Case CLng(ObjectSize)
            Case 0 To kiloByte - 1
                If (CDbl(MKiemFaiSo(CStr(CDec(ObjectSize) / oneByte))) >= 1000) = False Then
                    ObjectSize = CStr(CInt(ObjectSize) / 1) + " Bytes"
                Else : ObjectSize = "1,00 KB" : End If

            Case kiloByte To megaByte - 1
                If (CDbl(MKiemFaiSo(CStr(CDec(ObjectSize) / kiloByte))) >= 1000) = False Then
                    ObjectSize = MKiemFaiSo(CStr(CDec(ObjectSize) / kiloByte)) + " KB"
                Else : ObjectSize = "1,00 MB" : End If

            Case megaByte To gigaByte - 1
                If (CDbl(MKiemFaiSo(CStr(CDec(ObjectSize) / megaByte))) >= 1000) = False Then
                    ObjectSize = MKiemFaiSo(CStr(CDec(ObjectSize) / megaByte)) + " MB"
                Else : ObjectSize = "1,00 GB" : End If

            Case gigaByte To terraByte - 1
                If (CDbl(MKiemFaiSo(CStr(CDec(ObjectSize) / gigaByte))) >= 1000) = False Then
                    ObjectSize = MKiemFaiSo(CStr(CDec(ObjectSize) / gigaByte)) + " GB"
                Else : ObjectSize = "1,00 TB" : End If

            Case terraByte To pettaByte - 1
                If (CDbl(MKiemFaiSo(CStr(CDec(ObjectSize) / terraByte))) >= 1000) = False Then
                    ObjectSize = MKiemFaiSo(CStr(CDec(ObjectSize) / terraByte)) + " TB"
                Else : ObjectSize = "1,00 PB" : End If
        End Select
        Return ObjectSize
    End Function

#Region "Load Data Chuan"
    Function MLoadDataTinh(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            Dim sSql As String
            If CoAll = 1 Then
                sSql = "SELECT MA_QG,TEN_QG FROM Y_Tinh UNION SELECT '-1',' < ALL > ' ORDER BY TEN_QG"
            Else
                sSql = "SELECT MA_QG,TEN_QG FROM Y_Tinh ORDER BY TEN_QG"
            End If
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sSql))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataQuan(ByVal CoAll As Integer, ByVal sTinh As String) As DataTable
        Dim dtTmp As New DataTable()
        Try
            Dim sSql As String
            If CoAll = 1 Then
                sSql = "SELECT  MA_QG,TEN_QG FROM Y_District WHERE  ( '" + sTinh + "' = '-1' )  OR ( MS_CHA = '" + sTinh + "'  ) UNION SELECT '-1',' < ALL > '  ORDER BY TEN_QG"
            Else
                sSql = "SELECT  MA_QG,TEN_QG FROM Y_District WHERE  ( '" + sTinh + "' = '-1' )  OR ( MS_CHA = '" + sTinh + "'  ) ORDER BY TEN_QG"
            End If
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sSql))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataDuong(ByVal CoAll As Integer, ByVal sTinh As String, ByVal sQuan As String) As DataTable
        Dim dtTmp As New DataTable()
        Try
            Dim sSql As String
            If CoAll = 1 Then
                sSql = "SELECT MS_DUONG, DUONG_TV FROM Y_Duong WHERE  (( '" + sTinh + "' = '-1' ) OR ( MS_Tinh = '" + sTinh + "'  ))  " &
                            " AND (( '" + sQuan + "' = '-1' ) OR ( MS_Quan = '" + sQuan + "'  ))  UNION SELECT '-1',' < ALL > '  ORDER BY DUONG_TV"
            Else
                sSql = "SELECT MS_DUONG, DUONG_TV FROM Y_Duong WHERE  (( '" + sTinh + "' = '-1' ) OR ( MS_Tinh = '" + sTinh + "'  ))  " &
                            " AND (( '" + sQuan + "' = '-1' ) OR ( MS_Quan = '" + sQuan + "'  ))  ORDER BY DUONG_TV"
            End If
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sSql))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function


    Function MLoadDataNhaXuong(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNhaXuongAll", Modules.UserName, Modules.TypeLanguage, CoAll))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataNhaXuong(ByVal CoAll As Integer, ByVal sTinh As String, ByVal sQuan As String, ByVal sDuong As String) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "MGetNhaXuong", Modules.UserName, sTinh, sQuan, sDuong))
            If CoAll <> 1 Then
                For Each rowTm As DataRow In dtTmp.Select("MS_N_XUONG = '-1'")
                    dtTmp.Rows.Remove(rowTm)
                    Exit For
                Next
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function
    Function MLoadDataNhaXuongTree(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNhaXuongTreeList", CoAll, Modules.UserName, Commons.Modules.TypeLanguage))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataDayChuyen(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetHeThongAll", CoAll, Modules.UserName, Modules.TypeLanguage))
        Catch ex As Exception
            Try
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetHeThongAll", CoAll, Modules.UserName))
            Catch
                Return Nothing
            End Try
        End Try
        Return dtTmp
    End Function


    Function MLoadDataDayChuyenTree(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetHeThongTreeListAll", CoAll, Modules.UserName, Commons.Modules.TypeLanguage))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataDCViTri(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetHeThongViTriAll", CoAll, Modules.UserName))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataLoaiMay(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLoaiMayAll", CoAll, Modules.UserName, Modules.TypeLanguage))
        Catch ex As Exception
            Try
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLoaiMayAll", CoAll, Modules.UserName))
            Catch
                Return Nothing
            End Try
        End Try

        Return dtTmp
    End Function

    Function MLoadDataNhomMay(ByVal CoAll As Integer, ByVal sLoaiMay As String) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNhomMayAll", CoAll, sLoaiMay, Modules.UserName, Modules.TypeLanguage))
        Catch ex As Exception
            Try
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNhomMayAll", CoAll, sLoaiMay, Modules.UserName))
            Catch
                Return Nothing
            End Try
        End Try
        Return dtTmp
    End Function

    Function MLoadDataBoPhanChiuPhi(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetBoPhanChiuPhiAll", CoAll, Modules.UserName, Modules.TypeLanguage))
        Catch ex As Exception
            Try
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetBoPhanChiuPhiAll", CoAll, Modules.UserName))
            Catch
                Return Nothing
            End Try
        End Try
        Return dtTmp
    End Function

    Function MLoadDataDonVi(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetDonViAll", CoAll))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataPhongBan(ByVal CoAll As Integer, ByVal sDonVi As String) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetPhongBanAll", CoAll, sDonVi))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataTo(ByVal CoAll As Integer, ByVal sDonVi As String, ByVal sPhongBan As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetToAll", CoAll, sDonVi, sPhongBan))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataLoaiVatTu(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLoaiVatTuAll", CoAll, Modules.TypeLanguage, Modules.UserName))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function

    Function MLoadDataKho(ByVal CoAll As Integer) As DataTable
        Dim dtTmp As New DataTable()
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetKhoPQ", Modules.UserName, CoAll))
        Catch ex As Exception
            Return Nothing
        End Try
        Return dtTmp
    End Function
#End Region

    Public Function MVni2Uni(ByVal mVnistr As String) As String
        MVni2Uni = ""
        Dim c As String, i As Integer
        Dim db As Boolean
        For i = 1 To Len(mVnistr)
            db = False
            If i < Len(mVnistr) Then
                c = Mid(mVnistr, i + 1, 1)
                If c = "ù" Or c = "ø" Or c = "û" Or c = "õ" Or c = "ï" Or
                c = "ê" Or c = "é" Or c = "è" Or c = "ú" Or c = "ü" Or c = "ë" Or
                c = "â" Or c = "á" Or c = "à" Or c = "å" Or c = "ã" Or c = "ä" Or
                c = "Ù" Or c = "Ø" Or c = "Û" Or c = "Õ" Or c = "Ï" Or
                c = "Ê" Or c = "É" Or c = "È" Or c = "Ú" Or c = "Ü" Or c = "Ë" Or
                c = "Â" Or c = "Á" Or c = "À" Or c = "Å" Or c = "Ã" Or c = "Ä" Then db = True
            End If
            If db Then
                c = Mid(mVnistr, i, 2)
                Select Case c
                    Case "aù" : c = ChrW(225)
                    Case "aø" : c = ChrW(224)
                    Case "aû" : c = ChrW(7843)
                    Case "aõ" : c = ChrW(227)
                    Case "aï" : c = ChrW(7841)
                    Case "aê" : c = ChrW(259)
                    Case "aé" : c = ChrW(7855)
                    Case "aè" : c = ChrW(7857)
                    Case "aú" : c = ChrW(7859)
                    Case "aü" : c = ChrW(7861)
                    Case "aë" : c = ChrW(7863)
                    Case "aâ" : c = ChrW(226)
                    Case "aá" : c = ChrW(7845)
                    Case "aà" : c = ChrW(7847)
                    Case "aå" : c = ChrW(7849)
                    Case "aã" : c = ChrW(7851)
                    Case "aä" : c = ChrW(7853)
                    Case "eù" : c = ChrW(233)
                    Case "eø" : c = ChrW(232)
                    Case "eû" : c = ChrW(7867)
                    Case "eõ" : c = ChrW(7869)
                    Case "eï" : c = ChrW(7865)
                    Case "eâ" : c = ChrW(234)
                    Case "eá" : c = ChrW(7871)
                    Case "eà" : c = ChrW(7873)
                    Case "eå" : c = ChrW(7875)
                    Case "eã" : c = ChrW(7877)
                    Case "eä" : c = ChrW(7879)
                    Case "où" : c = ChrW(243)
                    Case "oø" : c = ChrW(242)
                    Case "oû" : c = ChrW(7887)
                    Case "oõ" : c = ChrW(245)
                    Case "oï" : c = ChrW(7885)
                    Case "oâ" : c = ChrW(244)
                    Case "oá" : c = ChrW(7889)
                    Case "oà" : c = ChrW(7891)
                    Case "oå" : c = ChrW(7893)
                    Case "oã" : c = ChrW(7895)
                    Case "oä" : c = ChrW(7897)
                    Case "ôù" : c = ChrW(7899)
                    Case "ôø" : c = ChrW(7901)
                    Case "ôû" : c = ChrW(7903)
                    Case "ôõ" : c = ChrW(7905)
                    Case "ôï" : c = ChrW(7907)
                    Case "uù" : c = ChrW(250)
                    Case "uø" : c = ChrW(249)
                    Case "uû" : c = ChrW(7911)
                    Case "uõ" : c = ChrW(361)
                    Case "uï" : c = ChrW(7909)
                    Case "öù" : c = ChrW(7913)
                    Case "öø" : c = ChrW(7915)
                    Case "öû" : c = ChrW(7917)
                    Case "öõ" : c = ChrW(7919)
                    Case "öï" : c = ChrW(7921)
                    Case "yù" : c = ChrW(253)
                    Case "yø" : c = ChrW(7923)
                    Case "yû" : c = ChrW(7927)
                    Case "yõ" : c = ChrW(7929)
                    Case "AÙ" : c = ChrW(193)
                    Case "AØ" : c = ChrW(192)
                    Case "AÛ" : c = ChrW(7842)
                    Case "AÕ" : c = ChrW(195)
                    Case "AÏ" : c = ChrW(7840)
                    Case "AÊ" : c = ChrW(258)
                    Case "AÉ" : c = ChrW(7854)
                    Case "AÈ" : c = ChrW(7856)
                    Case "AÚ" : c = ChrW(7858)
                    Case "AÜ" : c = ChrW(7860)
                    Case "AË" : c = ChrW(7862)
                    Case "AÂ" : c = ChrW(194)
                    Case "AÁ" : c = ChrW(7844)
                    Case "AÀ" : c = ChrW(7846)
                    Case "AÅ" : c = ChrW(7848)
                    Case "AÃ" : c = ChrW(7850)
                    Case "AÄ" : c = ChrW(7852)
                    Case "EÙ" : c = ChrW(201)
                    Case "EØ" : c = ChrW(200)
                    Case "EÛ" : c = ChrW(7866)
                    Case "EÕ" : c = ChrW(7868)
                    Case "EÏ" : c = ChrW(7864)
                    Case "EÂ" : c = ChrW(202)
                    Case "EÁ" : c = ChrW(7870)
                    Case "EÀ" : c = ChrW(7872)
                    Case "EÅ" : c = ChrW(7874)
                    Case "EÃ" : c = ChrW(7876)
                    Case "EÄ" : c = ChrW(7878)
                    Case "OÙ" : c = ChrW(211)
                    Case "OØ" : c = ChrW(210)
                    Case "OÛ" : c = ChrW(7886)
                    Case "OÕ" : c = ChrW(213)
                    Case "OÏ" : c = ChrW(7884)
                    Case "OÂ" : c = ChrW(212)
                    Case "OÁ" : c = ChrW(7888)
                    Case "OÀ" : c = ChrW(7890)
                    Case "OÅ" : c = ChrW(7892)
                    Case "OÃ" : c = ChrW(7894)
                    Case "OÄ" : c = ChrW(7896)
                    Case "ÔÙ" : c = ChrW(7898)
                    Case "ÔØ" : c = ChrW(7900)
                    Case "ÔÛ" : c = ChrW(7902)
                    Case "ÔÕ" : c = ChrW(7904)
                    Case "ÔÏ" : c = ChrW(7906)
                    Case "UÙ" : c = ChrW(218)
                    Case "UØ" : c = ChrW(217)
                    Case "UÛ" : c = ChrW(7910)
                    Case "UÕ" : c = ChrW(360)
                    Case "UÏ" : c = ChrW(7908)
                    Case "ÖÙ" : c = ChrW(7912)
                    Case "ÖØ" : c = ChrW(7914)
                    Case "ÖÛ" : c = ChrW(7916)
                    Case "ÖÕ" : c = ChrW(7918)
                    Case "ÖÏ" : c = ChrW(7920)
                    Case "YÙ" : c = ChrW(221)
                    Case "YØ" : c = ChrW(7922)
                    Case "YÛ" : c = ChrW(7926)
                    Case "YÕ" : c = ChrW(7928)
                End Select
            Else
                c = Mid(mVnistr, i, 1)
                Select Case c
                    Case "ô" : c = ChrW(417)
                    Case "í" : c = ChrW(237)
                    Case "ì" : c = ChrW(236)
                    Case "æ" : c = ChrW(7881)
                    Case "ó" : c = ChrW(297)
                    Case "ò" : c = ChrW(7883)
                    Case "ö" : c = ChrW(432)
                    Case "î" : c = ChrW(7925)
                    Case "ñ" : c = ChrW(273)
                    Case "Ô" : c = ChrW(416)
                    Case "Í" : c = ChrW(205)
                    Case "Ì" : c = ChrW(204)
                    Case "Æ" : c = ChrW(7880)
                    Case "Ó" : c = ChrW(296)
                    Case "Ò" : c = ChrW(7882)
                    Case "Ö" : c = ChrW(431)
                    Case "Î" : c = ChrW(7924)
                    Case "Ñ" : c = ChrW(272)
                End Select
            End If
            MVni2Uni = MVni2Uni + c
            If db Then i = i + 1
        Next i
    End Function

    Public Function MUni2Vni(ByVal mUnistr As String) As String
        MUni2Vni = ""
        Dim c As String, i As Integer
        For i = 1 To Len(mUnistr)
            c = Mid(mUnistr, i, 1)
            Select Case c
                Case ChrW(97) : c = "a"
                Case ChrW(225) : c = "aù"
                Case ChrW(224) : c = "aø"
                Case ChrW(7843) : c = "aû"
                Case ChrW(227) : c = "aõ"
                Case ChrW(7841) : c = "aï"
                Case ChrW(259) : c = "aê"
                Case ChrW(7855) : c = "aé"
                Case ChrW(7857) : c = "aè"
                Case ChrW(7859) : c = "aú"
                Case ChrW(7861) : c = "aü"
                Case ChrW(7863) : c = "aë"
                Case ChrW(226) : c = "aâ"
                Case ChrW(7845) : c = "aá"
                Case ChrW(7847) : c = "aà"
                Case ChrW(7849) : c = "aå"
                Case ChrW(7851) : c = "aã"
                Case ChrW(7853) : c = "aä"
                Case ChrW(101) : c = "e"
                Case ChrW(233) : c = "eù"
                Case ChrW(232) : c = "eø"
                Case ChrW(7867) : c = "eû"
                Case ChrW(7869) : c = "eõ"
                Case ChrW(7865) : c = "eï"
                Case ChrW(234) : c = "eâ"
                Case ChrW(7871) : c = "eá"
                Case ChrW(7873) : c = "eà"
                Case ChrW(7875) : c = "eå"
                Case ChrW(7877) : c = "eã"
                Case ChrW(7879) : c = "eä"
                Case ChrW(111) : c = "o"
                Case ChrW(243) : c = "où"
                Case ChrW(242) : c = "oø"
                Case ChrW(7887) : c = "oû"
                Case ChrW(245) : c = "oõ"
                Case ChrW(7885) : c = "oï"
                Case ChrW(244) : c = "oâ"
                Case ChrW(7889) : c = "oá"
                Case ChrW(7891) : c = "oà"
                Case ChrW(7893) : c = "oå"
                Case ChrW(7895) : c = "oã"
                Case ChrW(7897) : c = "oä"
                Case ChrW(417) : c = "ô"
                Case ChrW(7899) : c = "ôù"
                Case ChrW(7901) : c = "ôø"
                Case ChrW(7903) : c = "ôû"
                Case ChrW(7905) : c = "ôõ"
                Case ChrW(7907) : c = "ôï"
                Case ChrW(105) : c = "i"
                Case ChrW(237) : c = "í"
                Case ChrW(236) : c = "ì"
                Case ChrW(7881) : c = "æ"
                Case ChrW(297) : c = "ó"
                Case ChrW(7883) : c = "ò"
                Case ChrW(117) : c = "u"
                Case ChrW(250) : c = "uù"
                Case ChrW(249) : c = "uø"
                Case ChrW(7911) : c = "uû"
                Case ChrW(361) : c = "uõ"
                Case ChrW(7909) : c = "uï"
                Case ChrW(432) : c = "ö"
                Case ChrW(7913) : c = "öù"
                Case ChrW(7915) : c = "öø"
                Case ChrW(7917) : c = "öû"
                Case ChrW(7919) : c = "öõ"
                Case ChrW(7921) : c = "öï"
                Case ChrW(121) : c = "y"
                Case ChrW(253) : c = "yù"
                Case ChrW(7923) : c = "yø"
                Case ChrW(7927) : c = "yû"
                Case ChrW(7929) : c = "yõ"
                Case ChrW(7925) : c = "î"
                Case ChrW(273) : c = "ñ"
                Case ChrW(65) : c = "A"
                Case ChrW(193) : c = "AÙ"
                Case ChrW(192) : c = "AØ"
                Case ChrW(7842) : c = "AÛ"
                Case ChrW(195) : c = "AÕ"
                Case ChrW(7840) : c = "AÏ"
                Case ChrW(258) : c = "AÊ"
                Case ChrW(7854) : c = "AÉ"
                Case ChrW(7856) : c = "AÈ"
                Case ChrW(7858) : c = "AÚ"
                Case ChrW(7860) : c = "AÜ"
                Case ChrW(7862) : c = "AË"
                Case ChrW(194) : c = "AÂ"
                Case ChrW(7844) : c = "AÁ"
                Case ChrW(7846) : c = "AÀ"
                Case ChrW(7848) : c = "AÅ"
                Case ChrW(7850) : c = "AÃ"
                Case ChrW(7852) : c = "AÄ"
                Case ChrW(69) : c = "E"
                Case ChrW(201) : c = "EÙ"
                Case ChrW(200) : c = "EØ"
                Case ChrW(7866) : c = "EÛ"
                Case ChrW(7868) : c = "EÕ"
                Case ChrW(7864) : c = "EÏ"
                Case ChrW(202) : c = "EÂ"
                Case ChrW(7870) : c = "EÁ"
                Case ChrW(7872) : c = "EÀ"
                Case ChrW(7874) : c = "EÅ"
                Case ChrW(7876) : c = "EÃ"
                Case ChrW(7878) : c = "EÄ"
                Case ChrW(79) : c = "O"
                Case ChrW(211) : c = "OÙ"
                Case ChrW(210) : c = "OØ"
                Case ChrW(7886) : c = "OÛ"
                Case ChrW(213) : c = "OÕ"
                Case ChrW(7884) : c = "OÏ"
                Case ChrW(212) : c = "OÂ"
                Case ChrW(7888) : c = "OÁ"
                Case ChrW(7890) : c = "OÀ"
                Case ChrW(7892) : c = "OÅ"
                Case ChrW(7894) : c = "OÃ"
                Case ChrW(7896) : c = "OÄ"
                Case ChrW(416) : c = "Ô"
                Case ChrW(7898) : c = "ÔÙ"
                Case ChrW(7900) : c = "ÔØ"
                Case ChrW(7902) : c = "ÔÛ"
                Case ChrW(7904) : c = "ÔÕ"
                Case ChrW(7906) : c = "ÔÏ"
                Case ChrW(73) : c = "I"
                Case ChrW(205) : c = "Í"
                Case ChrW(204) : c = "Ì"
                Case ChrW(7880) : c = "Æ"
                Case ChrW(296) : c = "Ó"
                Case ChrW(7882) : c = "Ò"
                Case ChrW(85) : c = "U"
                Case ChrW(218) : c = "UÙ"
                Case ChrW(217) : c = "UØ"
                Case ChrW(7910) : c = "UÛ"
                Case ChrW(360) : c = "UÕ"
                Case ChrW(7908) : c = "UÏ"
                Case ChrW(431) : c = "Ö"
                Case ChrW(7912) : c = "ÖÙ"
                Case ChrW(7914) : c = "ÖØ"
                Case ChrW(7916) : c = "ÖÛ"
                Case ChrW(7918) : c = "ÖÕ"
                Case ChrW(7920) : c = "ÖÏ"
                Case ChrW(89) : c = "Y"
                Case ChrW(221) : c = "YÙ"
                Case ChrW(7922) : c = "YØ"
                Case ChrW(7926) : c = "YÛ"
                Case ChrW(7928) : c = "YÕ"
                Case ChrW(7924) : c = "Î"
                Case ChrW(272) : c = "Ñ"
            End Select
            MUni2Vni = MUni2Vni + c
        Next i
    End Function

    Public Function MVni2TCVN3(ByVal mVnistr As String)
        MVni2TCVN3 = ""
        Dim c As String, i As Integer
        Dim db As Boolean
        For i = 1 To Len(mVnistr)
            db = False
            If i < Len(mVnistr) Then
                c = Mid(mVnistr, i + 1, 1)
                If c = "ù" Or c = "ø" Or c = "û" Or c = "õ" Or c = "ï" Or
                c = "ê" Or c = "é" Or c = "è" Or c = "ú" Or c = "ü" Or c = "ë" Or
                c = "â" Or c = "á" Or c = "à" Or c = "å" Or c = "ã" Or c = "ä" Or
                c = "Ù" Or c = "Ø" Or c = "Û" Or c = "Õ" Or c = "Ï" Or
                c = "Ê" Or c = "É" Or c = "È" Or c = "Ú" Or c = "Ü" Or c = "Ë" Or
                c = "Â" Or c = "Á" Or c = "À" Or c = "Å" Or c = "Ã" Or c = "Ä" Then db = True
            End If
            If db Then
                c = Mid(mVnistr, i, 2)
                Select Case c
                    Case "aù" : c = "¸"
                    Case "aø" : c = "µ"
                    Case "aû" : c = "¶"
                    Case "aõ" : c = "·"
                    Case "aï" : c = "¹"
                    Case "aê" : c = "¨"
                    Case "aé" : c = "¾"
                    Case "aè" : c = "»"
                    Case "aú" : c = "¼"
                    Case "aü" : c = "½"
                    Case "aë" : c = "Æ"
                    Case "aâ" : c = "©"
                    Case "aá" : c = "Ê"
                    Case "aà" : c = "Ç"
                    Case "aå" : c = "È"
                    Case "aã" : c = "É"
                    Case "aä" : c = "Ë"
                    Case "eù" : c = "Ð"
                    Case "eø" : c = "Ì"
                    Case "eû" : c = "Î"
                    Case "eõ" : c = "Ï"
                    Case "eï" : c = "Ñ"
                    Case "eâ" : c = "ª"
                    Case "eá" : c = "Õ"
                    Case "eà" : c = "Ò"
                    Case "eå" : c = "Ó"
                    Case "eã" : c = "Ô"
                    Case "eä" : c = "Ö"
                    Case "où" : c = "ã"
                    Case "oø" : c = "ß"
                    Case "oû" : c = "á"
                    Case "oõ" : c = "â"
                    Case "oï" : c = "ä"
                    Case "oâ" : c = "«"
                    Case "oá" : c = "è"
                    Case "oà" : c = "å"
                    Case "oå" : c = "æ"
                    Case "oã" : c = "ç"
                    Case "oä" : c = "é"
                    Case "ôù" : c = "í"
                    Case "ôø" : c = "ê"
                    Case "ôû" : c = "ë"
                    Case "ôõ" : c = "ì"
                    Case "ôï" : c = "î"
                    Case "uù" : c = "ó"
                    Case "uø" : c = "ï"
                    Case "uû" : c = "ñ"
                    Case "uõ" : c = "ò"
                    Case "uï" : c = "ô"
                    Case "öù" : c = "ø"
                    Case "öø" : c = "õ"
                    Case "öû" : c = "ö"
                    Case "öõ" : c = "÷"
                    Case "öï" : c = "ù"
                    Case "yù" : c = "ý"
                    Case "yø" : c = "ú"
                    Case "yû" : c = "û"
                    Case "yõ" : c = "ü"
                    Case "AÙ" : c = "¸"
                    Case "AØ" : c = "µ"
                    Case "AÛ" : c = "¶"
                    Case "AÕ" : c = "·"
                    Case "AÏ" : c = "¹"
                    Case "AÉ" : c = "¾"
                    Case "AÈ" : c = "»"
                    Case "AÚ" : c = "¼"
                    Case "AÜ" : c = "½"
                    Case "AË" : c = "Æ"
                    Case "AÁ" : c = "Ê"
                    Case "AÀ" : c = "Ç"
                    Case "AÅ" : c = "È"
                    Case "AÃ" : c = "É"
                    Case "AÄ" : c = "Ë"
                    Case "EÙ" : c = "Ð"
                    Case "EØ" : c = "Ì"
                    Case "EÛ" : c = "Î"
                    Case "EÕ" : c = "Ï"
                    Case "EÏ" : c = "Ñ"
                    Case "EÁ" : c = "Õ"
                    Case "EÀ" : c = "Ò"
                    Case "EÅ" : c = "Ó"
                    Case "EÃ" : c = "Ô"
                    Case "EÄ" : c = "Ö"
                    Case "OÙ" : c = "ã"
                    Case "OØ" : c = "ß"
                    Case "OÛ" : c = "á"
                    Case "OÕ" : c = "â"
                    Case "OÏ" : c = "ä"
                    Case "OÁ" : c = "è"
                    Case "OÀ" : c = "å"
                    Case "OÅ" : c = "æ"
                    Case "OÃ" : c = "ç"
                    Case "OÄ" : c = "é"
                    Case "ÔÙ" : c = "í"
                    Case "ÔØ" : c = "ê"
                    Case "ÔÛ" : c = "ë"
                    Case "ÔÕ" : c = "ì"
                    Case "ÔÏ" : c = "î"
                    Case "UÙ" : c = "ó"
                    Case "UØ" : c = "ï"
                    Case "UÛ" : c = "ñ"
                    Case "UÕ" : c = "ò"
                    Case "UÏ" : c = "ô"
                    Case "ÖÙ" : c = "ø"
                    Case "ÖØ" : c = "õ"
                    Case "ÖÛ" : c = "ö"
                    Case "ÖÕ" : c = "÷"
                    Case "ÖÏ" : c = "ù"
                    Case "YÙ" : c = "ý"
                    Case "YØ" : c = "ú"
                    Case "YÛ" : c = "û"
                    Case "YÕ" : c = "ü"
                    Case "AÊ" : c = "¡"
                    Case "AÂ" : c = "¢"
                    Case "EÂ" : c = "£"
                    Case "OÂ" : c = "¤"
                End Select
            Else
                c = Mid(mVnistr, i, 1)
                Select Case c
                    Case "ô" : c = "¬"
                    Case "i" : c = "i"
                    Case "í" : c = "Ý"
                    Case "ì" : c = "×"
                    Case "æ" : c = "Ø"
                    Case "ó" : c = "Ü"
                    Case "ò" : c = "Þ"
                    Case "ö" : c = "­"
                    Case "î" : c = "þ"
                    Case "ñ" : c = "®"
                    Case "A" : c = "A"
                    Case "Ô" : c = "¥"
                    Case "I" : c = "I"
                    Case "Í" : c = "Æ"
                    Case "Ý" : c = "Ø"
                    Case "U" : c = "U"
                    Case "Ö" : c = "¦"
                    Case "Y" : c = "Y"
                    Case "Ñ" : c = "§"
                End Select
            End If
            MVni2TCVN3 = MVni2TCVN3 + c
            If db Then i = i + 1
        Next i
    End Function


    Public Function MBoMailUser(ByVal sMail As String) As String


        Dim sTmp As String
        Try
            If sMail <> "" Then
                If Microsoft.VisualBasic.Right(sMail, 1) = ";" Then
                    sMail = sMail.Substring(0, Len(sMail) - 1)
                End If
            End If

            If sMail = "" Then
                sTmp = ""
            Else
                sMail = MBoMailTrung(sMail)
                sTmp = sMail.Trim()
                sTmp = sTmp.Replace(" ", String.Empty)
                sTmp = sTmp.Replace("  ", String.Empty)
                sTmp = sTmp.Replace("   ", String.Empty)
                sTmp = sTmp.Replace("    ", String.Empty)
                If Commons.Modules.sPrivate = "REMINGTON" Then Return sTmp
                If Commons.Modules.sMailUser.Trim <> "" Then
                    sTmp = sTmp.Replace(Commons.Modules.sMailUser + ";", String.Empty)
                    sTmp = sTmp.Replace(";" + Commons.Modules.sMailUser, String.Empty)
                End If
            End If
        Catch ex As Exception
            sTmp = sMail
        End Try
        Return sTmp
    End Function

    Public Function MBoMailUser(ByVal sMail As String, ByVal sUserMail As String) As String
        Dim sTmp As String
        Try
            If sMail = "" Then
                sTmp = ""
            Else
                sMail = MBoMailTrung(sMail)
                sTmp = sMail.Trim()
                sTmp = sTmp.Replace(" ", String.Empty)
                sTmp = sTmp.Replace("  ", String.Empty)
                sTmp = sTmp.Replace("   ", String.Empty)
                sTmp = sTmp.Replace("    ", String.Empty)
                If sUserMail.Trim <> "" Then
                    sTmp = sTmp.Replace(sUserMail + ";", String.Empty)
                    sTmp = sTmp.Replace(";" + sUserMail, String.Empty)
                End If
            End If
        Catch ex As Exception
            sTmp = sMail
        End Try
        Return sTmp
    End Function

    Public Function MBoMailTrung(ByVal input As String) As String
        If input.Trim = "" Then Return input
        If Microsoft.VisualBasic.Right(input, 1) = ";" Then
            input = input.Substring(0, Len(input) - 1)
        End If

        Dim sChuoi As String = ""
        Dim sMail As String() = input.Split(New [Char]() {";"c})
        Dim sList As List(Of [String]) = New List(Of String)()
        For Each s As String In sMail
            s = s.Trim
            If Not sList.Contains(s.Trim) Then
                sList.Add(s.Trim)
                sChuoi = (If(sChuoi = "", s.Trim(), (sChuoi & Convert.ToString(";")) + s.Trim()))
            End If
        Next
        Return sChuoi
    End Function



    Public Shared Function VSGetID(ByVal Hkey As String) As String
        Try
            Dim ID As String
            Dim Hdate As DateTime = DateTime.ParseExact("01/" & DateTime.Now.ToString("MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            ID = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_get_id", Hkey, Hdate), String)
            Return ID
        Catch
            Return ""
        End Try
    End Function
    Public Shared Function VSGetID(ByVal Hkey As String, ByVal Hdate As DateTime) As String
        Try

            Dim ID As String
            Hdate = DateTime.ParseExact("01/" & Hdate.ToString("MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            ID = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_get_id", Hkey, Hdate), String)
            Return ID
        Catch
            Return ""
        End Try
    End Function

    Public Sub MDoiFontCrystalReports(ByVal rptMain As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim sFont As String = ""
        sFont = Modules.sFontReport
        For Each sec As CrystalDecisions.CrystalReports.Engine.Section In rptMain.ReportDefinition.Sections
            Dim section As CrystalDecisions.CrystalReports.Engine.Section
            section = rptMain.ReportDefinition.Sections.Item(sec.Name)
            For i As Integer = 0 To section.ReportObjects.Count - 1
                Dim fieldObject As CrystalDecisions.CrystalReports.Engine.FieldObject
                Dim textObject As CrystalDecisions.CrystalReports.Engine.TextObject
                'Dim ChartObject As CrystalDecisions.CrystalReports.Engine.ChartObject

                Dim ifont As Single
                Dim sStyle As System.Drawing.FontStyle
                Try
                    If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.ChartObject Then
                        'CrystalDecisions.ReportAppServer.ReportDefModel.ChartObject oldChart;
                        'CrystalDecisions.ReportAppServer.ReportDefModel.ChartObject newChart;
                        'oldChart = (CrystalDecisions.ReportAppServer.ReportDefModel.ChartObject)oldObject;
                        'newChart = (CrystalDecisions.ReportAppServer.ReportDefModel.ChartObject)oldChart.Clone(true);

                        'newChart.ChartStyle.TextOptions.Title = "My new Title";
                        'newChart.ChartStyle.TextOptions.DataTitle = "My new data Title";
                        'newChart.ChartStyle.TextOptions.SeriesTitle = "My new series Title";

                        'rptClientDoc.ReportDefController.ModifyChartObject(oldChart, newChart);

                        'Dim oldChart As CrystalDecisions.CrystalReports.Engine.ChartObject
                        'Dim newChart As CrystalDecisions.CrystalReports.Engine.ChartObject
                        'oldChart = CType(section.ReportObjects(i), CrystalDecisions.CrystalReports.Engine.ChartObject)
                        'newChart = CType(section.ReportObjects(i), CrystalDecisions.CrystalReports.Engine.ChartObject)
                        'newChart.ObjectFormat.

                    Else
                        If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.FieldObject Then
                            fieldObject = section.ReportObjects(i)
                            'fieldObject.Color = Color.Red
                            ifont = CType(fieldObject.Font.Size, Single)
                            sStyle = fieldObject.Font.Style
                            fieldObject.ApplyFont(New Font(sFont, ifont, sStyle))
                        Else
                            If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.TextObject Then
                                textObject = section.ReportObjects(i)
                                'textObject.Color = Color.Red
                                ifont = CType(textObject.Font.Size, Single)
                                sStyle = textObject.Font.Style
                                textObject.ApplyFont(New Font(sFont, ifont, sStyle))
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Try
                    Catch ex1 As Exception
                    End Try
                End Try
            Next
        Next

        For j As Integer = 0 To rptMain.Subreports.Count - 1
            Try

                Dim rptSub As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                rptSub = rptMain.Subreports(j)

                For Each sec As CrystalDecisions.CrystalReports.Engine.Section In rptSub.ReportDefinition.Sections
                    Dim section As CrystalDecisions.CrystalReports.Engine.Section
                    section = rptSub.ReportDefinition.Sections.Item(sec.Name)
                    For i As Integer = 0 To section.ReportObjects.Count + 1
                        Dim fieldObject As CrystalDecisions.CrystalReports.Engine.FieldObject
                        Dim textObject As CrystalDecisions.CrystalReports.Engine.TextObject
                        Dim ifont As Single
                        Dim sStyle As System.Drawing.FontStyle
                        Try
                            If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.FieldObject Then
                                fieldObject = section.ReportObjects(i)
                                'fieldObject.Color = Color.Red
                                ifont = CType(fieldObject.Font.Size, Single)
                                sStyle = fieldObject.Font.Style

                                fieldObject.ApplyFont(New Font(sFont, ifont, sStyle))
                            Else
                                If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.TextObject Then
                                    textObject = section.ReportObjects(i)
                                    'textObject.Color = Color.Red
                                    ifont = CType(textObject.Font.Size, Single)
                                    sStyle = textObject.Font.Style
                                    textObject.ApplyFont(New Font(sFont, ifont, sStyle))
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                Next
            Catch ex4 As Exception

            End Try

        Next
    End Sub


    Public Sub MDoiFontCrystalReports(ByVal rptMain As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal sFont As String)
        If sFont = "" Then sFont = Modules.sFontReport

        For Each sec As CrystalDecisions.CrystalReports.Engine.Section In rptMain.ReportDefinition.Sections
            Dim section As CrystalDecisions.CrystalReports.Engine.Section
            section = rptMain.ReportDefinition.Sections.Item(sec.Name)
            For i As Integer = 0 To section.ReportObjects.Count + 1
                Dim fieldObject As CrystalDecisions.CrystalReports.Engine.FieldObject
                Dim textObject As CrystalDecisions.CrystalReports.Engine.TextObject
                Dim ifont As Single
                Dim sStyle As System.Drawing.FontStyle
                Try
                    If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.FieldObject Then
                        fieldObject = section.ReportObjects(i)
                        'fieldObject.Color = Color.Red
                        ifont = CType(fieldObject.Font.Size, Single)
                        sStyle = fieldObject.Font.Style
                        fieldObject.ApplyFont(New Font(sFont, ifont, sStyle))
                    Else
                        If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.TextObject Then
                            textObject = section.ReportObjects(i)
                            'textObject.Color = Color.Red
                            ifont = CType(textObject.Font.Size, Single)
                            sStyle = textObject.Font.Style
                            textObject.ApplyFont(New Font(sFont, ifont, sStyle))
                        End If
                    End If
                Catch ex As Exception
                    Try
                    Catch ex1 As Exception
                    End Try
                End Try
            Next
        Next

        For j As Integer = 0 To rptMain.Subreports.Count + 1
            Try

                Dim rptSub As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                rptSub = rptMain.Subreports(j)

                For Each sec As CrystalDecisions.CrystalReports.Engine.Section In rptSub.ReportDefinition.Sections
                    Dim section As CrystalDecisions.CrystalReports.Engine.Section
                    section = rptSub.ReportDefinition.Sections.Item(sec.Name)
                    For i As Integer = 0 To section.ReportObjects.Count + 1
                        Dim fieldObject As CrystalDecisions.CrystalReports.Engine.FieldObject
                        Dim textObject As CrystalDecisions.CrystalReports.Engine.TextObject
                        Dim ifont As Single
                        Dim sStyle As System.Drawing.FontStyle
                        Try
                            If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.FieldObject Then
                                fieldObject = section.ReportObjects(i)
                                'fieldObject.Color = Color.Red
                                ifont = CType(fieldObject.Font.Size, Single)
                                sStyle = fieldObject.Font.Style
                                fieldObject.ApplyFont(New Font(sFont, ifont, sStyle))
                            Else
                                If section.ReportObjects(i).Kind = CrystalDecisions.Shared.ReportObjectKind.TextObject Then
                                    textObject = section.ReportObjects(i)
                                    'textObject.Color = Color.Red
                                    ifont = CType(textObject.Font.Size, Single)
                                    sStyle = textObject.Font.Style
                                    textObject.ApplyFont(New Font(sFont, ifont, sStyle))
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                Next
            Catch ex4 As Exception

            End Try

        Next
    End Sub

    Public Sub MRemoveRow(ByVal panel As TableLayoutPanel, ByVal row_index_to_remove As Integer)
        If row_index_to_remove >= panel.RowCount Then
            Return
        End If

        ' delete all controls of row that we want to delete
        For i As Integer = 0 To panel.ColumnCount - 1
            Dim control = panel.GetControlFromPosition(i, row_index_to_remove)
            panel.Controls.Remove(control)
        Next

        ' move up row controls that comes after row we want to remove
        For i As Integer = row_index_to_remove + 1 To panel.RowCount - 1
            For j As Integer = 0 To panel.ColumnCount - 1
                Dim control = panel.GetControlFromPosition(j, i)
                If control IsNot Nothing Then
                    panel.SetRow(control, i - 1)
                End If
            Next
        Next

        ' remove last row
        panel.RowStyles.RemoveAt(panel.RowCount - 1)
        panel.RowCount -= 1
    End Sub

    Public Function MEncryptMD5(ByVal sEncrypt As String, ByVal sKey As String) As String
        Try
            Dim keyArr As Byte()
            Dim EnCryptArr As Byte() = UTF8Encoding.UTF8.GetBytes(sEncrypt)
            Dim MD5Hash As New Security.Cryptography.MD5CryptoServiceProvider()
            keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey))
            Dim tripDes As New Security.Cryptography.TripleDESCryptoServiceProvider()
            tripDes.Key = keyArr
            tripDes.Mode = Security.Cryptography.CipherMode.ECB
            tripDes.Padding = Security.Cryptography.PaddingMode.PKCS7
            Dim transform As Security.Cryptography.ICryptoTransform = tripDes.CreateEncryptor()
            Dim arrResult As Byte() = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length)
            Return Convert.ToBase64String(arrResult, 0, arrResult.Length)
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function MDecryptMD5(ByVal sDecrypt As String, ByVal sKey As String) As String
        Try
            Dim keyArr As Byte()
            Dim DeCryptArr As Byte() = Convert.FromBase64String(sDecrypt)
            Dim MD5Hash As New Security.Cryptography.MD5CryptoServiceProvider()
            keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey))
            Dim tripDes As New Security.Cryptography.TripleDESCryptoServiceProvider()
            tripDes.Key = keyArr
            tripDes.Mode = Security.Cryptography.CipherMode.ECB
            tripDes.Padding = Security.Cryptography.PaddingMode.PKCS7
            Dim transform As Security.Cryptography.ICryptoTransform = tripDes.CreateDecryptor()
            Dim arrResult As Byte() = transform.TransformFinalBlock(DeCryptArr, 0, DeCryptArr.Length)
            Return UTF8Encoding.UTF8.GetString(arrResult)
        Catch ex As Exception
        End Try
        Return ""
    End Function


    Public Function MImageToByteArray(ByVal imageIn As System.Drawing.Image) As Byte()
        Dim ms As New IO.MemoryStream()
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
        Return ms.ToArray()
    End Function

    Public Function MByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New IO.MemoryStream(byteArrayIn)
        Dim returnImage As Image = Image.FromStream(ms)
        Return returnImage
    End Function

    Public Sub MOpenLinkElearning(ByVal sDLLName As String, ByVal sFormName As String)
        Dim sSql As String
        If sDLLName = "" Then sDLLName = "CMMS"
        Dim dtTmp As New DataTable

        sSql = "SELECT TOP 1 ISNULL([LINK_BH],N'http://vietsoft.com.vn/elearning/index.html') AS [LINK_BH] FROM DS_FORM WHERE [DLL_NAME] = N'" & sDLLName & "' AND  [FORM_NAME] = N'" & sFormName & "'  "
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count = 0 Then
                sSql = " IF NOT EXISTS( SELECT * FROM DS_FORM WHERE [DLL_NAME] = N'" & sDLLName & "' AND  [FORM_NAME] = N'" & sFormName & "' ) " +
                            " BEGIN INSERT INTO DS_FORM(DLL_NAME,FORM_NAME) VALUES (N'" & sDLLName & "', N'" & sFormName & "') END "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                sSql = "http://vietsoft.com.vn/elearning/index.html"
            Else
                sSql = dtTmp.Rows(0)(0).ToString()
            End If
        Catch ex As Exception
            sSql = "http://vietsoft.com.vn/elearning/index.html"
        End Try
        'INSERT INTO DS_FORM (DLL_NAME,FORM_NAME,[DESCRIPTION])
        Try
            System.Diagnostics.Process.Start(sSql)
        Catch ex As Exception
            System.Diagnostics.Process.Start("http://vietsoft.com.vn")
        End Try
    End Sub

    Public Sub MOpenLinkVideo(ByVal sDLLName As String, ByVal sFormName As String)
        ''IconElearning()
        ''IconLinkVideo()
        Dim sSql As String
        Dim dtTmp As New DataTable

        If sDLLName = "" Then sDLLName = "CMMS"

        sSql = "SELECT TOP 1 ISNULL([LINK_VIDEO],N'http://vietsoft.com.vn/elearning/gallery.html') AS [LINK_VIDEO] FROM DS_FORM WHERE [DLL_NAME] = N'" & sDLLName & "' AND  [FORM_NAME] = N'" & sFormName & "'  "
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count = 0 Then
                sSql = " IF NOT EXISTS( SELECT * FROM DS_FORM WHERE [DLL_NAME] = N'" & sDLLName & "' AND  [FORM_NAME] = N'" & sFormName & "' ) " &
                    " BEGIN INSERT INTO DS_FORM(DLL_NAME,FORM_NAME) VALUES (N'" & sDLLName & "', N'" & sFormName & "') END "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                sSql = "http://vietsoft.com.vn/elearning/gallery.html"
            Else
                sSql = dtTmp.Rows(0)(0).ToString()
            End If
        Catch ex As Exception
            sSql = "http://vietsoft.com.vn/elearning/gallery.html"
        End Try
        Try
            System.Diagnostics.Process.Start(sSql)
        Catch ex As Exception
            System.Diagnostics.Process.Start("http://vietsoft.com.vn")
        End Try
    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CtlDev As DevExpress.XtraEditors.SimpleButton
        Try

            CtlDev = CType(sender, DevExpress.XtraEditors.SimpleButton)
            If CtlDev.Tag = "" Then
                Commons.Modules.ObjSystems.MOpenLinkElearning("CMMS", "frmmain")
                Exit Sub
            End If
            Dim sArr() As String = Split(CtlDev.Tag, "!")
            Dim DLL As String
            Dim sForm As String
            Try
                DLL = sArr(0)
            Catch ex As Exception
                DLL = "CMMS"
            End Try
            Try
                sForm = sArr(1)
            Catch ex As Exception
                sForm = "frmmain"
            End Try
            Commons.Modules.ObjSystems.MOpenLinkElearning(DLL, sForm)
        Catch ex As Exception
            Commons.Modules.ObjSystems.MOpenLinkElearning("CMMS", "frmmain")
        End Try

    End Sub

    Private Sub btnVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim CtlDev As DevExpress.XtraEditors.SimpleButton
            CtlDev = CType(sender, DevExpress.XtraEditors.SimpleButton)
            If CtlDev.Tag = "" Then
                Commons.Modules.ObjSystems.MOpenLinkElearning("CMMS", "frmmain")
                Exit Sub
            End If
            Dim sArr() As String = Split(CtlDev.Tag, "!")
            Dim DLL As String
            Dim sForm As String
            Try
                DLL = sArr(0)
            Catch ex As Exception
                DLL = "CMMS"
            End Try
            Try
                sForm = sArr(1)
            Catch ex As Exception
                sForm = "frmmain"
            End Try

            Commons.Modules.ObjSystems.MOpenLinkVideo(DLL, sForm)
        Catch ex As Exception
            Commons.Modules.ObjSystems.MOpenLinkElearning("CMMS", "frmmain")
        End Try
    End Sub


    Public Sub HTimXtraTreeList(ByVal keyword As String, ByVal treeView As DevExpress.XtraTreeList.TreeList, sMa As String, sTen As String, ByRef arrTim As List(Of String))
        Try

            If keyword = "" Then Exit Sub
            If IsDBNull(keyword) Then Exit Sub
            Static i As Integer
            Dim oNode As DevExpress.XtraTreeList.Nodes.TreeListNode
            Static Dim strOldThietBiNode As String
            Dim ie As DevExpress.XtraTreeList.Nodes.TreeListNodes = treeView.Nodes
            If Trim(strOldThietBiNode) <> "" And Trim(strOldThietBiNode) = Trim(keyword) Then
                i += 1
                If arrTim.Count <= 0 Then Exit Sub
                If i >= arrTim.Count Then
                    If (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonCongViecChoPBT_ThueNgoai", "MsgQuyenKT32", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = MsgBoxResult.Yes Then
                        i = 0
                    Else
                        Exit Sub
                    End If
                End If
                oNode = treeView.FindNodeByFieldValue(sMa, arrTim(i))
                treeView.FocusedNode = oNode
            Else
                i = 0
                arrTim.Clear()
                strOldThietBiNode = keyword
                parseThietBiNode(ie, keyword, sMa, sTen, arrTim)
                If arrTim.Count <= 0 Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonCongViecChoPBT_ThueNgoai", "MsgQuyenKT33", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    strOldThietBiNode = 0
                    Exit Sub
                End If
                oNode = treeView.FindNodeByFieldValue(sMa, arrTim(i))
                treeView.FocusedNode = oNode

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub parseThietBiNode(ByVal tn As DevExpress.XtraTreeList.Nodes.TreeListNodes, ByVal tenNode As String, sMa As String, sTen As String, ByRef arrTim As List(Of String))
        For Each node As DevExpress.XtraTreeList.Nodes.TreeListNode In tn
            If (node(sMa).ToString().Contains(tenNode)) Then
                arrTim.Add(node(sMa))
            ElseIf (ConvertToUnsign3(node(sTen).ToString().ToLower()).Contains(ConvertToUnsign3(tenNode.ToLower()))) Then
                arrTim.Add(node(sMa))
            End If
            parseThietBiNode(node.Nodes, tenNode, sMa, sTen, arrTim)
        Next
    End Sub

    Public Function ConvertToUnsign3(str As String) As String
        Dim regex As New RegularExpressions.Regex("\p{IsCombiningDiacriticalMarks}+")
        Dim temp As String = str.Normalize(NormalizationForm.FormD)
        Return regex.Replace(temp, [String].Empty).Replace("đ"c, "d"c).Replace("Đ"c, "D"c)
    End Function

#Region "DoubleClick"
    Private Sub GridView_MouseUp(sender As Object, e As MouseEventArgs)
        Try
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = View.CalcHitInfo(e.Location)

            If hitInfo.InRow And e.Button = MouseButtons.Left And Form.ModifierKeys = Keys.Control Then
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView_DoubleClick(sender As Object, e As EventArgs)
        If Form.ModifierKeys = Keys.Control Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView
                Dim sText As String = ""
                View = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
                Dim dxMouseEventArgs As DevExpress.Utils.DXMouseEventArgs = TryCast(e, DevExpress.Utils.DXMouseEventArgs)
                Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = View.CalcHitInfo(dxMouseEventArgs.Location)
                If hitInfo.InColumn Then
                    Try
                        Dim sName As String = DirectCast(View.GridControl.Parent.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                        If "frmReports".ToUpper() = sName.ToUpper() Then
                            'sName = View.ParentView.ParentView.ToString().Substring(View.ParentView.ParentView.ProductName.Length + 1)
                            sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                            Try
                                sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                            Catch ex As Exception
                                sName = DirectCast(View.GridControl.Parent.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                            End Try
                        End If

                        If sName.Trim.ToString() = "" Then sName = DirectCast(View.GridControl.Parent.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString


                        sText = XtraInputBox.Show(hitInfo.Column.GetTextCaption, True)
                        If sText = "" Then
                            Exit Sub
                        Else
                            If sText = "Windows.Forms.DialogResult.Retry" Then
                                sText = ""
                                CapNhapNN(sName, hitInfo.Column.FieldName, sText, True)
                            Else
                                CapNhapNN(sName, hitInfo.Column.FieldName, sText, False)
                            End If
                        End If
                        sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = '" & sName & "' AND KEYWORD = '" & hitInfo.Column.FieldName & "' AND MS_MODULE = 'ECOMAIN' "
                        sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))
                        hitInfo.Column.Caption = sText
                    Catch ex As Exception

                    End Try

                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
    Dim selectionLength As Integer = 0
    Private Sub ctr_MouseUp(sender As Object, e As MouseEventArgs)

        If TypeOf sender Is TextEdit Then
            If selectionLength = TryCast(sender, TextEdit).Text.Length Then
                TryCast(sender, TextEdit).DeselectAll()
            Else
                TryCast(sender, TextEdit).SelectAll()
            End If
            selectionLength = TryCast(sender, TextEdit).SelectionLength
        End If

        If TypeOf sender Is TextBox Then
            If selectionLength = TryCast(sender, TextBox).Text.Length Then
                TryCast(sender, TextBox).DeselectAll()
            Else
                TryCast(sender, TextBox).SelectAll()
            End If
            selectionLength = TryCast(sender, TextBox).SelectionLength

        End If

        'If TypeOf sender Is DateEdit Then
        '    'If e.Clicks > 1 Then
        '    '    TryCast(sender, DateEdit).DeselectAll()
        '    'Else
        '    TryCast(sender, DateEdit).SelectAll()
        '        'End If
        '    End If

        If TypeOf sender Is ButtonEdit Then
            If selectionLength = TryCast(sender, ButtonEdit).Text.Length Then
                TryCast(sender, ButtonEdit).DeselectAll()
            Else
                TryCast(sender, ButtonEdit).SelectAll()
            End If
            selectionLength = TryCast(sender, ButtonEdit).SelectionLength
        End If

        If TypeOf sender Is MemoEdit Then
            If selectionLength = TryCast(sender, MemoEdit).Text.Length Then
                TryCast(sender, MemoEdit).DeselectAll()
            Else
                TryCast(sender, MemoEdit).SelectAll()
            End If
            selectionLength = TryCast(sender, MemoEdit).SelectionLength
        End If
    End Sub

    Public Function GetParentForm(parent As Control) As Form
        Dim form As Form = TryCast(parent, Form)
        If form IsNot Nothing Then
            Return form
        End If
        If parent IsNot Nothing Then
            Return GetParentForm(parent.Parent)
        End If
        Return Nothing
    End Function


    Private Sub Label_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As Label
            Dim sText As String = ""
            Ctl = CType(sender, Label)
            Try
                Dim sName As String = GetParentForm(Ctl).Name.ToString 'DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                If "frmReports".ToUpper() = sName.ToUpper() Then
                    sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1)
                    sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                    Try
                        sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                    Catch ex As Exception
                        sName = GetParentForm(Ctl).Name.ToString()
                    End Try
                End If
                If sName.Trim.ToString() = "" Then sName = GetParentForm(Ctl).Name.ToString()
                sText = XtraInputBox.Show(Ctl.Text, True)
                If sText = "" Then
                    Exit Sub
                Else
                    If sText = "Windows.Forms.DialogResult.Retry" Then
                        sText = ""
                        CapNhapNN(sName, Ctl.Name, sText, True)
                    Else
                        CapNhapNN(sName, Ctl.Name, sText, False)
                    End If
                End If
                sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = '" & sName & "' AND KEYWORD = '" & Ctl.Name & "' AND MS_MODULE = 'ECOMAIN'"
                sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Text = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If


    End Sub

    Private Sub RadioButton_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As RadioButton
            Dim sText As String = ""
            Ctl = CType(sender, RadioButton)
            Try
                Dim sName As String = GetParentForm(Ctl).Name.ToString ' = DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                If "frmReports".ToUpper() = sName.ToUpper() Then
                    sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1)
                    sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                    Try
                        sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                    Catch ex As Exception
                        sName = GetParentForm(Ctl).Name.ToString()
                    End Try
                End If
                If sName.Trim.ToString() = "" Then sName = GetParentForm(Ctl).Name.ToString()
                sText = XtraInputBox.Show(Ctl.Text, True)
                If sText = "" Then
                    Exit Sub
                Else
                    If sText = "Windows.Forms.DialogResult.Retry" Then
                        sText = ""
                        CapNhapNN(sName, Ctl.Name, sText, True)
                    Else
                        CapNhapNN(sName, Ctl.Name, sText, False)
                    End If
                End If
                sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = '" & sName & "' AND KEYWORD = '" & Ctl.Name & "' AND MS_MODULE = 'ECOMAIN'"
                sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Text = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If


    End Sub

    Private Sub CheckBox_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As CheckBox
            Dim sText As String = ""
            Ctl = CType(sender, CheckBox)
            Try
                Dim sName As String = GetParentForm(Ctl).Name.ToString '= DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                If "frmReports".ToUpper() = sName.ToUpper() Then
                    sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1)
                    sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                    Try
                        sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                    Catch ex As Exception
                        sName = GetParentForm(Ctl).Name.ToString()
                    End Try
                End If
                If sName.Trim.ToString() = "" Then sName = GetParentForm(Ctl).Name.ToString()
                sText = XtraInputBox.Show(Ctl.Text, True)
                If sText = "" Then
                    Exit Sub
                Else
                    If sText = "Windows.Forms.DialogResult.Retry" Then
                        sText = ""
                        CapNhapNN(sName, Ctl.Name, sText, True)
                    Else
                        CapNhapNN(sName, Ctl.Name, sText, False)
                    End If
                End If
                sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = '" & sName & "' AND KEYWORD = '" & Ctl.Name & "' AND MS_MODULE = 'ECOMAIN'"
                sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Text = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If


    End Sub

    Private Sub LabelControl_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As LabelControl
            Dim sText As String = ""
            Ctl = CType(sender, LabelControl)
            Try
                Dim sName As String = GetParentForm(Ctl).Name.ToString ' = DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                If "frmReports".ToUpper() = sName.ToUpper() Then
                    sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1)
                    sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                    Try
                        sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                    Catch ex As Exception
                        sName = GetParentForm(Ctl).Name.ToString()
                    End Try
                End If
                If sName.Trim.ToString() = "" Then sName = GetParentForm(Ctl).Name.ToString()
                sText = XtraInputBox.Show(Ctl.Text, True)
                If sText = "" Then
                    Exit Sub
                Else
                    If sText = "Windows.Forms.DialogResult.Retry" Then
                        sText = ""
                        CapNhapNN(sName, Ctl.Name, sText, True)
                    Else
                        CapNhapNN(sName, Ctl.Name, sText, False)
                    End If
                End If
                sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = '" & sName & "' AND KEYWORD = '" & Ctl.Name & "' AND MS_MODULE = 'ECOMAIN'"
                sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Text = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If


    End Sub

    Private Sub CheckEdit_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As CheckEdit
            Dim sText As String = ""
            Ctl = CType(sender, CheckEdit)
            Try
                Dim sName As String = GetParentForm(Ctl).Name.ToString ' = DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString

                If "frmReports".ToUpper() = sName.ToUpper() Then
                    sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1)
                    sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                    Try
                        sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                    Catch ex As Exception
                        sName = GetParentForm(Ctl).Name.ToString()
                    End Try
                End If
                If sName.Trim.ToString() = "" Then sName = GetParentForm(Ctl).Name.ToString()
                sText = XtraInputBox.Show(Ctl.Text, True)
                If sText = "" Then
                    Exit Sub
                Else
                    If sText = "Windows.Forms.DialogResult.Retry" Then
                        sText = ""
                        CapNhapNN(sName, Ctl.Name, sText, True)
                    Else
                        CapNhapNN(sName, Ctl.Name, sText, False)
                    End If
                End If
                sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = '" & sName & "' AND KEYWORD = '" & Ctl.Name & "' AND MS_MODULE = 'ECOMAIN'"
                sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Text = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If

    End Sub

    Private Sub Form_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Right Then
            Try
                Dim Ctl As CheckEdit
                Dim sText As String = ""
                Ctl = CType(sender, CheckEdit)
                Dim sName As String = GetParentForm(Ctl).Name.ToString

                'Dim frm = New VietShape.frmNNgu()
                'frm.sForm = sName
                'frm.ShowDialog()
                Commons.Modules.ObjSystems.ThayDoiNN(CType(sender, XtraForm))
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString())
            End Try
        End If
    End Sub
    Private Sub TableLayoutPanel_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = 458752 And e.Button = MouseButtons.Left Then
            Try
                Dim frm = New VietShape.frmNNgu()
                Dim Ctl As TableLayoutPanel
                Ctl = CType(sender, TableLayoutPanel)
                frm.sForm = Ctl.Parent.Name
                frm.ShowDialog()
                'Commons.Modules.ObjSystems.ThayDoiNNNew(sName)
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString())
            End Try
        End If
        'Form.ModifierKeys = Shift Or Control {196608} Form.ModifierKeys = Shift Or Control Or Alt {458752}
    End Sub
    Private Sub CheckedListBoxControl_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As CheckedListBoxControl
            Dim sText As String = ""
            Ctl = CType(sender, CheckedListBoxControl)
            Try
                Dim sName As String
                sName = GetParentForm(Ctl).Name.ToString()
                If "frmReports".ToUpper() = sName.ToUpper() Then
                    sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1)
                    sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                    Try
                        sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                    Catch ex As Exception
                        sName = GetParentForm(Ctl).Name.ToString()
                    End Try
                End If
                If sName.Trim.ToString() = "" Then sName = GetParentForm(Ctl).Name.ToString()
                sText = XtraInputBox.Show(Ctl.Items(Ctl.SelectedIndex).Description, True)
                If sText = "" Then
                    Exit Sub
                Else
                    If sText = "Windows.Forms.DialogResult.Retry" Then
                        sText = ""
                        CapNhapNN(sName, Ctl.Items(Ctl.SelectedIndex).Value, sText, True)
                    Else
                        CapNhapNN(sName, Ctl.Items(Ctl.SelectedIndex).Value, sText, False)
                    End If
                End If
                sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = N'" & sName & "' AND KEYWORD = N'" & Ctl.Items(Ctl.SelectedIndex).Value & "' AND MS_MODULE = 'ECOMAIN'"
                sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Items(Ctl.SelectedIndex).Description = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If


    End Sub


    Private Sub RadioGroup_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As RadioGroup
            Dim sText As String = ""
            Ctl = CType(sender, RadioGroup)
            Try
                Dim sName As String
                sName = GetParentForm(Ctl).Name.ToString()
                If "frmReports".ToUpper() = sName.ToUpper() Then
                    sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1)
                    sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' "
                    Try
                        sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sName))
                    Catch ex As Exception
                        sName = GetParentForm(Ctl).Name.ToString()
                    End Try
                End If
                If sName.Trim.ToString() = "" Then sName = GetParentForm(Ctl).Name.ToString()

                sText = XtraInputBox.Show(Ctl.Properties.Items(Ctl.SelectedIndex).Description, True)
                If sText = "" Then
                    Exit Sub
                Else
                    If sText = "Windows.Forms.DialogResult.Retry" Then
                        sText = ""
                        CapNhapNN(sName, Ctl.Properties.Items(Ctl.SelectedIndex).Value, sText, True)
                    Else
                        CapNhapNN(sName, Ctl.Properties.Items(Ctl.SelectedIndex).Value, sText, False)
                    End If
                End If
                sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = N'" & sName & "' AND KEYWORD = N'" & Ctl.Properties.Items(Ctl.SelectedIndex).Value & "' AND MS_MODULE = 'ECOMAIN'"
                sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Properties.Items(Ctl.SelectedIndex).Description = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If


    End Sub

    Private Sub CapNhapNN(sForm As String, sKeyWord As String, sChuoi As String, bReset As Boolean)
        Dim sSql As String
        If bReset Then

            sSql = "UPDATE LANGUAGES SET " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " = " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM_OR", "ENGLISH_OR") & " WHERE FORM = '" & sForm & "' AND KEYWORD = '" & sKeyWord & "' AND MS_MODULE = 'ECOMAIN'"

        Else
            sSql = "UPDATE LANGUAGES SET " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " = N'" & sChuoi & "' WHERE FORM = '" & sForm & "' AND KEYWORD = '" & sKeyWord & "' AND MS_MODULE = 'ECOMAIN'"
        End If
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
    End Sub



#End Region
End Class

#Region "XtraMessageBox co ngon ngu"
Public Class MssBox
    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String, MessageBoxButtons As MessageBoxButtons)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), "", MessageBoxButtons, MessageBoxIcon.Exclamation)
    End Sub

    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String, MessageBoxIcon As MessageBoxIcon)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), "", MessageBoxButtons.OK, MessageBoxIcon)
    End Sub

    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String, MessageBoxButtons As MessageBoxButtons, MessageBoxIcon As MessageBoxIcon)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), "", MessageBoxButtons, MessageBoxIcon)
    End Sub


    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String, sCaption As String)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), sCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String, sCaption As String, MessageBoxButtons As MessageBoxButtons)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), sCaption, MessageBoxButtons, MessageBoxIcon.Exclamation)
    End Sub

    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String, sCaption As String, MessageBoxIcon As MessageBoxIcon)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), sCaption, MessageBoxButtons.OK, MessageBoxIcon)
    End Sub

    Public Overloads Shared Sub Show(sForm As String, sKeyWord As String, sCaption As String, MessageBoxButtons As MessageBoxButtons, MessageBoxIcon As MessageBoxIcon)
        XtraMessageBox.Show(Commons.Modules.GetNNgu(sForm, sKeyWord), sCaption, MessageBoxButtons, MessageBoxIcon)
    End Sub

End Class

#End Region

#Region "XtraInputBox"
Public Class XtraInputBox

    Private Shared f As XtraForm
    Private Shared WithEvents cmdAccept As DevExpress.XtraEditors.SimpleButton
    Private Shared WithEvents cmdReset As DevExpress.XtraEditors.SimpleButton

    Private Shared txtResults As DevExpress.XtraEditors.TextEdit
    Private Shared lblPrompt As DevExpress.XtraEditors.LabelControl
    Private Shared WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton

    Private Shared Sub InitializeComponent()
        f = New XtraForm
        txtResults = New DevExpress.XtraEditors.TextEdit()
        cmdAccept = New DevExpress.XtraEditors.SimpleButton()
        cmdReset = New DevExpress.XtraEditors.SimpleButton()
        lblPrompt = New DevExpress.XtraEditors.LabelControl()
        cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        DirectCast(txtResults.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        f.SuspendLayout()
        '
        'txtResults
        '
        txtResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        txtResults.Location = New System.Drawing.Point(12, 31)
        txtResults.Name = "txtResults"
        txtResults.Size = New System.Drawing.Size(375, 20)
        txtResults.TabIndex = 0
        txtResults.Text = String.Empty
        '
        'cmdAccept
        '
        cmdAccept.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        cmdAccept.Location = New System.Drawing.Point(231, 57)
        cmdAccept.Name = "cmdAccept"
        cmdAccept.Size = New System.Drawing.Size(75, 23)
        cmdAccept.TabIndex = 1
        cmdAccept.Text = "&Accept"

        AddHandler cmdAccept.Click, AddressOf cmdAccept_Click
        '
        'cmdReset
        '
        cmdReset.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        cmdReset.Location = New System.Drawing.Point(150, 57)
        cmdReset.Name = "cmdReset"
        cmdReset.Size = New System.Drawing.Size(75, 23)
        cmdReset.TabIndex = 1
        cmdReset.Text = "&Reset"

        AddHandler cmdReset.Click, AddressOf cmdReset_Click        '
        'lblPrompt
        '
        lblPrompt.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
        lblPrompt.Location = New System.Drawing.Point(12, 12)
        lblPrompt.Name = "lblPrompt"
        lblPrompt.Size = New System.Drawing.Size(42, 13)
        lblPrompt.TabIndex = 2
        lblPrompt.Text = "prompt"
        '
        'cmdCancel
        '
        cmdCancel.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        cmdCancel.Location = New System.Drawing.Point(312, 57)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(75, 23)
        cmdCancel.TabIndex = 3
        cmdCancel.Text = "&Cancel"
        '
        'XtraInputBox
        '
        f.AcceptButton = cmdAccept
        f.CancelButton = cmdCancel
        f.ClientSize = New System.Drawing.Size(399, 91)
        f.Controls.Add(lblPrompt)
        f.Controls.Add(cmdCancel)
        f.Controls.Add(cmdAccept)
        f.Controls.Add(cmdReset)

        f.Controls.Add(txtResults)
        f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        f.HelpButton = True
        f.MaximizeBox = False
        f.MinimizeBox = False
        f.Name = "XtraInputBox"
        f.ShowInTaskbar = False
        f.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        DirectCast(txtResults.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        f.ResumeLayout(False)
        f.PerformLayout()
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Overloads Shared Sub cmdAccept_Click(sender As Object, e As System.EventArgs) Handles cmdAccept.Click
        f.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Overloads Shared Sub cmdReset_Click(sender As Object, e As System.EventArgs) Handles cmdReset.Click
        f.DialogResult = Windows.Forms.DialogResult.Retry
    End Sub
    Private Overloads Shared Sub cmdCancel_click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        f.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Public Overloads Shared Function Show(Prompt As String) As String
        Return Show(Prompt, Application.ProductName).ToString()
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String) As Object
        Return Show(Prompt, Title, "")
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String, DefaultResponse As String) As Object
        Return Show(Prompt, Title, DefaultResponse, -1)
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String, DefaulResponse As String, XPos As Integer) As Object
        Return Show(Prompt, Title, DefaulResponse, XPos, -1)
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String, DefaultResponse As String, XPos As Integer, YPos As Integer) As String
        InitializeComponent()
        lblPrompt.Text = Prompt
        If Not String.IsNullOrEmpty(DefaultResponse) Then txtResults.Text = DefaultResponse
        f.Text = Title
        f.Top = XPos
        f.Left = YPos
        f.Controls.Remove(cmdReset)
        Dim DialogShow As DialogResult = f.ShowDialog()
        If DialogShow = Windows.Forms.DialogResult.OK Then
            Return txtResults.Text
        Else
            If DialogShow = Windows.Forms.DialogResult.Cancel Then
                Return ""
            Else
                If DialogShow = Windows.Forms.DialogResult.Retry Then
                    Return "Windows.Forms.DialogResult.Retry"
                Else
                    Return DefaultResponse
                End If
            End If

        End If
    End Function



    Public Overloads Shared Function Show(Prompt As String, bReset As Boolean) As String

        Return Show(Prompt, Application.ProductName, bReset).ToString()
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String, bReset As Boolean) As Object

        Return Show(Prompt, Title, "", bReset)
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String, DefaultResponse As String, bReset As Boolean) As Object

        Return Show(Prompt, Title, DefaultResponse, -1, bReset)
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String, DefaulResponse As String, XPos As Integer, bReset As Boolean) As Object

        Return Show(Prompt, Title, DefaulResponse, XPos, -1, bReset)
    End Function

    Public Overloads Shared Function Show(Prompt As String, Title As String, DefaultResponse As String, XPos As Integer, YPos As Integer, bReset As Boolean) As String
        InitializeComponent()
        lblPrompt.Text = Prompt
        If Not String.IsNullOrEmpty(DefaultResponse) Then txtResults.Text = DefaultResponse

        f.Text = Title
        f.Top = XPos
        f.Left = YPos
        If bReset = False Then f.Controls.Remove(cmdReset)

        Dim DialogShow As DialogResult = f.ShowDialog()
        If DialogShow = Windows.Forms.DialogResult.OK Then
            Return txtResults.Text
        Else
            If DialogShow = Windows.Forms.DialogResult.Cancel Then
                Return ""
            Else
                If DialogShow = Windows.Forms.DialogResult.Retry Then
                    Return "Windows.Forms.DialogResult.Retry"
                Else
                    Return DefaultResponse
                End If
            End If

        End If


    End Function
#End Region


    Private _clientSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

    Private receivedBuf As Byte() = New Byte(1024) {}


    Function ConnectService() As Boolean
        Dim attempts As Integer = 0
        While Not _clientSocket.Connected
            Try
                attempts += 1
                _clientSocket.Connect(IConnections.Server, 65530)
                If attempts = 10 Then
                    Return False
                    Exit Function
                End If
            Catch generatedExceptionName As SocketException
            End Try
        End While
        Return True
    End Function


    Private Sub Conn()
        If ConnectService() Then
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveData), _clientSocket)
            Dim buffer As Byte() = Encoding.ASCII.GetBytes("@@" + IConnections.Server)
            _clientSocket.Send(buffer)
        End If
    End Sub








    Private Sub ReceiveData(ar As IAsyncResult)
        Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Dim socket As Socket = DirectCast(ar.AsyncState, Socket)
        Dim received As Integer = socket.EndReceive(ar)
        Dim dataBuf As Byte() = New Byte(received - 1) {}
        Array.Copy(receivedBuf, dataBuf, received)
        'lb_stt.Text = (Encoding.ASCII.GetString(dataBuf))
        'rb_chat.AppendText("\nServer: " + lb_stt.Text);
        _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveData), _clientSocket)

    End Sub

    Public Function CheckServer() As Boolean
        If _clientSocket.Connected Then
            Dim buffer As Byte() = Encoding.ASCII.GetBytes("HDD")
            _clientSocket.Send(buffer)
        End If
    End Function







End Class



