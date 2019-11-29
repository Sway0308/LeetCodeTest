using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Sort a linked list in O(n log n) time using constant space complexity.
    /// 
    /// Example 1:
    /// 
    ///     Input: 4->2->1->3
    ///     Output: 1->2->3->4
    /// </summary>
    class Sort_List : ISolution, IHard, IComplete
    {
        public string Method()
        {
            var head = CreateNode(new List<int> { 4, 1, 2, 3 });
            var node = SortList(head);
            return node.ConvertToStr();
        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var result = new List<int>();
            while (head != null)
            {
                var value = head.val;
                var insert = false;
                for (int i = 0; i < result.Count; i++)
                {
                    if (value < result[i])
                    {
                        result.Insert(i, value);
                        insert = true;
                        break;
                    }
                }
                if (!insert)
                    result.Add(value);
                head = head.next;
            }
            return CreateNode(result);
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
            result.Reverse();
            return result;
        }
    }
}
