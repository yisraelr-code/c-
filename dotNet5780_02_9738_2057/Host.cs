using System.Collections.Generic;
using System;
using System.Collections;

namespace dotNet5780_02_9738_2057
{
    class Host: IEnumerable
    {
        public long HostKey;
        public List<HostingUnit> HostingUnitCollection = new List<HostingUnit>();
        public Host(long HostKey, int numOfHostingUnit)
        {
            this.HostKey = HostKey;
            for (int i = 0; i < numOfHostingUnit; i++)
            {
                HostingUnit hu = new HostingUnit();
                this.HostingUnitCollection.Add(hu);
            }
        }
        public override String ToString() 
        {
            String temp = "Host:"+this.HostKey+"\n";
            foreach (var units in HostingUnitCollection)
            {
                temp += units.ToString() + "\n\n";
            }
            return temp; 
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (var units in HostingUnitCollection)
            {
                if (units.ApproveRequest(guestReq))
                    return units.HostingUnitKey;
            }
            return -1;
        }
        public int GetHostAnnualBusyDays() 
        {
            int sumOfHosts = 0;
            foreach (var units in HostingUnitCollection)
            {
                sumOfHosts += units.GetAnnualBusyDays();
            }
            return sumOfHosts;
        }

        //sorting by capacity
        public void SortUnits() 
        {
            HostingUnitCollection.Sort();
        }
        public bool AssignRequests(params GuestRequest[] Requests)
        {
            for (int i = 0; i < Requests.Length; i++)
            {
                if (SubmitRequest(Requests[i]) == -1)
                    return false;
            }
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

        public HostingUnit this[int i]
        {
            get
            {
                if (i < this.HostingUnitCollection.Count)
                {
                    int j = 0;
                    foreach (var item in HostingUnitCollection)
                    {
                        if (i == j)
                            return item;
                        j++;
                    }
                }
                return null;
            }
        }
    }
}
