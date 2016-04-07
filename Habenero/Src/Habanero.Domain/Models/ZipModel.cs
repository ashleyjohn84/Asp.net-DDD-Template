using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain.Entities;

namespace Habanero.Domain.Models
{
    [DataContract]
    public class ZipModel
    {
        [DataMember]
        public string Zip { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string StateName { get; set; }

        public ZipModel(ZipCode zipCode)
        {
            Zip = zipCode.Zip;
            County = zipCode.County;
            StateName = zipCode.State == null ? String.Empty : zipCode.State.Name;
        }
    }
}
