using LeetCodeRunner.ExternalClasses;

namespace LeetCodeRunner.Problems.Easy
{
    public class P_83_RemoveDuplicatesFromSortedList
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;

            ListNode result = new ListNode();
            ListNode aux = result;
            int actualNumber = head.val;

            result.val = actualNumber;
            head = head.next;

            while (head != null)
            {
                if(head.val != actualNumber)
                {
                    aux.next = new ListNode(head.val);
                    aux = aux.next;
                    actualNumber = head.val;
                }

                head = head.next;
            }

            return result;
        }
    }
}