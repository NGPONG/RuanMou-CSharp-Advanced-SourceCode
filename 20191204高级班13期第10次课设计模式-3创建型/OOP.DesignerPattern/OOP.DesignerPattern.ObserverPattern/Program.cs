using OOP.DesignerPattern.ObserverPattern.Observer;
using OOP.DesignerPattern.ObserverPattern.Subject;
using System;

namespace OOP.DesignerPattern.ObserverPattern
{
    public class Program
    {
        public static void Show()
        {
            {
                Cat cat = new Cat();
                cat.Miao();
            }
            {
                Cat cat = new Cat();
                //
                cat.AddObserver(new Chicken());
                cat.AddObserver(new Baby());
                cat.AddObserver(new Brother());
                cat.AddObserver(new Dog());
                cat.AddObserver(new Father());
                cat.AddObserver(new Mother());
                cat.AddObserver(new Neighbor());
                cat.AddObserver(new Stealer());
                cat.AddObserver(new Mouse());

                cat.MiaoObserver();
            }
            //甩锅了，那锅还是存在的---这个锅，行为型设计模式，不背！--创建型设计模式
            //观察者之后，观察者数量可以增减 而且可以调整顺序
            //
            {
                Cat cat = new Cat();
                cat.MiaoHandler += (new Chicken().Woo);
                cat.MiaoHandler += (new Baby().Cry);
                cat.MiaoHandler += (new Brother().Turn);
                cat.MiaoHandler += (new Dog().Wang);
                cat.MiaoHandler += (new Father().Roar);
                cat.MiaoHandler += (new Mother().Whisper);
                cat.MiaoHandler += (new Neighbor().Awake);
                cat.MiaoHandler += (new Stealer().Hide);
                cat.MiaoHandler += (new Mouse().Run);
                //为什么有这么好的事儿？ 这世界上其实没有这么好的事儿，
                //哪里有什么岁月静好，是因为有人替你负重前行
                cat.MiaoHandler += new Action(new Mouse().Run);
                //Action是委托，，委托实际上就是类
                cat.MiaoObserver();
            }
        }
    }
}
