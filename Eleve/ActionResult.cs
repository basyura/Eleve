namespace Eleve
{
    public class ActionResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        public ActionResult(ActionStatus status)
        {
            Status = status;
        }
        /// <summary></summary>
        public ActionStatus Status { get; private set; }
    }
}
