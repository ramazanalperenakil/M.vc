using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public  class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Mesaj GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

     

        public List<Mesaj> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@bilgisayartech.tk");
        }

        public List<Mesaj> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@bilgisayartech.tk");
        }

        public void MesajAdd(Mesaj mesaj)
        {
            _messageDal.Insert(mesaj);
        }

        public void MesajDelete(Mesaj mesaj)
        {
            throw new NotImplementedException();
        }

        public void MesajUpdate(Mesaj mesaj)
        {
            throw new NotImplementedException();
        }
    }
}
