using WebProgramlama.EfCore;
using WebProgramlama.Models;

namespace WebProgramlama.DBHelpers
{
    public class CustomerHelper
    {
        private EF_DataContext _context;
        public CustomerHelper(EF_DataContext context)
        {
            _context = context;
        }
        public List<CustomerModel> GetAll()
        {
            List<CustomerModel> response = new List<CustomerModel>();
            var dataList = _context.Customer.ToList();
            dataList.ForEach(row => response.Add(new CustomerModel()
            {
                CustomerId = row.CustomerId,
                CustomerUserName  = row.Customerusername,
                Email = row.Email,
                    Password = row.Password
            }));
            return response;
        }

        public CustomerModel getCustomerById(int id) 
        {
            var row = _context.Customer.Where(c => c.CustomerId == id).FirstOrDefault();
            return new CustomerModel()
            {
                CustomerId = row.CustomerId,
                CustomerUserName = row.Customerusername,
                Email = row.Email,
                Password = row.Email
            };
        }

        public void makeRecord(CustomerModel customerModel)
        {
            Customer customer = new Customer();
            Customer dbTableElement = _context.Customer.Where(c => c.CustomerId ==  customerModel.CustomerId).FirstOrDefault();
            //PUT
            if (dbTableElement != null)
            {
                dbTableElement .CustomerId = customerModel.CustomerId;
                dbTableElement.Customerusername = customerModel.CustomerUserName;
                dbTableElement.Email = customerModel.Email;
                dbTableElement.Password = customerModel.Password;
            }
            else
            {
                customer.CustomerId = customerModel.CustomerId;
                customer.Customerusername = customerModel.CustomerUserName;
                customer.Email = customerModel.Email;
                customer.Password = customerModel.Password;
                _context.Customer.Add(customer);
            }
            _context.SaveChanges();
        }

        public Boolean DeleteRecord(int rowId)
        {
            var record = _context.Customer.Where(c => c.CustomerId == rowId).FirstOrDefault();
            if (record != null)
            {
                _context.Customer.Remove(record);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
