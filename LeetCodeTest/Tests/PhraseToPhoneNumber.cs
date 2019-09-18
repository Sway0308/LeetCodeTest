using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    class PhraseToPhoneNumber : ISolution
    {
        public string Method()
        {
            var s = "However, how do I check if I'm actually getting back a KeyValuePair? I can't seem to use != or == to check against default(KeyValuePair) without a compiler error. There is a similar thread here that doesn't quite seem to have a solution. I'm actually able to solve my particular problem by getting the key and checking the default of Guid, but I'm curious if there's a good way of doing this with the keyvaluepair. Thanks";
            var ans = GetPhraseToPhoneNumber(s);
            return string.Join("", ans);
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

        private IEnumerable<string> GetPhraseToPhoneNumber(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                yield break;

            foreach (var s in phrase.Trim().ToLower())
            {
                var value = s.ToString();
                if (int.TryParse(value, out _))
                    yield return value;

                var ans = dic.Where(x => x.Value.Contains(value)).Select(p => new { p.Key, p.Value }).FirstOrDefault();
                yield return (ans == null ? value : ans.Key.ToString());
            }
        }
    }
}
