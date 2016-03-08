using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fallout4Checklist.Entities
{
    public partial class ImagePath
    {
        public string FullPath => $"{Environment.CurrentDirectory}{Path}";
    }
}
