using System;
namespace targil_2
{
    class guestRequest
    {
        public DateTime EntryDate;
        public DateTime RelaeseDate;
        public bool IsApproved = false;
        public override string ToString()
        {
            if (IsApproved)
                return " the request from: " + EntryDate.ToString() + " until: " + RelaeseDate.ToString() + " has approved! ";
            else
                return " the request from: " + EntryDate.ToString() + " until: " + RelaeseDate.ToString() + " has rejected! ";
        }
    }
}
