Public Class Validaciones
    ''' <summary>
    ''' Muestra la letra de un DNI que corresponde a los números introducidos
    ''' </summary>
    ''' <param name="numero">Números del DNI</param>
    ''' <returns>Letra que le corresponde a los números introducidos</returns>
    Public Shared Function LetraDNI(numero As Integer) As Char
        Dim letras As String = "TRWAGMYFPDXBNJZSQVHLCKE"

        If (numero > 9999999) AndAlso (numero < 100000000) Then
            Dim resultado As Integer = numero Mod 23
            Return letras.Chars(resultado)
        End If

        Return ""
    End Function

    ''' <summary>
    ''' Comprueba si el DNI introducido es válido
    ''' </summary>
    ''' <param name="dni">DNI introducido para comprobar</param>
    ''' <returns>Devuelve si el DNI es válido o no</returns>
    Public Shared Function ValidarDNI(dni As String) As String

        Dim letras As String = "TRWAGMYFPDXBNJZSQVHLCKE"
        Dim numeros As Integer = 0
        Dim resto As Integer = 0
        Dim letra As Char = ""

        If dni.Length <> 9 Then Return "El DNI debe tener 9 caracteres"
        If Not Integer.TryParse(dni.Substring(0, 8), numeros) Then Return "El DNI debe estar compuesto por 8 números y una letra al final"
        If Not (numeros > 9999999) AndAlso (numeros < 100000000) Then Return "El DNI debe estar compuesto por 8 números y una letra al final"
        If Not Char.IsLetter(dni.Substring(8)) Then Return "El DNI debe estar compuesto por 8 números y una letra al final"

        letra = dni.Substring(8).ToUpper
        resto = numeros Mod 23
        If letras(resto) <> letra Then Return "El DNI no es válido"

        Return ""

    End Function

End Class
