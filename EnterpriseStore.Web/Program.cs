using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseStore.Web
{
    // This file previously contained top-level statements which caused CS8802
    // because the project also has a top-level Program.cs. Convert the startup
    // flow into helper methods to preserve the original configuration without
    // executing duplicate top-level statements.

    public static class EnterpriseStoreWebHost
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Preserve original service registrations here if you ever want to reuse them.
            // Do not call this from the main Program.cs unless you intend to merge configurations.
            builder.Services.AddControllersWithViews();
        }

        public static void Configure(WebApplication app)
        {
            // Preserve original middleware pipeline here.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
