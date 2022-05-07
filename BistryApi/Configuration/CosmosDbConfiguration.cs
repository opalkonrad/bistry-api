namespace BistryApi.Configuration;

public class CosmosDbConfiguration
{
    public string Uri { get; set; }

    public string Key { get; set; }

    public string DatabaseName { get; set; }

    public string ContainerName { get; set; }
}
