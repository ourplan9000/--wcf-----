//   * Copyright (c) 2016,海能达通信股份有限公司
//   * All rights reserved.
//   *
//   * 文件名称：importExcel.cs
//   * 文件标识：
//   * 摘要：
//   * -------------------------------------------------------
//   * 当前版本：
//   * 作者：y20419
//   * 完成日期：2016 年 12 月 01 日 15:18 分
//   *--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace WpfApplication1
{
    public class importExcel
    {

        public importExcel()
        {
            CreateAdvExcel(GetStudentData());
        }
        public void CreateAdvExcel<T>(IList<T> lt) where T : class
        {
            try
            {
                string resultFile = string.Empty;

                SaveFileDialog openFileDialog1 = new SaveFileDialog
                {
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    Filter = "All files (*.*)|*.*|xls files (*.xls)|*.xls",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };
                if (openFileDialog1.ShowDialog() == true)
                    resultFile = openFileDialog1.FileName;
                var builder = new StringBuilder(); 
                var path = resultFile;

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();  //Excel应用程序
                _Workbook excelDoc = excelApp.Workbooks.Add(Missing.Value);  //Excel文档 
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                Object nothing = Missing.Value;
                excelDoc.SaveAs(path, nothing, nothing, nothing, nothing, nothing,
                    XlSaveAsAccessMode.xlExclusive, nothing, nothing, nothing, nothing, nothing);
                excelDoc.Close(nothing, nothing, nothing);
                excelApp.Quit();
                var generation = System.GC.GetGeneration(excelApp);
                excelApp = null;


                //虽然用了_xlApp.Quit()，但由于是COM，并不能清除驻留在内存在的进程，每实例一次Excel则Excell进程多一个。
                //因此用垃圾回收，建议不要用进程的KILL()方法，否则可能会错杀无辜啊:)。
                System.GC.Collect(generation);
                if (lt == null || (0 == lt.Count))
                {
                    return;
                }
                var myPropertyInfo =
                    lt.First().GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                int i = 0, j;
                for (i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    var pi = myPropertyInfo[i];
                    var headname = pi.Name;//单元格头部
                    builder.Append(headname);
                    builder.Append("\t");
                }
                builder.Append("\n");
                foreach (var t in lt)
                {
                    if (lt == null)
                    {
                        continue;
                    }
                    for (i = 0, j = myPropertyInfo.Length; i < j; i++)
                    {
                        var pi = myPropertyInfo[i];
                        var str = string.Format("{0}", pi.GetValue(t, null)).Replace("\n", "");
                        if (str == "")
                        {
                            builder.Append("\t");
                        }
                        else
                        {
                            builder.Append(str + "\t");//横向跳到另一个单元格
                        }
                    }
                    builder.Append("\n");//换行
                }
                var sw = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("GB2312"));
                sw.Write(builder.ToString());//输出
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            { 
                throw;
            }
        }

        private List<Student> GetStudentData()
        {
            var studentList = new List<Student>();
            for (int i = 0; i < 50; i++)
            {
                var s1 = new Student();
                s1.Id = "1";
                s1.Name = "haha";
                s1.Age = "10";

                var s2 = new Student();
                s2.Id = "2";
                s2.Name = "xixi";
                s2.Age = "20";

                var s3 = new Student();
                s3.Id = "3";
                s3.Name = "lolo";
                s3.Age = "30";

                studentList.Add(s1);
                studentList.Add(s2);
                studentList.Add(s3);
            }
            return studentList;
        }
    }

    public class Student
    {
        private string id;
        public string Id { get { return id; } set { id = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string age;
        public string Age { get { return age; } set { age = value; } }
    }

}