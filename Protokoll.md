# Protokoll UE 1

**Gruppenmitglieder:** Thomas Macek, Thomas Fankhauser  
**Programmiersprache:** C#

## Hashtable

Unseren Hashtable haben wir als Klasse definiert und übergeben den Key und ein Objekt mit den Daten die wir einfügen wollen.

### Tabellengröße

Um Clusterbildung zu vermeiden haben wir die Primzahl 1499 als unsere Tabellengröße festgelegt. Bei 1000 Einträgen ergibt das einen Füllgrad von 66,7%. Mit `1/(1-0,667)` erhalten wir die durschnittliche Anzahl von Zugriffen: `3`. 

### Hashfunktion

In unseren `hash.cs` File verwalten wir alle unsere Funktionen zum Hashtable. Um einen neuen Eintrag in diesen einzufügen wird die `insert()` Funktion verwendet. Mithilfe der Funktion `hash()` wird dann das Kürzel gehasht. Wir haben uns hierfür an den Vorlesungsfolien orientiert. Jeder Buchstabe des Kürzels wird verwendet um zusammen mit a & h einen gesamten Hashwert h am Ende herauszubekommen. Wir rechnen `mod (maxSize-1)` deshalb weil wir für unsere Tabellengröße 1500 gewählt haben, -1 ergibt 1499 und ist die näheste Primzahl. 

### Einfügen der Daten mit Kollisionsbehandlung (quadratische Sondierung)

Zuerst überprüfen wir mit unserer `checkOpenSpace()` ob die Tabelle voll ist, sollte kein Platz mehr vorhanden sein geben wir über die Konsole die Meldung `Hashtable ist leider voll!` aus. 
Darauf folgt die eigentliche Aufgabe der Funktion - wir überprüfen ob der Platz des Tables mit unserem errechneten Hashwert `==null ` ist, sollte das der Fall sein ist der Platz noch frei und die Daten werden eingefügt.  
Sollte der Platz belegt sein verwenden wir quadratisches Sondierung um eine freie Stelle in dem Hashtable zu finden. Wir inkrementieren einen wert `j`, quadrieren diesen, addieren unseren Hashwert und rechnen die Summe `mod maxSize`. Das machen wir so oft, bis wir einen freien Platz gefunden haben. Anschaulich in diesen kurzen Codesnippet:  
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

Mit unserer `retrieve()` Funktion, können wir nach Datensätzen mit dem Aktienkürzel suchen. Hier wird die Eingabe gehasht und überprüft ob der Eintrag vorhanden ist, also nicht `==null` entspricht, ist dies der Fall kommt auch hier die selbe Methode des quadratischen Sondierens zum Einsatz, wie bei unserer `insert()` Funktion, bis der Eintrag gefunden wird.

### Löschen von Daten

Unsere `remove()` Funktion überprüft zuerst ob der Eintrag den wir Löschen wollen vorhanden ist. Ist dies der Fall wird diser geflagged, inderm das Kürzel auf `null` gesetzt wird. Somit ist es für unsere anderen Funktionen unsichtbar und freigegeben zum Überschreiben.


## Aufwandsabschätzung

### Hashtable

|Verfahren |Best Case |Worst Case|Average Case|
|----------|---------:|---------:|-----------:|
|Lineare Suche| O(1) | O(N) | O(1)|
|Am Ende einfügen| O(1) | O(N) | O(1)|
|Am Ende löschen| O(1) | O(N) | O(1)|

### Linked List

|Verfahren |Best Case |Worst Case|Average Case|
|----------|---------:|---------:|-----------:|
|Lineare Suche| O(1) | O(N) | O(N)|
|Am Ende einfügen| O(N) | O(N) | O(N)|
|Am Ende löschen| O(N) | O(N) | O(N)|

### Array

|Verfahren |Best Case |Worst Case|Average Case|
|----------|---------:|---------:|-----------:|
|Lineare Suche| O(1) | O(N) | O(N/2)|
|Am Ende einfügen| O(1) | O(1) | O(1)|
|Am Ende löschen| O(1) | O(1) | O(1)|


