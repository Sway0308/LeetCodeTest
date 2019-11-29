using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers. 
    /// The digits are stored in reverse order and each of their nodes contain a single digit. 
    /// Add the two numbers and return it as a linked list.
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// </summary>
    class Add_Two_Numbers : ISolution, IMedium, IComplete
    {
        private ListNode CreateNode(int[] vals)
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

        public string Method()
        {
            //var l1 = CreateNode(new int[] { 2, 4, 3 });
            //var l2 = CreateNode(new int[] { 5, 6, 4 });
            //var l1 = CreateNode(new int[] { 9 });
            //var l2 = CreateNode(new int[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 });
            var l1 = CreateNode(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
            var l2 = CreateNode(new int[] { 5, 6, 4 });
            var node = AddTwoNumbers(l1, l2);
            var ans = node.ConvertToStr();
            return ans;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var num1 = l1 != null ? l1.val : 0;
            var num2 = l2 != null ? l2.val : 0;
            var sum = num1 + num2;
            var carry = sum / 10;
            var val = sum % 10;

            var firstNode = new ListNode(val);

            l1 = l1?.next;
            l2 = l2?.next;

            var node = firstNode;
            while (l1 != null || l2 != null || carry != 0)
            {
                num1 = l1 != null ? l1.val : 0;
                num2 = l2 != null ? l2.val : 0;
                sum = num1 + num2 + carry;
                val = sum % 10;
                node.next = new ListNode(val);
                node = node.next;
                carry = sum / 10;
                l1 = l1?.next;
                l2 = l2?.next;
            }
            return firstNode;
        }
    }
}
