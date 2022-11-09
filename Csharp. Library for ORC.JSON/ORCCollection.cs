using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCCollection
{
    [JsonProperty("collection_uid")] public readonly string Id;
    [JsonProperty("collection_name")] public readonly string Name;
    [JsonProperty("created_at")] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] public DateTimeOffset Updated;
    [JsonProperty("test_suites")] public ORCTestSuite[] TestSuites;
    [JsonProperty("test_suite_runs")] public ORCTestSuiteRun[] SuiteRuns;
    [JsonProperty("tags")] public ORCParameter[] Tags;
    [JsonProperty("extended_parameters")] public ORCParameter[] ExtParameters;
    [JsonProperty("attachments")] public ORCAttachment[] Attachments;
    
    public ORCCollection()
    {
        Id = RandomGenerator.GetRandomId();
        Name = "";
        Created = DateTimeOffset.Now;
        Updated = DateTimeOffset.Now;
        TestSuites = Array.Empty<ORCTestSuite>();
        SuiteRuns = Array.Empty<ORCTestSuiteRun>();
        Tags = Array.Empty<ORCParameter>();
        ExtParameters = Array.Empty<ORCParameter>();
        Attachments = Array.Empty<ORCAttachment>();
    }

    public OrcErrorCode AddRunTestSuite(ORCTestSuiteRun testSuiteRun)
    {
        return OrcErrorCode.ORC_ERROR_CODE_NO_ERRORS;
    }

    public OrcErrorCode AddRunTestCase()
    {
        return OrcErrorCode.ORC_ERROR_CODE_NO_ERRORS;
    }

    public OrcErrorCode AddRunPreTestCaseStep()
    {
        return OrcErrorCode.ORC_ERROR_CODE_NO_ERRORS;
    }

    public OrcErrorCode AddRunTestCaseStep()
    {
        return OrcErrorCode.ORC_ERROR_CODE_NO_ERRORS;
    }

    public OrcErrorCode AddRunPostTestCaseStep()
    {
        return OrcErrorCode.ORC_ERROR_CODE_NO_ERRORS;
    }
}