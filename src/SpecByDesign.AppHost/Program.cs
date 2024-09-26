var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HAN_Weatherforecast_Service>("han-weatherforecast-service");

builder.AddProject<Projects.HAN_Weatherforecast_Website>("han-weatherforecast-website");

builder.Build().Run();
