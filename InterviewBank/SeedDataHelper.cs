using InterviewBank.Database;
using Microsoft.EntityFrameworkCore;

namespace InterviewBank;

public static class SeedDataHelper {
    public static WebApplication SeedData(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<BankDbContext>();
            context.Database.Migrate();
        }
        return app;
    }
}