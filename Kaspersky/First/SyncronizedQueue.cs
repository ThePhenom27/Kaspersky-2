using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaspersky.First
{
    class SyncronizedQueue<T>
    {
        private object _locker = new object();
        private Queue<T> _queue = new Queue<T>();

        public void Push(T item)
        {
            lock (_locker)
            {
                _queue.Enqueue(item);
                Monitor.Pulse(_locker);
            }
        }

        public T Pop()
        {
            lock (_locker)
            {
                if (0 == _queue.Count)
                {
                    Monitor.Wait(_locker);
                }
                return _queue.Dequeue();
            }

        }
    }
}
