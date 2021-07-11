using System.Runtime.Serialization;

namespace DuoLegend
{
    /// <summary>
    /// Model class representing a data point. Aids in chart making
    /// </summary>
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Label for the x axis
        /// </summary>
        /// <value></value>
        [DataMember(Name = "x")]
        public string X {get;set;}

        /// <summary>
        /// Value of y axis
        /// </summary>
        /// <value></value>
        [DataMember(Name = "y")]
        public int Y {get;set;}
    }
}