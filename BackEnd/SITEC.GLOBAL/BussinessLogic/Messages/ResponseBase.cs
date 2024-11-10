namespace SITEC.GLOBAL.BussinessLogic.Messages
{
    public class ResponseBase<T>
    {
        public ResponseType Type { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
