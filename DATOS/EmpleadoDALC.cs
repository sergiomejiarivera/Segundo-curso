using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class EmpleadoDALC
    {
        public void Agregar(Empleado empleado)
        {
            using (var db = new ProyectosContext())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
            }
        }
        public List<Empleado> ListarEmpleados()
        {
            using (var db = new ProyectosContext())
            {
                return db.Empleado.ToList();
            }
        }

        public Empleado ObtenerEmpleado(int id)
        {
            using (var db = new ProyectosContext())
            {
                return db.Empleado.Find(id);
            }
        }

        public void Editar(Empleado empleado)
        {
            //using (var db = new ProyectosContext())
            //{
            //    var origen = db.Empleado.Find(empleado.ProyectoId);
            //    origen.NombreProyecto = empleado.NombreProyecto;
            //    origen.FechaInicio = empleado.FechaInicio;
            //    origen.FechaFin = empleado.FechaFin;
            //    db.SaveChanges();

            //}
        }

        public void Eliminar(int id)
        {
            using (var db = new ProyectosContext())
            {
                var empleado = db.Empleado.Find(id);
                db.Empleado.Remove(empleado);
                db.SaveChanges();
            }
        }

    }
}

