using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a linked list, remove the n-th node from the end of list and return its head.
    /// </summary>
    class Remove_Nth_Node_From_End_of_List : ISolution, IMedium, IComplete
    {
        private ListNode CreateNode(List<int> vals)
        {
            if (vals.Count == 0)
                return null;

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

        public string Method()
        {
            var head = //CreateNode(new List<int> { 1, 2, 3, 4, 5 });
                       CreateNode(new List<int> { 1 });
            var n = 1;
            var node = RemoveNthFromEnd(head, n);
            return node.ConvertToStr();
        }

        private ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var list = ConvertToList(head);
            list.RemoveAt(list.Count - n);
            return CreateNode(list);
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
