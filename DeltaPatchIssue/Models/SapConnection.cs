using System.Runtime.Serialization;

namespace DeltaPatchIssue.Models;

[DataContract]
public class SapConnection : ErpConnection
{
    public SapConnection()
    {
    }

    [DataMember(Name = "SapConnectionUrl")]
    public string? SapConnectionUrl { get; set; }
}