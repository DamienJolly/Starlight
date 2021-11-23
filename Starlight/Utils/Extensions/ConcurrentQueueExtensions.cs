using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Starlight.Utils.Extensions
{
    internal static class ConcurrentQueueExtensions
    {
        /// <summary>
        /// Drains the concurrent queue into a list
        /// </summary>
        internal static List<T> Dequeue<T>(this ConcurrentQueue<T> queue)
        {
            var list = new List<T>();

            while (queue.Count > 0)
            {
				if (queue.TryDequeue(out T element))
					list.Add(element);
			}

            return list;
        }
    }
}
