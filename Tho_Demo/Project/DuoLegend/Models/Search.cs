using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class Search
    {
        private string _lane;
        private string _rank;
        private string _purpose;
        private string _server;

        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }


        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public string Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }

    }
}
