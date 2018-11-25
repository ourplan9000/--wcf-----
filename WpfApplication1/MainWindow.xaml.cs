
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using RestSharp;
using RestSharp.Serializers;
using WebApiClient;
//using WebApiClient;
using DataFormat = System.Windows.DataFormat;
using XmlSerializer = System.Xml.Serialization.XmlSerializer;


namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        public MainWindow()
        {
            ProfileOptimization.SetProfileRoot(Directory.GetCurrentDirectory());

            ProfileOptimization.StartProfile("ProfileFile");

            InitializeComponent();
         
            Application.Current.Dispatcher.InvokeAsync(new Action(async () =>
            {
                await Task.Yield();
            }));
          


            var dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
            Dispatcher.VerifyAccess();
            var products = new List<Person>(){
                    new Person(){ Id="1", Name="n1"},
                    new Person(){ Id="1", Name="n12"},
                    new Person(){ Id="2", Name="n21"},
                    new Person(){ Id="2", Name="n22"},
                    new Person(){ Id="3", Name="n3"},
                    new Person(){ Id="4", Name="n3"}
            };

            var distinctProduct = products
             .GroupBy(p => new { p.Name })
             .Select(g => g.First())
             .ToList();
            
            var lookupTest = products.ToLookup(t => t.Id);
            Debug.WriteLine("lookup: "+lookupTest["1"].Count());
            var strList = new List<string>()
            {
                "1"
            };
            var exist = products.Join(strList,
                data => data.Id,
                police => police, (entity, s) => entity).ToList();
            var linqJoin = from product in products
                join str in strList
                on product.Id equals str
                select new { product, str};
            Debug.WriteLine(JsonConvert.SerializeObject(exist));

            
            grid.ItemsSource = distinctProduct;
          

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {

        }

        internal RestRequest CreateGetRequest(string accesstoken)
        {
            string getStr = "/services/facade/mess/getactivtityallchildren/" + accesstoken;
            var request = new RestRequest(Method.GET);
            request.Resource = getStr;
            //  request.AddParameter("ACTIVTITYID", accesstoken, ParameterType.QueryString);
            return request;
        }

        async void CreateAddWeiboRequest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            stopwatch.Stop();

            // string ResStr = "/services/facade/mess/saveorupdateactivtitytask";
            // string ResStr = "/services/facade/mess/deletesecuritypolicebyguid";
            //string ResStr = "/services/facade/mess/saveorupdateactivity";
            //string ResStr = "/services/facade/mess/deletedutystations";
            string ResStr = "/services/facade/mess/saveorupdatedutystation";


            var request = new RestRequest(Method.POST);

            request.RequestFormat = RestSharp.DataFormat.Json;
            request.Resource = ResStr;
            request.JsonSerializer = new RestSharpSerializer();
            request.AddHeader("Content-Type", "application/json");

            var parmas = new InputParam();

            var idList = new List<string>
            {
                "2659c1895803453387c7a8e77d35eb2d",
                "61bb3e87cec642b1bdf7b3724d4b7fbc"
            };

            var parmers = new InputParam3();
            parmers.ids = idList;
            parmers.withPoliceForce = false;
            parmas.Guids = idList;

            var tdto = new ActivityTaskDto
            {
                ID = "2659c1895803453387c7a8e77d35eb2d",
                Name = "webapi"
            };
            var paramas1 = new InputParamModel<ActivityTaskDto>()
            {
                model = tdto
            };
            var paramers = new InputParam2()
            {
                activityId = "2659c1895803453387c7a8e77d35eb2d",
                type = "webApi"

            };
            ActivityDto adto = new ActivityDto()
            {
                ID = "2659c1895803453387c7a8e77d35eb2d",
                Name = "webapi",
                StartTime = DateTime.Now,

            };

            var activity = new InputParamModel<ActivityDto>()
            {
                model = adto
            };

            DutyStationDto dutyDto = new DutyStationDto()
            {
                ID = "2659c1895803453387c7a8e77d35eb2d3",
                Name = "webapi",
                LastUpdateTime = DateTime.Now,
                SecurityPolices = new List<SecurityPoliceDto>()
            };

            var dutyStationDto = new InputParamModel<DutyStationDto>()
            {
                model = dutyDto
            };


            var pararmType = typeof(InputParamModel<ActivityDto>).GetGenericArguments();
            var firstOrDefault = pararmType.FirstOrDefault();

            var jstr = JsonConvert.SerializeObject(dutyStationDto, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            });
            //mess/deletedutystations
            MessageBox.Show(jstr);
            request.AddJsonBody(dutyStationDto);
            var _restClient = new RestClient("http://192.168.0.210:9191/");
            var response = await Task.Run(() => _restClient.Execute(request));
            //  var response = await Task.Run(() => _restClient.Execute(CreateGetRequest("2c58988be0b24301b9499241fa96977c")));
            // var response = await Task.Run(() => _restClient.Execute(CreateGetRequest("2cfab9ec9e0f46349dcb32de70fb03d8")));

            // WebBrowser.NavigateToString(response.Content);
            //this.richTextBox.AppendText("响应网页内容：" + response.Content);


        }
        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawEllipse(Brushes.Orange, null, new Point(), 80, 80);

        }
        private void DisplayConfig()
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];

                this.richTextBox.AppendText(" " + key + ": " + value);
            }

        }

        //display current content in App.config appSettings section
        /// <summary>
        /// 写入config 并更新内存
        /// </summary>
        /// <param name="valueStr"></param>
        private void SaveConfig(string valueStr)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Add("ModificationTime", valueStr + " ");
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }


        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            var str = string.Empty;
            CancellationTokenSource cacellTokenSource = new CancellationTokenSource();

            var task = new Task(() =>
            {
                throw new Exception("test");
                //str = client133.GetLeadInfo(string.Empty, 1, 10, "864564020125415");
            }, cacellTokenSource.Token);
            Task errask = task.ContinueWith((parentTask) =>
            {
                if (parentTask.IsFaulted)
                {

                    // str = client1.GetLeadInfo(string.Empty, 1, 10, "864564020125415");
                }
                richTextBox.AppendText(str);
            }, TaskContinuationOptions.OnlyOnFaulted);
            Task canceleTask = task.ContinueWith((parentTask) =>
            {
                if (parentTask.IsCanceled)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {

                    }));
                }
            }, TaskContinuationOptions.OnlyOnCanceled);
            Task completionetask = task.ContinueWith((parentTask) =>
            {
                if (parentTask.IsCompleted)
                {
                    Dispatcher.BeginInvoke(new System.Action(() =>
                    {

                    }));
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task completionetask1 = errask.ContinueWith((parentTask) =>
            {
                if (parentTask.IsCompleted)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {

                    }));
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
            task.Wait();
            richTextBox.AppendText(str);
        }

        private void btnJson2Dt_Click(object sender, RoutedEventArgs e)
        {
            OracleMapperSql dbHelp = new OracleMapperSql();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    DataSet dataSet = dbHelp.GetDsQuery("select * from SYS_DICTTREEDATA WHERE ROWNUM <= 500");
                    DynamicParameters dbDynamicParameters = new DynamicParameters();
                    dbDynamicParameters.Add("@a", 123, dbType: DbType.StringFixedLength);

                    watch.Stop();
                    List<Dictionary<string, string>> dictList = new List<Dictionary<string, string>>();
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("key", "test");
                    dict.Add("value", "oect");
                    dictList.Add(dict);
                    dictList.Add(dict);
                    dictList.Add(dict);
                    string jasonstr = JsonConvert.SerializeObject(dictList, Newtonsoft.Json.Formatting.None);
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        richTextBox.Document.Blocks.Clear();
                        this.richTextBox.AppendText(jasonstr);
                    }));
                    Dispatcher.BeginInvoke(new Action(() =>
                    {

                        this.richTextBox.AppendText(
                            string.Format("{0}条数据：{1}ms ", dataSet.Tables[0].Rows.Count,
                                watch.ElapsedMilliseconds));
                        this.richTextBox.AppendText("\r");
                        grid.ItemsSource = dataSet.Tables[0].DefaultView;
                    }));
                    string json = JsonConvert.SerializeObject(dataSet, Newtonsoft.Json.Formatting.None);
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.richTextBox.AppendText(json);
                    }));

                    DataSet dataSet1 = JsonConvert.DeserializeObject<DataSet>(json);
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            });
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {


            }));



            //this.WebBrowser.NavigateToString("");
            richTextBox.Document.Blocks.Clear();
            grid.ItemsSource = null;

            //SaveConfig(DateTime.Now.ToLongDateString());
            //Master master = new Master();
            //master.IP = "192.168.168.71";
            //master.Port = 6666;
            //master.Enabled = true;
            //FromClientDFClient client = new FromClientDFClient(master, master);

            //client.ThrowException = true;
            //try
            //{
            //    double result = client.Invoke<ICalculator, double>(
            //    proxy => proxy.Add(2, 1));
            //    MessageBox.Show(result.ToString());
            //}
            //catch (Exception ex)
            //{
            //}select wi.EVENTID,wi.CALLTIME,wi.VC64_02,wi.VC64_06,wi.VC64_11,vi.x,vi.y from wi_incept_records wi,VIEW_ALARM_LOCATION vi where wi.EVENTID=vi.eventid
            OracleMapperSql.MapperSql();


            Dispatcher.Invoke(() =>
            {


                this.richTextBox.AppendText("\r");
                DoEvents();
            });



        }

        private static void DoEvents()
        {
            var frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }

        private static object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }


        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                this.richTextBox.Document.Blocks.Clear();
                OracleMapperSql dhHelp = new OracleMapperSql();
                Task.Run(async () =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    var list = dhHelp.SqlQuery<SYS_DICTTREEDATA>("select * from SYS_DICTTREEDATA WHERE ROWNUM <= 500");
                    watch.Stop();
                    var data = new
                    {
                        total = list.Count(),
                        rows = list
                    }; // easyui datagrid 匿名类
                    var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None);
                    await Dispatcher.BeginInvoke(new Action(() =>
                      {
                          this.richTextBox.AppendText(string.Format("{0}条数据：{1}ms ",
                              list.Count(),
                              watch.ElapsedMilliseconds));
                          this.richTextBox.AppendText(Environment.NewLine);
                          this.richTextBox.AppendText(json);
                          DoEvents();
                      }));
                    using (var file = File.Create("DictTreeData.bin"))
                    {
                        ProtoBuf.Serializer.Serialize(file, list);
                    }
                    List<SYS_DICTTREEDATA> newDicttreedatas;
                    using (var file = File.OpenRead("DictTreeData.bin"))
                    {
                        newDicttreedatas = ProtoBuf.Serializer.Deserialize<List<SYS_DICTTREEDATA>>(file);
                    }
                    await Dispatcher.BeginInvoke(new Action(() =>
                    {
                        grid.ItemsSource = newDicttreedatas;

                        newDicttreedatas.AddRange(newDicttreedatas.Where(t =>
                            t.NODEID.Equals("AccidentAcceptProcStatusType_211")));
                        DoEvents();
                    }));
                    var xmlSerizlizer = new XmlSerializer(typeof(List<SYS_DICTTREEDATA>));
                    using (var file = File.Create("DictTreeData.xml"))
                    {
                        xmlSerizlizer.Serialize(file, list);
                    }
                    using (var file = new FileStream("DictTreeData.dat", FileMode.Create))
                    {
                        var binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(file, list);
                    }
                    long em = 0;
                    const int count = 20;
                    for (var k = 0; k < count; k++)
                    {
                        var stopwatch = new Stopwatch();

                        stopwatch.Start();
                        var taskList = new List<Task>();
                        const int fq = 25;
                        for (var i = 0; i < fq; i++)
                        {
                            var task1 = Task.Run(() =>
                            {
                                for (var j = 0; j < 100000000 / fq; j++)
                                {

                                }
                            });
                            taskList.Add(task1);
                        }
                        await Task.WhenAll(taskList.ToArray());
                        stopwatch.Stop();
                        em += stopwatch.ElapsedMilliseconds;
                        Dispatcher.Invoke(() =>
                        {
                            this.richTextBox.AppendText(" 1亿次：" + stopwatch.ElapsedMilliseconds.ToString() + "ms  ");
                            this.richTextBox.AppendText("\r");
                            DoEvents();
                        });
                    }
                    Dispatcher.Invoke(new Action(() =>
                    {

                    }));
                    Dispatcher.Invoke(() =>
                    {
                        richTextBox.AppendText(Thread.GetDomain().FriendlyName);
                        this.richTextBox.AppendText("\r");
                        richTextBox.AppendText(Assembly.GetEntryAssembly().FullName);
                        var acceptExId = new Guid("B5367DF1-CBAC-11CF-95CA-00805F48A192");
                        this.richTextBox.AppendText("\r");
                        richTextBox.AppendText(acceptExId.ToString("N"));
                        DoEvents();
                    });

                    MedicalSub sub = new MedicalSub();

                    sub.Id = "1";
                    sub.Name = "test";
                    sub.MedicalType = new MedicalType();
                    sub.MedicalType.Id = "1-1";
                    sub.MedicalType.Name = "type-test";


                    var xmlStr = XmlSerialize.SerializeXml(sub);

                    Dispatcher.Invoke(() =>
                    {
                        richTextBox.AppendText("\r");
                        richTextBox.AppendText(xmlStr);

                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Extended WPF ToolKit MessageBox",
                    MessageBoxButton.OK, MessageBoxImage.Question);
            }

        }

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        private async void btnWebService_Click(object sender, RoutedEventArgs e)
        {
            this.btnWebService.IsEnabled = false;
            Init();
            this.richTextBox.Document.Blocks.Clear();
            HttpApiFactory.Add<IShareFacade>().ConfigureHttpApiConfig(c =>
            {
                c.HttpHost = new Uri("http://192.168.0.210:9191/");

            });
            var webApi = HttpApiFactory.Create<IShareFacade>();
            var getallcallobject = await webApi.getallcallobject();
            this.richTextBox.AppendText(getallcallobject);

            //var response = await _httpClient.GetAsync(_url);

            //task.Result.EnsureSuccessStatusCode();
            //HttpResponseMessage response = task.Result;


           // var result = await response.Content.ReadAsStringAsync();
           // var responseBodyAsText = result;
            //  responseBodyAsText = responseBodyAsText.Replace("<br/>", Environment.NewLine);
            //this.richTextBox.AppendText(responseBodyAsText);
            // this.WebBrowser.NavigateToString(responseBodyAsText);
            btnWebService.IsEnabled = true;
        }

        private string _url = string.Empty;
        private HttpClientHandler _handler;
        private HttpClient _httpClient;

        public void Init()
        {
            _url = "http://webservices.amazon.com/AWSECommerceService/AWSECommerceService.wsdl";
            // url = "http://www.cnblogs.com/";
            //url = "https://github.com/dotnet"; 
            _handler = new HttpClientHandler
            {
                AllowAutoRedirect = false

            };
            _httpClient = new HttpClient(_handler)
            {
                MaxResponseContentBufferSize = 256000
            };
            _httpClient.DefaultRequestHeaders.Add("user-agent",
                "Mozilla/5.0 (compatible;MSIE 11.0;Windows NT 6.2; WOW64; Trident/6.0)");
        }



        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            var sysTime = new SystemTime();

            SetSystemDateTime.GetLocalTime(sysTime);

            sysTime.vYear = (ushort)DateTime.Now.Year;

            sysTime.vMonth = (ushort)DateTime.Now.Month;

            sysTime.vDay = (ushort)DateTime.Now.Day;

            sysTime.vHour = (ushort)DateTime.Now.Hour;

            sysTime.vMinute = (ushort)DateTime.Now.Minute;

            sysTime.vSecond = (ushort)DateTime.Now.Second;
            if (MessageBox.Show("您真的确定更改系统当前日期和时间吗？", "信息提示", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {

                SetSystemDateTime.SetLocalTime(sysTime);
            }
        }

        private void BtnImport_OnClick(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                importExcel importExcel = new importExcel();
            });
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void UIElement_OnKeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.Source.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
        }

        private async void DBtest_OnClick(object sender, RoutedEventArgs e)
        {
            OracleMapperSql oracleMapper = new OracleMapperSql();
            const string sql = @"SELECT * FROM  v_allcallableobjects WHERE ROWNUM <= 500 and guid ='1'";
            Stopwatch stopwatch = Stopwatch.StartNew();
            var list = await oracleMapper.Sqldynamic<dynamic>(sql);

            var idList = list.Select(t => t.Guid).ToList();
            stopwatch.Stop();
            MessageBox.Show(list.Count() + Environment.NewLine + " time " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            stopwatch.Restart();
            var liststr = JsonConvert.SerializeObject(list);
            stopwatch.Stop();
            MessageBox.Show(" time " + stopwatch.ElapsedMilliseconds);
            File.WriteAllText("1.txt", liststr); ;
        }
        //Stopwatch stopwatch = Stopwatch.StartNew();
        //OracleMapperSql oracleMapper = new OracleMapperSql();
        //StringBuilder strSql = new StringBuilder();
        //strSql.Append("insert into ICC_SDMS_INTERPHONE_INFO(");
        //strSql.Append("INTERPHONE_GUID,PUC_ID,DEVICE_ID,DEVICE_TYPE,DEVICE_NUMBER,DEVICE_NAME,STATUS,DEVICE_MAKE,NUMBER_TYPE,ORG_GUID,DEVICE_ICON,HAS_GPS,ENABLE_GPS,AND_OR_FLAG,GPS_INTERVAL,GPS_CHANNEL,DISTANCE,GPS_DATETIME,LONGITUDE,LATITUDE,HAS_SCREEN,ENABLE_FLAG,JOIN_GROUP,JOIN_GROUP_INFO,RESPONSE_GROUP,RESPONSE_GROUP_INFO,IMPLICT_GROUP,IMPLICT_GROUP_INFO,CREATEUSER,CREATETIME,UPDATEUSER,UPDATETIME,REMARK,USER_GUID,USER_TYPE,USER_NAME,ORG_IDENTIFIER,SYSTEM_ID)");
        //strSql.Append(" values (");
        //strSql.Append(":INTERPHONE_GUID,:PUC_ID,:DEVICE_ID,:DEVICE_TYPE,:DEVICE_NUMBER,:DEVICE_NAME,:STATUS,:DEVICE_MAKE,:NUMBER_TYPE,:ORG_GUID,:DEVICE_ICON,:HAS_GPS,:ENABLE_GPS,:AND_OR_FLAG,:GPS_INTERVAL,:GPS_CHANNEL,:DISTANCE,:GPS_DATETIME,:LONGITUDE,:LATITUDE,:HAS_SCREEN,:ENABLE_FLAG,:JOIN_GROUP,:JOIN_GROUP_INFO,:RESPONSE_GROUP,:RESPONSE_GROUP_INFO,:IMPLICT_GROUP,:IMPLICT_GROUP_INFO,:CREATEUSER,:CREATETIME,:UPDATEUSER,:UPDATETIME,:REMARK,:USER_GUID,:USER_TYPE,:USER_NAME,:ORG_IDENTIFIER,:SYSTEM_ID)");

        //List<ICC_SDMS_INTERPHONE_INFO> list = new List<ICC_SDMS_INTERPHONE_INFO>();
        //    for (int i = 0; i< 8000; i++)
        //{
        //    ICC_SDMS_INTERPHONE_INFO c = new ICC_SDMS_INTERPHONE_INFO();
        //    c.DEVICE_ID = "201111" + i;
        //    c.DEVICE_NAME = c.DEVICE_ID;
        //    c.DEVICE_TYPE = "0";
        //    c.ENABLE_FLAG = 1;
        //    c.INTERPHONE_GUID = "d7c3b" + i + "dskdajksad21";


        //    c.ORG_IDENTIFIER = "000";
        //    c.ORG_GUID = "7F967013C18A4978B1A908FDA14FF160";
        //    c.PUC_ID = "00001";
        //    c.SYSTEM_ID = "001";

        //    list.Add(c);
        //}


        //// oracleMapper.InsertMultiple<ICC_SDMS_INTERPHONE_INFO>(strSql.ToString(), list);
        //stopwatch.Stop();
        //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OracleMapperSql oracleMapper = new OracleMapperSql();
            const string sql = @"SELECT * FROM LSS_T_ACTIVITY WHERE DELETEFLAG = 0  
                                     AND to_char(Starttime,'yyyymmdd') = :TodayString   
                                    And STARTTIME <= :starttime 
                                    AND  ACTIVESTARTTIME is null";
            var list = oracleMapper.SqldynamicWithParams<dynamic>(sql, new
            {
                TodayString = DateTime.Now.ToString("yyyyMMdd"),
                starttime = DateTime.Now
            }).ToList();
            MessageBox.Show(list.Count.ToString());
        }
    }

    #region XmlSerialize




    public class XmlSerialize
    {
        /// <summary>  
        /// 反序列化XML为类实例  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="xmlObj"></param>  
        /// <returns></returns>  
        public static T DeserializeXml<T>(string xmlObj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlObj))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>  
        /// 序列化类实例为XML  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
        public static string SerializeXml<T>(T obj)
        {
            var strb = new StringBuilder();
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var writer = XmlWriter.Create(strb, settings))
            {
                var ns = new XmlSerializerNamespaces();
                //Add an empty namespace and empty value
                ns.Add("", "");
                new XmlSerializer(obj.GetType()).Serialize(writer, obj, ns);

            }
            string[] newStr = strb.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            strb.Clear();
            foreach (var t in newStr)
            {
                strb.Append(t);
            }
            return strb.ToString();
        }
    }

    #endregion

    public class InputParam
    {
        [JsonProperty("guids")]
        public List<string> Guids { get; set; }
    }
    public class InputParam3
    {

        public List<string> ids { get; set; }
        public bool withPoliceForce { get; set; }
    }
    public class InputParam2
    {
        public string activityId { get; set; }
        public string type { get; set; }
    }
    public class InputParamModel<T>
    {
        [JsonProperty("model")]
        public T model { get; set; }
    }
    // 摘要: 
    //     执勤岗位
    public class DutyStationDto
    {


        // 摘要: 
        //     所属的活动ID
        public string ActivityID { get; set; }
        //
        // 摘要: 
        //     安保活动任务ID
        public string ActivityTaskID { get; set; }
        //
        // 摘要: 
        //     负责人
        public string Charger { get; set; }
        //
        // 摘要: 
        //     主键ID：GUID
        public string ID { get; set; }
        //
        // 摘要: 
        //     是否撤岗
        public bool IsCancel { get; set; }
        //
        // 摘要: 
        //     上一次更新时间
        public DateTime LastUpdateTime { get; set; }
        //
        // 摘要: 
        //     获取或设置节点的纬度值
        public double? Latitude { get; set; }
        //
        // 摘要: 
        //     获取或设置节点的经度值
        public double? Longitude { get; set; }
        //
        // 摘要: 
        //     岗位名称
        public string Name { get; set; }
        //
        // 摘要: 
        //     警力需求数量
        public int PoliceAmountNeed { get; set; }
        //
        // 摘要: 
        //     岗位职责
        public string Remark { get; set; }
        //
        // 摘要: 
        //     获取该执勤点的执勤警力人员列表
        public List<SecurityPoliceDto> SecurityPolices { get; set; }
        //
        // 摘要: 
        //     岗位半径，用于确定警力是否离岗
        public double? StationRange { get; set; }
        //
        // 摘要: 
        //     岗位类别ID，在Xml中匹配
        public string StationTypeID { get; set; }
        //
        // 摘要: 
        //     场馆ID
        public string VenueID { get; set; }
    }
    // 摘要: 
    //     警力部署(执勤警力)
    public class SecurityPoliceDto
    {


        // 摘要: 
        //     下岗时间
        public DateTime? EndTime { get; set; }
        //
        // 摘要: 
        //     标识
        public string ID { get; set; }
        //
        // 摘要: 
        //     部岗时该警力的初始纬度
        public double? Latitude { get; set; }
        //
        // 摘要: 
        //     部岗时该警力的初始经度
        public double? Longitude { get; set; }
        //
        // 摘要: 
        //     警力标识
        public string PoliceID { get; set; }
        //
        // 摘要: 
        //     警力类型[CAR|STAFF]
        public string PoliceType { get; set; }
        //
        // 摘要: 
        //     职责描述
        public string Remark { get; set; }
        //
        // 摘要: 
        //     上岗时间
        public DateTime? StartTime { get; set; }
        //
        // 摘要: 
        //     关联值勤岗位ID
        public string StationID { get; set; }
        //
        // 摘要: 
        //     是否到岗：0:未到岗，1：到岗
        public bool WorkState { get; set; }
        //
        // 摘要: 
        //     到岗时间
        public DateTime? WorkTime { get; set; }
    }
    public class RestSharpSerializer : ISerializer
    {
        public RestSharpSerializer()
        {
            this.ContentType = "application/json";
        }
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            });
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }
    }
    #region 扩展类

    public class ActivityDto
    {

        /// <summary>主键ID</summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>活动类型,从数据字典中获取</summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>活动名称</summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>活动简介</summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>活动开始时间</summary>
        [DataMember]
        public DateTime? StartTime { get; set; }

        /// <summary>活动结束时间</summary>
        [DataMember]
        public DateTime? EndTime { get; set; }

        /// <summary>活动总负责单位机构ID</summary>
        [DataMember]
        public string DepartmentInCharge { get; set; }

        /// <summary>活动总负责人</summary>
        [DataMember]
        public string Charger { get; set; }

        /// <summary>活动制作时间</summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>上一次修改时间</summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>是否当前正激活的对象</summary>
        [DataMember]
        public bool IsCurrent { get; set; }

        /// <summary>激活开始时间</summary>
        [DataMember]
        public DateTime? ActiveStartTime { get; set; }

        /// <summary>激活结束时间</summary>
        [DataMember]
        public DateTime? ActiveEndTime { get; set; }

        /// <summary>活动分类,normal=大型线路安保,simple=简易安保</summary>
        [DataMember]
        public string Category { get; set; }

        /// <summary>事故级别</summary>
        [DataMember]
        public string AccidentLevel { get; set; }

        /// <summary>是否编辑</summary>
        [DataMember]
        public bool IsEdit { get; set; }

        /// <summary>编辑账号</summary>
        [DataMember]
        public string EditAccount { get; set; }

        /// <summary>总体方案概述</summary>
        [DataMember]
        public string Overrall { get; set; }

        /// <summary>总体方案概述附件,以;号分隔的文件名称列表</summary>

        public string OverrallAttachments { get; set; }

        /// <summary>风险评估内容</summary>
        [DataMember]
        public string RiskAssess { get; set; }

        /// <summary>风险评估附件,以;号分隔的文件名称列表</summary>
        [DataMember]
        public string RiskAssessAttachments { get; set; }




        [DataMember]
        public List<ActivityTaskDto> TaskList { get; set; }
    }

    public class ActivityTaskDto
    {

        /// <summary>
        /// 主键ID
        /// </summary>

        public string ID { get; set; }

        /// <summary>
        /// 关联活动：对应活动ID
        /// </summary>

        public string ActivityID { get; set; }

        /// <summary>
        /// 方案名称
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 方案类型:对应数据字典中的字典代码
        /// </summary>

        public string Type { get; set; }

        /// <summary>
        /// 方案负责单位:对应活动分组中的分组责任单位
        /// </summary>

        public string DepartmentInCharge { get; set; }

        /// <summary>
        /// 方案负责人:对应活动分组中的方案负责人
        /// </summary>   
        public string Charger { get; set; }

        /// <summary>
        /// 当前状态
        /// <para>0=未开始，1=已开始，2=已结束</para>
        /// </summary>

        public int Status { get; set; }

        /// <summary>
        /// 方案描述
        /// </summary>

        public string Remark { get; set; }

        /// <summary>
        /// 创建时间戮
        /// </summary>

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 上一次修改时间
        /// </summary>

        public DateTime? LastUpdateTime { get; set; }


        /// <summary>
        /// 任务开始时间
        /// </summary>   
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 任务结束时间
        /// </summary>

        public DateTime? EndTime { get; set; }

        #region 2017-06-28 应柳州的需求增加字段
        /// <summary>
        /// 任务进场时间
        /// </summary>

        public DateTime? EnterTime { get; set; }

        /// <summary>
        /// 任务离场时间
        /// </summary>

        public DateTime? LeaveTime { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>

        public string Memo { get; set; }

        /// <summary>
        /// 传感器ID
        /// </summary>

        public string ISNID { get; set; }

        /// <summary>
        /// 场馆ID
        /// </summary>

        public virtual string VenueID { get; set; }


        #endregion



    }

    [Serializable]
    [ProtoBuf.ProtoContract]
    public class Person
    {
        [ProtoBuf.ProtoMember(1)]
        public string Id { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public Address Address { get; set; }


    }

    [Serializable]
    [ProtoBuf.ProtoContract]
    public class Address
    {
        [ProtoBuf.ProtoMember(1)]
        public string Line1 { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string Line2 { get; set; }
    }

    [Serializable]
    public class MedicalSub
    {
        [XmlAttribute]
        public string Id;

        [XmlElementAttribute]
        public string Name;

        public MedicalType MedicalType;
    }

    [Serializable]
    public class MedicalType
    {
        [XmlAttribute]
        public string Id;

        [XmlElementAttribute]
        public string Name;
    }
    public class SetSystemDateTime
    {

        [DllImportAttribute("Kernel32.dll")]
        public static extern void GetLocalTime(SystemTime st);

        [DllImportAttribute("Kernel32.dll")]
        public static extern void SetLocalTime(SystemTime st);

    }
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class SystemTime
    {

        public ushort vYear;

        public ushort vMonth;

        public ushort vDayOfWeek;

        public ushort vDay;

        public ushort vHour;

        public ushort vMinute;

        public ushort vSecond;

    }

    #endregion

}
