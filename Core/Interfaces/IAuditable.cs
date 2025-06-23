using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuditable
    {
        //String CreatedBy { get; }

        //DateTime CreatedOnUtc { get; }

        //String ModifiedBy { get; }

        //DateTime? ModifiedOnUtc { get; }

        String UpdatedBy { get; }

        DateTime UpdateDate { get; }
    }
}
