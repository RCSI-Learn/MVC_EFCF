namespace MVC_EFCF.Models {
    public class TaxDocument {
        public long Id { get; set; }
        public long NIT { get; set; }
        public string Name { get; set; } = String.Empty;
        public short DocumentType { get; set; }
        public long DocumentNumber { get; set; }
        public string DocumentComplement { get; set; } = String.Empty;
        public short Currency { get; set; }
        public Decimal TotalAmount { get; set; }
        public List<Detail> Detail { get; set; } = new List<Detail>();
    }
    public class Detail {
        public long IdTaxDocument { get; set; }
        public long Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public int Quantity { get; set; }
        public decimal SingleAmount { get; set; }
        public decimal PartialAmount { get; set; }
        public TaxDocument taxDocument { get; set; } = new TaxDocument();
    }
}
