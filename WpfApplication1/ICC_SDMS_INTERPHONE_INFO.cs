//   * Copyright (c) 2016,海能达通信股份有限公司
//   * All rights reserved.
//   *
//   * 文件名称：ICC_SDMS_INTERPHONE_INFO.cs
//   * 文件标识：
//   * 摘要：
//   * -------------------------------------------------------
//   * 当前版本：
//   * 作者：l18536
//   * 完成日期：2016 年 11 月 09 日 16:26 分
//   *--------------------------------------------------------

using System;
 
using Newtonsoft.Json;

namespace WpfApplication1
{
   
    public class ICC_SDMS_INTERPHONE_INFO  
    {
        
        
        public virtual string INTERPHONE_GUID { get; set; }

        
        public virtual string PUC_ID { get; set; }

        /// <summary>
        ///     设备号码,为终端的SSI  可能重号
        /// </summary>
       
        public virtual string DEVICE_ID { get; set; }

        
        public virtual string DEVICE_TYPE { get; set; }

        /// <summary>
        ///     设备编号
        /// </summary> 
        public virtual string DEVICE_NUMBER { get; set; }

        /// <summary>
        ///     设备名称
        /// </summary> 
        public virtual string DEVICE_NAME { get; set; }

        /// <summary>
        ///     数据字典 状态
        /// </summary> 
        public virtual string STATUS { get; set; }

        /// <summary>
        ///     设备厂商
        /// </summary> 
        public virtual string DEVICE_MAKE { get; set; }
         
        public virtual string NUMBER_TYPE { get; set; }

        /// <summary>
        ///     使用设备的部门GUID号
        /// </summary> 
        public virtual string ORG_GUID { get; set; }

        /// <summary>
        ///     设备图标
        /// </summary> 
        public virtual byte[] DEVICE_ICON { get; set; }

        /// <summary>
        ///     是否有GPS模块
        /// </summary> 
        public virtual decimal? HAS_GPS { get; set; }

        /// <summary>
        ///     是否启动GPS模块
        /// </summary> 
        public virtual decimal? ENABLE_GPS { get; set; }
         
        public virtual decimal? AND_OR_FLAG { get; set; }

        /// <summary>
        ///     GPS上传周期
        /// </summary> 
        public virtual decimal? GPS_INTERVAL { get; set; }
         
        public virtual decimal? GPS_CHANNEL { get; set; }
         
        public virtual decimal? DISTANCE { get; set; }

        /// <summary>
        ///     最后一次GPS上传时间
        /// </summary> 
        public virtual DateTime? GPS_DATETIME { get; set; }

        /// <summary>
        ///     经度
        /// </summary> 
        public virtual decimal? LONGITUDE { get; set; }

        /// <summary>
        ///     纬度
        /// </summary> 
        public virtual decimal? LATITUDE { get; set; }

        /// <summary>
        ///     是否有显示屏
        /// </summary> 
        public virtual decimal? HAS_SCREEN { get; set; }
         
        public virtual decimal? ENABLE_FLAG { get; set; }

        /// <summary>
        ///     参与组
        /// </summary> 
        public virtual string JOIN_GROUP { get; set; }

        /// <summary>
        ///     参与组说明
        /// </summary> 
        public virtual string JOIN_GROUP_INFO { get; set; }

        /// <summary>
        ///     响应组
        /// </summary> 
        public virtual string RESPONSE_GROUP { get; set; }

        /// <summary>
        ///     响应组说明
        /// </summary> 
        public virtual string RESPONSE_GROUP_INFO { get; set; }

        /// <summary>
        ///     隐含组
        /// </summary> 
        public virtual string IMPLICT_GROUP { get; set; }

        /// <summary>
        ///     隐含组说明
        /// </summary> 
        public virtual string IMPLICT_GROUP_INFO { get; set; }

        /// <summary>
        ///     创建人
        /// </summary> 
        public virtual string CREATEUSER { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary> 
        public virtual DateTime? CREATETIME { get; set; }

        /// <summary>
        ///     修改人,取最后一次修改值
        /// </summary> 
        public virtual string UPDATEUSER { get; set; }

        /// <summary>
        ///     修改时间,取最后一次修改值
        /// </summary> 
        public virtual DateTime? UPDATETIME { get; set; }

        /// <summary>
        ///     备注
        /// </summary> 
        public virtual string REMARK { get; set; }

        /// <summary>
        ///     使用者GUID
        /// </summary> 
        public virtual string USER_GUID { get; set; }

        /// <summary>
        ///     使用者类型  根据数据字典
        /// </summary>
      
        public virtual string USER_TYPE { get; set; }

        /// <summary>
        ///     使用者名称
        /// </summary> 
        public virtual string USER_NAME { get; set; }

        /// <summary>
        ///     部门内部编号
        /// </summary> 
        public virtual string ORG_IDENTIFIER { get; set; }

        /// <summary>
        ///     系统ID
        /// </summary> 
        public virtual string SYSTEM_ID { get; set; }

       
    }
}