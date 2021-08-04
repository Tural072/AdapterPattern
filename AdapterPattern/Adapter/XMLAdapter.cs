using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Adapter
{
    public class XMLAdapter:IAdapter
    {
        XML _XML;
        public void Read()
        {
            _XML.XML_Deserialize();
        }

        public XMLAdapter(XML XML_File)
        {
            _XML = XML_File;
        }
        public void Write()
        {
            _XML.XML_Serialize();
        }
    }
}
