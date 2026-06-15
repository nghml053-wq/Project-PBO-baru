namespace Project_PBO_baru.Services
{
    // Renamed to avoid duplicate with existing ServiceResult
    internal class ServiceResultNew
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ServiceResultNew Ok(string msg = "") => new ServiceResultNew { Success = true, Message = msg };
        public static ServiceResultNew Fail(string msg) => new ServiceResultNew { Success = false, Message = msg };
    }
}
