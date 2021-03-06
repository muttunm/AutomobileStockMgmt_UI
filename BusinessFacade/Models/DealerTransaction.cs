﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade.Models
{
    public class DealerTransaction
    {
        public long TransactionId { get; set; }

        public int DealerId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string InvoiceNumber { get; set; }

        public string InvoiceUrl { get; set; }

        public double Vat { get; set; }

        public double Discount { get; set; }

        public string SeperatedStockItemIds { get; set; }

        public string SeperatedStockItemQuantities { get; set; }

        public double TotalAmount { get; set; }

        public double GrandTotalAmount { get; set; }

        public double DueAmount { get; set; }

        public double PaidAmount { get; set; }

        public string TransactionStatus { get; set; }

        public IList<StockItem> StockItems { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
        public string SeperatedStockItemPrices { get; set; }

        public double VatAmount
        {
            get
            {
                var totalAmount = StockItems.Sum(p => p.Quantity * p.UnitPrice);
                return (totalAmount * Vat) / 100;
            }
        }

        public double DiscountAmount
        {
            get
            {
                var totalAmount = StockItems.Sum(p => p.Quantity * p.UnitPrice);
                totalAmount += VatAmount;
                return (totalAmount * Discount) / 100;
            }
        }
    }
}
