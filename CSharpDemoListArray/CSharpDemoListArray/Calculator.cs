using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    static class Calculator
    {
        public static int Add(int a, int b) => a + b;
        public static int Substract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;

    }

    //Calculator class i stateeless iken Ractangle sinifi statefull dur...yani Rectangle class i her instance ye gore verilen degerler uzerinden dinamik bir sekilde degisecektir ve state i dinamiktir..ama Calculator class inin bir statei yoktur her durumda ayni sonucu verecektir
    //O zaamn Calculator class indan neden yeni bir instance olusturalim ki o zaman
    //Iste boyle durumlar icin biz static class kullaniriz
    public class MyRectangle
    {
        private static int _someField = 1;
        public string AsString()=>"Value of fields is "+ _someField;
        //static olmayan bir method icinde satatic bir degiskene direk erisilebiliyor
       public int x;
        public static int Width { get; set; }
        public int Height { get; set; }

        public static int CountOfInstances { get; private set; }

        //Ya bu sekilde dogrudan declaration da atama yapariz...assign it at declaration like this..or in thi static constructor which is just like a regular constructor, but it doesn't have any access modifier, instead it has the static modifier
        private static DateTime _firstUsed = DateTime.Now;

        static MyRectangle()
        {
            _firstUsed = DateTime.Now;
        }

        public MyRectangle(int weight, int height)
        {
            Width = weight;
            Height = height;

            CountOfInstances++;
            //Whenever an instance of a rectangle class i created, this counter will be incremented
            //If this field was not static, the value would be incremented only once when the object was created
        }


        //Static method icinde static olmayan method ve properties e erisilemez
        //Eger private bir methodumuz var ve bu method instance data icinde kullanilmiyor ise o zaman onu static yapmak good practise...dir..daha dogrudur..
        public static void Calculate()
        {
           // return Width * Height; Boyle kullanilmaz
           // return MyRectangle.Width * Rectangle.Heigth;
        }

        public string NotUsingAnyState() => "abc";
    }

}
