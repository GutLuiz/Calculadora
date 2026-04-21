class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
        List<string> _c = new List<string>();

        // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = num1 + num2;
                _c.Add("Numero 1: " + num1 + " + " + "Numero 2: " + num2 + " = " + result);
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            case "e":
                Console.WriteLine("Result");
                foreach (string c in _c)
                {
                    Console.WriteLine("Qtd itens: " + _c.Count);
                    Console.WriteLine(" - " + c.ToString());
                }
                break;

            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
}