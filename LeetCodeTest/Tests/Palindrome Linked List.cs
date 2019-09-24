using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a singly linked list, determine if it is a palindrome.
    /// </summary>
    class Palindrome_Linked_List : ISolution
    {
        public string Method()
        {
            var head = CreateNode(new List<int> { 1, 0, 0 });
            var ans = IsPalindrome(head);
            return ans.ToString();
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;
            var list = ConvertToList(head);
            var quotient = list.Count / 2;
            for (int i = 0; i < quotient; i++)
            {
                if (list.ElementAt(i) != list.ElementAt(list.Count - 1 - i))
                    return false;
            }
            return true;
        }

        private ListNode CreateNode(List<int> vals)
        {
            var firstNode = new ListNode(vals[0]);
            var node = firstNode;
            for (int i = 0; i < vals.Count; i++)
            {
                if (i == 0)
                    continue;

                node.next = new ListNode(vals[i]);
                node = node.next;
            }
            return firstNode;
        }

        private List<int> ConvertToList(ListNode node)
        {
            var result = new List<int>();
            while (node != null)
            {
                result.Add(node.val);
                node = node.next;
            }
            return result;
        }
    }
}
