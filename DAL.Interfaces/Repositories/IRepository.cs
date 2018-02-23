using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All();
        Task<IEnumerable<TEntity>> AllAsync();
        // Async lubab protsessi juurde tagasi pöörduda kui see valmis on, ehk ei oota taski taga kinni.
        // Kasutatakse mahukate päringute puhul.
        TEntity Find(params object[] id);
        Task<TEntity> FindAsync(params object[] id);
        // find(1) Find(1,2,3,4) --- Piiramatu arv param, aga see peab olema list

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);
        void Remove(params object[] id);
    }
}
