using System;
using System.Runtime.Serialization;

namespace BaseProject.Models
{
    [DataContract]
    public class Response : BaseModel
    {
        [DataMember(Name = "total_count")]
        public int Total { get; set; }
        [DataMember(Name = "incomplete_results")]
        public bool Result { get; set; }

    }

    [DataContract]
    public class Response<T> : Response
    {
        [DataMember(Name = "items")]
        public T Items { set; get; }
    }
}

