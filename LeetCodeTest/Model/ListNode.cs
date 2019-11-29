using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public string ConvertToStr()
        {
            var node = this;
            var result = node.val.ToString();
            node = node.next;
            while (node != null)
            {
                result += node.val.ToString();
                node = node.next;
            }
            return result;
        }


        public static ListNode CreateNode(int[] vals)
        {
            var firstNode = new ListNode(vals[0]);
            var node = firstNode;
            for (int i = 0; i < vals.Length; i++)
            {
                if (i == 0)
                    continue;

                node.next = new ListNode(vals[i]);
                node = node.next;
            }
            return firstNode;
        }

        public static ListNode CreateNode(List<int> vals)
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
