namespace Core.Models.ValueObjects
{
    public record Flow(decimal value, string unit) //: ValueObject
    {
        // ToDo: verify the conversion factors with OCC
        private decimal? mlminToCFS = (decimal)5.88577770211022e7; // 1699010.8
        private decimal? lbsdayToCFS = (decimal)2.50766394e7; // 1/5393775.79
        private decimal? mgdToCFS = (decimal)1.5472286365101; // 1.547

        public decimal? Value { get; set; }

        public string? Unit { get; set; }

        public decimal? ValueInCFS => Unit?.ToLower() switch
        {
            "cfs" => Value,
            "ml/min" => Value * mlminToCFS,
            "lbsday" => Value * lbsdayToCFS,
            "mgd" => Value * mgdToCFS,
            _ => null
        };

        //protected abstract Flow CreateFlow(decimal? value, string? unit);

        //protected override IEnumerable<object> GetEqualityComponents()
        //{
        //    throw new NotImplementedException();
        //}

        //public Flow ToFlow(Flow from, Flow to)
        //{
        //    if (from == null) throw new ArgumentNullException(nameof(from));

        //    if (to == null) throw new ArgumentNullException(nameof(to));

        //    if (from.Unit != to.Unit)
        //    {
        //        switch (from.Unit)
        //        {
        //            case "CFS": // verified
        //                switch (to.Unit)
        //                {
        //                    case "CFS":
        //                        return from;
        //                    case "mL/min":
        //                        return CreateFlow(from.Value * 1699010.8, to.Unit);
        //                    case "MGD":
        //                        return CreateFlow(from.Value * 0.646317, to.Unit);
        //                    case "lbs/day":
        //                        return CreateFlow(from.Value * 5393775.79, to.Unit);
        //                    default:
        //                        throw new ArgumentException("Cannot convert between different units.");
        //                }
        //            case "mL/min":
        //                switch (to.Unit)
        //                {
        //                    case "CFS":
        //                        return CreateFlow(from.Value / 1699010.8, to.Unit);
        //                    case "mL/min":
        //                        return from;
        //                    case "MGD":
        //                        return CreateFlow(from.Value / 2628758.18, to.Unit); //ok
        //                    case "lbs/day":
        //                        return CreateFlow(from.Value * 2.36, to.Unit);
        //                    default:
        //                        throw new ArgumentException("Cannot convert between different units.");
        //                }
        //            case "MGD":
        //                switch (to.Unit)
        //                {
        //                    case "CFS":
        //                        return CreateFlow(from.Value * 1.547, to.Unit);
        //                    case "mL/min":
        //                        return CreateFlow(from.Value * 2628758.18, to.Unit);
        //                    case "MGD":
        //                        return from;
        //                    case "lbs/day":
        //                        return CreateFlow(from.Value * 8340000, to.Unit);
        //                    default:
        //                        throw new ArgumentException("Cannot convert between different units.");
        //                }
        //            case "lbs/day":
        //                switch (to.Unit)
        //                {
        //                    case "CFS":
        //                        return CreateFlow(from.Value / 5393775.79, to.Unit);
        //                    case "mL/min":
        //                        return CreateFlow(from.Value / 3.17515, to.Unit);
        //                    case "MGD":
        //                        return CreateFlow(from.Value / 8340000, to.Unit);
        //                    case "lbs/day":
        //                        return from;
        //                    default:
        //                        throw new ArgumentException("Cannot convert between different units.");
        //                }
        //            default:
        //                throw new ArgumentException("Cannot convert between different units.");
        //        }
        //    }

        //    return from;
        //}



    }
}
