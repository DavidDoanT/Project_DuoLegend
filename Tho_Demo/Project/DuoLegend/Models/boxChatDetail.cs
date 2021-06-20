using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class BoxChatDetail
    {
        private int _boxChatId;
        private string _content;
        private DateTime _timeSend;
        private int _sendFrom;
        private bool _isSeen;

        public bool IsSeen
        {
            get { return _isSeen; }
            set { _isSeen = value; }
        }

        public int SendFrom
        {
            get { return _sendFrom; }
            set { _sendFrom = value; }
        }

        public DateTime TimeSend
        {
            get { return _timeSend; }
            set { _timeSend = value; }
        }


        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public int BoxChatId
        {
            get { return _boxChatId; }
            set { _boxChatId = value; }
        }
    }
}
