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
        // Method that checks and returns whether it is a one-dimensional array.
        // Phương thức kiểm tra và trả về là mảng 1 chiều
        public static int GetNumberOfDimensionOfAnArray<T>(T[] arr)
        {
            // The input is a one-dimensional array, so it returns 1.
            // Đầu vào là mảng 1 chiều nên trả về 1
            return 1;
        }
        // Method that checks and returns whether it is a two-dimensional array.
        // Phương thức kiểm tra và trả về là mảng 2 chiều
        public static int GetNumberOfDimensionOfAnArray<T>(T[,] arr)
        {
            // The input is a two-dimensional array, so it returns 2.
            // Đầu vào là mảng 2 chiều nên trả về 2
            return 2;
        }

        // Method that return the length of each dimension
        // Phương thức trả về độ dài của mảng theo từng chiều
        public static int GetLengthOfEachDimension<T>(T[] arr)
        {
            // The input is a one-dimensional array, so it will return the size of the one-dimensional array.
            // Đầu vào là mảng 1 chiều nên sẽ trả về kích thước của mảng 1 chiều
            return GetLenghtOfAnArray(arr);
        }
        public static int GetLengthOfEachDimension<T>(T[,] arr, int dimension)
        {
            int row = 0;
            int coloum = 0;

            for(int i = 0; i < arr.GetLength(0); i++)
            {
                row++;
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == 0) coloum++;
                }
            }

            if (dimension == 0) return row;
            if(dimension == 1) return coloum;
            else return -1;
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

            Console.WriteLine($"Mảng matrix có {ArrayMethod.GetLengthOfEachDimension(matrix, 0)} hàng và {ArrayMethod.GetLengthOfEachDimension(matrix, 1)} cột");
        }
    }
}
