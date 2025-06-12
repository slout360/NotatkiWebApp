# NotatkiWebApp

Prosta aplikacja webowa do zarządzania notatkami, napisana w ASP.NET Core MVC z użyciem bazy danych SQL Server.
Została stworzona na potrzeby projektu z PM9.

---

## Funkcjonalności

- Tworzenie, edycja i usuwanie notatek
- Kolorowe kategorie notatek (5 różnych kategorii!)
- Oznaczanie notatek jako ulubione
- Filtrowanie i wyszukiwanie notatek (po tytule, treści, kategorii, dacie, ulubionych)
- Sortowanie notatek
- Zachowanie daty utworzenia i daty ostatniej edycji notatki
- Responsywny i czytelny interfejs użytkownika

---

## Technologie

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap (frontend)

---

## Instalacja i uruchomienie

1. **Sklonuj repozytorium:**

```bash
git clone https://github.com/slout360/NotatkiWebApp.git
```

2. **Otwórz projekt w Visual Studio 2022 (lub nowszym).**

3. **Skonfiguruj połączenie do bazy danych w appsettings.json:**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=NotatkiDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

4. **Wykonaj migracje EF Core, aby utworzyć bazę danych:**

```bash
dotnet ef database update
```

lub w Visual Studio z konsoli Menedżera Pakietów:

```powershell
Update-Database
```

5. **Uruchom aplikację (F5 lub Ctrl+F5).**

---

## Używanie

- Na stronie głównej zobaczysz (prawdopodobnie pustą) listę notatek.
- Możesz tworzyć nowe, edytować istniejące oraz je usuwać.
- Kliknij w "Szczegóły" aby zobaczyć pełną zawartość swojej notatki! 
- Kliknij serduszko, aby oznaczyć notatkę jako ulubioną.
- Użyj filtrów i wyszukiwarki, aby szybko znaleźć interesujące notatki.

---

## Kontakt

Jesli masz pytania, sugestie, skargi, lub zażalenia, to jest mi bardzo przykro i możesz się ze mną skontaktować na discordzie albo w osobie!

---
