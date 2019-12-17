using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    /// <summary>
    ///Richard 老师和一只猫的故事 
    /// </summary>
    public class Cat
    {

        /// <summary>
        /// 依赖太重，依赖太多的类型
        /// 职责不单，耦合太重，本身猫只应该做自己的事
        /// 如果任何一个环节发生改变，这个方法就得修改，导致这方法非常不稳定
        /// 
        /// 其实也不应该这样，猫就是猫，只能Miao一声，剩下的动作，本来不是这个猫的事儿； 
        /// 但是我们代码给全部限定了，还指定了顺序。
        /// 
        /// 需求：只能Miao一声,剩下的动作来自于哪里，或者怎么执行，我们不管，只负责触发，调用。
        /// 
        /// 把一堆动作按顺序执行，应该使用什么？多播委托
        /// </summary>
        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            new Dog().Wang(); //狗叫了
            new Mouse().Run();//老鼠跑了
            new Baby().Cry(); // 小孩哭了
            new Mother().Wispher();
            new Father().Roar();
            new Neighbor().Awake();
            new Stealer().Hide();
        }

        /// <summary>
        /// 基于面向抽象的观察者模式
        /// </summary>

        private List<IObject> _Observer = new List<IObject>();
        public void AddObserver(IObject obserer)
        {
            _Observer.Add(obserer);
        }
        public void MiaoAbserver()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);//固定动作
            foreach (var item in _Observer)
            {
                item.DoAction();
            }
        }

        public Action CatMaioAction;
        /// <summary>
        /// 把需要执行的动作放到委托中去
        /// 方法非常稳定
        /// 观察者模式（基于C# 语法）
        /// </summary>
        public void MiaoDelegate()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            CatMaioAction?.Invoke();
        }

        /// <summary>
        /// 事件Event:就是一个委托的实例  加一个event关键字
        /// 事件也实现上面这个猫叫了以后发生的事儿；
        /// event：可以限定权限，限定只能在事件所在类的内部Invoke;在外面是不行，包括子类也行
        /// </summary>
         
        public event Action CatMaioActionHandler;

        public void MiaoEvent()
        { 
            Console.WriteLine("{0} MiaoEvent", this.GetType().Name);
            Console.WriteLine("{7890&*（）——", this.GetType().Name);
            Console.WriteLine("{7890&*（）——", this.GetType().Name);
            Console.WriteLine("{7890&*（）——", this.GetType().Name);
            CatMaioActionHandler?.Invoke();
            Console.WriteLine("{7890&*（）——", this.GetType().Name);
            Console.WriteLine("{7890&*（）——", this.GetType().Name);
            Console.WriteLine("{7890&*（）——", this.GetType().Name);
        }

       // 现在是20:53，开始提问，快速上厕所，20:57开始答疑

    }


    public class CatChild : Cat
    {
        public void Show()
        {
            //base.CatMaioActionHandler.
            //base.CatMaioActionHandler = null; //在子类 也不行
        }
    }
}
