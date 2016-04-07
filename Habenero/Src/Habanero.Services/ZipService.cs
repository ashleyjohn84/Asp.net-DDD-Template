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
    public class ZipService : IZipService
    {
        private readonly IRepository<ZipCode> _repository;

        public ZipService(IRepository<ZipCode> repository)
        {
            _repository = repository;
        }
        public List<ZipModel> GetZipsByState(string stateCode)
        {
           return _repository.Get()
                .Where(zipCode => zipCode.State.Abbreviation.ToLowerInvariant().Equals(stateCode.ToLowerInvariant()))
                .Select(zipCode => new ZipModel(zipCode)).ToList();
        }
    }
}
