using System;
using System.Collections.Generic;
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

    public virtual DbSet<AprovedLeave> AprovedLeaves { get; set; }

    public virtual DbSet<Assignee> Assignees { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

    public virtual DbSet<JuniourAssign> JuniourAssigns { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<LeaveType> LeaveTypes { get; set; }

    public virtual DbSet<SeniourAssign> SeniourAssigns { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=HrManager;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AprovedLeave>(entity =>
        {
            entity.HasKey(e => e.AId);

            entity.ToTable("aprovedLeave");

            entity.Property(e => e.AId).HasColumnName("aId");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");

            entity.HasOne(d => d.Emp).WithMany(p => p.AprovedLeaves)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_aprovedLeave_Employee");
        });

        modelBuilder.Entity<Assignee>(entity =>
        {
            entity.HasKey(e => e.AssId);

            entity.ToTable("assignee");

            entity.Property(e => e.AssId).HasColumnName("assId");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.JId).HasColumnName("jId");
            entity.Property(e => e.SId).HasColumnName("sId");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updatedOn");

            entity.HasOne(d => d.JIdNavigation).WithMany(p => p.Assignees)
                .HasForeignKey(d => d.JId)
                .HasConstraintName("FK_assignee_juniourAssign");

            entity.HasOne(d => d.SIdNavigation).WithMany(p => p.Assignees)
                .HasForeignKey(d => d.SId)
                .HasConstraintName("FK_assignee_seniourAssign");
        });

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
            entity.HasKey(e => e.CId);

            entity.ToTable("company");

            entity.Property(e => e.CId).HasColumnName("cId");
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
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.CId).HasColumnName("cId");
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
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnName("lastName");
            entity.Property(e => e.MobileNo)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("mobileNo");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CId)
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
            entity.ToTable("EmployeeRole");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.EmployeeRoleName).HasMaxLength(30);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeSalary>(entity =>
        {
            entity.HasKey(e => e.SId);

            entity.ToTable("employeeSalary");

            entity.Property(e => e.SId).HasColumnName("sId");
            entity.Property(e => e.BasicsSalary)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("basicsSalary");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.GrossSalary)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("grossSalary");
            entity.Property(e => e.HouseRent)
                .HasColumnType("numeric(6, 0)")
                .HasColumnName("houseRent");
            entity.Property(e => e.Medical)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("medical");
            entity.Property(e => e.Taxes)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("taxes");

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

        modelBuilder.Entity<JuniourAssign>(entity =>
        {
            entity.HasKey(e => e.JId);

            entity.ToTable("juniourAssign");

            entity.Property(e => e.JId).HasColumnName("jId");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updatedOn");

            entity.HasOne(d => d.Emp).WithMany(p => p.JuniourAssigns)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_juniourAssign_Employee");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.ToTable("Leave");

            entity.Property(e => e.LeaveId).HasColumnName("leaveId");
            entity.Property(e => e.AId).HasColumnName("aId");
            entity.Property(e => e.Contact)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("contact");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Fromdate)
                .HasColumnType("date")
                .HasColumnName("fromdate");
            entity.Property(e => e.IsAccepted).HasColumnName("isAccepted");
            entity.Property(e => e.IsApply).HasColumnName("isApply");
            entity.Property(e => e.LtId).HasColumnName("ltId");
            entity.Property(e => e.Session)
                .HasMaxLength(20)
                .HasColumnName("session");
            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("toDate");

            entity.HasOne(d => d.AIdNavigation).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.AId)
                .HasConstraintName("FK_Leave_aprovedLeave");

            entity.HasOne(d => d.Emp).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_Leave_Leave");

            entity.HasOne(d => d.Lt).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.LtId)
                .HasConstraintName("FK_Leave_leaveType");
        });

        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.HasKey(e => e.LtId);

            entity.ToTable("leaveType");

            entity.Property(e => e.LtId).HasColumnName("ltId");
            entity.Property(e => e.LeaveType1)
                .HasMaxLength(50)
                .HasColumnName("leaveType");
        });

        modelBuilder.Entity<SeniourAssign>(entity =>
        {
            entity.HasKey(e => e.SId);

            entity.ToTable("seniourAssign");

            entity.Property(e => e.SId).HasColumnName("sId");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(50)
                .HasColumnName("updateBy");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updatedOn");

            entity.HasOne(d => d.Emp).WithMany(p => p.SeniourAssigns)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_seniourAssign_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
