using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameDevUtils.AwaitableExtensions
{
    public static class AwaitableExtensions
    {
        public static async Awaitable<T> AwaitTask<T>(this Task<T> task)
        {
            await task;
            await Awaitable.NextFrameAsync();
            return task.Result;
        }

        public static async void WailUntil(Func<bool> condition)
        {
            while (!condition()) await Awaitable.NextFrameAsync();
        }
    }
}