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
    /// Note:
    ///     Only constant extra memory is allowed.
    ///     You may not alter the values in the list's nodes, only nodes itself may be changed.
    /// </summary>
    class Reverse_Nodes_in_k_Group : ISolution, IHard//, IComplete
    {
        public string Method()
        {
            var head = ListNode.CreateNode(new List<int> { 1, 2, 3, 4, 5 });
            var k = 3;
            var node = ReverseKGroup(head, k);
            return node.ConvertToStr();
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null)
                return head;

            var nodes = ExtractListNode(head);
            var sortedNodes = SortNodes(nodes, k);
            head = sortedNodes.Last();
            for (int i = sortedNodes.Count() - 2; i >= 0; i--)
            {
                sortedNodes.ElementAt(i).next = head;
                head = sortedNodes.ElementAt(i);
            }
            return head;
        }

        private IEnumerable<ListNode> ExtractListNode(ListNode node)
        {
            var result = new List<ListNode>();
            while (node != null)
            {
                var nextNode = node.next;
                node.next = null;
                result.Add(node);
                node = nextNode;
            }
            return result;
        }

        private IEnumerable<ListNode> SortNodes(IEnumerable<ListNode> nodes, int k)
        {
            var result = new List<ListNode>();
            var quotient = nodes.Count() / k;
            for (int i = 0; i < quotient; i++)
            {
                var index = k * i;
                for (int j = k - 1; j >= 0; j--)
                {
                    result.Add(nodes.ElementAt(index + j));
                }
            }

            var remainder = nodes.Count() % k;
            if (remainder > 0)
            {
                var remainList = nodes.Skip(quotient * k);
                foreach (var item in remainList)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
