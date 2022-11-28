using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

[Serializable]
public class ORCTestSuite
{
    [JsonProperty("test_suite_uid")] public readonly string Id;
    [JsonProperty("test_suite_name")] public readonly string Name;
    [JsonProperty("created_at")] [JsonConverter(typeof(DateFormatConverter) )] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] [JsonConverter(typeof(DateFormatConverter) )] public DateTimeOffset Updated;
    [JsonProperty("test_cases")] public IEnumerable<ORCTestCase> TestCases;
    [JsonProperty("tags")] public IEnumerable<ORCParameter> Tags;
    [JsonProperty("extended_parameters")] public IEnumerable<ORCParameter> ExtParameters;
    [JsonProperty("attachments")] public IEnumerable<ORCAttachment> Attachments;
    [JsonProperty("runners")] public IEnumerable<ORCRunner> Runners;

    public ORCTestSuite(string id = "", string name = "",
        DateTimeOffset? created = null, DateTimeOffset? updated = null, IEnumerable<ORCTestCase>? cases = null,
        IEnumerable<ORCParameter>? tags = null, IEnumerable<ORCParameter>? parameters = null,
        IEnumerable<ORCAttachment>? attachments = null, IEnumerable<ORCRunner>? runners = null)
    {
        Id = id;
        Name = name;
        Created = created ?? DateTimeOffset.Now;
        Updated = updated ?? DateTimeOffset.Now;
        TestCases = cases ?? Array.Empty<ORCTestCase>();
        Tags = tags ?? Array.Empty<ORCParameter>();
        ExtParameters = parameters ?? Array.Empty<ORCParameter>();
        Attachments = attachments ?? Array.Empty<ORCAttachment>();
        Runners = runners ?? Array.Empty<ORCRunner>();
    }

    public void AddTestCase(ORCTestCase testCase)
    {
        testCase.SuiteId = Id;
        TestCases = TestCases.Append(testCase);
    }
}