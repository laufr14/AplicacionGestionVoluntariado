Imports System.Data.SqlClient
Imports System.IO
Imports Entidades


Public Class GestionProyecto
    Private servidor As String
    Private cadenaConexion As String

    Public Function CargarFichero() As Boolean
        If Not File.Exists("servidor.txt") Then Return False
        Dim leerFichero() As String = File.ReadAllLines("servidor.txt")
        servidor = leerFichero(0)
        cadenaConexion = $"Data Source = {servidor}; Initial Catalog = DATABASEVOLUNTARIADO; Integrated Security = SSPI; MultipleActiveResultSets=true"
        Return True
    End Function
    Public Function CargarDatabase() As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        Try
            conexion.Open()
        Catch ex As Exception
            Return False
        End Try
        conexion.Close()
        Return True
    End Function

    Public Function TodosProyectos() As List(Of Proyecto)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = "Select proyectos.* from proyectos"
        Dim cmdProyectos As New SqlCommand(consultaSQL, conexion)
        Dim drProyectos As SqlDataReader = cmdProyectos.ExecuteReader
        Dim proyectos As New List(Of Proyecto)
        Dim estado As String = ""
        While drProyectos.Read
            If drProyectos("estado") = "TRUE" Then
                estado = "ACTIVO"
            Else
                If drProyectos("fecha_inicio") > Now() Then estado = "PENDIENTE"
                If drProyectos("fecha_inicio") < Now() Then estado = "TERMINADO"
            End If
            If IsDBNull(drProyectos("fecha_fin")) Then
                proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), estado, drProyectos("idorganizacion")))
            Else
                proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), drProyectos("fecha_fin"), estado, drProyectos("idorganizacion")))
            End If
        End While
        conexion.Close()
        Return proyectos
    End Function

    Public Function TodasOrganizaciones() As List(Of Organizacion)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = "Select organizaciones.* from organizaciones"
        Dim cmdOrganizaciones As New SqlCommand(consultaSQL, conexion)
        Dim drOrganizaciones As SqlDataReader = cmdOrganizaciones.ExecuteReader
        Dim organizaciones As New List(Of Organizacion)
        While drOrganizaciones.Read
            organizaciones.Add(New Organizacion(drOrganizaciones("idorganizacion"), drOrganizaciones("cif"), drOrganizaciones("nombre"), drOrganizaciones("direccion"), drOrganizaciones("telefono"), drOrganizaciones("correo")))
        End While
        conexion.Close()
        Return organizaciones
    End Function

    Public Function TodosAlumnos() As List(Of Alumno)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = "Select alumnado_inscrito.* from alumnado_inscrito"
        Dim cmdAlumnos As New SqlCommand(consultaSQL, conexion)
        Dim drAlumnos As SqlDataReader = cmdAlumnos.ExecuteReader
        Dim alumnos As New List(Of Alumno)
        While drAlumnos.Read
            alumnos.Add(New Alumno(drAlumnos("dni"), drAlumnos("nombre"), drAlumnos("primer_apellido"), drAlumnos("segundo_apellido"), drAlumnos("correo_electronico"), drAlumnos("telefono"), drAlumnos("fecha_nacimiento"), drAlumnos("nombre_curso")))
        End While
        conexion.Close()
        Return alumnos
    End Function

    'NO SE UTILIZA
    Public Function InformacionProyecto(nombre As String) As List(Of Proyecto)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = "Select proyectos.* from proyectos where proyectos.nombre_proyecto='" & nombre & "'"
        Dim cmdProyecto As New SqlCommand(consultaSQL, conexion)
        Dim drProyecto As SqlDataReader = cmdProyecto.ExecuteReader
        Dim resultado As New List(Of Proyecto)

        While drProyecto.Read
            resultado.Add(New Proyecto(drProyecto("idproyecto"), drProyecto("nombre_proyecto"), drProyecto("descripcion"), drProyecto("fecha_inicio"), drProyecto("fecha_fin"), drProyecto("estado")))
        End While
        conexion.Close()
        Return resultado
    End Function

    Public Function ModificarDescripcionProyecto(nuevaDescripcion As String, idProyecto As String) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = "Update proyectos set descripcion='" & nuevaDescripcion & "' where idProyecto=" & idProyecto
        Dim cmdDescripcion As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas As Integer = cmdDescripcion.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function ActividadPorProyecto(idProyecto As String) As List(Of Actividad)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "Select actividades.* FROM actividades WHERE actividades.idproyecto=" & idProyecto
        Dim cmdActividades As New SqlCommand(consultaSQL, conexion)
        Dim drActividades As SqlDataReader = cmdActividades.ExecuteReader
        Dim actividades As New List(Of Actividad)

        While drActividades.Read
            If IsDBNull(drActividades("fecha_inicio")) Then
                actividades.Add(New Actividad(drActividades("idproyecto"), drActividades("idactividad"), drActividades("nombre"), drActividades("descripcion"), drActividades("fecha_inicio"), drActividades("ubicacion")))
            Else
                actividades.Add(New Actividad(drActividades("idproyecto"), drActividades("idactividad"), drActividades("nombre"), drActividades("descripcion"), drActividades("fecha_inicio"), drActividades("fecha_fin"), drActividades("ubicacion")))
            End If
        End While
        conexion.Close()
        Return actividades
    End Function

    Public Function AlumnoPorActividad(idActividad As String, idProyecto As String) As List(Of String)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = $"Select ALUMNO_ACTIVIDAD.* FROM ALUMNO_ACTIVIDAD WHERE ALUMNO_ACTIVIDAD.IDACTIVIDAD={idActividad} AND ALUMNO_ACTIVIDAD.IDPROYECTO={idProyecto}"
        Dim cmdAlumnos As New SqlCommand(consultaSQL, conexion)
        Dim drDNI As SqlDataReader = cmdAlumnos.ExecuteReader
        Dim dnis As New List(Of String)
        While drDNI.Read
            dnis.Add(drDNI("DNI"))
        End While
        conexion.Close()
        Return dnis
    End Function
    Public Function AñadirAlumnoActividad(dniAlumno As String, idProyecto As String, idActividad As String) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "Insert into alumno_actividad values ('" & dniAlumno & "', " & idProyecto & ", " & idActividad & ")"
        Dim cmdAlumno As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas = cmdAlumno.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function NuevoProyecto(idProyecto As String, nombre As String, descripcion As String, fechaInicio As Date, fechaFin As Date, estado As String, idOrganizacion As String) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "Insert into Proyectos values (" & idProyecto & ", '" & nombre & "', '" & descripcion & "', '" & fechaInicio.Year & "-" & fechaInicio.Day & "-" & fechaInicio.Month & "', '" & fechaFin.Year & "-" & fechaFin.Day & "-" & fechaFin.Month & "', '" & estado & "', " & idOrganizacion & ")"
        Dim cmdDescripcion As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas = cmdDescripcion.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function NuevoProyecto(idProyecto As String, nombre As String, descripcion As String, fechaInicio As Date, estado As String, idOrganizacion As String) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "Insert into Proyectos values (" & idProyecto & ", '" & nombre & "', '" & descripcion & "', '" & fechaInicio.Year & "-" & fechaInicio.Day & "-" & fechaInicio.Month & "', NULL, '" & estado & "', " & idOrganizacion & ")"
        Dim cmd As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas = cmd.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function NuevaActividad(idProyecto As Integer, idActividad As Integer, nombre As String, descripcion As String, ubicacion As String, fechaInicio As Date, fecha_fin As Date) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "EXEC AñadirActividad " & idProyecto & ", " & idActividad & ", '" & nombre & "','" & descripcion & "','" & ubicacion & "','" & fechaInicio.Year & "-" & fechaInicio.Day & "-" & fechaInicio.Month & "', '" & fecha_fin.Year & "-" & fecha_fin.Day & "-" & fecha_fin.Month & "'"
        Dim cmd As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas = cmd.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function NuevaActividad(idProyecto As Integer, idActividad As Integer, nombre As String, descripcion As String, ubicacion As String, fechaInicio As Date) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "Insert into ACTIVIDADES (idproyecto, idactividad, nombre, descripcion, ubicacion, fecha_inicio) values (" & idProyecto & ", " & idActividad & ", '" & nombre & "','" & descripcion & "','" & ubicacion & "','" & fechaInicio.Year & "-" & fechaInicio.Day & "-" & fechaInicio.Month & "')"
        Dim cmd As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas = cmd.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function


    Public Function AñadirODSAProyecto(idProyecto As String, listaOds As List(Of Integer)) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim filasAfectadas As Integer = 0
        Dim consultaSelectSQL As String = $"SELECT PROYECTO_ODS.IDODS FROM PROYECTO_ODS WHERE IDPROYECTO={idProyecto}"
        Dim cmdSelect As New SqlCommand(consultaSelectSQL, conexion)
        Dim drSelect As SqlDataReader = cmdSelect.ExecuteReader
        Dim listaOdsExistentes As New List(Of Integer)
        While drSelect.Read
            listaOdsExistentes.Add(drSelect("idods"))
        End While
        For Each ODS As Integer In listaOdsExistentes
            If listaOds.Contains(ODS) Then
                listaOds.Remove(ODS)

            End If
        Next

        For Each idODS As Integer In listaOds
            Dim consultaSQL As String = "Insert into Proyecto_ODS values ('" & idProyecto & "', '" & idODS & "')"
            Dim cmdDescripcion As New SqlCommand(consultaSQL, conexion)
            filasAfectadas = cmdDescripcion.ExecuteNonQuery()
        Next
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function ListODS() As List(Of ODS)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "Select * from ODS"
        Dim cmdProyectos As New SqlCommand(consultaSQL, conexion)
        Dim drProyectos As SqlDataReader = cmdProyectos.ExecuteReader
        Dim ods As New List(Of ODS)
        While drProyectos.Read
            ods.Add(New ODS(drProyectos("idods"), drProyectos("nombre"), drProyectos("descripcion")))
        End While
        conexion.Close()
        Return ods
    End Function

    Public Function BuscarODSPorProyecto(idProyecto As String) As List(Of ODS)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = $"SELECT ODS.*
              FROM ODS INNER JOIN PROYECTO_ODS ON ODS.IDODS = PROYECTO_ODS.IDODS
              WHERE PROYECTO_ODS.IDPROYECTO = {idProyecto}"
        Dim cmdProyectos As New SqlCommand(consultaSQL, conexion)
        Dim drProyectos As SqlDataReader = cmdProyectos.ExecuteReader
        Dim ods As New List(Of ODS)
        While drProyectos.Read
            ods.Add(New ODS(drProyectos("idods"), drProyectos("nombre"), drProyectos("descripcion")))
        End While
        conexion.Close()
        Return ods
    End Function

    Public Function BorrarODSAProyecto(idProyecto As String, listaOds As List(Of Integer)) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim filasAfectadas As Integer = 0
        For Each idODS As Integer In listaOds
            Dim consultaSQL As String = "Delete Proyecto_ODS where idproyecto=" & idProyecto & " and idods=" & idODS
            Dim cmdDescripcion As New SqlCommand(consultaSQL, conexion)
            filasAfectadas = cmdDescripcion.ExecuteNonQuery()
        Next
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function EliminarActividad(idproyecto As Integer, idactividad As Integer) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = $"DELETE ALUMNO_ACTIVIDAD WHERE ALUMNO_ACTIVIDAD.IDPROYECTO={idproyecto} AND ALUMNO_ACTIVIDAD.IDACTIVIDAD={idactividad}"
        Dim consultaSQL2 As String = $"DELETE ACTIVIDADES WHERE ACTIVIDADES.IDPROYECTO={idproyecto} AND ACTIVIDADES.IDACTIVIDAD={idactividad}"
        Dim cmdDescripcion As New SqlCommand(consultaSQL, conexion)
        Dim cmdDescripcion2 As New SqlCommand(consultaSQL2, conexion)
        Dim filasAfectadas = cmdDescripcion.ExecuteNonQuery()
        Dim filasAfectadas2 = cmdDescripcion2.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas2 > 0
    End Function

    Public Function ProyectosPorAño(año As Integer) As List(Of Proyecto)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = "Select proyectos.* from proyectos where (YEAR(fecha_inicio) <=" & año & " AND YEAR(fecha_fin) >= " & año & ") or (YEAR(fecha_inicio) = " & año & " AND fecha_fin IS NULL)"

        Dim cmdProyectos As New SqlCommand(consultaSQL, conexion)
        Dim drProyectos As SqlDataReader = cmdProyectos.ExecuteReader
        Dim proyectos As New List(Of Proyecto)
        Dim estado As String = ""
        While drProyectos.Read
            If drProyectos("estado") = "TRUE" Then
                estado = "ACTIVO"
            Else
                If drProyectos("fecha_inicio") > Now() Then estado = "PENDIENTE"
                If drProyectos("fecha_inicio") < Now() Then estado = "TERMINADO"
            End If
            If IsDBNull(drProyectos("fecha_fin")) Then
                proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), estado, drProyectos("idorganizacion")))
            Else
                proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), drProyectos("fecha_fin"), estado, drProyectos("idorganizacion")))
            End If
        End While
        conexion.Close()
        Return proyectos
    End Function

    Public Function ProyectosPorODS(ods As ODS) As List(Of Proyecto)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = $"Select proyectos.* from proyectos inner join proyecto_ods on proyectos.idproyecto=proyecto_ods.idproyecto where proyecto_ods.idods={ods.IDODS}"

        Dim cmdProyectos As New SqlCommand(consultaSQL, conexion)
        Dim drProyectos As SqlDataReader = cmdProyectos.ExecuteReader
        Dim proyectos As New List(Of Proyecto)
        Dim estado As String = ""
        While drProyectos.Read
            If drProyectos("estado") = "TRUE" Then
                estado = "ACTIVO"
            Else
                If drProyectos("fecha_inicio") > Now() Then estado = "PENDIENTE"
                If drProyectos("fecha_inicio") < Now() Then estado = "TERMINADO"
            End If
            If IsDBNull(drProyectos("fecha_fin")) Then
                proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), estado, drProyectos("idorganizacion")))
            Else
                proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), drProyectos("fecha_fin"), estado, drProyectos("idorganizacion")))
            End If
        End While
        conexion.Close()
        Return proyectos
    End Function
End Class
