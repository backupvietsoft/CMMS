Imports System.Xml
Imports System.Reflection

Namespace QL.Common.Data
    ' <summary>
    ' <Class>Null Class</Class>
    ' <Created>Create By Nghiem Quan, Lieu</Created>
    ' <Description>Class for dealing with the translation of database null values. </Description>
    ' </summary>
    ' <remarks></remarks>
    Public Class Null

        ' define application encoded null values 
        Public Shared ReadOnly Property NullShort() As Short
            Get
                Return -1
            End Get
        End Property
        Public Shared ReadOnly Property NullInteger() As Integer
            Get
                Return -1
            End Get
        End Property
        Public Shared ReadOnly Property NullSingle() As Single
            Get
                Return Single.MinValue
            End Get
        End Property
        Public Shared ReadOnly Property NullDouble() As Double
            Get
                Return Double.MinValue
            End Get
        End Property
        Public Shared ReadOnly Property NullDecimal() As Decimal
            Get
                Return Decimal.MinValue
            End Get
        End Property
        Public Shared ReadOnly Property NullDate() As Date
            Get
                Return Date.MinValue
            End Get
        End Property
        Public Shared ReadOnly Property NullString() As String
            Get
                Return ""
            End Get
        End Property
        Public Shared ReadOnly Property NullBoolean() As Boolean
            Get
                Return False
            End Get
        End Property
        Public Shared ReadOnly Property NullGuid() As Guid
            Get
                Return Guid.Empty
            End Get
        End Property

        ' sets a field to an application encoded null value ( used in BLL layer )
        Public Shared Function SetNull(ByVal objValue As Object, ByVal objField As Object) As Object
            If IsDBNull(objValue) Then
                If TypeOf objField Is Short Then
                    SetNull = NullShort
                ElseIf TypeOf objField Is Integer Then
                    SetNull = NullInteger
                ElseIf TypeOf objField Is Single Then
                    SetNull = NullSingle
                ElseIf TypeOf objField Is Double Then
                    SetNull = NullDouble
                ElseIf TypeOf objField Is Decimal Then
                    SetNull = NullDecimal
                ElseIf TypeOf objField Is Date Then
                    SetNull = NullDate
                ElseIf TypeOf objField Is String Then
                    SetNull = NullString
                ElseIf TypeOf objField Is Boolean Then
                    SetNull = NullBoolean
                ElseIf TypeOf objField Is Guid Then
                    SetNull = NullGuid
                Else ' complex object
                    SetNull = Nothing
                End If
            Else    ' return value
                SetNull = objValue
            End If
        End Function

        ' sets a field to an application encoded null value ( used in BLL layer )
        Public Shared Function SetNull(ByVal objPropertyInfo As PropertyInfo) As Object
            Select Case objPropertyInfo.PropertyType.ToString
                Case "System.Int16"
                    SetNull = NullShort
                Case "System.Int32", "System.Int64"
                    SetNull = NullInteger
                Case "System.Single"
                    SetNull = NullSingle
                Case "System.Double"
                    SetNull = NullDouble
                Case "System.Decimal"
                    SetNull = NullDecimal
                Case "System.DateTime"
                    SetNull = NullDate
                Case "System.String", "System.Char"
                    SetNull = NullString
                Case "System.Boolean"
                    SetNull = NullBoolean
                Case "System.Guid"
                    SetNull = NullGuid
                Case Else
                    ' Enumerations default to the first entry
                    Dim pType As Type = objPropertyInfo.PropertyType
                    If pType.BaseType.Equals(GetType(System.Enum)) Then
                        Dim objEnumValues As System.Array = System.Enum.GetValues(pType)
                        Array.Sort(objEnumValues)
                        SetNull = System.Enum.ToObject(pType, objEnumValues.GetValue(0))
                    Else ' complex object
                        SetNull = Nothing
                    End If
            End Select
        End Function

        ' convert an application encoded null value to a database null value ( used in DAL )
        Public Shared Function GetNull(ByVal objField As Object, ByVal objDBNull As Object) As Object
            GetNull = objField
            If objField Is Nothing Then
                GetNull = objDBNull
            ElseIf TypeOf objField Is Short Then
                If Convert.ToInt16(objField) = NullShort Then
                    GetNull = objDBNull
                End If
            ElseIf TypeOf objField Is Integer Then
                If Convert.ToInt32(objField) = NullInteger Then
                    GetNull = objDBNull
                End If
            ElseIf TypeOf objField Is Single Then
                If Convert.ToSingle(objField) = NullSingle Then
                    GetNull = objDBNull
                End If
            ElseIf TypeOf objField Is Double Then
                If Convert.ToDouble(objField) = NullDouble Then
                    GetNull = objDBNull
                End If
            ElseIf TypeOf objField Is Decimal Then
                If Convert.ToDecimal(objField) = NullDecimal Then
                    GetNull = objDBNull
                End If
            ElseIf TypeOf objField Is Date Then
                ' compare the Date part of the DateTime with the DatePart of the NullDate ( this avoids subtle time differences )
                If Convert.ToDateTime(objField).Date = NullDate.Date Then
                    GetNull = objDBNull
                End If
            ElseIf TypeOf objField Is String Then
                If objField Is Nothing Then
                    GetNull = objDBNull
                Else
                    If objField.ToString = NullString Then
                        GetNull = objDBNull
                    End If
                End If
            ElseIf TypeOf objField Is Boolean Then
                If Convert.ToBoolean(objField) = NullBoolean Then
                    GetNull = objDBNull
                End If
            ElseIf TypeOf objField Is Guid Then
                If CType(objField, System.Guid).Equals(NullGuid) Then
                    GetNull = objDBNull
                End If
            End If
        End Function

        ' checks if a field contains an application encoded null value
        Public Shared Function IsNull(ByVal objField As Object) As Boolean
            If Not objField Is Nothing Then
                If TypeOf objField Is Integer Then
                    IsNull = objField.Equals(NullInteger)
                ElseIf TypeOf objField Is Single Then
                    IsNull = objField.Equals(NullSingle)
                ElseIf TypeOf objField Is Double Then
                    IsNull = objField.Equals(NullDouble)
                ElseIf TypeOf objField Is Decimal Then
                    IsNull = objField.Equals(NullDecimal)
                ElseIf TypeOf objField Is Date Then
                    Dim objDate As DateTime = CType(objField, DateTime)
                    IsNull = objDate.Date.Equals(NullDate.Date)
                ElseIf TypeOf objField Is String Then
                    IsNull = objField.Equals(NullString)
                ElseIf TypeOf objField Is Boolean Then
                    IsNull = objField.Equals(NullBoolean)
                ElseIf TypeOf objField Is Guid Then
                    IsNull = objField.Equals(NullGuid)
                Else ' complex object
                    IsNull = False
                End If
            Else
                IsNull = True
            End If
        End Function

    End Class
End Namespace