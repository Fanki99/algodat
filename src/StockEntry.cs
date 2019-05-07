using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ALGODAT
{
	class StockEntry{
		public string Date { get; set; }
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public double Close { get; set; }
		public int Volume { get; set; }
		public double AdjClose { get; set; }
	}
}
