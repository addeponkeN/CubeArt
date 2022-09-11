namespace Script.Util
{
    public static class IndexHelper
    {
        public static int ToIndex1D(int x, int y, int width)
        {
            return x + y * width;
        }

        public static void ToIndex2D(int i, int width, int height, out int x, out int y)
        {
            x = i % width;
            y = i / height;
        }
    }
}