# SISTEMA CALCULADORA

El sistema Calculadora  implementa un 'Servicio de calculadora' basado en HTTP/REST que permite realizar operaciones aritméticas básicas
como sumar, restar, multiplicar, dividir y raíz cuadrada. Además la solución implementa un cliente de aplicación de consola para consumir 
el servicio HTTP/REST. La aplicación cuenta también con un registro log que guarda el historial de las operaciones que se solicitan en el sistema.


El Entorno de Desarrollo Integrado para implementar la solución fue Visual Studio 2019
Sistema implementado en ASP/WebAPI, lenguaje de programación C# y .NET Framework 4.8. 

# Solución Calculator

Solución que implementa las aplicaciones:
ClientCalculator: Aplicación de consola que consume el servicio REST que realiza las operaciones aritméticas.
ServiceCalculator: Servicio ASP/WebAPI que implementa una calculadora con operaciones básicas.
ServiceCalculator.Test: Aplicación para pruebasunitarias.

# ClientCalculator

Aplicación de consola la cual opera como cliente de línea de comandos, permite realizar solicitudes al servicio HTTP ServiceCalculator.

La aplicación permite al usuario seleccionar una operación de suma, resta, multiplicación, división o raíz cuadrada, además permite ingresar un valor ID para registrar 
las operaciones realizadas.

En cada operacion aritmética se especifica como debe ser la entrada de datos correcta caso contrario la aplicación valida los datos y muestra mensaje de error.

Dependencias ClientCalculator
RestSharp: Instalar desde Nuget

# ServiceCalculator

Servicio donde se implementan las operaciones aritmeticas de la Calculadora a partir de los valores ingresados desde el cliente. Si se proporcionó un TrackingId, 
la información de la operación de trazas es guardada en un archivo .json el cual puede ser consultado posteriormente por dicho ID.

Operaciones implementadas en el servicio:

Add: Suma varios números y retorma el resultado.
Sub: Resta entre dos numeros y devuelve el resultado. 
Mult: Multiplicación de varios números y devuelve el resultado.
Div: Divide dos números y devuelve el resultado y su resto. 
Sqrt: Realiza la raíz cuadrada de un determinado número. 
Query: Retorna una lista de operaciones registradas con un mismo identificador. 

NOTA: Este proyecto cuenta con las carpetas Models, Controllers y Views que ordenan el proyecto en capas simulando patrón Modelo-Vista-Controlador.

Dependencia ServiceCalculator
Newtonsoft.Json: Instalar desde NuGet

# Dependencias generales

Instalar los siguientes programas en caso de no tener.
Visual Studio 2019 URL: https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&rel=16
.NET Framework 4.8 URL: https://dotnet.microsoft.com/download/dotnet-framework/net48

# Como ejecutar la aplicación

Abrir solución Calculator.sln con Visual Studio 2019, luego ejecutar dicha solución precionando la tecla F5 y automáticamente se levantarán el servicio WebAPI en un navegador y la aplicación
de consola, esta  última con la que debe interactuar el usuario para realizar las operaciones de la calculadora. La solución está configurada para que se ejecuten los dos proyectos al mismo tiempo. 







