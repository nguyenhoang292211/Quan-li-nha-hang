using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public enum stateSeat
    {
        emty,
        use,
        book,
        disable
    }

    class Seats
    {
        private int id;
        private stateSeat state;
        private int idArea;
        private DateTime bookingTime;
        private string stateColor;
        private string nameSeat;

        public Seats()
        {

        }
        public int Id { get => id; set => id = value; }
        public stateSeat State { get => state; set => state = value; }
        public int IdArea { get => idArea; set => idArea = value; }
        public DateTime BookingTime { get => bookingTime; set => bookingTime = value; }
        public string StateColor { get => stateColor; set => stateColor = value; }
        public string NameSeat { get => nameSeat; set => nameSeat = value; }

    }
}
