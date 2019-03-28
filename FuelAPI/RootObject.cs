using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelAPI
{
    public class Request
    {
        public string command { get; set; }
        public string series_id { get; set; }
    }

    public class Series
    {
        public string series_id { get; set; }
        public string name { get; set; }
        public string units { get; set; }
        public string f { get; set; }
        public string unitsshort { get; set; }
        public string description { get; set; }
        public string copyright { get; set; }
        public string source { get; set; }
        public string iso3166 { get; set; }
        public string geography { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public DateTime updated { get; set; }
        public List<List<object>> data { get; set; }
    }

    public class DataObject
    {
        public string date { get; set; }
        public double price { get; set; }
    }

    public class RootObject
    {
        public Request request { get; set; }
        public List<Series> series { get; set; }
    }
}
