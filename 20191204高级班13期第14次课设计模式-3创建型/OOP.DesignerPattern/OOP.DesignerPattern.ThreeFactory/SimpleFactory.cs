using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ThreeFactory
{
    /// <summary>
    /// 简单工厂转移矛盾，但是没有消除矛盾
    /// 而且还集中了矛盾
    /// </summary>
    public class SimpleFactory
    {
        public static IRace CreateInstance(RaceType raceType)
        {
            IRace iRace = null;
            switch (raceType)
            {
                case RaceType.Human:
                    iRace = new Human();
                    break;
                case RaceType.Undead:
                    iRace = new Undead();
                    break;
                case RaceType.NE:
                    iRace = new NE();
                    break;
                case RaceType.ORC:
                    iRace = new ORC();
                    break;
                default:
                    throw new Exception("wrong raceType");
            }
            return iRace;
        }






















        private static string IRaceConfigString = System.Configuration.ConfigurationManager.AppSettings["IRaceConfig"];
        /// <summary>
        /// 可配置
        /// </summary>
        /// <returns></returns>
        public static IRace CreateInstanceConfig()
        {
            RaceType raceType = (RaceType)Enum.Parse(typeof(RaceType), IRaceConfigString);
            return CreateInstance(raceType);
        }

        //如果你不想new，但是又想获取对象实例，有哪几种方法？

        private static string IRaceConfigReflectionString = System.Configuration.ConfigurationManager.AppSettings["IRaceConfigReflection"];
        public static IRace CreateInstanceConfigReflection()
        {
            Assembly assembly = Assembly.Load(IRaceConfigReflectionString.Split(',')[1]);
            Type type = assembly.GetType(IRaceConfigReflectionString.Split(',')[0]);
            return (IRace)Activator.CreateInstance(type);
        }
        //new--反射--IOC(反射)--克隆--反序列化

            //一个接口一个方法? 多个接口同一个方法？泛型！配置文件，自己想办法
        public enum RaceType
        {
            Human,
            Undead,
            NE,
            ORC
        }
    }
}
