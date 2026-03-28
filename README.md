System wypożyczalni sprzętu (C#)

Projekt przedstawia aplikację konsolową napisaną w języku C#, której celem jest obsługa uczelnianej wypożyczalni sprzętu. System umożliwia zarządzanie użytkownikami, sprzętem oraz procesem wypożyczeń.

<b>Aplikacja pozwala na:</b>

<ul>
  <li>dodawanie użytkowników (Student, Employee)</li>
  <li>dodawanie sprzętu (Laptop, Projektor, Camera)</li>
  <li>wypożyczanie i zwracanie sprzętu</li>
  <li>kontrolę dostępności sprzętu</li>
  <li>naliczanie kar za opóźnienia</li>
  <li>generowanie raportów</li>
  <li><s>zapis i odczyt danych w formacie JSON</s></li>
</ul>

<b>Struktura projektu</b>
<ul>
    <li>User (klasa abstrakcyjna)</li>
    <li>Student, Employee</li>
    <li>Hardware (klasa bazowa)</li>
    <li>Laptop, Projektor, Camera</li>
    <li>Borrowing</li>
</ul>
<b>Logika programu </b>
<ul>
    <li>RentalService</li>
</ul>

<b>Klasa pozwalająca na uruchomienie programu znajduję się w katalogu: </br></b>
    APBD -> Zadani2 -> Program.cs</b>