using InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;

using AutoMapper;

namespace InterviewPanelManagementTool.Application.Services
{
    public class RescheduleRequestService : IRescheduleRequestService
    {
        private readonly IRescheduleRequestRepository _repo;
        private readonly IMapper _mapper;

        public RescheduleRequestService(IRescheduleRequestRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RescheduleRequestResponseDto> CreateRequestAsync(RescheduleRequestCreateDto dto, int memberId)
        {
            var booking = await _repo.GetBookingbyMemberIdAsync(dto.BookingId,memberId);

            if (booking == null)
                throw new Exception("Booking not found or not assigned to this member.");

            var existingRequest = await _repo.GetByBookingIdAsync(dto.BookingId);
            if (existingRequest != null)
                throw new Exception("A reschedule request already exists for this booking.");

            var request = _mapper.Map<RescheduleRequest>(dto);
            request.MemberId = memberId;
            request.RequestedAt = DateTime.Now;


            var createdRequest = await _repo.AddAsync(request);

            return _mapper.Map<RescheduleRequestResponseDto>(createdRequest);
        }

        public async Task<List<RescheduleRequestResponseDto>> GetRequestsByMemberAsync(int memberId)
        {
            var requests = await _repo.GetRequestsByMemberAsync(memberId);

            return _mapper.Map<List<RescheduleRequestResponseDto>>(requests);
        }


       
        public async Task<IEnumerable<RescheduleRequestResponseDto>> GetAllRequestAsync()
        {
            var requests = await _repo.GetAllRequestAsync();
            return _mapper.Map<IEnumerable<RescheduleRequestResponseDto>>(requests);
        }
    }
}
