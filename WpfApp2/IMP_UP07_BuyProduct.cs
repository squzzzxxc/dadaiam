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
    
    public partial class IMP_UP07_BuyProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IMP_UP07_BuyProduct()
        {
            this.IMP_UP07_Product = new HashSet<IMP_UP07_Product>();
        }
    
        public int Id { get; set; }
        public int ClientId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual IMP_UP07_Client IMP_UP07_Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMP_UP07_Product> IMP_UP07_Product { get; set; }
    }
}
