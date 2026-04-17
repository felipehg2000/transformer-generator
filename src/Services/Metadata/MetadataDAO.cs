using System;
using System.IO;
using System.Text.Json;
using transformer_generator.src.Model;

namespace transformer_generator.src.Services.MetadataDAO
{
    /// <summary>
    /// Clase encargada de la persistencia de los metadatos.
    /// </summary>
    internal class MetadataDAO
    {
        /// <summary>
        /// Lee el fichero de metadatos y crea un atributo de tipo Metadata
        /// </summary>
        /// <param name="param_file_path">Ruta del fichero a leer.</param>
        /// <returns>Metadatos almacenados en un fichero.</returns>
        /// <exception cref="FileNotFoundException">Excepción de fichero no encontrado.</exception>
        /// <exception cref="JsonException">Excepción de fichero de formato incorrecto.</exception>
        static public Metadata ReadFile(string param_file_path)
        {
            // Comprobar que el archivo existe
            if (!File.Exists(param_file_path))
            {
                throw new FileNotFoundException("El archivo de configuración no existe.", param_file_path);
            }

            // Leer el contenido del archivo
            string jsonString = File.ReadAllText(param_file_path);

            Metadata ret_metadata = JsonSerializer.Deserialize<Metadata>(jsonString);
            if (ret_metadata == null)
            {
                throw new JsonException("Error al deserializar el archivo de configuración.");
            }

            // Devolver la configuración cargada
            return ret_metadata;
        }

        /// <summary>
        /// Guarda los datos del atributo Metadata en un fichero que se genera en el proceso.
        /// </summary>
        /// <param name="param_directory_path">Ruta del directorio en el que almacenar el fichero de metadatos.</param>
        /// <param name="param_metadata">Atributo a con los datos a almacenar en el fichero de destino.</param>
        /// <param name="param_file_name">Nombre del fichero, por defecto a vacío para que el método lo genere.</param>
        static public void SaveFile(string param_directory_path, Metadata param_metadata, string param_file_name = null)
        {
            string file_name = string.Empty;
            if (string.IsNullOrEmpty(param_file_name))
            {
                file_name = DateTime.Now.ToString("yyyyMMddHHmmss") + ".json";
            }
            else
            {
                if (Path.GetExtension(param_file_name) != ".json")
                {
                    file_name = param_file_name + ".json";
                }
                else
                {
                    file_name = param_file_name;
                }
            }

            // Agregar nombre de fichero
            param_directory_path = Path.Combine(param_directory_path, file_name);
            
            // Serializar el objeto a formato JSON
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json_string = JsonSerializer.Serialize(param_metadata, opciones);

            // Escribir el contenido en el archivo
            File.WriteAllText(param_directory_path, json_string);
        }
    }
}
