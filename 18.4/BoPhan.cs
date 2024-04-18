using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Do_an_nhom
{
    public class BoPhan : ISerializable
    {
        public int MaBP { get; set; }
        public string TenBP { get; set; }
        public int HeSoLuong { get; set; }
        public BoPhan() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MaBP", MaBP);
            info.AddValue("TenBP", TenBP);
            info.AddValue("HeSoLuong", HeSoLuong);
        }
        public BoPhan(SerializationInfo info, StreamingContext context)
        {
            MaBP = info.GetInt32("MaBP");
            TenBP = info.GetString("TenBP");
            HeSoLuong = info.GetInt32("HeSoLuong");
        }
        public override string ToString()
        {
            return $"MaBP: {MaBP} -- TenBP: {TenBP} -- HeSoLuong: {HeSoLuong}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            BoPhan other = (BoPhan)obj;
            return MaBP == other.MaBP;
        }
    }
    public class BoPhan_List : ISerializable
    {
        private List<BoPhan> boPhans = new List<BoPhan>();
        public List<BoPhan> BoPhans { get { return boPhans; } set { boPhans = value; } }
        public BoPhan_List() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context )
        {
            info.AddValue("BoPhans", BoPhans);
        }
        public BoPhan_List(SerializationInfo info, StreamingContext context)
        {
            BoPhans = (List<BoPhan>)info.GetValue("BoPhans", typeof(List<BoPhan>));
        }
        public void Add(BoPhan item)
        {
            BoPhans.Add(item);
        }
    }
}
