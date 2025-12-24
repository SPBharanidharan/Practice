using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.InterviewBoooking;

public class InterviewBookingDetailsDto
{
    public int BookingId { get; set; }
    public string CandidateName { get; set; }
    public string MemberName { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public InterviewBookingStatus Status { get; set; }
}
