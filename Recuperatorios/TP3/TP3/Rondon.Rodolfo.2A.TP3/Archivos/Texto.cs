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
                StreamWriter str = new StreamWriter(archivo);
                str.WriteLine(datos,false);
                str.Close();
                retorno = true;
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

            try
            {
                StreamReader str = new StreamReader(archivo);
                datos = str.ReadToEnd();
                str.Close();    
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
