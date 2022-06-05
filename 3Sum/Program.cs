public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
      // Step 1 - Sort the input array so that we can avoid three loops
      // when the input array is sorted we know the values are in desc order, we can use binary search concept here
      // Step 2 -we take one element from the starting of the array say ith index, and then take the boundary from next element (i+1) to the end
      // We calculate nums[i]+nums[i+1]+nums[end] and check is sum 0, if yes push all the indexes in result
      // Step 3 -as the question has asked not to include duplicate sets as an answer, to avoid getting duplicate, we can check the current element and prev elemnts are same ? if yes ignore that position and increment (i+1) to next and end to prev until we found non duplicate element.
      // Step 1 
      Array.Sort(nums); // O(n longn)
      
      IList<IList<int>> result = new List<IList<int>>();
      // Step 2
      for(int i = 0 ; i < nums.Length; i++) {
        // for each i create the boundary for the other two element which all sum and make 0
        if(i != 0 && nums[i] == nums[i-1]) continue;
        // boundary
        int l = i+1; int r = nums.Length - 1;
        while(l < r) {
          // use binary search concept here, as the boundary is sorted
          int sum = nums[i]+nums[l]+nums[r];
          if(sum == 0){
            result.Add(new List<int>() {nums[i], nums[l], nums[r]});
            while(l < r && nums[l] == nums[l+1]) l++;
            while(l < r && nums[r] == nums[r-1]) r--;
            l++;r--; 
          } else if(sum < 0) {
            l++;
          } else{
            r--;
          }
        }
      }
      
      return result;
    }
}
