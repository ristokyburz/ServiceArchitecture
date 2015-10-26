namespace CorePrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTransaction();
            //DoTransactionTransfers();
        }

        private static void DoTransaction()
        {
            var paymentTransactionWcfService = new PaymentWcfService();
            paymentTransactionWcfService.AuthorizeAutoCaptureTransactionWithInvoiceAndTransfer("CH2347897897D9823749872E", "CHF", 34550);
        }

        private static void DoTransactionTransfers()
        {
            var transactionTransferService = new PaymentTransferWcfService();
            transactionTransferService.TransferAndTransaction("a5f2908b-0088-4277-81f9-5d51847ce3df");
        }
    }
}
