using System;

namespace MunicipalServicesApp
{
    public class ReportedIssue
    {
        public string Location { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string AttachmentPath { get; set; } = string.Empty;

        public DateTime DateReported { get; set; }

        public string ReferenceNumber { get; set; } = string.Empty;

        public string Status { get; set; } = "Reported";

        public bool IsEmergency { get; set; }
    }
}
