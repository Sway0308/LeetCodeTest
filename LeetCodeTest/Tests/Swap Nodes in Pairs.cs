using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a linked list, swap every two adjacent nodes and return its head.
    /// You may not modify the values in the list's nodes, only nodes itself may be changed.
    /// </summary>
    class Swap_Nodes_in_Pairs : ISolution, IMedium, IComplete
    {
        public string Method()
        {
            var head = CreateNode(new List<int> { 1, 2, 3, 4 });
            var node = SwapPairs(head);
            return node.ConvertToStr();
        }

        public ListNode SwapPairs(ListNode head)
        {
            var list = ConvertToList(head);
            var quotient = list.Count / 2;
            var remainder = list.Count % 2;
            var newList = new List<int>();
            for (int i = 0; i < quotient; i++)
            {
                var index = 2 * i;
                newList.Add(list.ElementAt(index + 1));
                newList.Add(list.ElementAt(index));
            }
            if (remainder != 0)
                newList.Add(list.Last());
            return newList.Count == 0 ? null : CreateNode(newList);
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
