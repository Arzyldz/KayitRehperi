using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehperi.Core.DTOs
{
    public class CustomerDto:BaseDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EMail { get; set; }
        public string Tel { get; set; }
        public string City { get; set; }

        public byte[] Image { get; set; }
    }
}
