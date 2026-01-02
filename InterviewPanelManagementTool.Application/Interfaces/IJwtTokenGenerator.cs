using System;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateToken(User user);
}
