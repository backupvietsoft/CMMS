﻿Public Class IGroups    Private _GROUP_ID As Integer    Private _GROUP_NAME As String    Private _DESCRIPTION As String    Private _TYPE_LIC As Integer    Public Property GROUP_ID() As Integer        Get            Return _GROUP_ID        End Get        Set(ByVal value As Integer)            _GROUP_ID = value        End Set    End Property    Public Property GROUP_NAME() As String        Get            Return _GROUP_NAME        End Get        Set(ByVal value As String)            _GROUP_NAME = value        End Set    End Property    Public Property DESCRIPTION() As String        Get            Return _DESCRIPTION        End Get        Set(ByVal value As String)            _DESCRIPTION = value        End Set    End Property    Public Property TYPE_LIC() As Integer        Get            Return _TYPE_LIC        End Get        Set(ByVal value As Integer)            _TYPE_LIC = value        End Set    End PropertyEnd Class