


Public Class Program
    <STAThread()> _
    Public Shared Sub Main()
        Commons.Modules.UserName = "admin"
        'Commons.Modules.UserName = "trungnv"
        Commons.Modules.TypeLanguage = 0

        Commons.IConnections.Server = "."
        Commons.IConnections.Database = "CMMS_BR"
        'Commons.IConnections.Database = "CMMS_gf"
        Commons.IConnections.Password = "123"
        Commons.IConnections.Username = "sa"
        Commons.Modules.sPrivate = "BARIA"

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
        Commons.Modules.sFontReport = "Monotype Corsiva"

        Commons.Modules.ObjSystems.PBTKho = True
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Commons.Modules.ObjSystems.KhoMoi = False


        Dim myThread As System.Threading.Thread
        Try
            myThread = New System.Threading.Thread(AddressOf MRunForm)
            myThread.Start()
        Catch ex As Exception
        End Try
    End Sub


    Public Shared Sub MRunForm()
        Application.Run(New XtraForm1())

    End Sub

End Class
