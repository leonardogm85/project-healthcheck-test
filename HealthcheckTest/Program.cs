var builder = WebApplication.CreateBuilder(args);

var type = builder.Configuration.GetValue<ContainerType>("Container:Type");
var interval = builder.Configuration.GetValue<double>("Container:Interval");

var date = DateTime.Now;

var app = builder.Build();

app.MapGet("/", () =>
{
    switch (type)
    {
        case ContainerType.ItWillAlwaysBeHealthy:
            return HealthyStatus.Healthy;
        case ContainerType.ItWillAlwaysBeUnhealthy:
            return HealthyStatus.Unhealthy;
        case ContainerType.ItWillGetUnhealthyInAFewMinutes:
            return (DateTime.Now - date).TotalMinutes > interval
                ? HealthyStatus.Unhealthy
                : HealthyStatus.Healthy;
        case ContainerType.ItWillThrowExceptionInAFewMinutes:
            if ((DateTime.Now - date).TotalMinutes > interval)
            {
                Environment.Exit(0);
                return HealthyStatus.Unhealthy;
            }
            return HealthyStatus.Healthy;
        default:
            return HealthyStatus.Healthy;
    }
});

app.Run();

enum ContainerType
{
    ItWillAlwaysBeHealthy = 1,
    ItWillAlwaysBeUnhealthy = 2,
    ItWillGetUnhealthyInAFewMinutes = 3,
    ItWillThrowExceptionInAFewMinutes = 4
}

enum HealthyStatus
{
    Healthy = 0,
    Unhealthy = 1
}
