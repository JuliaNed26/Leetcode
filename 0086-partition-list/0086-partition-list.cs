/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        ListNode lessHead = null;
        ListNode less = null;
        ListNode greatHead = null;
        ListNode greater = null;
        var curNode = head;
        while(curNode != null)
        {
            if(curNode.val < x)
            {
                if(less == null)
                {
                    lessHead = new ListNode(curNode.val);
                    less = lessHead;
                }
                else
                {
                    less.next = new ListNode(curNode.val);
                    less = less.next;
                }
            }
            else
            {
                if(greater == null)
                {
                    greatHead = new ListNode(curNode.val);
                    greater = greatHead;
                }
                else
                {
                    greater.next = new ListNode(curNode.val);
                    greater = greater.next;
                }
            }
            curNode = curNode.next;
        }

        if(lessHead != null)
        {
            less.next = greatHead;
            return lessHead;
        }

        return greatHead;
    }
}