using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
public partial class VIEW_CLEARANCETYPE
{
    [StringLength(2)]
    [Unicode(false)]
    public string CLEARANCETYPE { get; set; } = null!;

    [Precision(2)]
    public byte CLEARANCETYPENO { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string CLEARANCETYPENAME { get; set; } = null!;
}
