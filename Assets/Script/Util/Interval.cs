namespace Script.Util
{
    public struct Timer
    {
        public float Interval;
        float _timer;
        
        public Timer(float interval) : this()
        {
            Interval = interval;
        }

        public bool UpdateTick(float delta)
        {
            _timer += delta;
            if(_timer >= Interval)
            {
                _timer -= Interval;
                return true;
            }

            return false;
        }

        public static implicit operator Timer(float interval) => new Timer() {Interval = interval};

    }
}