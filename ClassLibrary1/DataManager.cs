using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DataManager
    {
        public void KafeBilgisiniYazdir()
        {
            var connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");
            connection.Open();
            var command = new SqlCommand("select top 1 * from Kafe",connection);
            var result = command.ExecuteReader();
            result.Read();
            Console.WriteLine($"Kafe Adi: {result["Ad"]}");
            Console.WriteLine($"Kafe Durumu: {result["Durum"]}");
            result.Close();
            connection.Close();
        }
        public void UrunListesiniYazdir()
        {
            var connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");
            connection.Open();
            var command = new SqlCommand("select * from URUNler",connection);
            var result = command.ExecuteReader();

            while(result.Read())
            {
                Console.Write($"Ad: {result["Ad"]} ; ");
                Console.Write($"Fiyat: {result["Fiyat"]} ; ");
                Console.Write($"Stokta Var mı? {result["StoktaVarMi"]} ; ");
               Console.WriteLine();
               
            }
            result.Close();
            connection.Close();
        }
        public void KAfeIsmiGetir()
        {
            var connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");
            connection.Open();
            var command = new SqlCommand("Select Top 1 Ad from Kafe",connection);
            var result = (string)command.ExecuteScalar();
            
            Console.WriteLine($"{result}");
            Console.ReadLine();
        }
        public void FiyatBilgisi()
        {
            var connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");
            connection.Open();

            Console.WriteLine("Urun Adı Yazın");
            string urunadi=Console.ReadLine();

            var command = new SqlCommand($"Select fiyat from urunler where ad='"+urunadi+"'", connection);
            var result = (object)command.ExecuteScalar();
            connection.Close();
            Console.WriteLine($"{urunadi} urunun fiyatı{result}");
            Console.ReadLine();
        }
        public void GirilenDegerinustundekiler()
        {
            var connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");
            connection.Open();

            Console.WriteLine("Fiyat Giriniz");
            int fiyat = int.Parse(Console.ReadLine());

            var command = new SqlCommand($"Select ad,fiyat from urunler where fiyat>{fiyat}", connection);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine($"{fiyat}dan fazla olanlar{result["ad"]}");
                
            }
            result.Close();
            connection.Close();
        }
        public void UrunGiris()
        {
            Console.WriteLine("Urun Adını girin");
            string UrunAdi = Console.ReadLine();
            Console.WriteLine("Urun Fiyatını Giriniz");
            int UrunFiyati = int.Parse(Console.ReadLine());
            Console.WriteLine("Urun Stok Durumunu Giriniz ");
            bool Stok = bool.Parse(Console.ReadLine());

            var connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");
            connection.Open();
            var command = new SqlCommand($"insert into urunler ([Ad],[Fiyat],[StoktaVarMi]) Values ('{UrunAdi}','{UrunFiyati}','{Stok}')", connection);
            
            var result=command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Kayıt başarlı");
            }
            else
            {
                Console.WriteLine("Başarısız");
            }
            connection.Close();
        }
    }
}
