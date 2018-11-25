//   * Copyright (c) 2016,海能达通信股份有限公司
//   * All rights reserved.
//   *
//   * 文件名称：IShareFacade.cs
//   * 文件标识：
//   * 摘要：
//   * -------------------------------------------------------
//   * 当前版本：
//   * 作者：y20419
//   * 完成日期：2018 年 10 月 16 日 8:53 分
//   *--------------------------------------------------------

using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;


namespace WpfApplication1
{
   [HttpHost("http://192.168.0.210:9191/")]
    public interface IShareFacade : IHttpApi
    {
       [HttpGet("services/sharedatafacade/v1/getallcallobject")]
        Task<string> getallcallobject();
    }
}