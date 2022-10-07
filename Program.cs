using RestaurantSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RestaurantSystem.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantLogicLayer LogicLayer = new RestaurantLogicLayer();
            bool show = true;
            try
            {
                do
                {
                    WriteLine("1) Register:");
                    WriteLine("2) login:");
                    WriteLine("3)Exit:");
                    WriteLine("--------------------------------------------");
                    WriteLine("enter option : ");
                    int option = Convert.ToInt32(ReadLine());

                    switch (option)
                    {
                        case 1:
                            LogicLayer.RegisterUser();
                            break;
                        case 2:
                            LogicLayer.Login();
                            break;
                        case 3:
                            show = false;
                            break;

                    }
                } while (show);

            }catch(Exception e)
            {

            }
        }
    }
}
