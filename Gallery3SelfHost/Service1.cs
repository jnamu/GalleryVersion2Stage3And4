using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery3SelfHost.DTO;

namespace Gallery3SelfHost
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    class Service1 : IService1
    {
        public List<string> GetArtistNames()
        {
            using (Gallery_DataEntities lcContext = new Gallery_DataEntities())
                return lcContext.Artists
                    .Select(lcArtist => lcArtist.Name)
                    .ToList();
        }

        public clsArtist GetArtist(string prArtistName)
        {
            using (Gallery_DataEntities lcContext = new Gallery_DataEntities())
            {
                Artist lcArtist = lcContext.Artists
                .Include("Works")
                .Where(Artist => Artist.Name == prArtistName)
                .FirstOrDefault();
                clsArtist lcArtistDTO = new clsArtist() { Name = lcArtist.Name, Speciality = lcArtist.Speciality, Phone = lcArtist.Phone, Works = new List<clsWork>() };
                foreach (Work item in lcArtist.Works)
                    lcArtistDTO.Works.Add(item.MapToDTO());
                return lcArtistDTO;
            }
        }

        private int process<TEntity>(TEntity prItem, System.Data.Entity.EntityState prState) where TEntity : class
        {
            using (Gallery_DataEntities lcContext = new Gallery_DataEntities())
            {
                lcContext.Entry(prItem).State = prState;
                int lcCount = lcContext.SaveChanges();
                return lcCount;
            }
        }
        public int UpdateArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Modified);
        }

        public int InsertArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Added);
        }

        public int DeleteArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Deleted);
        }

        public int UpdateWork(clsWork prWork)
        {
            return process(prWork.MapToEntity(), System.Data.Entity.EntityState.Modified);
        }

        public int InsertWork(clsWork prWork)
        {
            return process(prWork.MapToEntity(), System.Data.Entity.EntityState.Added);
        }

        public int DeleteWork(clsWork prWork)
        {
            return process(prWork.MapToEntity(), System.Data.Entity.EntityState.Deleted);
        }

    //    public static void ShowInnerException(Exception ex)
    //    {
    //        ex.ToString();
    //    }
    }


}
