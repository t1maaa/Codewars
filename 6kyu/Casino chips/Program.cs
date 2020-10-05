using System;
public class Solution
{
    public static int solve(int [] arr){  
      const int limitPerDay = 2;
      int days = 0;
      bool fl = false;
      do {
        Array.Sort(arr, (a,b) => b - a);      
        for(int i=0;i<limitPerDay; i++)
        {
          if(--arr[i] >= 0)
            continue;
          fl = true;
            break;
        }
        if(!fl) days++;
        else return days;
      } while(!fl);
      return days;
    }
}
