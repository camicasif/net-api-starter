namespace dotnet_api_template.DTOs
{
    public class ResponseDto<T>
    {
        public bool EsExitoso { get; set; }
        public string? Mensaje { get; set; }
        public T? Data { get; set; }

        public static ResponseDto<T> Success(T data) =>
            new ResponseDto<T> { EsExitoso = true, Data = data };

        public static ResponseDto<T> Fail(string mensaje) =>
            new ResponseDto<T> { EsExitoso = false, Mensaje = mensaje };
    }
}
