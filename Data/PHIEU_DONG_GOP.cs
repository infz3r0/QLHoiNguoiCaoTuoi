//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEU_DONG_GOP
    {
        public decimal MA_PHIEU_DONG_GOP { get; set; }
        public System.DateTime NGAY_DONG_GOP { get; set; }
        public decimal SO_TIEN_DONG_GOP { get; set; }
        public decimal MA_DON_VI { get; set; }
    
        public virtual DON_VI_DONG_GOP DON_VI_DONG_GOP { get; set; }
    }
}
