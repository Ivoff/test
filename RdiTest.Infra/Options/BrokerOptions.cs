namespace Infra.Options;

public class BrokerOptions
{
    public const string SectionName = "Broker"; 
    
    public required string Host { get; set; }
    public required ushort Port { get; set; }
    public required string User { get; set; }
    public required string Password { get; set; }
}