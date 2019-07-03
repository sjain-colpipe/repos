using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPC.BusinessObject.Nominations;
using CPC.BusinessObject.Ticketing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();
        }

        private static void DoWork()
        {
            var obj = new CPC.BusinessObject.Ticketing.AddressInformation();

            var a = obj.CityName;
        }
    }
}
