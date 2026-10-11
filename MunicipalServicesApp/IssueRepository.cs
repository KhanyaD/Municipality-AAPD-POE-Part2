using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public static class IssueRepository
    {
        public static List<ReportedIssue> Issues { get; }
            = new List<ReportedIssue>();
    }
}