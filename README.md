# Result Pattern in C#

Este repositorio implementa el patrón `Result` en C#, una forma segura y expresiva de manejar operaciones que pueden fallar sin recurrir a excepciones.

## ✨ Características

- `Result`: representa el estado de éxito o error. No incluye un valor en caso de éxito, pero sí instancias de `Error` en caso de fallo.
- `Result<TSuccess>`: versión genérica que encapsula un valor cuando la operación es exitosa, o instancias de `Error` si falla.
- `Result<TSuccess, TError>`: versión genérica que encapsula un valor de éxito o un error fuertemente tipado.
- Métodos `Match` permiten manejar ambos estados (éxito y error) de forma funcional y expresiva.
- Propiedades `IsSuccess` y `IsFailure` facilitan la inspección rápida del estado del resultado.
- Pruebas unitarias completas con xUnit para garantizar la confiabilidad del patrón.

```

## 🧪 Pruebas incluidas

Las pruebas cubren:

- ✅ Creación de resultados exitosos y fallidos
- ✅ Validación de propiedades (`IsSuccess`, `IsFailure`)
- ✅ Comportamiento de `Match` con funciones y acciones
- ✅ Acceso seguro a `Value` y `Error` (con excepciones en estado incorrecto)

## 🛠️ Ejemplo de uso

```csharp
var result = Result<string, string>.Ok("Orden creada");

var mensaje = result.Match(
    onSuccess: val => $"Éxito: {val}",
    onError: err => $"Error: {err}"
);
```

## 📚 Motivación

El patrón `Result` permite:

- Evitar excepciones para control de flujo
- Expresar claramente el éxito o fracaso de una operación
- Facilitar pruebas y composición funcional

## 🧰 Requisitos

- El código ha sido implementado con .NET 9.
- xUnit para pruebas

---

¡Contribuciones y sugerencias son bienvenidas!
