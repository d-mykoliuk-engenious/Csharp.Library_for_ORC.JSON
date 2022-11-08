﻿using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestSuiteRun
{
    [JsonProperty("test_suite_uid")] public readonly string SuiteId;
    [JsonProperty("test_suite_run_uid")] public readonly string Id;
    [JsonProperty("test_suite_run_name")] public readonly string Name;
    [JsonProperty("created_at")] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] public DateTimeOffset Updated;
    [JsonProperty("started_at")] public readonly DateTimeOffset Started;
    [JsonProperty("ended_at")] public readonly DateTimeOffset Ended;
    [JsonProperty("run_status")] public OrcRunStatus Status;
    [JsonProperty("test_cases_runs")] public ORCTestCaseRun[] TestCaseRuns;
    [JsonProperty("tags")] public ORCParameter[] Tags;
    [JsonProperty("extended_parameters")] public ORCParameter[] ExtParameters;
    [JsonProperty("attachments")] public ORCAttachment[] Attachments;
    [JsonProperty("runners")] public ORCRunner[] Runners;

    public ORCTestSuiteRun()
    {
        SuiteId = "";
        Id = RandomGenerator.GetRandomId();
        Name = "";
        Created = DateTimeOffset.Now;
        Updated = DateTimeOffset.Now;
        Started = DateTimeOffset.Now;
        Ended = DateTimeOffset.Now;
        Status = OrcRunStatus.ORC_RUN_STATUS_TODO;
        TestCaseRuns = Array.Empty<ORCTestCaseRun>();
        Tags = Array.Empty<ORCParameter>();
        ExtParameters = Array.Empty<ORCParameter>();
        Attachments = Array.Empty<ORCAttachment>();
        Runners = Array.Empty<ORCRunner>();
    }
}