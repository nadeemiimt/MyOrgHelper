using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Unity.Extension;

namespace Common.Utils
{
    public class LogCreation : UnityContainerExtension
    {
        protected override void Initialize()
        {
            XmlConfigurator.Configure();
        }
    }
}
