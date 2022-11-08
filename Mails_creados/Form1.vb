Imports System.Data.SqlClient
Public Class Form1

    Dim bd As New SqlConnection("Data Source=+++;Initial Catalog=+++;User ID=sa;Password=+++")
    Dim dv As New DataView

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenamos el DataGridView
        cargaDGV()


    End Sub

    'creamos un método para cargar el DataGridView
    Private Sub cargaDGV()
        Dim dt As New DataSet
        'Dim at As New SqlDataAdapter("Select docente, apellido, nombre, tipo_doc, documento, foto, fechaIngreso  from Docente", bd)
        Dim at As New SqlDataAdapter("Select alumno_id as Matrícula, email as correo_electrónico, Combo as Apellido_y_nombre, NroDocPadre as DNI from AL_ALUMNOS_EMAIL as mail inner join VE_FAMILIAS as fam on mail.alumno_id=fam.Familia_ID order by alumno_id", bd)
        at.Fill(dt)
        dv.Table = dt.Tables(0)
        DataGridView1.DataSource = dv

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'creamos la búsqueda DataGridView
        'dv.RowFilter = String.Format("email like '%{0}%' ", TextBox1.Text)

        dv.RowFilter = String.Format("CONVERT(Matrícula, System.String) LIKE '%{0}%'", TextBox1.Text)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        'creamos la búsqueda DataGridView
        dv.RowFilter = String.Format("Apellido_y_nombre like '%{0}%' ", TextBox2.Text)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargaDGV()
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub
End Class
