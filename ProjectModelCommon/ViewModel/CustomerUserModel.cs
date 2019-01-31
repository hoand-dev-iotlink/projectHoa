using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelCommon.ViewModel
{
    public class CustomerUserModel
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime? CreateTime { get; set; }
    }
}
