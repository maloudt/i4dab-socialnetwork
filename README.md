# i4dab-socialnetwork

* Et ER diagram der beskriver databasen er vedlagt projektet
* Programmet opretter selv en database med navnet'SocialNetworkDb', men �nskes dette �ndret findes denne definition i Services/PostService og Services/UserService (skal �ndres begge steder)
* Programmet fungerer som et consol-program

For at k�re pogrammet:
* K�r programmet (F5 i VS)
* Du pr�senteres derefter med et consol-vindue, som du kan navigere i
* Der kommer propmpts p� hver ny sk�rm, s� man aldrig burde v�re i tvivl om, hvad den n�ste handling kan v�re
* Tryk Ctrl-C for at stoppe programmet
* Programmet er begr�nset i funktionalitet, men de 3 hovedfunktioner er: 
  1) View feed (log ind som en bruger og se brugerens feed)
  2) View wall (log ind som en bruger og se en anden brugers v�g)
  3) Create new post (log ind som en bruger og lav en ny post)

Programmet har f�lgende mangler:
* Koden til at lave en kommentar er lavet, men den er ikke integreret i resten af programmet. 
  Der er ingen m�de at v�lge hvilken post kommentaren skal l�gges p�.
* Der er ikke implementeret funktionalitet til at blokere brugere (selv om man kan have brugere i sin 'blocked users' liste)
* Der er ingen public posts, kun posts der er i cirkler
* Der er ingen fejlh�ndtering - skrives den forkerte kommando eller forkert input type etc. lukker programmet
* Der er ikke taget hensyn til transactions - kun �n person kan �ndre i systemet p� �n gang