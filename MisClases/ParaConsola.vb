Public Class ParaConsola
    ''' <summary>
    ''' Muestra un mensaje con un color
    ''' </summary>
    ''' <param name="mensaje">Mensaje que muestra</param>
    ''' <param name="color">Color para el texto</param>
    Public Shared Sub MostrarMensaje(mensaje As String, color As ConsoleColor)
        Console.ForegroundColor = color
        Console.WriteLine(mensaje)
        Console.ResetColor()
    End Sub

    ''' <summary>
    ''' Muestra un mensaje con un color y un posible salto de línea
    ''' </summary>
    ''' <param name="mensaje">Mensaje que muestra</param>
    ''' <param name="color">Color para el texto</param>
    ''' <param name="saltoLinea">Determina si hay salto de línea</param>
    Public Shared Sub MostrarMensaje(mensaje As String, color As ConsoleColor, saltoLinea As Boolean)
        Console.ForegroundColor = color
        If saltoLinea Then
            Console.WriteLine(mensaje)
        Else
            Console.Write(mensaje)
        End If
        Console.ResetColor()
    End Sub

    ''' <summary>
    ''' Leer un dato el cual está siendo escrito con un color determinado
    ''' </summary>
    ''' <param name="color">Color que se verá en pantalla mientras el usuario escribe</param>
    ''' <returns>Dato escrito por el usuario</returns>
    Public Shared Function LeerDato(color As ConsoleColor) As String
        Dim dato As String
        Console.ForegroundColor = color
        dato = Console.ReadLine
        Console.ResetColor()
        Return dato
    End Function
End Class


