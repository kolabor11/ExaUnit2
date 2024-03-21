//Function 1

 static int Square(int number)
    {
        return number * number;
    }

//Function 2
 static double InchesToMillimeters(double inches)
    
        const double InchesToMillimetersFactor = 25.4;
        
        return inches * InchesToMillimetersFactor;

//Function 3

    static double SquareRoot(double number)
    {
        
        double guess = number / 2.0;

        while (true)
            double nextGuess = 0.5 * (guess + number / guess);

    
            if (Math.Abs(nextGuess - guess) < 0.0001)
            {
                return nextGuess;
            }

        
            guess = nextGuess;
        }
//Function 4

static int Cube(int number)
    {
        return number * number * number;
    }
//Function 5s
static double CalculateArea(double radius)
    {
        const double Pi = 3.14159;
        
        double area = Pi * radius * radius;
        
        return area;
    }

//Function 6

    static string GenerateGreeting(string name)
    {
        return "Ahoy, " + name + "!";
    }

