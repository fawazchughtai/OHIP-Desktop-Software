Public Class OHIPValidation
    Private class_OHIPNumber As String
    Private class_IsValid As Boolean = False
    Public Property OHIPNumber() As String
        Set(ByVal value As String)
            class_OHIPNumber = value.ToString
        End Set
        Get
            Return class_OHIPNumber
        End Get

    End Property
    Public ReadOnly Property isValid() As Boolean
        Get
            Dim OHIPCharacters As Array = class_OHIPNumber.ToCharArray
            Dim OHIPValid As Boolean = False
            Dim i As Integer = 0

            Dim mod10CharDigit1 As String
            Dim mod10CharDigit2 As String
            Dim mod10CharDigit3 As String
            Dim mod10CharDigit4 As String
            Dim mod10CharDigit5 As String
            Dim mod10CharDigit6 As String
            Dim mod10CharDigit7 As String
            Dim mod10CharDigit8 As String
            Dim mod10CharDigit9 As String

            Dim mod10DoubleDigit1 As Integer
            Dim mod10DoubleDigit3 As Integer
            Dim mod10DoubleDigit5 As Integer
            Dim mod10DoubleDigit7 As Integer
            Dim mod10DoubleDigit9 As Integer

            Dim mod10CharArrayDigit1 As String
            Dim mod10CharArrayDigit3 As String
            Dim mod10CharArrayDigit5 As String
            Dim mod10CharArrayDigit7 As String
            Dim mod10CharArrayDigit9 As String


            Dim mod10NumberDigit1 As Integer = 0
            Dim mod10NumberDigit2 As Integer = 0
            Dim mod10NumberDigit3 As Integer = 0
            Dim mod10NumberDigit4 As Integer = 0
            Dim mod10NumberDigit5 As Integer = 0
            Dim mod10NumberDigit6 As Integer = 0
            Dim mod10NumberDigit7 As Integer = 0
            Dim mod10NumberDigit8 As Integer = 0
            Dim mod10NumberDigit9 As Integer = 0
            Dim mod10CheckDigit As Integer = 0


            Dim mod10Sum As Integer = 0


            If class_OHIPNumber.Length = 10 Then

                mod10CharDigit1 = OHIPCharacters(0).ToString
                mod10CharDigit2 = OHIPCharacters(1).ToString
                mod10CharDigit3 = OHIPCharacters(2).ToString
                mod10CharDigit4 = OHIPCharacters(3).ToString
                mod10CharDigit5 = OHIPCharacters(4).ToString
                mod10CharDigit6 = OHIPCharacters(5).ToString
                mod10CharDigit7 = OHIPCharacters(6).ToString
                mod10CharDigit8 = OHIPCharacters(7).ToString
                mod10CharDigit9 = OHIPCharacters(8).ToString
                mod10CheckDigit = OHIPCharacters(9).ToString

                mod10DoubleDigit1 = CType(mod10CharDigit1, Integer) * 2
                mod10DoubleDigit3 = CType(mod10CharDigit3, Integer) * 2
                mod10DoubleDigit5 = CType(mod10CharDigit5, Integer) * 2
                mod10DoubleDigit7 = CType(mod10CharDigit7, Integer) * 2
                mod10DoubleDigit9 = CType(mod10CharDigit9, Integer) * 2

                mod10CharArrayDigit1 = mod10DoubleDigit1.ToString.ToCharArray
                mod10CharArrayDigit3 = mod10DoubleDigit3.ToString.ToCharArray
                mod10CharArrayDigit5 = mod10DoubleDigit5.ToString.ToCharArray
                mod10CharArrayDigit7 = mod10DoubleDigit7.ToString.ToCharArray
                mod10CharArrayDigit9 = mod10DoubleDigit9.ToString.ToCharArray


                For i = 0 To mod10CharArrayDigit1.Length - 1
                    mod10NumberDigit1 = mod10NumberDigit1 + CType(mod10CharArrayDigit1(i).ToString, Integer)
                Next
                For i = 0 To mod10CharArrayDigit3.Length - 1
                    mod10NumberDigit3 = mod10NumberDigit3 + CType(mod10CharArrayDigit3(i).ToString, Integer)
                Next
                For i = 0 To mod10CharArrayDigit5.Length - 1
                    mod10NumberDigit5 = mod10NumberDigit5 + CType(mod10CharArrayDigit5(i).ToString, Integer)
                Next
                For i = 0 To mod10CharArrayDigit7.Length - 1
                    mod10NumberDigit7 = mod10NumberDigit7 + CType(mod10CharArrayDigit7(i).ToString, Integer)
                Next
                For i = 0 To mod10CharArrayDigit9.Length - 1
                    mod10NumberDigit9 = mod10NumberDigit9 + CType(mod10CharArrayDigit9(i).ToString, Integer)
                Next

                mod10NumberDigit2 = CType(mod10CharDigit2.ToString, Integer)
                mod10NumberDigit4 = CType(mod10CharDigit4.ToString, Integer)
                mod10NumberDigit6 = CType(mod10CharDigit6.ToString, Integer)
                mod10NumberDigit8 = CType(mod10CharDigit8.ToString, Integer)


                mod10CheckDigit = CType(OHIPCharacters(9).ToString, Integer)

                mod10Sum = mod10NumberDigit1 + mod10NumberDigit2 + mod10NumberDigit3 + mod10NumberDigit4 + mod10NumberDigit5 + mod10NumberDigit6 + mod10NumberDigit7 + mod10NumberDigit8 + mod10NumberDigit9

                Dim sumMod10Characters As Array = mod10Sum.ToString.ToCharArray
                Dim sumModUnit As String = sumMod10Characters((sumMod10Characters.Length - 1))


                If (10 - CType(sumModUnit, Integer)) = mod10CheckDigit Then
                    OHIPValid = True
                Else
                    If sumModUnit = 0 And mod10CheckDigit = 0 Then
                        OHIPValid = True
                    Else
                        OHIPValid = False
                    End If
                End If

            End If

            Return OHIPValid
        End Get
    End Property

End Class
