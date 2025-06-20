using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
public partial class VIEW_ALLEVENTS_LOGTYPE
{
    [Precision(2)]
    public byte LOGTYPENO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LOGTYPENAME { get; set; } = null!;
}
