USE [CBoo_Main]
GO
/****** Object:  Table [dbo].[Base_Permit_RoleDefine]    Script Date: 03/14/2011 16:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Permit_RoleDefine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Permit_RoleDefine](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [varchar](50) NULL,
	[CityId] [uniqueidentifier] NULL,
	[CityName] [varchar](50) NULL,
	[CompanyId] [uniqueidentifier] NULL,
	[CompanyName] [varchar](50) NULL,
	[IsShow] [bit] NULL CONSTRAINT [DF_Base_Permit_RoleDefine_IsShow]  DEFAULT ((1)),
	[DefRole] [bit] NULL DEFAULT ((0)),
 CONSTRAINT [PK_Base_Permit_RoleDefine] PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'true:显示;false:非显示' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Permit_RoleDefine', @level2type=N'COLUMN', @level2name=N'IsShow'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色定义表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Permit_RoleDefine'

GO
/****** Object:  Table [dbo].[Base_RolePermitionRelationInfo]    Script Date: 03/14/2011 16:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_RolePermitionRelationInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_RolePermitionRelationInfo](
	[RecordId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NULL,
	[PermitId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_BASE_ROLEPERMITIONRELATIONI] PRIMARY KEY NONCLUSTERED 
(
	[RecordId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限关系表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RolePermitionRelationInfo'

GO
/****** Object:  Table [dbo].[Base_RoleUserRelationInfo]    Script Date: 03/14/2011 16:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_RoleUserRelationInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_RoleUserRelationInfo](
	[RecordId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_BASE_ROLEUSERRELATIONINFO] PRIMARY KEY NONCLUSTERED 
(
	[RecordId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色用户关系吧' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleUserRelationInfo'

GO
/****** Object:  Table [dbo].[Sys_User_BaseInfo]    Script Date: 03/14/2011 16:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_User_BaseInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sys_User_BaseInfo](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserCode] [varchar](50) NULL,
	[UserName] [varchar](150) NULL,
	[Department] [varchar](150) NULL,
	[CompanyName] [varchar](150) NULL,
	[Password] [varchar](200) NULL,
	[CityId] [uniqueidentifier] NULL,
	[CityName] [varchar](50) NULL,
	[Validate] [bit] NULL,
	[UserType] [int] NULL,
	[IDType] [varchar](50) NULL,
	[IDNum] [varchar](150) NULL,
	[Mobile] [varchar](50) NULL,
	[OfficeTel] [varchar](50) NULL,
	[Email] [varchar](250) NULL,
	[Remark] [varchar](max) NULL,
	[Regtime] [datetime] NULL,
	[Updatetime] [datetime] NULL,
	[LastLoginTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_User_BaseInfo] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'UserId'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'UserCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'UserName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户部门（仅仅作为一个属性，无组织架构概念）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Department'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户公司（仅仅作为一个属性，无组织架构概念）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'CompanyName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码（MD5加密）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Password'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户所在城市' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'CityId'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户所在城市' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'CityName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户是否被冻结（被冻结后不能登录）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Validate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型（枚举：免费用户；普通收费用户；vip收费用户等）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'UserType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证据类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'IDType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证件号码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'IDNum'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Mobile'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'办公电话' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'OfficeTel'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮箱' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Email'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Regtime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Sys_User_BaseInfo', @level2type=N'COLUMN', @level2name=N'Updatetime'

GO
/****** Object:  Table [dbo].[Base_Permit_Define]    Script Date: 03/14/2011 16:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Permit_Define]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Permit_Define](
	[PermitID] [uniqueidentifier] NOT NULL,
	[PermitCode] [varchar](200) NULL,
	[PermitName] [varchar](200) NULL,
	[PermitGroup] [varchar](50) NULL,
 CONSTRAINT [PK_BASE_PERMIT_DEFINE] PRIMARY KEY CLUSTERED 
(
	[PermitID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Permit_Define', @level2type=N'COLUMN', @level2name=N'PermitID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Permit_Define', @level2type=N'COLUMN', @level2name=N'PermitCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Permit_Define', @level2type=N'COLUMN', @level2name=N'PermitName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限分类名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Permit_Define', @level2type=N'COLUMN', @level2name=N'PermitGroup'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限定义表
   ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Permit_Define'

