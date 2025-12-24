using System;

namespace InterviewPanelManagementTool.Application.DTOs.Candidate;

public class CandidateUpdateDto
{
    public string? Name { get; set; }
    public int? PracticeId { get; set; }
    public int? PositionId { get; set; }
}
