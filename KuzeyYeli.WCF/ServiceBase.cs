using KuzeyYeli.DTO;
using KuzeyYeli.Entity;
using KuzeyYeli.Extensions;
using KuzeyYeli.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KuzeyYeli.WCF
{
    public class ServiceBase< Rep, Entity, DTO> :IService<DTO>  
        where DTO : class
        where Rep: RepositoryBase <Entity>
        where Entity:class
    {
        private Rep repository;

        public Rep Repository
        {
            get {
                repository = repository ?? Activator.CreateInstance<Rep>();
                return repository;
            }
            set { repository = value; }
        }

        public bool Ekle(DTO entity)
        {
            return Repository.Ekle(entity.Changer<Entity>());
        }

        public bool Guncelle(DTO entity)
        {
            return Repository.Guncelle(entity.Changer<Entity>());
        }

        public List<DTO> Listele()
        {
            return Repository.Listele().Select(x => x.Changer<DTO>()).ToList();
        }

        public bool Sil(DTO entity)
        {
            return Repository.Sil(entity.Changer<Entity>());
        }
    }
}