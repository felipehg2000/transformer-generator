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

#include ""TableManagment.h""

/**
 * @brief   Imprime los datos de una tabla para poder visualizarla por pantalla
 * @param   param_table tabla rellena a imprimir por pantalla
 * @since   {Fecha}
 * @author  Generado automáticamente
 */
void PrintTable(const TableManagment::Table &param_table)
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
        /// Plantilla para el make file del proyecto, con instrucciones para compilar y ejecutar el script.
        /// </summary>
        static readonly public string CMakeLists =
@"# Versión mínima de CMake
cmake_minimum_required(VERSION 3.15)

# Nombre del proyecto
project(TableManagerApp LANGUAGES CXX)

# Información del compilador (opcional pero útil)
message(STATUS ""Compilador C++: ${CMAKE_CXX_COMPILER}"")
message(STATUS ""ID del compilador: ${CMAKE_CXX_COMPILER_ID}"")
message(STATUS ""Version del compilador: ${CMAKE_CXX_COMPILER_VERSION}"")

# Estándar de C++
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# ============================
# EJECUTABLE PRINCIPAL
# ============================

add_executable(TableManagerApp
    main.cpp
    src/TableManagment.cpp
)

# Incluir directorios de headers
target_include_directories(TableManagerApp PRIVATE
    ${CMAKE_SOURCE_DIR}/src
)

# ====================================================
# Instrucciones para compilar y ejecutar
# ====================================================

# cmake -S . -B build
# cmake --build build  (Crea solo la carpeta de debug, para ejecutar cd debug y ./TableManagerApp)
# cmake --build build --config Release (Crea solo la carpeta de release, para ejecutar cd release y ./TableManagerApp)";
    }
}
