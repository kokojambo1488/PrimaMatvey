using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab {
    class Client {
        internal Account[] Accounts;

        internal String Name;
        internal String Surname;
        internal String City;
        internal String Phone;

        public override string ToString() {
            String res = String.Format("{0} {1} ({2}) из {3}:", Name, Surname, Phone, City);
            
            foreach (Account account in Accounts) {
                res += String.Format("\n\t{0}, на счету {1} руб. Аккаунт {2}",
                    account.Bank, account.Balance, account.IsBlocked ? "заблокирован" : "не заблокирован");
            }

            return res;
        }

        public double SumNeg() {
            double ret = 0;

            foreach (Account account in Accounts) {
                if (account.Balance < 0)
                    ret += account.Balance;
            }

            return ret;
        }

        public double SumPos() {
            double ret = 0;

            foreach (Account account in Accounts) {
                if (account.Balance >= 0)
                    ret += account.Balance;
            }

            return ret;
        }

        public double Sum() {
            return SumNeg() + SumPos();
        }
    }
}
