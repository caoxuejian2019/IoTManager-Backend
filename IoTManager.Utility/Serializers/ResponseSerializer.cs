using System;

namespace IoTManager.Utility.Serializers
{
    public class ResponseSerializer
    {
        public ResponseSerializer(int _c, String _m, object _d)
        {
            this.c = _c;
            this.m = _m;
            this.d = _d;
        }
        
        public int c { get; set; }
        public String m { get; set; }
        public object d { get; set; }
    }
}