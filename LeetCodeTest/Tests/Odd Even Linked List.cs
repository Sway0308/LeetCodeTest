using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a singly linked list, group all odd nodes together followed by the even nodes. 
    /// Please note here we are talking about the node number and not the value in the nodes.
    /// You should try to do it in place.The program should run in O(1) space complexity and O(nodes) time complexity.
    /// </summary>
    class Odd_Even_Linked_List : ISolution, IMedium, IComplete
    {
        public string Method()
        {
            var head = //CreateNode(new List<int> { 1, 2, 3, 4, 5 });
                       CreateNode(new List<int> { 2, 1, 3, 5, 6, 4, 7 });
            var node = OddEvenList(head);
            return node.ConvertToStr();
        }

        public ListNode OddEvenList(ListNode head)
        {
            var list = ConvertToList(head);
            var reList = new List<int>();
            var index = 0;
            AddElement(reList, list, index);

            index = 1;
            AddElement(reList, list, index);
            return CreateNode(reList);
        }

        private void AddElement(List<int> reList, IEnumerable<int> list, int index)
        {
            while (index <= list.Count() - 1)
            {
                reList.Add(list.ElementAt(index));
                index += 2;
            }
        }

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

        private IEnumerable<int> ConvertToList(ListNode node)
        {
            while (node != null)
            {
                yield return node.val;
                node = node.next;
            }
        }
    }
}
