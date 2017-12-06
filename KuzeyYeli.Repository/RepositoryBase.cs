using KuzeyYeli.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.Repository
{

    public class RepositoryBase<TT> : IRepository<TT> where TT : class
    {
        
        private static NorthwindContext context;

        public static NorthwindContext Context
        {
            get {
                context = context ?? new NorthwindContext  ();
                return context;

            }
            set { context = value; }
        }

        public bool Ekle(TT entity)
        {
            Context.Set<TT>().Add(entity);
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Guncelle(TT entity)
        {
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<TT> Listele()
        {
            return Context.Set<TT>().ToList();
        }

        public bool Sil(TT entity)
        {
            Context.Set<TT>().Remove(entity);
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
