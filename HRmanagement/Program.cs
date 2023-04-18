using Hrmanagement.Repository.Interface;
using Hrmanagement.Repository.Repository;
using Hrmanagement.Repository.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
