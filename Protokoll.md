# Protokoll UE 2

**Gruppenmitglieder:** Thomas Macek, Thomas Fankhauser  
**Programmiersprache:** C#
**rekursive Funktionen:** addR und parse

|Funktion |Best Case |Worst Case|Average Case|
|----------|---------:|---------:|-----------:|
|addR| O(1) | O(N) | O(log N)|
|parseR| O(N) | O(N) | O(N)|

## addR()
<!--  -->
Unsere Funktion Add ruft die rekursive Funktion AddR auf. Als aller erstes überprüfen wir ob der Baum noch leer ist und erstellen daraufhin den ersten Node. Danach überprüfen wir ob es den Key schon gibt, sollte dies der Fall sein, wird er verworfen, so verhindern wir doppelte Inputs.
Jetz sehen wir uns den linken Baum an sollte der kleiner sein als unser Key, rufen wir die Funktion nochmal auf.
Beim rechten Baum schaune wir ob der key größer ist als der key, sollte das der Fall sein, rufen wir die Funktion nochmal auf. Bis eine Stelle die null ist gefunden wird, dann wir der neue Node erzeugt.


## parseR()

In dieser Funktion parsen wir durch unseren Tree und checken ob es ein AVL Tree ist und die min und max werte  zu erhalten. Diese Funktion ruft sich so lange selbst wieder auf, bis sie ans Ende des Baums stöhst wo N=null ist.
