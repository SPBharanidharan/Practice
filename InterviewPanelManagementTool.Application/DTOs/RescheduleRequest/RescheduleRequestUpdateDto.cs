using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;

public class RescheduleRequestUpdateDto
{
    public RescheduleStatus? Status { get; set; }
    public int? ProcessedByAdminId { get; set; }
    public DateTime? ProcessedDate { get; set; }
}
