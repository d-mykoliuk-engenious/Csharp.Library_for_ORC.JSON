using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Csharp._Library_for_ORC.JSON;

[Serializable]
public class ORCTestCaseRun
{
    [JsonProperty("test_suite_uid")] public string SuiteId;
    [JsonProperty("test_suite_run_uid")] public string SuiteRunId;
    [JsonProperty("test_case_uid")] public readonly string CaseId;
    [JsonProperty("test_case_run_uid")] public int Id;
    [JsonProperty("created_at")] [JsonConverter(typeof(DateFormatConverter))] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] [JsonConverter(typeof(DateFormatConverter))] public DateTimeOffset Updated;
    [JsonProperty("started_at")] [JsonConverter(typeof(DateFormatConverter))] public readonly DateTimeOffset Started;
    [JsonProperty("ended_at")] [JsonConverter(typeof(DateFormatConverter))] public readonly DateTimeOffset Ended;
    [JsonProperty("run_status")] [JsonConverter(typeof(StringEnumConverter))] public OrcRunStatus Status;
    [JsonProperty("pre_test_steps_runs")] public IEnumerable<ORCTestCaseStepRun> PreStepsRuns;
    [JsonProperty("test_steps_runs")] public IEnumerable<ORCTestCaseStepRun> StepsRuns;
    [JsonProperty("post_test_steps_runs")] public IEnumerable<ORCTestCaseStepRun> PostStepsRuns;
    [JsonProperty("tags")] public IEnumerable<ORCParameter> Tags;
    [JsonProperty("extended_parameters")] public IEnumerable<ORCParameter> ExtParameters;
    [JsonProperty("attachments")] public IEnumerable<ORCAttachment> Attachments;
    [JsonProperty("runners")] public IEnumerable<ORCRunner> Runners;

    public ORCTestCaseRun(string suiteId = "", string suiteRunId = "", string caseId = "", int id = 1,
        IEnumerable<ORCTestCaseStepRun>? preSteps = null, IEnumerable<ORCTestCaseStepRun>? steps = null, IEnumerable<ORCTestCaseStepRun>? postSteps = null,
        DateTimeOffset? created = null, DateTimeOffset? updated = null, DateTimeOffset? started = null, DateTimeOffset? ended = null,
        OrcRunStatus status = OrcRunStatus.ORC_RUN_STATUS_TODO,
        IEnumerable<ORCParameter>? tags = null, IEnumerable<ORCParameter>? parameters = null,
        IEnumerable<ORCAttachment>? attachments = null, IEnumerable<ORCRunner>? runners = null)
    {
        SuiteId = suiteId;
        SuiteRunId = suiteRunId;
        CaseId = caseId;
        Id = id;
        PreStepsRuns = preSteps ?? Array.Empty<ORCTestCaseStepRun>();
        StepsRuns = steps ?? Array.Empty<ORCTestCaseStepRun>();
        PostStepsRuns = postSteps ?? Array.Empty<ORCTestCaseStepRun>();
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

    internal void AddPreStepRun(ORCTestCaseStepRun stepRun)
    {
        var preStepRun = stepRun.DeepClone();
        AdaptStepRun(preStepRun);
        PreStepsRuns = PreStepsRuns.Append(preStepRun);
    }

    internal void AddStepRun(ORCTestCaseStepRun stepRun)
    {
        var regularStepRun = stepRun.DeepClone();
        AdaptStepRun(regularStepRun);
        StepsRuns = StepsRuns.Append(regularStepRun);
    }

    internal void AddPostStepRun(ORCTestCaseStepRun stepRun)
    {
        var postStepRun = stepRun.DeepClone();
        AdaptStepRun(postStepRun);
        PostStepsRuns = PostStepsRuns.Append(postStepRun);
    }

    private void AdaptStepRun(ORCTestCaseStepRun stepRun)
    {
        stepRun.CaseRunId = Id;
        stepRun.CaseId = CaseId;
        stepRun.SuiteId = SuiteId;
        stepRun.SuiteRunId = SuiteRunId;
    }
}