using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture12TransactionInAdoNetAndEF
{
    class CardAccounts
    {
        [Column(TypeName = "char(10)")]
        public string CardNumber {get;set;}
    }
}
