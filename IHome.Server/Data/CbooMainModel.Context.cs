﻿//------------------------------------------------------------------------------
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
using IHome.Models.Data;
namespace IHome.Server.Data
{
    public partial class CbooEntities : ObjectContext
    {
        public const string ConnectionString = "name=CbooEntities";
        public const string ContainerName = "CbooEntities";
    
        #region Constructors
    
        public CbooEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public CbooEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public CbooEntities(EntityConnection connection)
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
    
        public ObjectSet<base_personal_push_config> base_personal_push_config
        {
            get { return _base_personal_push_config  ?? (_base_personal_push_config = CreateObjectSet<base_personal_push_config>("base_personal_push_config")); }
        }
        private ObjectSet<base_personal_push_config> _base_personal_push_config;
    
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
    
        public ObjectSet<customer_baseinfo> customer_baseinfo
        {
            get { return _customer_baseinfo  ?? (_customer_baseinfo = CreateObjectSet<customer_baseinfo>("customer_baseinfo")); }
        }
        private ObjectSet<customer_baseinfo> _customer_baseinfo;
    
        public ObjectSet<customer_demandinfo> customer_demandinfo
        {
            get { return _customer_demandinfo  ?? (_customer_demandinfo = CreateObjectSet<customer_demandinfo>("customer_demandinfo")); }
        }
        private ObjectSet<customer_demandinfo> _customer_demandinfo;
    
        public ObjectSet<customer_traceinfo> customer_traceinfo
        {
            get { return _customer_traceinfo  ?? (_customer_traceinfo = CreateObjectSet<customer_traceinfo>("customer_traceinfo")); }
        }
        private ObjectSet<customer_traceinfo> _customer_traceinfo;
    
        public ObjectSet<house_baseinfo> house_baseinfo
        {
            get { return _house_baseinfo  ?? (_house_baseinfo = CreateObjectSet<house_baseinfo>("house_baseinfo")); }
        }
        private ObjectSet<house_baseinfo> _house_baseinfo;
    
        public ObjectSet<house_intrustinfo> house_intrustinfo
        {
            get { return _house_intrustinfo  ?? (_house_intrustinfo = CreateObjectSet<house_intrustinfo>("house_intrustinfo")); }
        }
        private ObjectSet<house_intrustinfo> _house_intrustinfo;
    
        public ObjectSet<house_key_receiptioninfo> house_key_receiptioninfo
        {
            get { return _house_key_receiptioninfo  ?? (_house_key_receiptioninfo = CreateObjectSet<house_key_receiptioninfo>("house_key_receiptioninfo")); }
        }
        private ObjectSet<house_key_receiptioninfo> _house_key_receiptioninfo;
    
        public ObjectSet<house_markedinfo> house_markedinfo
        {
            get { return _house_markedinfo  ?? (_house_markedinfo = CreateObjectSet<house_markedinfo>("house_markedinfo")); }
        }
        private ObjectSet<house_markedinfo> _house_markedinfo;
    
        public ObjectSet<house_picinfo> house_picinfo
        {
            get { return _house_picinfo  ?? (_house_picinfo = CreateObjectSet<house_picinfo>("house_picinfo")); }
        }
        private ObjectSet<house_picinfo> _house_picinfo;
    
        public ObjectSet<house_push_logs> house_push_logs
        {
            get { return _house_push_logs  ?? (_house_push_logs = CreateObjectSet<house_push_logs>("house_push_logs")); }
        }
        private ObjectSet<house_push_logs> _house_push_logs;
    
        public ObjectSet<house_traceinfo> house_traceinfo
        {
            get { return _house_traceinfo  ?? (_house_traceinfo = CreateObjectSet<house_traceinfo>("house_traceinfo")); }
        }
        private ObjectSet<house_traceinfo> _house_traceinfo;
    
        public ObjectSet<house_viewhouse_baseinfo> house_viewhouse_baseinfo
        {
            get { return _house_viewhouse_baseinfo  ?? (_house_viewhouse_baseinfo = CreateObjectSet<house_viewhouse_baseinfo>("house_viewhouse_baseinfo")); }
        }
        private ObjectSet<house_viewhouse_baseinfo> _house_viewhouse_baseinfo;
    
        public ObjectSet<house_viewhouse_subinfo> house_viewhouse_subinfo
        {
            get { return _house_viewhouse_subinfo  ?? (_house_viewhouse_subinfo = CreateObjectSet<house_viewhouse_subinfo>("house_viewhouse_subinfo")); }
        }
        private ObjectSet<house_viewhouse_subinfo> _house_viewhouse_subinfo;
    
        public ObjectSet<sys_user_baseinfo> sys_user_baseinfo
        {
            get { return _sys_user_baseinfo  ?? (_sys_user_baseinfo = CreateObjectSet<sys_user_baseinfo>("sys_user_baseinfo")); }
        }
        private ObjectSet<sys_user_baseinfo> _sys_user_baseinfo;
    
        public ObjectSet<sys_user_community_config> sys_user_community_config
        {
            get { return _sys_user_community_config  ?? (_sys_user_community_config = CreateObjectSet<sys_user_community_config>("sys_user_community_config")); }
        }
        private ObjectSet<sys_user_community_config> _sys_user_community_config;
    
        public ObjectSet<sys_user_region_config> sys_user_region_config
        {
            get { return _sys_user_region_config  ?? (_sys_user_region_config = CreateObjectSet<sys_user_region_config>("sys_user_region_config")); }
        }
        private ObjectSet<sys_user_region_config> _sys_user_region_config;
    
        public ObjectSet<sys_user_relationinfo> sys_user_relationinfo
        {
            get { return _sys_user_relationinfo  ?? (_sys_user_relationinfo = CreateObjectSet<sys_user_relationinfo>("sys_user_relationinfo")); }
        }
        private ObjectSet<sys_user_relationinfo> _sys_user_relationinfo;
    
        public ObjectSet<usys_community_baseinfo> usys_community_baseinfo
        {
            get { return _usys_community_baseinfo  ?? (_usys_community_baseinfo = CreateObjectSet<usys_community_baseinfo>("usys_community_baseinfo")); }
        }
        private ObjectSet<usys_community_baseinfo> _usys_community_baseinfo;
    
        public ObjectSet<usys_community_buildinginfo> usys_community_buildinginfo
        {
            get { return _usys_community_buildinginfo  ?? (_usys_community_buildinginfo = CreateObjectSet<usys_community_buildinginfo>("usys_community_buildinginfo")); }
        }
        private ObjectSet<usys_community_buildinginfo> _usys_community_buildinginfo;

        #endregion
    }
}
