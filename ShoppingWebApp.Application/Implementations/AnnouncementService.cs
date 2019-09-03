using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Application.ViewModels.System;
using ShoppingWebApp.Data.Entities;
using ShoppingWebApp.Infrastructure.Interfaces;
using ShoppingWebApp.Utilities.DTOs;
using System;
using System.Linq;

namespace ShoppingWebApp.Application.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {
        private IAsyncRepository<Announcement, string> _announcementRepository;
        private IAsyncRepository<AnnouncementUser, int> _announcementUserRepository;

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AnnouncementService(IAsyncRepository<Announcement, string> announcementRepository, IAsyncRepository<AnnouncementUser, int> announcementUserRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _announcementUserRepository = announcementUserRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PagedResult<AnnouncementViewModel> GetAllUnReadPaging(Guid userId, int pageIndex, int pageSize)
        {
            var query = from x in _announcementRepository.FindAll()
                        join y in _announcementUserRepository.FindAll()
                            on x.Id equals y.AnnouncementId
                            into xy
                        from annonUser in xy.DefaultIfEmpty()
                        where annonUser.HasRead == false && (annonUser.UserId == null || annonUser.UserId == userId)
                        select x;
            int totalRow = query.Count();

            var model = query.OrderByDescending(x => x.DateCreated)
                .Skip(pageSize * (pageIndex - 1)).Take(pageSize).ProjectTo<AnnouncementViewModel>(_mapper.ConfigurationProvider).ToList();

            var paginationSet = new PagedResult<AnnouncementViewModel>
            {
                Results = model,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public bool MarkAsRead(Guid userId, string id)
        {
            bool result = false;
            var announ = _announcementUserRepository.FindSingle(x => x.AnnouncementId == id
                                                                               && x.UserId == userId);
            if (announ == null)
            {
                _announcementUserRepository.Add(new AnnouncementUser
                {
                    AnnouncementId = id,
                    UserId = userId,
                    HasRead = true
                });
                result = true;
            }
            else
            {
                if (announ.HasRead == false)
                {
                    announ.HasRead = true;
                    result = true;
                }

            }
            return result;
        }
    }
}
