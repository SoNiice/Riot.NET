using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LorStatusV1.Responses;

public struct StatusDTO
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("maintenance_status")] public MaintenanceStatus MaintenanceStatus { get; set; }
    [JsonProperty("incident_severity")] public IncidentSeverity IncidentSeverity { get; set; }
    [JsonProperty("titles")] public List<ContentDTO> Titles { get; set; }
    [JsonProperty("updates")] public List<UpdateDTO> Updates { get; set; }

    [JsonProperty("created_at")]
    [JsonConverter(typeof(DateTimeConverterFromString))]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("archive_at")]
    [JsonConverter(typeof(DateTimeConverterFromString))]
    public DateTime ArchiveAt { get; set; }

    [JsonProperty("updated_at")]
    [JsonConverter(typeof(DateTimeConverterFromString))]
    public DateTime UpdatedAt { get; set; }
}