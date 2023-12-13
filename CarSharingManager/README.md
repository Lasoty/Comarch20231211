# Wymagania Projektowe dla "CarSharingManager"

## 1. Cel i Zakres
* **Główny Cel**: Aplikacja ma na celu nauczenie użytkowników metodologii TDD poprzez praktyczne zastosowanie w projekcie.
* **Zakres**: Zarządzanie flotą samochodów w systemie współdzielenia pojazdów.

## 2. Funkcjonalności
* **Dodawanie Samochodu**: Możliwość dodawania nowych samochodów do systemu.
* **Edycja Samochodu**: Modyfikacja informacji o samochodzie.
* **Usuwanie Samochodu**: Usuwanie samochodu z systemu.
* **Wyszukiwanie Samochodu**: Przeszukiwanie listy samochodów według różnych kryteriów.
* **Rezerwacja Samochodu**: Możliwość rezerwacji dostępnego samochodu.
* **Anulowanie Rezerwacji**: Anulowanie istniejącej rezerwacji.
* **Raportowanie Stanu Samochodów**: Generowanie raportów o stanie i dostępności pojazdów.

## 3. Interfejs Użytkownika
* **Konsolowy Interfejs Użytkownika**: Prosty interfejs konsolowy do interakcji z aplikacją.

## 4. Testowanie i TDD
* **Testy Jednostkowe**: Każda funkcjonalność powinna być poprzedzona testami jednostkowymi.
* **Testy Integracyjne**: Testy integracyjne dla scenariuszy użycia łączących wiele komponentów.
* **Mockowanie**: Użycie Moq do mockowania zależności w testach.

## 5. Wymagania Techniczne
* **Język Programowania**: C# z użyciem .NET 7.
* **Framework Testowy**: NUnit.
* **Biblioteka Asercji**: FluentAssertions.
* **Framework do Mockowania**: Moq.
* **Baza Danych**: Opcjonalnie, prosta baza danych (np. SQLite) do przechowywania danych o samochodach i rezerwacjach.

## 6. Przypadki Użycia do Demonstracji TDD
* **Walidacja Danych Samochodu**: Testy walidujące poprawność danych samochodu.
* **Proces Rezerwacji**: Testowanie logiki rezerwacji samochodu.
* **Zarządzanie Konfliktami Rezerwacji**: Testowanie sytuacji, gdy dwa żądania rezerwacji nakładają się na siebie.
* **Generowanie Raportów**: Testowanie generowania raportów o stanie floty.
