
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptTON_KHO_THEO_VI_TRI_BAYER
    Private SqlText As String = String.Empty

    Private Sub frmrptTON_KHO_THEO_VI_TRI_BAYER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_KHO_KHO", Commons.Modules.UserName))
        cboKho.DataSource = dt
        cboKho.DisplayMember = "TEN_KHO"
        cboKho.ValueMember = "MS_KHO"

        dtTuNgay_Kho.Value = "01/01/" + DateTime.Now.Year.ToString()
        dtDenNgay_Kho.Value = "31/12/" + DateTime.Now.Year.ToString()


        Dim vtbClass As New DataTable
        vtbClass.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_CLASS"))

        Dim vrAll As DataRow = vtbClass.NewRow()
        vrAll("MS_CLASS") = 0
        vrAll("TEN_CLASS") = " < ALL > "
        vtbClass.Rows.InsertAt(vrAll, 0)

        Dim vrNull As DataRow = vtbClass.NewRow()
        vrNull("MS_CLASS") = -1
        vrNull("TEN_CLASS") = ""
        vtbClass.Rows.InsertAt(vrNull, 0)

        cbxClass.DataSource = vtbClass
        cbxClass.ValueMember = "MS_CLASS"
        cbxClass.DisplayMember = "TEN_CLASS"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptTON_THEO_VI_TRI_BAYER()
        Me.Cursor = Cursors.Default
    End Sub

    Sub ShowrptTON_THEO_VI_TRI_BAYER()
        Try
            Dim str As String = ""
            Try
                str = "DROP TABLE dbo.TON_KHO_THEO_VI_TRI_TMP"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_THEO_VI_TRI_BAYER", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, Commons.Modules.TypeLanguage, cbxClass.SelectedValue)
            CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
            ReportPreview("reports/rptTON_KHO_THEO_VI_TRI_BAYER.rpt")
        Catch ex As Exception

        End Try
    End Sub

    Sub CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_TON_KHO_THEO_VI_TRI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_TON_KHO_THEO_VI_TRI(TypeLanguage int , Trangin nvarchar(120), NgayIn nvarchar(120),TieuDe nvarchar(255),MaKho nvarchar(120)," & _
                "TenKho nvarchar(130),MaPT nvarchar(120),TenPT nvarchar(130),QuyCach nvarchar(130),TenViTri nvarchar(130),sDVT nvarchar(120),TonDK nvarchar(120),sNhap nvarchar(120),sXuat nvarchar(120)," & _
                "ChuyenDi nvarchar(120),ChuyenDen nvarchar(120), TonCK nvarchar(120),Tong nvarchar(120),STT nvarchar(15),ThoiGian nvarchar(200),PART_NO NVARCHAR (256),GIA_TRI NVARCHAR (256),TON_MIN NVARCHAR (256), TEN_CLASS NVARCHAR (256),T1 NVARCHAR (256),T2 NVARCHAR (256),T3 NVARCHAR (256),T4 NVARCHAR (256),T5 NVARCHAR (256),T6 NVARCHAR (256),T7 NVARCHAR (256))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TieuDe4", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaKho", Commons.Modules.TypeLanguage)
        Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenKho", Commons.Modules.TypeLanguage) & " : " & cboKho.Text
        Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaPT", Commons.Modules.TypeLanguage)
        Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenPT", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sTenViTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenViTri", Commons.Modules.TypeLanguage)
        Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sDVT", Commons.Modules.TypeLanguage)
        Dim sTonDK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonDK", Commons.Modules.TypeLanguage)
        Dim sNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sNhap", Commons.Modules.TypeLanguage)
        Dim sXuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sXuat", Commons.Modules.TypeLanguage)
        Dim sChuyenDi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "DI_CHUYEN", Commons.Modules.TypeLanguage)
        Dim sChuyenDen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "CL_KK", Commons.Modules.TypeLanguage)
        Dim sTonCK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonCK", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Tong", Commons.Modules.TypeLanguage) '
        Dim ThoiGian As String = lblTungay.Text & " " & dtTuNgay_Kho.Value & "  " & lblDenngay.Text & " " & Format(dtDenNgay_Kho.Value, "short date") 'cboThang.SelectedValue"
        Dim Part_no As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Part_No", Commons.Modules.TypeLanguage)
        Dim Gia_Tri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Gia_Tri", Commons.Modules.TypeLanguage)
        Dim Ton_Min As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ton_Min", Commons.Modules.TypeLanguage)
        Dim Ten_Class As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ten_Class", Commons.Modules.TypeLanguage)
        Dim T1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T1", Commons.Modules.TypeLanguage)
        Dim T2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T2", Commons.Modules.TypeLanguage)
        Dim T3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T3", Commons.Modules.TypeLanguage)
        Dim T4 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T4", Commons.Modules.TypeLanguage)
        Dim T5 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T5", Commons.Modules.TypeLanguage)
        Dim T6 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T6", Commons.Modules.TypeLanguage)
        Dim T7 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T7", Commons.Modules.TypeLanguage)
        str = "INSERT INTO [DBO].rptTIEU_DE_TON_KHO_THEO_VI_TRI(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
                "MaKho,TenKho,MaPT,TenPT,QuyCach,TenViTri,sDVT,TonDK,sNhap,sXuat,ChuyenDi,ChuyenDen,TonCK,Tong,STT,ThoiGian ,Part_No,Gia_Tri,Ton_Min,Ten_Class,T1,T2,T3,T4,T5,T6,T7)" & _
                "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
                "N'" & sTieudeReport & "',N'" & sMaKho & "',N'" & sTenKho & "',N'" & sMaPT & "',N'" & sTenPT & "',N'" & sQuyCach & "',N'" & sTenViTri & "',N'" & sDVT & "',N'" & sTonDK & "',N'" & sNhap & "'," & _
            "N'" & sXuat & "',N'" & sChuyenDi & "',N'" & sChuyenDen & "',N'" & sTonCK & "',N'" & sTong & "',N'" & sSTT & "',N'" & ThoiGian & "'" & ",N'" & Part_no & "'" & ",N'" & Gia_Tri & "'" & ",N'" & Ton_Min & "'" & ",N'" & Ten_Class & "'" & ",N'" & T1 & "'" & ",N'" & T2 & "'" & ",N'" & T3 & "'" & ",N'" & T4 & "'" & ",N'" & T5 & "'" & ",N'" & T6 & "'" & ",N'" & T7 & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)


    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
