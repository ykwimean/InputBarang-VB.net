Public Class FrmBarang
    Sub tampildata()
        'TODO: This line of code loads data into the 'BarangDataSet.Tbl_barang' table. You can move, or remove it, as needed.
        Me.Tbl_barangTableAdapter.Fill(Me.BarangDataSet.Tbl_barang)
    End Sub
    Sub cleartext()
        TextKode.Clear()
        TextNama.Clear()
        TextJumlah.Clear()
        TextKeterangan.Clear()
    End Sub
    Sub textfalse()
        TextJumlah.Enabled = False
        TextNama.Enabled = False
        TextKode.Enabled = False
        TextKeterangan.Enabled = False
    End Sub
    Sub texttrue()
        TextJumlah.Enabled = True
        TextNama.Enabled = True
        TextKode.Enabled = True
        TextKeterangan.Enabled = True
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextKode.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextNama.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextJumlah.Text = DataGridView1.CurrentRow.Cells(3).Value
        TextKeterangan.Text = DataGridView1.CurrentRow.Cells(4).Value
        Call texttrue()
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub FrmBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampildata()
        Call textfalse()


    End Sub

    Private Sub BtnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambah.Click
        Call cleartext()
        Call texttrue()
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If Trim(TextKode.Text) = "" Or Trim(TextNama.Text) = "" Or Trim(TextJumlah.Text) = "" Or Trim(TextKeterangan.Text) = "" Then
            MsgBox("Kode, Nama, Jumlah, dan Keterangan Tidak boleh kosong!")
            Exit Sub
        End If

        Dim kodebarang As String = TextKode.Text
        Dim nmb As String = TextNama.Text
        Dim jmlh As String = TextJumlah.Text
        Dim ktr As String = TextKeterangan.Text
        Try
            Dim rs As Integer = Me.Tbl_barangTableAdapter.Qsimpan(kodebarang, nmb, jmlh, ktr)
            If rs <> 0 Then
                MsgBox("Data tersimpan")
                Call tampildata()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContextMenuStripChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContextMenuStripChanged
       
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim kodee As String = TextKode.Text
        Dim nm As String = TextNama.Text
        Dim jumlahh As String = TextJumlah.Text
        Dim keterangann As String = TextKeterangan.Text

        Try
            Dim rs As Integer = Me.Tbl_barangTableAdapter.Qedit(nm, jumlahh, keterangann, kodee)
            If rs <> 0 Then
                MsgBox("Data telah terupdated")
                Call tampildata()
            Else
                MsgBox("Data tidak terupdated")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        Dim kodee As String = TextKode.Text

        Try
            Dim rs As Integer = Me.Tbl_barangTableAdapter.Qdelete(kodee)
            If rs <> 0 Then
                MsgBox("Data Berhasil di Hapus!")
                Call tampildata()
            Else
                MsgBox("Data Tidak Terhapus!")

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        Call cleartext()
        Call textfalse()
    End Sub
End Class
