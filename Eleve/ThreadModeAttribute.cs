using System;

namespace Eleve
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ThreadModeAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public ThreadModeAttribute(ThreadMode mode)
        {
            ThreadMode = mode;
        }
        /// <summary></summary>
        public ThreadMode ThreadMode { get; private set; }
    }
}
