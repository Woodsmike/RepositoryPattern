using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharp_RepositoryPattern.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Repository.DAL
{
    public class FacultyRepository : IFacultyRepository, IDisposable
    {
        // Part 1 - Context
        private CSharp_RepositoryPatternContext _context;

        // Constructor
        public FacultyRepository(CSharp_RepositoryPatternContext context)
        {
            this._context = context;
        }

        // Part 2 - CRUD
        public void InsertFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
        }

        public Task<Faculty> GetFacultyByID(int? facultyId)
        {
            return _context.Faculties.FindAsync(facultyId);
        }

        public Task<List<Faculty>> GetFaculties()
        {
            return _context.Faculties.ToListAsync();
        }

        public void UpdateFaculty(Faculty faculty)
        {
            _context.Entry(faculty).State = EntityState.Modified;
        }

        public void DeleteFaculty(int facultyID)
        {
            Faculty faculty = _context.Faculties.Find(facultyID);
            _context.Faculties.Remove(faculty);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        // Part 3 - Clean up
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            // Prevent the GC from calling Object.Finalize on an 
            // object that does not require it
            GC.SuppressFinalize(this);
        }

        public Task<List<Faculty>> GetFaculty()
        {
            throw new NotImplementedException();
        }
    }
}