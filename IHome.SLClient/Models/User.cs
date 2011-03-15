using System;
using System.Collections.Generic;
using System.Text;
namespace IHome.Models
{
    /// <summary>
    /// 实体类Wp_user
    /// </summary>
    public class User
    {
        #region 私有字段
        private string _token;

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        private ulong _iD;
        private string _user_login;
        private string _user_pass;
        private string _user_nicename;
        private string _user_email;
        private string _user_url;
        private DateTime _user_registered;
        private string _user_activation_key;
        private int _user_status;
        private string _display_name;
        #endregion

        #region 公开属性
        public ulong ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        public string User_login
        {
            get { return _user_login; }
            set { _user_login = value; }
        }
        public string User_pass
        {
            get { return _user_pass; }
            set { _user_pass = value; }
        }
        public string User_nicename
        {
            get { return _user_nicename; }
            set { _user_nicename = value; }
        }
        public string User_email
        {
            get { return _user_email; }
            set { _user_email = value; }
        }
        public string User_url
        {
            get { return _user_url; }
            set { _user_url = value; }
        }
        public DateTime User_registered
        {
            get { return _user_registered; }
            set { _user_registered = value; }
        }
        public string User_activation_key
        {
            get { return _user_activation_key; }
            set { _user_activation_key = value; }
        }
        public int User_status
        {
            get { return _user_status; }
            set { _user_status = value; }
        }
        public string Display_name
        {
            get { return _display_name; }
            set { _display_name = value; }
        }
        #endregion
    }
}
