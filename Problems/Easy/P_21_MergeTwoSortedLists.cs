using LeetCodeRunner.ExternalClasses;

namespace LeetCodeRunner.Problems
{
    public class P_21_MergeTwoSortedLists
    {
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {

            ListNode aux = new ListNode();
            ListNode result = aux;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    result.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    result.next = list2;
                    list2 = list2.next;
                }
                result = result.next;
            }

            if (list1 == null) result.next = list2;
            else if (list2 == null) result.next = list1;

            return aux.next;
        }
    }
}