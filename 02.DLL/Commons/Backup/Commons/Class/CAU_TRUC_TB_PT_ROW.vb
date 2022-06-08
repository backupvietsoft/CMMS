Public Class CAU_TRUC_TB_PT_ROW

    Dim _MS_MAY As String
    Dim _MS_BO_PHAN As String
    Dim _MS_PT As String

    Public Sub New()
        _MS_MAY = String.Empty
        _MS_BO_PHAN = String.Empty
        _MS_PT = String.Empty
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

    ' <summary>
    ' Gán hoặc nhận về giá trị là Mã số phụ tùng của thiết bị
    ' </summary>
    ' <value>Giá trị truyền vào là kiểu chuổi</value>
    ' <returns>Kiểu chuổi</returns>
    ' <remarks></remarks>
    Public Property PHU_TUNG() As String
        Get
            Return _MS_PT
        End Get
        Set(ByVal value As String)
            _MS_PT = value
        End Set
    End Property
End Class
