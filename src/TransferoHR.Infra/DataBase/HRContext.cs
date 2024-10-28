using TransferoHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TransferoHR.Domain.Enums;

namespace TransferoHR.Infra.Database;

public class HRContext : DbContext
{
    public HRContext(DbContextOptions<HRContext> options)
        : base(options)
    {
    }

    public DbSet<Collaborator> Collaborator { get; set; } = null!;   // Setando as entidades que passaram o modelo do db
    public DbSet<Company> Company { get; set; } = null!;
    public DbSet<Department> Department { get; set; } = null!;
    public DbSet<JobLevel> JobLevel { get; set; } = null!;
    public DbSet<JobTitle> JobTitle { get; set; } = null!;
    public DbSet<WorkExperience> WorkExperience { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data para a tabela JobLevel
        modelBuilder.Entity<JobLevel>().HasData(
            new JobLevel
            {
                Id = Guid.NewGuid(), // Use um GUID gerado para o Id
                Name = "Junior",     // Exemplo de nível de trabalho
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            },
            new JobLevel
            {
                Id = Guid.NewGuid(),
                Name = "Senior",     // Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            },
            new JobLevel
            {
                Id = Guid.NewGuid(),
                Name = "Pleno",     // Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            },
            new JobLevel
            {
                Id = Guid.NewGuid(),
                Name = "Gerente",     // Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            }
        );

        modelBuilder.Entity<JobTitle>().HasData(
            new JobTitle
            {
                Id = Guid.NewGuid(),
                Name = "DBA",     // Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            },
           new JobTitle
           {
               Id = Guid.NewGuid(),
               Name = "Analista de suporte",     // Outro exemplo
               CreatedBy = "system",
               CreatedAt = DateTime.Now,
               Status = EntityStatusEnum.Active
           },
           new JobTitle
           {
               Id = Guid.NewGuid(),
               Name = "Desenvolvedor",     // Outro exemplo
               CreatedBy = "system",
               CreatedAt = DateTime.Now,
               Status = EntityStatusEnum.Active
           },
           new JobTitle
           {
               Id = Guid.NewGuid(),
               Name = "Analista de Asset",     // Outro exemplo
               CreatedBy = "system",
               CreatedAt = DateTime.Now,
               Status = EntityStatusEnum.Active
           }
        );

        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "TRANSF. GESTÃO DE ATIVOS DIGITAIS - EIRELI",
                CNPJ = "30.934.964/0001-78",// Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "TRANSFERO SWISS LTD",
                CNPJ = "28.360.810/0001-78",// Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            },

            new Company
            {
                Id = Guid.NewGuid(),
                Name = "TRANSFERO GESTORA DE RECURSOS LTDA",
                CNPJ = "42.155.153/0001-58",// Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "TRANSFERO PAGAMENTOS HOLDING",
                CNPJ = "45.685.859/0001-10",// Outro exemplo
                CreatedBy = "system",
                CreatedAt = DateTime.Now,
                Status = EntityStatusEnum.Active
            }

        );

        modelBuilder.Entity<Department>().HasData(
        new Department
        {
            Id = Guid.NewGuid(),
            Name = "Infraestrutura",
            CreatedBy = "system",
            CreatedAt = DateTime.Now,
            Status = EntityStatusEnum.Active
        },
        new Department
        {
            Id = Guid.NewGuid(),
            Name = "Asset",
            CreatedBy = "system",
            CreatedAt = DateTime.Now,
            Status = EntityStatusEnum.Active
        }
        );
    }
}