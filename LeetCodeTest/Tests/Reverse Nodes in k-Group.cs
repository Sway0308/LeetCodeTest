using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
    /// k is a positive integer and is less than or equal to the length of the linked list.
    /// If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
    /// </summary>
    class Reverse_Nodes_in_k_Group : ISolution
    {
        public string Method()
        {
            var head = CreateNode(new List<int> { 1, 2, 3, 4, 5 });
            var k = 3;
            var node = ReverseKGroup(head, k);
            return ConvertToStr(node);
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var list = ConvertToList(head);
            var quotient = list.Count / k;
            var remainder = list.Count % k;
            var newList = new List<int>();
            for (int i = 0; i < quotient; i++)
            {
                var index = k * i;
                for (int j = k - 1; j >= 0; j--)
                {
                    newList.Add(list.ElementAt(index + j));
                }
            }

            if (remainder > 0)
            {
                var remainList = list.Skip(quotient * k);
                foreach (var item in remainList)
                {
                    newList.Add(item);
                }
            }

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

        private string ConvertToStr(ListNode node)
        {
            var result = node.val.ToString();
            node = node.next;
            while (node != null)
            {
                result += node.val.ToString();
                node = node.next;
            }
            return result;
        }
    }
}
