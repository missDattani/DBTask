namespace WebApplicationAllOverTopics.Middleware
{
    public class CustomMiddleware
    {
        #region Fileds
        private readonly RequestDelegate _requestDelegate;
        private readonly IWebHostEnvironment _environment;
        #endregion

        #region Constructor
        public CustomMiddleware(RequestDelegate requestDelegate, IWebHostEnvironment environment)
        {
            _requestDelegate = requestDelegate;
            _environment = environment;
        }
        #endregion

        #region Methods
        public async Task Invoke(HttpContext context)
        {
            try
            {
                var logFilePath = Path.Combine(_environment.WebRootPath, "ReqResLogs", "Log_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                if (!File.Exists(logFilePath))
                {
                    var myFile = File.Create(logFilePath);
                    myFile.Close();
                }

                using StreamWriter sw = File.AppendText(logFilePath);
                sw.WriteLine("");
                sw.WriteLine("Request");
                sw.WriteLine(context.Request.Path.Value);
                sw.WriteLine("Response");
                await _requestDelegate(context);
                sw.WriteLine(context.Response.StatusCode);
            }
            catch (Exception ex)
            {

                AddExceptionLog(ex, context);
            }
        }

        public void AddExceptionLog(Exception ex,HttpContext context)
        {
            var logFile = Path.Combine(_environment.WebRootPath, "ExceptionLogs", "Exception_" + Path.GetFileName(DateTime.Now.ToString("dd_MM_yyyy") + ".txt"));
            if(!File.Exists(logFile))
            {
                var myFile = File.Create(logFile);
                myFile.Close();
            }

            using StreamWriter sw = File.AppendText(logFile);
            sw.WriteLine("");
            sw.WriteLine("Request");
            sw.WriteLine(context.Request.Path.Value);
            sw.WriteLine("Exception");
            sw.WriteLine(ex.Message);
            sw.WriteLine(ex.InnerException);
            if(ex.InnerException != null)
            {
                sw.WriteLine(ex.InnerException.InnerException);
            }
            sw.Close();
        }

        public void DeleteOldLogFiles()
        {
            try
            {
                var directoryPath = Path.Combine(_environment.WebRootPath, "ReqResLogs");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string[] AllFiles = Directory.GetFiles(directoryPath);

                foreach (string fileName in AllFiles)
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    if (fileInfo.LastAccessTime < DateTime.Now.AddDays(-7))
                    {
                        fileInfo.Delete();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
