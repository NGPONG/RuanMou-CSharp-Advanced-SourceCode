using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEncrypt
{
    /// <summary> 
    /// 1：MD5 不可逆加密
    /// 2：Des 对称可逆加密
    /// 3：RSA 非对称可逆加密
    /// 4：数字证书 SSL
    /// 
    /// 加密解密：清晰的思维，大家比聪明！
    /// miyao 密钥
    /// 
    /// 
    /// 能听到老师讲话  能看到老师屏幕  刷个1
    /// 
    /// 
    /// 网站向CA机构申请购买证书
    //    网站提交相关信息

    //    将用户的基本信息，先使用md5生成一个摘要，CA使用加密key，加密用户的基本信息，将密文和用户信息放入颁发的证书中

    //    将证书安装到网站上

    //使用浏览器访问https站点，会自动获取证书，并使用浏览器预置的CA机构的解密证书进行解密，并与证书中的明文进行比对，如果一样，则验证通过
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //MD5  加密算法是公开的
                //通过原文---密文    密文不能得到原文

                //相同的原文加密的结果是一样的
                //原文差别小，密文差别大
                //文件加密：（文件摘要）无论文件多大，都能产生一个32位字符串
                //无论原文如何，都能得到一个32位字符串

                //MD5有啥用呢？
                //1 文件防止纂改：
                //git：如果仅仅只是一个文件修改了，当前这个文件就会标红！ MD5!
                //急速妙传：MD5

                //2 密码保存  避免看到明文
                //   校验：就是把明文MD5以后再表

                //3 数字签名/防止抵赖 

                //MD5加盐：“123456Richard-Eleven” MD5 多次

                #region MD5
                {
                    //Console.WriteLine(MD5Encrypt.Encrypt("1"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("1"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("123456小李"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("113456小李"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("113456小李113456小李113456小李113456小李113456小李113456小李113456小李"));
                    //string md5Abstract1 = MD5Encrypt.AbstractFile(@"D:\Ruanmou\Advanced13Encrypt\00test-副本.rar");
                    //string md5Abstract2 = MD5Encrypt.AbstractFile(@"D:\Ruanmou\Advanced13Encrypt\00test.rar");
                }
                #endregion


                //Des:
                //对称可逆加密
                //原文---加密以后--密文   密文---解密--原文
                //再加密和解密的时候 需要一个密钥！
                //对称：加密解密都是同一个密钥; 
                //速度快 
                //加密算法也是公开！
                //安全性 传输加密解密Key的时候存在的安全性问题

                #region Des
                {
                    string desEn = DesEncrypt.Encrypt("Richard老师");
                    string desDe = DesEncrypt.Decrypt(desEn);
                    string desEn1 = DesEncrypt.Encrypt("张三李四");
                    string desDe1 = DesEncrypt.Decrypt(desEn1);
                }
                #endregion 


                //Rsa
                //速度相对较慢！
                //加密Key  解密Key 二者是一对儿，但是不能相互推导出来！
                //公钥  把Key公开， 私钥：放在自己兜儿里
                //位什么要有公钥私钥？

                #region Rsa 
                {
                    KeyValuePair<string, string> encryptDecrypt = RsaEncrypt.GetKeyPair();
                    string rsaEn1 = RsaEncrypt.Encrypt("net", encryptDecrypt.Key);
                    string rsaDe1 = RsaEncrypt.Decrypt(rsaEn1, encryptDecrypt.Value);
                }
                #endregion


                //我们再访问有些站点的时候：https  证书

                //现在是22：03 大家开始提问，22：06开始答疑！期间老师不说话！

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
