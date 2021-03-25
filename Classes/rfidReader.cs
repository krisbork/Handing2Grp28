using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class rfidReader : IRFIDReader
    {
        public void OnRfidRead(int id)
        {
            _id = id;
        }
        
        public int _id { get; set; }
    }
}
