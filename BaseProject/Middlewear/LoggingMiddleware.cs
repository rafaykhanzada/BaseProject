using Core.Data.DataContext;
using Core.Data.Entities;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;

namespace BaseProject.Middlewear
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        ApplicationDbContext db = new ApplicationDbContext();

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext/*, ILogService logger*/)
        {
            //Static File
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(new JsonFormatter(renderMessage: true), "Meta/logs/log.json")
                .CreateLogger();

            try
            {
                Log.Information(httpContext.Request.Path);
                string userId = "";
                string tok = "";
                var route = httpContext.Request.Path != "/" ? httpContext.Request.Path.Value.ToLower().Split("/")[2] : "";
                //var path = httpContext.Request.Path != "/" && httpContext.Request.Path.Value.ToLower().Split("/").Length > 3 ? httpContext.Request.Path.Value.ToLower().Split("/")[3] : "";
                var token = httpContext.Request.Headers.Where(x => x.Key == "Authorization").Select(x => x.Value).FirstOrDefault();
                var CurrentUser = new Users();
                if (token.Count() > 0)
                {
                    tok = token.First().ToString().Split(" ")[1];
                    userId = httpContext?.User?.Claims?.FirstOrDefault()?.Value;
                }
                var log = new ActivityLog()
                {
                    RequestedOn = DateTime.Now,
                    Action = httpContext.Request.Method,
                    Module = route,
                    Path = httpContext.Request.Scheme + "://" + httpContext.Request.Host.Value + httpContext.Request.Path,
                    UserId = userId,
                    CreatedBy = userId,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    Token = tok
                };
                db.ActivityLog.Add(log);
                db.SaveChanges();
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
                await _next(httpContext);
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            //End

        }
    }
}
