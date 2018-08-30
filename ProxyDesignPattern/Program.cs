using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            //Faktoriel _faktoriel = new Faktoriel();
            //Console.WriteLine(_faktoriel.Hesapla());
            //Console.WriteLine(_faktoriel.Hesapla());

            SayiAbstract faktorielproxy = new FaktroielProxy();
            Console.WriteLine(faktorielproxy.Hesapla());
            Console.WriteLine(faktorielproxy.Hesapla());

            Console.ReadKey();
        }
    }
    abstract class SayiAbstract
    {
        public abstract int Hesapla();
    }
    class Faktoriel : SayiAbstract
    {
        public override int Hesapla()
        {
            int sayi = 1;
            for (int i = 1; i <= 4; i++)
            {
                sayi *= i;
                Thread.Sleep(1000);
            }
            return sayi;
        }
    }
    class FaktroielProxy : SayiAbstract
    {
        private Faktoriel faktoriel;
        private int _cachesayi;
        public override int Hesapla()
        {
            if (faktoriel == null)
            {
                faktoriel = new Faktoriel();
                _cachesayi = faktoriel.Hesapla();
            }
            return _cachesayi;
        }
    }
}
