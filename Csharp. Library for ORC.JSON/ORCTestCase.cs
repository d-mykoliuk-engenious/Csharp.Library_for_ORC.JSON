using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCase
{
    [JsonProperty("test_suite_uid")] public readonly string SuiteId;
    [JsonProperty("test_case_uid")] public readonly string Id;
    [JsonProperty("test_case_name")] public readonly string Name;
    [JsonProperty("test_case_max_runs_count")] public int MaxRuns;
    [JsonProperty("created_at")] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] public DateTimeOffset Updated;
    [JsonProperty("pre_test_steps")] public ORCTestCaseStep[] PreSteps;
    [JsonProperty("test_steps")] public ORCTestCaseStep[] Steps;
    [JsonProperty("post_test_steps")] public ORCTestCaseStep[] PostSteps;
    [JsonProperty("tags")] public ORCParameter[] Tags;
    [JsonProperty("extended_parameters")] public ORCParameter[] ExtParameters;
    [JsonProperty("attachments")] public ORCAttachment[] Attachments;
    [JsonProperty("runners")] public ORCRunner[] Runners;

    public ORCTestCase()
    {
        SuiteId = "";
        Id = RandomGenerator.GetRandomId();
        Name = "";
        MaxRuns = 1;
        Created = DateTimeOffset.Now;
        Updated = DateTimeOffset.Now;
        PreSteps = Array.Empty<ORCTestCaseStep>();
        Steps = Array.Empty<ORCTestCaseStep>();
        PostSteps = Array.Empty<ORCTestCaseStep>();
        Tags = Array.Empty<ORCParameter>();
        ExtParameters = Array.Empty<ORCParameter>();
        Attachments = Array.Empty<ORCAttachment>();
        Runners = Array.Empty<ORCRunner>();
    }
}