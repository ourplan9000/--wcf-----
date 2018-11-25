using System;
using System.Runtime.Serialization;
 

namespace Hytera.SystemBase.IServices.Model
{
    /// <summary>
    /// 可呼叫对象
    /// </summary>
    [DataContract]
    [Serializable]
   
    public class CallableObjectDTO  
    {
     

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
       
        public string GUID { get; set; }

        /// <summary>
        /// 对象类型，STAFF=警员，CAR=车辆，NO=未分配手台
        /// </summary>
        [DataMember]
        public string ObjType { get; set; }

        /// <summary>
        /// 人员为STAFF_TYPE，车辆为CAR_TYPE,手台为NUMBER_TYPE
        /// </summary>
        [DataMember]
        public string ObjType2 { get; set; }

        /// <summary>
        /// 人员为IsLeader的值，车辆为IS_VALID值，手台为GPS_INTERVAL
        /// </summary>
        [DataMember]
        public int Param1 { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        ///     次呼叫号（手机号码）
        /// </summary>
        [DataMember]
        public string Mobile { get; set; }

        /// <summary>
        ///     第三呼叫号（座机号码）
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// 手台呼叫号码
        /// </summary>
        [DataMember]
        public string InterPhoneGuid { get; set; }

        /// <summary>
        /// 所属单位的Guid
        /// </summary>
        [DataMember]
        public string OrgGuid { get; set; }

        /// <summary>
        /// 所属单位的名称
        /// </summary>
        [DataMember]
        public string Org_Name { get; set; }

        /// <summary>
        /// 系统编号
        /// </summary>
        [DataMember]
        public string SystemID { get; set; }

        /// <summary>
        /// Puc Guid
        /// </summary>
        [DataMember]
        public string PucID { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        [DataMember]
        public string DeviceID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DeviceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DeviceNumber { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [DataMember]
        public string DeviceType { get; set; }

        /// <summary>
        /// 设备的呼叫号码类型
        /// </summary>
        [DataMember]
        public string NumberType { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [DataMember]
        public double? GpsDirection { get; set; }

        /// <summary>
        /// 经度值
        /// </summary>
        [DataMember]
        public double? GpsLongitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [DataMember]
        public double? GpsLatitude { get; set; }

        /// <summary>
        /// 移动速度
        /// </summary>
        [DataMember]
        public double? GpsSpeed { get; set; }

        /// <summary>
        /// GPS状态
        /// </summary>
        [DataMember]
        public string GpsState { get; set; }

        /// <summary>
        /// 定位数据接收时间
        /// </summary>
        [DataMember]
        public DateTime? GpsReceiveTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PdtIsOnline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PdtState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? PdtReceiveTime { get; set; }
    }
}