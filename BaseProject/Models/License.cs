using System;
using System.Runtime.Serialization;

namespace BaseProject.Models
{
    [DataContract]
    public class License : BaseModel
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "spdx_id")]
        public string SpdxID { get; set; }
        [DataMember(Name = "url")]
        public string URL { get; set; }
    }
}

