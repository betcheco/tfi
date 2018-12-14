Imports System.ComponentModel

Public Class Charts
    Public Shared Function ToDataTable(Of T)(data As IList(Of T)) As DataTable
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim dt As New DataTable()
        For i As Integer = 0 To properties.Count - 1
            Dim [property] As PropertyDescriptor = properties(i)
            dt.Columns.Add([property].Name, [property].PropertyType)
        Next
        Dim values As Object() = New Object(properties.Count - 1) {}
        For Each item As T In data
            For i As Integer = 0 To values.Length - 1
                values(i) = properties(i).GetValue(item)
            Next
            dt.Rows.Add(values)
        Next
        Return dt
    End Function

    Public Shared Function DicToDataTable(dic As Dictionary(Of String, Integer), keyName As String) As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add(keyName, GetType(String))
        dt.Columns.Add("value", GetType(Integer))

        For Each kvp As KeyValuePair(Of String, Integer) In dic
            Dim key As String = kvp.Key.ToString
            Dim value As Integer = kvp.Value

            Dim values As Object() = New Object(1) {}
            values(0) = key
            values(1) = value
            dt.Rows.Add(values)
        Next

        Return dt
    End Function
End Class
