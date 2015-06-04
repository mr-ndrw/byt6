using System;
using System.Runtime.Serialization;

namespace Logic.Core
{
    [DataContract]
    public class UrlSubjectState
    {
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public DateTime LastModified { get; set; }
    }
}
