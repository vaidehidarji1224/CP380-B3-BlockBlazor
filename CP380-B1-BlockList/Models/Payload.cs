
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public string user
        { get; set; }
        public TransactionTypes transType
        { get; set; }

        public int tamount
        { get; set; }
        public string titem
        { get; set; }
        public Payload(string Tuser, TransactionTypes TransType, int Tamount, string Titem)
        {
            user = Tuser;
           transType= TransType;
            tamount = Tamount;
            titem = Titem;
        }
       }
    }

