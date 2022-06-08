Imports System.Threading
Imports System.Windows.Forms

Public Class Program
    <STAThread()>
    Public Shared Sub Main()
        Commons.Modules.ModuleName = "ECOMAIN"

        Commons.Modules.UserName = "admin"
        'Commons.Modules.UserName = "svi1310278"
        'Commons.Modules.UserName = "trungnv"
        Commons.Modules.TypeLanguage = 0

        'Commons.IConnections.Server = "10.39.244.219"
        Commons.IConnections.Server = "192.168.2.27\SQL2017"
        'Commons.IConnections.Database = "CMMS_REMINGTON2"
        Commons.IConnections.Database = "CMMS_TN"
        Commons.IConnections.Password = "123"
        Commons.IConnections.Username = "sa"
        Commons.Modules.sPrivate = "REMINGTON"

        Commons.Modules.iSoLeSL = 1
        Commons.Modules.iSoLeDG = 2
        Commons.Modules.iSoLeTT = 3

        Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
        Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
        Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)


        'Commons.IConnections.Server = "mashilove"
        'Commons.IConnections.Database = "CMMS_ace"
        'Commons.IConnections.Database = "CMMS_TEST"
        'Commons.IConnections.Password = "123"
        'Commons.IConnections.Username = "sa"



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
        Commons.Modules.sFontReport = "Arial"

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
        'Application.Run(New frmTinhGiaLai())

        Application.Run(New Form1())
        'Commons.Modules.SQLString = "0LOAD"
        'Dim frm As New frmPhieuBaoTriBHNT
        'frm.dTNgay = "03/07/2015"
        'frm.dDNgay = "23/07/2016"
        'frm.ShowDialog()

        'Dim frm As New frmThongTinThietBi
        'frm.ShowDialog()

    End Sub

End Class
