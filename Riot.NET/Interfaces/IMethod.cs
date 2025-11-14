namespace Riot.NET.Interfaces;

internal interface IMethod<TResponse>
{
    public string Url { get; }
    public Task<TResponse> ExecuteAsync();
    public TResponse Execute();
}