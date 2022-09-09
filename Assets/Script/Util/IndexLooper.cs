namespace Script.Util
{
    public struct IndexLooper
    {
        public int Length;
        public int CurrentIndex;

        public IndexLooper(int length)
        {
            Length = length;
            CurrentIndex = 0;
        }

        public int Next()
        {
            CurrentIndex++;
            return CurrentIndex %= Length;
        }

        public int Previous()
        {
            if(--CurrentIndex >= Length)
                CurrentIndex = 0;
            return CurrentIndex;
        }
        
    }
}