﻿
using System;
namespace dotNet5780_02_9738_2057
{
    class GuestRequest
    {
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public bool IsApproved = false;
        
        public override string ToString()
        {
            if (IsApproved)
                return " The request from: " + EntryDate.ToString() + " until: " + ReleaseDate.ToString() + " has approved! ";
            else
                return " The request from: " + EntryDate.ToString() + " until: " + ReleaseDate.ToString() + " has rejected! ";
        }
    }
}
