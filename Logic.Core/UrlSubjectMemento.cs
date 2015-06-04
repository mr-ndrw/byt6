using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Core
{
    [DataContract]
    public class UrlSubjectMemento
    {
        [DataMember]
        private UrlSubjectState _state;

        public UrlSubjectMemento(UrlSubjectState state)
        {
            _state = state;
        }

        public UrlSubjectState GetState()
        {
            return _state;
        }
    }
}
