namespace BaseProject.Middlewear
{
    public static class GlobalCutomMiddleware
    {
        public static void UseGloablCustomMiddleware(this IApplicationBuilder app)
        {
            //app.UseMiddleware<LoggingMiddleware>();
            //app.UseMiddleware<SecurityMiddleware>();
        }
    }
}
