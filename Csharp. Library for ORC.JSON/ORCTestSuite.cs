using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestSuite
{
    [JsonProperty("test_suite_uid")] public readonly string Id;
    [JsonProperty("test_suite_name")] public readonly string Name;
    [JsonProperty("created_at")] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] public DateTimeOffset Updated;
    [JsonProperty("test_cases")] public ORCTestCase[] TestCases;
    [JsonProperty("tags")] public ORCParameter[] Tags;
    [JsonProperty("extended_parameters")] public ORCParameter[] ExtParameters;
    [JsonProperty("attachments")] public ORCAttachment[] Attachments;
    [JsonProperty("runners")] public ORCRunner[] Runners;

    public ORCTestSuite()
    {
    }
    
    
}