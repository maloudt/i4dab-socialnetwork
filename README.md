# i4dab-socialnetwork

NoSqlGroup19
* Marie-Louise Troelsen (201510409)
* Thomas Vittrup Bærentsen (201606351)
* Lea Mo Føste Andersen (201703769)
* Sahand Matten (201506510)

* Et ER diagram der beskriver databasen er vedlagt projektet og en beskrivelse findes også nedenfor
* Programmet opretter selv en database med navnet'SocialNetworkDb', men ønskes dette ændret findes denne definition i Services/PostService og Services/UserService (skal ændres begge steder)
* Programmet fungerer som et consol-program

## Database beskrivelse:
Der er to collections: User og Post. 

User består af følgende key/value pairs:
* Id
* Name
* Age
* Gender
* Circles (består af en liste af Cirle objekter, som hver indeholder et Circle Number og en liste af bruger-id'er)
* Blocked Users (en liste af bruger-id'er)

Post består af følgende key/value pairs:
* Id
* Post Author
* Post Type
* Creation Time
* Is Public (bool - om posten er public eller ej)
* Circles (en liste af de Circles som Post'en skal være synlig for)')
* Comments ( består af en liste af Comment objekter, som hver indeholder Comment Author, Comment Text og Creation Time)

Der er altså embedded Circle dokumenter i User og embedded Comment dokumenter i Post.


## For at køre pogrammet:
* Tryk på 'Start without debugging' e.l. (Ctrl-F5 i VS)
* Du præsenteres derefter med et consol-vindue, som du kan navigere i
* Der kommer propmpts på hver ny skærm, så du aldrig burde være i tvivl om, hvad den næste handling kan være
* Tryk Ctrl-C eller Ctrl-F4 for at stoppe programmet


## Programmet har følgende mangler:
* Der er ikke taget hensyn til transactions - kun én person kan ændre i systemet på én gang. Dette er selvfølgelig et problem, hvis det skal være et brugbart system i virkeligheden
* Sharding: Hvis systemet skulle bruges af mange brugere og der dermed vil ligge en meget stor mængde data i systemet, vil det være nødvendigt at sharde database for at gøre søgetider mm. kortere og realistiske. ingen gider bruge et system, som er lnagsomt.