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
<<<<<<< HEAD
        book,
        disable
=======
        book
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    }

    class Seats
    {
        private int id;
        private stateSeat state;
        private int idArea;
        private DateTime bookingTime;
        private string stateColor;
        private string nameSeat;
<<<<<<< HEAD
     
=======
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
        public Seats()
        {

        }
        public int Id { get => id; set => id = value; }
        public stateSeat State { get => state; set => state = value; }
        public int IdArea { get => idArea; set => idArea = value; }
        public DateTime BookingTime { get => bookingTime; set => bookingTime = value; }
        public string StateColor { get => stateColor; set => stateColor = value; }
        public string NameSeat { get => nameSeat; set => nameSeat = value; }
<<<<<<< HEAD
      
=======
>>>>>>> f5d3beba0a6f59be34b34444f14010fb33ffb151
    }
}
