using System.Threading.Channels;

Calculator test = new("Welcome to ALI-NT's Calculator");
test.Start();

public sealed class Calculator
{
    private string _welcome;

    public Calculator(string welcome)
    {
        _welcome = welcome;
    }

    public void Start()
    {
        Console.WriteLine(_welcome);

        Dictionary<string, string> operators = new()
        {
            { "+", "Add" },
            { "/", "divide" },
            { "*", "multiplication" },
            { "-", "subtraction" }
        };
        
        while (true)
        {

            Console.WriteLine("Operator choices are as follows:");
            foreach(var op in operators)
            {
                Console.WriteLine($"{op.Value}: {op.Key}");
            }

            Console.WriteLine("Enter an operator");
            string opChoice = Console.ReadLine();
            if(!operators.TryGetValue(
                opChoice,
                out var ignore))
            {
                Console.WriteLine("invalid operator choice.");
                continue;
            }

            int firstNumber, secondNumber;
            while (true)
            {
                Console.WriteLine($"Recall that integers are on the range {int.MinValue} to {int.MaxValue}!");

                Console.WriteLine("Enter the first number (must be integer)");
                string firstNumberSt = Console.ReadLine();
                if(!int.TryParse(firstNumberSt, out firstNumber))
                {
                    Console.WriteLine($"{firstNumberSt} could not be parsed as an integer!");
                    continue;
                }

                Console.WriteLine("Enter the second number (must be integer)");
                string secondNumberSt = Console.ReadLine();
                if(!int.TryParse (secondNumberSt, out secondNumber))
                {
                    Console.WriteLine($"{secondNumberSt} could not be parsed as an integer!");
                    continue;
                }
                break;
            }

            int result;
            try
            {
                result = opChoice switch
                {
                    "+" => firstNumber + secondNumber,
                    "-" => firstNumber - secondNumber, 
                    "/" => firstNumber / secondNumber,
                    "*" => firstNumber * secondNumber
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR : {ex.Message}");
                continue;
            }
            Console.WriteLine($"the result is {result}");

            Console.WriteLine("do you want to Exit (yes/no)");
            string exitRes = Console.ReadLine();
            switch (exitRes)
            {
                case "yes":
                    System.Environment.Exit(0);
                    break;
                case "no":
                    continue;
                default:
                    System.Environment.Exit(0);
                    break;
            };
        }

    }
}