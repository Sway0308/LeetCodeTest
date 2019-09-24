using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Merge two sorted linked lists and return it as a new list. 
    /// The new list should be made by splicing together the nodes of the first two lists.
    /// </summary>
    class Merge_Two_Sorted_Lists : ISolution
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
            var l1 = CreateNode(new List<int> { 1, 2, 4 });
            var l2 = CreateNode(new List<int> { 1, 3, 4 });
            //var l1 = CreateNode(new List<int> { 9 });
            //var l2 = CreateNode(new List<int> { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 });
            //var l1 = CreateNode(new List<int> { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
            //var l2 = CreateNode(new List<int> { 5, 6, 4 });
            var node = MergeTwoLists(l1, l2);
            var ans = ConvertToStr(node);
            return ans;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var list1 = ConvertToList(l1);
            var list2 = ConvertToList(l2);
            list1.AddRange(list2);
            list1.Sort();
            return CreateNode(list1);
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
