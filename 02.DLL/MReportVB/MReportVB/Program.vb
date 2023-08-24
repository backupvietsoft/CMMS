Imports System.Threading

Public Class Program
    <STAThread()>
    Public Shared Sub Main()
        Commons.Modules.UserName = "trungnv"
        Commons.Modules.UserName = "admin"
        Commons.Modules.TypeLanguage = 0
        Commons.IConnections.Server = "27.74.240.29,1433"
        'Commons.IConnections.Server = "192.168.2.27\SQL2017"
        Commons.IConnections.Database = "CMMS_DEV"
        'Commons.IConnections.Database = "CMMS_TN_NEW"
        'Commons.IConnections.Database = "CMMS_TN"
        Commons.IConnections.Password = "codaikadaiku"
        Commons.IConnections.Username = "sa"
        'Commons.IConnections.Server = "."
        'Commons.IConnections.Database = "CMMS_GREENFEED"
        'Commons.IConnections.Database = "CMMS_BARIA"
        'Commons.IConnections.Password = "Pil@2018"
        'Commons.IConnections.Username = "sa"
        Commons.Modules.iSoLeSL = 1
        Commons.Modules.iSoLeDG = 2
        Commons.Modules.iSoLeTT = 3
        Commons.Modules.ModuleName = "ECOMAINT"
        Commons.Modules.sPrivate = " "
        Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
        Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
        Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
        'Commons.Modules.sMailFrom = "Cmms.rilvn@gmail.com"
        'Commons.Modules.sMailFromPass = "R1l@101007"
        'Commons.Modules.sMailFromSmtp = "smtp.gmail.com"
        'Commons.Modules.sMailFromPort = "25"
        'Commons.Modules.sMailFrom = "ecomaint.cmms@gmail.com"
        'Commons.Modules.sMailFromPass = "Vietsoft@123"
        'Commons.Modules.sMailFromSmtp = "smtp.gmail.com"
        'Commons.Modules.sMailFromPort = "587"
        Commons.Modules.iLoaiGoiMail = 1
        Commons.Modules.sDDanMail = "E:\Public"
        Commons.Modules.bSSL = True
        Commons.Modules.iDefault = 1
        'Commons.Modules.PermisString = "READ ONLY"
        Commons.Modules.PermisString = "Full access"
        Commons.Modules.sDDanMail = "E:\Public"
        'Commons.Modules.bDoiFontReport = True
        'Commons.Modules.sFontReport = "Monotype Corsiva"
        Commons.Modules.ObjSystems.PBTKho = True
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Commons.Modules.ObjSystems.KhoMoi = False
        Dim myThread As Thread
        Try
            myThread = New Thread(AddressOf MRunForm)
            myThread.SetApartmentState(ApartmentState.STA)
            myThread.Start()
        Catch ex As Exception
        End Try

    End Sub


    Public Shared Sub MRunForm()
        'Application.Run(New XtraForm1())
        'Application.Run(New frmPhieuBaoTriBHNT())
        'Application.Run(New frmTinhGiaLai())
        Application.Run(New FrmPhieuXuatKhoVatTu_CS())



        'Commons.Modules.SQLString = "0LOAD"
        'Dim frm As New frmDuyetSanXuat
        'frm.dTNgay = "01/05/2020"
        'frm.dDNgay = "23/07/2020"
        'frm.ShowDialog()
        'Dim frm As New frmThongTinThietBi
        'frm.ShowDialog()

        'Dim frm As MReportVB.frmPhieuBaoTriBHNT = New MReportVB.frmPhieuBaoTriBHNT()
        'Commons.Modules.SQLString = "0LOAD"
        'frm.dTNgay = "01/11/2021"
        'frm.dDNgay = "30/11/2021"
        'frm.ShowDialog()
    End Sub
End Class
