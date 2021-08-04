using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Adapter
{
    public class JSONAdapter:IAdapter
    {
        JSON _JSON;
        public void Read()
        {
            _JSON.JSON_Deserialize();
        }

        public JSONAdapter(JSON JSON)
        {
            _JSON = JSON;
        }
        public void Write()
        {
            _JSON.JSON_Serialize();
        }
    }
}
