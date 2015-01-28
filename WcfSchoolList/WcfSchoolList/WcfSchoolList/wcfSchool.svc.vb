Imports System.Runtime.Serialization.Json
Imports Newtonsoft.Json
Imports System.Web.Script.Serialization


''' <summary>
''' View of Coutry
''' </summary>
''' <remarks></remarks>
'<DataContract()> _
'Public Class vwCountry
'    <DataMember()> _
'    Private _CountryCode As String
'    Public Property CountryCode() As String
'        Get
'            Return _CountryCode
'        End Get
'        Set(ByVal value As String)
'            _CountryCode = value
'        End Set
'    End Property
'    <DataMember()> _
'    Private _CountryName As String
'    Public Property CountryName() As String
'        Get
'            Return _CountryName
'        End Get
'        Set(ByVal value As String)
'            _CountryName = value
'        End Set
'    End Property
'End Class
''' <summary>
''' View of School
''' </summary>
''' <remarks></remarks>
'Public Class vwSchool
'    Private _CountryCode As String
'    Public Property CountryCode() As String
'        Get
'            Return _CountryCode
'        End Get
'        Set(ByVal value As String)
'            _CountryCode = value
'        End Set
'    End Property

'    Private _CountryName As String
'    Public Property CountryName() As String
'        Get
'            Return _CountryName
'        End Get
'        Set(ByVal value As String)
'            _CountryName = value
'        End Set
'    End Property

'    Private _ID As String
'    Public Property ID() As String
'        Get
'            Return _ID
'        End Get
'        Set(ByVal value As String)
'            _ID = value
'        End Set
'    End Property

'    Private _IsActive As String
'    Public Property IsActive() As String
'        Get
'            Return _IsActive
'        End Get
'        Set(ByVal value As String)
'            _IsActive = value
'        End Set
'    End Property

'    Private _IsMultiSchool As String
'    Public Property IsMultiSchool() As String
'        Get
'            Return _IsMultiSchool
'        End Get
'        Set(ByVal value As String)
'            _IsMultiSchool = value
'        End Set
'    End Property

'    Private _Location As String
'    Public Property Location() As String
'        Get
'            Return _Location
'        End Get
'        Set(ByVal value As String)
'            _Location = value
'        End Set
'    End Property

'    Private _SchoolName As String
'    Public Property SchoolName() As String
'        Get
'            Return _SchoolName
'        End Get
'        Set(ByVal value As String)
'            _SchoolName = value
'        End Set
'    End Property

'    Private _ServiceURL As String
'    Public Property ServiceURL() As String
'        Get
'            Return _ServiceURL
'        End Get
'        Set(ByVal value As String)
'            _ServiceURL = value
'        End Set
'    End Property

'    Private _StaffDomain As String
'    Public Property StaffDomain() As String
'        Get
'            Return _StaffDomain
'        End Get
'        Set(ByVal value As String)
'            _StaffDomain = value
'        End Set
'    End Property

'    Private _StudentDomain As String
'    Public Property StudentDomain() As String
'        Get
'            Return _StudentDomain
'        End Get
'        Set(ByVal value As String)
'            _StudentDomain = value
'        End Set
'    End Property

'    Private _Version As String
'    Public Property Version() As String
'        Get
'            Return _Version
'        End Get
'        Set(ByVal value As String)
'            _Version = value
'        End Set
'    End Property

'End Class

<DataContract()> _
Public Class vwCountry
    <DataMember()> _
    Public CountryCode As Int64 = 0
    <DataMember()> _
    Public CountryName As String = String.Empty
End Class

<DataContract()> _
Public Class vwSchool
    <DataMember()> _
    Public ID As Int64 = 0
    <DataMember()> _
    Public CountryCode As Int64 = 0
    <DataMember()> _
    Public SchoolName As String = String.Empty
    <DataMember()> _
    Public IsActive As Boolean = False
    <DataMember()> _
    Public Location As String = String.Empty
    <DataMember()> _
    Public StaffDomain As String = String.Empty
    <DataMember()> _
    Public StudentDomain As String = String.Empty
    <DataMember()> _
    Public ServiceURL As String = String.Empty
    <DataMember()> _
    Public CountryName As String = String.Empty
    <DataMember()> _
    Public IsMultiSchool As Boolean = False
    <DataMember()> _
    Public Version As String = False
End Class

' NOTE: You can use the "Rename" command on the context menu to change the class name "wcfSchool" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select wcfSchool.svc or wcfSchool.svc.vb at the Solution Explorer and start debugging.
Public Class wcfSchool
    Implements IwcfSchool

    ''' <summary>
    ''' Get list of country
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListCountries() As List(Of vwCountry) Implements IwcfSchool.ListCountries
        Dim pathAppData As String = ConfigurationManager.AppSettings.Get("DataDirectory").ToString()
        Dim fileName As String = pathAppData & "\json_country.txt"
        Dim strJson As String = ""
        Dim jss As New JavaScriptSerializer
        If System.IO.File.Exists(fileName) = True Then
            Dim objReader As New System.IO.StreamReader(fileName)
            Do While objReader.Peek() <> -1
                strJson = strJson & objReader.ReadLine() & vbNewLine
            Loop
        End If
        Dim lstOfCountry As Generic.List(Of vwCountry) = jss.Deserialize(Of List(Of vwCountry))(strJson)

        Return lstOfCountry
    End Function

    ''' <summary>
    ''' Get list of school
    ''' </summary>
    ''' <returns></returns>s
    ''' <remarks></remarks>
    Public Function ListSchools() As List(Of vwSchool) Implements IwcfSchool.ListSchools
        Dim pathAppData As String = ConfigurationManager.AppSettings.Get("DataDirectory").ToString()
        Dim fileName As String = pathAppData & "\json_school.txt"
        Dim strJson As String = ""
        Dim jss As New JavaScriptSerializer
        If System.IO.File.Exists(fileName) = True Then
            Dim objReader As New System.IO.StreamReader(fileName)
            Do While objReader.Peek() <> -1
                strJson = strJson & objReader.ReadLine() & vbNewLine
            Loop
        End If
        Dim lstOfSchool As Generic.List(Of vwSchool) = jss.Deserialize(Of List(Of vwSchool))(strJson)

        Return lstOfSchool
    End Function


End Class
