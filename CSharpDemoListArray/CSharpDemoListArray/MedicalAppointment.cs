using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    internal class MedicalAppointment
    {
        private string _patientName;
        private DateTime _date;
        private static string patientName;


        //ctor tab+tab(double tab)
        //public MedicalAppointment(string patientName, DateTime date)
        //{
        //    _patientName = patientName;
        //    _date = date;
        //}

        public DateTime GetDate()
        {
            return _date;
        }
        // public MedicalAppointment(string patientName, DateTime date):this(patientName)
        //{
        //    _date = date;
        //}

        ////default olarak bugunden itibaren 7 gun verelim
        //public MedicalAppointment(string patientName="Unknown", int daysFromNow=7)
        //{
        //    _patientName = patientName;
        //     _date = DateTime.Now.AddDays(7);
        //}

        //////Eger biz sadece patientname i kullanmak istiyoruz ve ayrica da patientname ve date i birlikte kullanmak istedigmz ayri usecase ler var o zaman, don't repeat yourself mantiginda...bu sekilde kullanabilriiz
        ////public MedicalAppointment(DateTime date, string patientName):this(patientName)
        ////{
        ////    _date = date;
        ////}

        ////Optioanal kullanim, eger kullanici sadece patientName girerse o zaman default olarak 7 gun sonraya randevu versin diye bir logic yazilacaksa o zaman da bu sekilde kod tekrari onlenmis olarak yazilir bestpractise....
        ////public MedicalAppointment(string patientName) : this(patientName, 7)
        ////{

        ////}

        //public MedicalAppointment(string patientName, int daysFromNow=7)
        //{
        //    _patientName = patientName;
        //    _date = DateTime.Now.AddDays(daysFromNow);
        //}

        //public void Reschedule(DateTime date)
        //{
        //    _date = date;
        //    var printer = new MedicalAppointmentPrinter();
        //    printer.Print(this);
        //}
        //int Square(int x)
        //{
        //    return x * x;//This is a statement (that contains the expression `x * x`)

        //}

        int Square2(int x) => x * x;
        //If your method only contains a single statement or expression, you can write it with a special syntax
        //What is a statement and what is an expression
        //An expression is anything that returns a value.Think of it like a small piece of code that evaluates to something — a number, a string, a boolean, etc.
        //5 + 3           // returns 8
        //x* x           // returns the square of x
        //"Hello " + name // returns a new string
        //Math.Sqrt(25)   // returns 5

        //A statement is a complete instruction. It performs an action, but doesn’t always return a value.
        /*
         int y = 10;             // variable declaration & assignment (statement)
        Console.WriteLine(y);   // method call (statement)
        return x * x;           // return statement

         */
    }

    class MedicalAppointmentPrinter
    {
        public void Print(MedicalAppointment medicalAppointment)
        {
            Console.WriteLine($"Appointment will take place on {medicalAppointment.GetDate()}");
        }
    }
}

 
