using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

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

    /// <summary>
    /// Creates a test suite model from the test suite run.
    /// </summary>
    /// <param name="suiteRun">A test suite run.</param>
    public ORCTestSuite(ORCTestSuiteRun suiteRun)
    {
        Id = suiteRun.SuiteId;
        Name = suiteRun.Name;
        Created = DateTimeOffset.Now;
        Updated = DateTimeOffset.Now;
        TestCases = suiteRun.TestCaseRuns.Select(caseRun => new ORCTestCase(caseRun));
        Tags = suiteRun.Tags;
        ExtParameters = suiteRun.ExtParameters;
        Attachments = Array.Empty<ORCAttachment>();
        Runners = suiteRun.Runners;
    }

    public void AddTestCase(ORCTestCase testCase)
    {
        var newCase = AdaptTestCase(testCase.DeepClone());
        TestCases = TestCases.Append(newCase);
    }

    private ORCTestCase AdaptTestCase(ORCTestCase testCase)
    {
        testCase.SuiteId = Id;
        return testCase;
    }
}