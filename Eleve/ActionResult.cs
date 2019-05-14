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
        public static ActionResult OK { get { return new ActionResult(ActionStatus.OK); } }

        /// <summary></summary>
        public ActionStatus Status { get; private set; }
        /// <summary></summary>
        public string Message { get; set; }
    }
}
