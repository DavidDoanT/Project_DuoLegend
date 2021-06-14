using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class boxChatDetail
    {
        private string _content;
        private int _sendFrom;

        public int SendFrom
        {
            get { return _sendFrom; }
            set { _sendFrom = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

    }
}
