<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblInformacion = New System.Windows.Forms.Label()
        Me.txtNombreProyecto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescripcionProyecto = New System.Windows.Forms.TextBox()
        Me.btnNuevoProyecto = New System.Windows.Forms.Button()
        Me.btnInfoProyectos = New System.Windows.Forms.Button()
        Me.cboProyectosInfo = New System.Windows.Forms.ComboBox()
        Me.btnInfoProyectoSeleccionado = New System.Windows.Forms.Button()
        Me.txtNuevaDescripcion = New System.Windows.Forms.TextBox()
        Me.btnModificarDescripcion = New System.Windows.Forms.Button()
        Me.cboOrganizaciones = New System.Windows.Forms.ComboBox()
        Me.cboProyectosAñadirAlumnoActividad = New System.Windows.Forms.ComboBox()
        Me.cboAlumnos = New System.Windows.Forms.ComboBox()
        Me.cboActividadesAñadirAlumno = New System.Windows.Forms.ComboBox()
        Me.cboProyectosModificarDescripcion = New System.Windows.Forms.ComboBox()
        Me.grbActividadesDeProyecto = New System.Windows.Forms.GroupBox()
        Me.grbModificarDescripcionProyecto = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAñadirAlumnoActividad = New System.Windows.Forms.Button()
        Me.grbAñadirAlumnoActividad = New System.Windows.Forms.GroupBox()
        Me.dtFechaInicioProyecto = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaFinProyecto = New System.Windows.Forms.DateTimePicker()
        Me.grbNuevoProyecto = New System.Windows.Forms.GroupBox()
        Me.grbCrearActividad = New System.Windows.Forms.GroupBox()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNombreNuevaActividad = New System.Windows.Forms.TextBox()
        Me.cboProyectosCrearActividad = New System.Windows.Forms.ComboBox()
        Me.dtFechaFinActividad = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicioActividad = New System.Windows.Forms.DateTimePicker()
        Me.btnNuevaActividad = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDescripcionActividad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboProyectosAñadirODS = New System.Windows.Forms.ComboBox()
        Me.cboProyectosEliminarODS = New System.Windows.Forms.ComboBox()
        Me.btnAñadirODSProyecto = New System.Windows.Forms.Button()
        Me.btnBuscarODSProyecto = New System.Windows.Forms.Button()
        Me.btnEliminarODSProyecto = New System.Windows.Forms.Button()
        Me.lsbAñadirODS = New System.Windows.Forms.ListBox()
        Me.lsbEliminarODS = New System.Windows.Forms.ListBox()
        Me.grbEliminarODS = New System.Windows.Forms.GroupBox()
        Me.grbAñadirODSProyecto = New System.Windows.Forms.GroupBox()
        Me.btnEliminarActividad = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboActividadesEliminar = New System.Windows.Forms.ComboBox()
        Me.cboProyectosEliminarAcividad = New System.Windows.Forms.ComboBox()
        Me.grbEliminarActividad = New System.Windows.Forms.GroupBox()
        Me.btnProyectosAñoIntroducido = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbActividadesDeProyecto.SuspendLayout()
        Me.grbModificarDescripcionProyecto.SuspendLayout()
        Me.grbAñadirAlumnoActividad.SuspendLayout()
        Me.grbNuevoProyecto.SuspendLayout()
        Me.grbCrearActividad.SuspendLayout()
        Me.grbEliminarODS.SuspendLayout()
        Me.grbAñadirODSProyecto.SuspendLayout()
        Me.grbEliminarActividad.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(844, 48)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 51
        Me.dgv.RowTemplate.Height = 24
        Me.dgv.Size = New System.Drawing.Size(657, 175)
        Me.dgv.TabIndex = 0
        '
        'lblInformacion
        '
        Me.lblInformacion.BackColor = System.Drawing.Color.PaleGreen
        Me.lblInformacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInformacion.Location = New System.Drawing.Point(844, 9)
        Me.lblInformacion.Name = "lblInformacion"
        Me.lblInformacion.Size = New System.Drawing.Size(657, 25)
        Me.lblInformacion.TabIndex = 1
        '
        'txtNombreProyecto
        '
        Me.txtNombreProyecto.Location = New System.Drawing.Point(164, 70)
        Me.txtNombreProyecto.Name = "txtNombreProyecto"
        Me.txtNombreProyecto.Size = New System.Drawing.Size(222, 22)
        Me.txtNombreProyecto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre Proyecto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha Fin"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Organización"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Descripción"
        '
        'txtDescripcionProyecto
        '
        Me.txtDescripcionProyecto.Location = New System.Drawing.Point(164, 220)
        Me.txtDescripcionProyecto.Multiline = True
        Me.txtDescripcionProyecto.Name = "txtDescripcionProyecto"
        Me.txtDescripcionProyecto.Size = New System.Drawing.Size(231, 92)
        Me.txtDescripcionProyecto.TabIndex = 10
        '
        'btnNuevoProyecto
        '
        Me.btnNuevoProyecto.Location = New System.Drawing.Point(6, 280)
        Me.btnNuevoProyecto.Name = "btnNuevoProyecto"
        Me.btnNuevoProyecto.Size = New System.Drawing.Size(152, 32)
        Me.btnNuevoProyecto.TabIndex = 12
        Me.btnNuevoProyecto.Text = "Nuevo Proyecto"
        Me.btnNuevoProyecto.UseVisualStyleBackColor = True
        '
        'btnInfoProyectos
        '
        Me.btnInfoProyectos.Location = New System.Drawing.Point(1200, 241)
        Me.btnInfoProyectos.Name = "btnInfoProyectos"
        Me.btnInfoProyectos.Size = New System.Drawing.Size(301, 35)
        Me.btnInfoProyectos.TabIndex = 13
        Me.btnInfoProyectos.Text = "Ver información de todos los proyectos"
        Me.btnInfoProyectos.UseVisualStyleBackColor = True
        '
        'cboProyectosInfo
        '
        Me.cboProyectosInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectosInfo.FormattingEnabled = True
        Me.cboProyectosInfo.Location = New System.Drawing.Point(17, 26)
        Me.cboProyectosInfo.Name = "cboProyectosInfo"
        Me.cboProyectosInfo.Size = New System.Drawing.Size(249, 24)
        Me.cboProyectosInfo.TabIndex = 14
        '
        'btnInfoProyectoSeleccionado
        '
        Me.btnInfoProyectoSeleccionado.Location = New System.Drawing.Point(17, 56)
        Me.btnInfoProyectoSeleccionado.Name = "btnInfoProyectoSeleccionado"
        Me.btnInfoProyectoSeleccionado.Size = New System.Drawing.Size(203, 34)
        Me.btnInfoProyectoSeleccionado.TabIndex = 15
        Me.btnInfoProyectoSeleccionado.Text = "Ver actividades del proyecto"
        Me.btnInfoProyectoSeleccionado.UseVisualStyleBackColor = True
        '
        'txtNuevaDescripcion
        '
        Me.txtNuevaDescripcion.Location = New System.Drawing.Point(11, 52)
        Me.txtNuevaDescripcion.Multiline = True
        Me.txtNuevaDescripcion.Name = "txtNuevaDescripcion"
        Me.txtNuevaDescripcion.Size = New System.Drawing.Size(270, 65)
        Me.txtNuevaDescripcion.TabIndex = 16
        '
        'btnModificarDescripcion
        '
        Me.btnModificarDescripcion.Location = New System.Drawing.Point(11, 135)
        Me.btnModificarDescripcion.Name = "btnModificarDescripcion"
        Me.btnModificarDescripcion.Size = New System.Drawing.Size(270, 27)
        Me.btnModificarDescripcion.TabIndex = 17
        Me.btnModificarDescripcion.Text = "Modificar descripción del proyecto"
        Me.btnModificarDescripcion.UseVisualStyleBackColor = True
        '
        'cboOrganizaciones
        '
        Me.cboOrganizaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrganizaciones.FormattingEnabled = True
        Me.cboOrganizaciones.Location = New System.Drawing.Point(164, 183)
        Me.cboOrganizaciones.Name = "cboOrganizaciones"
        Me.cboOrganizaciones.Size = New System.Drawing.Size(231, 24)
        Me.cboOrganizaciones.TabIndex = 18
        '
        'cboProyectosAñadirAlumnoActividad
        '
        Me.cboProyectosAñadirAlumnoActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectosAñadirAlumnoActividad.FormattingEnabled = True
        Me.cboProyectosAñadirAlumnoActividad.Location = New System.Drawing.Point(104, 65)
        Me.cboProyectosAñadirAlumnoActividad.Name = "cboProyectosAñadirAlumnoActividad"
        Me.cboProyectosAñadirAlumnoActividad.Size = New System.Drawing.Size(172, 24)
        Me.cboProyectosAñadirAlumnoActividad.TabIndex = 19
        '
        'cboAlumnos
        '
        Me.cboAlumnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlumnos.FormattingEnabled = True
        Me.cboAlumnos.Location = New System.Drawing.Point(104, 25)
        Me.cboAlumnos.Name = "cboAlumnos"
        Me.cboAlumnos.Size = New System.Drawing.Size(172, 24)
        Me.cboAlumnos.TabIndex = 20
        '
        'cboActividadesAñadirAlumno
        '
        Me.cboActividadesAñadirAlumno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActividadesAñadirAlumno.FormattingEnabled = True
        Me.cboActividadesAñadirAlumno.Location = New System.Drawing.Point(104, 105)
        Me.cboActividadesAñadirAlumno.Name = "cboActividadesAñadirAlumno"
        Me.cboActividadesAñadirAlumno.Size = New System.Drawing.Size(172, 24)
        Me.cboActividadesAñadirAlumno.TabIndex = 21
        '
        'cboProyectosModificarDescripcion
        '
        Me.cboProyectosModificarDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectosModificarDescripcion.FormattingEnabled = True
        Me.cboProyectosModificarDescripcion.Location = New System.Drawing.Point(11, 22)
        Me.cboProyectosModificarDescripcion.Name = "cboProyectosModificarDescripcion"
        Me.cboProyectosModificarDescripcion.Size = New System.Drawing.Size(270, 24)
        Me.cboProyectosModificarDescripcion.TabIndex = 22
        '
        'grbActividadesDeProyecto
        '
        Me.grbActividadesDeProyecto.Controls.Add(Me.btnInfoProyectoSeleccionado)
        Me.grbActividadesDeProyecto.Controls.Add(Me.cboProyectosInfo)
        Me.grbActividadesDeProyecto.Location = New System.Drawing.Point(902, 238)
        Me.grbActividadesDeProyecto.Name = "grbActividadesDeProyecto"
        Me.grbActividadesDeProyecto.Size = New System.Drawing.Size(282, 99)
        Me.grbActividadesDeProyecto.TabIndex = 23
        Me.grbActividadesDeProyecto.TabStop = False
        Me.grbActividadesDeProyecto.Text = "Actividades de un proyecto"
        '
        'grbModificarDescripcionProyecto
        '
        Me.grbModificarDescripcionProyecto.Controls.Add(Me.cboProyectosModificarDescripcion)
        Me.grbModificarDescripcionProyecto.Controls.Add(Me.btnModificarDescripcion)
        Me.grbModificarDescripcionProyecto.Controls.Add(Me.txtNuevaDescripcion)
        Me.grbModificarDescripcionProyecto.Location = New System.Drawing.Point(1200, 291)
        Me.grbModificarDescripcionProyecto.Name = "grbModificarDescripcionProyecto"
        Me.grbModificarDescripcionProyecto.Size = New System.Drawing.Size(300, 171)
        Me.grbModificarDescripcionProyecto.TabIndex = 24
        Me.grbModificarDescripcionProyecto.TabStop = False
        Me.grbModificarDescripcionProyecto.Text = "Modificar descripción de proyecto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Alumnos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Proyectos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Actividades"
        '
        'btnAñadirAlumnoActividad
        '
        Me.btnAñadirAlumnoActividad.Location = New System.Drawing.Point(12, 135)
        Me.btnAñadirAlumnoActividad.Name = "btnAñadirAlumnoActividad"
        Me.btnAñadirAlumnoActividad.Size = New System.Drawing.Size(264, 34)
        Me.btnAñadirAlumnoActividad.TabIndex = 28
        Me.btnAñadirAlumnoActividad.Text = "Añadir alumno a actividad"
        Me.btnAñadirAlumnoActividad.UseVisualStyleBackColor = True
        '
        'grbAñadirAlumnoActividad
        '
        Me.grbAñadirAlumnoActividad.Controls.Add(Me.btnAñadirAlumnoActividad)
        Me.grbAñadirAlumnoActividad.Controls.Add(Me.Label8)
        Me.grbAñadirAlumnoActividad.Controls.Add(Me.Label7)
        Me.grbAñadirAlumnoActividad.Controls.Add(Me.Label6)
        Me.grbAñadirAlumnoActividad.Controls.Add(Me.cboActividadesAñadirAlumno)
        Me.grbAñadirAlumnoActividad.Controls.Add(Me.cboAlumnos)
        Me.grbAñadirAlumnoActividad.Controls.Add(Me.cboProyectosAñadirAlumnoActividad)
        Me.grbAñadirAlumnoActividad.Location = New System.Drawing.Point(902, 343)
        Me.grbAñadirAlumnoActividad.Name = "grbAñadirAlumnoActividad"
        Me.grbAñadirAlumnoActividad.Size = New System.Drawing.Size(282, 173)
        Me.grbAñadirAlumnoActividad.TabIndex = 29
        Me.grbAñadirAlumnoActividad.TabStop = False
        Me.grbAñadirAlumnoActividad.Text = "Añadir alumno a actividad"
        '
        'dtFechaInicioProyecto
        '
        Me.dtFechaInicioProyecto.Location = New System.Drawing.Point(164, 103)
        Me.dtFechaInicioProyecto.Name = "dtFechaInicioProyecto"
        Me.dtFechaInicioProyecto.Size = New System.Drawing.Size(222, 22)
        Me.dtFechaInicioProyecto.TabIndex = 30
        '
        'dtFechaFinProyecto
        '
        Me.dtFechaFinProyecto.Location = New System.Drawing.Point(164, 142)
        Me.dtFechaFinProyecto.Name = "dtFechaFinProyecto"
        Me.dtFechaFinProyecto.ShowCheckBox = True
        Me.dtFechaFinProyecto.Size = New System.Drawing.Size(222, 22)
        Me.dtFechaFinProyecto.TabIndex = 31
        '
        'grbNuevoProyecto
        '
        Me.grbNuevoProyecto.Controls.Add(Me.dtFechaFinProyecto)
        Me.grbNuevoProyecto.Controls.Add(Me.dtFechaInicioProyecto)
        Me.grbNuevoProyecto.Controls.Add(Me.cboOrganizaciones)
        Me.grbNuevoProyecto.Controls.Add(Me.btnNuevoProyecto)
        Me.grbNuevoProyecto.Controls.Add(Me.Label5)
        Me.grbNuevoProyecto.Controls.Add(Me.txtDescripcionProyecto)
        Me.grbNuevoProyecto.Controls.Add(Me.Label4)
        Me.grbNuevoProyecto.Controls.Add(Me.Label3)
        Me.grbNuevoProyecto.Controls.Add(Me.Label2)
        Me.grbNuevoProyecto.Controls.Add(Me.Label1)
        Me.grbNuevoProyecto.Controls.Add(Me.txtNombreProyecto)
        Me.grbNuevoProyecto.Location = New System.Drawing.Point(1, 2)
        Me.grbNuevoProyecto.Name = "grbNuevoProyecto"
        Me.grbNuevoProyecto.Size = New System.Drawing.Size(401, 319)
        Me.grbNuevoProyecto.TabIndex = 32
        Me.grbNuevoProyecto.TabStop = False
        Me.grbNuevoProyecto.Text = "Crear nuevo proyecto"
        '
        'grbCrearActividad
        '
        Me.grbCrearActividad.Controls.Add(Me.txtUbicacion)
        Me.grbCrearActividad.Controls.Add(Me.Label14)
        Me.grbCrearActividad.Controls.Add(Me.txtNombreNuevaActividad)
        Me.grbCrearActividad.Controls.Add(Me.cboProyectosCrearActividad)
        Me.grbCrearActividad.Controls.Add(Me.dtFechaFinActividad)
        Me.grbCrearActividad.Controls.Add(Me.dtFechaInicioActividad)
        Me.grbCrearActividad.Controls.Add(Me.btnNuevaActividad)
        Me.grbCrearActividad.Controls.Add(Me.Label9)
        Me.grbCrearActividad.Controls.Add(Me.txtDescripcionActividad)
        Me.grbCrearActividad.Controls.Add(Me.Label10)
        Me.grbCrearActividad.Controls.Add(Me.Label11)
        Me.grbCrearActividad.Controls.Add(Me.Label12)
        Me.grbCrearActividad.Controls.Add(Me.Label13)
        Me.grbCrearActividad.Location = New System.Drawing.Point(422, 2)
        Me.grbCrearActividad.Name = "grbCrearActividad"
        Me.grbCrearActividad.Size = New System.Drawing.Size(401, 319)
        Me.grbCrearActividad.TabIndex = 33
        Me.grbCrearActividad.TabStop = False
        Me.grbCrearActividad.Text = "Crear nueva actividad"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Location = New System.Drawing.Point(164, 185)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(222, 22)
        Me.txtUbicacion.TabIndex = 37
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 189)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 16)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Ubicación"
        '
        'txtNombreNuevaActividad
        '
        Me.txtNombreNuevaActividad.Location = New System.Drawing.Point(164, 76)
        Me.txtNombreNuevaActividad.Name = "txtNombreNuevaActividad"
        Me.txtNombreNuevaActividad.Size = New System.Drawing.Size(222, 22)
        Me.txtNombreNuevaActividad.TabIndex = 35
        '
        'cboProyectosCrearActividad
        '
        Me.cboProyectosCrearActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectosCrearActividad.FormattingEnabled = True
        Me.cboProyectosCrearActividad.Location = New System.Drawing.Point(164, 36)
        Me.cboProyectosCrearActividad.Name = "cboProyectosCrearActividad"
        Me.cboProyectosCrearActividad.Size = New System.Drawing.Size(222, 24)
        Me.cboProyectosCrearActividad.TabIndex = 34
        '
        'dtFechaFinActividad
        '
        Me.dtFechaFinActividad.Location = New System.Drawing.Point(164, 148)
        Me.dtFechaFinActividad.Name = "dtFechaFinActividad"
        Me.dtFechaFinActividad.ShowCheckBox = True
        Me.dtFechaFinActividad.Size = New System.Drawing.Size(222, 22)
        Me.dtFechaFinActividad.TabIndex = 31
        '
        'dtFechaInicioActividad
        '
        Me.dtFechaInicioActividad.Location = New System.Drawing.Point(164, 108)
        Me.dtFechaInicioActividad.Name = "dtFechaInicioActividad"
        Me.dtFechaInicioActividad.Size = New System.Drawing.Size(222, 22)
        Me.dtFechaInicioActividad.TabIndex = 30
        '
        'btnNuevaActividad
        '
        Me.btnNuevaActividad.Location = New System.Drawing.Point(0, 275)
        Me.btnNuevaActividad.Name = "btnNuevaActividad"
        Me.btnNuevaActividad.Size = New System.Drawing.Size(158, 38)
        Me.btnNuevaActividad.TabIndex = 12
        Me.btnNuevaActividad.Text = "Nueva Actividad"
        Me.btnNuevaActividad.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 16)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Descripción"
        '
        'txtDescripcionActividad
        '
        Me.txtDescripcionActividad.Location = New System.Drawing.Point(164, 223)
        Me.txtDescripcionActividad.Multiline = True
        Me.txtDescripcionActividad.Name = "txtDescripcionActividad"
        Me.txtDescripcionActividad.Size = New System.Drawing.Size(231, 89)
        Me.txtDescripcionActividad.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Nombre actividad"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Fecha Fin"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Fecha Inicio"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Proyectos"
        '
        'cboProyectosAñadirODS
        '
        Me.cboProyectosAñadirODS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectosAñadirODS.FormattingEnabled = True
        Me.cboProyectosAñadirODS.Location = New System.Drawing.Point(6, 21)
        Me.cboProyectosAñadirODS.Name = "cboProyectosAñadirODS"
        Me.cboProyectosAñadirODS.Size = New System.Drawing.Size(294, 24)
        Me.cboProyectosAñadirODS.TabIndex = 34
        '
        'cboProyectosEliminarODS
        '
        Me.cboProyectosEliminarODS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectosEliminarODS.FormattingEnabled = True
        Me.cboProyectosEliminarODS.Location = New System.Drawing.Point(6, 21)
        Me.cboProyectosEliminarODS.Name = "cboProyectosEliminarODS"
        Me.cboProyectosEliminarODS.Size = New System.Drawing.Size(294, 24)
        Me.cboProyectosEliminarODS.TabIndex = 35
        '
        'btnAñadirODSProyecto
        '
        Me.btnAñadirODSProyecto.Location = New System.Drawing.Point(6, 58)
        Me.btnAñadirODSProyecto.Name = "btnAñadirODSProyecto"
        Me.btnAñadirODSProyecto.Size = New System.Drawing.Size(294, 31)
        Me.btnAñadirODSProyecto.TabIndex = 36
        Me.btnAñadirODSProyecto.Text = "Añadir ODS a proyecto"
        Me.btnAñadirODSProyecto.UseVisualStyleBackColor = True
        '
        'btnBuscarODSProyecto
        '
        Me.btnBuscarODSProyecto.Location = New System.Drawing.Point(6, 56)
        Me.btnBuscarODSProyecto.Name = "btnBuscarODSProyecto"
        Me.btnBuscarODSProyecto.Size = New System.Drawing.Size(294, 29)
        Me.btnBuscarODSProyecto.TabIndex = 37
        Me.btnBuscarODSProyecto.Text = "Buscar ODSs del proyecto"
        Me.btnBuscarODSProyecto.UseVisualStyleBackColor = True
        '
        'btnEliminarODSProyecto
        '
        Me.btnEliminarODSProyecto.Location = New System.Drawing.Point(6, 94)
        Me.btnEliminarODSProyecto.Name = "btnEliminarODSProyecto"
        Me.btnEliminarODSProyecto.Size = New System.Drawing.Size(294, 32)
        Me.btnEliminarODSProyecto.TabIndex = 38
        Me.btnEliminarODSProyecto.Text = "Eliminar ODS de proyecto"
        Me.btnEliminarODSProyecto.UseVisualStyleBackColor = True
        '
        'lsbAñadirODS
        '
        Me.lsbAñadirODS.FormattingEnabled = True
        Me.lsbAñadirODS.ItemHeight = 16
        Me.lsbAñadirODS.Location = New System.Drawing.Point(6, 99)
        Me.lsbAñadirODS.Name = "lsbAñadirODS"
        Me.lsbAñadirODS.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lsbAñadirODS.Size = New System.Drawing.Size(294, 196)
        Me.lsbAñadirODS.TabIndex = 39
        '
        'lsbEliminarODS
        '
        Me.lsbEliminarODS.FormattingEnabled = True
        Me.lsbEliminarODS.ItemHeight = 16
        Me.lsbEliminarODS.Location = New System.Drawing.Point(6, 141)
        Me.lsbEliminarODS.Name = "lsbEliminarODS"
        Me.lsbEliminarODS.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lsbEliminarODS.Size = New System.Drawing.Size(294, 148)
        Me.lsbEliminarODS.TabIndex = 40
        '
        'grbEliminarODS
        '
        Me.grbEliminarODS.Controls.Add(Me.lsbEliminarODS)
        Me.grbEliminarODS.Controls.Add(Me.btnEliminarODSProyecto)
        Me.grbEliminarODS.Controls.Add(Me.btnBuscarODSProyecto)
        Me.grbEliminarODS.Controls.Add(Me.cboProyectosEliminarODS)
        Me.grbEliminarODS.Location = New System.Drawing.Point(313, 336)
        Me.grbEliminarODS.Name = "grbEliminarODS"
        Me.grbEliminarODS.Size = New System.Drawing.Size(306, 310)
        Me.grbEliminarODS.TabIndex = 41
        Me.grbEliminarODS.TabStop = False
        Me.grbEliminarODS.Text = "Buscar o eliminar ODS de proyecto"
        '
        'grbAñadirODSProyecto
        '
        Me.grbAñadirODSProyecto.Controls.Add(Me.lsbAñadirODS)
        Me.grbAñadirODSProyecto.Controls.Add(Me.btnAñadirODSProyecto)
        Me.grbAñadirODSProyecto.Controls.Add(Me.cboProyectosAñadirODS)
        Me.grbAñadirODSProyecto.Location = New System.Drawing.Point(1, 336)
        Me.grbAñadirODSProyecto.Name = "grbAñadirODSProyecto"
        Me.grbAñadirODSProyecto.Size = New System.Drawing.Size(306, 310)
        Me.grbAñadirODSProyecto.TabIndex = 42
        Me.grbAñadirODSProyecto.TabStop = False
        Me.grbAñadirODSProyecto.Text = "Añadir ODS a proyecto"
        '
        'btnEliminarActividad
        '
        Me.btnEliminarActividad.Location = New System.Drawing.Point(105, 108)
        Me.btnEliminarActividad.Name = "btnEliminarActividad"
        Me.btnEliminarActividad.Size = New System.Drawing.Size(188, 34)
        Me.btnEliminarActividad.TabIndex = 47
        Me.btnEliminarActividad.Text = "Eliminar actividad"
        Me.btnEliminarActividad.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 16)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Actividades"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 16)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Proyectos"
        '
        'cboActividadesEliminar
        '
        Me.cboActividadesEliminar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActividadesEliminar.FormattingEnabled = True
        Me.cboActividadesEliminar.Location = New System.Drawing.Point(105, 75)
        Me.cboActividadesEliminar.Name = "cboActividadesEliminar"
        Me.cboActividadesEliminar.Size = New System.Drawing.Size(188, 24)
        Me.cboActividadesEliminar.TabIndex = 44
        '
        'cboProyectosEliminarAcividad
        '
        Me.cboProyectosEliminarAcividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectosEliminarAcividad.FormattingEnabled = True
        Me.cboProyectosEliminarAcividad.Location = New System.Drawing.Point(105, 35)
        Me.cboProyectosEliminarAcividad.Name = "cboProyectosEliminarAcividad"
        Me.cboProyectosEliminarAcividad.Size = New System.Drawing.Size(188, 24)
        Me.cboProyectosEliminarAcividad.TabIndex = 43
        '
        'grbEliminarActividad
        '
        Me.grbEliminarActividad.Controls.Add(Me.btnEliminarActividad)
        Me.grbEliminarActividad.Controls.Add(Me.Label15)
        Me.grbEliminarActividad.Controls.Add(Me.Label16)
        Me.grbEliminarActividad.Controls.Add(Me.cboActividadesEliminar)
        Me.grbEliminarActividad.Controls.Add(Me.cboProyectosEliminarAcividad)
        Me.grbEliminarActividad.Location = New System.Drawing.Point(1200, 472)
        Me.grbEliminarActividad.Name = "grbEliminarActividad"
        Me.grbEliminarActividad.Size = New System.Drawing.Size(299, 165)
        Me.grbEliminarActividad.TabIndex = 48
        Me.grbEliminarActividad.TabStop = False
        Me.grbEliminarActividad.Text = "Eliminar Actividad"
        '
        'btnProyectosAñoIntroducido
        '
        Me.btnProyectosAñoIntroducido.Location = New System.Drawing.Point(902, 526)
        Me.btnProyectosAñoIntroducido.Name = "btnProyectosAñoIntroducido"
        Me.btnProyectosAñoIntroducido.Size = New System.Drawing.Size(282, 45)
        Me.btnProyectosAñoIntroducido.TabIndex = 49
        Me.btnProyectosAñoIntroducido.Text = "Proyectos en un año introducido"
        Me.btnProyectosAñoIntroducido.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1513, 649)
        Me.Controls.Add(Me.btnProyectosAñoIntroducido)
        Me.Controls.Add(Me.grbEliminarActividad)
        Me.Controls.Add(Me.grbAñadirODSProyecto)
        Me.Controls.Add(Me.grbEliminarODS)
        Me.Controls.Add(Me.grbCrearActividad)
        Me.Controls.Add(Me.grbNuevoProyecto)
        Me.Controls.Add(Me.grbAñadirAlumnoActividad)
        Me.Controls.Add(Me.grbModificarDescripcionProyecto)
        Me.Controls.Add(Me.grbActividadesDeProyecto)
        Me.Controls.Add(Me.btnInfoProyectos)
        Me.Controls.Add(Me.lblInformacion)
        Me.Controls.Add(Me.dgv)
        Me.Name = "Form1"
        Me.Text = "Aplicación para la gestión del voluntariado cuatrovientos"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbActividadesDeProyecto.ResumeLayout(False)
        Me.grbModificarDescripcionProyecto.ResumeLayout(False)
        Me.grbModificarDescripcionProyecto.PerformLayout()
        Me.grbAñadirAlumnoActividad.ResumeLayout(False)
        Me.grbAñadirAlumnoActividad.PerformLayout()
        Me.grbNuevoProyecto.ResumeLayout(False)
        Me.grbNuevoProyecto.PerformLayout()
        Me.grbCrearActividad.ResumeLayout(False)
        Me.grbCrearActividad.PerformLayout()
        Me.grbEliminarODS.ResumeLayout(False)
        Me.grbAñadirODSProyecto.ResumeLayout(False)
        Me.grbEliminarActividad.ResumeLayout(False)
        Me.grbEliminarActividad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents lblInformacion As Label
    Friend WithEvents txtNombreProyecto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDescripcionProyecto As TextBox
    Friend WithEvents btnNuevoProyecto As Button
    Friend WithEvents btnInfoProyectos As Button
    Friend WithEvents cboProyectosInfo As ComboBox
    Friend WithEvents btnInfoProyectoSeleccionado As Button
    Friend WithEvents txtNuevaDescripcion As TextBox
    Friend WithEvents btnModificarDescripcion As Button
    Friend WithEvents cboOrganizaciones As ComboBox
    Friend WithEvents cboProyectosAñadirAlumnoActividad As ComboBox
    Friend WithEvents cboAlumnos As ComboBox
    Friend WithEvents cboActividadesAñadirAlumno As ComboBox
    Friend WithEvents cboProyectosModificarDescripcion As ComboBox
    Friend WithEvents grbActividadesDeProyecto As GroupBox
    Friend WithEvents grbModificarDescripcionProyecto As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnAñadirAlumnoActividad As Button
    Friend WithEvents grbAñadirAlumnoActividad As GroupBox
    Friend WithEvents dtFechaInicioProyecto As DateTimePicker
    Friend WithEvents dtFechaFinProyecto As DateTimePicker
    Friend WithEvents grbNuevoProyecto As GroupBox
    Friend WithEvents grbCrearActividad As GroupBox
    Friend WithEvents dtFechaFinActividad As DateTimePicker
    Friend WithEvents dtFechaInicioActividad As DateTimePicker
    Friend WithEvents btnNuevaActividad As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDescripcionActividad As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboProyectosCrearActividad As ComboBox
    Friend WithEvents txtNombreNuevaActividad As TextBox
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cboProyectosAñadirODS As ComboBox
    Friend WithEvents cboProyectosEliminarODS As ComboBox
    Friend WithEvents btnAñadirODSProyecto As Button
    Friend WithEvents btnBuscarODSProyecto As Button
    Friend WithEvents btnEliminarODSProyecto As Button
    Friend WithEvents lsbAñadirODS As ListBox
    Friend WithEvents lsbEliminarODS As ListBox
    Friend WithEvents grbEliminarODS As GroupBox
    Friend WithEvents grbAñadirODSProyecto As GroupBox
    Friend WithEvents btnEliminarActividad As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cboActividadesEliminar As ComboBox
    Friend WithEvents cboProyectosEliminarAcividad As ComboBox
    Friend WithEvents grbEliminarActividad As GroupBox
    Friend WithEvents btnProyectosAñoIntroducido As Button
End Class
