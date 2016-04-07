using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain.Models;

namespace Habanero.Services
{
    public interface IStateService
    {
        List<StateModel> GetAllStates();
        List<StateModel> GetAllPrimaryStates();

    }
}
