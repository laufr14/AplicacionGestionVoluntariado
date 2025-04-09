Public Class Proyecto
    Implements IEquatable(Of Proyecto)

    Public Property IDProyecto As String
    Public Property Nombre_Proyecto As String
    Public Property Descripcion As String
    Public Property Fecha_Inicio As Date
    Public Property Fecha_Fin As Date
    Public Property Estado As String
    Public Property IDOrganizacion As String

    Public Sub New()
    End Sub
    Public Sub New(id As String, nombre As String, descripcion As String, fechaInicio As Date, estado As String, organizacion As String)
        Me.IDProyecto = id
        Me.Nombre_Proyecto = nombre
        Me.Descripcion = descripcion
        Me.Fecha_Inicio = fechaInicio
        Me.Estado = estado
        Me.IDOrganizacion = organizacion
    End Sub
    Public Sub New(id As String, nombre As String, descripcion As String, fechaInicio As Date, fechaFin As Date, estado As String, organizacion As String)
        Me.IDProyecto = id
        Me.Nombre_Proyecto = nombre
        Me.Descripcion = descripcion
        Me.Fecha_Inicio = fechaInicio
        Me.Fecha_Fin = fechaFin
        Me.Estado = estado
        Me.IDOrganizacion = organizacion
    End Sub

    Public Overrides Function ToString() As String
        Return Nombre_Proyecto
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Proyecto))
    End Function

    Public Overloads Function Equals(other As Proyecto) As Boolean Implements IEquatable(Of Proyecto).Equals
        Return other IsNot Nothing AndAlso
               IDProyecto.ToLower = other.IDProyecto.ToLower
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hashCode As Long = -842410301
        hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(IDProyecto)).GetHashCode()
        Return hashCode
    End Function
End Class
