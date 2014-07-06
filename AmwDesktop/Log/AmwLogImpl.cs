using System.Collections.Generic;

namespace AirMedia.Core.Log
{
    public class AmwLogImpl : AmwLog
    {
        private static readonly string LogTag = typeof (AmwLogImpl).Name;
        private static readonly object Mutex = new object();

        private volatile bool _isRequestHandlerRegistered;
        private bool _isDisposed;

        protected override void DispatchLogRequest(LogLevel level, string tag, 
            string displayMessage, string details, params object[] args)
        {
            base.DispatchLogRequest(level, tag, displayMessage, details, args);
        }

        protected override void PerformEntryLog(LogEntry entry)
        {
            System.Diagnostics.Debug.WriteLine(entry);
        }

        protected override void SaveEntries(IEnumerable<LogEntry> entries)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_isDisposed) return;

            if (disposing)
            {
            }

            _isDisposed = true;
        }
    }
}
