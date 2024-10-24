using da3_intra_sommatif.DataAccess;
using da3_intra_sommatif.Presentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace da3_intra_sommatif.Business
{
    public class FuelService
    {
        private FuelDao dao;
        private FuelView window;

        public FuelService() 
        {
            dao = new FuelDao();
            window = new FuelView(this);
        }

        public FuelView GetFuelWindow() 
        {
            return new FuelView(this);
        }

        public DataTable GetDataTable()
        {
            return dao.GetData();
        }

        public void ReloadDataTable() 
        {
            dao.ReloadDataTable();
        }

        public void SaveChanges() 
        {
            dao.SaveChanges();
        }


    }
}
