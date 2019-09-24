using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    class Add_Two_Numbers_II : ISolution
    {
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

        public string Method()
        {
            var l1 = CreateNode(new List<int> { 7, 2, 4, 3 });
            var l2 = CreateNode(new List<int> { 5, 6, 4 });
            //var l1 = CreateNode(new List<int> { 9 });
            //var l2 = CreateNode(new List<int> { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 });
            //var l1 = CreateNode(new List<int> { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
            //var l2 = CreateNode(new List<int> { 5, 6, 4 });
            var node = AddTwoNumbers(l1, l2);
            var ans = ConvertToStr(node);
            return ans;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var queueOne = new Queue<int>(ConvertToList(l1));
            var queueTwo = new Queue<int>(ConvertToList(l2));
            var node = new List<int>();
            var carry = 0;

            while (queueOne.Count != 0 || queueTwo.Count != 0 || carry != 0)
            {
                queueOne.TryDequeue(out var num1);
                queueTwo.TryDequeue(out var num2);
                var sum = num1 + num2 + carry;
                var val = sum % 10;
                node.Add(val);
                carry = sum / 10;
            }
            node.Reverse();
            return CreateNode(node);
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
