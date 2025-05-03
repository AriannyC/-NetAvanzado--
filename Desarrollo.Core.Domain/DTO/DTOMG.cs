using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Desarrollo.Core.Domain.DTO
{
    public class DTOMG
    {

        public bool ThereIsError => Errors.Any();
        public long EntityId { get; set; }
        public bool Successful { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>(0);
    }

        public class DTOMG<T> : DTOMG where T : class
        {
            public IEnumerable<T> DataList { get; set; }
            public T SingleData { get; set; }
        }

    
}
