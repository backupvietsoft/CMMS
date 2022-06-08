Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Drawing

Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports System.Windows.Forms.PictureBoxSizeMode
Imports DevExpress.XtraEditors

Public Class frmCompany
    ' <summary>
    ' Thủ tục hiển thị thông tin đơn vị sử dụng
    ' </summary>
    ' <remarks></remarks>
    Sub ShowInfo()
        Dim dtTest As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM THONG_TIN_CHUNG").Tables(0)
        If dtTest.Rows.Count > 0 Then
            For Each dr As DataRow In dtTest.Rows
                txtTenct_V.Text = IIf(IsDBNull(dr("TEN_CTY_TIENG_VIET")), String.Empty, dr("TEN_CTY_TIENG_VIET"))
                txtTenct_A.Text = IIf(IsDBNull(dr("TEN_CTY_TIENG_ANH")), String.Empty, dr("TEN_CTY_TIENG_ANH"))
                txtTentat_V.Text = IIf(IsDBNull(dr("TEN_NGAN_TIENG_VIET")), String.Empty, dr("TEN_NGAN_TIENG_VIET"))
                txtTentat_A.Text = IIf(IsDBNull(dr("TEN_NGAN_TIENG_ANH")), String.Empty, dr("TEN_NGAN_TIENG_ANH"))
                lblDuongdan.Text = IIf(IsDBNull(dr("LOGO_PATH")), String.Empty, dr("LOGO_PATH"))
                txtDiachi_V.Text = IIf(IsDBNull(dr("DIA_CHI_VIET")), String.Empty, dr("DIA_CHI_VIET"))
                txtDiachi_A.Text = IIf(IsDBNull(dr("DIA_CHI_ANH")), String.Empty, dr("DIA_CHI_ANH"))
                txtSofax.Text = IIf(IsDBNull(dr("FAX")), String.Empty, dr("FAX"))
                txtDienthoai.Text = IIf(IsDBNull(dr("PHONE")), String.Empty, dr("PHONE"))
                txtChieucao.Text = IIf(IsDBNull(dr("HEIGHT")), 0, dr("HEIGHT"))
                txtDorong.Text = IIf(IsDBNull(dr("WIDTH")), 0, dr("WIDTH"))
                txtTTCCao.Text = IIf(IsDBNull(dr("TTC_CAO")), 0, dr("TTC_CAO"))
                txtSoLeSL.Text = IIf(IsDBNull(dr("SO_LE_SL")), String.Empty, dr("SO_LE_SL"))
                txtSoLeDG.Text = IIf(IsDBNull(dr("SO_LE_DG")), String.Empty, dr("SO_LE_DG"))
                txtSoLeTT.Text = IIf(IsDBNull(dr("SO_LE_TT")), String.Empty, dr("SO_LE_TT"))
                txtTTCRong.Text = IIf(IsDBNull(dr("TTC_RONG")), 0, dr("TTC_RONG"))
                txtPhantram.Text = IIf(IsDBNull(dr("TI_LE_PHAN_TRAM")), 0, dr("TI_LE_PHAN_TRAM"))
                chkStretch.Checked = IIf(IsDBNull(dr("STRETCH")), False, dr("STRETCH"))
                txtLePhai.Text = IIf(IsDBNull(dr("LE_PHAI_LOGO")), 0, dr("LE_PHAI_LOGO"))
                txtLetren.Text = IIf(IsDBNull(dr("LE_TREN_LOGO")), 0, dr("LE_TREN_LOGO"))
                txtDUONGDANTL.Text = IIf(IsDBNull(dr("DUONG_DAN_TL")), String.Empty, dr("DUONG_DAN_TL"))
                txtEmail.Text = IIf(IsDBNull(dr("EMAIL")), String.Empty, dr("EMAIL"))
                txtTaiKhoan.Text = IIf(IsDBNull(dr("TAI_KHOAN")), String.Empty, dr("TAI_KHOAN"))
                txtTaiKhoanAnh.Text = IIf(IsDBNull(dr("TAI_KHOAN_ANH")), String.Empty, dr("TAI_KHOAN_ANH"))
                txtMaSoThue.Text = IIf(IsDBNull(dr("MS_THUE")), String.Empty, dr("MS_THUE"))
                txtSoPhut.Text = IIf(IsDBNull(dr("SO_PHUT_HIEN_MSG")), String.Empty, dr("SO_PHUT_HIEN_MSG"))


                txtFont.Text = IIf(IsDBNull(dr("FONT_REPORT")), String.Empty, dr("FONT_REPORT"))

                If IsDBNull(dr("DOI_FONT")) Then
                    chkDoiFont.Checked = False
                Else
                    If dr("DOI_FONT") Then
                        chkDoiFont.Checked = True
                        txtFont.Font = New System.Drawing.Font(txtFont.Text, 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    Else
                        chkDoiFont.Checked = False
                    End If
                End If


                If IsDBNull(dr("SENT_MAIL")) Then
                    chkMail.Checked = False
                Else
                    If dr("SENT_MAIL") Then
                        chkMail.Checked = True
                    Else
                        chkMail.Checked = False
                    End If
                End If
                If chkMail.Checked = False Then
                    txtMail.Enabled = False
                    txtPass.Enabled = False
                    txtSmtp.Enabled = False
                    txtPort.Enabled = False
                Else
                    txtMail.Enabled = True
                    txtPass.Enabled = True
                    txtSmtp.Enabled = True
                    txtPort.Enabled = True

                End If

                txtMail.Text = IIf(IsDBNull(dr("MAIL_FROM")), String.Empty, dr("MAIL_FROM"))
                Dim sPass As String
                sPass = IIf(IsDBNull(dr("PASS_MAIL")), String.Empty, dr("PASS_MAIL"))
                sPass = Commons.clsXuLy.GiaiMaDL(sPass)
                txtPass.Text = sPass
                txtSmtp.Text = IIf(IsDBNull(dr("SMTP_MAIL")), String.Empty, dr("SMTP_MAIL"))
                txtPort.Text = IIf(IsDBNull(dr("PORT_MAIL")), String.Empty, dr("PORT_MAIL"))


                If Not IsDBNull(dr("LOGO")) Then

                    Dim arrPicture As Byte() = dr("LOGO")
                    If arrPicture.Length <> 0 Then
                        Dim ms As New MemoryStream(arrPicture)
                        picLogo.Image = Image.FromStream(ms)
                        picLogo.SizeMode = PictureBoxSizeMode.CenterImage
                        picLogo.BorderStyle = BorderStyle.Fixed3D
                    End If
                End If
            Next
        End If
        dtTest.Dispose()
    End Sub

    ' <summary>
    ' Hàm kiểm tra việc nhập dữ liệu
    ' </summary>
    ' <returns>Nếu nhập đầy đủ trả về True, ngược lại là False</returns>
    ' <remarks></remarks>
    Function IsMissing() As Boolean
        Dim lFlag As Boolean = False
        If txtTenct_V.Text.Trim().Equals(String.Empty) Or
            txtDiachi_V.Text.Trim().Equals(String.Empty) Then
            lFlag = True
        End If
        Return lFlag
    End Function



    Public Function imageToByteArray(ByVal imageIn As System.Drawing.Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
        Return (ms.ToArray())
    End Function

    Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Dim returnImage As Image = Image.FromStream(ms)

        Return returnImage
    End Function

    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim converter As New ImageConverter()
        Return DirectCast(converter.ConvertTo(img, GetType(Byte())), Byte())
    End Function

    ' <summary>
    ' Thủ tục cập nhật dữ liệu vào bảng THONG_TIN_CHUNG
    ' </summary>
    ' <remarks></remarks>
    Sub UpdateData()
        'Kiểm tra xem người dùng có chọn hình logo không
        'If lblDuongdan.Text.Equals(String.Empty) Or IO.File.Exists(lblDuongdan.Text.Trim) = False Then
        '    XtraMessageBox.Show("Xin đưa vào logo của công ty bạn", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If
        Dim chuoicanthaythe As String = ""
        Dim chuoithaythe As String = ""
        Dim vtb As New DataTable
        Dim sql As String

        sql = "select duong_dan_tl from thong_tin_chung"
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, sql))
        If vtb.Rows.Count > 0 Then
            chuoicanthaythe = vtb.Rows(0).Item("duong_dan_tl").ToString
        End If
        Dim arrImage1 As Byte() = Nothing
        arrImage1 = ImageToByte(picLogo.Image)
        Try
            Dim arrImage As Byte() = Nothing
            Try
                arrImage = ImageToByte(picLogo.Image)
            Catch ex As Exception
                arrImage = Nothing
            End Try
            Dim arrFilename As String() = Nothing
            'Dim ms As New MemoryStream
            arrFilename = Regex.Split(lblDuongdan.Text, "/")

            If IO.File.Exists(lblDuongdan.Text) = True Then
                '    Array.Reverse(arrFilename)
                '    picLogo.Image.Save(ms, picLogo.Image.RawFormat)
                '    arrImage = ms.GetBuffer()
                '    ms.Close()
            Else
                arrFilename(0) = Nothing
                '    arrImage = Nothing
            End If
            'Kiểm tra trong cơ sở dữ liệu, nếu chưa có mẫu tin nào thì nhập mới,ngược lại
            'thì cập nhật thông tin đã có sự thay đổi.
            Dim lRecordExists As Boolean = False        'Không có record nào

            Dim dtTest As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM THONG_TIN_CHUNG").Tables(0)
            If dtTest.Rows.Count > 0 Then
                lRecordExists = True                    'Đã có dữ liệu rồi
            End If
            dtTest.Dispose()                            'Giải phóng bộ nhớ

            'Việc thêm và cập nhật dữ liệu vào CSDL sẽ được viết bằng câu lệnh StoreProcedure
            'do user đăng nhập làm ảnh hưởng đến việc thi hành câu lệnh nên được viết bằng command line
            'các dòng lệnh dưới đây sẽ được đổi thành storeprocedure khi Form này được nối với ct chính

            Dim SqlText As String = String.Empty
            Dim sPass As String
            sPass = Commons.clsXuLy.MaHoaDL(txtPass.Text)


            If lRecordExists Then
                'Tồn tại thì cập nhật
                SqlText = "exec UPDATE_THONG_TIN_CHUNG_LOG '" & Me.Name & "','" & Commons.Modules.UserName & "',2"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

                SqlText = "UPDATE THONG_TIN_CHUNG SET TEN_CTY_TIENG_VIET=@TEN_CTY_TIENG_VIET," &
                        "TEN_CTY_TIENG_ANH=@TEN_CTY_TIENG_ANH, TEN_NGAN_TIENG_VIET=@TEN_NGAN_TIENG_VIET," &
                        "TEN_NGAN_TIENG_ANH=@TEN_NGAN_TIENG_ANH,LOGO_PATH=" & IIf(arrFilename(0) Is Nothing, "NULL", "@LOGO_PATH") & ",LOGO=" & IIf(arrImage Is Nothing, "NULL", "@LOGO") & "," &
                        "DIA_CHI_VIET=@DIA_CHI_VIET,DIA_CHI_ANH=@DIA_CHI_ANH,PHONE=@PHONE,FAX=@FAX," &
                        "WIDTH=@WIDTH,HEIGHT=@LENGTH,TI_LE_PHAN_TRAM=@TI_LE_PHAN_TRAM," &
                        "STRETCH=@STRETCH,LE_PHAI_LOGO=@LE_PHAI_LOGO,LE_TREN_LOGO=@LE_TREN_LOGO,LOGO_TEN_CTY=@LOGO_TEN_CTY,DUONG_DAN_TL=@DUONG_DAN_TL,EMAIL = @EMAIL,TAI_KHOAN=@TAI_KHOAN" &
                        ",TAI_KHOAN_ANH=@TAI_KHOAN_ANH,SO_PHUT_HIEN_MSG=@SO_PHUT_HIEN_MSG,MS_THUE=@MS_THUE," &
                        "MAIL_FROM=@MAIL_FROM,PASS_MAIL = @PASS_MAIL,SMTP_MAIL = @SMTP_MAIL, PORT_MAIL = @PORT_MAIL, SENT_MAIL = @SENT_MAIL, " &
                        "TTC_CAO=@TTC_CAO, TTC_RONG = @TTC_RONG ,SO_LE_SL = @SO_LE_SL ,  SO_LE_DG = @SO_LE_DG ,  SO_LE_TT = @SO_LE_TT, " &
                        " DOI_FONT = @DOI_FONT,FONT_REPORT = @FONT_REPORT "

            Else
                'Chưa có thì nhập mới
                SqlText = "INSERT INTO THONG_TIN_CHUNG(TEN_CTY_TIENG_VIET,TEN_CTY_TIENG_ANH,TEN_NGAN_TIENG_VIET,TEN_NGAN_TIENG_ANH," &
                        "LOGO_PATH,LOGO,DIA_CHI_VIET,DIA_CHI_ANH,PHONE,FAX,WIDTH,HEIGHT,TI_LE_PHAN_TRAM,STRETCH,LE_PHAI_LOGO," &
                        "LE_TREN_LOGO,LOGO_TEN_CTY,DUONG_DAN_TL,TAI_KHOAN,TAI_KHOAN_ANH,MS_THUE,SO_PHUT_HIEN_MSG, " &
                        "MAIL_FROM, PASS_MAIL, SMTP_MAIL, PORT_MAIL,SENT_MAIL,TTC_CAO,TTC_RONG,SO_LE_SL,SO_LE_DG,SO_LE_TT, DOI_FONT,FONT_REPORT ) " &
                        " VALUES(@TEN_CTY_TIENG_VIET,@TEN_CTY_TIENG_ANH,@TEN_NGAN_TIENG_VIET,@TEN_NGAN_TIENG_ANH," &
                        IIf(arrFilename(0) Is Nothing, "NULL", "@LOGO_PATH") & "," & IIf(arrImage Is Nothing, "NULL", "@LOGO") & ", " &
                        " @DIA_CHI_VIET,@DIA_CHI_ANH,@PHONE,@FAX,@WIDTH,@LENGTH,@TI_LE_PHAN_TRAM,@STRETCH,@LE_PHAI_LOGO," &
                        "@LE_TREN_LOGO,@LOGO_TEN_CTY,@DUONG_DAN_TL,@EMAIL,@TAI_KHOAN,@TAI_KHOAN_ANH,@MS_THUE,@SO_PHUT_HIEN_MSG," &
                        "@MAIL_FROM, @PASS_MAIL, @SMTP_MAIL,@PORT_MAIL,@SENT_MAIL,@TTC_CAO,@TTC_RONG,@SO_LE_SL,@SO_LE_DG,@SO_LE_TT,@DOI_FONT,@FONT_REPORT )"
            End If
            Dim SqlConnect As New SqlClient.SqlConnection(Commons.IConnections.ConnectionString())
            Dim mycom As New SqlClient.SqlCommand(SqlText, SqlConnect)

            mycom.Parameters.Add(New SqlClient.SqlParameter("@TEN_CTY_TIENG_VIET", SqlDbType.NVarChar)).Value = txtTenct_V.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@TEN_CTY_TIENG_ANH", SqlDbType.NVarChar)).Value = txtTenct_A.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@TEN_NGAN_TIENG_VIET", SqlDbType.NVarChar)).Value = txtTentat_V.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@TEN_NGAN_TIENG_ANH", SqlDbType.NVarChar)).Value = txtTentat_A.Text
            If Not arrFilename(0) Is Nothing Then mycom.Parameters.Add(New SqlClient.SqlParameter("@LOGO_PATH", SqlDbType.NVarChar)).Value = arrFilename(0)
            If Not arrImage Is Nothing Then mycom.Parameters.Add(New SqlClient.SqlParameter("@LOGO", SqlDbType.Image)).Value = arrImage
            mycom.Parameters.Add(New SqlClient.SqlParameter("@DIA_CHI_VIET", SqlDbType.NVarChar)).Value = txtDiachi_V.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@DIA_CHI_ANH", SqlDbType.NVarChar)).Value = txtDiachi_A.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@PHONE", SqlDbType.NVarChar)).Value = txtDienthoai.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@FAX", SqlDbType.NVarChar)).Value = txtSofax.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@WIDTH", SqlDbType.Int)).Value = txtDorong.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@LENGTH", SqlDbType.Int)).Value = txtChieucao.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@TI_LE_PHAN_TRAM", SqlDbType.Float)).Value = txtPhantram.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@STRETCH", SqlDbType.Bit)).Value = IIf(chkStretch.CheckState = CheckState.Checked, 1, 0)
            mycom.Parameters.Add(New SqlClient.SqlParameter("@LE_PHAI_LOGO", SqlDbType.Int)).Value = txtLePhai.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@LE_TREN_LOGO", SqlDbType.Int)).Value = txtLetren.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@LOGO_TEN_CTY", SqlDbType.Int)).Value = txtLogoTenct.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@DUONG_DAN_TL", SqlDbType.NVarChar)).Value = txtDUONGDANTL.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@EMAIL", SqlDbType.NVarChar)).Value = txtEmail.Text

            mycom.Parameters.Add(New SqlClient.SqlParameter("@TAI_KHOAN", SqlDbType.NVarChar)).Value = txtTaiKhoan.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@TAI_KHOAN_ANH", SqlDbType.NVarChar)).Value = txtTaiKhoanAnh.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@MS_THUE", SqlDbType.NVarChar)).Value = txtMaSoThue.Text

            mycom.Parameters.Add(New SqlClient.SqlParameter("@MAIL_FROM", SqlDbType.NVarChar)).Value = txtMail.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@PASS_MAIL", SqlDbType.NVarChar)).Value = sPass
            mycom.Parameters.Add(New SqlClient.SqlParameter("@SMTP_MAIL", SqlDbType.NVarChar)).Value = txtSmtp.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@PORT_MAIL", SqlDbType.NVarChar)).Value = txtPort.Text

            If chkMail.Checked = True Then
                mycom.Parameters.Add(New SqlClient.SqlParameter("@SENT_MAIL", SqlDbType.NVarChar)).Value = 1
            Else
                mycom.Parameters.Add(New SqlClient.SqlParameter("@SENT_MAIL", SqlDbType.NVarChar)).Value = 0
            End If


            If txtSoPhut.Text <> "" Then
                mycom.Parameters.Add(New SqlClient.SqlParameter("@SO_PHUT_HIEN_MSG", SqlDbType.Int)).Value = txtSoPhut.Text
            Else
                mycom.Parameters.Add(New SqlClient.SqlParameter("@SO_PHUT_HIEN_MSG", SqlDbType.Int)).Value = 0
            End If
            mycom.Parameters.Add(New SqlClient.SqlParameter("@TTC_CAO", SqlDbType.Int)).Value = txtTTCCao.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@TTC_RONG", SqlDbType.Int)).Value = txtTTCRong.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@SO_LE_SL", SqlDbType.Int)).Value = txtSoLeSL.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@SO_LE_DG", SqlDbType.Int)).Value = txtSoLeDG.Text
            mycom.Parameters.Add(New SqlClient.SqlParameter("@SO_LE_TT", SqlDbType.Int)).Value = txtSoLeTT.Text


            If chkDoiFont.Checked = True Then
                mycom.Parameters.Add(New SqlClient.SqlParameter("@DOI_FONT", SqlDbType.Bit)).Value = 1
                mycom.Parameters.Add(New SqlClient.SqlParameter("@FONT_REPORT", SqlDbType.NVarChar)).Value = txtFont.Text
            Else
                mycom.Parameters.Add(New SqlClient.SqlParameter("@DOI_FONT", SqlDbType.Bit)).Value = 0
                mycom.Parameters.Add(New SqlClient.SqlParameter("@FONT_REPORT", SqlDbType.NVarChar)).Value = ""
            End If




            mycom.Connection.Open()
            mycom.ExecuteNonQuery()
            mycom.Connection.Close()
            If Not lRecordExists Then
                SqlText = "exec UPDATE_THONG_TIN_CHUNG_LOG '" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
            chuoithaythe = txtDUONGDANTL.Text
            sql = "exec UpdateTable '" & chuoicanthaythe & "','" & chuoithaythe & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString(), CommandType.Text, sql)

            XtraMessageBox.Show("Đã cập nhật xong", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + " Kiểm tra lại kết nối, hoặc câu lệnh sai.", "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub btnChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChon.Click
        Dim oOpen As New OpenFileDialog()
        oOpen.InitialDirectory = "C:\"
        oOpen.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        oOpen.FilterIndex = 2
        If oOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                picLogo.Image = Image.FromFile(oOpen.FileName)
                picLogo.SizeMode = PictureBoxSizeMode.CenterImage
                picLogo.BorderStyle = BorderStyle.Fixed3D
                lblDuongdan.Text = oOpen.FileName
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If XtraMessageBox.Show("Bạn muốn xóa bỏ logo này?", "VietSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            picLogo.Image = Nothing
            picLogo.BorderStyle = BorderStyle.None
            lblDuongdan.Text = Nothing
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        ErrorProvider1.Clear()
        Close()
    End Sub

    Private Sub btnCapnhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapnhat.Click
        Dim USER As String
        Dim vtb As New DataTable
        Dim sql As String
        USER = Commons.Modules.UserName
        sql = "select * from USER_CHUC_NANG where username = '" & Commons.Modules.UserName & "'  and stt = 12"
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, sql))
        If vtb.Rows.Count > 0 Then
            If IsMissing() Then
                XtraMessageBox.Show("Nhập dữ liệu chưa đầy đủ.", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If txtDUONGDANTL.Text = "" Then
                XtraMessageBox.Show("Nhập đường dẫn dữ liệu", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            Call UpdateData()
            Commons.Modules.iSoLeSL = Convert.ToInt16(txtSoLeSL.Text)
            Commons.Modules.iSoLeDG = Convert.ToInt16(txtSoLeDG.Text)
            Commons.Modules.iSoLeTT = Convert.ToInt16(txtSoLeTT.Text)

            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG)
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
        Else
            Vietsoft.Information.MsgBox(Me, "MsgKhongcoquyen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

        ClsMain.LoadThongTinChung()
    End Sub

    Private Sub frmCompany_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub frmCompany_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClsMain.LoadThongTinChung()
    End Sub

    Private Sub frmThongtinDonviSudung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Commons.Modules.PermisString.Equals("Read only") Then
            Call ShowInfo()
            EnableButton(False)
        Else
            EnableButton(True)
            Call ShowInfo()
        End If
        picLogo.SizeMode = StretchImage
        ClsMain.SetLanguageForm(Me)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        btnFont.Text = "..."
    End Sub

    Sub EnableButton(ByVal chon As Boolean)
        btnCapnhat.Enabled = chon
        btnChon.Enabled = chon
        btnXoa.Enabled = chon
    End Sub

    Private Sub chkStretch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStretch.Click
        If chkStretch.Checked = True Then
            picLogo.SizeMode = StretchImage
        Else
            picLogo.SizeMode = Normal
        End If
    End Sub

    Private Sub txtSoPhut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoPhut.KeyDown, txtSoLeDG.KeyDown, txtSoLeTT.KeyDown, txtSoLeSL.KeyDown
        If (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub chkMail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMail.CheckedChanged, chkDoiFont.CheckedChanged
        If chkMail.Checked = False Then
            txtMail.Enabled = False
            txtPass.Enabled = False
            txtSmtp.Enabled = False
            txtPort.Enabled = False
        Else
            txtMail.Enabled = True
            txtPass.Enabled = True
            txtSmtp.Enabled = True
            txtPort.Enabled = True

        End If
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        Dim FontDlg As New FontDialog
        If FontDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFont.Text = FontDlg.Font.Name.ToString()
            txtFont.Font = New System.Drawing.Font(txtFont.Text, 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If
    End Sub


End Class