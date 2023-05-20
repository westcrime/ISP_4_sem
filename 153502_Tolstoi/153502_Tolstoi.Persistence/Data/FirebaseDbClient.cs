using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Tolstoi.Domain.Entities;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace _153502_Tolstoi.Persistence.Data
{
    public class FirebaseDbClient
    {
        private IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "oTxM61FEplhbia22CvAmu4LeAY489cAHRLgtWTWJ",
            BasePath = "https://lab5-d9493-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public IFirebaseClient Client;

        public FirebaseDbClient()
        {
            try
            {
                Client = new FirebaseClient(ifc);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
