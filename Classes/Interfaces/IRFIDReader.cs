using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IRFIDReader
    {
        void OnRfidRead(int id);

        int _id { get; set; }
    }
}
