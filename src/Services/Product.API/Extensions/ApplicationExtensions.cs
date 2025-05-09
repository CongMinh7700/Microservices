namespace Product.API.Extensions;

public static class ApplicationExtensions
{
    public static void UserInfrastructure(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        //app.UseHttpsRedirection(); for production
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }

}

