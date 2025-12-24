using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.InterviewBoooking;

public class InterviewBookingDto
{
    public int BookingId { get; set; }
    public int CandidateId { get; set; }
    public int MemberId { get; set; }
    public InterviewBookingStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
