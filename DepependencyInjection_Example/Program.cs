using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepependencyInjection_Example
{

    #region Constructor Injection

    //class CustomerBusinessLogic
    //{
    //    ICustomerDataAccess _dataAccess;

    //    public CustomerBusinessLogic(ICustomerDataAccess customerDataAccess)
    //    {
    //        _dataAccess = customerDataAccess;
    //    }

    //    public CustomerBusinessLogic()
    //    {
    //        _dataAccess = new CustomerDataAccess();
    //    }

    //    public string ProcessCustomerData(int id)
    //    {
    //        return _dataAccess.GetCustomerName(id);
    //    }
    //}

    //interface ICustomerDataAccess
    //{
    //    string GetCustomerName(int id);
    //}

    //class CustomerDataAccess : ICustomerDataAccess
    //{
    //    public CustomerDataAccess()
    //    {

    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        // get the customer name from db
    //        //  in real application
    //        return "Dummy Customer Name";
    //    }
    //}

    //class CustomerService
    //{
    //    CustomerBusinessLogic _customerBL;

    //    public CustomerService()
    //    {
    //        _customerBL = new CustomerBusinessLogic(new CustomerDataAccess());
    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        return _customerBL.ProcessCustomerData(id);
    //    }
    //}

    #endregion

    #region Property Injection

    //class CustomerBusinessLogic
    //{
    //    public CustomerBusinessLogic()
    //    {

    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        return DataAccess.GetCustomerName(id);
    //    }

    //    public ICustomerDataAccess DataAccess { get; set; }
    //}

    //interface ICustomerDataAccess
    //{
    //    string GetCustomerName(int id);
    //}

    //class CustomerDataAccess : ICustomerDataAccess
    //{
    //    public CustomerDataAccess()
    //    {

    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        // get the customer name from db
    //        //  in real application
    //        return "Dummy Customer Name";
    //    }
    //}

    //class CustomerService
    //{
    //    CustomerBusinessLogic _customerBL;

    //    public CustomerService()
    //    {
    //        _customerBL = new CustomerBusinessLogic();
    //        _customerBL.DataAccess = new CustomerDataAccess();
    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        return _customerBL.GetCustomerName(id);
    //    }
    //}

    #endregion

    #region Method Injection

    //class CustomerDataAccess : ICustomerDataAccess
    //{
    //    public CustomerDataAccess()
    //    {

    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        // get the customer name from db
    //        //  in real application
    //        return "Dummy Customer Name";
    //    }
    //}

    //interface IDataAccessDependency
    //{
    //    void SetDependency(ICustomerDataAccess customerDataAccess);
    //}

    //interface ICustomerDataAccess
    //{
    //    string GetCustomerName(int id);
    //}

    //class CustomerBusinessLogic : IDataAccessDependency
    //{
    //    ICustomerDataAccess _dataAccess;

    //    public CustomerBusinessLogic()
    //    {

    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        return _dataAccess.GetCustomerName(id);
    //    }

    //    public void SetDependency(ICustomerDataAccess customerDataAccess)
    //    {
    //        _dataAccess = customerDataAccess;
    //    }
    //}

    //class CustomerService
    //{
    //    CustomerBusinessLogic _customerBL;

    //    public CustomerService()
    //    {
    //        _customerBL = new CustomerBusinessLogic();
    //        ((IDataAccessDependency)_customerBL).SetDependency(new CustomerDataAccess());
    //    }

    //    public string GetCustomerName(int id)
    //    {
    //        return _customerBL.GetCustomerName(id);
    //    }
    //}

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
