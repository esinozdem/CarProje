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
    public class PieceManager : IPieceService
    {
        IPieceDal _pieceDal;
        public PieceManager(IPieceDal pieceDal)
        {
            _pieceDal = pieceDal;
        }
        public Piece GetById(int id)
        {
            return _pieceDal.GetById(id);
        }

        public List<Piece> GetList()
        {
            return _pieceDal.GetListAll();
        }

        public void TAdd(Piece t)
        {
            _pieceDal.Insert(t);
        }

        public void TDelete(Piece t)
        {
            _pieceDal.Delete(t);
        }

        public void TUpdate(Piece t)
        {
            _pieceDal.Update(t);
        }
    }
}
