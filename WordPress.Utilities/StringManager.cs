using System;
using System.Text;

namespace WordPress.Utilities
{
    public class StringManager
    {
        public static string GenerateTitle(string sufix = ", Title")
        {
            return CreateRandomString() + sufix;
        }

        public static string GenerateBody(string sufix = ", Body")
        {
            return CreateRandomString() + sufix;
        }

        /// <summary>Creates the random string.</summary>
        /// <returns></returns>
        private static string CreateRandomString()
        {
            var s = new StringBuilder();

            var random = new Random(Guid.NewGuid().GetHashCode());
            var cycles = random.Next(3, 5);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
            }

            return s.ToString();
        }

        /// <summary>The words</summary>
        private static string[] Words =
        {
            "codedui", "jala", "web", "trainning", "game", "fixed", "good", "bad", "code", "review", "implemented", "completed", "finished", "tc", "atc", "vs", "alm", "dev", "qe", "selenium", "white"
        };

        /// <summary>The articles</summary>
        private static string[] Articles =
        {
            "the", "an", "and", "a", "of", "to", "it", "as", "that", "this"
        };
    }
}
