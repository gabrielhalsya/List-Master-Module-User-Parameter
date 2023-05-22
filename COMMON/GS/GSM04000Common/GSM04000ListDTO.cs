using System;
using System.Collections.Generic;
using System.Text;

namespace GSM04000Common
{
    public class GSM04000ListDTO
    {
        public IAsyncEnumerable<GSM04000DTO> Data { get; set; }
    }
}
