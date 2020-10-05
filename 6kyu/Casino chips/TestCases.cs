using NUnit.Framework;
using System;
 
[TestFixture]
public class SolutionTest
{
  [Test]
  public void ExampleTests()
  {
    Assert.AreEqual(1, Solution.solve(new int[] {1,1,1}));
    Assert.AreEqual(2, Solution.solve(new int[] {1,2,1}));    
    Assert.AreEqual(2, Solution.solve(new int[] {4,1,1}));
    Assert.AreEqual(9, Solution.solve(new int[] {8,2,8}));
    Assert.AreEqual(5, Solution.solve(new int[] {8,1,4}));
    Assert.AreEqual(10, Solution.solve(new int[] {7,4,10}));
    Assert.AreEqual(18, Solution.solve(new int[] {12,12,12}));
    Assert.AreEqual(3, Solution.solve(new int[] {1,23,2}));
    Assert.AreEqual(6, Solution.solve(new int[] {10,5,1}));
  }

  private static int c12(int [] arr){  
      Array.Sort(arr);
      return Math.Min((arr[0] + arr[1] + arr[2])/2|0, arr[0] + arr[1]);
  }

  [Test]
  public void RandomTestsA(){
    Random random = new Random(); 
    for (int i = 0; i < 100; i++){ 
      int[] arr = new int[3];
      arr[0] = random.Next(1, 10);       
      arr[1] = random.Next(1, 10);  
      arr[2] = random.Next(1, 10);  
      int exp = c12(arr);
      Assert.AreEqual(exp,Solution.solve(arr));
    }    
  }
  
  [Test]
  public void RandomTestsB(){
    Random random = new Random(); 
    for (int i = 0; i < 100; i++){ 
      int[] arr = new int[3];
      arr[0] = random.Next(1, 1000000);       
      arr[1] = random.Next(1, 1000000);  
      arr[2] = random.Next(1, 1000000);  
      int exp = c12(arr);
      Assert.AreEqual(exp,Solution.solve(arr));
    }    
  }
}
