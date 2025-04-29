Imports System.Data.Odbc
Imports System.Diagnostics.Contracts
Imports System.IO
Imports Entidades
Imports GestorProyecto
Imports MisClases
Public Class Form1
    Dim gestion As New GestionProyecto
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not gestion.CargarFichero() Then
            MessageBox.Show("Fallo en la lectura del fichero.txt")
            Close()
            Exit Sub
        End If
        actualizarCajas()
    End Sub

    Private Sub btnInfoProyectos_Click(sender As Object, e As EventArgs) Handles btnInfoProyectos.Click
        dgv.DataSource = Nothing
        dgv.DataSource = gestion.TodosProyectos()
        lblInformacion.Text = "Información de todos los proyectos"
    End Sub

    Private Sub btnInfoProyectoSeleccionado_Click(sender As Object, e As EventArgs) Handles btnInfoProyectoSeleccionado.Click
        dgv.DataSource = Nothing
        If cboProyectosInfo.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            limpiarTodo()
            Exit Sub
        End If
        Dim proySeleccionado As Proyecto = TryCast(cboProyectosInfo.SelectedItem, Proyecto)
        dgv.DataSource = gestion.ActividadPorProyecto(proySeleccionado.IDProyecto)
        lblInformacion.Text = "Actividades dentro del proyecto '" & proySeleccionado.Nombre_Proyecto & "'"
        actualizarCajas()
        limpiarTodo()
    End Sub

    Private Sub btnModificarDescripcion_Click(sender As Object, e As EventArgs) Handles btnModificarDescripcion.Click
        If String.IsNullOrEmpty(txtNuevaDescripcion.Text) Then
            MessageBox.Show("No se puede quedar la caja de texto para la nueva descripción vacía")
            limpiarTodo()
            Exit Sub
        ElseIf cboProyectosModificarDescripcion.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            limpiarTodo()
            Exit Sub
        End If
        Dim proySeleccionado As Proyecto = TryCast(cboProyectosModificarDescripcion.SelectedItem, Proyecto)
        If gestion.ModificarDescripcionProyecto(txtNuevaDescripcion.Text, proySeleccionado.IDProyecto) Then
            MessageBox.Show("Se ha modificado correctamente")
        Else
            MessageBox.Show("No se ha podido modificar")
        End If
        actualizarCajas()
        limpiarTodo()
    End Sub

    Private Sub cboProyectosAñadirAlumnoActividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProyectosAñadirAlumnoActividad.SelectedIndexChanged
        cboActividadesAñadirAlumno.Items.Clear()
        Dim proySeleccionado As Proyecto = TryCast(cboProyectosAñadirAlumnoActividad.SelectedItem, Proyecto)
        cboActividadesAñadirAlumno.Items.AddRange(gestion.ActividadPorProyecto(proySeleccionado.IDProyecto).ToArray)
    End Sub
    Private Sub btnAñadirAlumnoActividad_Click(sender As Object, e As EventArgs) Handles btnAñadirAlumnoActividad.Click
        If cboAlumnos.SelectedItem Is Nothing OrElse cboProyectosAñadirAlumnoActividad.SelectedItem Is Nothing OrElse cboActividadesAñadirAlumno.SelectedItem Is Nothing Then
            MessageBox.Show("Hay algún campo vacío")
            limpiarTodo()
            Exit Sub
        End If
        Dim alumnoSeleccionado As Alumno = TryCast(cboAlumnos.SelectedItem, Alumno)
        Dim actSeleccionado As Actividad = TryCast(cboActividadesAñadirAlumno.SelectedItem, Actividad)

        Dim dnis As List(Of String) = gestion.AlumnoPorActividad(actSeleccionado.IDActividad, actSeleccionado.IDProyecto)
        Dim alumnos As New List(Of Alumno)

        For Each dni In dnis
            Dim alumno As New Alumno(dni)
            alumnos.Add(alumno)
        Next

        If alumnos.Contains(alumnoSeleccionado) Then
            MessageBox.Show("El alumno ya estaba inscrito en la actividad")
            limpiarTodo()
            Exit Sub
        End If

        If gestion.AñadirAlumnoActividad(alumnoSeleccionado.DNI, actSeleccionado.IDProyecto, actSeleccionado.IDActividad) Then
            MessageBox.Show("Se ha añadido correctamente")
        Else
            MessageBox.Show("No se ha podido añadir")
        End If
        actualizarCajas()
        limpiarTodo()
    End Sub

    Private Sub btnNuevoProyecto_Click(sender As Object, e As EventArgs) Handles btnNuevoProyecto.Click
        If String.IsNullOrEmpty(txtNombreProyecto.Text) OrElse String.IsNullOrEmpty(txtDescripcionProyecto.Text) OrElse String.IsNullOrEmpty(dtFechaInicioProyecto.Text) OrElse cboOrganizaciones.SelectedItem Is Nothing Then
            MessageBox.Show("Falta algún dato necesario")
            limpiarTodo()
            Exit Sub
        ElseIf txtNombreProyecto.Text.Length > 25 Then
            MessageBox.Show("El nombre es demasiado largo, máximo de 25 caracteres")
            limpiarTodo()
            Exit Sub
        ElseIf txtDescripcionProyecto.Text.Length > 255 Then
            MessageBox.Show("Descripción demasiado larga, máximo de 255 caracteres")
            limpiarTodo()
            Exit Sub
        End If

        For Each p In gestion.TodosProyectos
            If p.Nombre_Proyecto.ToLower = txtNombreProyecto.Text.ToLower Then
                MessageBox.Show("Ya existe un proyecto con el mismo nombre")
                limpiarTodo()
                Exit Sub
            End If
        Next

        Dim nuevoId As Integer = 1
        For Each p In gestion.TodosProyectos()
            nuevoId = p.IDProyecto + 1
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
                limpiarTodo()
                Exit Sub
            End If
            If fechaFin < Now() Then estado = "FALSE"

            If gestion.NuevoProyecto(nuevoId, txtNombreProyecto.Text, txtDescripcionProyecto.Text, fechaInicio, fechaFin, estado, orgSeleccionada.IDOrganizacion) Then
                MessageBox.Show("Se ha creado correctamente")
            Else
                MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
            End If
            actualizarCajas()
            limpiarTodo()
            Exit Sub
        End If

        If gestion.NuevoProyecto(nuevoId, txtNombreProyecto.Text, txtDescripcionProyecto.Text, fechaInicio, estado, orgSeleccionada.IDOrganizacion) Then
            MessageBox.Show("Se ha creado correctamente")
        Else
            MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
        End If
        actualizarCajas()
        limpiarTodo()
    End Sub

    Private Sub btnNuevaActividad_Click(sender As Object, e As EventArgs) Handles btnNuevaActividad.Click
        If String.IsNullOrEmpty(txtNombreNuevaActividad.Text) OrElse String.IsNullOrEmpty(txtDescripcionActividad.Text) OrElse
            String.IsNullOrEmpty(txtUbicacion.Text) OrElse String.IsNullOrEmpty(dtFechaInicioActividad.Text) OrElse cboProyectosCrearActividad.SelectedItem Is Nothing Then
            MessageBox.Show("Falta algún dato necesario")
            limpiarTodo()
            Exit Sub
        ElseIf txtNombreNuevaActividad.Text.Length > 25 Then
            MessageBox.Show("Nombre demadiado largo, máximo de 25 caracteres")
            limpiarTodo()
            Exit Sub
        ElseIf txtDescripcionActividad.Text.Length > 255 Then
            MessageBox.Show("Descripción demasiado larga, máximo de 255 caracteres")
            limpiarTodo()
            Exit Sub
        End If

        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosCrearActividad.SelectedItem, Proyecto)

        Dim actividades As List(Of Actividad) = gestion.ActividadPorProyecto(proyectoSeleccionado.IDProyecto)

        For Each a In gestion.ActividadPorProyecto(proyectoSeleccionado.IDProyecto)
            If a.Nombre.ToLower = txtNombreNuevaActividad.Text.ToLower Then
                MessageBox.Show("Ya existe una actividad con el mismo nombre")
                limpiarTodo()
                Exit Sub
            End If
        Next

        Dim nuevoId As Integer = 1
        For Each a In gestion.ActividadPorProyecto(proyectoSeleccionado.IDProyecto)
            nuevoId = a.IDActividad + 1
        Next

        Dim fechainicio As Date = dtFechaInicioActividad.Text

        If fechainicio < proyectoSeleccionado.Fecha_Inicio Then
            MessageBox.Show("La actividad no puede empezar antes que el proyecto")
            limpiarTodo()
            Exit Sub
        End If

        If dtFechaFinActividad.Checked Then
            Dim fechaFin As Date = dtFechaFinActividad.Text
            If fechaFin < fechainicio Then
                MessageBox.Show("La fecha fin no puede ser anterior a la fecha inicio")
                Exit Sub
            ElseIf proyectoSeleccionado.Fecha_Fin < fechaFin AndAlso proyectoSeleccionado.Fecha_Fin <> Date.MinValue Then
                MessageBox.Show("La fechas de las actividades deben estar dentro de los margenes del proyecto")
                Exit Sub
            End If
            If gestion.NuevaActividad(proyectoSeleccionado.IDProyecto, nuevoId, txtNombreNuevaActividad.Text, txtDescripcionActividad.Text, txtUbicacion.Text, fechainicio, fechaFin) Then
                MessageBox.Show("Se ha creado correctamente")
            Else
                MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
            End If
            actualizarCajas()
            limpiarTodo()
            Exit Sub
        End If
        If gestion.NuevaActividad(proyectoSeleccionado.IDProyecto, nuevoId, txtNombreNuevaActividad.Text, txtDescripcionActividad.Text, txtUbicacion.Text, fechainicio) Then
            MessageBox.Show("Se ha creado correctamente")
        Else
            MessageBox.Show("Ha habido algún error creando el nuevo proyecto")
        End If
        actualizarCajas()
        limpiarTodo()
    End Sub

    Private Sub btnAñadirODSProyecto_Click(sender As Object, e As EventArgs) Handles btnAñadirODSProyecto.Click
        If cboProyectosAñadirODS.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            Exit Sub
        End If

        Dim a As ListBox.SelectedObjectCollection = lsbAñadirODS.SelectedItems

        If a.Count = 0 Then
            MessageBox.Show("No se ha seleccionado ninguna ODS")
            Exit Sub
        End If

        Dim lista As New List(Of ODS)
        For i = 0 To a.Count - 1
            lista.Add(a(i))
        Next
        Dim listaInt As New List(Of Integer)
        For Each item As ODS In lista
            listaInt.Add(item.IDODS)
        Next
        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosAñadirODS.SelectedItem, Proyecto)

        If gestion.AñadirODSAProyecto(proyectoSeleccionado.IDProyecto, listaInt) Then
            MessageBox.Show("Se ha añadido correctamente")
        Else
            MessageBox.Show("No se ha podido añadir nada")
            Exit Sub
        End If
    End Sub

    Private Sub btnBuscarODSProyecto_Click(sender As Object, e As EventArgs) Handles btnBuscarODSProyecto.Click
        If cboProyectosEliminarODS.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            limpiarTodo()
            Exit Sub
        End If
        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosEliminarODS.SelectedItem, Proyecto)
        lsbEliminarODS.Items.Clear()
        lsbEliminarODS.Items.AddRange(gestion.BuscarODSPorProyecto(proyectoSeleccionado.IDProyecto).ToArray)
        If gestion.BuscarODSPorProyecto(proyectoSeleccionado.IDProyecto).Count = 0 Then MessageBox.Show("No había ninguna ODS en este proyecto")
    End Sub

    Private Sub btnEliminarODSProyecto_Click(sender As Object, e As EventArgs) Handles btnEliminarODSProyecto.Click
        If cboProyectosEliminarODS.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            Exit Sub
        End If

        Dim a As ListBox.SelectedObjectCollection = lsbEliminarODS.SelectedItems

        If a.Count = 0 Then
            MessageBox.Show("No se ha seleccionado ninguna ODS")
            Exit Sub
        End If

        Dim lista As List(Of ODS) = New List(Of ODS)
        For i = 0 To a.Count - 1
            lista.Add(a(i))
        Next
        Dim listaInt As List(Of Integer) = New List(Of Integer)
        For Each item As ODS In lista
            listaInt.Add(item.IDODS)
        Next
        Dim proyectoSeleccionado As Proyecto = TryCast(cboProyectosEliminarODS.SelectedItem, Proyecto)
        If Not gestion.BorrarODSAProyecto(proyectoSeleccionado.IDProyecto, listaInt) Then
            MessageBox.Show("Algo ha salido mal")
            Exit Sub
        End If
        MessageBox.Show($"Se han eliminado los ODS seleccionados del proyecto {proyectoSeleccionado.Nombre_Proyecto}")
        lsbEliminarODS.Items.Clear()
        lsbEliminarODS.Items.AddRange(gestion.BuscarODSPorProyecto(proyectoSeleccionado.IDProyecto).ToArray)
    End Sub

    Private Sub cboProyectosEliminarAcividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProyectosEliminarAcividad.SelectedIndexChanged
        cboActividadesEliminar.Items.Clear()
        Dim proySeleccionado As Proyecto = TryCast(cboProyectosEliminarAcividad.SelectedItem, Proyecto)
        cboActividadesEliminar.Items.AddRange(gestion.ActividadPorProyecto(proySeleccionado.IDProyecto).ToArray)
    End Sub

    Private Sub btnEliminarActividad_Click(sender As Object, e As EventArgs) Handles btnEliminarActividad.Click
        If cboProyectosEliminarAcividad.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ningún proyecto")
            limpiarTodo()
            Exit Sub
        ElseIf cboActividadesEliminar.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado ninguna actividad")
            limpiarTodo()
            Exit Sub
        End If

        Dim actSeleccionada As Actividad = TryCast(cboActividadesEliminar.SelectedItem, Actividad)

        If gestion.EliminarActividad(actSeleccionada.IDProyecto, actSeleccionada.IDActividad) Then
            MessageBox.Show("Se ha eliminado la actividad correctamente")
        Else
            MessageBox.Show("No se ha podido eliminar la actividad")
        End If
        actualizarCajas()
        limpiarTodo()
    End Sub

    Private Sub actualizarCajas()
        cboProyectosInfo.Items.Clear()
        cboProyectosModificarDescripcion.Items.Clear()
        cboProyectosAñadirAlumnoActividad.Items.Clear()
        cboProyectosCrearActividad.Items.Clear()
        cboProyectosAñadirODS.Items.Clear()
        cboProyectosEliminarODS.Items.Clear()
        cboOrganizaciones.Items.Clear()
        cboAlumnos.Items.Clear()

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

    Private Sub limpiarTodo()
        txtNombreProyecto.Clear()
        txtDescripcionProyecto.Clear()
        txtNombreNuevaActividad.Clear()
        txtUbicacion.Clear()
        txtDescripcionActividad.Clear()
        txtNuevaDescripcion.Clear()

        lsbAñadirODS.Items.Clear()
        lsbEliminarODS.Items.Clear()

        cboOrganizaciones.SelectedIndex = -1
        cboProyectosAñadirODS.SelectedIndex = -1
        cboProyectosCrearActividad.SelectedIndex = -1
        cboProyectosEliminarODS.SelectedIndex = -1
        cboProyectosInfo.SelectedIndex = -1
        cboAlumnos.SelectedIndex = -1
        cboProyectosAñadirAlumnoActividad.SelectedIndex = -1
        cboActividadesAñadirAlumno.SelectedIndex = -1
        cboProyectosModificarDescripcion.SelectedIndex = -1
        cboProyectosEliminarAcividad.SelectedIndex = -1
        cboActividadesEliminar.SelectedIndex = -1

        dtFechaInicioProyecto.Value = DateTime.Now
        dtFechaFinProyecto.Value = DateTime.Now
        dtFechaInicioActividad.Value = DateTime.Now
        dtFechaFinActividad.Value = DateTime.Now
    End Sub

    Private Sub btnProyectosAñoSeleccionado_Click(sender As Object, e As EventArgs) Handles btnProyectosAñoIntroducido.Click
        Dim añoSeleccionado As String
        añoSeleccionado = InputBox("Ingrese un año:", "Año para ver los proyectos")

        If IsNumeric(añoSeleccionado) AndAlso añoSeleccionado.Length = 4 Then
            MessageBox.Show("El año ingresado es: " & añoSeleccionado)
        ElseIf añoSeleccionado <> "" Then
            MessageBox.Show("Año inválido. Debe ser un número de 4 dígitos.")
        End If
    End Sub
End Class
