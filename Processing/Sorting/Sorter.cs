namespace SimpleLibraryProject.Processing.Sorting
{
    public class Sorter
    {
        public static async Task<List<DateTime>> OrderListByDate(List<DateTime> list)
        {
            IOrderedEnumerable<DateTime> enumerable = list.OrderByDescending(x => x.Date);
            
            List<DateTime> ret = new();
            ret.AddRange(enumerable);

            return ret;
        }
    }
}