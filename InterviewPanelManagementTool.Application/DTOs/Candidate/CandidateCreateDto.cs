using System;

namespace InterviewPanelManagementTool.Application.DTOs.Candidate;

public class CandidateCreateDto
{
    public int CandidateCode { get; set; }
    public string Name { get; set; } = null!;
    public int PracticeId { get; set; }
    public int PositionId { get; set; }


}
