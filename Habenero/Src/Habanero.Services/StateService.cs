using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain;
using Habanero.Domain.Entities;
using Habanero.Domain.Models;

namespace Habanero.Services
{
    public class StateService : IStateService
    {
        private readonly IRepository<State> _repository;

        public StateService(IRepository<State> repository)
        {
            _repository = repository;
        }
        public List<StateModel> GetAllStates()
        {
            return _repository.Get().Select(state => new StateModel(state)).ToList();
        }

        public List<StateModel> GetAllPrimaryStates()
        {
           return _repository.Get().Where(state => state.IsPrimaryState)
               .Select(state => new StateModel(state)).ToList();
        }       
    }
}
