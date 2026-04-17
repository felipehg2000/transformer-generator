namespace transformer_generator.Templates
{
    /// <summary>
    /// Almacena todas las porciones de código que necesita el generador para crear un proyecto de C++ que ejecute las instrucciones leídas del lenguaje M.
    /// </summary>
    internal class Cpp
    {
        /// <summary>
        /// Clase principal del programa, contiene el método main que se encargará de ejecutar las instrucciones leídas del lenguaje M.
        /// </summary>
        static readonly public string MainCpp =
@"#include <iostream>
#include <string>

#include ""src/TableManagment.h""
#include ""src/TableOutput.h""

/**
 * @brief   Función principal del programa, primera y última en ejecutarse
 * @details Clona los pasos leidos del lenguaje M
 * @return  int siempre devuelve 0 
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
int main()
{
{Instrucciones}
    return 0;
}
";

        /// <summary>
        /// Parte de los encabezados de la clase que clona el comportamiento de las instrucciones del lenguaje M.
        /// </summary>
        static readonly public string TableManagmentH =
@"#ifndef TableManagmentH
#define TableManagmentH

#include <string>
#include <vector>
#include <functional>
#include <unordered_map>

/**
 * @brief   Espacio de nombres para la gestión de tablas. Implementa los métodos de los pasos que se pueden leer del fichero M.
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
namespace TableManagment
{
    // Alias para una estructura larga de tipo mapa.
    using Row = std::unordered_map<std::string, std::string>;

    // Alias de una estructura larga de tipo vector de mapas
    using Table = std::vector<Row>; 
    
    // Añadir columna
    Table AddColumn(const Table &param_table,
        const std::string &param_name,
        std::function<std::string(const Row&)> param_generate);

    // Leer fichero de tipo CSV
    Table ReadCSV(const std::string &param_path);

    // Borrar columnas
    Table RemoveColumns(const Table &param_table,
        std::vector<std::string> param_columns);

    // Seleccionar una columna
    Table SelectColumns(const Table &param_table,
        std::vector<std::string> param_columns);

    // Seleccionar una fila
    Table SelectRow(const Table &param_table,
        std::function<bool(const Row&)> param_predicate);
}
#endif
";

        /// <summary>
        /// Parte de implementación de la clase que colna el comportamiento de las instrucciones del lenguaje M.
        /// </summary>
        static readonly public string TableManagmentCpp =
@"#include <fstream>
#include <sstream>

#include ""TableManagment.h""

/**
 * @brief   Lee un fichero CSV y traduce la información al tipo de dato Table
 * @param   param_path ruta al fichero a traducir
 * @return  Tipo de dato Table vacío en caso de error, con los datos del CSV en caso de acierto.
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
TableManagment::Table TableManagment::ReadCSV(const std::string &param_path)
{
    // Variable de retorno 
    TableManagment::Table ret_table;

    // Abre fichero
    std::ifstream file(param_path);
    if (!file.is_open())
        return ret_table;

    // Define variables de lectura
    std::string line;
    std::vector<std::string> headers;

    // Lee cabeceras
    if (std::getline(file, line))
    {
        std::stringstream cast_line(line);
        std::string cell;

        while (std::getline(cast_line, cell, ','))
            headers.push_back(cell);
    }

    // Lee datos
    while (std::getline(file, line))
    {
        // Castea la linea
        std::stringstream cast_line(line);

        // Define variables
        std::string cell;
        Row row;
        int index = 0;

        // Recorre las columnas
        while (std::getline(cast_line, cell, ','))
        {
            std::string columnName = headers[index];
            row[columnName] = cell;
            index++;
        }

        // Carga vector
        ret_table.push_back(row);
    }

    return ret_table;
}

/**
 * @brief   Selecciona una fila de la tabla.
 * @param   param_table tabla de la que se seleccionará una fila.
 * @param   param_predicate fila a buscar dentro de la tabla.
 * @return  Tabla con la fila a buscar.
 * @since   {Fecha}
 * @author  Generado automáticamente.
 */
TableManagment::Table TableManagment::SelectRow(const TableManagment::Table &param_table, std::function<bool(const TableManagment::Row&)> param_predicate)
{
    // Variable de retorno
    TableManagment::Table ret_table;

    // Recorre las filas
    for (const TableManagment::Row& row : param_table)
    {
        if (param_predicate(row))
            ret_table.push_back(row);
    }

    return ret_table;
}

/**
 * @brief   Selecciona una o más columnas de una tabla.
 * @param   param_table tabla de la que se seleccionarán las filas.
 * @param   param_columns nombres de las columnas a seleccionar
 * @return  Tabla con las columnas seleccionadas.
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
TableManagment::Table TableManagment::SelectColumns(const TableManagment::Table &param_table, std::vector<std::string> param_columns)
{
    // Variable de retorno
    TableManagment::Table ret_table;

    // Recorre todas las filas
    for (const TableManagment::Row &row : param_table)
    {
        TableManagment::Row new_row;

        // Recorre todas las columnas
        for (const std::string &col : param_columns)
        {
            if (row.find(col) != row.end())
                new_row[col] = row.at(col);
        }

        // Carga el fichero con la nueva fila
        ret_table.push_back(new_row);
    }

    // Retorna el resultado
    return ret_table;
}

/**
 * @brief   Borra columnas de la tabla.
 * @param   param_table tabla de la que se borrarán las columnas
 * @param   param_columns nombre de las columnas a borrar.
 * @return  Tabla sin la columna que se debía borrar
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
TableManagment::Table TableManagment::RemoveColumns(const TableManagment::Table &param_table, std::vector<std::string> param_columns)
{
    // Variable de retorno
    TableManagment::Table ret_table;

    // Recorre filas 
    for (TableManagment::Row row : param_table)
    {
        // Recorre columnas borrando la fila
        for (const std::string &column : param_columns)
        {
            row.erase(column);
        }

        // Agrega la fila sin la columna borrada
        ret_table.push_back(row);
    }

    // Retorna el resultado
    return ret_table;
}

/**
 * @brief   Añade una columna a todas las filas de una tabla.
 * @param   param_table tabla a la que se le añadirá una columna.
 * @param   param_column_name nombre de la columna a añadir
 * @param   param_generator función a aplicar para añadir la columna al mapa.
 * @return  Tabla con la columna que se debía añadir
 * @since   {fecha}
 * @author  Generado automáticamente
 */
TableManagment::Table TableManagment::AddColumn(const TableManagment::Table &param_table, const std::string &param_column_name, std::function<std::string(const TableManagment::Row&)> param_generator)
{
    // Variable de retorno
    TableManagment::Table ret_table;

    // Recorre todas las filas añadiendo el dato
    for (TableManagment::Row row : param_table)
    {
        row[param_column_name] = param_generator(row);
        ret_table.push_back(row);
    }

    // Retorna el resultado
    return ret_table;
}
";

        /// <summary>
        /// Parte de encabezados de la clase encargada de imprimir tablas.
        /// </summary>
        static readonly public string TableOutputH =
@"#ifndef TableOutputH
#define TableOutputH

#include ""TableManagment.h""

/**
 * @brief   Clase encargada de mostrar tablas. Método para mostrarla por consola y método para exportarla a CSV.
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
class TableOutput
{
	public:
		static void ExportTableToCSV(const TableManagment::Table& param_table);
		static void PrintTable(const TableManagment::Table& param_table);
};
#endif
";

        /// <summary>
        /// Parte de implementación de la clase encargada de imprimir tablas.
        /// </summary>
        static readonly public string TableOutputCpp =
@"#include <fstream>
#include <iostream>

#include ""TableOutput.h""

/**
 * @brief   Genera un fichero CSV y lo rellena con los datos de la tabla pasada por parámetros.
 * @param   param_table tabla rellena a exportar.
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
void TableOutput::ExportTableToCSV(const TableManagment::Table& param_table)
{
    // Comprobar variable
    if (param_table.empty())
    {
        return;
    }

    // Abrir fichero
    std::ofstream file(""{Path}"");
    if (!file.is_open())
    {
        return;
    }

    // Cabeceras
    std::string csv_table = """";
    std::string line = """";
    for (const auto& [key, value] : param_table[0])
    {
        if (line != """")
        {
            line += "","";
        }
        line += key;
    }
    csv_table = line;

    // Valores
    for (const auto& row : param_table)
    {
        line = """";
        for (const auto& [key, value] : row)
        {
            if (line != """")
            {
                line += "","";
            }
            line += value;
        }
        csv_table += ""\n"" + line;
    }


    // Cargar y cerrar fichero
    file << csv_table;
    file.close();
}

/**
 * @brief   Imprime los datos de una tabla para poder visualizarla por consola
 * @param   param_table tabla rellena a imprimir por pantalla
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
void TableOutput::PrintTable(const TableManagment::Table& param_table)
{
    if (param_table.empty())
    {
        std::cout << ""(Tabla limpia)\n"";
        return;
    }

    // Imprimir cabeceras 
    for (const auto& [key, value] : param_table[0])
    {
        std::cout << key << ""\t"";
    }
    std::cout << ""\n----------------------------------\n"";

    // Imprimir filas
    for (const auto& row : param_table)
    {
        for (const auto& [key, value] : row)
        {
            std::cout << value << ""\t"";
        }
        std::cout << ""\n"";
    }
}
";

        /// <summary>
        /// Solución legible por visual studio
        /// </summary>
        static readonly public string MTransformerSlnx =
@"<Solution>
  <Configurations>
    <Platform Name=""x64"" />
    <Platform Name=""x86"" />
  </Configurations>
  <Project Path=""m-transformer.vcxproj"" Id=""27438b77-83c4-41bf-9152-f86202c90463"" />
</Solution>
";

        /// <summary>
        /// Fichero de proyecto para visual studio
        /// </summary>
        static readonly public string MTransformerVcxproj =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <ItemGroup Label=""ProjectConfigurations"">
    <ProjectConfiguration Include=""Debug|Win32"">
      <Configuration>Debug</Configuration>
      <Platform>Win32</Platform>
    </ProjectConfiguration>
    <ProjectConfiguration Include=""Release|Win32"">
      <Configuration>Release</Configuration>
      <Platform>Win32</Platform>
    </ProjectConfiguration>
    <ProjectConfiguration Include=""Debug|x64"">
      <Configuration>Debug</Configuration>
      <Platform>x64</Platform>
    </ProjectConfiguration>
    <ProjectConfiguration Include=""Release|x64"">
      <Configuration>Release</Configuration>
      <Platform>x64</Platform>
    </ProjectConfiguration>
  </ItemGroup>
  <PropertyGroup Label=""Globals"">
    <VCProjectVersion>18.0</VCProjectVersion>
    <Keyword>Win32Proj</Keyword>
    <ProjectGuid>{27438b77-83c4-41bf-9152-f86202c90463}</ProjectGuid>
    <RootNamespace>testproyectcpp</RootNamespace>
    <WindowsTargetPlatformVersion>10.0</WindowsTargetPlatformVersion>
  </PropertyGroup>
  <Import Project=""$(VCTargetsPath)\Microsoft.Cpp.Default.props"" />
  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Debug|Win32'"" Label=""Configuration"">
    <ConfigurationType>Application</ConfigurationType>
    <UseDebugLibraries>true</UseDebugLibraries>
    <PlatformToolset>v145</PlatformToolset>
    <CharacterSet>Unicode</CharacterSet>
  </PropertyGroup>
  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Release|Win32'"" Label=""Configuration"">
    <ConfigurationType>Application</ConfigurationType>
    <UseDebugLibraries>false</UseDebugLibraries>
    <PlatformToolset>v145</PlatformToolset>
    <WholeProgramOptimization>true</WholeProgramOptimization>
    <CharacterSet>Unicode</CharacterSet>
  </PropertyGroup>
  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Debug|x64'"" Label=""Configuration"">
    <ConfigurationType>Application</ConfigurationType>
    <UseDebugLibraries>true</UseDebugLibraries>
    <PlatformToolset>v145</PlatformToolset>
    <CharacterSet>Unicode</CharacterSet>
  </PropertyGroup>
  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Release|x64'"" Label=""Configuration"">
    <ConfigurationType>Application</ConfigurationType>
    <UseDebugLibraries>false</UseDebugLibraries>
    <PlatformToolset>v145</PlatformToolset>
    <WholeProgramOptimization>true</WholeProgramOptimization>
    <CharacterSet>Unicode</CharacterSet>
  </PropertyGroup>
  <Import Project=""$(VCTargetsPath)\Microsoft.Cpp.props"" />
  <ImportGroup Label=""ExtensionSettings"">
  </ImportGroup>
  <ImportGroup Label=""Shared"">
  </ImportGroup>
  <ImportGroup Label=""PropertySheets"" Condition=""'$(Configuration)|$(Platform)'=='Debug|Win32'"">
    <Import Project=""$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props"" Condition=""exists('$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props')"" Label=""LocalAppDataPlatform"" />
  </ImportGroup>
  <ImportGroup Label=""PropertySheets"" Condition=""'$(Configuration)|$(Platform)'=='Release|Win32'"">
    <Import Project=""$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props"" Condition=""exists('$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props')"" Label=""LocalAppDataPlatform"" />
  </ImportGroup>
  <ImportGroup Label=""PropertySheets"" Condition=""'$(Configuration)|$(Platform)'=='Debug|x64'"">
    <Import Project=""$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props"" Condition=""exists('$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props')"" Label=""LocalAppDataPlatform"" />
  </ImportGroup>
  <ImportGroup Label=""PropertySheets"" Condition=""'$(Configuration)|$(Platform)'=='Release|x64'"">
    <Import Project=""$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props"" Condition=""exists('$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props')"" Label=""LocalAppDataPlatform"" />
  </ImportGroup>
  <PropertyGroup Label=""UserMacros"" />
  <ItemDefinitionGroup Condition=""'$(Configuration)|$(Platform)'=='Debug|Win32'"">
    <ClCompile>
      <WarningLevel>Level3</WarningLevel>
      <SDLCheck>true</SDLCheck>
      <PreprocessorDefinitions>WIN32;_DEBUG;_CONSOLE;%(PreprocessorDefinitions)</PreprocessorDefinitions>
      <ConformanceMode>true</ConformanceMode>
      <LanguageStandard>stdcpp20</LanguageStandard>
    </ClCompile>
    <Link>
      <SubSystem>Console</SubSystem>
      <GenerateDebugInformation>true</GenerateDebugInformation>
    </Link>
  </ItemDefinitionGroup>
  <ItemDefinitionGroup Condition=""'$(Configuration)|$(Platform)'=='Release|Win32'"">
    <ClCompile>
      <WarningLevel>Level3</WarningLevel>
      <FunctionLevelLinking>true</FunctionLevelLinking>
      <IntrinsicFunctions>true</IntrinsicFunctions>
      <SDLCheck>true</SDLCheck>
      <PreprocessorDefinitions>WIN32;NDEBUG;_CONSOLE;%(PreprocessorDefinitions)</PreprocessorDefinitions>
      <ConformanceMode>true</ConformanceMode>
      <LanguageStandard>stdcpp20</LanguageStandard>
    </ClCompile>
    <Link>
      <SubSystem>Console</SubSystem>
      <GenerateDebugInformation>true</GenerateDebugInformation>
    </Link>
  </ItemDefinitionGroup>
  <ItemDefinitionGroup Condition=""'$(Configuration)|$(Platform)'=='Debug|x64'"">
    <ClCompile>
      <WarningLevel>Level3</WarningLevel>
      <SDLCheck>true</SDLCheck>
      <PreprocessorDefinitions>_DEBUG;_CONSOLE;%(PreprocessorDefinitions)</PreprocessorDefinitions>
      <ConformanceMode>true</ConformanceMode>
      <LanguageStandard>stdcpp20</LanguageStandard>
    </ClCompile>
    <Link>
      <SubSystem>Console</SubSystem>
      <GenerateDebugInformation>true</GenerateDebugInformation>
    </Link>
  </ItemDefinitionGroup>
  <ItemDefinitionGroup Condition=""'$(Configuration)|$(Platform)'=='Release|x64'"">
    <ClCompile>
      <WarningLevel>Level3</WarningLevel>
      <FunctionLevelLinking>true</FunctionLevelLinking>
      <IntrinsicFunctions>true</IntrinsicFunctions>
      <SDLCheck>true</SDLCheck>
      <PreprocessorDefinitions>NDEBUG;_CONSOLE;%(PreprocessorDefinitions)</PreprocessorDefinitions>
      <ConformanceMode>true</ConformanceMode>
      <LanguageStandard>stdcpp20</LanguageStandard>
    </ClCompile>
    <Link>
      <SubSystem>Console</SubSystem>
      <GenerateDebugInformation>true</GenerateDebugInformation>
    </Link>
  </ItemDefinitionGroup>
  <ItemGroup>
    <ClCompile Include=""src\TableManagment.cpp"" />
    <ClCompile Include=""src\TableOutput.cpp"" />
    <ClCompile Include=""m-transformer.cpp"" />
  </ItemGroup>
  <ItemGroup>
    <ClInclude Include=""src\TableManagment.h"" />
    <ClInclude Include=""src\TableOutput.h"" />
  </ItemGroup>
  <Import Project=""$(VCTargetsPath)\Microsoft.Cpp.targets"" />
  <ImportGroup Label=""ExtensionTargets"">
  </ImportGroup>
</Project>";

        /// <summary>
        /// Filtros que usa visual studio para mostrarlo al usuario.
        /// </summary>
        static readonly public string MTransformerFilters =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""4.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <ItemGroup>
    <Filter Include=""Archivos de origen"">
      <UniqueIdentifier>{4FC737F1-C7A5-4376-A066-2A32D752A2FF}</UniqueIdentifier>
      <Extensions>cpp;c;cc;cxx;c++;cppm;ixx;def;odl;idl;hpj;bat;asm;asmx</Extensions>
    </Filter>
    <Filter Include=""Archivos de encabezado"">
      <UniqueIdentifier>{93995380-89BD-4b04-88EB-625FBE52EBFB}</UniqueIdentifier>
      <Extensions>h;hh;hpp;hxx;h++;hm;inl;inc;ipp;xsd</Extensions>
    </Filter>
    <Filter Include=""Archivos de recursos"">
      <UniqueIdentifier>{67DA6AB6-F800-4c08-8B7A-83BB121AAD01}</UniqueIdentifier>
      <Extensions>rc;ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe;resx;tiff;tif;png;wav;mfcribbon-ms</Extensions>
    </Filter>
  </ItemGroup>
  <ItemGroup>
    <ClCompile Include=""m-transformer.cpp"">
      <Filter>Archivos de origen</Filter>
    </ClCompile>
    <ClCompile Include=""src\TableManagment.cpp"">
      <Filter>Archivos de origen</Filter>
    </ClCompile>
    <ClCompile Include=""src\TableOutput.cpp"">
      <Filter>Archivos de origen</Filter>
    </ClCompile>
  </ItemGroup>
  <ItemGroup>
    <ClInclude Include=""src\TableManagment.h"">
      <Filter>Archivos de encabezado</Filter>
    </ClInclude>
    <ClInclude Include=""src\TableOutput.h"">
      <Filter>Archivos de encabezado</Filter>
    </ClInclude>
  </ItemGroup>
</Project>";

        /// <summary>
        /// Carpetas que muestra visual studio para que el usuario vea los archivos ordenados.
        /// </summary>
        static readonly public string MTransformerUser =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""Current"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <PropertyGroup />
</Project>";

    }
}
