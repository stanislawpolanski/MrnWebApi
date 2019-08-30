using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Common.Command
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }
}
