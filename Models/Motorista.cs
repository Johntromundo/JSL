//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JSLProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Motorista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Motorista()
        {
            this.Veiculo = new HashSet<Veiculo>();
            this.Viagem = new HashSet<Viagem>();
        }
    
        public int id_motorista { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Nullable<int> id_end { get; set; }
    
        public virtual Endereco Endereco { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veiculo> Veiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}
