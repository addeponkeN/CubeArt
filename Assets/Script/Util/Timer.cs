namespace Script.Util
{
    public struct Timer
    {
        float _timer;
        
        public float Interval;
        
        public Timer(float interval) : this()
        {
            Interval = interval;
        }

        public bool UpdateTick(float delta)
        {
            if((_timer += delta) >= Interval)
            {
                _timer -= Interval;
                return true;
            }

            return false;
        }

        public static implicit operator Timer(float interval) => new(interval);

    }
}