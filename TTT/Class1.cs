using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT

{
    public enum UserType
    {
        Basic,
        Premium,
        SpecialUser
    }


    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }
        public string password { get; set; }
        public int Age { get; set; }


        public bool IsSeniorCitizen()
        {
            if (Age >= 60)
            {
                return true;
            }
            return false;
        }

        public bool ContainsPolishChars()
        {
            if (this.UserName.Contains("ą") | this.UserName.Contains("ć") | this.UserName.Contains("ś") | this.UserName.Contains("ł")
                | this.UserName.Contains("ó") | this.UserName.Contains("ę") | this.UserName.Contains("ż") | this.UserName.Contains("ź")
                | this.UserName.Contains("ń"))
            {
                return true;
            }
            return false;
        }
        public bool IsPasswordLongEnough()
        {
            if (this.password.Length > 7)
            {
                return true;
            }
            return false;
        }
    }
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Amount { get; set; }
    }

    public class UserOrderService
    {
        public void ApplyDiscount(User user, Order order)
        {
            if (user.UserType == UserType.Premium)
            {
                order.Amount = order.Amount - ((order.Amount * 10) / 100);
            }
            else if (user.UserType == UserType.SpecialUser)
            {
                order.Amount = order.Amount - ((order.Amount * 20) / 100);
            }
            else if (user.UserType == UserType.Basic)
            {
                order.Amount = order.Amount - ((order.Amount * 30) / 100);
            }
        }
    }
}