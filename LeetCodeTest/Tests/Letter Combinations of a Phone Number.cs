using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    /// <summary>
    /// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
    /// A mapping of digit to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
    /// </summary>
    class Letter_Combinations_of_a_Phone_Number : ISolution, IComplete
    {
        public string Method()
        {
            var s = "2";
            var ans = LetterCombinations2(s);
            return string.Join(",", ans);
        }

        private readonly Dictionary<int, string> dic = new Dictionary<int, string>
            {
                { 2, "abc" },
                { 3, "def" },
                { 4, "ghi" },
                { 5, "jkl" },
                { 6, "mno" },
                { 7, "pqrs" },
                { 8, "tuv" },
                { 9, "wxyz" },
            };

        private IList<string> LetterCombinations(string digits)
        {            
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(digits) || !int.TryParse(digits, out var num))
                return result;

            var nums = new List<int>();
            var strs = new List<string>();
            while (num > 0)
            {
                var value = num % 10;
                if (value == 0 || value == 1)
                    return result;
                num /= 10;
                nums.Add(value);
                strs.Add(dic[value]);
            }

            var maxLen = strs.Last().Length;
            for (int i = 0; i < maxLen; i++)
            {
                var txt = "";
                for (int j = nums.Count - 1; j >= 0; j--)
                {
                    var a = strs[j];
                    var b = a.Length < i + 1 ? "" : a[i].ToString();
                    txt += b;
                }
                if (!string.IsNullOrEmpty(txt))
                    result.Add(txt);
            }

            return result;
        }

        private IList<string> LetterCombinations2(string digits)
        {
            var result = new List<string>();
            if (digits == null || digits.Length == 0) return result;

            char[][] mapping = new char[8][];
            mapping[0] = "abc".ToCharArray();
            mapping[1] = "def".ToCharArray();
            mapping[2] = "ghi".ToCharArray();
            mapping[3] = "jkl".ToCharArray();
            mapping[4] = "mno".ToCharArray();
            mapping[5] = "pqrs".ToCharArray();
            mapping[6] = "tuv".ToCharArray();
            mapping[7] = "wxyz".ToCharArray();

            result.Add("");
            foreach (var digit in digits)
                result = expand(in result, in mapping[digit - '2']);

            return result;
        }

        private List<string> expand(in List<string> answers, in char[] inputs)
        {
            var next = new List<string>();

            foreach (var answer in answers)
                foreach (var input in inputs)
                    next.Add(answer + input);

            return next;
        }
    }
}
