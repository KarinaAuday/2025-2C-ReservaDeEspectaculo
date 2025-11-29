using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Rol : IdentityRole<int>
    {
        //public int Id { get; set; }
        
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override string NormalizedName
        {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }

        public Rol() : base()
        {

        }

        public Rol(string roleName) : base(roleName)
        {

        }

    }
}
