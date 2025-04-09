Imports System.CodeDom

Public Class MiString

    ''' <summary>
    ''' Te dice si en el texto a validar introducido contiene sólo los caracteres válidos introducidos.
    ''' </summary>
    ''' <param name="caracteresValidos">Caracteres válidos que puede contener el texto a validar</param>
    ''' <param name="textoAValidar">Texto que se quiere comprobar con los caracteres válidos</param>
    ''' <returns>True si es válido, False si no es válido</returns>
    Public Shared Function CaracteresValidosEnTexto(caracteresValidos As String, textoAValidar As String) As Boolean
        caracteresValidos = caracteresValidos.ToLower
        textoAValidar = textoAValidar.ToLower
        For i = 0 To textoAValidar.Length - 1
            Dim contiene As Boolean = False
            For a = 0 To caracteresValidos.Length - 1
                If textoAValidar(i) = caracteresValidos(a) Then
                    contiene = True
                    Exit For
                End If
            Next
            If Not contiene Then Return False
        Next
        Return True
    End Function

    ''' <summary>
    ''' Te dice si el texto a validar introducido contiene sólo letras del abecedario
    ''' </summary>
    ''' <param name="textoAValidar">Texto que se quiere comprobar</param>
    ''' <returns>True si es válido, False si no es válido</returns>
    Public Shared Function EsAlfabetico(textoAValidar As String) As Boolean
        Return CaracteresValidosEnTexto("qwertyuiopasdfghjklñzxcvbnm", textoAValidar)
    End Function

    ''' <summary>
    ''' Te dice si el texto a validar introducido contiene sólo letras del abecedario, incluyendo tildes si se desea.
    ''' </summary>
    ''' <param name="textoAValidar">Texto que se quiere comprobar</param>
    ''' <param name="admiteTildes">Indicar si se admiten tildes o no</param>
    ''' <returns>True si es válido, False si no es válido</returns>
    Public Shared Function EsAlfabetico(textoAValidar As String, admiteTildes As Boolean) As Boolean
        If admiteTildes Then Return CaracteresValidosEnTexto("qwertyuiopasdfghjklñzxcvbnmáéíóúäëïöü", textoAValidar)
        Return EsAlfabetico(textoAValidar)
    End Function

    ''' <summary>
    ''' Te dice si la frase introducida es palíndroma
    ''' </summary>
    ''' <param name="frase">Frase a comprobar</param>
    ''' <returns>True si es palíndroma, Flase si no lo es</returns>
    Public Shared Function EsPalindroma(frase As String) As Boolean
        frase = frase.ToLower
        If frase.Length = 0 Then Return False
        Dim inicio As Integer = 0
        Dim fin As Integer = frase.Length - 1
        Do
            If frase(inicio) = frase(fin) Then
                inicio += 1
                fin -= 1
            Else Return False
            End If
        Loop Until inicio >= fin
        Return True
    End Function
    ''' <summary>
    ''' Te dice si es un correo válido
    ''' </summary>
    ''' <param name="correo">Correo solicitado</param>
    ''' <returns>True si es correo válido, Flase si no lo es</returns>
    Public Shared Function EsCorreo(correo As String) As Boolean
        correo = correo.ToLower
        If correo <= 4 Then Return False
        If Not CaracteresValidosEnTexto("qwertyuiopasdfghjklñzxcvbnmáéíóúäëïöü@.-_0123456789", correo) Then Return False
        If correo.IndexOf("@") > 0 AndAlso correo.IndexOf("@") = correo.LastIndexOf("@") Then
            If correo.IndexOf("@") + 1 < correo.LastIndexOf(".") Then
                For i = 0 To correo.Length - 1
                    If correo(i) = "." Then
                        If correo(i + 1) = "." Then Return False
                    End If
                Next
                Return True
            End If
        End If
        Return False
    End Function
End Class
