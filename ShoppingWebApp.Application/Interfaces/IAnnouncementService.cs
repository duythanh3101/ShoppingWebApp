using ShoppingWebApp.Application.ViewModels.System;
using ShoppingWebApp.Utilities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Application.Interfaces
{
    public interface IAnnouncementService
    {
        PagedResult<AnnouncementViewModel> GetAllUnReadPaging(Guid userId, int pageIndex, int pageSize);

        bool MarkAsRead(Guid userId, string id);
    }
}
