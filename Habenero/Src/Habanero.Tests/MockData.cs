using System.Collections.Generic;
using System.Linq;
using Habanero.Domain.Entities;
using Habanero.Domain.Models;

namespace Habanero.Tests
{
    public class MockData
    {
        public IQueryable<State> GetMockStates()
        {
            var states = new List<State>
            {
                new State()
                {
                    Name = "Alaska",
                    Abbreviation = "AK",
                    IsPrimaryState = true
                },
                new State()
                {
                    Name = "California",
                    Abbreviation = "CA",
                    IsPrimaryState = true
                },
                new State()
                {
                    Name = "Colorado",
                    Abbreviation = "CO",
                    IsPrimaryState = true
                },
                new State()
                {
                    Name = "Hawaii",
                    Abbreviation = "HI",
                    IsPrimaryState = false
                }
            };
            return states.AsQueryable();
        }

        public IQueryable<ZipCode> GetZipCodes()
        {
            var zipCodes = new List<ZipCode>()
            {
                new ZipCode()
                {
                    City = "Arecibo",
                    Zip = "00501",
                    County = "Suffolk",
                    State = new State()
                    {
                        Name = "Alaska",
                        Abbreviation = "AK",
                        IsPrimaryState = true
                    }
                },
                new ZipCode()
                {
                    City = "Rosario",
                    Zip = "00502",
                    County = "San German",
                    State = new State()
                    {
                        Name = "Alaska",
                        Abbreviation = "AK",
                        IsPrimaryState = true
                    }
                },
                new ZipCode()
                {
                    City = "Dorado",
                    Zip = "00541",
                    County = "Suffolk",
                    State = new State()
                    {
                        Name = "Alaska",
                        Abbreviation = "AK",
                        IsPrimaryState = true
                    }
                },
                new ZipCode()
                {
                    City = "Arecibo",
                    Zip = "00501",
                    County = "Suffolk",
                    State = new State()
                    {
                        Name = "Colorado",
                        Abbreviation = "CO",
                        IsPrimaryState = true
                    }
                }
            };

            return zipCodes.AsQueryable();
        }

        public List<ZipModel> GetZipModels()
        {
            return new List<ZipModel>()
            {
                new ZipModel(new ZipCode()
                {
                    Zip = "04598",
                    County = "Sufflock"
                })
            };
        }
    }
}