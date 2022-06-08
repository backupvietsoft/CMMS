Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class Modules
    'DevExpress.LookAndFeel.UserLookAndFeel defaultLF = new DevExpress.LookAndFeel.UserLookAndFeel(this);
    Private Shared _defaultLF As DevExpress.LookAndFeel.UserLookAndFeel
    Public Shared Property defaultLF() As DevExpress.LookAndFeel.UserLookAndFeel
        Get
            Return _defaultLF
        End Get
        Set(ByVal value As DevExpress.LookAndFeel.UserLookAndFeel)
            _defaultLF = value
        End Set
    End Property

    Private Shared _ModuleName As String = "ECOMAIN"
    Private Shared myHost As String = System.Net.Dns.GetHostName

    Public Shared Property ModuleName() As String
        Get
            Return _ModuleName
        End Get
        Set(ByVal value As String)
            _ModuleName = value
        End Set
    End Property

    Private Shared _Licences As Integer = 15
    Public Shared Property Licences() As Integer
        Get
            Return _Licences
        End Get
        Set(ByVal value As Integer)
            _Licences = value
        End Set
    End Property
    'Private Shared _Licences As Integer = 5
    Public Shared _LicensePro As Integer = 15
    Public Shared _LicenseProduction As Integer = 15
    Public Shared _LicenseWarehouse As Integer = 15

    Private Shared _LicDemo As Boolean = False
    Public Shared Property LicDemo() As Boolean
        Get
            Return _LicDemo
        End Get
        Set(ByVal value As Boolean)
            _LicDemo = value
        End Set
    End Property

    Public Shared Property LicenseProduction() As Integer
        Get
            Return _LicenseProduction
        End Get
        Set(ByVal value As Integer)
            _LicenseProduction = value
        End Set
    End Property
    Public Shared Property LicenseWarehouse() As Integer
        Get
            Return _LicenseWarehouse
        End Get
        Set(ByVal value As Integer)
            _LicenseWarehouse = value
        End Set
    End Property
    Public Shared Property LicensePro() As Integer
        Get
            Return _LicensePro
        End Get
        Set(ByVal value As Integer)
            _LicensePro = value
        End Set
    End Property


    Public Shared _LicID As Integer
    Public Shared Property LicID() As Integer
        Get
            Return _LicID
        End Get
        Set(ByVal value As Integer)
            _LicID = value
        End Set
    End Property


    Private Shared _DemoDate As DateTime = "12/12/2015"
    Public Shared Property DemoDate() As DateTime
        Get
            Return _DemoDate
        End Get
        Set(ByVal value As DateTime)
            _DemoDate = value
        End Set
    End Property
    Private Shared _UserName As String = String.Empty
    Public Shared Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Private Shared _TypeLanguage As Integer = 0
    Public Shared Property TypeLanguage() As Integer
        Get
            Return _TypeLanguage
        End Get
        Set(ByVal value As Integer)
            _TypeLanguage = value
        End Set
    End Property

    Private Shared _MExcel As MExcel = New MExcel()
    Public Shared Property MExcel() As MExcel
        Get
            Return _MExcel
        End Get
        Set(ByVal value As MExcel)
            _MExcel = value
        End Set
    End Property

    Private Shared _MMail As MMail = New MMail()
    Public Shared Property MMail() As MMail
        Get
            Return _MMail
        End Get
        Set(ByVal value As MMail)
            _MMail = value
        End Set
    End Property

    Private Shared _OSystems As OSystems = New OSystems()
    Public Shared Property ObjSystems() As OSystems
        Get
            Return _OSystems
        End Get
        Set(ByVal value As OSystems)
            _OSystems = value
        End Set
    End Property

    Private Shared _OLanguages As OLanguages = New OLanguages()
    Public Shared Property ObjLanguages() As OLanguages
        Get
            Return _OLanguages
        End Get
        Set(ByVal value As OLanguages)
            _OLanguages = value
        End Set
    End Property

    Private Shared _OGroups As OGroups = New OGroups()
    Public Shared Property ObjGroups() As OGroups
        Get
            Return _OGroups
        End Get
        Set(ByVal value As OGroups)
            _OGroups = value
        End Set
    End Property

    Private Shared _PermisString As String
    Public Shared Property PermisString() As String
        Get
            Return _PermisString
        End Get
        Set(ByVal value As String)
            _PermisString = value
        End Set
    End Property

    Private Shared _DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
    Public Shared Property DataGridViewCellStyle1() As DataGridViewCellStyle
        Get
            Return _DataGridViewCellStyle1
        End Get
        Set(ByVal value As DataGridViewCellStyle)
            _DataGridViewCellStyle1 = value
        End Set
    End Property

    Private Shared _DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle
    Public Shared Property DataGridViewCellStyle2() As DataGridViewCellStyle
        Get
            Return _DataGridViewCellStyle2
        End Get
        Set(ByVal value As DataGridViewCellStyle)
            _DataGridViewCellStyle2 = value
        End Set
    End Property

    Private Shared _SqlString As String = String.Empty
    Public Shared Property SQLString() As String
        Get
            Return _SqlString
        End Get
        Set(ByVal value As String)
            _SqlString = value
        End Set
    End Property

    Private Shared _HasTableVT As Hashtable = New Hashtable
    Public Shared Property HasTableVT() As Hashtable
        Get
            Return _HasTableVT
        End Get
        Set(ByVal value As Hashtable)
            _HasTableVT = value
        End Set
    End Property

    Private Shared _sMailFrom As String = String.Empty
    Public Shared Property sMailFrom() As String
        Get
            Return _sMailFrom
        End Get
        Set(ByVal value As String)
            _sMailFrom = value
        End Set
    End Property

    Private Shared _sMailFromPass As String = String.Empty
    Public Shared Property sMailFromPass() As String
        Get
            Return _sMailFromPass
        End Get
        Set(ByVal value As String)
            _sMailFromPass = value
        End Set
    End Property

    Private Shared _sMailFromSmtp As String = String.Empty
    Public Shared Property sMailFromSmtp() As String
        Get
            Return _sMailFromSmtp
        End Get
        Set(ByVal value As String)
            _sMailFromSmtp = value
        End Set
    End Property

    Private Shared _sMailFromPort As String = String.Empty
    Public Shared Property sMailFromPort() As String
        Get
            Return _sMailFromPort
        End Get
        Set(ByVal value As String)
            _sMailFromPort = value
        End Set
    End Property

    Private Shared _GoiMail As Boolean = False
    Public Shared Property GoiMail() As Boolean
        Get
            Return _GoiMail
        End Get
        Set(ByVal value As Boolean)
            _GoiMail = value
        End Set
    End Property

    Private Shared _iLoaiGoiMail As Integer = 1
    Public Shared Property iLoaiGoiMail() As Integer
        Get
            Return _iLoaiGoiMail
        End Get
        Set(ByVal value As Integer)
            _iLoaiGoiMail = value
        End Set
    End Property

    Private Shared _sDDanMail As String = String.Empty
    Public Shared Property sDDanMail() As String
        Get
            Return _sDDanMail
        End Get
        Set(ByVal value As String)
            _sDDanMail = value
        End Set
    End Property

    ' Xac dinh thong tin cong ty
    Private Shared _sPrivate As String = String.Empty
    Public Shared Property sPrivate() As String
        Get
            Return _sPrivate.ToUpper()
        End Get
        Set(ByVal value As String)
            _sPrivate = value.ToUpper()
        End Set
    End Property

    ' Dung de xac dinh in report cung = 1 hay excel = 0
    Private Shared _iReport As Integer = 0
    Public Shared Property iReport() As Integer
        Get
            Return _iReport
        End Get
        Set(ByVal value As Integer)
            _iReport = value
        End Set
    End Property

    'Dung de dinh nghia set so phieu = ma so.    = 0 Binh Thuong, = 1 so phieu = ma so, = 2 so phieu = ma so lock luon so phieu
    Private Shared _iDefault As Integer = 0
    Public Shared Property iDefault() As Integer
        Get
            Return _iDefault
        End Get
        Set(ByVal value As Integer)
            _iDefault = value
        End Set
    End Property


    Private Shared _iSoLeSL As Integer = 0
    Public Shared Property iSoLeSL() As Integer
        Get
            Return _iSoLeSL
        End Get
        Set(ByVal value As Integer)
            _iSoLeSL = value
        End Set
    End Property

    Private Shared _iSoLeDG As Integer = 2
    Public Shared Property iSoLeDG() As Integer
        Get
            Return _iSoLeDG
        End Get
        Set(ByVal value As Integer)
            _iSoLeDG = value
        End Set
    End Property


    Private Shared _iSoLeTT As Integer = 2
    Public Shared Property iSoLeTT() As Integer
        Get
            Return _iSoLeTT
        End Get
        Set(ByVal value As Integer)
            _iSoLeTT = value
        End Set
    End Property

    Private Shared _sSoLeSL As String = "#,##0"
    Public Shared Property sSoLeSL() As String
        Get
            Return _sSoLeSL
        End Get
        Set(ByVal value As String)
            _sSoLeSL = value
        End Set
    End Property

    Private Shared _sSoLeDG As String = "#,##0.00"
    Public Shared Property sSoLeDG() As String
        Get
            Return _sSoLeDG
        End Get
        Set(ByVal value As String)
            _sSoLeDG = value
        End Set
    End Property

    Private Shared _sSoLeTT As String = "#,##0.00"
    Public Shared Property sSoLeTT() As String
        Get
            Return _sSoLeTT
        End Get
        Set(ByVal value As String)
            _sSoLeTT = value
        End Set
    End Property

    Private Shared _iTRFData As Integer = 0
    Public Shared Property iTRFData() As Integer
        Get
            Return _iTRFData
        End Get
        Set(ByVal value As Integer)
            _iTRFData = value
        End Set
    End Property

    '0 Nhu hien tai, Nhap tu gio va den gio
    '1 Nhap So Gio trong phieu bao tri
    Private Shared _iPBTTheoGio As Integer = 0
    Public Shared Property iPBTTheoGio() As Integer
        Get
            Return _iPBTTheoGio
        End Get
        Set(ByVal value As Integer)
            _iPBTTheoGio = value
        End Set
    End Property

    Private Shared _sDonViMacDinh As String = ""
    Public Shared Property sDonViMacDinh() As String
        Get
            Return _sDonViMacDinh
        End Get
        Set(ByVal value As String)
            _sDonViMacDinh = value
        End Set
    End Property

    '0 Nhu hien tai mac dinh la WO trong ma so phieu bao tri
    '1 Theo dinh nghia trong Don vi
    Private Shared _iMaPBT As Integer = 0
    Public Shared Property iMaPBT() As Integer
        Get
            Return _iMaPBT
        End Get
        Set(ByVal value As Integer)
            _iMaPBT = value
        End Set
    End Property


    Private Shared _iMaKhoMD As Integer = Nothing
    Public Shared Property iMaKhoMD() As Integer
        Get
            Return _iMaKhoMD
        End Get
        Set(ByVal value As Integer)
            _iMaKhoMD = value
        End Set
    End Property

    Private Shared _sTenKhoMD As String = ""
    Public Shared Property sTenKhoMD() As String
        Get
            Return _sTenKhoMD
        End Get
        Set(ByVal value As String)
            _sTenKhoMD = value
        End Set
    End Property


    Private Shared _sTienTeMD As String = "VND"
    Public Shared Property sTienTeMD() As String
        Get
            Return _sTienTeMD
        End Get
        Set(ByVal value As String)
            _sTienTeMD = value
        End Set
    End Property

    Private Shared _sTenNhanVienMD As String = ""
    Public Shared Property sTenNhanVienMD() As String
        Get
            Return _sTenNhanVienMD
        End Get
        Set(ByVal value As String)
            _sTenNhanVienMD = value
        End Set
    End Property

    Private Shared _sMaNhanVienMD As String = ""
    Public Shared Property sMaNhanVienMD() As String
        Get
            Return _sMaNhanVienMD
        End Get
        Set(ByVal value As String)
            _sMaNhanVienMD = value
        End Set
    End Property

    Private Shared _sInfoClient As String = ""
    Public Shared Property sInfoClient() As String
        Get
            Return _sInfoClient
        End Get
        Set(ByVal value As String)
            _sInfoClient = value
        End Set
    End Property

    Private Shared _sInfoSer As String = ""
    Public Shared Property sInfoSer() As String
        Get
            Return _sInfoSer
        End Get
        Set(ByVal value As String)
            _sInfoSer = value
        End Set
    End Property

    Private Shared _bSSL As Boolean = False
    Public Shared Property bSSL() As Boolean
        Get
            Return _bSSL
        End Get
        Set(ByVal value As Boolean)
            _bSSL = value
        End Set
    End Property


    Private Shared _sMailUser As String = ""
    Public Shared Property sMailUser() As String
        Get
            Return _sMailUser
        End Get
        Set(ByVal value As String)
            _sMailUser = value
        End Set
    End Property

    Private Shared _bCNDXDuyet As Boolean = False
    Public Shared Property bCNDXDuyet() As Boolean
        Get
            Return _bCNDXDuyet
        End Get
        Set(ByVal value As Boolean)
            _bCNDXDuyet = value
        End Set
    End Property

    Private Shared _bDoiFontReport As Boolean = False
    Public Shared Property bDoiFontReport() As Boolean
        Get
            Return _bDoiFontReport
        End Get
        Set(ByVal value As Boolean)
            _bDoiFontReport = value
        End Set
    End Property

    Private Shared _sFontReport As String = ""
    Public Shared Property sFontReport() As String
        Get
            Return _sFontReport
        End Get
        Set(ByVal value As String)
            _sFontReport = value
        End Set
    End Property

    Private Shared _sFontForm As String = ""
    Public Shared Property sFontForm() As String
        Get
            Return _sFontForm
        End Get
        Set(ByVal value As String)
            _sFontForm = value
        End Set
    End Property
    Private Shared _iFontsize As Integer = Nothing
    Public Shared Property iFontsize() As Integer
        Get
            Return _iFontsize
        End Get
        Set(ByVal value As Integer)
            _iFontsize = value
        End Set
    End Property

    Private Shared _iBBCPMail As Integer = Nothing
    Public Shared Property iBBCPMail() As Integer
        Get
            Return _iBBCPMail
        End Get
        Set(ByVal value As Integer)
            _iBBCPMail = value
        End Set
    End Property

    Private Shared _iMacDinhCVPT As Integer = Nothing
    Public Shared Property iMacDinhCVPT() As Integer
        Get
            Return _iMacDinhCVPT
        End Get
        Set(ByVal value As Integer)
            _iMacDinhCVPT = value
        End Set
    End Property

    '0 Trong PBT cong viec nhan su nhap theo gio
    '1 Trong PBT cong viec nhan su nhap theo Phut
    Private Shared _iPhutGioPBT As Integer = 0
    Public Shared Property iPhutGioPBT() As Integer
        Get
            Return _iPhutGioPBT
        End Get
        Set(ByVal value As Integer)
            _iPhutGioPBT = value
        End Set
    End Property

End Class
