using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;

namespace DatabaseAPI.Inner.Logic.Owner
{
    public interface IOwnerLogicService
    {
        Task<OwnerDTO> GetOwnerByIdAsync(int id);
    }
}
