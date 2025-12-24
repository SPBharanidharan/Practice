using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewPanelManagementTool.Domain.Entities;

public class MemberPosition
{
    public int MemberId { get; set; }
    public int PositionId { get; set; }

    public User Member { get; set; } = null!;
    public Position Position { get; set; } = null!;
}
