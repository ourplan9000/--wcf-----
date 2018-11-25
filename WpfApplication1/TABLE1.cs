using System;
namespace WpfApplication1
{
    
    /// <summary>
    /// 实体类TABLE1 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Table1
    {
        public Table1()
        { }
        #region Model
        private decimal _id;
        private string testCol;
        /// <summary>
        /// 
        /// </summary>
        public decimal ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestCol
        {
            set { testCol = value; }
            get { return testCol; }
        }
        #endregion Model

    }
    
}

