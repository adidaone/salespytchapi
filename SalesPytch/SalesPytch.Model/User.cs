using System;
using System.Runtime.Serialization;

namespace SalesPytch.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public Role Role { get; set; }
        public string Password { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public bool IsProfileComplete { get; set; }
        public bool IsActive { get; set; }       
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public User()
        {
            Role = new Role();
        }
    }
}
