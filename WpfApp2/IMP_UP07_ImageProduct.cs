//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class IMP_UP07_ImageProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IMP_UP07_ImageProduct()
        {
            this.IMP_UP07_Product = new HashSet<IMP_UP07_Product>();
        }
    
        public int Id { get; set; }
        public string ImagePath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMP_UP07_Product> IMP_UP07_Product { get; set; }
    }
}
