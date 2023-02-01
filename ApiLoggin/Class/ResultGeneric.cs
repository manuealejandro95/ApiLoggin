namespace ApiLoggin.Class
{
    public class ResultGeneric<T>
    {
        public T result { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
        public int? codError { get; set; }

        public void SetError(string message, int codError, T result)
        {
            this.message = message;
            this.error = true;
            this.codError = codError;
            this.result = result;
        }

        public ResultGeneric<Object> GenereSetError(Exception e, int codError)
        {
            ResultGeneric<Object> r = new ResultGeneric<object>();
            r.SetError(e.Message, codError, e.InnerException?.Message);
            return r;
        }

        public void SetOk(T result)
        {
            this.message = "Ok";
            this.error = false;
            this.codError = 0;
            this.result = result;
        }
    }
}
