using System.Runtime.Serialization;

namespace DeltaPatchIssue.Models;

public abstract class ErpConnection
{
    protected ErpConnection()
    {
    }

    [DataMember(Name = "ConnectionName")] public string? ConnectionName { get; set; }
}