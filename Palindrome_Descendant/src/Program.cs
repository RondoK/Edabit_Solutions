using System.Text;

namespace Palindrome_Descendant.src
{
    public class Program
    {
        public static bool PalindromeDescendant(int num)
        {
            return new Element(num).IsPalindromeOrDescendantAre();
        }
    }
}
