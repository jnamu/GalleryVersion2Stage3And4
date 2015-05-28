using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

//namespace Selfhost.DTO
namespace Gallery3SelfHost.DTO
{
    [DataContract]
    public class clsArtist
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Speciality { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public ICollection<clsWork> Works { get; set; }
        public Artist MapToEntity()
        {
            return new Artist() { Name = this.Name, Phone = this.Phone, Speciality = this.Speciality };
        }
    }

    [DataContract]
    [KnownType(typeof(clsPainting))]
    [KnownType(typeof(clsPhotograph))]
    [KnownType(typeof(clsSculpture))]
    public abstract partial class clsWork
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
        //public DateTime Date { get; set; }
        [DataMember]
        public decimal Value { get; set; }
        [DataMember]
        public string ArtistName { get; set; }
        public abstract Work MapToEntity();
    }

    [DataContract]
    public class clsPainting : clsWork
        //: Work
    {
        [DataMember]
        public Nullable<float> Width { get; set; }
        [DataMember]
        public Nullable<float> Height { get; set; }
        [DataMember]
        public string Type { get; set; }
        public override Work MapToEntity()
        {
            return new Painting() { Name = this.Name, Date = this.Date, Value = this.Value, ArtistName = this.ArtistName, Width = this.Width, Height = this.Height,
                Type = this.Type};
        }
    }

    [DataContract]
    public class clsPhotograph  : clsWork
        //: Work
    {
        [DataMember]
        public Nullable<float> Width { get; set; }
        [DataMember]
        public Nullable<float> Height { get; set; }
        [DataMember]
        public string Type { get; set; }
        public override Work MapToEntity()
        {
            return new Photograph() { Name = this.Name, Date = this.Date, Value = this.Value, ArtistName = this.ArtistName, Width = this.Width, Height = this.Height,
                Type = this.Type};
        }
    }

    [DataContract]
    public class clsSculpture : clsWork
        //: Work
    {
        [DataMember]
        public Nullable<float> Weight { get; set; }
        [DataMember]
        public string Material { get; set; }
        public override Work MapToEntity()
        {
            return new Sculpture() { Name = this.Name, Date = this.Date, Value = this.Value, ArtistName = this.ArtistName, Weight = this.Weight, 
                Material = this.Material};
        }
    }
}
