﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Imports System.ComponentModel


Public Class rptrptKiemKeVT_PT
    Inherits ReportClass

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Property ResourceName() As String
        Get
            Return "rptrptKiemKeVT_PT.rpt"
        End Get
        Set(ByVal value As String)
            'Do nothing
        End Set
    End Property

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Section1() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(0)
        End Get
    End Property

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Section2() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(1)
        End Get
    End Property

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Section3() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(2)
        End Get
    End Property

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Section4() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(3)
        End Get
    End Property

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Section5() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(4)
        End Get
    End Property
End Class

<System.Drawing.ToolboxBitmapAttribute(GetType(CrystalDecisions.[Shared].ExportOptions), "report.bmp")> _
Public Class CachedrptKiemKeVT_PT
    Inherits Component
    Implements ICachedReport

    Public Sub New()
        MyBase.New()
    End Sub

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public Overridable Property IsCacheable() As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
            '
        End Set
    End Property

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public Overridable Property ShareDBLogonInfo() As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            '
        End Set
    End Property

    <Browsable(False), _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public Overridable Property CacheTimeOut() As System.TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
        Get
            Return CachedReportConstants.DEFAULT_TIMEOUT
        End Get
        Set(ByVal value As System.TimeSpan)
            '
        End Set
    End Property

    Public Overridable Function CreateReport() As CrystalDecisions.CrystalReports.Engine.ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
        Dim rpt As rptKiemKeVT_PT = New rptKiemKeVT_PT
        rpt.Site = Me.Site
        Return rpt
    End Function

    Public Overridable Function GetCustomizedCacheKey(ByVal request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
        Dim key As [String] = Nothing
        '// The following is the code used to generate the default
        '// cache key for caching report jobs in the ASP.NET Cache.
        '// Feel free to modify this code to suit your needs.
        '// Returning key == null causes the default cache key to
        '// be generated.
        '
        'key = RequestContext.BuildCompleteCacheKey(
        '    request,
        '    null,       // sReportFilename
        '    this.GetType(),
        '    this.ShareDBLogonInfo );
        Return key
    End Function
End Class
