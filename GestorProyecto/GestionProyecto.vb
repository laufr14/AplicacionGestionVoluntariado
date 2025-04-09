Imports System.Data.SqlClient
Imports Entidades

Public Class GestionProyecto
    Private servidor As String = "DESKTOP-EAOLBSJ"
    Private cadenaConexion As String = $"Data Source = {servidor}; Initial Catalog = DATABASEVOLUNTARIADO; Integrated Security = SSPI; MultipleActiveResultSets=true"

    Public Function TodosProyectos() As List(Of Proyecto)
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()

        Dim consultaSQL As String = "Select proyectos.* from proyectos"
        Dim cmdProyectos As New SqlCommand(consultaSQL, conexion)
        Dim drProyectos As SqlDataReader = cmdProyectos.ExecuteReader
        Dim proyectos As New List(Of Proyecto)
        While drProyectos.Read
            'If drProyectos("fecha_fin") Is Nothing Then
            '    proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), drProyectos("estado"), drProyectos("idorganizacion")))
            'Else
            proyectos.Add(New Proyecto(drProyectos("idproyecto"), drProyectos("nombre_proyecto"), drProyectos("descripcion"), drProyectos("fecha_inicio"), drProyectos("fecha_fin"), drProyectos("estado"), drProyectos("idorganizacion")))
            'End If
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
            actividades.Add(New Actividad(drActividades("idproyecto"), drActividades("idactividad"), drActividades("nombre"), drActividades("descripcion"), drActividades("fecha_inicio"), drActividades("fecha_fin"), drActividades("ubicacion")))
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
        Dim consultaSQL As String = "Insert into ACTIVIDADES values (" & idProyecto & ", " & idActividad & ", '" & nombre & "','" & descripcion & "','" & ubicacion & "','" & fechaInicio.Year & "-" & fechaInicio.Day & "-" & fechaInicio.Month & "', '" & fecha_fin.Year & "-" & fecha_fin.Day & "-" & fecha_fin.Month & "')"
        Dim cmd As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas = cmd.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function

    Public Function NuevaActividad(idProyecto As Integer, idActividad As Integer, nombre As String, descripcion As String, ubicacion As String, fechaInicio As Date) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim consultaSQL As String = "Insert into ACTIVIDADES values (" & idProyecto & ", " & idActividad & ", '" & nombre & "','" & descripcion & "','" & ubicacion & "','" & fechaInicio.Year & "-" & fechaInicio.Day & "-" & fechaInicio.Month & "')"
        Dim cmd As New SqlCommand(consultaSQL, conexion)
        Dim filasAfectadas = cmd.ExecuteNonQuery()
        conexion.Close()
        Return filasAfectadas > 0
    End Function


    Public Function AñadirODSAProyecto(idProyecto As String, listaOds As List(Of Integer)) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        conexion.Open()
        Dim filasAfectadas As Integer = 0
        For Each idODS As Integer In listaOds
            Dim consultaSQL As String = "Insert into Proyecto_ODS (idproyecto, idods) values ('" & idProyecto & "', '" & idODS & "')"
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
              INNER JOIN PROYECTOS ON PROYECTOS.IDPROYECTO = PROYECTO_ODS.IDPROYECTO 
              WHERE PROYECTOS.IDPROYECTO = {idProyecto}"
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
            Dim consultaSQL As String = "Delete from Proyecto_ODS where idproyecto='" & idProyecto & "' and idods='" & idODS & "'"
            Dim cmdDescripcion As New SqlCommand(consultaSQL, conexion)
            filasAfectadas = cmdDescripcion.ExecuteNonQuery()
        Next
        conexion.Close()
        Return filasAfectadas > 0
    End Function

End Class
