using Contracts;
using Entities.DataTransferObjects;
using lrs.ActionFilters;
using lrs.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Repository.DataShaping;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureCors();
        services.ConfigureIISIntegration();
        services.ConfigureLoggerService();
        services.ConfigureSqlContext(Configuration);
        services.ConfigureRepositoryManager();
        services.AddAutoMapper(typeof(Startup));
        services.AddControllers(config => { 
            config.RespectBrowserAcceptHeader = true;
            config.ReturnHttpNotAcceptable = true;
        }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters().AddCustomCSVFormatter();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        services.AddScoped<ValidationFilterAttribute>();
        services.AddScoped<ValidateCompanyExistsAttribute>();
        services.AddScoped<ValidateEmployeeForCompanyExistsAttribute>();
        services.AddScoped<ValidatePartWorldExistsAttribute>();
        services.AddScoped<ValidateCountryExistsAttribute>();
        services.AddScoped<ValidateCityExistsAttribute>();
        services.AddScoped<ValidateHotelExistsAttribute>();
        services.AddScoped<ValidateTicketExistsAttribute>();
        services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
        services.AddScoped<IDataShaper<CompanyDto>, DataShaper<CompanyDto>>();
        services.AddScoped<IDataShaper<PartWorldDto>, DataShaper<PartWorldDto>>();
        services.AddScoped<IDataShaper<CountryDto>, DataShaper<CountryDto>>();
        services.AddScoped<IDataShaper<CityDto>, DataShaper<CityDto>>();
        services.AddScoped<IDataShaper<HotelDto>, DataShaper<HotelDto>>();
        services.AddScoped<IDataShaper<TicketDto>, DataShaper<TicketDto>>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ConfigureExceptionHandler(logger);
        app.UseHttpsRedirection();
        app.UseHsts();
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
