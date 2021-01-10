using System;
using Aids.Logging;

namespace Aids.Methods
{
    public static class Safe {

        private static readonly object Key = new object();

        public static T Run<T>(Func<T> function, T valueOnException,
            bool useLock = false) => useLock
            ? LockedRun(function, valueOnException)
            : Run(function, valueOnException);

        public static void Run(Action action, bool useLock = false) {
            if (useLock) LockedRun(action);
            else Run(action);
        }

        private static T LockedRun<T>(Func<T> function, T valueOnException) {
            lock (Key) { return Run(function, valueOnException); }
        }

        private static void LockedRun(Action action) {
            lock (Key) { Run(action); }
        }

        private static T Run<T>(Func<T> function, T valueOnException) {
            try { return function(); }
            catch (Exception e) {
                Log.Exception(e);

                return valueOnException;
            }
        }

        private static void Run(Action action) {
            try { action(); }
            catch (Exception e) { Log.Exception(e); }
        }
    }
}