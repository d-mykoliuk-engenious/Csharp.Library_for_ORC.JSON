using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCaseRun
{
    [JsonProperty("test_suite_uid")] public readonly string SuiteId;
    [JsonProperty("test_suite_run_uid")] public readonly string RunId;
    [JsonProperty("test_case_uid")] public readonly string CaseId;
    [JsonProperty("test_case_run_uid")] public readonly string Id;
    [JsonProperty("created_at")] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] public DateTimeOffset Updated;
    [JsonProperty("started_at")] public readonly DateTimeOffset Started;
    [JsonProperty("ended_at")] public readonly DateTimeOffset Ended;
    [JsonProperty("run_status")] public OrcRunStatus Status;
    [JsonProperty("pre_test_steps_runs")] public ORCTestCaseStepRun[] PreStepsRuns;
    [JsonProperty("test_steps_runs")] public ORCTestCaseStepRun[] StepsRuns;
    [JsonProperty("post_test_steps_runs")] public ORCTestCaseStepRun[] PostStepsRuns;
    [JsonProperty("tags")] public ORCParameter[] Tags;
    [JsonProperty("extended_parameters")] public ORCParameter[] ExtParameters;
    [JsonProperty("attachments")] public ORCAttachment[] Attachments;
    [JsonProperty("runners")] public ORCRunner[] Runners;

    public ORCTestCaseRun(ORCTestCase parentCase)
    {
        Id = RandomGenerator.GetRandomId();
    }
}