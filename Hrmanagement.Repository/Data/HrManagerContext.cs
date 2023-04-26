using System;
using System.Collections.Generic;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hrmanagement.Repository.Data;

public partial class HrManagerContext : DbContext
{
    public HrManagerContext()
    {
    }

    public HrManagerContext(DbContextOptions<HrManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<LeaveType> LeaveTypes { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=10.100.172.11;Database=HrManager;User ID=hr;Password=psspl@123#;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("attendanceId");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.InTime)
                .HasColumnType("datetime")
                .HasColumnName("inTime");
            entity.Property(e => e.OutTime)
                .HasColumnType("datetime")
                .HasColumnName("outTime");
            entity.Property(e => e.Status)
                .HasMaxLength(40)
                .HasColumnName("status");

            entity.HasOne(d => d.Emp).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_attendance_Employee");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("company");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.CLocation)
                .HasMaxLength(30)
                .HasColumnName("cLocation");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.ToTable("department");

            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.DeptName)
                .HasMaxLength(40)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.DesgId);

            entity.ToTable("designation");

            entity.Property(e => e.DesgId).HasColumnName("desgId");
            entity.Property(e => e.DesName)
                .HasMaxLength(50)
                .HasColumnName("desName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK_Employee");

            entity.ToTable("employee");

            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.DesgId).HasColumnName("desgId");
            entity.Property(e => e.EmailId)
                .HasMaxLength(30)
                .HasColumnName("emailId");
            entity.Property(e => e.EmpTypeId).HasColumnName("empTypeId");
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnName("lastName");
            entity.Property(e => e.MobileNo)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("mobileNo");

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Employee_company");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Employee_department");

            entity.HasOne(d => d.Desg).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DesgId)
                .HasConstraintName("FK_Employee_designation");

            entity.HasOne(d => d.EmpType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmpTypeId)
                .HasConstraintName("FK_Employee_employeeType");

            entity.HasOne(d => d.EmployeeRole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeRoleId)
                .HasConstraintName("FK_Employee_EmployeeRole");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.EmployeeRoleId).HasName("PK_EmployeeRole");

            entity.ToTable("employeeRole");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.EmployeeRoleName).HasMaxLength(30);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeSalary>(entity =>
        {
            entity.HasKey(e => e.SalaryId);

            entity.ToTable("employeeSalary");

            entity.Property(e => e.SalaryId).HasColumnName("salaryId");
            entity.Property(e => e.BasicsSalary)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("basicsSalary");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.FromDate)
                .HasColumnType("date")
                .HasColumnName("fromDate");
            entity.Property(e => e.GrossSalary)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("grossSalary");
            entity.Property(e => e.HouseRent)
                .HasColumnType("numeric(6, 0)")
                .HasColumnName("houseRent");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Medical)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("medical");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("taxAmount");
            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("toDate");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeSalaries)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_employeeSalary_Employee");
        });

        modelBuilder.Entity<EmployeeType>(entity =>
        {
            entity.HasKey(e => e.EmpTypeId);

            entity.ToTable("employeeType");

            entity.Property(e => e.EmpTypeId).HasColumnName("empTypeId");
            entity.Property(e => e.EmployeeTypes)
                .HasMaxLength(30)
                .HasColumnName("employeeTypes");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK_Leave");

            entity.ToTable("leave");

            entity.Property(e => e.LeaveId).HasColumnName("leaveId");
            entity.Property(e => e.Contact)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("contact");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Fromdate)
                .HasColumnType("date")
                .HasColumnName("fromdate");
            entity.Property(e => e.IsAccepted).HasColumnName("isAccepted");
            entity.Property(e => e.IsApply).HasColumnName("isApply");
            entity.Property(e => e.LeaveTypeId).HasColumnName("leaveTypeId");
            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.SId).HasColumnName("sId");
            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("toDate");

            entity.HasOne(d => d.Emp).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_Leave_Leave");

            entity.HasOne(d => d.LeaveType).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.LeaveTypeId)
                .HasConstraintName("FK_Leave_leaveType1");

            entity.HasOne(d => d.Manager).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Leave_manager");

            entity.HasOne(d => d.SIdNavigation).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.SId)
                .HasConstraintName("FK_Leave_Session");
        });

        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.ToTable("leaveType");

            entity.Property(e => e.LeaveTypeId).HasColumnName("leaveTypeId");
            entity.Property(e => e.LeaveTypes)
            .HasMaxLength(50)
                .HasColumnName("leaveTypes");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("login");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");

            entity.HasOne(d => d.Emp).WithMany(p => p.Logins)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_login_employee");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.ToTable("manager");

            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.EffectiveFromDate)
                .HasColumnType("date")
                .HasColumnName("effectiveFromDate");
            entity.Property(e => e.EffectiveToDate)
                .HasColumnType("date")
                .HasColumnName("effectiveToDate");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.EmpIdMgr).HasColumnName("empIdMgr");
            entity.Property(e => e.EmployeeRoleId).HasColumnName("employeeRoleId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.Dept).WithMany(p => p.Managers)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_manager_department");

            entity.HasOne(d => d.Emp).WithMany(p => p.ManagerEmps)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_manager_employee");

            entity.HasOne(d => d.EmpIdMgrNavigation).WithMany(p => p.ManagerEmpIdMgrNavigations)
                .HasForeignKey(d => d.EmpIdMgr)
                .HasConstraintName("FK_manager_employeeMgr");

            entity.HasOne(d => d.EmployeeRole).WithMany(p => p.Managers)
                .HasForeignKey(d => d.EmployeeRoleId)
                .HasConstraintName("FK_manager_EmployeeRole");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK_Session");

            entity.ToTable("session");

            entity.Property(e => e.SessionId).HasColumnName("sessionId");
            entity.Property(e => e.Sessions).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
