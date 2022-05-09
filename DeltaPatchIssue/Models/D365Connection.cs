using System.Runtime.Serialization;

namespace DeltaPatchIssue.Models;

[DataContract]
public class D365Connection : ErpConnection
{
    public D365Connection()
    {
    }

    [DataMember(Name = "D365ConnectionUrl")]
    public string? D365ConnectionUrl { get; set; }
}