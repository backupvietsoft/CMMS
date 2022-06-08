Imports System.Reflection

Public Class QDynamicInvoke

    Public Shared Function InvokeMethodSlow(ByVal AssemblyName As String, ByVal ClassName As String, ByVal MethodName As String, ByVal args As Object()) As Object
        Try
            Dim _assembly As Assembly = Assembly.LoadFrom(AssemblyName)
            For Each type As Type In _assembly.GetTypes
                If type.IsClass = True Then
                    If type.FullName.EndsWith("." + ClassName) Then
                        Dim ClassObj As Object = Activator.CreateInstance(type)
                        Dim Result As Object = type.InvokeMember(MethodName, BindingFlags.Default Or BindingFlags.InvokeMethod, Nothing, ClassObj, args)
                        Return (Result)
                    End If
                End If
            Next
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString)
        End Try
        Throw (New System.Exception("could not invoke method"))
    End Function

    Public Shared Function InvokeNewForm(ByVal AssemblyName As String, ByVal ClassName As String, ByVal MethodName As String, ByVal args As Object()) As Object
        Try
            Dim _assembly As Assembly = Assembly.LoadFrom(AssemblyName)
            For Each type As Type In _assembly.GetTypes
                If type.IsClass = True Then
                    If type.FullName.EndsWith(ClassName) Then
                        Dim ClassObj As Object = Activator.CreateInstance(type)
                        'Dim Result As Object = type.InvokeMember(MethodName, BindingFlags.Default Or BindingFlags.InvokeMethod, Nothing, ClassObj, args)
                        Return (ClassObj)
                    End If
                End If
            Next
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString)
        End Try
        Return Nothing
    End Function

    Public Class DynaClassInfo
        Public type As Type
        Public ClassObject As Object

        Public Sub New()
        End Sub

        Public Sub New(ByVal t As Type, ByVal c As Object)
            type = t
            ClassObject = c
        End Sub
    End Class

    Public Shared AssemblyReferences As Hashtable = New Hashtable
    Public Shared ClassReferences As Hashtable = New Hashtable

    Public Shared Function GetClassReference(ByVal AssemblyName As String, ByVal ClassName As String) As DynaClassInfo
        If ClassReferences.ContainsKey(AssemblyName) = False Then
            Dim _assembly As Assembly
            If AssemblyReferences.ContainsKey(AssemblyName) = False Then
                _assembly = Assembly.LoadFrom(AssemblyName)
                AssemblyReferences.Add(AssemblyName, _assembly)
            Else
                _assembly = CType(AssemblyReferences(AssemblyName), Assembly)
            End If
            For Each type As Type In _assembly.GetTypes
                If type.IsClass = True Then
                    If type.FullName.EndsWith("." + ClassName) Then
                        Dim ci As DynaClassInfo = New DynaClassInfo(type, Activator.CreateInstance(type))
                        ClassReferences.Add(AssemblyName, ci)
                        Return (ci)
                    End If
                End If
            Next
            Throw (New System.Exception("could not instantiate class"))
        End If
        Return CType(ClassReferences(AssemblyName), DynaClassInfo)
    End Function

    Public Shared Function InvokeMethod(ByVal ci As DynaClassInfo, ByVal MethodName As String, ByVal args As Object()) As Object
        Dim Result As Object = ci.type.InvokeMember(MethodName, BindingFlags.Default Or BindingFlags.InvokeMethod, Nothing, ci.ClassObject, args)
        Return (Result)
    End Function

    Public Shared Function InvokeMethod(ByVal AssemblyName As String, ByVal ClassName As String, ByVal MethodName As String, ByVal args As Object()) As Object
        Dim ci As DynaClassInfo = GetClassReference(AssemblyName, ClassName)
        Return (InvokeMethod(ci, MethodName, args))
    End Function

End Class