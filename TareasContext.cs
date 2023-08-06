using Microsoft.EntityFrameworkCore;
using projectef.Models;
namespace projectef
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<Tarea> Tareas {get;set;}
        public TareasContext(DbContextOptions<TareasContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria(){ CategoriaId = Guid.Parse("60ecf22d-fcf7-4d2f-8dd7-ea12ded125d7"), Nombre = "Actividades pendientes",  Peso= 20});
            categoriasInit.Add(new Categoria(){ CategoriaId = Guid.Parse("60ecf22d-fcf7-4d2f-8dd7-ea12ded12502"), Nombre = "Actividades personales",  Peso= 50});
            
            modelBuilder.Entity<Categoria>(categoria=>
            {
                categoria.ToTable("Categoria");
                
                categoria.HasKey(p=> p.CategoriaId);
                categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p=> p.Descripcion).IsRequired(false);
                categoria.Property(p=>p.Peso);

                //enviar los datos iniciales
                categoria.HasData(categoriasInit);
            });
            modelBuilder.Entity<Tarea>(tarea=>
            {
                List<Tarea> TareasInit = new List<Tarea>();
                TareasInit.Add(new Tarea() {TareaId=Guid.Parse("60ecf22d-fcf7-4d2f-8dd7-ea12ded12510"), categoriaId=Guid.Parse("60ecf22d-fcf7-4d2f-8dd7-ea12ded125d7"), PrioridadTarea = Prioridad.media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.UtcNow});
                TareasInit.Add(new Tarea() {TareaId=Guid.Parse("60ecf22d-fcf7-4d2f-8dd7-ea12ded12511"), categoriaId=Guid.Parse("60ecf22d-fcf7-4d2f-8dd7-ea12ded12502"), PrioridadTarea = Prioridad.baja, Titulo = "Terminar de ver pelicula en Netflix", FechaCreacion = DateTime.UtcNow});
                tarea.ToTable("Tarea");
                tarea.HasKey(p=> p.TareaId);
                tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.categoriaId);
                tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p=> p.Descripcion).IsRequired(false);
                tarea.Property(p=> p.PrioridadTarea);
                tarea.Property(p=> p.FechaCreacion).HasDefaultValue(DateTime.Now);
                tarea.Ignore(p=> p.Resumen);
                tarea.HasData(TareasInit);

                /*tarea.ToTable("Tarea");
                tarea.HasKey(p=> p.TareaId);

                tarea.HasOne(p=> p.Categoria)
                    .WithMany(p=>p.Tareras)
                    .HasForeignKey(p=>p.categoriaId);

                tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p=> p.Descripcion).IsRequired(false);
                tarea.Property(p=> p.PrioridadTarea);
                tarea.Property(p=> p.FechaCreacion);

                tarea.Ignore(p=>p.Resumen);

                tarea.HasData(TareasInit);*/
            });
        }
    }
}