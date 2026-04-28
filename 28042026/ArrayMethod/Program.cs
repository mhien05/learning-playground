using System.Runtime.InteropServices;
using System.Text;

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
        public static int GetNumberOfDimensionOfAnArray<T>(T[] arr)
        {
            return 1;
        }
        public static int GetNumberOfDimensionOfAnArray<T>(T[,] arr)
        {
            return 2;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Set console output to allow typing Vietnamese in UTF-8.
            // Đặt console output cho phép gõ tiếng việt UTF-8

            Console.OutputEncoding = Encoding.UTF8;


            // Test array
            // Mảng dùng để test

            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int[,] matrix = { { 1, 3, 5, 7 }, { 2, 4, 6, 8 } };

            // Get Length of an array
            // Lấy độ dài của mảng

            Console.WriteLine($"Độ dài của mảng nums: {ArrayMethod.GetLenghtOfAnArray(nums)}.\n");

            // Check array dimension
            // Kiểm tra mảng 1 hay 2 chiều
            Console.WriteLine($"Mảng nums là mảng {ArrayMethod.GetNumberOfDimensionOfAnArray(nums)} chiều.\n");
            Console.WriteLine($"Mảng matrix là mảng {ArrayMethod.GetNumberOfDimensionOfAnArray(matrix)} chiều.\n");
            
        }
    }
}
