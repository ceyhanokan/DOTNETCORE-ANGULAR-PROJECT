using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDistrictBusService: IBaseBusinessService<District>
    {
        //Ana Interface olarak IBaseBusinessService tanımlı. Temel ve ortak işlemler bu interfaceden kalıtılıyor.
        //varsa eklenecek diğer fonksiyonları buraya tanımlıyoruz
    }
}
