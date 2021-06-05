using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMessageService
    {
        List<Mesaj> GetListInbox();
        List<Mesaj> GetListSendbox();
        void MesajAdd(Mesaj mesaj);
        Mesaj GetByID(int id);
        void MesajDelete(Mesaj mesaj);
        void MesajUpdate(Mesaj mesaj);
    }
}
