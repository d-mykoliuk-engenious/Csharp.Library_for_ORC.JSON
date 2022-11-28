using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Csharp._Library_for_ORC.JSON;

[Serializable]
public class ORCTestCaseStepRun
{
    [JsonProperty("test_suite_uid")] public string SuiteId;
    [JsonProperty("test_suite_run_uid")] public string SuiteRunId;
    [JsonProperty("test_case_uid")] public string CaseId;
    [JsonProperty("test_case_run_uid")] public int CaseRunId;
    [JsonProperty("test_case_step_uid")] public readonly string StepId;
    [JsonProperty("test_case_step_run_uid")] public int Id;
    [JsonProperty("created_at")] [JsonConverter(typeof(DateFormatConverter) )] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] [JsonConverter(typeof(DateFormatConverter) )] public DateTimeOffset Updated;
    [JsonProperty("started_at")] [JsonConverter(typeof(DateFormatConverter) )] public readonly DateTimeOffset Started;
    [JsonProperty("ended_at")] [JsonConverter(typeof(DateFormatConverter) )] public readonly DateTimeOffset Ended;
    [JsonProperty("run_status")] [JsonConverter(typeof(StringEnumConverter))] public OrcRunStatus Status;
    [JsonProperty("tags")] public IEnumerable<ORCParameter> Tags;
    [JsonProperty("extended_parameters")] public IEnumerable<ORCParameter> ExtParameters;
    [JsonProperty("attachments")] public IEnumerable<ORCAttachment> Attachments;
    [JsonProperty("runners")] public IEnumerable<ORCRunner> Runners;
    
    public ORCTestCaseStepRun(string suiteId = "", string suiteRunId = "", string caseId = "", int caseRunId = 1, string stepId = "", int id = 1,
        DateTimeOffset? created = null, DateTimeOffset? updated = null, DateTimeOffset? started = null, DateTimeOffset? ended = null,
        OrcRunStatus status = OrcRunStatus.ORC_RUN_STATUS_TODO,
        IEnumerable<ORCParameter>? tags = null, IEnumerable<ORCParameter>? parameters = null,
        IEnumerable<ORCAttachment>? attachments = null, IEnumerable<ORCRunner>? runners = null)
    {
        SuiteId = suiteId;
        SuiteRunId = suiteRunId;
        CaseId = caseId;
        CaseRunId = caseRunId;
        StepId = stepId;
        Id = id;
        Created = created ?? DateTimeOffset.Now;
        Updated = updated ?? DateTimeOffset.Now;
        Started = started ?? DateTimeOffset.Now;
        Ended = ended ?? DateTimeOffset.Now;
        Status = status;
        Tags = tags ?? Array.Empty<ORCParameter>();
        ExtParameters = parameters ?? Array.Empty<ORCParameter>();
        Attachments = attachments ?? Array.Empty<ORCAttachment>();
        Runners = runners ?? Array.Empty<ORCRunner>();
    }
}