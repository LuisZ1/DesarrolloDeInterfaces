Imports _01_HelloWorld_WindowsForm_cSharp

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre As String
        nombre = Me.TextBox1.Text

        Dim apellidos As String
        apellidos = Me.TextBox2.Text

        'MessageBox.Show("Hola " + nombre)'

        Dim persona1 As New _01_HelloWorld_WindowsForms_cSharp.clsPersona(nombre, apellidos)

        'persona1.nombre(nombre)'

        MessageBox.Show("Hola " + persona1.nombre + " " + persona1.apellidos)

    End Sub

End Class
