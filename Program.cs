using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
        int quantidade = 1;

        List<Calculator> _c = new List<Calculator>();

        while (!endApp)
        {
            // Declare variables and set to empty.
            // Use Nullable types (with ?) to match type of System.Console.ReadLine
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            // Ask the user to type the first number.
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine(" ");
            // Ask the user to choose an operator.
            Console.WriteLine("This calculator was used: " + quantidade + " times");
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\te - Recent calculations");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            // Validate input is not null, and matches the pattern
            if (op == null || !Regex.IsMatch(op, "[a|s|m|d|e]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    if (op == "e")
                    {
                        // listo os resultados
                        Console.WriteLine("Resultados:");
                        foreach (var item in _c)
                        {
                            Console.WriteLine($" - {item.numero1} {item.operacao} {item.numero2} = {item.resultado}");
                        }
                        
                        if (_c.Count > 0)
                        {
                            Console.WriteLine("Excluir lista?");
                            Console.WriteLine("1 - Sim, quero excluir essa lista recente de calculos.");
                            Console.WriteLine("2 - Nao, quero continuar com lista recente de calculos.");
                            int escolha = int.Parse(Console.ReadLine());

                            if (escolha == 1)
                            {
                                _c.Clear();
                            }
                            else
                            {
                                Console.WriteLine("1 - Voce quer reutilizar algum calculo? (0,1,2,3,4,5)");
                                int indice = int.Parse(Console.ReadLine());

                                var escolhido = _c[indice];

                                var resultado = escolhido.resultado;

                                Console.Write("Digite o segundo número: ");
                                string? input = Console.ReadLine();
                                double n2 = double.Parse(input);

                                Console.WriteLine("Escolha a operação (a/s/m/d): ");
                                string opNova = Console.ReadLine();

                                var novoResultado = Calculator.DoOperation(resultado, n2, opNova);

                                string simbolo = opNova switch
                                {
                                    "a" => "+",
                                    "s" => "-",
                                    "m" => "*",
                                    "d" => "/",
                                    _ => "?"
                                };

                                if (double.IsNaN(novoResultado))
                                {
                                    Console.WriteLine("This operation will result in a mathematical error.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Your result: {0:0.##}\n", novoResultado);
                                    _c.Add(new Calculator
                                    {
                                        numero1 = cleanNum1,
                                        numero2 = cleanNum2,
                                        operacao = simbolo,
                                        resultado = novoResultado
                                    });
                                }


                            }
                        }
                        
                    }
                    else 
                    {
                        result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                        string simbolo = op switch
                        {
                            "a" => "+",
                            "s" => "-",
                            "m" => "*",
                            "d" => "/",
                            _ => "?"
                        };

                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else
                        {
                            Console.WriteLine("Your result: {0:0.##}\n", result);
                            _c.Add(new Calculator
                            {
                                numero1 = cleanNum1,
                                numero2 = cleanNum2,
                                operacao = simbolo,
                                resultado = result
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
            quantidade++;
        }
        return;
    }
}