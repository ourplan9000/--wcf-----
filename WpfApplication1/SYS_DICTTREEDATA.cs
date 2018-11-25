using System;
namespace WpfApplication1
{
    /// <summary>
    /// 实体类SYS_DICTTREEDATA 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [ProtoBuf.ProtoContract]
    public class SYS_DICTTREEDATA
    {
        public SYS_DICTTREEDATA()
        { }
        #region Model
        private string _treeid;
        private string _nodeid;
        private string _parentnodeid;
        private string _code;
        private decimal? _orderno;
        private string _data1;
        private string _data2;
        private string _data3;
        /// <summary>
        /// 
        /// </summary>

        [ProtoBuf.ProtoMember(1)]
        public string TREEID
        {
            set { _treeid = value; }
            get { return _treeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public string NODEID
        {
            set { _nodeid = value; }
            get { return _nodeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(3)]
        public string PARENTNODEID
        {
            set { _parentnodeid = value; }
            get { return _parentnodeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(4)]
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(5)]
        public decimal? ORDERNO
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(6)]
        public string DATA1
        {
            set { _data1 = value; }
            get { return _data1; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [ProtoBuf.ProtoMember(7)]
        public string DATA2
        {
            set { _data2 = value; }
            get { return _data2; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [ProtoBuf.ProtoMember(8)]
        public string DATA3
        {
            set { _data3 = value; }
            get { return _data3; }
        }
        #endregion Model

    }
}

