using System;

namespace ConsoleApplication1
{
    class MathQuiz 
    {

        private static  double count = 0;
        private static void Welcome()
        {
            Console.WriteLine("Welcome to Math quize");
            Console.Write("Enter your name : ");
            String name = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("hello ");
            Console.Write(name);
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            Welcome();
            String[][] questions = CreateQuestions();
            double total = questions.Length;
            foreach (String[] question in questions)
            {
                Console.WriteLine();
                Console.WriteLine(question[0]);
                String ans = Console.ReadLine();
                Console.WriteLine(printResult(ans, question[1]));
            }
            ShowResult(total);
            Console.ReadKey();
        }


        private static void ShowResult(double total)
        {
            double result = CalculatePercentage(total);
            Console.WriteLine("Thanks for your participation");
            Console.Write("You have scored ");
            Console.Write(result);
        }

        private static double  CalculatePercentage(double total)
        {
            return (count / total) * 100;
        }


        private static String printResult(String expected, String given)
        {
            if (!expected.Equals(given))
                return "Sorry your ans is wrong";
            count += 1;
            return "yah..!! you got it!!!!";
        }

        private static String[][] CreateQuestions()
        {
            String[][] questions = new String[6][];
            questions[0] = new String[2]{ "1+2", "3"};
            questions[1] = new String[2] { "2*5", "10" };
            questions[2] = new String[2] { "55+67", "122" };
            questions[3] = new String[2] { "1/2", "0.5" };
            questions[4] = new String[2] { "4*89", "356" };
            questions[5] = new String[2] { "2^3", "8" };
            return questions; 
        }
    }
}
