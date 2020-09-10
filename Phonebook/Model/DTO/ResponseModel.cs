namespace Model.DTO
{
    public class ResponseModel<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
    }
}
