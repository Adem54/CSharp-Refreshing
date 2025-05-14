//If one day we need to extend the game, we can simply add another line as tie for example...


//ConsoleReader class ini,  GuessingGame class i icinde kulanmamiz gerekiyor..dependency injection olarak kullaniriz.
//Improvement-7- Ama sonra da ConsoleReader in gorevi girilen input u okumak oldugu icin, C# Console.WriteLine da Console static class tir o zaman, ConsoleReader i da biz static class yapariz..yani tools gibi helpers gibi kullanilan bir class old icin de static class yapariz..static class lar sadece static methodlari barindirabilir..Ek bilgi olarak static class larin test edilebilirlk problemleri vardir bunun detaylari ilerde konusulur
namespace DiceRollGame.UserCommunication
{
    public static class ConsoleReader
    {
        public static int ReadInteger(string message)
        {
            int result;
            do
            {
                Console.WriteLine(message);
            }
            while (!int.TryParse(Console.ReadLine(), out result));//Improving-5. Harika bir bestpractise...kullanicidan beklenilen input tipi gelene kadar kullaniciya sorma durumunda, biz tam olarak do while ile bu islemi cok kolayca yonetebiliriz..harika bestpractise...
            return result;
        }
    }

}

