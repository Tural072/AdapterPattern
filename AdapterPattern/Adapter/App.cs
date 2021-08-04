using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Adapter
{
    public class App1
    {
        private readonly Convertor _convertor;

        public App1(IAdapter adapter)
        {
            _convertor = new Convertor(adapter);
        }

        public void Start()
        {
            _convertor.WriteFile();
            _convertor.ReadFile();

        }
    }
}
