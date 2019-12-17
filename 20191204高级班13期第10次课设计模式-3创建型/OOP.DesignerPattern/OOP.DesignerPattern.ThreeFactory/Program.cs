using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using OOP.DesignerPattern.ThreeFactory.AbstractFactroy;
using OOP.DesignerPattern.ThreeFactory.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ThreeFactory
{
    class Program
    {


        static void Main(string[] args)
        {
            try
            {
                {
                    Human human = new Human();
                    human.ShowKing();
                }
                {
                    IRace iRace = new Human();//面向抽象
                    iRace.ShowKing();
                }
                #region MyRegion
                {
                    IRace iRace = SimpleFactory.CreateInstance(SimpleFactory.RaceType.Human);// new Human();//怎么样更面向抽象
                    iRace.ShowKing();
                }
                {
                    //可配置
                    IRace iRace = SimpleFactory.CreateInstanceConfig();
                    iRace.ShowKing();
                }
                {
                    //可配置可扩展
                    IRace iRace = SimpleFactory.CreateInstanceConfigReflection();
                    iRace.ShowKing();
                }
                //走一步看一步
                {
                    IRace iRace = SimpleFactory.CreateInstance(SimpleFactory.RaceType.Undead);
                }
                #endregion
                {
                    IFactory factory = new HumanFactory();
                    //就是为了扩展（mvc扩展IOC就知道了）  为了屏蔽细节
                    IRace race = factory.CreateInstance();
                }
                {
                    //工厂方法+ 抽象--是必须全部实现的:方便扩展种族 但是不能扩展产品簇--倾斜性可扩展性设计
                    AbstractFactoryBase factory = new HumanFactoryAbstract();
                    IRace race = factory.CreatRace();
                    IArmy army = factory.CreateArmy();
                    IResource resource = factory.CreateResource();
                }
                {
                    AbstractFactoryBase factory = new UndeadFactoryAbstract();
                    IRace race = factory.CreatRace();
                    IArmy army = factory.CreateArmy();
                    IResource resource = factory.CreateResource();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
