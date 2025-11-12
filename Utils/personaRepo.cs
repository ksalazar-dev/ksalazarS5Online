using ksalazarS5Online.Models;
using Microsoft.Win32.SafeHandles;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksalazarS5Online.Utils
{
    public class personaRepo
    {
        string dbRuta;
        private SQLiteConnection conn;
        public string mensaje { get; set; }

        public void init()
        {
            if (conn is not null)
                return;
            conn = new(dbRuta);
            conn.CreateTable<persona>();
        }
        public personaRepo(string ruta)
        {
            dbRuta = ruta;
        }

        //CRUD

        public void AddNewPerson(string _nombre)
        {
            int result = 0;
            try
            {
                //Insertar la persona

                init();
                if (string.IsNullOrEmpty(_nombre))
                    throw new Exception("EL NOMBRE ES REQUERIDO");
                persona persona = new() { Nombre = _nombre };
                result = conn.Insert(persona);
                mensaje = string.Format("DATO INGRESADO CORRECTAMENTE", +result+" "+_nombre);
            }
            catch (Exception ex)
            {
                mensaje = string.Format("ERROR :" +ex.Message);
            }
        }

        //MOSTRAR / LISTAR

        public List<persona> GetAllPeople()
        {
            try
            {
                init();
                return conn.Table<persona>().ToList();
                mensaje = string.Format("ELEMENTO LISTADOS CORRECTAMENTE"+" ");

            }
            catch (Exception ex)
            {

                mensaje = string.Format("ERROR :" +ex.Message);
            }
            return new List<persona>();
        }

        // DELETE
       
        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                init();
                var personaEliminar = conn.Table<persona>().FirstOrDefault(p => p.Id == id);
                if (personaEliminar == null)
                    throw new Exception("No se encontró la persona con el ID especificado.");

                result = conn.Delete(personaEliminar);
                mensaje = $"Registro eliminado correctamente. ID: {id}";
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR: {ex.Message}";
            }
        }


         // UPDATE
        public void UpdatePerson(persona personaActualizada)
        {
            int result = 0;
            try
            {
                init();
                if (personaActualizada == null)
                    throw new Exception("El objeto persona no puede ser nulo.");

                var personaExistente = conn.Table<persona>().FirstOrDefault(p => p.Id == personaActualizada.Id);
                if (personaExistente == null)
                    throw new Exception("No se encontró la persona con el ID especificado.");

                // Actualizar los campos necesarios
                personaExistente.Nombre = personaActualizada.Nombre;

                result = conn.Update(personaExistente);
                mensaje = $"Registro actualizado correctamente. ID: {personaActualizada.Id}";
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR: {ex.Message}";
            }
        }

    }
}