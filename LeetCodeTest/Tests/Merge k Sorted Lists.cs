using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    class Merge_k_Sorted_Lists : ISolution
    {
        public string Method()
        {
            var lists = new ListNode[] {
                CreateNode(new List<int> { 1, 4, 5 }),
                CreateNode(new List<int> { 1, 3, 4 }),
                CreateNode(new List<int> { 2, 6 })
            };
            var node = MergeKLists(lists);
            return ConvertToStr(node);
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            var result = new List<int>();
            foreach (var item in lists)
            {
                if (item != null)
                    result.AddRange(ConvertToList(item));
            }
            result.Sort();
            return result.Count == 0 ? null : CreateNode(result);
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
