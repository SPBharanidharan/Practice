using System;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
