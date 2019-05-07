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
    	public StockEntry[] StockEntries { get; set; }
	}
}