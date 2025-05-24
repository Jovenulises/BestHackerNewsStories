# 🧠 Santander - Developer Coding Test

Este proyecto resuelve el reto técnico solicitado por Santander utilizando **ASP.NET Core** para crear una API RESTful que consume datos desde la [Hacker News API](https://github.com/HackerNews/API), junto con una aplicación cliente desarrollada con **Blazor Server** para mostrar los resultados de forma amigable.

---

## 🚀 Descripción del Proyecto

La solución está compuesta por **dos aplicaciones independientes**:

### 🔹 API Backend (ASP.NET Core Web API)
Expone un endpoint que permite recuperar los mejores `n` artículos de Hacker News ordenados por su `score`.

🔗 URL en producción:  
[https://apihacker-ebf6bydabxhjgvf0.canadacentral-01.azurewebsites.net/stories/best-stories?n=10]

Se desplego en Azure y se puede acceder a través de la URL proporcionada.

---

### 🔹 Frontend (Blazor Server)
Permite al usuario seleccionar un número `n` y visualizar los mejores artículos obtenidos desde la API anterior.

🔗 URL en producción:  
[https://fronthacker-btgwavg2cfgubgd6.mexicocentral-01.azurewebsites.net/]

Repositorio de Github: https://github.com/Jovenulises/fronthacker

---

## 📦 Cómo Ejecutar la Aplicación Localmente

### 🔧 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) o superior
- Visual Studio 2022 o superior
- Acceso a Internet (para consumir la Hacker News API)

### ▶️ Instrucciones

1. Clona los dos repositorios (API y Frontend).
2. Configura la URL de la API en el frontend si deseas apuntar a un entorno local.
3. Ejecuta ambos proyectos desde Visual Studio o `dotnet run`.

---

## 🧱 Arquitectura Utilizada

Esta aplicación ha sido desarrollada siguiendo una arquitectura basada en **Clean Architecture** y principios **SOLID**, orientada a escalabilidad, mantenibilidad y extensibilidad.

### 📁 Estructura por Capas


### 🧱 Arquitectura Utilizada

 Arquitectura Utilizada
Esta aplicación ha sido desarrollada siguiendo una arquitectura basada en "Clean Architecture" y principios de diseño SOLID, especialmente orientada a facilitar la escalabilidad, el mantenimiento y la extensibilidad tanto del frontend como del backend.

🧱 Estructura por Capas



/Arquitectura
├── NombreModulo
│ ├── Controllers // Endpoints HTTP
│ ├── Services // Lógica de negocio
│ ├── Interfaces // Contratos entre capas
│ ├── Repositories // Acceso a la API de Hacker News
│ ├── DTOs // Transferencia de datos
│ └── Models // Entidades del dominio



### ✅ Ventajas

- **Separación de responsabilidades**
- **Escalabilidad modular**
- **Alta testabilidad**
- **Reutilización de componentes**
- **Facilidad de mantenimiento**

---

## ⚡ Estrategia de Rendimiento: Uso de Caché

Para evitar sobrecarga y mejorar el tiempo de respuesta, se implementó `MemoryCache` en el servicio `StoryService`.

### 🛠 ¿Cómo funciona?

- Cuando se llama a `GET /stories/best-stories?n={n}`, se verifica si hay resultados en caché.
- Si existen, se devuelven desde memoria.
- Si no, se hacen las llamadas a Hacker News, se procesan y se almacenan en caché por **5 minutos**.

### 📈 Beneficios

- 🔄 Menos llamadas a la API externa
- ⚡ Mejores tiempos de respuesta
- 📉 Reducción del consumo de recursos

### 📌 Ejemplo

GET /stories/best-stories?n=10

Primera llamada: se consulta Hacker News y se guarda el resultado.

Llamadas siguientes: se devuelve la respuesta directamente desde la caché.

### Mejoras Futuras

Si se contara con más tiempo o se migrara a producción:

🧪 Pruebas unitarias e integración con xUnit y Moq

🌐 Documentación interactiva con Swagger/OpenAPI

🐳 Dockerización de ambos proyectos

🔐 Autenticación JWT o IdentityServer

☁️ Caché distribuido (Redis) para despliegues horizontales

📊 Monitoreo con Application Insights o Prometheus/Grafana

🧰 Validación avanzada de parámetros (n, rangos, tipos)

🎨 Mejoras visuales en el frontend con diseño responsive y accesible

### ✉️ Contacto
Desarrollado por [JESUS ULISES CRUZ PAZ]
📧 Tel: +52 4271678743 
💼 GitHub: https://github.com/Jovenulises

