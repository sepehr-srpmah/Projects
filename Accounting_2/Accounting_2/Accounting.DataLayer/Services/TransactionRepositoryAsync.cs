using Accounting.DataLayer.Contexts;
using Accounting.DataLayer.Repositories;
using Accounting.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public partial class TransactionRepository : ITransactionRepository
    {
        public async Task UpdateAsync(Transaction entity)
        {
            try
            {
                await Task.Run(delegate ()
                {
                    var local = _db.Set<Transaction>()
                        .Local
                        .FirstOrDefault(t => t.ID == entity.ID);

                    if (local != null)
                    {
                        _db.Entry(local).State = EntityState.Detached;
                    }

                    _db.Entry(entity).State = EntityState.Modified;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Transaction> GetByIdAsync(object id)
        {
            return await _db.Transaction.FindAsync((int)id);
        }

        public async Task<IEnumerable<Transaction>> GetAsync(Expression<Func<Transaction, bool>> where = null)
        {
            IQueryable<Transaction> query = _db.Transaction;

            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.ToListAsync();
        }


        public async Task DeleteAsync(Transaction entity)
        {
            try
            {
                await Task.Run(delegate ()
                {
                    _db.Entry(entity).State = EntityState.Deleted;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAsync(object id)
        {

            var transaction = await GetByIdAsync(id);
            await DeleteAsync(transaction);
        }


        public async Task AddAsync(Transaction entity)
        {
            try
            {
                await Task.Run(delegate ()
                {
                    _db.Entry(entity).State = EntityState.Added;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TransactionReportViewModel>> GetTransactionWithFullNameAsync(Expression<Func<TransactionReportViewModel, bool>> where = null, string userName = "")
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

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypesAsync()
        {
            return await _db.TransactionType.ToListAsync();
        }
    }
}
