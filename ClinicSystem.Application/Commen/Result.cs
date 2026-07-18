namespace ClinicSystem.Application.Commen
{
    public class Result
    {
        public bool IsSuccessed { get; private set; }
        public string? Message { get; private set; } = string.Empty;
        public List<string>? Errors { get; set; } = new List<string>();

        protected Result(bool isSuccessed,string message,List<string>? errors)
        {
            IsSuccessed = isSuccessed;
            Message = message;
            Errors = errors ?? new List<string>();
        }
        protected Result(bool isSuccessed,string message)
        {
            IsSuccessed = isSuccessed;
            Message = message;
            
        }
        public static Result Success(string message = "Opration Completed Successfully")
        => new Result(true,message);
        public static Result Faild(string message)
        => new Result(false,message);
        public static Result Faild(List<string> errors,string message)
        => new Result(false,message,errors);
        




        

    }
    public class Result<T> : Result
    {
        public T? Data { get; set; }
        private Result(bool isSuccessed,string message, T? data) : base(isSuccessed,message) 
        {
            Data = data;
        }
        private Result(List<string> errors,bool isSuccessed,string message, T? data) : base(isSuccessed,message,errors) 
        {
            Data = data;
        }
        public static Result<T> Success( T? data, string message = "Opration Completed Successfully")
       => new Result<T>(true, message,data);
        public static Result<T> Faild(string message, T data)
        => new Result<T>(false, message,data);
        public static Result<T> Faild(List<string> errors, string message,T data)
        => new Result<T>(errors,false, message,data);
        
    }
}
