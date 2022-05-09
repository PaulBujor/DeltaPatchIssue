using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DeltaPatchIssue.Models;

/*
 *  JsonVersion of SomeSystem with a SapConnection subobject
 * {
        "Name": "SomeSapSystem",
        "Connection": {
            "@odata.type": "#DeltaPatchIssue.Models.SapConnection",
            "SapConnectionUrl": "http://something.com",
            "ConnectionName": "SapConnection"
        }
    }
 */

[DataContract]
public class SomeSystem
{
    [Key]
    [DataMember(Name = "Key")] public string? Key { get; set; }

    [DataMember(Name = "Name")] public string? Name { get; set; }

    [DataMember(Name = "Connection")] public ErpConnection? Connection { get; set; }
}