using System;

namespace OOP.DesignerPattern.ResponsibilityChainPattern
{
    /// <summary>
    /// 行为型设计模式的巅峰之作！
    /// 无止境的行为封装转移
    /// </summary>
    public class Program
    {
        public static void Show()
        {
            ApplyContext context = new ApplyContext()
            {
                Id = 506,
                Name = "数字男孩",
                Hour = 100,
                Description = "我想参加北京线下聚会",
                AuditResult = false,
                AuditRemark = ""
            };

            {
                ////审批逻辑都写在上端，直接就是需求翻译，没有任何加工，谈不上什么扩展，面向过程---面向过程编程
                //if (context.Hour <= 8)
                //{
                //    Console.WriteLine("PM审批通过");
                //}
                //else if (context.Hour <= 16)
                //{
                //    Console.WriteLine("主管审批通过");
                //}
                //else
                //{
                //    Console.WriteLine("************");
                //}
            }
            {
                ////面向对象--从对象出发--PM  Charge  Manager--进步
                ////逻辑封装转移 第一弹！
                //AbstractAuditor pm = new PM()
                //{
                //    Name = "清茶"
                //};
                //pm.Audit(context);
                //if (!context.AuditResult)
                //{
                //    AbstractAuditor charge = new Charge()
                //    {
                //        Name = "腾坤"
                //    };
                //    charge.Audit(context);
                //    if (!context.AuditResult)
                //    {
                //        AbstractAuditor manager = new Manager()
                //        {
                //            Name = "小巨蛋"
                //        };
                //        manager.Audit(context);
                //        if (!context.AuditResult)
                //        {
                //            //未完待续
                //        }
                //    }
                //}
            }
            {
                //还得有自己的思考--多想一步--我找PM--PM转交主管
                //逻辑封装转移 第二弹！
                //AbstractAuditor pm = new PM()
                //{
                //    Name = "清茶"
                //};
                //pm.Audit(context);
            }
            {
                AbstractAuditor pm = new PM()
                {
                    Name = "清茶"
                };
                AbstractAuditor charge = new Charge()
                {
                    Name = "腾坤"
                };
                AbstractAuditor manager = new Manager()
                {
                    Name = "小巨蛋"
                };
                AbstractAuditor chief = new Chief()
                {
                    Name = "ivy"
                };
                AbstractAuditor ceo = new CEO()
                {
                    Name = "fresh"
                };
                //这个锅，行为型设计模式不背---->创建型设计模式---甩锅明天

                //逻辑封装转移 第三弹！
                //pm.SetNext(charge);
                //charge.SetNext(manager);
                //manager.SetNext(chief);
                //chief.SetNext(ceo);
                pm.SetNext(ceo);//保证了环节的稳定--可以灵活配置环节

                pm.Audit(context);
            }
        }
    }
}
