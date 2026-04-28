using System.Runtime.InteropServices;

namespace ArrayMethod
{
    public class ArrayMethod
    {
        // Method that returns the length of an array
        // Phương thức trả về độ dài của mảng
        public static int GetLenghtOfAnArray<T> (T[] arr)
        {
            // Initialize a variable to count the elements in the array.
            // Khởi tạo biến đếm phần tử có trong mảng

            int count = 0;

            // Use a foreach loop to iterate through the entire array without needing to know the length of the array.
            // Sử dụng vòng lặp foreach để duyệt qua toàn bộ mảng mà không cần biết chiều dài của mảng

            foreach (var i in arr)
            {
                count++;
            }

            // Return size of an Array
            // Trả về kích thước của mảng

            return count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(ArrayMethod.GetLenghtOfAnArray(nums));
        }
    }
}
