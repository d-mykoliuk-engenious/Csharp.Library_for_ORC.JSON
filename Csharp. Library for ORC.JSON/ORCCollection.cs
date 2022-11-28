using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCCollection
{
    [JsonProperty("collection_uid")] public readonly string Id;
    [JsonProperty("collection_name")] public readonly string Name;
    [JsonProperty("created_at")] [JsonConverter(typeof(DateFormatConverter))]  public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] [JsonConverter(typeof(DateFormatConverter))] public DateTimeOffset Updated;
    [JsonProperty("test_suites")] public IEnumerable<ORCTestSuite> TestSuites;
    [JsonProperty("test_suite_runs")] public IEnumerable<ORCTestSuiteRun> SuiteRuns;
    [JsonProperty("tags")] public IEnumerable<ORCParameter> Tags;
    [JsonProperty("extended_parameters")] public IEnumerable<ORCParameter> ExtParameters;
    [JsonProperty("attachments")] public IEnumerable<ORCAttachment> Attachments;
    
    public ORCCollection(string id = "", string name = "",
        DateTimeOffset? created = null, DateTimeOffset? updated = null,
        IEnumerable<ORCTestSuite>? suites = null, IEnumerable<ORCTestSuiteRun>? suiteRuns = null,
        IEnumerable<ORCParameter>? tags = null, IEnumerable<ORCParameter>? parameters = null,
        IEnumerable<ORCAttachment>? attachments = null)
    {
        Id = id;
        Name = name;
        Created = created ?? DateTimeOffset.Now;
        Updated = updated ?? DateTimeOffset.Now;
        Created = DateTimeOffset.Now;
        Updated = DateTimeOffset.Now;
        TestSuites = suites ?? Array.Empty<ORCTestSuite>();
        SuiteRuns = suiteRuns ?? Array.Empty<ORCTestSuiteRun>();
        Tags = tags ?? Array.Empty<ORCParameter>();
        ExtParameters = parameters ?? Array.Empty<ORCParameter>();
        Attachments = attachments ?? Array.Empty<ORCAttachment>();
    }

    public OrcErrorCode AddRunTestSuite(ORCTestSuiteRun testSuiteRun)
    {
        var suiteIdCollection = TestSuites.Select(suite => suite.Id);
        if (!suiteIdCollection.Contains(testSuiteRun.SuiteId))
        {
            // TODO: Create testsuite1
            return OrcErrorCode.ORC_ERROR_CODE_NO_COMMON_ERROR;
        }
        SuiteRuns = SuiteRuns.Append(testSuiteRun.DeepClone());
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

    public static ORCCollection CreateExampleCollection()
    {
        var collection = new ORCCollection(id: RandomGenerator.GetRandomId(), name: "Collection example");
        
        var suite1 = new ORCTestSuite(id: RandomGenerator.GetRandomId(), name: "TestSuite1");
        var testcase = new ORCTestCase(id: RandomGenerator.GetRandomId(), name: "test Case 1");
        suite1.AddTestCase(testcase);
        testcase.AddPreStep(new ORCTestCaseStep(id: RandomGenerator.GetRandomId(), name: "PreStep1"));
        testcase.AddStep(new ORCTestCaseStep(id: RandomGenerator.GetRandomId(), name: "Step1"));
        testcase.AddPostStep(new ORCTestCaseStep(id: RandomGenerator.GetRandomId(), name: "PostStep1"));

        var suite1Run = new ORCTestSuiteRun(suiteId: suite1.Id, id: RandomGenerator.GetRandomId(), name: "Suite 1 run 1");

        var testcaseRun = new ORCTestCaseRun(caseId: testcase.Id);
        suite1Run.AddCaseRun(testcaseRun);
        testcaseRun.AddPreStepRun(new ORCTestCaseStepRun(stepId: testcase.PreSteps.First().Id));
        testcaseRun.AddStepRun(new ORCTestCaseStepRun(stepId: testcase.Steps.First().Id));
        testcaseRun.AddPostStepRun(new ORCTestCaseStepRun(stepId: testcase.PostSteps.First().Id));

        collection.AddTestSuite(suite1);
        collection.AddRunTestSuite(suite1Run);

        return collection;
    }

    public void WriteToFile(string path)
    {
        var serializer = new JsonSerializer();

        using (StreamWriter sw = File.CreateText(path))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            writer.Formatting = Formatting.Indented;
            serializer.Serialize(writer, this);
        }
    }

    internal void AddTestSuite(ORCTestSuite suite)
    {
        TestSuites = TestSuites.Append(suite);
    }
}