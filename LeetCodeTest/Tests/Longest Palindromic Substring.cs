using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    /// <summary>
    /// Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
    /// </summary>
    class Longest_Palindromic_Substring : ISolution
    {
        public string Method()
        {
            //var s = "civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth";
            var s = "kyyrjtdplseovzwjkykrjwhxquwxsfsorjiumvxjhjmgeueafubtonhlerrgsgohfosqssmizcuqryqomsipovhhodpfyudtusjhonlqabhxfahfcjqxyckycstcqwxvicwkjeuboerkmjshfgiglceycmycadpnvoeaurqatesivajoqdilynbcihnidbizwkuaoegmytopzdmvvoewvhebqzskseeubnretjgnmyjwwgcooytfojeuzcuyhsznbcaiqpwcyusyyywqmmvqzvvceylnuwcbxybhqpvjumzomnabrjgcfaabqmiotlfojnyuolostmtacbwmwlqdfkbfikusuqtupdwdrjwqmuudbcvtpieiwteqbeyfyqejglmxofdjksqmzeugwvuniaxdrunyunnqpbnfbgqemvamaxuhjbyzqmhalrprhnindrkbopwbwsjeqrmyqipnqvjqzpjalqyfvaavyhytetllzupxjwozdfpmjhjlrnitnjgapzrakcqahaqetwllaaiadalmxgvpawqpgecojxfvcgxsbrldktufdrogkogbltcezflyctklpqrjymqzyzmtlssnavzcquytcskcnjzzrytsvawkavzboncxlhqfiofuohehaygxidxsofhmhzygklliovnwqbwwiiyarxtoihvjkdrzqsnmhdtdlpckuayhtfyirnhkrhbrwkdymjrjklonyggqnxhfvtkqxoicakzsxmgczpwhpkzcntkcwhkdkxvfnjbvjjoumczjyvdgkfukfuldolqnauvoyhoheoqvpwoisniv";
            var ans = LongestPalindrome2(s);
            return ans;
        }

        public string LongestPalindrome(string s)
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
                    var isOdd = subStr.Length % 2 != 0;
                    var reverseStr = string.Join("", subStr.Substring(slicecount + (isOdd ? 1 : 0), slicecount).Reverse());
                    var result = true;
                    for (int k = 0; k < slicecount; k++)
                    {
                        if (subStr.Substring(0, k + 1) != reverseStr.Substring(0, k + 1))
                        {
                            result = false;
                            break;
                        }
                    }

                    if (result)
                    {
                        dic.Add(i, subStr);
                        break;
                    }
                }
            }

            return dic.LastOrDefault().Value ?? "";
        }
    }
}
