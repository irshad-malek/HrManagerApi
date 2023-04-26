using Hrmanagement.Repository.Interface;
using Hrmanagement.Repository.Repository;
using Hrmanagement.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("JWT:ValidIssuer").Value,
        ValidAudience = builder.Configuration.GetSection("JWT:ValidAudience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Secret").Value))
    };
});
// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
      .AllowAnyHeader());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployee,EmployeeRepository>();
builder.Services.AddScoped<Idepartment,DepartmentRepository>();
builder.Services.AddScoped<ILeaveApply,LeaveApplyRepository>();
builder.Services.AddScoped<ISalary, SalaryRepository>();
builder.Services.AddScoped<IEmployeeType, EmployeeTypeRepository>();
builder.Services.AddScoped<IEmployeeRole, EmployeeRolesRepository>();
builder.Services.AddScoped<IDesignation, DesignationRepository>();
//builder.Services.AddScoped<IAccounts, AccountRepository>();
builder.Services.AddScoped<IManager, ManagerRepository>();
string connString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<HrManagerContext>(options =>

           options.UseSqlServer(connString)
           );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
