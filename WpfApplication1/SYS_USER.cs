using System;
namespace WpfApplication1
{
    /// <summary>
    /// 实体类SYS_USER 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [ProtoBuf.ProtoContract]
    public class SYS_USER
    {
        public SYS_USER()
        { }
        #region Model
        private string _userid;
        private string _username;
        private string _loginid;
        private string _password;
        private string _districtcode;
        private string _description;
        private string _userduty;
        private string _usermobienumber;
        private string _useremail;
        private string _userthumbprint;
        private DateTime? _createtime;
        private decimal? _limitlogin;
        private string _usertype;
        private string _unitid;
        private decimal? _isadmin;
        private decimal? _status;
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(1)]
        public string USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public string USERNAME
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
         
        public string LOGINID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoBuf.ProtoMember(3)]
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DISTRICTCODE
        {
            set { _districtcode = value; }
            get { return _districtcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USERDUTY
        {
            set { _userduty = value; }
            get { return _userduty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USERMOBIENUMBER
        {
            set { _usermobienumber = value; }
            get { return _usermobienumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USEREMAIL
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USERTHUMBPRINT
        {
            set { _userthumbprint = value; }
            get { return _userthumbprint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATETIME
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LIMITLOGIN
        {
            set { _limitlogin = value; }
            get { return _limitlogin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USERTYPE
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UNITID
        {
            set { _unitid = value; }
            get { return _unitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ISADMIN
        {
            set { _isadmin = value; }
            get { return _isadmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

