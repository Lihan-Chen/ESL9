using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public partial record LogTypeDto // VIEW_ALLEVENTS_LOGTYPE
    {
        //[Precision(2)]
        public int LogTypeNo { get; set; }

        [StringLength(100)]
        //[Unicode(false)]
        public string LogTypeName { get; set; } = null!;
    }
}
