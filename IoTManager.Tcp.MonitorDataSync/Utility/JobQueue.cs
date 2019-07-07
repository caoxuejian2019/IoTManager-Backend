using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync.Utility
{
    public sealed class JobQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        public void Add(T t)
        {
            this._queue.Enqueue(t);
        }

        public T Acquire()
        {
            return this._queue.Dequeue();
        }
    }
}
