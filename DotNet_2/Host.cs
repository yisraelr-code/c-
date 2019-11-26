using System.Collections.Generic;
using System;
namespace targil_2
{
    class Host
    {
        public long HostKey;
        public List<HostingUnit> HostingUnitCollection;
        public Host(long HostKey, int numOfHotingUnit) { }
        public override String ToString() { return "ssss"; }
        private long SubmitRequest(guestRequest guestReq) { return 0; }
        public int GetHostAnnualBusyDays() { return 0; }
        public void SortUnits() { }
        public bool AssignRequests(guestRequest a) { return false; }
        public bool AssignRequests(guestRequest a, guestRequest b) { return false; }
        public bool AssignRequests(guestRequest a, guestRequest b, guestRequest c) { return false; }

        public HostingUnit this[int serialNum]
        {

            get
            {

                foreach (HostingUnit item in HostingUnitCollection)
                {
                    if (true) ;

                }
                return HostingUnitCollection[serialNum];
            }
            set
            {
                //HostingUnitCollection[serialNum = value;
            }
        }



    }
}
