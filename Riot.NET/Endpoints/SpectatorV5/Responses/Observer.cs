using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorV5.Responses;

public struct Observer
{
    [JsonProperty("encryptionKey")] public string EncryptionKey { get; set; }
}