using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab {
    class Account : IComparable<Account> {
        internal double Balance;
        internal bool IsBlocked;

        internal String Bank;

        public int CompareTo(Account account) {
            if (this.Balance > account.Balance)
                return 1;
            else if (this.Balance < account.Balance)
                return -1;
            else
                return 0;
        }
    }
}
