using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorTftV5.Responses;

public struct Observer
{
    [JsonProperty("encryptionKey")] public string EncryptionKey { get; set; }
}