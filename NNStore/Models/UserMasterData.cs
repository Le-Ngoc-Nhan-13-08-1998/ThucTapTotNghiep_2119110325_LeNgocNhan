using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNStore.Context
{
    public partial class UserMasterData
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Img { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Phone { get; set; }
        public string Address { get; set; }
        public string Roles { get; set; }
        public int CountError { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<int> Stutus { get; set; }
    }
}