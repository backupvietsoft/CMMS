Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Events
Imports Commons.QL.Common.Data

Imports System.Threading
Imports Commons.VS.Classes.Admin
Public Class FrmRefreshData

    Public Function Load_Authorized_User_Form(ByVal Form_Name As String) As String
        Dim dtReaderUserForm As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "QL_LOAD_USER_FORM", Commons.Modules.UserName, Form_Name)
        Dim authorized As String = ""
        While dtReaderUserForm.Read
            authorized = dtReaderUserForm.Item("QUYEN")
        End While
        dtReaderUserForm.Close()
        Return authorized
    End Function

    Public Function RefreshData(ByVal MS_KHO As Integer) As Boolean
        Dim dtTable As New DataTable
        Dim NGAY As DateTime
        NGAY = Date.Parse("01/01/1900")
        Dim connectionString As String = Commons.IConnections.ConnectionString()
        Dim objConnection As New SqlConnection(connectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try
            Dim Prefix As String = "QL_" + Commons.Modules.UserName
            Dim tableName As String = Prefix + "_QL_VAT_TU_TANG_GIAM"
            Dim sql As String = "IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[" + tableName + "]') AND type in (N'U')) DROP TABLE [" + tableName + "] CREATE TABLE dbo.[" + tableName + "]( [MS_DH_NHAP_PT] [NVARCHAR] (14) NOT NULL, [MS_PT] [NVARCHAR] (25) NOT NULL, [MS_VI_TRI] [INT] NOT NULL, [TANG] [FLOAT] NOT  NULL DEFAULT ((0)), [GIAM] [FLOAT] NOT NULL DEFAULT ((0)))"
            SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql)
            Me.prgBar.PerformStep()

            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(objTrans, "QL_LOAD_KIEM_KE_LAST", MS_KHO)
            While dtReader.Read
                NGAY = Date.Parse(dtReader.Item("NGAY").ToString)
                Exit While
            End While
            dtReader.Close()
            prgBar.PerformStep()
            'fill data kiem ke vat tu chi tiet
            dtReader = SqlHelper.ExecuteReader(objTrans, "QL_LOAD_PHIEU_KIEM_KE_VAT_TU_CHI_TIET", MS_KHO, NGAY, "-1")
            dtTable.Load(dtReader)
            dtReader.Close()
            For i As Integer = 0 To dtTable.Rows.Count - 1
                Dim row As DataRow = dtTable.Rows(i)
                sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + row("MS_DH_NHAP_PT").ToString + "','" + row("MS_PT").ToString + "'," + row("MS_VI_TRI").ToString + "," + row("SL_TON_TT").ToString + ",0)"
                SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql)
            Next
            prgBar.PerformStep()

            'FILL DATA FROM DON HANG NHAP VAT TU CHI TIET
            dtReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_LIST_DHN_VAT_CHI_TIET_THEO_PHIEU_KIEM_KE", MS_KHO, NGAY)
            While dtReader.Read
                sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader.Item("MS_DH_NHAP_PT").ToString + "','" + dtReader.Item("MS_PT").ToString + "'," + dtReader.Item("MS_VI_TRI").ToString + "," + IIf(dtReader.Item("SL_VT") Is Nothing Or dtReader.Item("SL_VT").Equals(DBNull.Value), "0", dtReader.Item("SL_VT").ToString()) + ",0)"
                SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql)
            End While
            dtReader.Close()
            prgBar.PerformStep()

            'FILL DATA FROM DON HANH XUAT VAT TU CHI TIET
            dtReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_LIST_DHX_VAT_CHI_TIET_THEO_PHIEU_KIEM_KE", MS_KHO, NGAY)
            While dtReader.Read
                sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader.Item("MS_DH_NHAP_PT").ToString + "','" + dtReader.Item("MS_PT").ToString + "'," + dtReader.Item("MS_VI_TRI").ToString + ",0," + dtReader.Item("SL_VT").ToString + ")"
                SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql)

            End While
            dtReader.Close()
            prgBar.PerformStep()

            'FILL DATA CHUYEN DI
            dtReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_VAT_TU_CHUYEN_DI", MS_KHO, NGAY)
            While dtReader.Read
                sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader.Item("MS_DH_NHAP_PT").ToString + "','" + dtReader.Item("MS_PT").ToString + "'," + dtReader.Item("MS_VI_TRI").ToString + ",0," + dtReader.Item("SL_VT").ToString + ")"
                SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql)
            End While
            dtReader.Close()
            prgBar.PerformStep()

            'FILL DATA CHUYEN DEN
            dtReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_VAT_TU_CHUYEN_DEN", MS_KHO, NGAY)
            While dtReader.Read
                sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader.Item("MS_DH_NHAP_PT").ToString + "','" + dtReader.Item("MS_PT").ToString + "'," + dtReader.Item("MS_VI_TRI").ToString + "," + dtReader.Item("SL_VT").ToString + ",0)"
                SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql)
            End While
            dtReader.Close()
            prgBar.PerformStep()

            'Calculator and Refresh Data
            Dim QUERY As String = "SELECT MS_DH_NHAP_PT,MS_PT,MS_VI_TRI ,SUM(TANG)-SUM(GIAM) SL_VT FROM " + Prefix + "_QL_VAT_TU_TANG_GIAM GROUP BY MS_DH_NHAP_PT,MS_PT,MS_VI_TRI"
            dtReader = SqlHelper.ExecuteReader(objTrans, "QL_SEARCH", QUERY)
            Dim dtTableTang_Giam As New DataTable
            If dtReader.HasRows Then
                dtTableTang_Giam.Load(dtReader)
            End If
            dtReader.Close()
            For i As Integer = 0 To dtTableTang_Giam.Rows.Count - 1
                Dim dtRow As DataRow = dtTableTang_Giam.Rows(i)
                SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", MS_KHO, dtRow("MS_PT").ToString, Integer.Parse(dtRow("MS_VI_TRI").ToString), dtRow("MS_DH_NHAP_PT").ToString, Math.Round(Double.Parse(dtRow("SL_VT").ToString), 3))
            Next
            objTrans.Commit()
            prgBar.PerformStep()
        Catch ex As Exception
            MsgBox(ex.ToString)
            objTrans.Rollback()
            Return False
        Finally
            objConnection.Close()
        End Try
        Return True
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Dispose()
    End Sub

    Private Sub btnTinhToanLai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTinhToanLai.Click
        Me.prgBar.Maximum = 100
        Me.prgBar.Step = 10
        Me.prgBar.PerformStep()
        If Me.cboKHO.SelectedValue IsNot Nothing Then
            If RefreshData(Integer.Parse(Me.cboKHO.SelectedValue.ToString)) Then
                Me.prgBar.PerformStep()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DATA_DA_DUOC_REFRESH", commons.Modules.TypeLanguage))
            End If
        End If
        prgBar.Value = 0
        Try
            Dim str As String = ""
            str = "Drop table QL_" & Commons.Modules.UserName & "_QL_VAT_TU_TANG_GIAM"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub



    Private Sub FrmRefreshData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LOAD_FORM()
    End Sub

    Public Sub LOAD_FORM()
        If Check_User_Form() Then
            commons.Modules.ObjSystems.DinhDang()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            Me.cboKHO.Param = Commons.Modules.UserName
            Me.cboKHO.BindDataSource()
            Show()
        End If
    End Sub

    Function Check_User_Form() As Boolean
        Dim authorized As String = Me.Load_Authorized_User_Form(Name)
        Select Case authorized
            Case "Full access"
                Exit Select
            Case "Read only"
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgReadOnly", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Dispose()
                Return False
                Exit Select
            Case "No access"
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNoAccess", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Dispose()
                Return False
                Exit Select
            Case Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNoAccess1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Dispose()
                Return False
                Exit Select
        End Select
        Return True
    End Function
End Class