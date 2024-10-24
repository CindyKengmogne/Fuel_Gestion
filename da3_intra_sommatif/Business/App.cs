using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace da3_intra_sommatif.Business
{
    public class App
    {
        private FuelService service;

        public App()
        {
            ApplicationConfiguration.Initialize();
            service = new FuelService();
        }

        public void Start()
        {
            Application.Run(this.service.GetFuelWindow());

        }
    }
}
