
Imports System.Data
Imports System.Data.SqlClient
Imports Commons.QL.Common.Data
Imports Microsoft.ApplicationBlocks.Data
Namespace VS.Classes.Catalogue
    Public Class DI_CHUYEN_KHO_VAT_TU_Controller

        Private connectionString As String = ""

        Public Sub New()
            Me.connectionString = Commons.IConnections.ConnectionString
        End Sub

        Public Function Load_Authorized_User_Form(ByVal Form_Name As String) As String
            Dim dtReaderUserForm As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_USER_FORM", Commons.Modules.UserName, Form_Name)
            Dim authorized As String = ""
            While dtReaderUserForm.Read
                authorized = dtReaderUserForm.Item("QUYEN")
            End While
            dtReaderUserForm.Close()
            Return authorized
        End Function

        Public Function Load_Vat_Tu_From_Kho_Position(ByVal MS_KHO As Integer, ByVal MS_VI_TRI As Integer) As List(Of DiChuyenVatTu)
            Dim lstVatTu As New List(Of DiChuyenVatTu)
            lstVatTu = QLBusinessDataController.FillCollection(Of DiChuyenVatTu) _
                    (SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                    "QL_LOAD_VAT_TU_KHO_VI_TRI", MS_KHO, MS_VI_TRI))
            Return lstVatTu
        End Function

        Public Function Add_Di_Chuyen_Vi_Tri_Trong_Kho(ByVal NGAY_CHUYEN As Date, ByVal GIO_CHUYEN As Date, _
                ByVal MS_KHO As Integer, ByVal MS_VI_TRI As Integer, ByVal MS_KHO_1 As Integer, _
                ByVal MS_VI_TRI_1 As Integer, ByVal tb As DataTable) As Boolean
            Try
                For i As Integer = 0 To tb.Rows.Count - 1
                    If Not IsDBNull(tb.Rows(i).Item("SL_DC")) Then
                        SqlHelper.ExecuteNonQuery(connectionString, "QL_ADD_DI_CHUYEN_VI_TRI_TRONG_KHO", _
                            NGAY_CHUYEN, GIO_CHUYEN, MS_KHO, MS_VI_TRI, tb.Rows(i).Item("MS_PT"), _
                            tb.Rows(i).Item("MS_DH_NHAP_PT"), MS_KHO_1, MS_VI_TRI_1, _
                            Double.Parse(tb.Rows(i).Item("SL_DC")), tb.Rows(i).Item("SL_VT"), _
                            Double.Parse(tb.Rows(i).Item("ID_DC")))

                        Dim objVTKVT As New VI_TRI_KHO_VAT_TU_Info
                        objVTKVT.MS_DH_NHAP_PT = tb.Rows(i).Item("MS_DH_NHAP_PT")
                        objVTKVT.MS_KHO = MS_KHO_1
                        objVTKVT.MS_VI_TRI = MS_VI_TRI_1
                        objVTKVT.MS_PT = tb.Rows(i).Item("MS_PT")
                        objVTKVT.SL_VT = Double.Parse(tb.Rows(i).Item("SL_DC"))
                        objVTKVT.ID = Double.Parse(tb.Rows(i).Item("ID_DC"))

                        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, _
                            "QL_LOAD_VI_TRI_KHO_VAT_TU", objVTKVT.MS_KHO, objVTKVT.MS_PT, objVTKVT.MS_VI_TRI, _
                            objVTKVT.MS_DH_NHAP_PT, objVTKVT.ID)
                        Dim Flag As Boolean = True
                        While dtReader.Read
                            objVTKVT.SL_VT = objVTKVT.SL_VT + Double.Parse(dtReader("SL_VT").ToString)
                            SqlHelper.ExecuteNonQuery(connectionString, "QL_UPDATE_VI_TRI_KHO_VAT_TU", _
                                objVTKVT.MS_KHO, objVTKVT.MS_PT, objVTKVT.MS_VI_TRI, objVTKVT.MS_DH_NHAP_PT, _
                                objVTKVT.SL_VT, objVTKVT.ID)
                            Flag = False
                        End While
                        If Flag Then
                            SqlHelper.ExecuteNonQuery(connectionString, "QL_ADD_VI_TRI_KHO_VAT_TU", _
                                objVTKVT.MS_KHO, objVTKVT.MS_PT, objVTKVT.MS_VI_TRI, objVTKVT.MS_DH_NHAP_PT, _
                                objVTKVT.SL_VT, objVTKVT.ID)
                        End If
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try
            Return True
        End Function

        Public Function Load_Phu_Tung(ByVal MS_PT As String) As IC_PHU_TUNG_Info
            Dim objPhuTung As New IC_PHU_TUNG_Info
            Try
                objPhuTung = QLBusinessDataController.FillObject(Of IC_PHU_TUNG_Info) _
                        (SqlHelper.ExecuteReader(connectionString, "QL_LOAD_PHU_TUNG", MS_PT))
            Catch ex As Exception
            End Try
            Return objPhuTung
        End Function
    End Class

    Public Class DiChuyenVatTu
        Private _MS_PT As String = ""
        Private _TEN_PT As String = ""
        Private _MS_DH_NHAP_PT As String = ""
        Private _QUY_CACH As String = ""
        Private _SL_VT As Double
        Private _SL_DC As String
        Private _ID_DC As Double

        Public Sub New()
        End Sub

        Public Property MS_PT() As String
            Get
                Return _MS_PT
            End Get
            Set(ByVal value As String)
                _MS_PT = value
            End Set
        End Property
        Public Property TEN_PT() As String
            Get
                Return _TEN_PT
            End Get
            Set(ByVal value As String)
                _TEN_PT = value
            End Set
        End Property

        Public Property QUY_CACH() As String
            Get
                Return _QUY_CACH
            End Get
            Set(ByVal value As String)
                _QUY_CACH = value
            End Set
        End Property


        Public Property MS_DH_NHAP_PT() As String
            Get
                Return _MS_DH_NHAP_PT
            End Get
            Set(ByVal value As String)
                _MS_DH_NHAP_PT = value
            End Set
        End Property

        Public Property SL_VT() As Double
            Get
                Return _SL_VT
            End Get
            Set(ByVal value As Double)
                _SL_VT = value
            End Set
        End Property

        Public Property SL_DC() As String
            Get
                Return _SL_DC
            End Get
            Set(ByVal value As String)
                _SL_DC = value
            End Set
        End Property

        Public Property ID_DC() As Double
            Get
                Return _ID_DC
            End Get
            Set(ByVal value As Double)
                _ID_DC = value
            End Set
        End Property
    End Class
End Namespace
