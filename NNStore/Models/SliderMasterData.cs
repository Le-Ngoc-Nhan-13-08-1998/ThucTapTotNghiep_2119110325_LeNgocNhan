using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNStore.Context
{
    public partial class SliderMasterData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> Status { get; set; }
    }
}