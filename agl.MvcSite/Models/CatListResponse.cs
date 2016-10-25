using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGL.MvcSite.Models
{
    public class CatListResponse
    {
        public List<string> MaleOwnerCats { get; set; }

        public List<string> FemaleOwnerCats{ get; set; }
    }
}