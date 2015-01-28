Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IwcfSchool" in both code and config file together.
<ServiceContract()>
Public Interface IwcfSchool

    <OperationContract()>
    <WebInvoke(Method:="POST", _
    BodyStyle:=WebMessageBodyStyle.Wrapped, _
    RequestFormat:=WebMessageFormat.Json, _
    ResponseFormat:=WebMessageFormat.Json)> _
    Function ListCountries() As List(Of vwCountry)

    <OperationContract()>
    <WebInvoke(Method:="POST", _
    BodyStyle:=WebMessageBodyStyle.Wrapped, _
    RequestFormat:=WebMessageFormat.Json, _
    ResponseFormat:=WebMessageFormat.Json)> _
    Function ListSchools() As List(Of vwSchool)


End Interface
