namespace FrancoHotel.Domain.Base
{
    public class OperationResult<TData>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }
    }
}
