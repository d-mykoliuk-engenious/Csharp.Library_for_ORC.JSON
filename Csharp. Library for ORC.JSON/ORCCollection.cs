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
        SuiteRuns = SuiteRuns.Append(testSuiteRun);
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

        var suiteRun = new ORCTestSuiteRun(suiteId: suite1.Id, id: RandomGenerator.GetRandomId(), name: "Suite 1 run 1");

        var testcaseRun = new ORCTestCaseRun(caseId: testcase.Id, suiteId: suite1.Id, suiteRunId: suiteRun.Id);
        testcaseRun.AddPreStepRun(new ORCTestCaseStepRun(suiteId: suite1.Id, suiteRunId: suiteRun.Id, caseId: testcase.Id, stepId: testcase.PreSteps.First().Id));
        testcaseRun.AddStepRun(new ORCTestCaseStepRun(suiteId: suite1.Id, suiteRunId: suiteRun.Id, caseId: testcase.Id, stepId: testcase.Steps.First().Id));
        testcaseRun.AddPostStepRun(new ORCTestCaseStepRun(suiteId: suite1.Id, suiteRunId: suiteRun.Id, caseId: testcase.Id, stepId: testcase.PostSteps.First().Id));
        suiteRun.AddCaseRun(testcaseRun);
        
        collection.TestSuites = collection.TestSuites.Append(suite1);
        collection.AddRunTestSuite(suiteRun);

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
}