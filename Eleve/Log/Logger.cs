using System.IO;
using System.Reflection;
using System.Diagnostics;
using log4net;
using log4net.Config;

namespace Eleve.Log
{
    public class Logger
    {
        /// <summary>
        /// ログ出力の初期化を行う
        /// </summary>
        static Logger()
        {
            string dir  = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(dir, "log4net.config");
            if (File.Exists(path))
            {
                XmlConfigurator.Configure(new FileInfo(path));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="param"></param>
        public static void Deubg(string message, params object[] param)
        {
            Log(LogLevel.Debug, message, param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="param"></param>
        public static void Info(string message, params object[] param)
        {
            Log(LogLevel.Info, message, param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="param"></param>
        private static void Log(LogLevel level, string message, params object[] param)
        {
            ILog logger = GetLogger();
            // 出力レベル判定
            switch (level)
            {
                case LogLevel.Debug:
                    if (!logger.IsDebugEnabled) { return; }
                    break;
                case LogLevel.Info:
                    if (!logger.IsInfoEnabled)  { return; }
                    break;
                case LogLevel.Warn:
                    if (!logger.IsWarnEnabled)  { return; }
                    break;
                case LogLevel.Error:
                    if (!logger.IsErrorEnabled) { return; }
                    break;
                default:
                    break;
            }
            // 再フォーマット 
            if (param.Length != 0)
            {
                message = string.Format(string.Format(message, param));
            }
            // コンソールに出したいがためにフォーマットしてからの再度の出力判定
            switch (level)
            {
                case LogLevel.Debug:
                    logger.Debug(message);
                    break;
                case LogLevel.Info:
                    logger.Info(message);
                    break;
                case LogLevel.Warn:
                    logger.Warn(message);
                    break;
                case LogLevel.Error:
                    logger.Error(message);
                    break;
                default:
                    break;
            }
            // 
            Debug.WriteLine(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static ILog GetLogger()
        {
#if DEBUG
            return LogManager.GetLogger("development.log");
#else
            return LogManager.GetLogger("production.log");
#endif
        }
    }
}
