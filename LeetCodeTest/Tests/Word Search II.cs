using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a 2D board and a list of words from the dictionary, find all words in the board.
    /// Each word must be constructed from letters of sequentially adjacent cell, 
    /// where "adjacent" cells are those horizontally or vertically neighboring.
    /// The same letter cell may not be used more than once in a word.
    /// </summary>
    class Word_Search_II : ISolution, IHard
    {
        public string Method()
        {
            var board = new char[][] {
                new char[] { 'o', 'a', 'a', 'n' },
                new char[] { 'e', 't', 'a', 'e' },
                new char[] { 'i','h','k','r' },
                new char[] { 'i', 'f', 'l', 'v' }
            };
            var words = new string[] { "oath", "pea", "eat", "rain" };
            return string.Join(",", FindWords(board, words));
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var result = new List<string>();
            foreach (var word in words)
            {
                var containWords = new bool[word.Length];
                for (int i = 0; i < word.Length; i++)
                {
                    var ans = false;
                    var character = word[i];
                    foreach (var name in board)
                    {
                        if (name.Contains(character))
                        {
                            ans = true;
                            break;
                        }
                    }
                    if (!ans)
                        break;
                    else
                        containWords[i] = true;
                }
                if (containWords.All(x => x))
                    result.Add(word);
                
            }
            return result;
        }
    }
}
