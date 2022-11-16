using Newtonsoft.Json.Converters;

namespace Csharp._Library_for_ORC.JSON;

public enum OrcRunStatus
{
    ORC_RUN_STATUS_TODO,
    ORC_RUN_STATUS_NA,
    ORC_RUN_STATUS_BLOCKED,
    ORC_RUN_STATUS_PASSED,
    ORC_RUN_STATUS_FAILED,
    ORC_RUN_STATUS_PAUSED,
    ORC_RUN_STATUS_CANCELED,
}

public enum OrcFileType
{
    ORC_FILE_TYPE_UNKNOWN,
    ORC_FILE_TYPE_TXT,
    ORC_FILE_TYPE_JSON,
    ORC_FILE_TYPE_XML,
    ORC_FILE_TYPE_HTML,
    ORC_FILE_TYPE_PDF,
}

public enum OrcErrorCode
{
    ORC_ERROR_CODE_NO_ERRORS,
    ORC_ERROR_CODE_NO_COMMON_ERROR,
}

public enum OrcAttachmentName
{
    ORC_ATTACHMENT_NAME_LOG,
    ORC_ATTACHMENT_NAME_COMMON
}



public class DateFormatConverter : IsoDateTimeConverter
{
    public DateFormatConverter()
    {
        DateTimeFormat = "yyyy-MM-dd hh-mm-ss(-fff)";
    }
}