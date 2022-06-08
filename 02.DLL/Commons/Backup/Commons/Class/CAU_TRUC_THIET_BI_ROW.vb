Public Class CAU_TRUC_THIET_BI_ROW
    Dim _MS_MAY As String
    Dim _MS_BO_PHAN As String
    Dim _TEN_BO_PHAN As String
    Dim _SO_LUONG As Integer
    Dim _MS_BOPHAN_CHA As String
    Dim _GHI_CHU As String
    Dim _RUN_TIME As Decimal
    Dim _MS_DVT_RT As Integer
    Dim _TEN_DVT_RT As String
    Dim _HINH As String
    Dim _MS_PT As String
    Dim _TEN_PT As String
    Dim _CLASS_ID As String

    Public Sub New()
        _MS_MAY = String.Empty
        _MS_BO_PHAN = String.Empty
        _TEN_BO_PHAN = String.Empty
        _SO_LUONG = 0
        _MS_BOPHAN_CHA = String.Empty
        _GHI_CHU = String.Empty
        _HINH = String.Empty
        _RUN_TIME = 0
        _MS_DVT_RT = 0
        _TEN_DVT_RT = String.Empty
        _MS_PT = String.Empty
        _CLASS_ID = String.Empty
    End Sub

    ' <summary>
    ' Gán hoặc nhận về giá trị là mã máy của thiết bị
    ' </summary>
    ' <value>Giá trị truyền vào kiểu chuổi</value>
    ' <returns>Kiểu chuổi</returns>
    ' <remarks></remarks>
    Public Property MA_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property

    ' <summary>
    ' Gán hoặc nhận về giá trị là Mã bộ phận của thiết bị
    ' </summary>
    ' <value>Giá trị truyền vào là kiểu chuổi</value>
    ' <returns>Kiểu chuổi</returns>
    ' <remarks></remarks>
    Public Property MA_BO_PHAN() As String
        Get
            Return _MS_BO_PHAN
        End Get
        Set(ByVal value As String)
            _MS_BO_PHAN = value
        End Set
    End Property

    Public Property MS_PT() As String
        Get
            Return _MS_PT
        End Get
        Set(ByVal value As String)
            _MS_PT = value
        End Set
    End Property

    ' <summary>
    ' Gán hoặc nhận về giá trị là Tên bộ phận của thiết bị
    ' </summary>
    ' <value>Giá trị truyền vào là kiểu chuổi</value>
    ' <returns>Kiểu chuổi</returns>
    ' <remarks></remarks>
    Public Property TEN_BO_PHAN() As String
        Get
            Return _TEN_BO_PHAN
        End Get
        Set(ByVal value As String)
            _TEN_BO_PHAN = value
        End Set
    End Property

    ' <summary>
    ' Gán hoặc nhận về giá trị là Số lượng thiết bị
    ' </summary>
    ' <value>Giá trị truyền vào là kiểu số</value>
    ' <returns>Kiểu số</returns>
    ' <remarks></remarks>
    Public Property SO_LUONG() As Integer
        Get
            Return _SO_LUONG
        End Get
        Set(ByVal value As Integer)
            _SO_LUONG = value
        End Set
    End Property

    ' <summary>
    ' Gán hoặc nhận về giá trị là Mã bộ phận cấp trên của thiết bị
    ' </summary>
    ' <value>Giá trị truyền vào là kiểu chuổi</value>
    ' <returns>Kiểu chuổi</returns>
    ' <remarks></remarks>
    Public Property BO_PHAN_CHA() As String
        Get
            Return _MS_BOPHAN_CHA
        End Get
        Set(ByVal value As String)
            _MS_BOPHAN_CHA = value
        End Set
    End Property

    ' <summary>
    ' Gán hoặc nhận về giá trị là Thông tin ghi chú của thiết bị
    ' </summary>
    ' <value>Giá trị truyền vào là kiểu chuổi</value>
    ' <returns>Kiểu chuổi</returns>
    ' <remarks></remarks>
    Public Property GHI_CHU() As String
        Get
            Return _GHI_CHU
        End Get
        Set(ByVal value As String)
            _GHI_CHU = value
        End Set
    End Property

    Public Property RUN_TIME() As Decimal
        Get
            Return _RUN_TIME
        End Get
        Set(ByVal value As Decimal)
            _RUN_TIME = value
        End Set
    End Property

    Public Property MS_DVT_RT() As Integer
        Get
            Return _MS_DVT_RT
        End Get
        Set(ByVal value As Integer)
            _MS_DVT_RT = value
        End Set
    End Property

    Public Property TEN_DVT_RT() As String
        Get
            Return _TEN_DVT_RT
        End Get
        Set(ByVal value As String)
            _TEN_DVT_RT = value
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
    Public Property HINH() As String
        Get
            Return _HINH
        End Get
        Set(ByVal value As String)
            _HINH = value
        End Set
    End Property
    Public Property CLASS_ID() As String
        Get
            Return _CLASS_ID
        End Get
        Set(ByVal value As String)
            _CLASS_ID = value
        End Set
    End Property
End Class
