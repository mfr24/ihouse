//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace IHome.Server.Data
{
    public partial class CbooMainEntities : ObjectContext
    {
        public const string ConnectionString = "name=CbooMainEntities";
        public const string ContainerName = "CbooMainEntities";
    
        #region Constructors
    
        public CbooMainEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public CbooMainEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public CbooMainEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<base_community_baseinfo> base_community_baseinfo
        {
            get { return _base_community_baseinfo  ?? (_base_community_baseinfo = CreateObjectSet<base_community_baseinfo>("base_community_baseinfo")); }
        }
        private ObjectSet<base_community_baseinfo> _base_community_baseinfo;
    
        public ObjectSet<base_community_buildinginfo> base_community_buildinginfo
        {
            get { return _base_community_buildinginfo  ?? (_base_community_buildinginfo = CreateObjectSet<base_community_buildinginfo>("base_community_buildinginfo")); }
        }
        private ObjectSet<base_community_buildinginfo> _base_community_buildinginfo;
    
        public ObjectSet<base_datadic_detailinfo> base_datadic_detailinfo
        {
            get { return _base_datadic_detailinfo  ?? (_base_datadic_detailinfo = CreateObjectSet<base_datadic_detailinfo>("base_datadic_detailinfo")); }
        }
        private ObjectSet<base_datadic_detailinfo> _base_datadic_detailinfo;
    
        public ObjectSet<base_datadic_iteminfo> base_datadic_iteminfo
        {
            get { return _base_datadic_iteminfo  ?? (_base_datadic_iteminfo = CreateObjectSet<base_datadic_iteminfo>("base_datadic_iteminfo")); }
        }
        private ObjectSet<base_datadic_iteminfo> _base_datadic_iteminfo;
    
        public ObjectSet<base_permit_define> base_permit_define
        {
            get { return _base_permit_define  ?? (_base_permit_define = CreateObjectSet<base_permit_define>("base_permit_define")); }
        }
        private ObjectSet<base_permit_define> _base_permit_define;
    
        public ObjectSet<base_permit_roledefine> base_permit_roledefine
        {
            get { return _base_permit_roledefine  ?? (_base_permit_roledefine = CreateObjectSet<base_permit_roledefine>("base_permit_roledefine")); }
        }
        private ObjectSet<base_permit_roledefine> _base_permit_roledefine;
    
        public ObjectSet<base_rolepermitionrelationinfo> base_rolepermitionrelationinfo
        {
            get { return _base_rolepermitionrelationinfo  ?? (_base_rolepermitionrelationinfo = CreateObjectSet<base_rolepermitionrelationinfo>("base_rolepermitionrelationinfo")); }
        }
        private ObjectSet<base_rolepermitionrelationinfo> _base_rolepermitionrelationinfo;
    
        public ObjectSet<base_roleuserrelationinfo> base_roleuserrelationinfo
        {
            get { return _base_roleuserrelationinfo  ?? (_base_roleuserrelationinfo = CreateObjectSet<base_roleuserrelationinfo>("base_roleuserrelationinfo")); }
        }
        private ObjectSet<base_roleuserrelationinfo> _base_roleuserrelationinfo;
    
        public ObjectSet<sys_user_baseinfo> sys_user_baseinfo
        {
            get { return _sys_user_baseinfo  ?? (_sys_user_baseinfo = CreateObjectSet<sys_user_baseinfo>("sys_user_baseinfo")); }
        }
        private ObjectSet<sys_user_baseinfo> _sys_user_baseinfo;

        #endregion
    }
}
