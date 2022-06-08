Module Program
    Public Sub Main()
        Commons.Modules.UserName = "Administrator"
        Commons.Modules.TypeLanguage = 1
        Commons.IConnections.Server = "MASHIMARO"
        Commons.IConnections.Database = "CMMS_afc"
        Commons.IConnections.Password = "123"
        Commons.IConnections.Username = "sa"
        Commons.Modules.bDoiFontReport = True
        Commons.Modules.sFontReport = "Tahoma"
        Form1.ShowDialog()

    End Sub
End Module
