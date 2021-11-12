using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL.Model
{
    public class VeChuyenBayModel
    {
        long Id;
        Double DonGia;
        long ChuyenBayId;
        long HangVeId;

        public long id { get => Id; set => Id = value; }
        public Double donGia { get => DonGia; set => DonGia = value; }
        public long chuyenBayID { get => ChuyenBayId; set => ChuyenBayId = value; }
        public long hangVeID { get => HangVeId; set => HangVeId = value; }
    }
}
