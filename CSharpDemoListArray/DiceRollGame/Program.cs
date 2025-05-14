using DiceRollGame.Game;

internal class Program
{
    private static void Main(string[] args)
    {
       
        //var handleDiceRollGame = new HandleDiceRollGame();
        //handleDiceRollGame.Start();

        Console.WriteLine("Finish!!!");



        //className is important it is real-life scenaria-fit named

        var random = new Random();
        var dice = new Dice(random);
        var guessingGame = new GuessingGame(dice);
        GameResult gameResult = guessingGame.Play();
        GuessingGame.PrintResult(gameResult);

    }
}


