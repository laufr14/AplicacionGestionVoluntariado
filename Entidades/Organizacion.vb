Public Class Organizacion
    Implements IEquatable(Of Organizacion)

    Public Property IDOrganizacion As String
    Public Property CIF As String
    Public Property Nombre As String
    Public Property Direccion As String
    Public Property Correo As String
    Public Property Telefono As Integer

    Public Sub New()
    End Sub
    Public Sub New(CIF As String, nombre As String, direccion As String, telefono As String, correo As String)
        Me.CIF = CIF
        Me.Nombre = nombre
        Me.Direccion = direccion
        Me.Telefono = telefono
        Me.Correo = correo
    End Sub
    Public Sub New(idorganizacion As String, CIF As String, nombre As String, direccion As String, telefono As String, correo As String)
        Me.IDOrganizacion = idorganizacion
        Me.CIF = CIF
        Me.Nombre = nombre
        Me.Direccion = direccion
        Me.Telefono = telefono
        Me.Correo = correo
    End Sub

    Public Overrides Function ToString() As String
        Return Nombre & ", " & Direccion
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Organizacion))
    End Function

    Public Overloads Function Equals(other As Organizacion) As Boolean Implements IEquatable(Of Organizacion).Equals
        Return other IsNot Nothing AndAlso
               IDOrganizacion = other.IDOrganizacion AndAlso
               CIF = other.CIF
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (IDOrganizacion, CIF).GetHashCode()
    End Function
End Class
