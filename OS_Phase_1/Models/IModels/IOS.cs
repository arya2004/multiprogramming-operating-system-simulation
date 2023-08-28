using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models.IModels
{
    public interface IOS
    {
        public void LOAD();

        public void READ();
        public void WRITE();
        public void TERMINATE();
        public void EXECUTE();


    }
}
