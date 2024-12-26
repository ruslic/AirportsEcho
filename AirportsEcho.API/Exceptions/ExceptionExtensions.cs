namespace AirportsEcho.API
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Получение внутреннего исключения
        /// </summary>
        public static Exception GetOriginalException(this Exception ex)
        {
            if (ex.InnerException == null)
                return ex;

            return ex.InnerException.GetOriginalException();
        }
    }
}
