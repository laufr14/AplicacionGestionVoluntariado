Public Class Alumno
    Implements IEquatable(Of Alumno)

    Public Property DNI As String
    Public Property Nombre As String
    Public Property Primer_Apellido As String
    Public Property Segundo_Apellido As String
    Public Property Correo_Electronico As String
    Public Property Telefono As Integer
    Public Property Fecha_Nacimiento As Date
    Public Property Nombre_Curso As String

    Public Sub New()
    End Sub
    Public Sub New(dni As String)
        Me.DNI = dni
    End Sub
    Public Sub New(dni As String, nombre As String, apellido1 As String, apellido2 As String, correoElectronico As String, telefono As Integer, fechaNacimiento As Date, curso As String)
        Me.DNI = dni
        Me.Nombre = nombre
        Me.Primer_Apellido = apellido1
        Me.Segundo_Apellido = apellido2
        Me.Correo_Electronico = correoElectronico
        Me.Telefono = telefono
        Me.Fecha_Nacimiento = fechaNacimiento
        Me.Nombre_Curso = curso
    End Sub

    Public Overrides Function ToString() As String
        Return NombreCompleto & ", " & DNI
    End Function

    Public ReadOnly Property NombreCompleto As String
        Get
            If String.IsNullOrEmpty(Nombre) AndAlso String.IsNullOrEmpty(Primer_Apellido) AndAlso String.IsNullOrEmpty(Segundo_Apellido) Then Return ""
            If String.IsNullOrEmpty(Primer_Apellido) AndAlso String.IsNullOrEmpty(Segundo_Apellido) Then Return Nombre
            If String.IsNullOrEmpty(Segundo_Apellido) Then Return _Primer_Apellido & ", " & Nombre
            Return _Primer_Apellido & " " & _Segundo_Apellido & ", " & Nombre
        End Get
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Alumno))
    End Function

    Public Overloads Function Equals(other As Alumno) As Boolean Implements IEquatable(Of Alumno).Equals
        Return other IsNot Nothing AndAlso
               DNI.ToLower = other.DNI.ToLower
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hashCode As Long = 1495294058
        hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(DNI)).GetHashCode()
        Return hashCode
    End Function
End Class
