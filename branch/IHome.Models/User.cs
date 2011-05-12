using System;
namespace IHome.Models
{

    public class User
    {
        #region 私有字段
        private string _token;

        public string token
        {
            get { return _token; }
            set { _token = value; }
        }
        private ulong _id;
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
        public ulong id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string user_login
        {
            get { return _user_login; }
            set { _user_login = value; }
        }
        public string user_pass
        {
            get { return _user_pass; }
            set { _user_pass = value; }
        }
        public string user_nicename
        {
            get { return _user_nicename; }
            set { _user_nicename = value; }
        }
        public string user_email
        {
            get { return _user_email; }
            set { _user_email = value; }
        }
        public string user_url
        {
            get { return _user_url; }
            set { _user_url = value; }
        }
        public DateTime user_registered
        {
            get { return _user_registered; }
            set { _user_registered = value; }
        }
        public string user_activation_key
        {
            get { return _user_activation_key; }
            set { _user_activation_key = value; }
        }
        public int user_status
        {
            get { return _user_status; }
            set { _user_status = value; }
        }
        public string display_name
        {
            get { return _display_name; }
            set { _display_name = value; }
        }
        #endregion
    }
}
