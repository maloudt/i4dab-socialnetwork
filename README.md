# i4dab-socialnetwork

NoSqlGroup19
* Marie-Louise Troelsen (201510409)
* Thomas Vittrup B�rentsen (201606351)
* Lea Mo F�ste Andersen (201703769)
* Sahand Matten (201506510)

* Et ER diagram der beskriver databasen er vedlagt projektet og en beskrivelse findes ogs� nedenfor
* Programmet opretter selv en database med navnet'SocialNetworkDb', men �nskes dette �ndret findes denne definition i Services/PostService og Services/UserService (skal �ndres begge steder)
* Programmet fungerer som et consol-program

## Database beskrivelse:
Der er to collections: User og Post. 

User best�r af f�lgende key/value pairs:
* Id
* Name
* Age
* Gender
* Circles (best�r af en liste af Cirle objekter, som hver indeholder et Circle Number og en liste af bruger-id'er)
* Blocked Users (en liste af bruger-id'er)

Post best�r af f�lgende key/value pairs:
* Id
* Post Author
* Post Type
* Creation Time
* Is Public (bool - om posten er public eller ej)
* Circles (en liste af de Circles som Post'en skal v�re synlig for)')
* Comments ( best�r af en liste af Comment objekter, som hver indeholder Comment Author, Comment Text og Creation Time)

Der er alts� embedded Circle dokumenter i User og embedded Comment dokumenter i Post.


## For at k�re pogrammet:
* Tryk p� 'Start without debugging' e.l. (Ctrl-F5 i VS)
* Du pr�senteres derefter med et consol-vindue, som du kan navigere i
* Der kommer propmpts p� hver ny sk�rm, s� du aldrig burde v�re i tvivl om, hvad den n�ste handling kan v�re
* Tryk Ctrl-C eller Ctrl-F4 for at stoppe programmet


## Programmet har f�lgende mangler:
* Der er ikke taget hensyn til transactions - kun �n person kan �ndre i systemet p� �n gang. Dette er selvf�lgelig et problem, hvis det skal v�re et brugbart system i virkeligheden
* Sharding: Hvis systemet skulle bruges af mange brugere og der dermed vil ligge en meget stor m�ngde data i systemet, vil det v�re n�dvendigt at sharde database for at g�re s�getider mm. kortere og realistiske. ingen gider bruge et system, som er lnagsomt.