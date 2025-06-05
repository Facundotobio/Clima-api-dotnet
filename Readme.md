# 🌤️ API del Clima - C# .NET

Proyecto de API's desarrollada en ASP.NET Core que permite obtener el pronóstico del clima de una ciudad y comparar el clima entre dos ciudades.
Esta aplicación utiliza una API externa para obtener datos del clima.
Registrate en WeatherAPI.com

## 🚀 Funcionalidades

- Obtener el pronóstico para una ciudad en un rango de 1 a 14 días.
- Comparar el pronóstico entre dos ciudades en paralelo.
- Respuestas en español, con datos como:
  - Ciudad, país, coordenadas
  - Fecha, temperatura máxima/mínima/promedio
  - Humedad, precipitación, condición climática

## 📦 Estructura

- `Controllers/`: Controladores de API (`ClimaController`)
- `Models/`: Modelos para deserialización y respuesta
- `Services/`: Lógica de negocio y consumo de API externa

## 🌐 API en producción

- URL base: https://clima-api-dotnet-production.up.railway.app

### Ejemplos de endpoints

- `/api/clima?ciudad=Buenos Aires&dias=3`
- `/api/clima/comparar?ciudad1=Buenos Aires&ciudad2=Madrid&dias=5`
