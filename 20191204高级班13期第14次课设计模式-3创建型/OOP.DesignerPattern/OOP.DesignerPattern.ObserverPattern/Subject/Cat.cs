using OOP.DesignerPattern.ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ObserverPattern.Subject
{
    /// <summary>
    /// 一只神奇的猫
    /// 
    /// 猫叫一声之后触发
    /// baby cry
    /// brother turn
    /// dog wang
    /// father roar
    /// mother whisper
    /// mouse run
    /// neighbor awake
    /// stealer hide
    /// 
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao.....", this.GetType().Name);
            new Mouse().Run();//猫和老鼠是啥关系--依赖
            new Chicken().Woo();
            new Baby().Cry();
            new Brother().Turn();
            new Dog().Wang();
            new Father().Roar();
            new Mother().Whisper();
            new Neighbor().Awake();
            new Stealer().Hide();
        }
        //但是出现了很多依赖---不稳定---这个符合实际情况吗？老鼠的变化跟猫有啥关系？--不科学，代码有坏的味道---怎么解决？
        //职责分析：其他动作不是猫的事儿---但是因为业务需求，才放在一起
        //想办法转移一下，其他动作-------封装转移
        private List<IObserver> observerList = new List<IObserver>();
        /// <summary>
        /// 只能上端添加--甩锅给了上端
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(IObserver observer)
        {
            this.observerList.Add(observer);
        }
        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver.....", this.GetType().Name);
            foreach (var observer in observerList)
            {
                observer.Action();
            }
        }
        //有知道这个段子，刷个6     都TMD赖丘处机当年路过了牛家村！ 否则中国将是世界上最发达的国家
        //甩锅：有什么责任，都推到别人头上，哪管他洪水滔天---职场人士有时候得学那么点~

        //C#观察者模式的优雅实现
        public event Action MiaoHandler;
        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoEvent.....", this.GetType().Name);
            foreach (Action observer in this.MiaoHandler?.GetInvocationList())
            {
                observer.Invoke();
            }
        }

        /// <summary>
        /// 被观察者/主题  观察者有多少 不知道  观察者之间  和被观察者之间  松耦合
        /// </summary>
        public event Func<int> MiaoHandlerReturn;
        public int MiaoEventReturn()
        {
            Console.WriteLine("{0} MiaoHandlerReturn.....", this.GetType().Name);
            foreach (Func<int> observer in this.MiaoHandlerReturn?.GetInvocationList())
            {
                try
                {
                    int iResult = observer.Invoke();
                }
                catch (Exception)
                {
                }
                
            }

            return 1;
        }

    }
}
