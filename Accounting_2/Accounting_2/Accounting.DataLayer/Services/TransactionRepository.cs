using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Contexts;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Data.Entity;
using Accounting.ViewModels.Transaction;

namespace Accounting.DataLayer.Services
{
    public partial class TransactionRepository : ITransactionRepository
    {
        private AccountingDbContext _db;
        public TransactionRepository(AccountingDbContext db)
        {
            _db = db;
        }

        public bool Add(Transaction entity)
        {
            try
            {
                _db.Transaction.Add(entity);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }


        public bool Delete(object id)
        {
            var transaction = GetById((int)id);
            return Delete(transaction);
        }

        public bool Delete(Transaction entity)
        {
            try
            {
                _db.Transaction.Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }


        public IEnumerable<Transaction> Get(Expression<Func<Transaction, bool>> where = null)
        {
            IQueryable<Transaction> query = _db.Transaction;

            if (where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }



        public Transaction GetById(object id)
        {
            return _db.Transaction.Find((int)id);
        }



        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            return _db.TransactionType.ToList();
        }

        public IEnumerable<TransactionReportViewModel> GetTransactionWithFullName(Expression<Func<TransactionReportViewModel, bool>> where = null, string userName = "")
        {
            var result = (from transaction in _db.Transaction
                          join customer in _db.Customer on transaction.Customer_ID equals customer.ID
                          where customer.UserName == userName
                          select new TransactionReportViewModel()
                          {
                              ID = transaction.ID,
                              Amount = transaction.Amount,
                              FullName = customer.FullName,
                              TransactionType = transaction.TransactionType,
                              DateCreated = transaction.DateCreated
                          });

            if (where != null)
            {
                result = result.Where(where);
            }

            return result.ToList();
        }

        public bool Update(Transaction entity)
        {
            try
            {
                var local = _db.Transaction
                    .Local
                    .FirstOrDefault(t => t.ID == entity.ID);

                if (local != null)
                {
                    _db.Entry(local).State = EntityState.Detached;
                }

                _db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }


    }
}
