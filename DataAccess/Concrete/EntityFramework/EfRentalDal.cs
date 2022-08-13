using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                              on u.UserId equals c.UserId
                             join r in context.Rentals
                             on c.CustomerId equals r.CustomerId
                             select new RentalDetailDto
                             {
                                 UserId = u.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }



        }
    }
}
