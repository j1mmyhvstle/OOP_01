using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_nhom
{
    public class Login : ISerializable
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Login() { }

        // Constructor sử dụng cho deserialization
        protected Login(SerializationInfo info, StreamingContext context)
        {
            // Đọc các giá trị từ SerializationInfo và gán vào các thuộc tính
            Username = info.GetString("Username");
            Password = info.GetString("Password");
        }

        // Phương thức này được triển khai từ ISerializable, sử dụng để serialize các thuộc tính của đối tượng
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Ghi các giá trị của các thuộc tính vào SerializationInfo
            info.AddValue("Username", Username);
            info.AddValue("Password", Password);
        }
        public override string ToString()
        {
            return $"Username : {Username}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Login other = (Login)obj;
            return Username == other.Username;
        }
    }
    public class Login_List : ISerializable
    {
        private List<Login> Logins = new List<Login>();
        public List<Login> logins { get { return Logins; } set { Logins = value; } }
        public Login_List() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("logins", logins);
        }
        public Login_List(SerializationInfo info, StreamingContext context)
        {
            logins = (List<Login>)info.GetValue("logins", typeof(List<Login>));
        }
        public void Add(Login item)
        {
            logins.Add(item);
        }
    }
}
