using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Data.Enums
{
    public enum OrderStatus
    {
        Created,
        Pending,
        Shipped,
        Delivered,
        Completed,
        Cancelled
    }
}
