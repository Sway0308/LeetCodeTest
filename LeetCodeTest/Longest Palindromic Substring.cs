using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    class Longest_Palindromic_Substring
    {
        public static void Main()
        {
            var a = DateTime.Now;
            Console.WriteLine(DateTime.Now);
            var s = "civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth";
            //var s = "lcnvoknqgejxbfhijmxglisfzjwbtvhodwummdqeggzfczmetrdnoetmcydwddmtubcqmdjwnpzdqcdhplxtezctvgnpobnnscrmeqkwgiedhzsvskrxwfyklynkplbgefjbyhlgmkkfpwngdkvwmbdskvagkcfsidrdgwgmnqjtdbtltzwxaokrvbxqqqhljszmefsyewwggylpugmdmemvcnlugipqdjnriythsanfdxpvbatsnatmlusspqizgknabhnqayeuzflkuysqyhfxojhfponsndytvjpbzlbfzjhmwoxcbwvhnvnzwmkhjxvuszgtqhctbqsxnasnhrusodeqmzrlcsrafghbqjpyklaaqximcjmpsxpzbyxqvpexytrhwhmrkuybtvqhwxdqhsnbecpfiudaqpzsvfaywvkhargputojdxonvlprzwvrjlmvqmrlftzbytqdusgeupuofhgonqoyffhmartpcbgybshllnjaapaixdbbljvjomdrrgfeqhwffcknmcqbhvulwiwmsxntropqzefwboozphjectnudtvzzlcmeruszqxvjgikcpfclnrayokxsqxpicfkvaerljmxchwcmxhtbwitsexfqowsflgzzeynuzhtzdaixhjtnielbablmckqzcccalpuyahwowqpcskjencokprybrpmpdnswslpunohafvminfolekdleusuaeiatdqsoatputmymqvxjqpikumgmxaxidlrlfmrhpkzmnxjtvdnopcgsiedvtfkltvplfcfflmwyqffktsmpezbxlnjegdlrcubwqvhxdammpkwkycrqtegepyxtohspeasrdtinjhbesilsvffnzznltsspjwuogdyzvanalohmzrywdwqqcukjceothydlgtocukc";
            var ans = LongestPalindrome2(s);
            var b = DateTime.Now;
            Console.WriteLine(DateTime.Now);
            Console.WriteLine((b - a).Milliseconds);
            Console.WriteLine(ans);
            Console.ReadKey();
        }

        public static string LongestPalindrome(string s)
        {
            var dic = new Dictionary<int, string>();
            var max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    var length = j - i + 1;
                    if (i > j || dic.ContainsKey(length) || max >= length)
                        continue;
                    var substring = s.Substring(i, j - i + 1);

                    if (i != j)
                    {
                        var slicecount = substring.Length / 2;
                        var isOdd = substring.Length % 2 != 0;
                        var firstStr = substring.Substring(0, slicecount);
                        var secondStr = isOdd ? substring.Substring(slicecount + 1, slicecount) : substring.Substring(slicecount, slicecount);
                        secondStr = string.Join("", secondStr.Reverse());
                        if (!firstStr.Equals(secondStr))
                            continue;
                    }

                    dic.Add(length, substring);
                    max = length;
                }
            }

            return dic.LastOrDefault().Value ?? "";
        }

        public static string LongestPalindrome2(string s)
        {
            var dic = new Dictionary<int, string>();
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (s.Length - j < i)
                        break;

                    var subStr = s.Substring(j, i);
                    if (subStr[0] != subStr[subStr.Length - 1])
                        continue;
                    var slicecount = subStr.Length / 2;
                    var midCount = slicecount / 2;
                    var aStr = subStr.Substring(0, midCount);
                    var bStr = subStr.Substring(subStr.Length - midCount, midCount);
                    if (aStr != string.Join("", bStr.Reverse()))
                        continue;

                    var isOdd = subStr.Length % 2 != 0;
                    var firstStr = subStr.Substring(0, slicecount);
                    var secondStr = isOdd ? subStr.Substring(slicecount + 1, slicecount) : subStr.Substring(slicecount, slicecount);
                    var reverseSecondStr = string.Join("", secondStr.Reverse());
                    if (!firstStr.Equals(reverseSecondStr))
                        continue;
                    dic.Add(i, subStr);
                    break;
                }
            }

            return dic.LastOrDefault().Value ?? "";
        }
    }
}
