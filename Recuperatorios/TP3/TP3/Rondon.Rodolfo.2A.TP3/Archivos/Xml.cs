using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(archivo);
                xml.Serialize(sw, datos);
                sw.Close();
                retorno = true;        
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        public bool Leer(string archivo,out T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                StreamReader str = new StreamReader(archivo);        
                datos = (T)xml.Deserialize(str);
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
