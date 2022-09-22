using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using SocialNetworkAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(options => options.UseNpgsql(
					builder.Configuration.GetConnectionString("DefaultConnection")
				)
			);
builder.Services.AddCors(c =>
{
	c.AddPolicy("AllowOrigin", options =>
		options
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader()
		);
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
	options =>
		options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
	).AddNewtonsoftJson(
	options => 
		options.SerializerSettings.ContractResolver = new DefaultContractResolver()
	);

var app = builder.Build();

app.UseCors(options => 
	options.
	AllowAnyOrigin().
	AllowAnyMethod().
	AllowAnyHeader()
);

if (app.Environment.IsDevelopment())
{
	//app.UseSwagger();
	//app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();


//app.MapControllers();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}"
	);
});

app.Run();
