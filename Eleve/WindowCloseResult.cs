namespace Eleve
{
    public class WindowCloseResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="result"></param>
        public WindowCloseResult(WindowCloseType type, object result)
        {
            Type = type;
            Result = result;
        }
        /// <summary></summary>
        public WindowCloseType Type { get; private set; }

        /// <summary></summary>
        public object Result { get; private set; }
    }
}
