using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.InterviewBoooking;

public class InterviewBookingStatusUpdateDto
{
    public int BookingId { get; set; }
    public InterviewBookingStatus Status { get; set; }
}
