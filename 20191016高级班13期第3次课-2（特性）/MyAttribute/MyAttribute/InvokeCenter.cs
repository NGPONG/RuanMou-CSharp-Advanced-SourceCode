using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    public class InvokeCenter
    {
        public static void ManagerSudent<T>(T student) where T : Student
        {
            Console.WriteLine(student.Id);
            Console.WriteLine(student.Name);
            student.Answer("YZM");
            Type type = student.GetType();
            if (type.IsDefined(typeof(CutomAttribute), true)) // 先判断
            {
                object[] aAttributeArry = type.GetCustomAttributes(typeof(CutomAttribute), true);
                foreach (CutomAttribute attribute in aAttributeArry)
                {
                    attribute.Show();
                }

                foreach (var prop in type.GetProperties())
                {
                    if (prop.IsDefined(typeof(CutomAttribute), true)) // 先判断
                    {
                        object[] aAttributeArryprop = prop.GetCustomAttributes(typeof(CutomAttribute), true);
                        foreach (CutomAttribute attribute in aAttributeArryprop)
                        {
                            attribute.Show();
                        }
                    } 
                } 
                foreach (var method in type.GetMethods())
                {
                    if (method.IsDefined(typeof(CutomAttribute), true)) // 先判断
                    {
                        object[] aAttributeArryMethod = method.GetCustomAttributes(typeof(CutomAttribute), true);
                        foreach (CutomAttribute attribute in aAttributeArryMethod)
                        {
                            attribute.Show();
                        }
                    }

                }

            }


        }
    }
}
