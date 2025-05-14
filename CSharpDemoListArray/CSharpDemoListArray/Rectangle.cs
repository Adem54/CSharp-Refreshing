using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Rectangle
    {
        public int Weight;

        //Making all fields of an object readonly makes the whole object immutable

        //Burda su anda initialize etmiyhoruz yani declearation var ama herhangi bir deger atamasi  yok...
        public readonly string? name;
        public readonly int SideA;//
        public readonly int Height;
        public string? FirstName;
        //public for reading but private for writing
        //Biz disardan degistirilmesini onlemek istiyoruz...ama disardan kullanilabilir, veya okunabilir olsun istiyoruz..yani develper olarak bu class uzerinde nasil yazdirilacagi ile ilgili full controlumuz olmasini istyoruz

        public int getWeight() => this.Weight;

        //Burda set private methodu ile atamak cok kritik onemlidir...cunku...bazen biz bazi logic ler uygulamak isteriz iste burda bunu uygulayabiliriz


        private void setWeight(int value)
        {
            if (value > 10)
            {
                this.Weight = value;

            }
        }


        //the name of the property is alwasy starter with the capital letter, no matter private or public
        //A property  icindeki getter ve setter lar aslinda birer fonksiyondur dolsyi ile biz validation ekleyebiliriz setter icerisine
        //Private field kullanmak yerine public property kullanarak, biz encapsulation yapmis oluyoruz aslinda yani disardan direk erisilmesini engelliyoruz bir taraftan ama direk okunabilmesine izin veriyourz...
        //public int Width
        //{
        //    get { return _weight; }

        //    //Burdaki set icerisinde validation uygulayacagiz
        //    //private yaparsak disardan atanmasini onlemis oluruz..sadece icerden biz kendimz yazacagimz fonksyonlar icerisinde atanmasina musade ederiz
        //   private set 
        //    { 
        //        if(value > 10)
        //        {
        //            _weight = value;
        //        }else
        //        {
        //            _weight = 1;
        //        }
        //    }
        //}
        //private int _width;

        //public int Width {  get=>_width; private set=>_width=value; }

        //public int Width { get; }

        //public void SetWidth2(  )
        //{
        //    Width = 12;
        //    //property Width can not assign...readonly ..diye bir uyari aliriz
        //}

        public Rectangle(int width, int height)
        {
            // Width = GetWidthOrDefault(width, "Width");
            SideA = GetWidthOrDefault(width, nameof(SideA));
            //Height = GetWidthOrDefault(height, "Height");
            Height = GetWidthOrDefault(height, nameof(Height));
        }

        //Constructor icerisinde biz dogrudan method da kullanabiliriz
        private int GetWidthOrDefault(int width, string name)
        {
            int defaultValueIfNonPositive = 1;
            if (SideA < 0)
            {
                Console.WriteLine($"{name} must be a positive number.");
                return defaultValueIfNonPositive;
            }
            else
            {
                return width;
            }
        }


        public int CalculateCircumference() => 2 * SideA + 2 * Height;

        public int CalculateCircumferenceProp { get { return 2 * SideA + 2 * Height; } }
        public int CalculateArea() => SideA * Height;

        public int Width { get; set; }
        private int _height;
        public string Description => $"A rectangle with width {Width}" +
            $" and height {_height}";
        //If we use the DEscription property 1000 times, the string will be built 1000 times...it is superfast, but if the logic here was more complex, this could cause performance issues...
        //This creates a get-only property
        /*
         * ...is exactly the same as this longer version:
         public string Description
        {
            get { return $"A rectangle with width"; }
        }
        Why is it "get-only"?
        Because:

        It only defines a get accessor

        There is no set, so you can’t assign a value to Description from outside

        var rect = new Rectangle();
        Console.WriteLine(rect.Description); // prints: A rectangle with width
        rect.Description = "Something else"; // ❌ Error: no setter

         */

        //Properties should never be performance-heavy!
        public string LongDescription
        {
            get
            {
                var result = "";
                for(int i = 0; i < 100; ++i)
                {
                    result += i;
                }
                return result;
            }
        }
    }
}

//public for reading but private for writing