using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Gallery3SelfHost.DTO;

namespace Gallery3SelfHost
{
    [ServiceContract]
    interface IService1
    {  
        [OperationContract]
        List<string> GetArtistNames();

        [OperationContract]
        clsArtist GetArtist(string prArtistName);

        [OperationContract]
        int UpdateArtist(clsArtist prArtist);

        [OperationContract]
        int InsertArtist(clsArtist prArtist);

        [OperationContract]
        int DeleteArtist(clsArtist prArtist);

        [OperationContract]
        int UpdateWork(clsWork prWork);

        [OperationContract]
        int InsertWork(clsWork prWork);

        [OperationContract]
        int DeleteWork(clsWork prWork);

        //[OperationContract]
        //void ShowInnerException(Exception ex);
    }
}
