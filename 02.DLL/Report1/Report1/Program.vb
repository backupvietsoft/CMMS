


Imports System.Threading

Public Class Program
    <STAThread()>
    Public Shared Sub Main()
        Commons.Modules.UserName = "admin"
        'Commons.Modules.UserName = "trungnv"
        Commons.Modules.TypeLanguage = 0

        Commons.Modules.iSoLeSL = 1
        Commons.Modules.iSoLeDG = 2
        Commons.Modules.iSoLeTT = 3

        Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
        Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
        Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
        Commons.IConnections.Server = ".\SQL2017"
        Commons.IConnections.Database = "CMMS_VNO"
        'Commons.IConnections.Database = "CMMS_VF"
        Commons.IConnections.Password = "123"
        Commons.IConnections.Username = "sa"
        'Commons.IConnections.Server = ".\SQL2016"
        'Commons.IConnections.Database = "CMMS_PILMICO"
        Vietsoft.Information.ConnectionString = Commons.IConnections.ConnectionString
        Commons.Modules.sPrivate = "GREENFEED"
        Commons.Modules.ModuleName = "ECOMAIN"
        Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com"
        Commons.Modules.sMailFromPass = "Vietsoft@123"
        Commons.Modules.sMailFromSmtp = "smtp.gmail.com"
        Commons.Modules.sMailFromPort = "587"
        Commons.Modules.iLoaiGoiMail = 1
        Commons.Modules.sDDanMail = "E:\Public"
        Commons.Modules.bSSL = True


        Commons.Modules.iLoaiGoiMail = 2
        Commons.Modules.sDDanMail = "E:\Public"

        Commons.Modules.bDoiFontReport = True
        Commons.Modules.sFontReport = "Monotype Corsiva"

        Commons.Modules.ObjSystems.PBTKho = True
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Commons.Modules.ObjSystems.KhoMoi = False
        Vietsoft.Information.UserID = Commons.Modules.UserName
        Commons.Modules.PermisString = "Full access"
        Dim myThread As System.Threading.Thread
        Try
            myThread = New System.Threading.Thread(AddressOf MRunForm)
            myThread.SetApartmentState(ApartmentState.STA)
            myThread.Start()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub MRunForm()
        'Application.Run(New frmDowtimeType())
        Application.Run(New frmNguyenNhanNgungMay())
        'Application.Run(New frmKho())
        'Application.Run(New frmCauseRemedy())
        'Application.Run(New frmNhacungcap())
        'Application.Run(New frmMucUT())
        'Application.Run(New frmDuyetSanXuat())
        'Application.Run(New FrmDiChuyenThietBi())
        'Commons.Modules.SQLString = "0LOAD"
        'Dim frm As New frmPhieuBaoTriBHNT
        'frm.dTNgay = "03/07/2015"
        'frm.dDNgay = "23/07/2016"
        'frm.ShowDialog()
        'Application.Run(New frmDanhSach_CV())
        'Application.Run(New FrmNXHTBPCP())
        'Application.Run(New frmTranferTo())
        'Application.Run(New frmCa())
        'Application.Run(New frmMucUT())
        'Application.Run(New frmThietBi())
        'Application.Run(New FrmLoaiBTQH())
    End Sub

End Class
