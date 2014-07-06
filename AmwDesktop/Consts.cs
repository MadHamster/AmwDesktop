using AirMedia.Core.Log;

namespace AirMedia.Core
{
    public static class Consts
    {
        public const int DefaultWebClientTimeout = 5000;

#if DEBUG
        public const bool Debug = true;
#else
        public const bool Debug = false;
#endif

        #region In-App Logging Settings

#if DEBUG
        public const bool IsInAppLoggingEnabled = true;

        /// <summary>
        /// Set global log level
        /// </summary>
        public const LogLevel TmLogLevel = LogLevel.Verbose;
#else
        public const bool IsInAppLoggingEnabled = true;
        public const LogLevel TmLogLevel = LogLevel.Info;
#endif
        #endregion
    }
}