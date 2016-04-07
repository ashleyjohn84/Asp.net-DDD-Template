using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain.Entities;

namespace Habanero.Domain.Models
{
    [DataContract]
    public class StateModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsPrimaryState { get; set; }

        [DataMember]
        public string Abbreviation { get; set; }

        public StateModel(State state)
        {
            Name = state.Name;
            IsPrimaryState = state.IsPrimaryState;
            Abbreviation = state.Abbreviation;
        }
    }
}
