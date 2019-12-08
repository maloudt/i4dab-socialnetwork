# i4dab-socialnetwork

* Et ER diagram der beskriver databasen er vedlagt projektet
* Programmet opretter selv en database med navnet'SocialNetworkDb', men ønskes dette ændret findes denne definition i Services/PostService og Services/UserService (skal ændres begge steder)
* Programmet fungerer som et consol-program

For at køre pogrammet:
* Kør programmet (F5 i VS)
* Du præsenteres derefter med et consol-vindue, som du kan navigere i
* Der kommer propmpts på hver ny skærm, så man aldrig burde være i tvivl om, hvad den næste handling kan være
* Tryk Ctrl-C for at stoppe programmet
* Programmet er begrænset i funktionalitet, men de 3 hovedfunktioner er: 
  1) View feed (log ind som en bruger og se brugerens feed)
  2) View wall (log ind som en bruger og se en anden brugers væg)
  3) Create new post (log ind som en bruger og lav en ny post)

Programmet har følgende mangler:
* Koden til at lave en kommentar er lavet, men den er ikke integreret i resten af programmet. 
  Der er ingen måde at vælge hvilken post kommentaren skal lægges på.
* Der er ikke implementeret funktionalitet til at blokere brugere (selv om man kan have brugere i sin 'blocked users' liste)
* Der er ingen public posts, kun posts der er i cirkler
* Der er ingen fejlhåndtering - skrives den forkerte kommando eller forkert input type etc. lukker programmet
* Der er ikke taget hensyn til transactions - kun én person kan ændre i systemet på én gang