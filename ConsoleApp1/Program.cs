using ClassLibrary1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataManager = new DataManager();
            //dataManager.KafeBilgisiniYazdir();
            //dataManager.UrunListesiniYazdir();
            //dataManager.KAfeIsmiGetir();
            //dataManager.FiyatBilgisi();
            //dataManager.GirilenDegerinustundekiler();
            dataManager.UrunGiris();
            Console.ReadLine();
        }
    }
}
