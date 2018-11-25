using System;
 

namespace WpfApplication1
{
    /// <summary>
    /// 执勤岗位(安保活动任务下的执勤岗位，任务不同，执勤岗位按活动任务部署执勤岗位)
    /// </summary>
    
    public class LSS_T_DUTYSTATION
    {
        /// <summary>
        /// 本岗位所属的活动的标识ID，冗余字段，执勤岗位目前从属于任务
        /// </summary>
        public string Activityid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 地图点经度,关联到T_MAPPOINT
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 地图点纬度,关联到T_MAPPOINT
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 警力需求
        /// </summary>
        public int Policeamountneed { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Charger { get; set; }

        /// <summary>
        /// 上一次更新时间
        /// </summary>
        public DateTime Lastupdatetime { get; set; }

		/// <summary>
		/// 安保活动任务ID
		/// </summary>
		public string ActivityTaskID { get; set; }

		/// <summary>
		/// 岗位类别ID，在Xml中匹配
		/// </summary>
		public string StationTypeID { get; set; }

		/// <summary>
		/// 岗位半径，用于确定警力是否离岗
		/// </summary>
		public double? StationRange { get; set; }

        /// <summary>
        /// 是否撤岗
        /// </summary>
        public int IsCancel { get; set; }

        /// <summary>
        /// 场馆ID
        /// </summary>
        public string VenueID { get; set; }


        /// <summary>
        /// 岗位职责
        /// </summary>
        public string Responsibility { get; set; }

        /// <summary>
        /// 装备
        /// </summary>
        public string PEquipment { get; set; }

        /// <summary>
        /// 车辆信息ID
        /// </summary>
        public string CarID { get; set; }
       /// <summary>
       /// 法律条款
       /// </summary>
        public string Laws { get; set; }
        public virtual string ID { get; set; }

       
        public virtual DateTime? CREATETIME { get; set; }

        
        public DateTime? RowStamp { get; set; }
        /// <summary>
        /// 返回本Entity的深度拷贝副本
        /// </summary>
       
    }
}