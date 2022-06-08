Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Reflection
Imports System.Xml.Serialization
Imports System.Collections.Generic

Namespace QL.Common.Data

    ' <summary>
    ' <Class>Class BusinessDataController</Class>
    ' <Created>Created By Nghiem Quan, Lieu</Created>
    ' <Description> Class that hydrates custom business objects with data. 
    ' Please note that this utility class can only be used on objects with "simple"
    ' data types. If the object contains "complex" data types such as 
    ' ArrayLists, HashTables, Custom Objects, etc... then the developer 
    ' will need to write custom code for the hydration of these "complex" 
    ' data types.</Description>
    ' </summary>
    ' <remarks></remarks>
    Public Class QLBusinessDataController

#Region "Public Functions"
        Public Shared Function GetPropertyInfo(ByVal objType As Type) As ArrayList

            ' Use the cache because the reflection used later is expensive
            Dim objProperties As ArrayList = New ArrayList

            objProperties = New ArrayList
            Dim objProperty As PropertyInfo
            For Each objProperty In objType.GetProperties()
                objProperties.Add(objProperty)
            Next
            Return objProperties

        End Function

        Private Shared Function GetOrdinals(ByVal objProperties As ArrayList, ByVal dr As IDataReader) As Integer()

            Dim arrOrdinals(objProperties.Count) As Integer
            Dim intProperty As Integer

            If Not dr Is Nothing Then
                For intProperty = 0 To objProperties.Count - 1
                    arrOrdinals(intProperty) = -1
                    Try
                        arrOrdinals(intProperty) = dr.GetOrdinal(CType(objProperties(intProperty), PropertyInfo).Name)
                    Catch
                        ' property does not exist in datareader
                    End Try
                Next intProperty
            End If

            Return arrOrdinals

        End Function

        Private Shared Function CreateObject(ByVal objType As Type, ByVal dr As IDataReader, ByVal objProperties As ArrayList, ByVal arrOrdinals As Integer()) As Object

            Dim objPropertyInfo As PropertyInfo
            Dim objValue As Object
            Dim objPropertyType As Type = Nothing
            Dim intProperty As Integer

            Dim objObject As Object = Activator.CreateInstance(objType)

            ' fill object with values from datareader
            For intProperty = 0 To objProperties.Count - 1
                objPropertyInfo = CType(objProperties(intProperty), PropertyInfo)
                If objPropertyInfo.CanWrite Then
                    'objValue = Null.SetNull(objPropertyInfo)

                    objValue = Nothing

                    If arrOrdinals(intProperty) <> -1 Then
                        If IsDBNull(dr.GetValue(arrOrdinals(intProperty))) Then
                            ' translate Null value
                            objPropertyInfo.SetValue(objObject, objValue, Nothing)
                        Else
                            Try
                                ' try implicit conversion first
                                objPropertyInfo.SetValue(objObject, dr.GetValue(arrOrdinals(intProperty)), Nothing)
                            Catch
                                ' business object info class member data type does not match datareader member data type
                                Try
                                    objPropertyType = objPropertyInfo.PropertyType
                                    'need to handle enumeration conversions differently than other base types
                                    If objPropertyType.BaseType.Equals(GetType(System.Enum)) Then
                                        ' check if value is numeric and if not convert to integer ( supports databases like Oracle )
                                        If IsNumeric(dr.GetValue(arrOrdinals(intProperty))) Then
                                            CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, System.Enum.ToObject(objPropertyType, Convert.ToInt32(dr.GetValue(arrOrdinals(intProperty)))), Nothing)
                                        Else
                                            CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, System.Enum.ToObject(objPropertyType, dr.GetValue(arrOrdinals(intProperty))), Nothing)
                                        End If
                                    Else
                                        ' try explicit conversion
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals(intProperty)), objPropertyType), Nothing)
                                    End If
                                Catch
                                    objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals(intProperty)), objPropertyType), Nothing)
                                End Try
                            End Try
                        End If
                    Else
                        ' property does not exist in datareader
                    End If
                End If
            Next intProperty

            Return objObject

        End Function

        Public Shared Function FillObject(ByVal dr As IDataReader, ByVal objType As Type) As Object

            Return FillObject(dr, objType, True)

        End Function

        Public Shared Function FillObject(ByVal dr As IDataReader, ByVal objType As Type, ByVal ManageDataReader As Boolean) As Object

            Dim objFillObject As Object

            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objType)

            ' get ordinal positions in datareader
            Dim arrOrdinals As Integer() = GetOrdinals(objProperties, dr)

            Dim [Continue] As Boolean
            If ManageDataReader Then
                [Continue] = False
                ' read datareader
                If dr.Read() Then
                    [Continue] = True
                End If
            Else
                [Continue] = True
            End If

            If [Continue] Then
                ' create custom business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals)
            Else
                objFillObject = Nothing
            End If

            If ManageDataReader Then
                ' close datareader
                If Not dr Is Nothing Then
                    dr.Close()
                End If
            End If

            Return objFillObject

        End Function

        Public Shared Function FillCollection(ByVal dr As IDataReader, ByVal objType As Type) As ArrayList

            Dim objFillCollection As New ArrayList
            Dim objFillObject As Object

            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objType)

            ' get ordinal positions in datareader
            Dim arrOrdinals As Integer() = GetOrdinals(objProperties, dr)

            ' iterate datareader
            While dr.Read
                ' fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals)
                ' add to collection
                objFillCollection.Add(objFillObject)
            End While

            ' close datareader
            If Not dr Is Nothing Then
                dr.Close()
            End If

            Return objFillCollection

        End Function

        Public Shared Function FillCollection(ByVal dr As IDataReader, ByVal objType As Type, ByRef objToFill As IList) As IList

            Dim objFillObject As Object

            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objType)

            ' get ordinal positions in datareader
            Dim arrOrdinals As Integer() = GetOrdinals(objProperties, dr)

            ' iterate datareader
            While dr.Read
                ' fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals)
                ' add to collection
                objToFill.Add(objFillObject)
            End While

            ' close datareader
            If Not dr Is Nothing Then
                dr.Close()
            End If

            Return objToFill

        End Function

        Public Shared Function InitializeObject(ByVal objObject As Object, ByVal objType As Type) As Object

            Dim objPropertyInfo As PropertyInfo
            Dim objValue As Object
            Dim intProperty As Integer

            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objType)

            ' initialize properties
            For intProperty = 0 To objProperties.Count - 1
                objPropertyInfo = CType(objProperties(intProperty), PropertyInfo)
                If objPropertyInfo.CanWrite Then
                    objValue = Null.SetNull(objPropertyInfo)
                    objPropertyInfo.SetValue(objObject, objValue, Nothing)
                End If
            Next intProperty

            Return objObject

        End Function



        Public Shared Function Serialize(ByVal objObject As Object) As XmlDocument

            Dim objXmlSerializer As New XmlSerializer(objObject.GetType())

            Dim objStringBuilder As New StringBuilder

            Dim objTextWriter As TextWriter = New StringWriter(objStringBuilder)

            objXmlSerializer.Serialize(objTextWriter, objObject)

            Dim objStringReader As New StringReader(objTextWriter.ToString())

            Dim objDataSet As New DataSet

            objDataSet.ReadXml(objStringReader)

            Dim xmlSerializedObject As New XmlDocument

            xmlSerializedObject.LoadXml(objDataSet.GetXml())

            Return xmlSerializedObject

        End Function
#End Region
#Region "Generic Methods"

        ' -----------------------------------------------------------------------------
        ' <summary>
        ' Generic version of CreateObject creates an object of a specified type from the 
        ' provided DataReader
        ' </summary>
        ' <typeparam name="T">The type of the business object</typeparam>
        ' <param name="dr">The DataReader</param>
        ' <returns>The custom business object</returns>
        ' <remarks></remarks>
        ' <history>
        ' 	[cnurse]	10/10/2005	Created
        ' </history>
        ' -----------------------------------------------------------------------------
        Private Shared Function CreateObject(Of T)(ByVal dr As IDataReader) As T

            Dim objPropertyInfo As PropertyInfo
            Dim objValue As Object
            Dim objPropertyType As Type = Nothing
            Dim intProperty As Integer

            Dim objObject As T = Activator.CreateInstance(Of T)()

            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objObject.GetType)

            ' get ordinal positions in datareader
            Dim arrOrdinals As Integer() = GetOrdinals(objProperties, dr)

            ' fill object with values from datareader
            For intProperty = 0 To objProperties.Count - 1
                objPropertyInfo = CType(objProperties(intProperty), PropertyInfo)
                If objPropertyInfo.CanWrite Then
                    objValue = Null.SetNull(objPropertyInfo)
                    If arrOrdinals(intProperty) <> -1 Then
                        If IsDBNull(dr.GetValue(arrOrdinals(intProperty))) Then
                            ' translate Null value
                            objPropertyInfo.SetValue(objObject, objValue, Nothing)
                        Else
                            Try
                                ' try implicit conversion first
                                objPropertyInfo.SetValue(objObject, dr.GetValue(arrOrdinals(intProperty)), Nothing)
                            Catch
                                ' business object info class member data type does not match datareader member data type
                                Try
                                    objPropertyType = objPropertyInfo.PropertyType
                                    'need to handle enumeration conversions differently than other base types
                                    If objPropertyType.BaseType.Equals(GetType(System.Enum)) Then
                                        ' check if value is numeric and if not convert to integer ( supports databases like Oracle )
                                        If IsNumeric(dr.GetValue(arrOrdinals(intProperty))) Then
                                            CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, System.Enum.ToObject(objPropertyType, Convert.ToInt32(dr.GetValue(arrOrdinals(intProperty)))), Nothing)
                                        Else
                                            CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, System.Enum.ToObject(objPropertyType, dr.GetValue(arrOrdinals(intProperty))), Nothing)
                                        End If
                                    Else
                                        ' try explicit conversion
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals(intProperty)), objPropertyType), Nothing)
                                    End If
                                Catch
                                    objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals(intProperty)), objPropertyType), Nothing)
                                End Try
                            End Try
                        End If
                    Else
                        ' property does not exist in datareader
                    End If
                End If
            Next intProperty

            Return objObject

        End Function

        ' -----------------------------------------------------------------------------
        ' <summary>
        ' Generic version of FillCollection fills a List custom business object of a specified type 
        ' from the supplied DataReader
        ' </summary>
        ' <typeparam name="T">The type of the business object</typeparam>
        ' <param name="dr">The IDataReader to use to fill the object</param>
        ' <returns>A List of custom business objects</returns>
        ' <remarks></remarks>
        ' <history>
        ' 	[cnurse]	10/10/2005	Created
        ' </history>
        ' -----------------------------------------------------------------------------
        Public Shared Function FillCollection(Of T)(ByVal dr As IDataReader) As List(Of T)

            Dim objFillCollection As New List(Of T)
            Dim objFillObject As T

            ' iterate datareader
            While dr.Read
                ' fill business object
                objFillObject = CreateObject(Of T)(dr)
                ' add to collection
                objFillCollection.Add(objFillObject)
            End While

            ' close datareader
            If Not dr Is Nothing Then
                dr.Close()
            End If

            Return objFillCollection

        End Function

        ' -----------------------------------------------------------------------------
        ' <summary>
        ' Generic version of FillCollection fills a provided IList with custom business 
        ' objects of a specified type from the supplied DataReader
        ' </summary>
        ' <typeparam name="T">The type of the business object</typeparam>
        ' <param name="dr">The IDataReader to use to fill the object</param>
        ' <param name="objToFill">The IList to fill</param>
        ' <returns>An IList of custom business objects</returns>
        ' <remarks></remarks>
        ' <history>
        ' 	[cnurse]	10/10/2005	Created
        ' </history>
        ' -----------------------------------------------------------------------------
        Public Shared Function FillCollection(Of T)(ByVal dr As IDataReader, ByRef objToFill As IList(Of T)) As IList(Of T)

            Dim objFillObject As T

            ' iterate datareader
            While dr.Read
                ' fill business object
                objFillObject = CreateObject(Of T)(dr)
                ' add to collection
                objToFill.Add(objFillObject)
            End While

            ' close datareader
            If Not dr Is Nothing Then
                dr.Close()
            End If

            Return objToFill

        End Function

        ' -----------------------------------------------------------------------------
        ' <summary>
        ' Generic version of FillObject fills a custom business object of a specified type 
        ' from the supplied DataReader
        ' </summary>
        ' <typeparam name="T">The type of the object</typeparam>
        ' <param name="dr">The IDataReader to use to fill the object</param>
        ' <returns>The object</returns>
        ' <remarks>This overloads sets the ManageDataReader parameter to true and calls 
        ' the other overload</remarks>
        ' <history>
        ' 	[cnurse]	10/10/2005	Created
        ' </history>
        ' -----------------------------------------------------------------------------
        Public Shared Function FillObject(Of T)(ByVal dr As IDataReader) As T

            Return FillObject(Of T)(dr, True)

        End Function

        ' -----------------------------------------------------------------------------
        ' <summary>
        ' Generic version of FillObject fills a custom business object of a specified type 
        ' from the supplied DataReader
        ' </summary>
        ' <typeparam name="T">The type of the object</typeparam>
        ' <param name="dr">The IDataReader to use to fill the object</param>
        ' <param name="ManageDataReader">A boolean that determines whether the DatReader
        ' is managed</param>
        ' <returns>The object</returns>
        ' <remarks>This overloads allows the caller to determine whether the ManageDataReader 
        ' parameter is set</remarks>
        ' <history>
        ' 	[cnurse]	10/10/2005	Created
        ' </history>
        ' -----------------------------------------------------------------------------
        Public Shared Function FillObject(Of T)(ByVal dr As IDataReader, ByVal ManageDataReader As Boolean) As T

            Dim objFillObject As T

            Dim [Continue] As Boolean
            If ManageDataReader Then
                [Continue] = False
                ' read datareader
                If dr.Read() Then
                    [Continue] = True
                End If
            Else
                [Continue] = True
            End If

            If [Continue] Then
                ' create custom business object
                objFillObject = CreateObject(Of T)(dr)
            Else
                objFillObject = Nothing
            End If

            If ManageDataReader Then
                ' close datareader
                If Not dr Is Nothing Then
                    dr.Close()
                End If
            End If

            Return objFillObject

        End Function

#End Region
    End Class
End Namespace
