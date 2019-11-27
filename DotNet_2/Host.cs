using System.Collections.Generic;
using System;
using System.Collections;

namespace targil_2
{
    class Host: IEnumerable
    {
        public long HostKey;
        public List<HostingUnit> HostingUnitCollection;
        public Host(long HostKey, int numOfHotingUnit)
        {
            this.HostKey = HostKey;
            this.HostingUnitCollection.AddRange(new HostingUnit[numOfHotingUnit]);
        }
        public override String ToString() 
        {
            String temp = "";
            foreach (var units in HostingUnitCollection)
            {
                temp = units.ToString() + "\n";
            }
            return temp; 
        }
        private long SubmitRequest(guestRequest guestReq)
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
            int sumOfDays = 0;
            foreach (var units in HostingUnitCollection)
            {
                sumOfDays += units.GetAnnualBusyDays();
            }
            return sumOfDays;
        }
        public void SortUnits() 
        {
            HostingUnitCollection.Sort();
        }
        public bool AssignRequests(params guestRequest[] listOfRequests)
        {
            for (int i = 0; i < listOfRequests.Length; i++)
            {
                if (SubmitRequest(listOfRequests[i]) == -1)
                    return false;
            }
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            //this is unfinishd code, we need to implement it again.
            return HostingUnitCollection.GetEnumerator();
        }

        public HostingUnit this[int serialNum]
        {
            get
            {
                foreach (var item in HostingUnitCollection)
                {
                    if (serialNum == item.HostingUnitKey)
                        return item;
                }
                return null;
            }
        }



    }
}
