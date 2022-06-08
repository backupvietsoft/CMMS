Imports System.Data
Imports Commons.VS.Classes.Admin
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.ApplicationBlocks.Data
Imports System.IO

Namespace VS.Object
    Public Class MenuCtrl
        Public Function GetAllMenu() As DataTable
            Dim TbMenu As DataTable = New DataTable
            TbMenu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_MENU_ALL"))
            Return TbMenu
        End Function
        Public Function GetMenuOfUser(ByVal vUser As Object) As DataTable
            Dim TbMenu As DataTable = New DataTable
            TbMenu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_MENU_OF_USER", vUser))
            Return TbMenu
        End Function
        Public Function GetMenuOfParent(ByVal vParent As Object, ByVal vUser As Object) As DataTable
            Dim TbMenu As DataTable = New DataTable
            TbMenu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_MENU_OF_PARENT", vParent, vUser))
            Return TbMenu
        End Function
        Public Function GetMenu(ByVal vMenuID As Object) As MenuInfo
            Dim TbMenu As DataTable = New DataTable()
            TbMenu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_MENU", vMenuID))
            Dim vMenuinfo As MenuInfo = New MenuInfo()
            vMenuinfo.MenuID = TbMenu.Rows(0)("MENU_ID")
            vMenuinfo.MenuText = TbMenu.Rows(0)("MENU_TEXT")
            vMenuinfo.MenuEnglish = TbMenu.Rows(0)("MENU_ENGLISH")
            vMenuinfo.MenuChinese = TbMenu.Rows(0)("MENU_CHINESE")
            vMenuinfo.MenuParent = TbMenu.Rows(0)("MENU_PARENT")
            vMenuinfo.MenuLine = TbMenu.Rows(0)("MENU_LINE")
            vMenuinfo.MenuIndex = TbMenu.Rows(0)("MENU_INDEX")
            vMenuinfo.ShortCutKey = TbMenu.Rows(0)("SHORT_KEY")
            vMenuinfo.DllName = TbMenu.Rows(0)("DLL_NAME")
            vMenuinfo.ProjectName = TbMenu.Rows(0)("PROJECT_NAME")
            vMenuinfo.ClassName = TbMenu.Rows(0)("CLASS_NAME")
            vMenuinfo.FunctionName = TbMenu.Rows(0)("FUNCTION_NAME")
            vMenuinfo.MenuNote = TbMenu.Rows(0)("MENU_NOTE")
            Return vMenuinfo
        End Function
        Public Function ShortcutKey(ByVal vShortCutKey As String) As Shortcut
            Select Case (vShortCutKey)
                Case "Alt0"
                    Return System.Windows.Forms.Shortcut.Alt0
                Case "Alt1"
                    Return System.Windows.Forms.Shortcut.Alt1
                Case "Alt2"
                    Return System.Windows.Forms.Shortcut.Alt2
                Case "Alt3"
                    Return System.Windows.Forms.Shortcut.Alt3
                Case "Alt4"
                    Return System.Windows.Forms.Shortcut.Alt4
                Case "Alt5"
                    Return System.Windows.Forms.Shortcut.Alt5
                Case "Alt6"
                    Return System.Windows.Forms.Shortcut.Alt6
                Case "Alt7"
                    Return System.Windows.Forms.Shortcut.Alt7
                Case "Alt8"
                    Return System.Windows.Forms.Shortcut.Alt8
                Case "Alt9"
                    Return System.Windows.Forms.Shortcut.Alt9

                Case "AltBksp"
                    Return System.Windows.Forms.Shortcut.AltBksp
                Case "AltDownArrow"
                    Return System.Windows.Forms.Shortcut.AltDownArrow
                Case "AltF1"
                    Return System.Windows.Forms.Shortcut.AltF1
                Case "AltF10"
                    Return System.Windows.Forms.Shortcut.AltF10
                Case "AltF11"
                    Return System.Windows.Forms.Shortcut.AltF11
                Case "AltF12"
                    Return System.Windows.Forms.Shortcut.AltF12
                Case "AltF2"
                    Return System.Windows.Forms.Shortcut.AltF2
                Case "AltF3"
                    Return System.Windows.Forms.Shortcut.AltF3
                Case "AltF4"
                    Return System.Windows.Forms.Shortcut.AltF4
                Case "AltF5"
                    Return System.Windows.Forms.Shortcut.AltF5
                Case "AltF6"
                    Return System.Windows.Forms.Shortcut.AltF6
                Case "AltF7"
                    Return System.Windows.Forms.Shortcut.AltF7
                Case "AltF8"
                    Return System.Windows.Forms.Shortcut.AltF8
                Case "AltF9"
                    Return System.Windows.Forms.Shortcut.AltF9
                Case "AltLeftArrow"
                    Return System.Windows.Forms.Shortcut.AltLeftArrow
                Case "AltRightArrow"
                    Return System.Windows.Forms.Shortcut.AltRightArrow
                Case "AltUpArrow"
                    Return System.Windows.Forms.Shortcut.AltUpArrow
                Case "Ctrl0"
                    Return System.Windows.Forms.Shortcut.Ctrl0
                Case "Ctrl1"
                    Return System.Windows.Forms.Shortcut.Ctrl1
                Case "Ctrl2"
                    Return System.Windows.Forms.Shortcut.Ctrl2
                Case "Ctrl3"
                    Return System.Windows.Forms.Shortcut.Ctrl3
                Case "Ctrl4"
                    Return System.Windows.Forms.Shortcut.Ctrl4
                Case "Ctrl5"
                    Return System.Windows.Forms.Shortcut.Ctrl5
                Case "Ctrl6"
                    Return System.Windows.Forms.Shortcut.Ctrl6
                Case "Ctrl7"
                    Return System.Windows.Forms.Shortcut.Ctrl7
                Case "Ctrl8"
                    Return System.Windows.Forms.Shortcut.Ctrl8
                Case "Ctrl9"
                    Return System.Windows.Forms.Shortcut.Ctrl9
                Case "CtrlA"
                    Return System.Windows.Forms.Shortcut.CtrlA
                Case "CtrlB"
                    Return System.Windows.Forms.Shortcut.CtrlB
                Case "CtrlC"
                    Return System.Windows.Forms.Shortcut.CtrlC
                Case "CtrlD"
                    Return System.Windows.Forms.Shortcut.CtrlD
                Case "CtrlDel"
                    Return System.Windows.Forms.Shortcut.CtrlDel
                Case "CtrlE"
                    Return System.Windows.Forms.Shortcut.CtrlE
                Case "CtrlF"
                    Return System.Windows.Forms.Shortcut.CtrlF
                Case "CtrlF1"
                    Return System.Windows.Forms.Shortcut.CtrlF1
                Case "CtrlF10"
                    Return System.Windows.Forms.Shortcut.CtrlF10
                Case "CtrlF11"
                    Return System.Windows.Forms.Shortcut.CtrlF11
                Case "CtrlF12"
                    Return System.Windows.Forms.Shortcut.CtrlF12
                Case "CtrlF2"
                    Return System.Windows.Forms.Shortcut.CtrlF2
                Case "CtrlF3"
                    Return System.Windows.Forms.Shortcut.CtrlF3
                Case "CtrlF4"
                    Return System.Windows.Forms.Shortcut.CtrlF4
                Case "CtrlF5"
                    Return System.Windows.Forms.Shortcut.CtrlF5
                Case "CtrlF6"
                    Return System.Windows.Forms.Shortcut.CtrlF6
                Case "CtrlF7"
                    Return System.Windows.Forms.Shortcut.CtrlF7
                Case "CtrlF8"
                    Return System.Windows.Forms.Shortcut.CtrlF8
                Case "CtrlF9"
                    Return System.Windows.Forms.Shortcut.CtrlF9
                Case "CtrlG"
                    Return System.Windows.Forms.Shortcut.CtrlG
                Case "CtrlH"
                    Return System.Windows.Forms.Shortcut.CtrlH
                Case "CtrlI"
                    Return System.Windows.Forms.Shortcut.CtrlI
                Case "CtrlIns"
                    Return System.Windows.Forms.Shortcut.CtrlIns
                Case "CtrlJ"
                    Return System.Windows.Forms.Shortcut.CtrlJ
                Case "CtrlK"
                    Return System.Windows.Forms.Shortcut.CtrlK
                Case "CtrlL"
                    Return System.Windows.Forms.Shortcut.CtrlL
                Case "CtrlM"
                    Return System.Windows.Forms.Shortcut.CtrlM
                Case "CtrlN"
                    Return System.Windows.Forms.Shortcut.CtrlN
                Case "CtrlO"
                    Return System.Windows.Forms.Shortcut.CtrlO
                Case "CtrlP"
                    Return System.Windows.Forms.Shortcut.CtrlP
                Case "CtrlQ"
                    Return System.Windows.Forms.Shortcut.CtrlQ
                Case "CtrlR"
                    Return System.Windows.Forms.Shortcut.CtrlR
                Case "CtrlS"
                    Return System.Windows.Forms.Shortcut.CtrlS
                Case "CtrlShift0"
                    Return System.Windows.Forms.Shortcut.CtrlShift0
                Case "CtrlShift1"
                    Return System.Windows.Forms.Shortcut.CtrlShift1
                Case "CtrlShift2"
                    Return System.Windows.Forms.Shortcut.CtrlShift2
                Case "CtrlShift3"
                    Return System.Windows.Forms.Shortcut.CtrlShift3
                Case "CtrlShift4"
                    Return System.Windows.Forms.Shortcut.CtrlShift4
                Case "CtrlShift5"
                    Return System.Windows.Forms.Shortcut.CtrlShift5
                Case "CtrlShift6"
                    Return System.Windows.Forms.Shortcut.CtrlShift6
                Case "CtrlShift7"
                    Return System.Windows.Forms.Shortcut.CtrlShift7
                Case "CtrlShift8"
                    Return System.Windows.Forms.Shortcut.CtrlShift8
                Case "CtrlShift9"
                    Return System.Windows.Forms.Shortcut.CtrlShift9
                Case "CtrlShiftA"
                    Return System.Windows.Forms.Shortcut.CtrlShiftA
                Case "CtrlShiftB"
                    Return System.Windows.Forms.Shortcut.CtrlShiftB
                Case "CtrlShiftC"
                    Return System.Windows.Forms.Shortcut.CtrlShiftC
                Case "CtrlShiftD"
                    Return System.Windows.Forms.Shortcut.CtrlShiftD
                Case "CtrlShiftE"
                    Return System.Windows.Forms.Shortcut.CtrlShiftE
                Case "CtrlShiftF"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF
                Case "CtrlShiftF1"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF1
                Case "CtrlShiftF10"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF10
                Case "CtrlShiftF11"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF11
                Case "CtrlShiftF12"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF12
                Case "CtrlShiftF2"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF2
                Case "CtrlShiftF3"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF3
                Case "CtrlShiftF4"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF4
                Case "CtrlShiftF5"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF5
                Case "CtrlShiftF6"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF6
                Case "CtrlShiftF7"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF7
                Case "CtrlShiftF8"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF8
                Case "CtrlShiftF9"
                    Return System.Windows.Forms.Shortcut.CtrlShiftF9
                Case "CtrlShiftG"
                    Return System.Windows.Forms.Shortcut.CtrlShiftG
                Case "CtrlShiftH"
                    Return System.Windows.Forms.Shortcut.CtrlShiftH
                Case "CtrlShiftI"
                    Return System.Windows.Forms.Shortcut.CtrlShiftI
                Case "CtrlShiftJ"
                    Return System.Windows.Forms.Shortcut.CtrlShiftJ
                Case "CtrlShiftK"
                    Return System.Windows.Forms.Shortcut.CtrlShiftK
                Case "CtrlShiftL"
                    Return System.Windows.Forms.Shortcut.CtrlShiftL
                Case "CtrlShiftM"
                    Return System.Windows.Forms.Shortcut.CtrlShiftM
                Case "CtrlShiftN"
                    Return System.Windows.Forms.Shortcut.CtrlShiftN
                Case "CtrlShiftO"
                    Return System.Windows.Forms.Shortcut.CtrlShiftO
                Case "CtrlShiftP"
                    Return System.Windows.Forms.Shortcut.CtrlShiftP
                Case "CtrlShiftQ"
                    Return System.Windows.Forms.Shortcut.CtrlShiftQ
                Case "CtrlShiftR"
                    Return System.Windows.Forms.Shortcut.CtrlShiftR
                Case "CtrlShiftS"
                    Return System.Windows.Forms.Shortcut.CtrlShiftS
                Case "CtrlShiftT"
                    Return System.Windows.Forms.Shortcut.CtrlShiftT
                Case "CtrlShiftU"
                    Return System.Windows.Forms.Shortcut.CtrlShiftU
                Case "CtrlShiftV"
                    Return System.Windows.Forms.Shortcut.CtrlShiftV
                Case "CtrlShiftW"
                    Return System.Windows.Forms.Shortcut.CtrlShiftW
                Case "CtrlShiftX"
                    Return System.Windows.Forms.Shortcut.CtrlShiftX
                Case "CtrlShiftY"
                    Return System.Windows.Forms.Shortcut.CtrlShiftY
                Case "CtrlShiftZ"
                    Return System.Windows.Forms.Shortcut.CtrlShiftZ
                Case "CtrlT"
                    Return System.Windows.Forms.Shortcut.CtrlT
                Case "CtrlU"
                    Return System.Windows.Forms.Shortcut.CtrlU
                Case "CtrlV"
                    Return System.Windows.Forms.Shortcut.CtrlV
                Case "CtrlW"
                    Return System.Windows.Forms.Shortcut.CtrlW
                Case "CtrlX"
                    Return System.Windows.Forms.Shortcut.CtrlX
                Case "CtrlY"
                    Return System.Windows.Forms.Shortcut.CtrlY
                Case "CtrlZ"
                    Return System.Windows.Forms.Shortcut.CtrlZ
                Case "Del"
                    Return System.Windows.Forms.Shortcut.Del
                Case "F1"
                    Return System.Windows.Forms.Shortcut.F1
                Case "F10"
                    Return System.Windows.Forms.Shortcut.F10
                Case "F11"
                    Return System.Windows.Forms.Shortcut.F11
                Case "F12"
                    Return System.Windows.Forms.Shortcut.F12
                Case "F2"
                    Return System.Windows.Forms.Shortcut.F2
                Case "F3"
                    Return System.Windows.Forms.Shortcut.F3
                Case "F4"
                    Return System.Windows.Forms.Shortcut.F4
                Case "F5"
                    Return System.Windows.Forms.Shortcut.F5
                Case "F6"
                    Return System.Windows.Forms.Shortcut.F6
                Case "F7"
                    Return System.Windows.Forms.Shortcut.F7
                Case "F8"
                    Return System.Windows.Forms.Shortcut.F8
                Case "F9"
                    Return System.Windows.Forms.Shortcut.F9
                Case "Ins"
                    Return System.Windows.Forms.Shortcut.Ins
                Case "ShiftDel"
                    Return System.Windows.Forms.Shortcut.ShiftDel
                Case "ShiftF1"
                    Return System.Windows.Forms.Shortcut.ShiftF1
                Case "ShiftF10"
                    Return System.Windows.Forms.Shortcut.ShiftF10
                Case "ShiftF11"
                    Return System.Windows.Forms.Shortcut.ShiftF11
                Case "ShiftF12"
                    Return System.Windows.Forms.Shortcut.ShiftF12
                Case "ShiftF2"
                    Return System.Windows.Forms.Shortcut.ShiftF2
                Case "ShiftF3"
                    Return System.Windows.Forms.Shortcut.ShiftF3
                Case "ShiftF4"
                    Return System.Windows.Forms.Shortcut.ShiftF4
                Case "ShiftF5"
                    Return System.Windows.Forms.Shortcut.ShiftF5
                Case "ShiftF6"
                    Return System.Windows.Forms.Shortcut.ShiftF6
                Case "ShiftF7"
                    Return System.Windows.Forms.Shortcut.ShiftF7
                Case "ShiftF8"
                    Return System.Windows.Forms.Shortcut.ShiftF8
                Case "ShiftF9"
                    Return System.Windows.Forms.Shortcut.ShiftF9
                Case "ShiftIns"
                    Return System.Windows.Forms.Shortcut.ShiftIns
                Case Else
                    Return System.Windows.Forms.Shortcut.None
            End Select
        End Function
        Private Sub Removeline(ByVal TbMenu As DataTable)
            Dim i As Integer = 0
            While (i <= TbMenu.Rows.Count - 3)
                Dim rNemu As DataRow = TbMenu.Rows(i)
                Dim rNext As DataRow = TbMenu.Rows(i + 1)
                If (rNemu("MENU_LINE").Equals(True) And rNext("MENU_LINE").Equals(True)) Then
                    TbMenu.Rows.RemoveAt(i + 1)
                    i = i - 1
                End If
                i = i + 1
            End While
            If (TbMenu.Rows.Count > 0) Then
                If (TbMenu.Rows(0)("MENU_LINE").Equals(True)) Then
                    TbMenu.Rows.RemoveAt(0)
                End If
            End If
            If (TbMenu.Rows.Count > 0) Then
                If (TbMenu.Rows(TbMenu.Rows.Count - 1)("MENU_LINE").Equals(True)) Then
                    TbMenu.Rows.RemoveAt(TbMenu.Rows.Count - 1)
                End If
            End If
        End Sub
        Public Sub LoadMenu()
            frmMain.BarMenu.ItemLinks.Clear()

            Dim dtTmp As DataTable = New DataTable()
            Dim TbMenu As DataTable = New DataTable()
            Dim sBTLic, sBTam As String

            sBTLic = "LIC_MENU_TMP" + Commons.Modules.UserName
            sBTam = "MENU_DATA" + Commons.Modules.UserName
            Commons.Modules.ObjSystems.MGiaiMaTable(sBTLic, "LIC_MENU", "MENU_ID", Commons.Modules.UserName, True)



            dtTmp = GetMenuOfUser(Commons.Modules.UserName)
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "")

            Dim sSql As String
            sSql = " SELECT A.MENU_ID, A.MENU_TEXT, A.MENU_ENGLISH, A.MENU_CHINESE, A.MENU_PARENT, " &
                    " A.MENU_LINE, A.MENU_INDEX, A.SHORT_KEY, A.DLL_NAME, A.PROJECT_NAME,  " &
                    " A.CLASS_NAME, A.FUNCTION_NAME, A.MENU_NOTE " &
                    " FROM " + sBTam + " A INNER JOIN " + sBTLic + " B ON A.MENU_ID = B.MENU_ID " &
                    " ORDER BY MENU_INDEX "
            TbMenu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

            TbMenu.DefaultView.RowFilter = "MENU_PARENT IS NULL"
            TbMenu = TbMenu.DefaultView.ToTable("TbMenu")
            For Each rItem As DataRow In TbMenu.Rows
                Dim TbMenuChild As DataTable = New DataTable()
                TbMenuChild = GetMenuOfParent(rItem("MENU_ID").ToString().Trim(), Commons.Modules.UserName)
                If (TbMenuChild.Rows.Count > 0) Then
                    Dim _MSubItem As DevExpress.XtraBars.BarSubItem = New DevExpress.XtraBars.BarSubItem()
                    _MSubItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
                    _MSubItem.Name = rItem("MENU_ID").ToString().Trim()
                    Select Case Commons.Modules.TypeLanguage
                        Case 1
                            If (rItem.IsNull("MENU_ENGLISH") Or rItem("MENU_ENGLISH").ToString().Trim().Equals(String.Empty)) Then
                                _MSubItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MSubItem.Caption = rItem("MENU_ENGLISH").ToString().Trim()
                            End If
                        Case 2
                            If (rItem.IsNull("MENU_CHINESE") Or rItem("MENU_CHINESE").ToString().Trim().Equals(String.Empty)) Then
                                _MSubItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MSubItem.Caption = rItem("MENU_CHINESE").ToString().Trim()
                            End If
                        Case Else
                            If (rItem.IsNull("MENU_TEXT") Or rItem("MENU_TEXT").ToString().Trim().Equals(String.Empty)) Then
                                _MSubItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MSubItem.Caption = rItem("MENU_TEXT").ToString().Trim()
                            End If
                    End Select
                    _MSubItem.Appearance.Font = New Font("Tahoma", 8, FontStyle.Bold)
                    _MSubItem.Appearance.Options.UseFont = True
                    If (Not rItem.IsNull("MENU_LINE") And rItem("MENU_LINE").Equals(True)) Then
                        frmMain.BarMenu.ItemLinks.Add(_MSubItem, True)
                    Else
                        frmMain.BarMenu.ItemLinks.Add(_MSubItem)
                    End If
                    LoadMenuChild(_MSubItem)
                Else
                    Dim _MButtonItem As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
                    _MButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
                    _MButtonItem.Name = rItem("MENU_ID").ToString().Trim()
                    Select Case Commons.Modules.TypeLanguage
                        Case 1
                            If (rItem.IsNull("MENU_ENGLISH") Or rItem("MENU_ENGLISH").ToString().Trim().Equals(String.Empty)) Then
                                _MButtonItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MButtonItem.Caption = rItem("MENU_ENGLISH").ToString().Trim()
                            End If
                        Case 2
                            If (rItem.IsNull("MENU_CHINESE") Or rItem("MENU_CHINESE").ToString().Trim().Equals(String.Empty)) Then
                                _MButtonItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MButtonItem.Caption = rItem("MENU_CHINESE").ToString().Trim()
                            End If
                        Case Else
                            If (rItem.IsNull("MENU_TEXT") Or rItem("MENU_TEXT").ToString().Trim().Equals(String.Empty)) Then
                                _MButtonItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MButtonItem.Caption = rItem("MENU_TEXT").ToString().Trim()
                            End If
                    End Select
                    If (Not rItem.IsNull("SHORT_KEY")) Then
                        Select Case rItem("SHORT_KEY").ToString()
                            Case "A"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Alt Or Keys.A)
                            Case "B"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.B)
                            Case "C"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.C)
                            Case "D"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.D)
                            Case "E"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.E)
                            Case "F"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.F)
                            Case "G"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.G)
                            Case "H"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.H)
                            Case "I"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.I)
                            Case "J"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.J)
                            Case "K"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.K)
                            Case "L"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.L)
                            Case "M"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.M)
                            Case "N"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.N)
                            Case "O"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.O)
                            Case "P"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.P)
                            Case "Q"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.Q)
                            Case "R"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.R)
                            Case "S"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.S)
                            Case "T"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.T)
                            Case "X"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.X)
                            Case "Y"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.Y)
                            Case "V"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Alt Or Keys.V)
                            Case "W"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.W)
                            Case "Z"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.Z)
                            Case Else
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.None)
                        End Select
                    End If
                    _MButtonItem.Appearance.Font = New Font("Tahoma", 8, FontStyle.Bold)
                    _MButtonItem.Appearance.Options.UseFont = True
                    If (Not rItem.IsNull("MENU_LINE") And rItem("MENU_LINE").Equals(True)) Then
                        frmMain.BarMenu.ItemLinks.Add(_MButtonItem, True)
                    Else
                        frmMain.BarMenu.ItemLinks.Add(_MButtonItem)
                    End If
                    If (Not rItem.IsNull("FUNCTION_NAME")) Then
                        AddHandler _MButtonItem.ItemClick, AddressOf Item_Click
                    End If
                End If
            Next

            sBTLic = "LIC_MENU_TMP" + Commons.Modules.UserName
            sBTam = "MENU_DATA" + Commons.Modules.UserName
            Commons.Modules.ObjSystems.XoaTable(sBTLic)
            Commons.Modules.ObjSystems.XoaTable(sBTam)

        End Sub
        Private Sub LoadMenuChild(ByVal _MnParent As DevExpress.XtraBars.BarSubItem)
            Dim TbMenu As DataTable = New DataTable()
            TbMenu = GetMenuOfParent(_MnParent.Name, Commons.Modules.UserName)
            For Each rItem As DataRow In TbMenu.Rows
                Dim TbMenuChild As DataTable = New DataTable()
                TbMenuChild = GetMenuOfParent(rItem("MENU_ID").ToString().Trim(), Commons.Modules.UserName)
                If (TbMenuChild.Rows.Count > 0) Then
                    Dim _MSubItem As DevExpress.XtraBars.BarSubItem = New DevExpress.XtraBars.BarSubItem()
                    _MSubItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
                    _MSubItem.Name = rItem("MENU_ID").ToString().Trim()
                    Select Case Commons.Modules.TypeLanguage
                        Case 1
                            If (rItem.IsNull("MENU_ENGLISH") Or rItem("MENU_ENGLISH").ToString().Trim().Equals(String.Empty)) Then
                                _MSubItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MSubItem.Caption = rItem("MENU_ENGLISH").ToString().Trim()
                            End If
                        Case 2
                            If (rItem.IsNull("MENU_CHINESE") Or rItem("MENU_CHINESE").ToString().Trim().Equals(String.Empty)) Then
                                _MSubItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MSubItem.Caption = rItem("MENU_CHINESE").ToString().Trim()
                            End If
                        Case Else
                            If (rItem.IsNull("MENU_TEXT") Or rItem("MENU_TEXT").ToString().Trim().Equals(String.Empty)) Then
                                _MSubItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MSubItem.Caption = rItem("MENU_TEXT").ToString().Trim()
                            End If
                    End Select
                    _MSubItem.Appearance.Font = New Font("Tahoma", 8, FontStyle.Bold)
                    _MSubItem.Appearance.Options.UseFont = True
                    If (Not rItem.IsNull("MENU_LINE") And rItem("MENU_LINE").Equals(True)) Then
                        _MnParent.ItemLinks.Add(_MSubItem, True)
                    Else
                        _MnParent.ItemLinks.Add(_MSubItem)
                    End If
                    LoadMenuChild(_MSubItem)
                Else
                    Dim _MButtonItem As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
                    _MButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
                    _MButtonItem.Name = rItem("MENU_ID").ToString().Trim()
                    Select Case Commons.Modules.TypeLanguage
                        Case 1
                            If (rItem.IsNull("MENU_ENGLISH") Or rItem("MENU_ENGLISH").ToString().Trim().Equals(String.Empty)) Then
                                _MButtonItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MButtonItem.Caption = rItem("MENU_ENGLISH").ToString().Trim()
                            End If
                        Case 2
                            If (rItem.IsNull("MENU_CHINESE") Or rItem("MENU_CHINESE").ToString().Trim().Equals(String.Empty)) Then
                                _MButtonItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MButtonItem.Caption = rItem("MENU_CHINESE").ToString().Trim()
                            End If
                        Case Else
                            If (rItem.IsNull("MENU_TEXT") Or rItem("MENU_TEXT").ToString().Trim().Equals(String.Empty)) Then
                                _MButtonItem.Caption = rItem("MENU_ID").ToString().Trim()
                            Else
                                _MButtonItem.Caption = rItem("MENU_TEXT").ToString().Trim()
                            End If
                    End Select
                    If (Not rItem.IsNull("SHORT_KEY")) Then
                        Select Case rItem("SHORT_KEY").ToString()
                            Case "A"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Alt Or Keys.A)
                            Case "B"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.B)
                            Case "C"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.C)
                            Case "D"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.D)
                            Case "E"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.E)
                            Case "F"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.F)
                            Case "G"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.G)
                            Case "H"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.H)
                            Case "I"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.I)
                            Case "J"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.J)
                            Case "K"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.K)
                            Case "L"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.L)
                            Case "M"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.M)
                            Case "N"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.N)
                            Case "O"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.O)
                            Case "P"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.P)
                            Case "Q"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.Q)
                            Case "R"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.R)
                            Case "S"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.S)
                            Case "T"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.T)
                            Case "X"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.X)
                            Case "Y"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.Y)
                            Case "V"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Alt Or Keys.V)
                            Case "W"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.W)
                            Case "Z"
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.Control Or Keys.Z)
                            Case Else
                                _MButtonItem.ItemShortcut = New DevExpress.XtraBars.BarShortcut(Keys.None)
                        End Select
                    End If
                    _MButtonItem.Appearance.Font = New Font("Tahoma", 8, FontStyle.Bold)
                    _MButtonItem.Appearance.Options.UseFont = True
                    If (Not rItem.IsNull("MENU_LINE") And rItem("MENU_LINE").Equals(True)) Then
                        _MnParent.ItemLinks.Add(_MButtonItem, True)
                    Else
                        _MnParent.ItemLinks.Add(_MButtonItem)
                    End If
                    If (Not rItem.IsNull("FUNCTION_NAME")) Then
                        AddHandler _MButtonItem.ItemClick, AddressOf Item_Click
                    End If
                End If
            Next
        End Sub
        Private Shared Sub Item_Click(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            Try
                Dim vMenuInfo As MenuInfo = New MenuInfo()
                vMenuInfo = New MenuCtrl().GetMenu(e.Item.Name)
                Dim vAssembly As Assembly
                If (Not vMenuInfo.DllName.Equals(Nothing)) Then
                    If Not vMenuInfo.DllName.ToString().Trim().Equals("") Then
                        vAssembly = Assembly.LoadFrom(Application.StartupPath & "\\DLL\\" & vMenuInfo.DllName.ToString().Trim())
                    Else
                        vAssembly = Assembly.GetExecutingAssembly()
                    End If
                Else
                    vAssembly = Assembly.GetExecutingAssembly()
                End If
                Dim vClassName As Type = vAssembly.GetType(vMenuInfo.ClassName.ToString().Trim())
                Dim vInstance As Object = Activator.CreateInstance(vClassName)
                Dim vMethod As MethodInfo = vInstance.GetType().GetMethod(vMenuInfo.FunctionName.ToString().Trim())
                'Kiem du lieu tung goi de open form
                If sKiemGoi(vMenuInfo.MenuID.ToString()) = False Then Exit Sub
                vMethod.Invoke(vMenuInfo.FunctionName.ToString().Trim(), Nothing)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Shared Function sKiemGoi(ByVal sMenu As String) As Boolean
            Dim sSql As String
            Dim dtTmp As New DataTable
            If Commons.Modules.LicID = 0 Then Return True
            Try

                sSql = "SELECT TYPE" + Commons.Modules.LicID.ToString() + " FROM LIC_ID WHERE (ID_NAME = N'" + Commons.Modules.ObjSystems.MaHoaDL(sMenu).ToString + "')"
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                If dtTmp.Rows.Count = 0 Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain",
                        "msgKhongDungVersion", Commons.Modules.TypeLanguage))
                    Return False
                Else
                    sSql = Commons.Modules.ObjSystems.GiaiMaDL(dtTmp.Rows(0)(0).ToString())
                    If Microsoft.VisualBasic.Strings.Left(Right(sSql, 2), 1) <> Commons.Modules.LicID Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain",
                            "msgKhongDungVersion", Commons.Modules.TypeLanguage))

                        Return False
                    End If
                    If Microsoft.VisualBasic.Strings.Right(Commons.Modules.ObjSystems.GiaiMaDL(dtTmp.Rows(0)(0).ToString()), 1) <> 1 Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain",
                            "msgKhongDungVersion", Commons.Modules.TypeLanguage))
                        Return False
                    End If
                    Return True
                End If
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain",
                    "msgKhongDungVersion", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message)
                Return False
            End Try
        End Function
    End Class

End Namespace
