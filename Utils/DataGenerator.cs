using System;


namespace OrangeHRM.Utils
{
    public class DataGenerator
    {

        public static string RandomString(int length)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var rString = "";
            for (var i = 0; i < length; i++)
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToUpper();
            // Thread.Sleep(1);
            return rString;
        }


        public static string RandomPassword(int length)
        {
            if (length < 7) throw new ArgumentException("Password length must be at least 7");

            Random random = new Random(DateTime.Now.Millisecond);
            var rString = "";
            for (var i = 0; i < length; i++) 
           { 
            rString += ((char)(random.Next(97, 123))).ToString();
           }
            rString += random.Next(0, 10).ToString();
            return rString;
        }
     
    }
}
