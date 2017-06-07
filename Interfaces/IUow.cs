using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUow
    {
        //Terve ports reposid oma interface'ide kaudu:
        //(get) saame ainult tagastada, väljastpoolt salvestada ei saa.
        IPersonRepository People { get; }
        IOwnershipRepository Ownerships { get; }

        //kui oleme 100% kindlad, et kusagile reposse custom funtsionaalsust ei tule,
        //saab teha ka nii: (siis me kõiki vahekihte ei kasuta)
        IRepository<Apartment> Apartments { get; }
        IRepository<House> Houses { get; }

        //kõige tähtsam feature: atomic save
        int SaveChanges();
    }
}
