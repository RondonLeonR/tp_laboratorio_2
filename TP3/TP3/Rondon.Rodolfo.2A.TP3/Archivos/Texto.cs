using System;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter str = new StreamWriter(archivo, false))
                {
                    str.WriteLine(datos);
                    str.Close();
                    retorno = true;
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = "";
            try
            {
                using (StreamReader str = new StreamReader(archivo))
                {
                    datos = str.ReadToEnd();
                    
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
