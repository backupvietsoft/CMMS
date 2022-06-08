Option Explicit On
Option Strict On
Imports System
Imports System.IO

Public Class clsFile

#Region "Đọc ghi tập tin ra file text"
    ' <summary>
    ' Hàm đọc nội dung của 1 file text.
    ' </summary>
    ' <param name="sPath">Đường dẫn thư mục chứa tập tin.</param>
    ' <param name="sFilename">Tên tập tin cần đọc</param>
    ' <param name="sData">Nội dung cần ghi vào file text.</param>
    ' <param name="EncryptData">Mặc định là FALSE không mã hóa. Nếu là TRUE thì sẽ mã hóa dữ liệu trước khi ghi ra file.</param>
    ' <remarks></remarks>
    Public Shared Sub WriteTextFile(ByVal sPath As String, ByVal sFilename As String, ByVal sData As String, Optional ByVal EncryptData As Boolean = False)
        Dim sFilePath As String = ""

        sFilename = GetCorrectFileName(sFilename)   'loại bỏ các ký tự đặt biệt
        sFilePath = GetCorrectFilePath(sPath & "\" & sFilename) 'loại bỏ các ký tự \ nằm liền nhau

        If File.Exists(sFilePath) = True Then
            If Windows.Forms.MessageBox.Show("Tập tin cần ghi đã tồn tại trên máy !" & vbCrLf & vbCrLf & "Bạn có muốn ghi đè lên tập tin cũ hay không?", "Vietsoft", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If EncryptData = True Then sData = clsXuLy.MaHoaDL(sData)

        'tạo 1 đối tượng StreamWriter để ghi dữ liệu vào tập tin.
        Using sw As StreamWriter = File.CreateText(sFilePath)
            'sw.WriteLine("Có thể ghi số thực với giá trị là {0} hoặc {1} ...", 1, 4.2)
            sw.Write(sData)
            sw.Close()
        End Using
    End Sub


    ' <summary>
    ' Hàm đọc nội dung của 1 file text.
    ' </summary>
    ' <param name="sPath">Đường dẫn thư mục chứa tập tin.</param>
    ' <param name="sFilename">Tên tập tin cần đọc</param>
    ' <param name="DecryptData">Mặc định là FALSE không giải mã dữ liệu được lấy từ file ra. Nếu là TRUE thì sẽ giải mã dữ liệu được đọc từ file ra.</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Shared Function ReadTextFile(ByVal sPath As String, ByVal sFilename As String, Optional ByVal DecryptData As Boolean = False) As String
        Dim sLine As String = ""
        Dim sData As String = ""
        Dim sFilePath As String = ""

        sFilename = GetCorrectFileName(sFilename)
        sFilePath = GetCorrectFilePath(sPath & "\" & sFilename)

        If File.Exists(sFilePath) = False Then
            Windows.Forms.MessageBox.Show("Tập tin cần lấy thông tin không tồn tại !" & vbCrLf & vbCrLf & "Vui lòng kiểm tra lại đường dẫn !", "Vietsoft", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            If DecryptData = True Then sData = clsXuLy.GiaiMaDL(sData)
            Return sData
        End If

        'tạo 1 đối tượng StreamReader để đọc nội dung trong tập tin.
        Using sr As StreamReader = New StreamReader(sFilename)
            'đọc đến cuối file thì thôi
            Do
                sLine = sr.ReadLine()   'đọc từng dòng
                If Not sLine Is Nothing Then sData = sData & sLine & vbCrLf
            Loop Until sLine Is Nothing
            sr.Close()
        End Using

        If Len(sData) > 0 Then sData = IIf(Right$(sData, 2) = vbCrLf, Left$(sData, Len(sData) - 2), sData).ToString() 'loại bỏ ký tự xuống dòng bị dư ra trong khi xử lý

        If DecryptData = True Then sData = clsXuLy.GiaiMaDL(sData)
        Return sData
    End Function
#End Region

    ' <summary>
    ' Hàm loại bỏ nếu có nhiều hơn 1 ký tự \ trong thư mục.
    ' </summary>
    ' <param name="sFilePath">Đường dẫn tập tin cần loại bỏ các ký tự \. Kết quả chỉ trả về 1 ký tự \.</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Private Shared Function GetCorrectFilePath(ByVal sFilePath As String) As String
        While InStr(sFilePath, "\\") > 0
            sFilePath = Replace$(sFilePath, "\\", "\")
        End While
        Return sFilePath
    End Function

    ' <summary>
    ' Hàm loại bỏ các ký tự đặt biệt không được sử dụng trong tập tin và thư mục
    ' </summary>
    ' <param name="sFileName">Tên tập tin cần kiểm tra loại bỏ các ký tự đặt biệt.</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Private Shared Function GetCorrectFileName(ByVal sFileName As String) As String
        sFileName = Replace$(sFileName, "\", "")
        sFileName = Replace$(sFileName, "/", "")
        sFileName = Replace$(sFileName, ":", "")
        sFileName = Replace$(sFileName, "*", "")
        sFileName = Replace$(sFileName, "?", "")
        sFileName = Replace$(sFileName, """", "")
        sFileName = Replace$(sFileName, "<", "")
        sFileName = Replace$(sFileName, ">", "")
        sFileName = Replace$(sFileName, "|", "")
        Return sFileName
    End Function
End Class
