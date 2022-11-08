using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCaseStepRun
{
    [JsonProperty("test_suite_uid")] public readonly string SuiteId;
    [JsonProperty("test_suite_run_uid")] public readonly string RunId;
    [JsonProperty("test_case_uid")] public readonly string CaseId;
    [JsonProperty("test_case_run_uid")] public int CaseRunId;
    [JsonProperty("test_case_step_uid")] public readonly string StepId;
    [JsonProperty("test_case_step_run_uid")] public int Id;
    [JsonProperty("created_at")] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] public DateTimeOffset Updated;
    [JsonProperty("started_at")] public readonly DateTimeOffset Started;
    [JsonProperty("ended_at")] public readonly DateTimeOffset Ended;
    [JsonProperty("run_status")] public OrcRunStatus Status;
    [JsonProperty("tags")] public ORCParameter[] Tags;
    [JsonProperty("extended_parameters")] public ORCParameter[] ExtParameters;
    [JsonProperty("attachments")] public ORCAttachment[] Attachments;
    [JsonProperty("runners")] public ORCRunner[] Runners;
    
    public ORCTestCaseStepRun()
    {
        SuiteId = "";
        RunId = "";
        CaseId = "";
        CaseRunId = 1;
        StepId = "";
        Id = 1;
        Created = DateTimeOffset.Now;
        Updated = DateTimeOffset.Now;
        Started = DateTimeOffset.Now;
        Ended = DateTimeOffset.Now;
        Status = OrcRunStatus.ORC_RUN_STATUS_TODO;
        Tags = Array.Empty<ORCParameter>();
        ExtParameters = Array.Empty<ORCParameter>();
        Attachments = Array.Empty<ORCAttachment>();
        Runners = Array.Empty<ORCRunner>();
    }
}