namespace Util
{
    public struct CubeBytePoint
    {
        public byte X;
        public byte Y;
        public CubeBytePoint(int x, int y) :this((byte)x, (byte)y) { }
        public CubeBytePoint(byte x, byte y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}