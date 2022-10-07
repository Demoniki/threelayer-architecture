using RestaurantSystem.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RestaurantSystem.BusinessLayer
{
    public class RestaurantLogicLayer
    {
        RestaurantDataAccessLayer restaurantDataAccessLayer = new RestaurantDataAccessLayer();

        public void RegisterUser()
        {
            restaurantDataAccessLayer.RegisterUser();
        }

        public void Login()
        {

            int flag = 0;
            int result = restaurantDataAccessLayer.Login(flag);
            if (result == 1)
            {
                bool show = true;
                do
                {
                    WriteLine("-----------------choose your option---------------------");

                    WriteLine("2)display all restaurant ");
                    WriteLine("3)search restaurant based on city");
                    WriteLine("4)book restaurant for meal");
                    WriteLine("5)update restaurant booking date on booking id");
                    WriteLine("6)cancel restaurant based on booking id ");

                    WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(ReadLine());
                    switch (choice)
                    {
                        case 2://DISPLAYALL
                            restaurantDataAccessLayer.DisplayAllRestaurant();
                            break;
                        case 3://search restaurant 
                            restaurantDataAccessLayer.SearchRestaurant();
                            break;
                        case 4://book restaurant 
                            restaurantDataAccessLayer.UpdateLibrary();
                            break;
                        case 5://update a restaurant 
                            restaurantDataAccessLayer.DeleteLibrary();

                            break;

                        case 6://cancel a restaurant 
                            restaurantDataAccessLayer.CancelRestaurant();

                            break;
                        case 7:
                            show = false;
                            break;
                        default:
                            WriteLine("Invalid option");
                            break;

                    }

                } while (show);


            }
        }  
    }
}
