using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ALGODAT
{
	class Stock{
    	public string Name { get; set; }
    	public string Abbreviation { get; set; }
    	public string Wkn { get; set; }
    	public List<StockEntry> StockEntries { get; set; }

		public List<StockEntry> sortByDateAsc(List<StockEntry> unsorted){
			return (unsorted.OrderBy(q => q.Date)).ToList();
		}    	

    	public String latestEntry(){
    		if(StockEntries != null){
    			StockEntry latest = (sortByDateAsc(StockEntries)).Last();
    			return "Der neuste Kurseintrag von " + Name + ":\n" +
    					"Datum: " + latest.Date + "\n" + 
    					"Open: " + latest.Open + "\n" +
    					"High: " + latest.High + "\n" +
    					"Low: " + latest.Low + "\n" +
    					"Close: " + latest.Close + "\n" +
    					"Volume: " + latest.Volume + "\n" +
    					"AdjClose: " + latest.AdjClose + "\n";
    		}
    		else{
    			return Abbreviation+ " wurde gefunden, allerdings sind noch keine Einträge vorhanden.";
    		}


    	}
	}
}