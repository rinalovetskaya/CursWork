//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursWork.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscriber
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int author_id { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
