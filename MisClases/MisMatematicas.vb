Imports System.Linq.Expressions

Public Class MisMatematicas
    ''' <summary>
    ''' Calcula y devuelve el factorial del número pasado como parámetro
    ''' </summary>
    ''' <param name="numero">Número pequeño, entre 0 y 50</param>
    ''' <returns>Devuelve el factorial del número solicitado</returns>
    Public Shared Function Factorial(numero As Byte) As Double
        Dim fact As Double = 1
        For i = 2 To numero
            fact *= i
        Next
        Return fact
    End Function
    Public Shared Function Permutaciones(numero As Byte) As Double
        Return Factorial(numero)
    End Function
    Public Shared Function Combinaciones(num1 As Byte, num2 As Byte) As Double
        Return Factorial(num1) / (Factorial(num2) / Factorial(num1 - num2))
    End Function
    Public Shared Function Variaciones(num1 As Byte, num2 As Byte) As Double
        Return Factorial(num1) / Combinaciones(num1, num2) * Factorial(num2)
    End Function
End Class


