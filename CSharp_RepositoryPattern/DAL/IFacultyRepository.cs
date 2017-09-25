using CSharp_RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repository.DAL
{
    public interface IFacultyRepository : IDisposable
    {       
        Task<List<Faculty>> GetFaculty();
        Task<Faculty> GetFacultyByID(int? facultyId);
        void InsertFaculty(Faculty faculty);
        void DeleteFaculty(int facultyID);
        void UpdateFaculty(Faculty faculty);
        Task<int> Save();
    }    
}