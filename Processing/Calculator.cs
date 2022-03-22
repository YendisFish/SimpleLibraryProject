namespace SimpleLibraryProject.Processing
{
    public class Calculator
    {
        public static async Task<int> CalculateMean(List<int> nums)
        {
            int start = 0;
            foreach (int num in nums)
            {
                start = start + num;
            }

            return start / nums.Count;
        }
        
        public static async Task<int> CalculateMean(int[] nums)
        {
            int start = 0;
            foreach (int num in nums)
            {
                start = start + num;
            }

            return start / nums.Length;
        }
    }
}