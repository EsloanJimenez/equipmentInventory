## 🧾 Requisitos Previos

Antes de comenzar, asegúrate de tener instalados los siguientes componentes:

* **.NET SDK 6.0 o superior**: [Descargar .NET SDK](https://dotnet.microsoft.com/download)
* **Node.js y npm**: [Descargar Node.js](https://nodejs.org/)
* **SQL Server Management Studio (SSMS)**: [Descargar SSMS](https://aka.ms/ssms)

---

## 📁 Estructura del Proyecto

El repositorio contiene las siguientes carpetas:

* `DB/`: Contiene el script SQL para crear la base de datos.
* `EquipmentInventory/`: Proyecto backend en ASP.NET Core.
* `front/`: Proyecto frontend desarrollado con Vue.js.

---

## 🛠️ Paso 1: Configurar la Base de Datos

1. **Abrir SQL Server Management Studio (SSMS)** y conectarse al servidor de base de datos.
2. **Ejecutar el script SQL**:

   * Abrir el archivo `DB/DB_EquipmentInventory.sql`.
   * Ejecutar el script.

---

## ⚙️ Paso 2: Configurar el Backend (ASP.NET Core)

1. **Abrir el proyecto backend**:

   * Navegar a la carpeta `EquipmentInventory/`.
   * Abrir el archivo `EquipmentInventory.sln` con Visual Studio o tu editor preferido.

2. **Configurar la cadena de conexión**:

   * Abrir el archivo `appsettings.json`.
   * Reemplazar el valor de `"Server"` por el nombre de tu servidor:

     Asegúrate de reemplazar `tu_usuario` y `tu_contraseña` con tus credenciales reales. Si estás utilizando autenticación de Windows, puedes usar:

     
     "EquipmentInventory": "Server=localhost;Database=basename;User Id=user;Password=123;TrustServerCertificate=true;Trusted_Connection=True;"
     

3. **Restaurar paquetes y compilar el proyecto**:

   * Abrir una terminal en la carpeta `EquipmentInventory/`.
   * Ejecutar los siguientes comandos:
     
     dotnet restore
     dotnet build
     

   * F5 para ejecutar el proyecto.

---

## 🌐 Paso 3: Configurar el Frontend (Vue.js)

1. **Abrir una terminal** y navegar a la carpeta `front/`:


2. **Instalar las dependencias**:

   npm install
  
3. **Configurar la URL**:

   * Abrir el archivo de apiBaseURL.js que se encuentra en la carpeta src/utils/.
   * Asegurarse de que la URL del backend coincida con la que esta en el archivo apiBaseURL.js (`https://localhost:7012/api/`).

4. **Ejecutar el frontend**:

   npm run dev

---

## ✅ Verificación Final

1. **Abrir el navegador** y navegar a la url que muestra la terminal.
2. **Interactuar con la aplicación** para asegurarse de que el frontend y el backend están comunicándose correctamente y que la base de datos está funcionando como se espera.

---
