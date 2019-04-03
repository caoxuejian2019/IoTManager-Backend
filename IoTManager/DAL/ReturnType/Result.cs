using System;

namespace IoTManager.DAL.ReturnType
{
    public class Result
    {
        public Result()
        {
            c = 0;
            m = null;
            d = null;
        }

        public Result(int _c, String _m, object _d)
        {
            c = _c;
            m = _m;
            d = _d;
        }
        
        public int c { get; set; }
        public String m { get; set; }
        public object d { get; set; }
    }
}