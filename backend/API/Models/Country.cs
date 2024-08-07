using System;
namespace API.Models
{
    public class Country : AbstractModel
    {

        public string Libelle { get; set; }
        public string LibelleAR { get; set; }
        public string LibelleAN { get; set; }
        public string PhoneCode { get; set; }
        public string AvatarsCulture { get; set; }
        public int PhoneLength { get; set; }
        public Guid FlagImage { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Country other = (Country)obj;
            return Id == other.Id &&
                   Libelle == other.Libelle &&
                   LibelleAR == other.LibelleAR &&
                   LibelleAN == other.LibelleAN &&
                   PhoneCode == other.PhoneCode &&
                   AvatarsCulture == other.AvatarsCulture &&
                   PhoneLength == other.PhoneLength &&
                   FlagImage == other.FlagImage;
        }
    }
}

