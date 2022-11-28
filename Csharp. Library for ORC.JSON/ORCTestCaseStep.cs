using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

[Serializable]
public class ORCTestCaseStep
{
    [JsonProperty("test_suite_uid")] public string SuiteId;
    [JsonProperty("test_case_uid")] public string CaseId;
    [JsonProperty("test_case_step_uid")] public readonly string Id;
    [JsonProperty("test_case_step_name")] public readonly string Name;
    [JsonProperty("test_case_step_max_runs_count")] public int MaxRuns;
    [JsonProperty("created_at")] [JsonConverter(typeof(DateFormatConverter))] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] [JsonConverter(typeof(DateFormatConverter))] public DateTimeOffset Updated;
    [JsonProperty("tags")] public IEnumerable<ORCParameter> Tags;
    [JsonProperty("extended_parameters")] public IEnumerable<ORCParameter> ExtParameters;
    [JsonProperty("attachments")] public IEnumerable<ORCAttachment> Attachments;
    [JsonProperty("runners")] public IEnumerable<ORCRunner> Runners;

    public ORCTestCaseStep(string suiteId = "", string caseId = "", string id = "", string name = "", int maxRuns = 1,
        DateTimeOffset? created = null, DateTimeOffset? updated = null,
        IEnumerable<ORCParameter>? tags = null, IEnumerable<ORCParameter>? parameters = null,
        IEnumerable<ORCAttachment>? attachments = null, IEnumerable<ORCRunner>? runners = null)
    {
        SuiteId = suiteId;
        CaseId = caseId;
        Id = id;
        Name = name;
        MaxRuns = maxRuns;
        Created = created ?? DateTimeOffset.Now;
        Updated = updated ?? DateTimeOffset.Now;
        Tags = tags ?? Array.Empty<ORCParameter>();
        ExtParameters = parameters ?? Array.Empty<ORCParameter>();
        Attachments = attachments ?? Array.Empty<ORCAttachment>();
        Runners = runners ?? Array.Empty<ORCRunner>();
    }
}
