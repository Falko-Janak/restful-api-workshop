# Live Workshop: RESTful APIs in ASP.NET Core

In diesem 3-stündigen Workshop entwickelst du eine praxisnahe REST API mit ASP.NET Core. Der Fokus liegt nicht nur auf der Funktionalität, sondern vor allem auf **gutem API-Design** nach modernen Standards.

---

## Voraussetzungen

Um aktiv am Workshop teilnehmen zu können, solltest du folgendes mitbringen:

- **Visual Studio 2022** mit installiertem **ASP.NET & Webentwicklung**-Workload
- Erfahrung mit **C#**
- Einfache Kenntnisse über JSON

---

## Inhalte

### Einführung & Zielsetzung
- Was macht eine gute REST API aus?
- Überblick über moderne API-Design-Prinzipien

### Projektsetup & API-Grundstruktur
- Erstellen eines ASP.NET Core Web API Projekts
- Projektstruktur nach Best Practices: Controller, Services, Repositories
- Konfiguration und Dependency Injection

### Entitäten & API-Design
- Entitäten:
  - `Product`: Name, Preis, Lagerbestand
  - `Cart`: Benutzer, Produkte im Warenkorb
  - `Order`: Benutzer, Datum, Gesamtsumme
  - `OrderItem`: Produkt, Menge, Preis zum Kaufzeitpunkt
- Ressourcenorientiertes URL-Design:
  - `/products`
  - `/carts/{id}/items`
  - `/orders`
  - `/orders/{id}/items`
- Query- vs. Path-Parameter: Wann welches einsetzen?

### HTTP-Verben & Status Codes
- Verwendung von `GET`, `POST`, `PUT`, `PATCH`, `DELETE`
- Bedeutung und Einsatz von:
  - `200 OK`
  - `201 Created`
  - `400 Bad Request`
  - `401 Unauthorized`
  - `403 Forbidden`
  - `404 Not Found`
  - `500 Internal Server Error`

### Order-Handling & Datenpersistenz
- Bestellung aus dem Warenkorb erzeugen
- `OrderItems` mit Preis und Menge zum Kaufzeitpunkt speichern
- Lagerbestand aktualisieren
- Gesamtsumme berechnen und abspeichern

### API-Dokumentation & Testing
- API-Dokumentation mit OpenAPI (Swagger)
- Testen der Endpunkte mit Postman
- Fehlerfälle nachvollziehbar abbilden und testen

### Abschluss & Q&A
- Recap der wichtigsten Designentscheidungen
- Weiterführende Tipps & Ressourcen
- Fragen & Diskussion

---

## Ziel

Nach diesem Workshop kannst du strukturierte, saubere und erweiterbare REST APIs in ASP.NET Core entwickeln – mit Fokus auf gutes API-Design, klare Routenführung und sinnvollen Einsatz von HTTP-Konzepten.

---

Dieser Workshop wird ermöglicht durch [Coding mit Jannick](https://codingmitjannick.de/s/coding-mit-jannick).
