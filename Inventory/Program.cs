using DAL.Data;
using DAL.Respository.Interface;
using DAL.Respository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


//void ConfigureServices(IServiceCollection services)
//{
//    services.AddApplicationInsightsTelemetry(options =>
//    {
//        options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
//    });

    
//}




builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPurchaseOrder, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderDetailRepository, PurchaseOrderDetailRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage(); // Enables detailed error pages in development
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error"); // Redirect to error page in production
//    app.UseHsts(); // Use HTTP Strict Transport Security in production
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
