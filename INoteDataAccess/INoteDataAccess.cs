using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsModel;
namespace INoteDataAccess
{
    public interface INoteDataAccess
    {
        IEnumerable<Nota> GetNota();
        void InsertNota();
        void UpdateNota();
    }
}
