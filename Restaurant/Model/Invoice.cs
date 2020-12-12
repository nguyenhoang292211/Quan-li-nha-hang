using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public   class Invoice
    {
        private int id;
        private DateTime date;
        private string nameCUs;
        private string phone;
        private int idEmp;
        private string nameEmp;
        private string promotion;
        private double promotionValue;
        private double loyalFriend;
        private int totalPrice;
        private List<dish_invoice> dishes;
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string NameCUs { get => nameCUs; set => nameCUs = value; }
        public string Phone { get => phone; set => phone = value; }
        public int IdEmp { get => idEmp; set => idEmp = value; }
        public string NameEmp { get => nameEmp; set => nameEmp = value; }
        public string Promotion { get => promotion; set => promotion = value; }
        public double PromotionValue { get => promotionValue; set => promotionValue = value; }
        public double LoyalFriend { get => loyalFriend; set => loyalFriend = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public List<dish_invoice> Dishes { get => dishes; set => dishes = value; }

        public Invoice(DataRow r)
        {
            this.Id = Convert.ToInt32(r[0]);
            this.Date = Convert.ToDateTime(r[1]);
            this.NameCUs = r[2].ToString();
            this.Phone = r[3].ToString();
            this.IdEmp = Convert.ToInt32(r[4]);
            this.NameEmp = r[5].ToString();
            this.Promotion = r[6].ToString();
            this.PromotionValue =Convert.ToDouble( r[7].ToString());
            this.LoyalFriend = Convert.ToDouble(r[8].ToString());
            this.TotalPrice = Convert.ToInt32(r[9]);
        }

        public  Invoice()
        { 
       
        }
    }

    public class dish_invoice
    {
        private string name;
        private int unitPrice;
        private int quantity;
        private int subTotal;

        public dish_invoice()
        {

        }
        public dish_invoice(DataRow r)
        {
            this.Name = r[0].ToString();
            this.Quantity = Convert.ToInt32(r[2]);
            this.UnitPrice =Convert.ToInt32(r[1]);

        }

        public string Name { get => name; set => name = value; }
        public int UnitPrice 
        {
            get { return unitPrice; }
            set { unitPrice = value; SubTotal = Quantity * unitPrice; }
        }
        public int Quantity { get => quantity; set => quantity = value; }
        public int SubTotal 
        {
            get { return subTotal; }
            set { subTotal = value;  }
        }
    }
}
