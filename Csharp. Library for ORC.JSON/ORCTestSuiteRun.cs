using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestSuiteRun
{
    [JsonProperty("test_suite_uid")] public readonly string SuiteId;
    [JsonProperty("test_suite_run_uid")] public readonly string Id;
    [JsonProperty("test_suite_run_name")] public readonly string Name;
    [JsonProperty("created_at")] [JsonConverter(typeof(DateFormatConverter) )] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] [JsonConverter(typeof(DateFormatConverter) )] public DateTimeOffset Updated;
    [JsonProperty("started_at")] [JsonConverter(typeof(DateFormatConverter) )] public readonly DateTimeOffset Started;
    [JsonProperty("ended_at")] [JsonConverter(typeof(DateFormatConverter) )] public readonly DateTimeOffset Ended;
    [JsonProperty("run_status")] public OrcRunStatus Status;
    [JsonProperty("test_cases_runs")] public IEnumerable<ORCTestCaseRun> TestCaseRuns;
    [JsonProperty("tags")] public IEnumerable<ORCParameter> Tags;
    [JsonProperty("extended_parameters")] public IEnumerable<ORCParameter> ExtParameters;
    [JsonProperty("attachments")] public IEnumerable<ORCAttachment> Attachments;
    [JsonProperty("runners")] public IEnumerable<ORCRunner> Runners;

    public ORCTestSuiteRun(string suiteId = "", string id = "", string name = "",
        DateTimeOffset? created = null, DateTimeOffset? updated = null, DateTimeOffset? started = null, DateTimeOffset? ended = null,
        OrcRunStatus status = OrcRunStatus.ORC_RUN_STATUS_TODO, IEnumerable<ORCTestCaseRun>? caseRuns = null,
        IEnumerable<ORCParameter>? tags = null, IEnumerable<ORCParameter>? parameters = null,
        IEnumerable<ORCAttachment>? attachments = null, IEnumerable<ORCRunner>? runners = null)
    {
        SuiteId = suiteId;
        Id = id;
        Name = name;
        Created = created ?? DateTimeOffset.Now;
        Updated = updated ?? DateTimeOffset.Now;
        Started = started ?? DateTimeOffset.Now;
        Ended = ended ?? DateTimeOffset.Now;
        TestCaseRuns = caseRuns ?? Array.Empty<ORCTestCaseRun>();
        Tags = tags ?? Array.Empty<ORCParameter>();
        ExtParameters = parameters ?? Array.Empty<ORCParameter>();
        Attachments = attachments ?? Array.Empty<ORCAttachment>();
        Runners = runners ?? Array.Empty<ORCRunner>();
        Status = status;
    }

    public void AddCaseRun(ORCTestCaseRun tcRun)
    {
        TestCaseRuns = TestCaseRuns.Append(tcRun);
    }
}