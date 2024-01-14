using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BLs.Configurations
{
    public class ModelSettings
    {
        public List<ModelSetting> Models { get; set; } = [];

        public string DefaultModel { get; set; } = string.Empty;
    }
}
