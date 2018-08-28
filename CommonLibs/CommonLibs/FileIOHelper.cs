using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonLibs
{
    public static class FileIOHelper
    {
        public static string ReadFileToString(string fileName)
        {
            string content = "";
            using (StreamReader sr = new StreamReader(fileName))
            {
                content = sr.ReadToEnd();
            }

            return content;
        }

        public static bool WriteFiltFromString(string content, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return false;
            }

            return true;
        }

        public static byte[] ReadFileToBytes(string fileName)
        {
            byte[] results = new byte[Int32.MaxValue];
            //构造读取文件流对象
            using (FileStream fsRead = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read)) //打开文件，不能创建新的
            {
                //readCount  这个是保存真正读取到的字节数
                int readCount = fsRead.Read(results, 0, (int)fsRead.Length);
            }

            return results;
        }

        public static bool WriteFileFromBytes(byte[] content, string fileName)
        {
            try
            {
                using (FileStream fsWrite = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fsWrite.Write(content, 0, content.Length); //将字节数组写入到文本文件
                }
            }
            catch (Exception ex)
            {
                //TODO:log
                return false;
            }

            return true;
        }

        /// <summary>
        /// FileStream读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string FileStreamReadFile(string filePath)
        {
            char[] charData;
            using (var file = new FileStream(filePath, FileMode.Open))
            {
                charData = new char[file.Length];
                byte[] data = new byte[file.Length];
                file.Seek(0, SeekOrigin.Begin); //文件指针指向0位置
                file.Read(data, 0, (int)file.Length);//读入两百个字节
                
                Decoder dec = Encoding.UTF8.GetDecoder();//提取字节数组
                dec.GetChars(data, 0, data.Length, charData, 0);
            }
            return new string(charData);
        }

        // 用FileStream写文件
        public static void FileStreamWriteFile(string filePath, string str)
        {
            try
            {
                using (var nFile = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    //获得字符数组
                    var charData = str.ToCharArray();
                    //初始化字节数组
                    var byData = new byte[charData.Length];
                    //将字符数组转换为正确的字节格式
                    Encoder enc = Encoding.UTF8.GetEncoder();
                    enc.GetBytes(charData, 0, charData.Length, byData, 0, true);
                    nFile.Seek(0, SeekOrigin.Begin);
                    nFile.Write(byData, 0, byData.Length);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T ReadFileToObject<T>(string filePath)
        {
            var objStr = FileStreamReadFile(filePath);

            return JsonConvert.DeserializeObject<T>(objStr);
        }

        public static bool WriteFileFromObject<T>(T obj, string filePath)
        {
            var objStr = JsonConvert.SerializeObject(obj);

            FileStreamWriteFile(filePath, objStr);

            return true;
        }
    }
}
