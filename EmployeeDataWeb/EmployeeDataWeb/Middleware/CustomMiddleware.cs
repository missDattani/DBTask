using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Model.ViewModels.SMTPSettings;
using EmployeeDataWeb.Model.ViewModels.Token;
using EmployeeDataWeb.Services.JwtAuthenticationServices;
using EmployeeDataWeb.Services.User;
using MailKit.Security;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;
using System.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EmployeeDataWeb.Middleware
{
    public class CustomMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly IJwtAuthServices jwtAuthServices;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private readonly SMTPSettings _smtpSettings;
        #endregion

        #region Constructor
        public CustomMiddleware(RequestDelegate next, IJwtAuthServices jwtAuthServices, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment,IOptions<SMTPSettings> smtpSettings)
        {
            _next = next;
            this.jwtAuthServices = jwtAuthServices;
            _environment = environment;
            _smtpSettings = smtpSettings.Value;
        }
        #endregion

        #region Methods
        public async Task Invoke(HttpContext context,IUserServices userServices)
        {
            try
            {
                var httpContextBody = context.Request.Body;
                string requestBody = string.Empty;

                context.Request.EnableBuffering();

                using (var reader = new StreamReader(
                    context.Request.Body,
                    encoding: Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: false,
                    bufferSize: -1,
                    leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();
                    context.Request.Headers.Add("reqModel", body);
                    context.Request.Body.Position = 0;
                }

                DeleteOldReqResLogFile();

                string? jwtToken = context.Session.GetString("userToken");
                if (!string.IsNullOrWhiteSpace(jwtToken))
                {
                    UserTokenData userToken = jwtAuthServices.GetUserTokenData(jwtToken);

                    var result = await userServices.ValidateToken(userToken.Id, jwtToken, userToken.TokenValidTo);
                    if (result == 1)
                    {
                        if (userToken != null)
                        {
                            if (userToken.TokenValidTo < DateTime.UtcNow.AddMinutes(1))
                            {
                                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                return;
                            }
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return;
                    }
                }

                AddReqResLogToFile(context);
                await _next(context);
            }
            catch (Exception ex)
            {
                bool success = await SendExceptionEmail(ex, context);
                AddExceptionLogsToFile(ex, context, success);
            }
        }

        public void DeleteOldReqResLogFile()
        {
            try
            {
                var directoryPath = Path.Combine(_environment.WebRootPath, "ReqResLogs");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string[] AllFiles = Directory.GetFiles(directoryPath);
                foreach (string file in AllFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
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

        public void AddExceptionLogsToFile(Exception ex,HttpContext context,bool success)
        {
            try
            {
                var exFilePath = Path.Combine(_environment.WebRootPath, "ExceptionLogs", "Exception_" + Path.GetFileName(DateTime.Now.ToString("dd_MM_yyyy") + ".txt"));
                if (!File.Exists(exFilePath))
                {
                    var myFile = File.Create(exFilePath);
                    myFile.Close();
                }

                using StreamWriter sw = File.AppendText(exFilePath);
                sw.WriteLine("");
                sw.WriteLine("----------" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "------------");
                sw.WriteLine("Request Url:" + context.Request.Path.Value);
                sw.WriteLine("Error Message : " + ex.Message);
                sw.WriteLine("InnerException :" + ex.InnerException);
                sw.WriteLine("StackStrace:" + ex.StackTrace);
                if(ex.InnerException != null)
                {
                    sw.WriteLine("Exception : " + ex.InnerException.InnerException);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SendExceptionEmail(Exception ex,HttpContext context)
        {
            try
            {
                string? AdminEmail = context.Session.GetString("userName");
                if (AdminEmail == null)
                {
                    AdminEmail = "dattanipooja1923@gmail.com";
                }
                var emailMessage = new MimeMessage();
                emailMessage.Sender = MailboxAddress.Parse(_smtpSettings.FromEmail);
                emailMessage.To.Add(MailboxAddress.Parse(AdminEmail));
                emailMessage.Subject = "Exception Email";

                var builder = new BodyBuilder();
                var RequestedUrl = context.Request.Path.Value;
                var Exception = ex.Message;
                var Innerexception = ex.InnerException;

                string filePath = Directory.GetCurrentDirectory() + "\\Templates\\ExceptionTemplate.html";
                string emailTemplateText = EmailTemplateHelper.GetEmailTemplateText(filePath);

                emailTemplateText = string.Format(emailTemplateText, RequestedUrl, Exception, Innerexception);

                builder.HtmlBody = emailTemplateText;
                builder.TextBody = "Plain Text goes here to avoid marked as spam for some email servers.";

                emailMessage.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_smtpSettings.EmailHostName, Convert.ToInt32(_smtpSettings.EmailPort), SecureSocketOptions.StartTls);
                smtp.Authenticate(_smtpSettings.FromEmail, _smtpSettings.EmailAppPassword);
                var success = await smtp.SendAsync(emailMessage);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddReqResLogToFile(HttpContext context)
        {
            try
            {
                var exFilePath = Path.Combine(_environment.WebRootPath, "ReqResLogs", "Log_" + Path.GetFileName(DateTime.Now.ToString("dd-MM-yyyy") + ".txt"));

                if (!File.Exists(exFilePath))
                {
                    var myFile = File.Create(exFilePath);
                    myFile.Close();
                }

                using StreamWriter sw = File.AppendText(exFilePath);
                sw.WriteLine("");
                sw.WriteLine("----------" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "------------");
                sw.WriteLine("Requested Url :" + context.Request.Path.Value);
                sw.WriteLine("Response");
                // _next(context);
                sw.WriteLine(context.Response.StatusCode);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
