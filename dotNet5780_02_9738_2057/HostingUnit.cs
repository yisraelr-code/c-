using System;
namespace dotNet5780_02_9738_2057
{
    class HostingUnit : IComparable
    {
        private static int stSerialKey = 10000000;
        private int _hostingUnitKey;
        public int HostingUnitKey
        {
            get { return _hostingUnitKey; }
            private set { _hostingUnitKey = value; }
        }
        public bool[,] Diary = new bool[12, 31];
        
        //constractor
        public HostingUnit()
        {
            HostingUnitKey = stSerialKey;
            stSerialKey++;
        }
        //return string with orders from the whole year!
        static public string presentAnnualOrder(bool[,] calander)
        {
            bool flag = false;
            string order = "";
            for (int monthl = 0; monthl < 12; monthl++)
            {
                for (int dayl = 0; dayl < 31; dayl++)
                {
                    if (calander[monthl, dayl] && !flag)
                    {
                        flag = true;
                        order += "\n start:" + (dayl + 1) + "/" + (monthl + 1)+"   ";
                    }
                    if (!calander[monthl, dayl] && flag)
                    {
                        order += " end:" + dayl + "/" + (monthl + 1);
                        flag = false;
                    }
                }
            }
            if (flag)
                order += (" end: 31/12\n");
            return order;
        }
        

        public override string ToString()
        {
            return "HostingUnitKey: " + HostingUnitKey + presentAnnualOrder(this.Diary);
        }
        public bool ApproveRequest(GuestRequest guestReq)
        {
            DateTime temp = guestReq.EntryDate;
            //chek if days are available (false) from enter to releas
            while ( !this.Diary[temp.Month-1, temp.Day-1] && (temp < guestReq.ReleaseDate) )
            {
                temp = temp.AddDays(1);
            }
            if (temp == guestReq.ReleaseDate)
            {
                //change diary to not available at those days
                for (DateTime temp2 = guestReq.EntryDate; temp2 <= guestReq.ReleaseDate; temp2=temp2.AddDays(1))
                {
                    this.Diary[temp2.Month - 1, temp2.Day - 1] = true;
                }
                guestReq.IsApproved = true;
                return true;
            }
            return false;
        }
        public int GetAnnualBusyDays()
        {
            int count = 0;
            for (int i = 1; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (this.Diary[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public float GetAnnualBusyPercentage()
        {
            return (float)(GetAnnualBusyDays() * 100 / (31 * 12));
        }
        public int CompareTo(object obj)
        {
            return -(GetAnnualBusyDays().CompareTo(((HostingUnit)obj).GetAnnualBusyDays()));
        }
    }
};