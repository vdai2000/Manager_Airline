using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_DAL.Model;

namespace DLL_DAL
{
    public class VeChuyenBayDLL_DAL : AbstractDLL_DAL<VeChuyenBayModel>
    {
        public VeChuyenBayDLL_DAL(String url) : base(url)
        { }
    }
}
