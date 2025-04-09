Public Class ODS
    Implements IEquatable(Of ODS)

    Public Property IDODS As Integer
    Public Property Nombre As String
    Public Property Descripcion As String

    ' Constructor vacío
    Public Sub New()
    End Sub

    ' Constructor con parámetros
    Public Sub New(ID_ODS As Integer, NombreODS As String, DescripcionODS As String)
        Me.IDODS = ID_ODS
        Me.Nombre = NombreODS
        Me.Descripcion = DescripcionODS
    End Sub

    ' Equals para comparar
    Public Overrides Function Equals(obj As Object) As Boolean
        Dim other As ODS = TryCast(obj, ODS)
        Return other IsNot Nothing AndAlso Equals(other)
    End Function

    ' Equals 
    Public Overloads Function Equals(other As ODS) As Boolean Implements IEquatable(Of ODS).Equals
        Return other IsNot Nothing AndAlso
           IDODS = other.IDODS AndAlso
           String.Equals(Nombre, other.Nombre, StringComparison.OrdinalIgnoreCase)
    End Function

    ' Método ToString 
    Public Overrides Function ToString() As String
        Return IDODS & ": " & Nombre
    End Function
End Class
