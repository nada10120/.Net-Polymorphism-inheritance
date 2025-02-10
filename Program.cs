namespace Research_Tak4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a C# program that reads a list of integers from the user and throws an exception if any numbers are duplicates.

            //    bool cont = true;
            //    List<int> list = new List<int>();

            //    while (cont)
            //    {

            //        Console.WriteLine("Enter some numbers make sure it does'nt duplicate .Enter 0 to Exit");
            //        int x = int.Parse(Console.ReadLine());
            //        if (x == 0)
            //        {
            //            cont = false;
            //        }
            //        else
            //        {
            //            if (list.Contains(x))
            //            {
            //                throw new Exception("Duplicate number is not allowed");


            //            }
            //            else
            //            {
            //                list.Add(x);
            //            }
            //        }
            //    }

            //Write a C# program to create a method that takes a string as input and throws an exception if the string does not contain vowels.

            Console.WriteLine("Enter your sentence :");
            string sen = Console.ReadLine();

            if (!(sen.Contains("a")||sen.Contains("e") || sen.Contains("i") || sen.Contains("o") || sen.Contains("u")))
            {
                throw new Exception("heyy , don't forget your vowls in this sentence");
            }
            //for (int i = 0; i < sen.Length; i++) { 
            //    if (sen[i]
            
            //}
        }
    }
}

