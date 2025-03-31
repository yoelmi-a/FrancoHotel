namespace FrancoHotel.WebApi.Models
{
    public class OperationResultModel<TData> where TData : class
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public TData Data { get; set; }
    }
}
