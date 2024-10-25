using System.ComponentModel.DataAnnotations;

namespace ArtsShop.Model.DTO
{
    public class VNPayReturnModel
    {
        [Required]
        public string vnp_Version { get; set; }

        [Required]
        public string vnp_Command { get; set; }

        [Required]
        public string vnp_TmnCode { get; set; }

        [Required]
        public string vnp_Locale { get; set; }

        [Required]
        public string vnp_CurrCode { get; set; }

        [Required]
        public string vnp_TxnRef { get; set; }

        [Required]
        public string vnp_OrderInfo { get; set; }

        [Required]
        public string vnp_Amount { get; set; }

        [Required]
        public string vnp_TransactionNo { get; set; }

        [Required]
        public string vnp_ResponseCode { get; set; }

        [Required]
        public string vnp_TxnDate { get; set; }

        [Required]
        public string vnp_CreateDate { get; set; }

        [Required]
        public string vnp_SecureHash { get; set; }

        [Required]
        public string vnp_BankCode { get; set; }

        [Required]
        public string vnp_BankTranNo { get; set; }

        [Required]
        public string vnp_PayDate { get; set; }

    }
}
