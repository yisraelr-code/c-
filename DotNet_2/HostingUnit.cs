using System;
namespace targil_2
{
    class HostingUnit : IComparable
    {
        static public string presentAnnualOrder(bool[,] calander)
        {
            //return string with all the orders from the year!
            bool flag = false;
            string order = "";
            for (int monthl = 0; monthl < 12; monthl++)
            {
                for (int dayl = 0; dayl < 31; dayl++)
                {
                    if (calander[monthl, dayl] && !flag)
                    {
                        flag = true;
                        order += "\n start:" + (dayl + 1) + "\\" + (monthl + 1);
                    }
                    if (!calander[monthl, dayl] && flag)
                    {
                        order += " end:" + dayl + "\\" + (monthl + 1);
                        flag = false;
                    }
                }
            }
            if (flag)
                order += (" end 31/12\n");
            return order;
        }

        private static int stSerialKey = 10000000;
        private int _hostingUnitKey;
        public int HostingUnitKey
        {
            get { return _hostingUnitKey; }
            private set { _hostingUnitKey = value; }
        }
        public bool[,] Diary = new bool[12, 31];
        public HostingUnit()
        {
            HostingUnitKey = stSerialKey;
            stSerialKey++;
        }
        public override string ToString()
        {
            return "HostingUnitKey:" + HostingUnitKey + presentAnnualOrder(this.Diary);
        }
        public bool ApproveRequest(guestRequest guestReq)
        {
            DateTime temp = guestReq.EntryDate;
            while (this.Diary[temp.Month, temp.Day] && temp != guestReq.ReleaseDate)
            {
                temp.AddDays(1);
            }
            if (temp == guestReq.ReleaseDate)
            {
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
            return GetAnnualBusyDays().CompareTo(((HostingUnit)obj).GetAnnualBusyDays());
        }
    }
}