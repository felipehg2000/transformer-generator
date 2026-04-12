namespace transformer_generator.Templates
{
    /// <summary>
    /// Almacena todas las porciones de código que necesita el generador para crear un proyecto de C# que ejecute las instrucciones leídas del lenguaje M.
    /// </summary>
    internal class CSharp
    {
        /// <summary>
        /// Objeto de tipo columna para la lectura de los metadatos.
        /// </summary>
        static readonly public string Column =
@"using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Define la estructura de una columna, con su nombre y tipo de dato.
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Enumeración con los posibles tipos de datos que gestiona el generador de código.
        /// </summary>
        public enum DataType
        {
            None = 0,            ///<summary>Valor por defecto, sin tipo definido</summary>
            Text = 1,           ///<summary>Tipo de dato texto</summary>
            Number = 2,         ///<summary>Tipo de dato numérico</summary>
            Double = 3,         ///<summary>Tipo de dato numérico con decimales</summary>
            Date = 4,           ///<summary>Tipo de dato fecha</summary>
            Boolean = 5,        ///<summary>Tipo de dato booleano</summary>
        }

        ///<summary>
        ///Nombre de la columna en lenguaje M
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///Tipo de dato en lenguaje M (Text, Number, Date...)
        ///</summary>
        public DataType Type { get; set; } 
        
        /// <summary>
        /// Valores que tiene la columna.
        /// </summary>
        public List<string> Values { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Column()
        {
            Name = string.Empty;
            Type = DataType.None;
            Values = new List<string>();
        }

        /// <summary>
        /// Constlructor, inicializa atributos.
        /// </summary>
        /// <param name=""param_name"">Nombre de la columna.</param>
        /// <param name=""param_type"">Tipo de dato de la columna.</param>
        /// <param name=""param_values"">Valores que tiene la columna.</param>
        public Column(string param_name, 
            DataType param_type,
            List<string> param_values)
        {
            Name = param_name;
            Type = param_type;
            Values = param_values;
        }
    }
}
";

        /// <summary>
        /// Objeto de tipo DataSource para la lectura de los metadatos.
        /// </summary>
        static readonly public string DataSource =
@"using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Define la información necesaria para leer y entender una fuente de datos.
    /// </summary>
    public class DataSource
    {
        /// <summary>
        /// Enumeración con los distintos tipos de datos que puede leer el generador de código.
        /// </summary>
        public enum DataSourceType
        {
            None = 0,           ///<summary>Valor por defecto, sin tipo definido</summary>
            CSV = 1,            ///<summary>Archivo CSV, con delimitador definido</summary>
        }

        ///<summary>
        ///Indica si el archivo CSV tiene encabezado
        ///</summary>
        public bool HasHeader { get; set; }

        ///<summary>
        ///Tipo de dato en lenguaje M (CSV, JSON, DB...)
        ///</summary>
        public DataSourceType Type { get; set; }

        ///<summary>
        ///Nombre en lenguaje M
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///Ruta del origen de datos
        ///</summary>
        public string Path { get; set; }

        ///<summary>
        ///Delimitador para archivos CSV
        ///</summary>
        public string Delimiter { get; set; }

        ///<summary>
        ///Lista de columnas que se van a leer del origen de datos
        ///</summary>
        public List <Column> Columns { get; set; }  

        /// <summary>
        /// Constructor de la clase, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public DataSource()
        {
            HasHeader = false;
            Type = DataSourceType.None;
            Name = string.Empty;
            Path = string.Empty;
            Delimiter = string.Empty;
            Columns = new List<Column>();
        }

        /// <summary>
        /// Constructor de la clase, inicializa atributos.
        /// </summary>
        /// <param name=""type"">Tipo de fichero que se va a leer.</param>
        /// <param name=""name"">Nombre del fichero donde están los datos a leer.</param>
        /// <param name=""path"">Ruta del origen de los datos.</param>
        /// <param name=""hasHeader"">True si el fichero de origen tiene encabezados o no.</param>
        /// <param name=""delimiter"">Delimitador por el que se separan los datos en los textos planos.</param>
        public DataSource(DataSourceType param_type, 
            string param_name, 
            string param_path, 
            bool param_hasHeader, 
            string param_delimiter,
            List<Column> param_columns)
        {
            Type = param_type;
            Name = param_name;
            Path = param_path;
            HasHeader = param_hasHeader;
            Delimiter = param_delimiter;
            Columns = param_columns;
        }

    }
}
";

        /// <summary>
        /// Objeto de tipo MainConfiguration para la lectura de los metadatos.
        /// </summary>
        static readonly public string MainConfiguration =
@"using System.Text.Json.Serialization;

namespace transformer_generator.src.Utils.Generator
{
    /// <summary>
    /// Almacena los datos que puede configurar el usuario en la herramienta.
    /// </summary>
    public class MainConfiguration
    {
        /// <summary>
        /// Enumeración con los posibles tipos de salida para el código generado.
        /// </summary>
        public enum OutputType
        {
            None = 0,           ///<summary>Indica que no se generará ningún código.</summary>
            CSharp = 1,         ///<summary>Indica que se generará código en C#.</summary>
            Cpp = 2,            ///<summary>Indica que se generará código en C++.</summary>
        }

        /// <summary>
        /// Tipo de salida que se va a generar.
        /// </summary>
        public OutputType Type { get; set; }

        /// <summary>
        /// Ruta del directorio donde se almacenará el archivo de salida.
        /// </summary>
        public string OutputPathFile { get; set; }

        /// <summary>
        /// Ruta del directorio donde se almacenará el código generado.
        /// </summary>
        public string OutputPathCode { get; set; }

        /// <summary>
        /// Constructor, inicializa los atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public MainConfiguration()
        {
            Type = OutputType.None;
            OutputPathFile = string.Empty;
            OutputPathCode = string.Empty;
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name=""param_type"">Tipo de salida que se va a generar.</param>
        /// <param name=""param_output_path_file"">Ruta del archivo de salida.</param>
        /// <param name=""param_output_path_code"">Ruta del código de salida.</param>
        /// <param name=""param_input_m_lenguage_path"">Ruta del archivo de lenguaje de entrada.</param>
        public MainConfiguration(OutputType param_type,
            string param_output_path_file,
            string param_output_path_code,
            string param_input_m_lenguage_path)
        {
            Type = param_type;
            OutputPathFile = param_output_path_file;
            OutputPathCode = param_output_path_code;
        }
    }
}
";

        /// <summary>
        /// Objeto de tipo Metadata para la lectura de los metadatos.
        /// </summary>
        static readonly public string Metadata =
@"using System.Text.Json.Serialization;
using transformer_generator.src.Utils.Generator;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Clase que almacena la información sobre la configuración del generador y las fuentes de datos con las que el generador trabajará para crear los transformadores.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Información sobre la configuración del generador.
        /// </summary>
        public MainConfiguration Configuration { get; set; }

        /// <summary>
        /// Información sobre las fuentes de datos con las que el generador trabajará para crear los transformadores.
        /// </summary>
        public DataSource Source { get; set; }

        /// <summary>
        /// Datos sobre el fichero de lenguaje M de entrada y las ordenes que contiene.
        /// </summary>
        public QueryModel QueryModel { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Metadata()
        {
            Source = new DataSource();
            Configuration = new MainConfiguration();
            QueryModel = new QueryModel();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name=""configuration"">Configuración del generador.</param>
        /// <param name=""param_source"">Información de la fuente de datos.</param>
        /// <param name=""param_query_model"">Datos sobre el fichero de lenguaje M de entrada y las ordenes que contiene.</param>
        public Metadata(MainConfiguration configuration, 
            DataSource param_source,
            QueryModel param_query_model)
        {
            Configuration = configuration;
            Source = param_source;
            QueryModel = param_query_model;
        }
    }
}
";

        /// <summary>
        /// Objeto de tipo QueryModel para la lectura de los metadatos.
        /// </summary>
        static readonly public string QueryModel =
 @"using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Clase que almacena todos los pasos a seguir para generar una salida.
    /// </summary>
    public class QueryModel
    {
        /// <summary>
        /// Lista de pasos a seguir para generar la salida.
        /// </summary>
        public List<Step> Steps { get; set; }

        /// <summary>
        /// Ruta del fichero de lenguaje M de entrada que se procesó.
        /// </summary>
        public string InputFile { get; set; }

        /// <summary>
        /// Variable final del bloque 'in' del lenguaje M
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Constructor, inicializa los atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public QueryModel()
        {
            Steps = new List<Step>();
            InputFile = string.Empty;
            Output = string.Empty;
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name=""param_steps"">Lista de pasos.</param>
        /// <param name=""param_input_file"">Ruta del fichero de lenguaje M de entrada que se procesó.</param>
        /// <param name=""param_output"">Variable final del bloque 'in' del lenguaje M.</param>
        public QueryModel(List<Step> param_steps, 
            string param_input_file,
            string param_output)
        {
            Steps = param_steps;
            InputFile = param_input_file;
            Output = param_output;
        }
    }
}
";

        /// <summary>
        /// Objeto de tipo Step para la lectura de los metadatos.
        /// </summary>
        static readonly public string Step =
@"using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Clase que almacena la información sobre cada paso definido en el lenguaje M.
    /// </summary>
    public class Step
    {
        public enum OperationType
        {
            None = 0,           ///<summary>Ninguna operación asignada.</summary>
            SelectRows,         ///<symmary>Operación de selección de fila.</symmary>
            AddColumn,          ///<summary>Operación de adición de columna.</summary>
            RemoveColumns,      ///<summary>Operación de eliminación de columnas.</summary>
            SelectColumns       ///<summary>Operación de selección de columnas.</summary>
        }

        /// <summary>
        /// Nombre de la variable en el lenguaje M (ej: Filtered)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Paso del que se parte para realizar la operación (ej: Source).
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Operación a realizar.
        /// </summary>
        public OperationType Operation { get; set; }

        /// <summary>
        /// Lista de argumentos asociados a la operación.
        /// </summary>
        public Dictionary<string, string> Arguments { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Step()
        {
            Name = string.Empty;
            Input = string.Empty;
            Operation = OperationType.None;
            Arguments = new Dictionary<string, string>();
        }

        /// <summary>
        /// Constructor inicializa los atributos.
        /// </summary>
        /// <param name=""param_name"">Nombre de la variable en el lenguaje M (ej: Filtered).</param>
        /// <param name=""param_input"">Paso del que se parte para realizar la operación (ej: Source).</param>
        /// <param name=""param_operation"">Tipo de operación a realizar</param>
        /// <param name=""param_arguments"">Argumentos asociados a la operación.</param>
        public Step(string param_name, 
            string param_input,
            OperationType param_operation, 
            Dictionary<string, string> param_arguments)
        {
            Name = param_name;
            Input = param_input;
            Operation = param_operation;
            Arguments = param_arguments;
        }

        /// <summary>
        /// Traduce el tipo de operación a un texto descriptivo en español.
        /// </summary>
        /// <returns>Texto descriptivo en español que define el tipo de operación.</returns>
        public string GetOperationTypeText()
        {
            switch (Operation)
            {
                case OperationType.SelectRows:
                    return ""Seleccionar fila."";
                case OperationType.AddColumn:
                    return ""Añadir columna."";
                case OperationType.RemoveColumns:
                    return ""Eliminar columna."";
                case OperationType.SelectColumns:
                    return ""Seleccionar columna."";
                default:
                    return ""None"";
            }
        }
    }
}
";

        /// <summary>
        /// Servicio de acceso a datos para la lectura y escritura de los metadatos, con la implementación de los métodos necesarios para realizar estas operaciones.
        /// </summary>
        static readonly public string MetadataDAO =
@"using System.Text.Json;
using transformer_generator.src.Model;

namespace transformer_generator.src.Utils.MetadataDAO
{
    /// <summary>
    /// Clase encargada de la persistencia de los metadatos.
    /// </summary>
    internal class MetadataDAO
    {
        /// <summary>
        /// Lee el fichero de metadatos y crea un atributo de tipo Metadata
        /// </summary>
        /// <param name=""param_file_path"">Ruta del fichero a leer.</param>
        /// <returns>Metadatos almacenados en un fichero.</returns>
        /// <exception cref=""FileNotFoundException"">Excepción de fichero no encontrado.</exception>
        /// <exception cref=""JsonException"">Excepción de fichero de formato incorrecto.</exception>
        static public Metadata ReadFile(string param_file_path)
        {
            // Comprobar que el archivo existe
            if (!File.Exists(param_file_path))
            {
                throw new FileNotFoundException(""El archivo de configuración no existe."", param_file_path);
            }

            // Leer el contenido del archivo
            string jsonString = File.ReadAllText(param_file_path);

            Metadata ret_metadata = JsonSerializer.Deserialize<Metadata>(jsonString);
            if (ret_metadata == null)
            {
                throw new JsonException(""Error al deserializar el archivo de configuración."");
            }

            // Devolver la configuración cargada
            return ret_metadata;
        }

        /// <summary>
        /// Guarda los datos del atributo Metadata en un fichero que se genera en el proceso.
        /// </summary>
        /// <param name=""param_directory_path"">Ruta del directorio en el que almacenar el fichero de metadatos.</param>
        /// <param name=""param_metadata"">Atributo a con los datos a almacenar en el fichero de destino.</param>
        static public void SaveFile(string param_directory_path, Metadata param_metadata)
        {
            // Agregar nombre de fichero
            param_directory_path = Path.Combine(param_directory_path, DateTime.Now.ToString(""yyyyMMddHHmmss"") + "".json"");
            
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
";

        /// <summary>
        /// Servicio de gestión de tablas, con la implementación de los métodos que clonan el comportamiento de las instrucciones del lenguaje M.
        /// </summary>
        static readonly public string TableManagment =
@"using transformer_generator.src.Model;

namespace test_proyect_c_sharp.src.Services.TableManagment
{
    /// <summary>
    /// Clase encargada de gestionar las operaciones sobre tablas.
    /// </summary>
    internal class TableManagment
    {
        #region ""Public Methods""
        /// <summary>
        /// Agrega una nueva columna generada a partir de una función que recibe la fila completa.
        /// </summary>
        /// <param name=""param_table"">Tabla a la que se agregará la nueva columna.</param>
        /// <param name=""param_column_name"">Nombre de la nueva columna.</param>
        /// <param name=""param_generator"">Función que genera los valores de la nueva columna a partir de cada fila.</param>
        /// <returns>Tabla con la nueva columna agregada.</returns>
        public static List<Column> AddColumn(List<Column> param_table,
            string param_column_name,
            Func<Dictionary<string, string>, string> param_generator)
        {
            List<Column> ret_table = Clone(param_table);

            Column new_column = new Column(param_column_name, Column.DataType.None, new List<string>());

            int row_count = param_table.FirstOrDefault()?.Values.Count ?? 0;
            for (int row_index = 0; row_index < row_count; row_index++)
            {
                Dictionary<string, string> row = BuildRow(param_table, row_index);
                new_column.Values.Add(param_generator(row));
            }

            ret_table.Add(new_column);
            return ret_table;
        }

        /// <summary>
        /// Elimina columnas de una tabla pasada por parámetro según una lista de nombres de columnas a eliminar.
        /// </summary>
        /// <param name=""param_table"">Tabla original a la que se eliminarán las columnas.</param>
        /// <param name=""param_columns_to_remove"">Lista de nombres de columnas a eliminar.</param>
        /// <returns>Tabla resultante con las columnas eliminadas.</returns>
        public static List<Column> RemoveColumns(List<Column> param_table,
            List<string> param_columns_to_remove)
        {
            return param_table
                .Where(column => !param_columns_to_remove.Contains(column.Name))
                .Select(column => new Column(column.Name, Column.DataType.None, new List<string>(column.Values)))
                .ToList();
        }

        /// <summary>
        /// Selecciona columnas según una lista de nombres de columnas a seleccionar.
        /// </summary>
        /// <param name=""param_table"">Tabla original de la que se seleccionarán las columnas.</param>
        /// <param name=""param_columns_to_select"">Lista de nombres de columnas a seleccionar.</param>
        /// <returns>Tabla resultante con las columnas seleccionadas.</returns>
        public static List<Column> SelectColumns(List<Column> param_table,
            List<string> param_columns_to_select)
        {
            return param_table
                .Where(column => param_columns_to_select.Contains(column.Name))
                .Select(column => new Column(column.Name, Column.DataType.None, new List<string>(column.Values)))
                .ToList();
        }
        
        /// <summary>
        /// Selecciona filas según un predicado que recibe una función que evalúa cada fila.
        /// </summary>
        /// <param name=""param_table"">Tabla original de la que se seleccionaran las filas.</param>
        /// <param name=""param_predicate"">Función que evalúa cada fila y devuelve true si la fila debe ser seleccionada.</param>
        /// <returns>Tabla resultante con las filas seleccionadas.</returns>
        public static List<Column> SelectRows(List<Column> param_table, 
            Func<Dictionary<string, string>, bool> param_predicate)
        {
            List<Column> ret_result = CloneStructure(param_table);

            int row_count = param_table.FirstOrDefault()?.Values.Count ?? 0;

            for (int row_index = 0; row_index < row_count; row_index++)
            {
                Dictionary<string, string> row = BuildRow(param_table, row_index);
                if (param_predicate(row))
                {
                    foreach (Column column in ret_result)
                    {
                        column.Values.Add(row[column.Name]);
                    }
                }
            }

            return ret_result;
        }

        #endregion ""Public Methods""

        #region ""Private Methods""

        /// <summary>
        /// Construye una fila de tipo Dictionary<string, string> a partir del índice de la fila en la tabla original.
        /// </summary>
        /// <param name=""param_table"">Tabla original de la que se construirá la fila.</param>
        /// <param name=""param_index"">Índice de la fila a construir.</param>
        /// <returns>Fila construida como un diccionario columna-valor.</returns>
        private static Dictionary<string, string> BuildRow(List<Column> param_table, int param_index)
        {
            Dictionary<string, string> ret_row = new Dictionary<string, string>();
            foreach (var column in param_table)
            {
                ret_row[column.Name] = column.Values[param_index];
            }

            return ret_row;
        }

        /// <summary>
        /// Clona una tabla completa, incluyendo los valores de cada columna.
        /// </summary>
        /// <param name=""param_table"">Tabla original a clonar</param>
        /// <returns>Tabla clonada.</returns>
        private static List<Column> Clone(List<Column> param_table)
        {
            return param_table
                .Select(column => new Column(column.Name, Column.DataType.None, new List<string>(column.Values)))
                .ToList();
        }

        /// <summary>
        /// Clona una estructura de datos vacía con los mismos nombres de columnas pero sin valores.
        /// </summary>
        /// <param name=""param_table"">Tabla original de la que se clonará la estructura.</param>
        /// <returns>Lista de columnas con los mismos nombres pero sin valores.</returns>
        private static List<Column> CloneStructure(List<Column> param_table)
        {
            return param_table.Select(column => new Column(column.Name,
                    Column.DataType.None,
                    new List<string>())).ToList();
        }
        
        #endregion ""Private Methods""
    }
}";

        /// <summary>
        /// Programa principal, ejecuta las instrucciones iniciales.
        /// </summary>
        static readonly public string Program =
@"using transformer_generator.src.Model;
using transformer_generator.src.Utils.MetadataDAO;
using test_proyect_c_sharp.src.Services.TableManagment;

{Instructions}";

        /// <summary>
        /// Código de proyecto para visual studio
        /// </summary>
        static readonly public string Csproj =
@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <RootNamespace>test_proyect_c_sharp</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include=""src\Model\"" />
    <Folder Include=""src\Services\Metadata\"" />
  </ItemGroup>

</Project>
";

        /// <summary>
        /// Código de proyecto para visual studio
        /// </summary>
        static readonly public string Slnx =
@"<Solution>
  <Project Path=""test-proyect-c-sharp.csproj"" />
</Solution>
";
    }
}
