using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCase
{
    [JsonProperty("test_suite_uid")] public string SuiteId;
    [JsonProperty("test_case_uid")] public readonly string Id;
    [JsonProperty("test_case_name")] public readonly string Name;
    [JsonProperty("test_case_max_runs_count")] public int MaxRuns;
    [JsonProperty("created_at")] [JsonConverter(typeof(DateFormatConverter))] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] [JsonConverter(typeof(DateFormatConverter))] public DateTimeOffset Updated;
    [JsonProperty("pre_test_steps")] public IEnumerable<ORCTestCaseStep> PreSteps;
    [JsonProperty("test_steps")] public IEnumerable<ORCTestCaseStep> Steps;
    [JsonProperty("post_test_steps")] public IEnumerable<ORCTestCaseStep> PostSteps;
    [JsonProperty("tags")] public IEnumerable<ORCParameter> Tags;
    [JsonProperty("extended_parameters")] public IEnumerable<ORCParameter> ExtParameters;
    [JsonProperty("attachments")] public IEnumerable<ORCAttachment> Attachments;
    [JsonProperty("runners")] public IEnumerable<ORCRunner> Runners;

    public ORCTestCase(string suiteId = "", string id = "", string name = "", int maxRuns = 1,
        DateTimeOffset? created = null, DateTimeOffset? updated = null,
        IEnumerable<ORCTestCaseStep>? preSteps = null, IEnumerable<ORCTestCaseStep>? steps = null, IEnumerable<ORCTestCaseStep>? postSteps = null,
        IEnumerable<ORCParameter>? tags = null, IEnumerable<ORCParameter>? parameters = null,
        IEnumerable<ORCAttachment>? attachments = null, IEnumerable<ORCRunner>? runners = null)
    {
        SuiteId = suiteId;
        Id = id;
        Name = name;
        MaxRuns = maxRuns;
        Created = created ?? DateTimeOffset.Now;
        Updated = updated ?? DateTimeOffset.Now;
        PreSteps = preSteps ?? Array.Empty<ORCTestCaseStep>();
        Steps = steps ?? Array.Empty<ORCTestCaseStep>();
        PostSteps = postSteps ?? Array.Empty<ORCTestCaseStep>();
        Tags = tags ?? Array.Empty<ORCParameter>();
        ExtParameters = parameters ?? Array.Empty<ORCParameter>();
        Attachments = attachments ?? Array.Empty<ORCAttachment>();
        Runners = runners ?? Array.Empty<ORCRunner>();
    }

    public ORCTestCase(ORCTestCaseRun caseRun)
    {
        // TODO: Implement this
    }

    internal void AddPreStep(ORCTestCaseStep preStep)
    {
        var newPreStep = AdaptStep(preStep.DeepClone());
        PreSteps = PreSteps.Append(newPreStep);
    }
    
    internal void AddStep(ORCTestCaseStep step)
    {
        var newStep = AdaptStep(step.DeepClone());
        Steps = Steps.Append(newStep);
    }
    
    internal void AddPostStep(ORCTestCaseStep postStep)
    {
        var newPostStep = AdaptStep(postStep.DeepClone());
        PostSteps = PostSteps.Append(newPostStep);
    }

    private ORCTestCaseStep AdaptStep(ORCTestCaseStep step)
    {
        step.SuiteId = SuiteId;
        step.CaseId = Id;
        return step;
    }
}