# Gestión de Registros de Estudiantes

Este documento describe tres enfoques diferentes para gestionar los registros de estudiantes, almacenando su información (apellidos, nombres, notas y promedio) y proporcionando consultas.

## **Métodos Desarrollados**

### 1. **Gestión con archivo XML en Pyhton🐍**
Este método utiliza un archivo XML para almacenar y consultar los datos de los estudiantes.

- **Insertar Estudiantes**: El usuario ingresa los apellidos, nombres y notas de cada estudiante. El promedio se calcula y los datos se almacenan en un archivo XML llamado `notas.xml`. Si el archivo no existe, se crea con una estructura inicial.
- **Consultar Registros**: Los registros de los estudiantes se leen desde el archivo XML, mostrando apellidos, nombres, notas y promedios.

### 2. **Student Grades 2 (Gestión con base de datos SQL)**

Este método utiliza una base de datos SQL para almacenar y consultar los registros de los estudiantes.

Funcionalidad
- Insertar Estudiantes: Los datos de los estudiantes (apellidos, nombres, notas) se almacenan en una base de datos SQL llamada NotasEstudiantes. Se utiliza una consulta SQL con parámetros para insertar los datos, lo que ayuda a prevenir vulnerabilidades de inyección SQL.

- Consultar Registros: Se pueden realizar consultas sobre la base de datos, filtrando registros según diferentes criterios, como el promedio de los estudiantes

### 3. **Gestión con arreglos en memoria**

Este enfoque utiliza arreglos en memoria para almacenar los registros de los estudiantes.

Funcionalidad
Captura de Datos: Se solicitan los apellidos, nombres y notas de cada estudiante. El promedio se calcula mientras se ingresan los datos.

Mostrar Registros: Una vez que los datos se han capturado, se muestran todos los registros con los nombres, apellidos, notas y promedios.
