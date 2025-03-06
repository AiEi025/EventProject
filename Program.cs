using ApplicationService;
using Instructore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MailService mailService = new MailService();
            UserRepository userRepository = new UserRepository();
            DisCountService disCountService = new DisCountService();
            userRepository.event_handler += disCountService.OnuserRegistered;
            userRepository.event_handler += mailService.OnUserRegistered;
            userRepository.RegisterUser("Information", "Pass");

            //ProductRepository productRepository = new ProductRepository();
            //productRepository.my_event += my_eventHandler;
            //productRepository.ADDP("D");
        }
        static void my_eventHandler()
        {
            Console.WriteLine("Product Add ...!");
        }
        //برای ساخت ایونت ما نیاز به ساختن  دلیگیت داریم


        public delegate void MyEvent();//delegate 

        public class ProductRepository
        {
            public event MyEvent my_event;//event
            public void ADDP(string name)
            {
                Console.WriteLine("Product ADD...");
                OnAddProduct();

            }

            protected virtual void OnAddProduct()
            {
                my_event?.Invoke();
            }
        }

    }
}
