Public Class Actividad
    Implements IEquatable(Of Actividad)

    Public Property IDProyecto As String
    Public Property IDActividad As String
    Public Property Nombre As String
    Public Property Descripcion As String
    Public Property Fecha_Inicio As Date
    Public Property Fecha_Fin As Date
    Public Property Ubicacion As String

    Public Sub New()
    End Sub
    Public Sub New(iDProyecto As String, iDActividad As String, nombre As String, descripcion As String, fecha_Inicio As Date, ubicacion As String)
        Me.IDProyecto = iDProyecto
        Me.IDActividad = iDActividad
        Me.Nombre = nombre
        Me.Descripcion = descripcion
        Me.Fecha_Inicio = fecha_Inicio
        Me.Fecha_Fin = Fecha_Fin
        Me.Ubicacion = ubicacion
    End Sub

    Public Sub New(iDProyecto As String, iDActividad As String, nombre As String, descripcion As String, fecha_Inicio As Date, fecha_Fin As Date, ubicacion As String)
        Me.IDProyecto = iDProyecto
        Me.IDActividad = iDActividad
        Me.Nombre = nombre
        Me.Descripcion = descripcion
        Me.Fecha_Inicio = fecha_Inicio
        Me.Fecha_Fin = fecha_Fin
        Me.Ubicacion = ubicacion
    End Sub
    Public Overrides Function ToString() As String
        Return Nombre
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Actividad))
    End Function

    Public Overloads Function Equals(other As Actividad) As Boolean Implements IEquatable(Of Actividad).Equals
        Return other IsNot Nothing AndAlso
               IDProyecto = other.IDProyecto AndAlso
               IDActividad = other.IDActividad
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (IDProyecto, IDActividad).GetHashCode()
    End Function
End Class
