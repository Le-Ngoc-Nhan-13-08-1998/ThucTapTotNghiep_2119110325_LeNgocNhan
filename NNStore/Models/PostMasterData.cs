using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNStore.Models
{
    public partial class PostMasterData
    {
        public int Id { get; set; }
        public Nullable<int> TopId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Detail { get; set; }
        public string Img { get; set; }
        public string PostType { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public System.DateTime UpdateAt { get; set; }
        public Nullable<int> Status { get; set; }
    }
}