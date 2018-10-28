namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class SysacadContext : DbContext
    {
        public SysacadContext()
            : base("name=SysacadContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public  DbSet<alumnos_inscripciones> alumnos_inscripciones { get; set; }
        public  DbSet<comisiones> comisiones { get; set; }
        public  DbSet<cursos> cursos { get; set; }
        public  DbSet<docentes_cursos> docentes_cursos { get; set; }
        public  DbSet<especialidades> especialidades { get; set; }
        public  DbSet<materias> materias { get; set; }
        public  DbSet<modulos> modulos { get; set; }
        public  DbSet<modulos_usuarios> modulos_usuarios { get; set; }
        public  DbSet<personas> personas { get; set; }
        public  DbSet<planes> planes { get; set; }
        public  DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);          
        }
        public static SysacadContext Create()
        {
            return new SysacadContext();
        }
    }
}
