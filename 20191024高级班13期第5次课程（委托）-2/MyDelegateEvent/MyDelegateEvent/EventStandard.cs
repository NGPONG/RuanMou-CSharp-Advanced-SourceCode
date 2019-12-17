using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    public class EventStandard
    {
        public static void Show()
        {
            Phone phone = new Phone()
            {
                Id = 123,
                Name = "华为P9",
                Price = 2499
            };

            //订阅：就是把订户和事件发布者关联起来
            phone.DiscountHandler += new Teacher().Buy;
            phone.DiscountHandler += new Student().Buy;

            phone.Price = 500;

        }

        /// <summary>
        /// 订户 关注事件，事件发生之后，自己做出相应的动作
        /// </summary>
        public class Teacher
        {
            public void Buy(object sender, EventArgs e)
            {
                Phone phone = (Phone)sender;
                Console.WriteLine($"this is {phone.Name}");
                XEventArgs xEventArgs = (XEventArgs)e;
                Console.WriteLine($"之前的价格{xEventArgs.OldPrice}");
                Console.WriteLine($"现在的价格{xEventArgs.NewPrice}");
                Console.WriteLine("买下来");

            }
        }

        public class Student
        {
            public void Buy(object sender, EventArgs e)
            {
                Phone phone = (Phone)sender;
                Console.WriteLine($"this is {phone.Name}");
                XEventArgs xEventArgs = (XEventArgs)e;
                Console.WriteLine($"之前的价格{xEventArgs.OldPrice}");
                Console.WriteLine($"现在的价格{xEventArgs.NewPrice}");
                Console.WriteLine("买下来");

            }
        }

        /// <summary>
        /// 自定的参数
        /// </summary>
        public class XEventArgs : EventArgs
        {
            public int OldPrice { get; set; }

            public int NewPrice { get; set; }

        }



        /// <summary>
        /// 事件的发布者，发布事件并且在满足条件的情况下，触发事件
        /// </summary>
        public class Phone
        {
            public int Id { get; set; }

            public string Name { get; set; }


            private int _price;

            public int Price
            {
                get
                {
                    return _price;
                }
                set
                {
                    if (value < _price) //降价了
                    {
                        this.DiscountHandler?.Invoke(this, new XEventArgs()
                        {
                            OldPrice = _price,
                            NewPrice = value
                        });
                    }

                    this._price = value;

                }
            }

            public event EventHandler DiscountHandler;
        }

    }
}
