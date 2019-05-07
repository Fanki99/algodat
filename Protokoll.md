# Protokoll UE 1

**Gruppenmitglieder:** Thomas Macek, Thomas Frankhauser  
**Programmiersprache:** C#

## Hashtable

Unsere Hashtable haben wir als Klasse definiert und übergeben den key und ein Objekt mit den Daten die wir einfügen wollen.

### Tabellengröße

Um Clusterbildung zu vermeiden haben wir die Primzahl 1499 als unsere Tabellengröße festgelegt. Bei 1000 Einträgen ergibt das einen Füllgrad von 66,7%. Mit `1/(1-0,667)` erhalten wir die durschnittliche anzahl von Zugriffen: `3`. 

### Hashfunktion

In unseren `hash.cs` file verwalten wir alle unsere Funktionen zur Hashtable. Um einen neuen Eintrag in diese einzufügen wird die `insert()` Funktion verwendet. Mithilfe der Funktion `hash()` wird dann das Kürzel gehasht, wir haben uns hierfür an die Vorlesungsfolien orientiert. Jeder Buchstabe des Kürzels wird verwendet um zusammen mit a & h einen gesamten Hashwert h am Ende herauszubekommen. Wir rechnen `mod (maxSize-1)` deshalb weil wir für unsere Tabellengröße 1500 gewählt haben, -1 ergibt 1499 und ist die näheste Primzahl. 

### Einfügen der Daten mit Kollisionsbehandlung (quadratic Probing)

Zu allererst überprüfen wir mit unserer `checkOpenSpace()` ob die Tabelle voll ist, sollte kein Platz mehr vorhanden sein geben wir über die Konsole die Meldung `table is at full capacity!` aus.  
Darauf folgt die eigentliche Aufgabe der Funktion wir überprüfen ob der Platz der Table mit unserern errechneten Hashwert `==null ` ist, sollte das der Fall sein ist der Platz noch frei und die Daten werden eingefügt.  
Sollte der Platz belegt sein verwenden wir quadratisches Sondieren um eine freie Stelle in der hashtable zu finden. Wir inkrementieren einen wert `j` quadrieren diesen, addieren unseren hashwert und nehmen die Summe `mod maxSize`. Das machen wir so oft, bis wir einen freien Platz gefunden haben. Anschaulich in diesen kurzen Codesnippet:  
```
while(table[hash] != null || table[hash].Abbreviation!=null)
    {
        j++;
        hash = (hash + j * j) % maxSize;
    }
    table[hash] = stock;
    return;
 ```
 

### Suchen von Daten

Mit unserer `retrieve()` Funktion, können wir nach Datensätzen mir den Aktienkürzel suchen. Hier wird die Eingabe gehasht und überprüft ob der eintrag vorhanden ist ist also nicht `==null` entspricht, ist dies der Fall kommt auch hier die Selbe Methode des quadratischen Sondierens zum einsatz, wie bei unserer `insert()` Funktion, bis der Eintrag gefunden wird.

### Löschen von Daten

Unsere `remove()` Funktion überprüft zuerst ob der Eintrag den wir Löschen wollen vorhanden ist. Ist dies der Fall wird diser geflagged, inderm das Kürzel auf `null` gesetzt wird. Somit ist es für unsere Funktionen unsichtbar und freigegen zum Überschreiben.