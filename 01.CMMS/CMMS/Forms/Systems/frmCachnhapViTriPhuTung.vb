
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmCachnhapViTriPhuTung

#Region "Event Control"
    Private Sub frmCachnhapViTriPhuTung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshLanguage()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
#End Region

#Region "Private Method"
    Sub RefreshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTitle.Name, commons.Modules.TypeLanguage)
        Me.LblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTitle.Name, commons.Modules.TypeLanguage)
        Me.lblValue.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblValue.Name, commons.Modules.TypeLanguage)
        Me.lblStandFor.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblStandFor.Name, commons.Modules.TypeLanguage)
        Me.lblUseCase.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblUseCase.Name, commons.Modules.TypeLanguage)
        Me.lblA.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblA.Name, commons.Modules.TypeLanguage)
        Me.lblAll.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblAll.Name, commons.Modules.TypeLanguage)
        Me.lblAUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblAUse.Name, commons.Modules.TypeLanguage)
        Me.lblU.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblU.Name, commons.Modules.TypeLanguage)
        Me.lblUnique.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblUnique.Name, commons.Modules.TypeLanguage)
        Me.lblUUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblUUse.Name, commons.Modules.TypeLanguage)
        Me.lblL.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblL.Name, commons.Modules.TypeLanguage)
        Me.lblLeft.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblLeft.Name, commons.Modules.TypeLanguage)
        Me.lblLUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblLUse.Name, commons.Modules.TypeLanguage)
        Me.lblR.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblR.Name, commons.Modules.TypeLanguage)
        Me.lblRight.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblRight.Name, commons.Modules.TypeLanguage)
        Me.lblRUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblRUse.Name, commons.Modules.TypeLanguage)
        Me.lblB.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblB.Name, commons.Modules.TypeLanguage)
        Me.lblBack.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBack.Name, commons.Modules.TypeLanguage)
        Me.lblBUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBUse.Name, commons.Modules.TypeLanguage)
        Me.lblFL.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblFL.Name, commons.Modules.TypeLanguage)
        Me.lblFront_Left.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblFront_Left.Name, commons.Modules.TypeLanguage)
        Me.lblFLUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblFLUse.Name, commons.Modules.TypeLanguage)
        Me.lblFR.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblFR.Name, commons.Modules.TypeLanguage)
        Me.lblFront_Right.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblFront_Right.Name, commons.Modules.TypeLanguage)
        Me.lblFRUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblFRUse.Name, commons.Modules.TypeLanguage)
        Me.lblBL.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBL.Name, commons.Modules.TypeLanguage)
        Me.lblBack_Left.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBack_Left.Name, commons.Modules.TypeLanguage)
        Me.lblBLUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBLUse.Name, commons.Modules.TypeLanguage)
        Me.lblBR.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBR.Name, commons.Modules.TypeLanguage)
        Me.lblBack_Right.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBack_Right.Name, commons.Modules.TypeLanguage)
        Me.lblBRUse.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblBRUse.Name, commons.Modules.TypeLanguage)
    End Sub
#End Region

End Class