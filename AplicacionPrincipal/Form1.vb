Imports System.Data.Odbc
Imports Entidades
Imports GestorProyecto
Imports MisClases

Public Class Form1
    Dim gestion As New GestionProyecto
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboProyectosInfo.Items.AddRange(gestion.TodosProyectos().ToArray)
        cboProyectosModificarDescripcion.Items.AddRange(gestion.TodosProyectos().ToArray)
        cboProyectosAñadirAlumnoActividad.Items.AddRange(gestion.TodosProyectos().ToArray)
        cboProyectosCrearActividad.Items.AddRange(gestion.TodosProyectos().ToArray)
        cboProyectosAñadirODS.Items.AddRange(gestion.TodosProyectos().ToArray)
        cboProyectosEliminarODS.Items.AddRange(gestion.TodosProyectos().ToArray)
        cboOrganizaciones.Items.AddRange(gestion.TodasOrganizaciones().ToArray)
        cboAlumnos.Items.AddRange(gestion.TodosAlumnos().ToArray)
        lsbAñadirODS.Items.AddRange(gestion.ListODS().ToArray)
    End Sub

    Private Sub btnInfoProyectos_Click(sender As Object, e As EventArgs) Handles btnInfoProyectos.Click
        dgv.DataSource = gestion.TodosProyectos()
        lblInformacion.Text = "Información de todos los proyectos"
    End Sub

    Private Sub btnInfoProyectoSeleccionado_Click(sender As Object, e As EventArgs) Handles btnInfoProyectoSeleccionado.Click
        If cboProyectosInfo.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            Exit Sub
        End If
        Dim proySeleccionado As Proyecto = TryCast(cboProyectosInfo.SelectedItem, Proyecto)
        dgv.DataSource = gestion.ActividadPorProyecto(proySeleccionado.IDProyecto)
        lblInformacion.Text = "Actividades dentro del proyecto '" & proySeleccionado.Nombre_Proyecto & "'"
    End Sub

    Private Sub btnModificarDescripcion_Click(sender As Object, e As EventArgs) Handles btnModificarDescripcion.Click
        If String.IsNullOrEmpty(txtNuevaDescripcion.Text) Then
            MessageBox.Show("No se puede quedar la caja de texto para la nueva descripción vacía")
            Exit Sub
        ElseIf cboProyectosModificarDescripcion.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            Exit Sub
        End If
        Dim proySeleccionado As Proyecto = TryCast(cboProyectosModificarDescripcion.SelectedItem, Proyecto)
        If gestion.ModificarDescripcionProyecto(txtNuevaDescripcion.Text, proySeleccionado.IDProyecto) Then
            MessageBox.Show("Se ha modificado correctamente")
        Else
            MessageBox.Show("No se ha podido modificar")
        End If
    End Sub

    Private Sub cboProyectosAñadirAlumnoActividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProyectosAñadirAlumnoActividad.SelectedIndexChanged
        cboActividadesPorProyecto.Items.Clear()
        Dim proySeleccionado As Proyecto = TryCast(cboProyectosAñadirAlumnoActividad.SelectedItem, Proyecto)
        cboActividadesPorProyecto.Items.AddRange(gestion.ActividadPorProyecto(proySeleccionado.IDProyecto).ToArray)
    End Sub
    Private Sub btnAñadirAlumnoActividad_Click(sender As Object, e As EventArgs) Handles btnAñadirAlumnoActividad.Click
        If cboAlumnos.SelectedItem Is Nothing OrElse cboProyectosAñadirAlumnoActividad.SelectedItem Is Nothing OrElse cboActividadesPorProyecto.SelectedItem Is Nothing Then
            MessageBox.Show("Hay algún campo vacío")
            Exit Sub
        End If
        Dim alumnoSeleccionado As Alumno = TryCast(cboAlumnos.SelectedItem, Alumno)
        Dim actSeleccionado As Actividad = TryCast(cboActividadesPorProyecto.SelectedItem, Actividad)

        Dim dnis As List(Of String) = gestion.AlumnoPorActividad(actSeleccionado.IDActividad, actSeleccionado.IDProyecto)
        Dim alumnos As New List(Of Alumno)

        For Each dni In dnis
            Dim alumno As New Alumno(dni)
            alumnos.Add(alumno)
        Next

        If alumnos.Contains(alumnoSeleccionado) Then
            MessageBox.Show("El alumno ya estaba inscrito en la actividad")
            Exit Sub
        End If

        If gestion.AñadirAlumnoActividad(alumnoSeleccionado.DNI, actSeleccionado.IDProyecto, actSeleccionado.IDActividad) Then
            MessageBox.Show("Se ha añadido correctamente")
        Else
            MessageBox.Show("No se ha podido añadir")
        End If
    End Sub

    Private Sub btnNuevoProyecto_Click(sender As Object, e As EventArgs) Handles btnNuevoProyecto.Click
        If String.IsNullOrEmpty(txtNombreProyecto.Text) OrElse String.IsNullOrEmpty(txtDescripcionProyecto.Text) OrElse String.IsNullOrEmpty(dtFechaInicioProyecto.Text) OrElse cboOrganizaciones.SelectedItem Is Nothing Then
            MessageBox.Show("Falta algún dato necesario")
            Exit Sub
        ElseIf txtNombreProyecto.Text.Length > 25 Then
            MessageBox.Show("El nombre es demasiado largo, máximo de 25 caracteres")
            Exit Sub
        ElseIf txtDescripcionProyecto.Text.Length > 255 Then
            MessageBox.Show("Descripción demasiado larga, máximo de 255 caracteres")
            Exit Sub
        End If

        Dim nuevoId As Integer = 1
        For Each p In gestion.TodosProyectos()
            nuevoId = 1
            nuevoId += p.IDProyecto
        Next

        Dim orgSeleccionada As Organizacion = TryCast(cboOrganizaciones.SelectedItem, Organizacion)

        Dim fechaInicio As Date = dtFechaInicioProyecto.Text
        Dim estado As String = ""

        If fechaInicio > Now Then estado = "FALSE"
        If fechaInicio < Now Then estado = "TRUE"

        If dtFechaFinProyecto.Checked Then
            Dim fechaFin As Date = dtFechaFinProyecto.Text
            If fechaFin < fechaInicio Then
                MessageBox.Show("La fecha fin no puede ser anterior a la fecha inicio")
                Exit Sub
            End If
            If fechaFin < Now() Then estado = "FALSE"

            If gestion.NuevoProyecto(nuevoId, txtNombreProyecto.Text, txtDescripcionProyecto.Text, fechaInicio, fechaFin, estado, orgSeleccionada.IDOrganizacion) Then
                MessageBox.Show("Se ha creado correctamente")
            Else
                MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
            End If
            Exit Sub
        End If

        If gestion.NuevoProyecto(nuevoId, txtNombreProyecto.Text, txtDescripcionProyecto.Text, fechaInicio, estado, orgSeleccionada.IDOrganizacion) Then
            MessageBox.Show("Se ha creado correctamente")
        Else
            MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
        End If
    End Sub

    Private Sub btnNuevaActividad_Click(sender As Object, e As EventArgs) Handles btnNuevaActividad.Click
        If String.IsNullOrEmpty(txtNombreNuevaActividad.Text) OrElse String.IsNullOrEmpty(txtDescripcionActividad.Text) OrElse
            String.IsNullOrEmpty(txtUbicacion.Text) OrElse String.IsNullOrEmpty(dtFechaInicioActividad.Text) OrElse cboProyectosCrearActividad.SelectedItem Is Nothing Then
            MessageBox.Show("Falta algún dato necesario")
            Exit Sub
        ElseIf txtNombreNuevaActividad.Text.Length > 25 Then
            MessageBox.Show("Nombre demadiado largo, máximo de 25 caracteres")
            Exit Sub
        ElseIf txtDescripcionActividad.Text.Length > 255 Then
            MessageBox.Show("Descripción demasiado larga, máximo de 255 caracteres")
            Exit Sub
        End If

        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosCrearActividad.SelectedItem, Proyecto)

        Dim nuevoId As Integer = 1
        For Each a In gestion.ActividadPorProyecto(proyectoSeleccionado.IDProyecto)
            nuevoId = 1
            nuevoId += a.IDActividad
        Next

        Dim fechainicio As Date = dtFechaInicioActividad.Text

        If dtFechaFinActividad.Checked Then

            Dim fechaFin As Date = dtFechaFinActividad.Text
            If fechaFin < fechainicio Then
                MessageBox.Show("La fecha fin no puede ser anterior a la fecha inicio")
                Exit Sub
            ElseIf proyectoSeleccionado.Fecha_Inicio > fechainicio OrElse proyectoSeleccionado.Fecha_Fin < fechaFin Then
                MessageBox.Show("La fechas de las actividades deben estar dentro de los margenes del proyecto")
                Exit Sub
            End If
            If gestion.NuevaActividad(proyectoSeleccionado.IDProyecto, nuevoId, txtNombreNuevaActividad.Text, txtDescripcionActividad.Text, txtUbicacion.Text, fechainicio, fechaFin) Then
                MessageBox.Show("Se ha creado correctamente")
            Else
                MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
            End If
            Exit Sub
        End If
        If gestion.NuevaActividad(proyectoSeleccionado.IDProyecto, nuevoId, txtNombreNuevaActividad.Text, txtDescripcionActividad.Text, txtUbicacion.Text, fechainicio) Then
            MessageBox.Show("Se ha creado correctamente")
        Else
            MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
        End If
    End Sub

    Private Sub btnAñadirODSProyecto_Click(sender As Object, e As EventArgs) Handles btnAñadirODSProyecto.Click
        Dim a As ListBox.SelectedObjectCollection = lsbAñadirODS.SelectedItems
        Dim lista As New List(Of ODS)
        For i = 0 To a.Count - 1
            lista.Add(a(i))
        Next
        Dim listaInt As New List(Of Integer)
        For Each item As ODS In lista
            listaInt.Add(item.IDODS)
        Next
        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosAñadirODS.SelectedItem, Proyecto)


        gestion.AñadirODSAProyecto(proyectoSeleccionado.IDProyecto, listaInt)
        lsbAñadirODS.Refresh()
        cboProyectosAñadirODS.Text = ""
        lsbAñadirODS.Items.Clear()
        lsbAñadirODS.Items.AddRange(gestion.ListODS().ToArray)
    End Sub

    Private Sub btnBuscarODSProyecto_Click(sender As Object, e As EventArgs) Handles btnBuscarODSProyecto.Click
        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosEliminarODS.SelectedItem, Proyecto)
        lsbEliminarODS.Items.Clear()
        lsbEliminarODS.Items.AddRange(gestion.BuscarODSPorProyecto(proyectoSeleccionado.IDProyecto).ToArray)

    End Sub

    Private Sub btnEliminarODSProyecto_Click(sender As Object, e As EventArgs) Handles btnEliminarODSProyecto.Click
        Dim a As ListBox.SelectedObjectCollection = lsbEliminarODS.SelectedItems
        Dim lista As List(Of ODS) = New List(Of ODS)
        For i = 0 To a.Count - 1
            lista.Add(a(i))
        Next
        Dim listaInt As List(Of Integer) = New List(Of Integer)
        For Each item As ODS In lista
            listaInt.Add(item.IDODS)
        Next
        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosEliminarODS.SelectedItem, Proyecto)
        gestion.BorrarODSAProyecto(proyectoSeleccionado.IDProyecto, listaInt)
        MessageBox.Show($"Se han eliminado los ODS seleccionados del proyecto  {proyectoSeleccionado.Nombre_Proyecto}")
        lsbEliminarODS.Items.Clear()
        lsbEliminarODS.Items.AddRange(gestion.BuscarODSPorProyecto(proyectoSeleccionado.IDProyecto).ToArray)
    End Sub


End Class
